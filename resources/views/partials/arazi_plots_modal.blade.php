<div id="arazi-plots-modal" class="modal" tabindex="-1" style="display:none;">
  <div class="modal-dialog modal-xl">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Plots</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <div id="arazi-plots-tabs">
          <!-- tabs rendered here -->
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <a id="arazi-grid-link" class="btn btn-outline-primary" target="_blank" href="#">Open full grid</a>
      </div>
    </div>
  </div>
</div>

<script>
(function(){
    const arazisPlotsUrl = @json(route('arazis.plots', ['arazi' => '__ARAZI_ID__']));
    const araziGridBase = @json(route('arazis.grid', ['identifier' => '__ARAZI_ID__']));

    function createTabsHtml(araziId, plots){
        const statuses = [
            {key:'all', label: 'All'},
            {key:'available', label: 'Available'},
            {key:'booked', label: 'Booked'},
            {key:'registry', label: 'Registry'},
            {key:'issue', label: 'Issue'},
            {key:'hold', label: 'Hold'},
            {key:'blacklist', label: 'Blacklist'},
            {key:'not_for_sale', label: 'Not for sale'},
        ];

        const tabsNav = document.createElement('ul');
        tabsNav.className = 'nav nav-tabs mb-3';

        const tabsContent = document.createElement('div');
        tabsContent.className = 'tab-content';

        statuses.forEach(function(s, idx){
            const li = document.createElement('li');
            li.className = 'nav-item';
            const a = document.createElement('a');
            a.className = 'nav-link' + (idx===0? ' active':'');
            a.href = '#arazi-tab-' + s.key;
            a.dataset.bsToggle = 'tab';
            a.textContent = s.label;
            li.appendChild(a);
            tabsNav.appendChild(li);

            const pane = document.createElement('div');
            pane.className = 'tab-pane fade' + (idx===0? ' show active':'');
            pane.id = 'arazi-tab-' + s.key;

            // filter plots
            const items = (s.key === 'all') ? plots : plots.filter(p => String(p.status) === String(s.key));

            if(items.length === 0){
                pane.innerHTML = '<div class="alert alert-secondary">No plots in this category.</div>';
            } else {
                const row = document.createElement('div');
                row.className = 'row g-2';
                items.forEach(function(p){
                    const col = document.createElement('div');
                    col.className = 'col-md-3';
                    col.innerHTML = `<div class="card">
                        <div class="card-body p-2">
                            <h6 class="card-title mb-1">${p.plot_number}</h6>
                            <div class="small text-muted">${p.label || ''}</div>
                            <div class="mt-2">Area: ${p.area ?? '-'} </div>
                            <div class="mt-1">Status: <strong>${p.status}</strong></div>
                            <div class="mt-2"><a href="${araziGridBase.replace('__ARAZI_ID__', encodeURIComponent(araziId))}#plot-${p.id}" target="_blank" class="btn btn-sm btn-outline-primary">Open</a></div>
                        </div>
                    </div>`;
                    row.appendChild(col);
                });
                pane.appendChild(row);
            }

            tabsContent.appendChild(pane);
        });

        const wrapper = document.createElement('div');
        wrapper.appendChild(tabsNav);
        wrapper.appendChild(tabsContent);
        return wrapper;
    }

    window.showAraziPlots = async function(araziId){
        if(!araziId) return;
        const modal = document.getElementById('arazi-plots-modal');
        const bodyTabs = modal.querySelector('#arazi-plots-tabs');
        bodyTabs.innerHTML = '<div class="text-center py-4">Loading…</div>';
        try{
            const res = await fetch(arazisPlotsUrl.replace('__ARAZI_ID__', encodeURIComponent(araziId)));
            if(!res.ok) throw new Error('Failed');
            const plots = await res.json();
            const content = createTabsHtml(araziId, plots || []);
            bodyTabs.innerHTML = '';
            bodyTabs.appendChild(content);
            // update grid link
            const gridLink = modal.querySelector('#arazi-grid-link');
            gridLink.href = araziGridBase.replace('__ARAZI_ID__', encodeURIComponent(araziId));
            // show modal (Bootstrap 5)
            try{
                const bsModal = new bootstrap.Modal(modal);
                bsModal.show();
            }catch(e){
                // fallback to manual display
                modal.style.display = 'block';
            }
        }catch(e){
            bodyTabs.innerHTML = '<div class="alert alert-danger">Failed to load plots.</div>';
        }
    };
})();
</script>
