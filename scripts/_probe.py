import pyodbc

conn_str = (
    "DRIVER={ODBC Driver 18 for SQL Server};"
    "SERVER=103.21.58.193,1433;DATABASE=amar;UID=amar;PWD=Heed@@2019;"
    "Encrypt=no;TrustServerCertificate=yes;Connection Timeout=15;"
)
cn = pyodbc.connect(conn_str, timeout=15)
cur = cn.cursor()

print("--- customerdeed CUSTREGNO match rate vs customerreg1 ---")
cur.execute("SELECT COUNT(*) FROM amar.customerdeed WHERE CUSTREGNO IS NOT NULL AND CUSTREGNO <> ''")
print("customerdeed rows with non-blank CUSTREGNO:", cur.fetchone()[0])
cur.execute("SELECT COUNT(*) FROM amar.customerdeed d WHERE EXISTS (SELECT 1 FROM wjstar1.customerreg1 c WHERE c.CUSTREGNO = d.CUSTREGNO)")
print("matched to customerreg1:", cur.fetchone()[0])
cur.execute("SELECT COUNT(*) FROM amar.customerdeed")
print("total customerdeed rows:", cur.fetchone()[0])

print()
print("--- customerdeed arazi match rate vs arazimap codes ---")
cur.execute("SELECT COUNT(*) FROM amar.customerdeed d WHERE d.arazi IS NOT NULL AND d.arazi <> '' AND d.arazi <> '0'")
print("customerdeed rows with real-looking arazi:", cur.fetchone()[0])
cur.execute("SELECT COUNT(*) FROM amar.customerdeed d WHERE EXISTS (SELECT 1 FROM amar.arazimap a WHERE a.arazi = d.arazi)")
print("customerdeed arazi matched to arazimap:", cur.fetchone()[0])

print()
print("--- chequedetails CUSTREGNO match rate vs customerreg1 ---")
cur.execute("SELECT COUNT(*) FROM amar.chequedetails ch WHERE EXISTS (SELECT 1 FROM wjstar1.customerreg1 c WHERE c.CUSTREGNO = ch.CUSTREGNO)")
print("matched:", cur.fetchone()[0])
cur.execute("SELECT COUNT(DISTINCT CUSTREGNO) FROM amar.chequedetails")
print("distinct CUSTREGNO in chequedetails:", cur.fetchone()[0])
cur.execute("SELECT COUNT(*) FROM amar.chequedetails")
print("total chequedetails rows:", cur.fetchone()[0])

print()
print("--- newkishan arazi match rate vs arazimap ---")
cur.execute("SELECT COUNT(*) FROM amar.newkishan k WHERE EXISTS (SELECT 1 FROM amar.arazimap a WHERE a.arazi = k.arazi)")
print("matched:", cur.fetchone()[0])
cur.execute("SELECT COUNT(*) FROM amar.newkishan")
print("total newkishan:", cur.fetchone()[0])
cur.execute("SELECT COUNT(DISTINCT arazi) FROM amar.newkishan")
print("distinct arazi in newkishan:", cur.fetchone()[0])
