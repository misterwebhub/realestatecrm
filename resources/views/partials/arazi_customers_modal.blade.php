<div id="arazi-customers-modal" class="modal" tabindex="-1" style="display:none;">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Customers for Arazi</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <div id="arazi-customers-body">Loading…</div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

<script>
(function(){
    const modal = document.getElementById('arazi-customers-modal');
    const body = modal.querySelector('#arazi-customers-body');

    window.showAraziCustomers = function(customers){
        if(!Array.isArray(customers) || customers.length === 0) return;
        const container = document.createElement('div');
        const table = document.createElement('table');
        table.className = 'table table-sm table-hover';
        const thead = document.createElement('thead');
        thead.innerHTML = '<tr><th>Customer</th><th>Purchases</th><th>Bonds / Plots</th><th></th></tr>';
        table.appendChild(thead);
        const tbody = document.createElement('tbody');

        customers.forEach(function(c){
            const tr = document.createElement('tr');
            const tdName = document.createElement('td'); tdName.textContent = c.name || '-';
            const tdCount = document.createElement('td'); tdCount.textContent = c.purchases || 0;
            const tdBonds = document.createElement('td');
            if(Array.isArray(c.bonds) && c.bonds.length){
                const lis = document.createElement('ul');
                lis.className = 'mb-0';
                c.bonds.forEach(function(b){
                    const li = document.createElement('li');
                    li.textContent = b.bond_no ? (b.bond_no + ' - ' + (b.plots.map(p=>p.plot_number).join(', ') || '-')) : ('Bond#' + b.id + ' - ' + (b.plots.map(p=>p.plot_number).join(', ') || '-'));
                    lis.appendChild(li);
                });
                tdBonds.appendChild(lis);
            } else {
                tdBonds.textContent = '-';
            }

            const tdAction = document.createElement('td');
            const selectBtn = document.createElement('button');
            selectBtn.type = 'button';
            selectBtn.className = 'btn btn-sm btn-primary select-arazi-customer';
            selectBtn.textContent = 'Select';
            selectBtn.dataset.customerId = String(c.customer_id || '');
            // If single bond, expose bond id on button so client can auto-select it
            if(Array.isArray(c.bonds) && c.bonds.length === 1){
                selectBtn.dataset.bondId = String(c.bonds[0].id);
            }
            tdAction.appendChild(selectBtn);

            tr.appendChild(tdName);
            tr.appendChild(tdCount);
            tr.appendChild(tdBonds);
            tr.appendChild(tdAction);
            tbody.appendChild(tr);
        });

        table.appendChild(tbody);
        container.appendChild(table);
        body.innerHTML = '';
        body.appendChild(container);

        // bind select buttons
        body.querySelectorAll('.select-arazi-customer').forEach(function(btn){
            btn.addEventListener('click', function(){
                const detail = { customer_id: this.dataset.customerId || null };
                if(this.dataset.bondId) detail.bond_id = this.dataset.bondId;
                const ev = new CustomEvent('arazi:customer:selected', { detail });
                window.dispatchEvent(ev);
                try{ const bs = bootstrap.Modal.getInstance(modal); if(bs) bs.hide(); }catch(e){ modal.style.display = 'none'; }
            });
        });

        try{ const bs = new bootstrap.Modal(modal); bs.show(); }catch(e){ modal.style.display = 'block'; }
    };
})();
</script>
