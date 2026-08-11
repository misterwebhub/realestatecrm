#!/usr/bin/env python3
"""
legacy_import.py
=================

Imports agents/brokers, arazis, plots, customers, customer_bonds,
customer_bond_payments, real kisans + kisan_bonds, registries and
customer_bond_cheques from the OLD SQL Server system ("amar" database,
old ASP.NET app) into "heeddatabase" -- a MySQL database that now has the
EXACT SAME SCHEMA as the live Laravel CRM (realestatecrm_run), rebuilt
table-for-table from the live app's own SQL dump. Point your reports at
heeddatabase and query "give me everything for arazi X" the same way you
would against the live app.

Why Python instead of the Laravel `legacy:import` artisan command that was
drafted earlier: this machine's PHP build has no sqlsrv/pdo_sqlsrv driver
installed (and installing it requires an admin-level DLL + ODBC driver
install). Python already has `pyodbc` + the "ODBC Driver 18 for SQL Server"
available, and `mysql-connector-python` for the MySQL side, so this runs
right now with zero extra installs.

Source tables used (confirmed against the LIVE database, not guessed):
  - amar.agent                (7 rows)  -> heeddatabase.agents
  - amar.arazimap             (3,803)   -> heeddatabase.arazis (distinct arazi codes)
                                        -> heeddatabase.plots  (arazi + plotno + status)
  - wjstar1.customerreg1      (3,310)   -> heeddatabase.customers
                                        -> heeddatabase.customer_bonds
                                        -> heeddatabase.customer_bond_plot (pivot)
  - wjstar1.recipt1           (40,956)  -> heeddatabase.customer_bond_payments
  - amar.newkishan            (107)     -> heeddatabase.kisans (real, one per matched arazi)
                                        -> heeddatabase.kisan_bonds
  - amar.customerdeed         (2,130)   -> heeddatabase.registries
                                        -> heeddatabase.registry_plot (pivot, best-effort)
  - amar.chequedetails        (17,921)  -> heeddatabase.customer_bond_cheques

Real relationships confirmed by querying the live data (not assumed from
the old .cs source):
  - arazimap.CUSTREGNO links a plot row directly to customerreg1.CUSTREGNO.
    (customerreg1.APPNO/plotno are messy free text and NOT reliable joins.)
  - recipt1.CUSTREGNO links a payment directly to customerreg1.CUSTREGNO.
  - recipt1.RECIPT is globally unique across the whole table -> safe natural key.
  - customerreg1.agentid matches amar.agent.formid but is only populated on
    5 of 3,310 rows. customerreg1.CHECKBY carries an informal broker/agent
    NAME on most rows but doesn't match any formal agent record. We resolve
    broker_id when agentid matches a real agent, and ALWAYS keep the raw
    CHECKBY text in customer_bonds.broker_comment so it isn't lost.
  - newkishan.arazi matches arazimap arazi codes for 56 of 107 rows -- those
    56+ rows (multiple newkishan rows can share one arazi) get a REAL kisan
    record (replacing the placeholder) plus one kisan_bonds row each.
  - customerdeed.CUSTREGNO/.arazi resolve to customers/arazis for most rows;
    a registries row is only created when BOTH resolve (customer_id and
    arazi_id are NOT NULL FKs). plotno in customerdeed is messy free text
    ("45,52", "9C") -- plot_id is resolved only on an exact, comma-split
    token match against an existing plot title for that arazi, never guessed.
  - chequedetails.CUSTREGNO resolves to an existing customer_bonds row for
    17,866 of 17,921 rows (near total) -- customer_bond_cheques is only
    created when customer_bond_id resolves (NOT NULL FK).

Behavior:
  - DRY RUN by default: connects to both databases, prints row counts and a
    few sample transformed rows, writes nothing.
  - --commit: actually TRUNCATEs and reloads the target tables in
    heeddatabase (agents, kisans, arazis, plots, customers, customer_bonds,
    customer_bond_payments, customer_bond_plot, kisan_bonds, registries,
    registry_plot, customer_bond_cheques). This is a full rebuild each run,
    not an incremental upsert -- heeddatabase is a dedicated, disposable
    reporting database, so "wipe and reload" is simpler and safer than
    partial upsert logic. It does NOT touch your live realestatecrm_run
    database.
  - --limit N: cap how many source rows are processed per step, for testing.

Usage:
    python scripts/legacy_import.py                  # dry run
    python scripts/legacy_import.py --limit 20        # dry run, small sample
    python scripts/legacy_import.py --commit           # real import, full data
    python scripts/legacy_import.py --commit --limit 50   # real import, small sample
"""

