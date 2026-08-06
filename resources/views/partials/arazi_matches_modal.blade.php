<div id="arazi-matches-modal" class="modal" tabindex="-1" style="display:none;">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Multiple Arazis Found</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <div id="arazi-matches-body">Loading…</div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>

<script>
(function(){
    const modal = document.getElementById('arazi-matches-modal');
    const body = modal.querySelector('#arazi-matches-body');

    window.showAraziMatches = function(matches){
        if(!Array.isArray(matches) || matches.length === 0) return;
        const table = document.createElement('table');
        table.className = 'table table-sm table-hover';
        const thead = document.createElement('thead');
        thead.innerHTML = '<tr><th>Arazi</th><th>Kisan</th><th>Deed No</th><th>Merged Deed No</th><th>Location</th><th>Size</th><th>Road</th><th>Status</th><th></th></tr>';
        table.appendChild(thead);
        const tbody = document.createElement('tbody');
        matches.forEach(function(m){
          const tr = document.createElement('tr');

          const tdLabel = document.createElement('td'); tdLabel.textContent = m.label || '';
          const tdKisan = document.createElement('td'); tdKisan.textContent = m.kisan ?? '-';
          const tdDeedNo = document.createElement('td'); tdDeedNo.textContent = m.deed_no || '—';
          const tdMergedDeedNo = document.createElement('td');
          if (m.merged_deed_no) {
              const badge = document.createElement('span');
              badge.className = 'badge bg-success-subtle text-success border border-success-subtle';
              badge.textContent = m.merged_deed_no;
              tdMergedDeedNo.appendChild(badge);
          } else {
              tdMergedDeedNo.textContent = '—';
          }
          const tdLocation = document.createElement('td'); tdLocation.textContent = m.location ?? '';
          const tdSize = document.createElement('td'); tdSize.textContent = ((m.size ?? '') + ' ' + (m.unit ?? '')).trim();
          const tdRoad = document.createElement('td'); tdRoad.textContent = m.road_area ?? 0;
          const tdStatus = document.createElement('td'); tdStatus.textContent = m.status ?? '';
          const tdAction = document.createElement('td');
          const btn = document.createElement('button');
          btn.type = 'button';
          btn.className = 'btn btn-sm btn-primary select-arazi-match';
          btn.textContent = 'Select';
          // attach safe dataset properties
          btn.dataset.araziId = String(m.id ?? '');
          btn.dataset.araziCode = String(m.arazi_code ?? m.label ?? '');
          btn.dataset.araziLabel = String(m.label ?? '');
          btn.dataset.kisan = String(m.kisan ?? '');
          btn.dataset.deedNo = String(m.deed_no ?? '');
          btn.dataset.mergedDeedNo = String(m.merged_deed_no ?? '');
          btn.dataset.partnerId = String(m.partner_id ?? '');
          btn.dataset.partnerName = String(m.partner_name ?? '');

          tdAction.appendChild(btn);

          tr.appendChild(tdLabel);
          tr.appendChild(tdKisan);
          tr.appendChild(tdDeedNo);
          tr.appendChild(tdMergedDeedNo);
          tr.appendChild(tdLocation);
          tr.appendChild(tdSize);
          tr.appendChild(tdRoad);
          tr.appendChild(tdStatus);
          tr.appendChild(tdAction);

          tbody.appendChild(tr);
        });
        table.appendChild(tbody);
        body.innerHTML = '';
        body.appendChild(table);

        // bind select buttons
        body.querySelectorAll('.select-arazi-match').forEach(function(btn){
          btn.addEventListener('click', function(){
            try{
              const data = {
                id: this.dataset.araziId || null,
                arazi_code: this.dataset.araziCode || null,
                label: this.dataset.araziLabel || null,
                kisan: this.dataset.kisan || null,
                deed_no: this.dataset.deedNo || null,
                merged_deed_no: this.dataset.mergedDeedNo || null,
                partner_id: this.dataset.partnerId || null,
                partner_name: this.dataset.partnerName || null,
              };
              const ev = new CustomEvent('arazi:selected', { detail: data });
              window.dispatchEvent(ev);
            }catch(e){ }
            // hide modal
            try{ bootstrap.Modal.getOrCreateInstance(modal).hide(); }catch(e){ modal.style.display = 'none'; }
          });
        });

        try{
            // Always reuse the same instance — never create a new one on each call
            const bs = bootstrap.Modal.getOrCreateInstance(modal);
            bs.show();
        }catch(e){ modal.style.display = 'block'; }
    };
})();
</script>