import argparse
import re
import sys
from datetime import date, datetime
from decimal import Decimal, InvalidOperation

try:
    import pyodbc
except ImportError:
    print("ERROR: pyodbc is not installed. Run: pip install pyodbc")
    sys.exit(1)

try:
    import mysql.connector
except ImportError:
    print("ERROR: mysql-connector-python is not installed. Run: pip install mysql-connector-python")
    sys.exit(1)


# --------------------------------------------------------------------------
# Connection settings
# --------------------------------------------------------------------------

LEGACY_ODBC = (
    "DRIVER={ODBC Driver 18 for SQL Server};"
    "SERVER=103.21.58.193,1433;"
    "DATABASE=amar;"
    "UID=amar;"
    "PWD=Heed@@2019;"
    "Encrypt=no;"
    "TrustServerCertificate=yes;"
    "Connection Timeout=15;"
)

MYSQL_CFG = dict(host="127.0.0.1", port=3306, user="root", password="", database="heeddatabase")

PLACEHOLDER_KISAN_REG_NO = "LEGACY-IMPORT-PLACEHOLDER"


# --------------------------------------------------------------------------
# Small helpers
# --------------------------------------------------------------------------

def clean_mobile(value):
    if value is None:
        return ""
    digits = re.sub(r"\D", "", str(value))
    return digits[:20]


def to_decimal(value):
    if value is None:
        return Decimal("0")
    if isinstance(value, Decimal):
        return value
    s = str(value).strip()
    if s == "":
        return Decimal("0")
    s = re.sub(r"[^0-9.\-]", "", s)
    if s in ("", "-", "."):
        return Decimal("0")
    try:
        return Decimal(s)
    except InvalidOperation:
        return Decimal("0")


def parse_date(value):
    """Best-effort date parser. Returns a date or None (never guesses)."""
    if value is None:
        return None
    if isinstance(value, datetime):
        return value.date()
    if isinstance(value, date):
        return value
    s = str(value).strip()
    if s in ("", "00/00/0000", "0000-00-00"):
        return None
    for fmt in ("%m/%d/%Y", "%d/%m/%Y", "%Y-%m-%d", "%d-%m-%Y", "%m-%d-%Y"):
        try:
            return datetime.strptime(s, fmt).date()
        except ValueError:
            continue
    return None


def normalize_plot_title(value):
    """arazimap.plotno is a SQL DECIMAL, e.g. Decimal('12.00') -> '12'."""
    if value is None:
        return None
    d = to_decimal(value)
    if d == d.to_integral_value():
        return str(int(d))
    return str(d.normalize())


def extract_name(name_dob_address):
    """customerreg1.NAMEDOBADDRESS is free text, e.g.:
    'SHAJDA BEGAM 02/05/1992\\r\\nW/O asgar ali 13 rachhpal pur ... 212655'
    First line, with a trailing dd/mm/yyyy date stripped, is the name."""
    if not name_dob_address:
        return "Unknown"
    first_line = str(name_dob_address).split("\r\n")[0].split("\n")[0].strip()
    first_line = re.sub(r"\d{1,2}/\d{1,2}/\d{2,4}\s*$", "", first_line).strip()
    first_line = first_line.strip(" ,.")
    return first_line or "Unknown"


def extract_address(name_dob_address):
    """Second line onward of NAMEDOBADDRESS, if present."""
    if not name_dob_address:
        return None
    parts = re.split(r"\r\n|\n", str(name_dob_address), maxsplit=1)
    if len(parts) < 2:
        return None
    addr = parts[1].strip()
    return addr or None


def map_plot_status(legacy_status):
    s = (legacy_status or "").strip().lower()
    if s == "book":
        return "booked"
    return "available"


def map_entry_type(insttype):
    s = (insttype or "").strip().lower()
    if "down" in s:
        return "advance"
    if "book" in s:
        return "advance"
    return "installment"


def map_bayana_mode(baymode):
    """newkishan.baymode is mostly free-text transaction refs, not a clean
    cash/cheque flag. Only an explicit 'cash' mention maps to cash; anything
    else (bank/RTGS ref numbers etc.) is treated as non-cash (cheque)."""
    s = (baymode or "").strip().lower()
    return "cash" if "cash" in s else "cheque"


def map_cheque_status(status, bstatus):
    s = (status or "").strip().upper()
    if s == "PAID":
        return "bounced" if (bstatus or "").strip().upper() == "BOUNCE" else "cleared"
    if s == "UNPAID":
        return "pending"
    return "pending"


def map_cheque_type(chequetype):
    s = (chequetype or "").strip().upper()
    return "mentioned" if s == "MENTION" else "not_mentioned"


def resolve_plot_id(plot_map, arazi_id, raw_plotno):
    """Best-effort, EXACT-match-only plot resolution from messy legacy free
    text (e.g. "45,52", "9C", "38"). Splits on comma, tries each token as an
    exact plot title for this arazi. Never LIKE, never guesses -- per
    CLAUDE.md, plot titles must be matched exactly. Returns (plot_id or
    None, matched_title or None)."""
    if not raw_plotno or arazi_id is None:
        return None, None
    for token in str(raw_plotno).split(","):
        title = token.strip()
        if not title:
            continue
        key = (arazi_id, title)
        if key in plot_map:
            return plot_map[key], title
    return None, None


# --------------------------------------------------------------------------
# Main
# --------------------------------------------------------------------------

def main():
    ap = argparse.ArgumentParser(description=__doc__)
    ap.add_argument("--commit", action="store_true", help="Actually write to heeddatabase. Without this, nothing is written.")
    ap.add_argument("--limit", type=int, default=0, help="Cap number of legacy rows processed per step (0 = no limit). For testing.")
    args = ap.parse_args()

    dry_run = not args.commit
    limit = args.limit if args.limit > 0 else None

    print("=" * 70)
    print("LEGACY -> heeddatabase IMPORT")
    print(f"Mode: {'DRY RUN (nothing will be written)' if dry_run else 'COMMIT (writing to heeddatabase)'}")
    if limit:
        print(f"Row limit per step: {limit}")
    print("=" * 70)

    print("\nConnecting to legacy SQL Server (amar)...")
    legacy = pyodbc.connect(LEGACY_ODBC, timeout=15)
    legacy_cur = legacy.cursor()
    print("  connected OK")

    print("Connecting to heeddatabase (MySQL)...")
    my = mysql.connector.connect(**MYSQL_CFG)
    my_cur = my.cursor()
    print("  connected OK")

    if not dry_run:
        print("\nTruncating target tables in heeddatabase...")
        my_cur.execute("SET FOREIGN_KEY_CHECKS=0")
        for t in [
            "customer_bond_cheques", "registry_plot", "registries",
            "kisan_bonds", "customer_bond_plot", "customer_bond_payments",
            "customer_bonds", "customers", "plots", "arazis", "agents", "kisans",
        ]:
            my_cur.execute(f"TRUNCATE TABLE `{t}`")
        my_cur.execute("SET FOREIGN_KEY_CHECKS=1")
        my.commit()
        print("  done")

    agent_map = {}       # legacy formid -> new agents.id
    agent_sponsor = {}   # legacy formid -> legacy sponsor formid (agentid col)
    arazi_map = {}       # legacy arazi code -> new arazis.id
    plot_map = {}        # (arazi_id, title) -> new plots.id
    customer_map = {}    # CUSTREGNO -> new customers.id
    bond_map = {}        # CUSTREGNO -> new customer_bonds.id
    custregno_arazi = {} # CUSTREGNO -> legacy arazi code (from arazimap)
    custregno_plot = {}  # CUSTREGNO -> single plot title, only if exactly one plot row
    custregno_plot_ids = {}  # CUSTREGNO -> list of new plots.id (for customer_bond_plot pivot)
    arazi_kisan_map = {}      # legacy arazi code -> new kisans.id (real kisan, from newkishan)

    # ----------------------------------------------------------------
    # STEP 1: agents
    # ----------------------------------------------------------------
    print("\n--- Step 1: agents (amar.agent) ---")
    legacy_cur.execute("SELECT formid, agentid, rank, name, mobile, agentper FROM amar.agent")
    rows = legacy_cur.fetchall()
    if limit:
        rows = rows[:limit]
    print(f"  {len(rows)} legacy agent rows")

    placeholder_kisan_id = None
    if not dry_run:
        my_cur.execute(
            "INSERT INTO kisans (reg_no, location, name, mobile, address, created_at, updated_at) "
            "VALUES (%s, %s, %s, %s, %s, NOW(), NOW())",
            (PLACEHOLDER_KISAN_REG_NO, "Legacy Import", "Legacy Import Placeholder", "0000000000", "N/A"),
        )
        placeholder_kisan_id = my_cur.lastrowid
        my.commit()
        print(f"  placeholder kisan id={placeholder_kisan_id} created")

    for r in rows:
        formid, agentid, rank, name, mobile, agentper = r
        pct = to_decimal(agentper)
        agent_sponsor[formid] = agentid
        if dry_run:
            print(f"  [dry] agent form_code={formid} name={name} sponsor(legacy)={agentid} pct={pct}")
            continue
        my_cur.execute(
            "INSERT INTO agents (broker_type, form_code, name, rank_title, mobile, "
            "commission_percentage, legacy_percent, created_at, updated_at) "
            "VALUES ('customer', %s, %s, %s, %s, %s, %s, NOW(), NOW())",
            (formid, name or "Unknown", rank, clean_mobile(mobile), pct, pct if agentper else None),
        )
        agent_map[formid] = my_cur.lastrowid
    if not dry_run:
        my.commit()
        # pass 2: sponsor hierarchy
        for formid, new_id in agent_map.items():
            sponsor_formid = agent_sponsor.get(formid)
            sponsor_id = agent_map.get(sponsor_formid) if sponsor_formid and sponsor_formid != formid else None
            if sponsor_id:
                my_cur.execute("UPDATE agents SET sponsor_agent_id=%s WHERE id=%s", (sponsor_id, new_id))
        my.commit()
        print(f"  imported {len(agent_map)} agents")

    # ----------------------------------------------------------------
    # STEP 2: arazis (distinct codes from arazimap)
    # ----------------------------------------------------------------
    print("\n--- Step 2: arazis (amar.arazimap distinct arazi) ---")
    legacy_cur.execute("SELECT DISTINCT arazi FROM amar.arazimap WHERE arazi IS NOT NULL AND arazi <> ''")
    arazi_codes = [r[0] for r in legacy_cur.fetchall()]
    if limit:
        arazi_codes = arazi_codes[:limit]
    print(f"  {len(arazi_codes)} distinct arazi codes")

    for code in arazi_codes:
        if dry_run:
            print(f"  [dry] arazi legacy_arazi_code={code}")
            continue
        my_cur.execute(
            "INSERT INTO arazis (legacy_arazi_code, kisan_id, location, total_area, road_area, "
            "unit, park_area, other_area, sellable_area, distribution_locked, size, status, "
            "created_at, updated_at) "
            "VALUES (%s, %s, %s, 0, 0, 'gaz', 0, 0, 0, 0, 0, 'available', NOW(), NOW())",
            (code, placeholder_kisan_id, f"Legacy Arazi {code}"),
        )
        arazi_map[code] = my_cur.lastrowid
    if not dry_run:
        my.commit()
        print(f"  imported {len(arazi_map)} arazis")

    # ----------------------------------------------------------------
    # STEP 3: plots (all arazimap rows) + CUSTREGNO -> arazi/plot lookup
    # ----------------------------------------------------------------
    print("\n--- Step 3: plots (amar.arazimap all rows) ---")
    legacy_cur.execute(
        "SELECT arazi, plotno, status, CUSTREGNO FROM amar.arazimap "
        "WHERE arazi IS NOT NULL AND arazi <> '' AND plotno IS NOT NULL"
    )
    plot_rows = legacy_cur.fetchall()
    if limit:
        plot_rows = plot_rows[:limit]
    print(f"  {len(plot_rows)} legacy plot rows")

    custregno_plot_counts = {}
    n_plots = 0
    for arazi, plotno, status, custregno in plot_rows:
        title = normalize_plot_title(plotno)
        if title is None:
            continue
        if custregno:
            custregno_arazi.setdefault(custregno, arazi)
            custregno_plot_counts.setdefault(custregno, []).append(title)

        if dry_run:
            if n_plots < 5:
                print(f"  [dry] plot arazi={arazi} title={title} status={map_plot_status(status)}")
            n_plots += 1
            continue

        arazi_id = arazi_map.get(arazi)
        if arazi_id is None:
            continue
        key = (arazi_id, title)
        if key not in plot_map:
            my_cur.execute(
                "INSERT INTO plots (arazi_id, arazi_code, size, size_unit, type, status, price, title, area, "
                "description, created_at, updated_at) "
                "VALUES (%s, %s, 0, 'gaz', 'residential', %s, 0, %s, 0, %s, NOW(), NOW())",
                (arazi_id, arazi, map_plot_status(status), title, f"Legacy import from arazimap (status={status})"),
            )
            plot_map[key] = my_cur.lastrowid
            n_plots += 1
        if custregno:
            plot_ids = custregno_plot_ids.setdefault(custregno, [])
            if plot_map[key] not in plot_ids:
                plot_ids.append(plot_map[key])

    for custregno, titles in custregno_plot_counts.items():
        if len(set(titles)) == 1:
            custregno_plot[custregno] = titles[0]

    if not dry_run:
        my.commit()
    print(f"  {'would import' if dry_run else 'imported'} {n_plots} plots")

    # ----------------------------------------------------------------
    # STEP 4: customers + customer_bonds (wjstar1.customerreg1)
    # ----------------------------------------------------------------
    print("\n--- Step 4: customers + customer_bonds (wjstar1.customerreg1) ---")
    legacy_cur.execute(
        "SELECT CUSTREGNO, DATEOFCOM, CONSAMOUNT, INSTSUBPAY, EXPIRYDATE, AGENCYID, "
        "NAMEDOBADDRESS, PLOTSIZE, NOMINEESNAME, idcard, mobile, mobile2, "
        "lastdate, downpay, CHECKBY, agentid, booktype "
        "FROM wjstar1.customerreg1"
    )
    creg_rows = legacy_cur.fetchall()
    if limit:
        creg_rows = creg_rows[:limit]
    print(f"  {len(creg_rows)} legacy customerreg1 rows")

    n_cust = 0
    n_bond = 0
    n_bond_plot = 0
    n_bond_no_arazi = 0
    n_dup_skipped = 0
    seen_custregno = set()
    for row in creg_rows:
        (custregno, dateofcom, consamount, instsubpay, expirydate, agencyid,
         namedobaddress, plotsize, nomineesname, idcard, mobile, mobile2,
         lastdate, downpay, checkby, legacy_agentid, booktype) = row

        if custregno in seen_custregno:
            # A handful of CUSTREGNO values are duplicated in the legacy data
            # (confirmed: distinct count is 1 less than total row count).
            # Keep the first occurrence, skip the repeat rather than fail the run.
            n_dup_skipped += 1
            continue
        seen_custregno.add(custregno)

        legacy_code = f"customerreg1:{custregno}"
        name = extract_name(namedobaddress)
        address = extract_address(namedobaddress) or "Unknown"
        cust_mobile = clean_mobile(mobile) or clean_mobile(mobile2)

        if dry_run:
            if n_cust < 5:
                print(f"  [dry] customer legacy_code={legacy_code} name={name} mobile={cust_mobile}")
            n_cust += 1
        else:
            my_cur.execute(
                "INSERT INTO customers (legacy_customer_code, name, mobile, secondary_mobile, "
                "id_document_no, address, created_at, updated_at) "
                "VALUES (%s, %s, %s, %s, %s, %s, NOW(), NOW())",
                (legacy_code, name, cust_mobile or "", clean_mobile(mobile2) or None, idcard or None, address),
            )
            customer_id = my_cur.lastrowid
            customer_map[custregno] = customer_id
            n_cust += 1

        arazi_code = custregno_arazi.get(custregno)
        arazi_id = arazi_map.get(arazi_code) if arazi_code else None

        if arazi_id is None:
            n_bond_no_arazi += 1
            continue  # can't create a bond without a valid arazi FK

        broker_id = agent_map.get(legacy_agentid) if legacy_agentid else None

        if dry_run:
            if n_bond < 5:
                print(f"  [dry] bond legacy_code={legacy_code} arazi={arazi_code} broker_comment={checkby}")
            n_bond += 1
            continue

        my_cur.execute(
            "INSERT INTO customer_bonds (customer_id, arazi_id, arazi_code, bond_no, bond_date, "
            "bond_amount, mobile, land_size, total_amount, bond_type, amount, installment_amount, "
            "last_date, expiry_date, notes, broker_id, broker_comment, nominee_details, "
            "created_at, updated_at) "
            "VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, NOW(), NOW())",
            (
                customer_id, arazi_id, arazi_code, legacy_code,
                parse_date(dateofcom) or date(1970, 1, 1),
                to_decimal(consamount), cust_mobile or None,
                str(plotsize) if plotsize is not None else None,
                to_decimal(consamount), booktype, to_decimal(downpay), to_decimal(instsubpay),
                parse_date(lastdate), parse_date(expirydate),
                f"Legacy import from customerreg1, CUSTREGNO={custregno}, AGENCYID={agencyid}",
                broker_id, checkby, nomineesname,
            ),
        )
        bond_id = my_cur.lastrowid
        bond_map[custregno] = bond_id
        n_bond += 1

        for plot_id in custregno_plot_ids.get(custregno, []):
            my_cur.execute(
                "INSERT INTO customer_bond_plot (customer_bond_id, plot_id, created_at, updated_at) "
                "VALUES (%s, %s, NOW(), NOW())",
                (bond_id, plot_id),
            )
            n_bond_plot += 1

    if not dry_run:
        my.commit()
    print(f"  {'would import' if dry_run else 'imported'} {n_cust} customers, {n_bond} customer_bonds, "
          f"{n_bond_plot} customer_bond_plot rows "
          f"({n_bond_no_arazi} customerreg1 rows had no resolvable arazi -> bond skipped, "
          f"{n_dup_skipped} duplicate CUSTREGNO rows skipped)")

    # ----------------------------------------------------------------
    # STEP 5: customer_bond_payments (wjstar1.recipt1)
    # ----------------------------------------------------------------
    print("\n--- Step 5: customer_bond_payments (wjstar1.recipt1) ---")
    legacy_cur.execute(
        "SELECT CUSTREGNO, RECIPT, DATE1, DATE, AMOUNTR, MOD, insttype, payto FROM wjstar1.recipt1"
    )
    pay_rows = legacy_cur.fetchall()
    if limit:
        pay_rows = pay_rows[:limit]
    print(f"  {len(pay_rows)} legacy recipt1 rows")

    n_pay = 0
    n_pay_skipped = 0
    batch = []
    for custregno, recipt, date1, date_txt, amountr, mod, insttype, payto in pay_rows:
        customer_id = customer_map.get(custregno)
        if dry_run:
            if n_pay < 5:
                print(f"  [dry] payment RECIPT={recipt} CUSTREGNO={custregno} amount={to_decimal(amountr)}")
            n_pay += 1
            continue
        if customer_id is None:
            n_pay_skipped += 1
            continue
        entry_date = parse_date(date1) or parse_date(date_txt) or date(1970, 1, 1)
        arazi_code = custregno_arazi.get(custregno)
        batch.append((
            customer_id, f"recipt1:{recipt}", entry_date, map_entry_type(insttype),
            to_decimal(amountr), mod or None, payto or None,
            bond_map.get(custregno), arazi_map.get(arazi_code), arazi_code,
            f"Legacy import from recipt1, CUSTREGNO={custregno}, insttype={insttype}",
        ))
        n_pay += 1
        if len(batch) >= 1000:
            my_cur.executemany(
                "INSERT INTO customer_bond_payments (customer_id, entry_no, entry_date, entry_type, "
                "amount, payment_method, account_payee_name, customer_bond_id, arazi_id, arazi_code, "
                "remarks, created_at, updated_at) "
                "VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, NOW(), NOW())",
                batch,
            )
            my.commit()
            batch = []
            print(f"  ... {n_pay} processed")

    if batch and not dry_run:
        my_cur.executemany(
            "INSERT INTO customer_bond_payments (customer_id, entry_no, entry_date, entry_type, "
            "amount, payment_method, account_payee_name, customer_bond_id, arazi_id, arazi_code, "
            "remarks, created_at, updated_at) "
            "VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, NOW(), NOW())",
            batch,
        )
        my.commit()

    print(f"  {'would import' if dry_run else 'imported'} {n_pay} payments "
          f"({n_pay_skipped} skipped, no matching customer)")

    # ----------------------------------------------------------------
    # STEP 6: real kisans + kisan_bonds (amar.newkishan)
    # ----------------------------------------------------------------
    print("\n--- Step 6: kisans + kisan_bonds (amar.newkishan) ---")
    legacy_cur.execute(
        "SELECT kid, kname, date, mobile, landsize, arazi, location, landamount, baymode, "
        "paidamount, landbalance, lastdate, brokername, btotal, bpaid, bbalance, bcomment, "
        "kcomment, modetype, id, saleland, salerate, status FROM amar.newkishan"
    )
    kishan_rows = legacy_cur.fetchall()
    if limit:
        kishan_rows = kishan_rows[:limit]
    print(f"  {len(kishan_rows)} legacy newkishan rows")

    n_real_kisan = 0
    n_kisan_bond = 0
    n_kisan_no_arazi = 0
    for row in kishan_rows:
        (kid, kname, kdate, mobile, landsize, arazi, location, landamount, baymode,
         paidamount, landbalance, lastdate, brokername, btotal, bpaid, bbalance, bcomment,
         kcomment, modetype, legacy_id, saleland, salerate, status) = row

        arazi_id = arazi_map.get(arazi) if arazi else None
        if arazi_id is None:
            n_kisan_no_arazi += 1
            continue

        if dry_run:
            if n_real_kisan < 5:
                print(f"  [dry] kisan_bond kid={kid} name={kname} arazi={arazi} amount={to_decimal(landamount)}")
            n_real_kisan += 1
            n_kisan_bond += 1
            continue

        kisan_id = arazi_kisan_map.get(arazi)
        if kisan_id is None:
            reg_no = str(legacy_id) if legacy_id else f"NEWKISHAN-{kid}"
            my_cur.execute(
                "INSERT INTO kisans (reg_no, legacy_arazi_no, location, name, mobile, address, "
                "created_at, updated_at) VALUES (%s, %s, %s, %s, %s, %s, NOW(), NOW())",
                (reg_no, arazi, location, kname or "Unknown", clean_mobile(mobile) or "0000000000",
                 location or "N/A"),
            )
            kisan_id = my_cur.lastrowid
            arazi_kisan_map[arazi] = kisan_id
            my_cur.execute("UPDATE arazis SET kisan_id=%s WHERE id=%s", (kisan_id, arazi_id))
            n_real_kisan += 1

        my_cur.execute(
            "INSERT INTO kisan_bonds (kisan_id, arazi_id, arazi_code, bond_no, bond_date, "
            "bond_amount, mobile, land_size, sale_land, sale_rate, total_amount, bayana_mode, "
            "bond_type, amount, balance, last_date, notes, broker_payment, broker_paid, "
            "broker_balance, broker_comment, kisan_comment, created_at, updated_at) "
            "VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, NOW(), NOW())",
            (
                kisan_id, arazi_id, arazi, f"newkishan:{kid}",
                parse_date(kdate) or date(1970, 1, 1),
                to_decimal(landamount), clean_mobile(mobile) or None,
                str(landsize) if landsize is not None else None,
                to_decimal(saleland) if saleland is not None else None,
                to_decimal(salerate) if salerate is not None else None,
                to_decimal(btotal) if btotal is not None else None,
                map_bayana_mode(baymode), modetype,
                to_decimal(paidamount), to_decimal(landbalance), parse_date(lastdate),
                f"Legacy import from newkishan kid={kid}, status={status}, bcomment={bcomment}, kcomment={kcomment}",
                to_decimal(btotal) if btotal is not None else None,
                to_decimal(bpaid) if bpaid is not None else None,
                to_decimal(bbalance) if bbalance is not None else None,
                brokername, kcomment,
            ),
        )
        n_kisan_bond += 1

    if not dry_run:
        my.commit()
    print(f"  {'would import' if dry_run else 'imported'} {n_real_kisan} real kisans, {n_kisan_bond} kisan_bonds "
          f"({n_kisan_no_arazi} newkishan rows had no resolvable arazi -> skipped)")

    # ----------------------------------------------------------------
    # STEP 7: registries (amar.customerdeed)
    # ----------------------------------------------------------------
    print("\n--- Step 7: registries (amar.customerdeed) ---")
    legacy_cur.execute(
        "SELECT ID, CID, arazi, deedno, buyby, date, name1, name2, name3, plotno, plotsize, "
        "path, CUSTREGNO FROM amar.customerdeed"
    )
    deed_rows = legacy_cur.fetchall()
    if limit:
        deed_rows = deed_rows[:limit]
    print(f"  {len(deed_rows)} legacy customerdeed rows")

    n_registry = 0
    n_registry_plot = 0
    n_registry_skipped = 0
    for row in deed_rows:
        (did, cid, arazi, deedno, buyby, ddate, name1, name2, name3, plotno, plotsize,
         path, custregno) = row

        customer_id = customer_map.get(custregno)
        arazi_id = arazi_map.get(arazi) if arazi else None
        registry_date = parse_date(ddate)

        if customer_id is None or arazi_id is None or registry_date is None:
            n_registry_skipped += 1
            continue

        witness_name = (buyby or name1 or "Unknown").strip() or "Unknown"

        if dry_run:
            if n_registry < 5:
                print(f"  [dry] registry deedno={deedno} arazi={arazi} custregno={custregno} date={registry_date}")
            n_registry += 1
            continue

        plot_id, matched_title = resolve_plot_id(plot_map, arazi_id, plotno)

        my_cur.execute(
            "INSERT INTO registries (registry_code, customer_reg_no, customer_id, arazi_id, "
            "arazi_code, registry_date, deed_no, land_size, witness_name, nominee_name, "
            "document_path, plot_id, status, payment_status, lock_status, booking_mode, "
            "created_at, updated_at) "
            "VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, 'completed', 'completed', "
            "'unlock', 'other', NOW(), NOW())",
            (
                f"customerdeed:{did}", custregno, customer_id, arazi_id, arazi,
                registry_date, deedno, to_decimal(plotsize), witness_name,
                name2 or name3 or None, path, plot_id,
            ),
        )
        registry_id = my_cur.lastrowid
        n_registry += 1

        if plot_id is not None:
            my_cur.execute(
                "INSERT INTO registry_plot (registry_id, plot_id, created_at, updated_at) "
                "VALUES (%s, %s, NOW(), NOW())",
                (registry_id, plot_id),
            )
            n_registry_plot += 1

    if not dry_run:
        my.commit()
    print(f"  {'would import' if dry_run else 'imported'} {n_registry} registries, {n_registry_plot} registry_plot rows "
          f"({n_registry_skipped} customerdeed rows skipped, missing customer/arazi/date)")

    # ----------------------------------------------------------------
    # STEP 8: customer_bond_cheques (amar.chequedetails)
    # ----------------------------------------------------------------
    print("\n--- Step 8: customer_bond_cheques (amar.chequedetails) ---")
    legacy_cur.execute(
        "SELECT ID, ARAZI, CUSTREGNO, NAME, PLOTNO, PLOTSIZE, CDATE, CHEQUENO, CAMOUNT, "
        "STATUS, CHEQUETYPE, paiddate, deletevalue, BSTATUS, BDATE, fstatus, finalstatus "
        "FROM amar.chequedetails"
    )
    cheque_rows = legacy_cur.fetchall()
    if limit:
        cheque_rows = cheque_rows[:limit]
    print(f"  {len(cheque_rows)} legacy chequedetails rows")

    n_cheque = 0
    n_cheque_skipped = 0
    n_cheque_dup_skipped = 0
    seen_bond_cheque = set()
    for row in cheque_rows:
        (cdid, arazi, custregno, name, plotno, plotsize, cdate, chequeno, camount,
         status, chequetype, paiddate, deletevalue, bstatus, bdate, fstatus, finalstatus) = row

        bond_id = bond_map.get(custregno)
        if bond_id is None:
            n_cheque_skipped += 1
            continue

        cheque_number = None
        if chequeno is not None:
            d = to_decimal(chequeno)
            cheque_number = str(int(d)) if d == d.to_integral_value() else str(d.normalize())

        dedup_key = (bond_id, cheque_number)
        if dedup_key in seen_bond_cheque:
            n_cheque_dup_skipped += 1
            continue
        seen_bond_cheque.add(dedup_key)

        if dry_run:
            if n_cheque < 5:
                print(f"  [dry] cheque bond_custregno={custregno} cheque_number={cheque_number} amount={to_decimal(camount)}")
            n_cheque += 1
            continue

        arazi_id = arazi_map.get(arazi) if arazi else None
        plot_id, _ = resolve_plot_id(plot_map, arazi_id, plotno) if arazi_id else (None, None)

        my_cur.execute(
            "INSERT INTO customer_bond_cheques (customer_bond_id, customer_id, arazi_code, "
            "plot_id, cheque_number, cheque_date, amount, status, type, notes, "
            "created_at, updated_at) "
            "VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, NOW(), NOW())",
            (
                bond_id, customer_map.get(custregno), arazi, plot_id, cheque_number,
                parse_date(cdate), to_decimal(camount),
                map_cheque_status(status, bstatus), map_cheque_type(chequetype),
                f"Legacy import from chequedetails ID={cdid}, PLOTNO={plotno}, "
                f"fstatus={fstatus}, finalstatus={finalstatus}, deletevalue={deletevalue}, "
                f"BDATE={bdate}, paiddate={paiddate}",
            ),
        )
        n_cheque += 1

    if not dry_run:
        my.commit()
    print(f"  {'would import' if dry_run else 'imported'} {n_cheque} customer_bond_cheques "
          f"({n_cheque_skipped} skipped, no matching bond; {n_cheque_dup_skipped} duplicate "
          f"bond+cheque_number rows skipped)")

    print("\n" + "=" * 70)
    if dry_run:
        print("DRY RUN complete. Nothing was written. Re-run with --commit to actually import.")
    else:
        print("COMMIT complete. heeddatabase now has real imported data.")
    print("=" * 70)

    legacy_cur.close()
    legacy.close()
    my_cur.close()
    my.close()


if __name__ == "__main__":
    main()
