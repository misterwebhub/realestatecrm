<?php
/* ── Bootstrap Laravel for DB access ─────────────────────── */
require __DIR__ . '/../vendor/autoload.php';
$app = require_once __DIR__ . '/../bootstrap/app.php';
$app->make(\Illuminate\Contracts\Console\Kernel::class)->bootstrap();

$arazi = \App\Models\Arazi::where('legacy_arazi_code','319')
    ->orWhere('location','like','%kathogar%')
    ->orWhere('location','like','%KATHOGAR%')
    ->first();

$dbPlots = [];
if ($arazi) {
    $arazi->plots()->get()->each(function($p) use (&$dbPlots) {
        if ($p->plot_number !== null)
            $dbPlots[(int)$p->plot_number] = strtolower(str_replace('_','-',$p->status ?? 'available'));
    });
}

$STATUS_COLORS = [
    'available'      => '#FFC107',
    'booked'         => '#28A745',
    'booked-advance' => '#20C997',
    'hold'           => '#A0522D',
    'registry'       => '#E53935',
    'not-for-sale'   => '#9E9E9E',
    'blacklist'      => '#212529',
    'issue'          => '#6C757D',
];

/* ── Plot bounding boxes (PDF pts, × 1.5 = canvas px) ─────── */
$S = 1.5;
$rowY  = [43,78.3,97.8,117.4,137,156.6,176.2,195.76,215.32,234.88,254.44,274.12,293.68,332.8];
$rowYC = [43,84.6,108.2,131.7,155.2,178.6,202.1,225.6,249.1,272.7,332.8];
$diagRowY = [27.9,54.3,74,93.5,113.1,132.6,152.2,171.8,191.4,211,230.6,250.2,269.8,306.0];
$diagLeft = [338.4,334.6,333.4,333.2,332.7,332.2,337.8,344.5,352.2,356.7,355.5,354.2,350.0];

$boxes = [];

// Col-A (45→34)
foreach([45,44,43,42,41,40,39,38,37,36,35,34] as $ri=>$no)
    $boxes[$no] = [406.9, $rowY[$ri], 446.0, $rowY[$ri+1]];
// Col-B (20→31)
foreach([20,21,22,23,24,25,26,27,28,29,30,31] as $ri=>$no)
    $boxes[$no] = [446.0, $rowY[$ri], 485.2, $rowY[$ri+1]];
// Col-C (19→11)
foreach([19,18,17,16,15,14,13,12,11] as $ri=>$no)
    $boxes[$no] = [511.3, $rowYC[$ri], 564.9, $rowYC[$ri+1]];
$boxes[10] = [511.3, 272.7, 564.9, 332.8];
// Corner plots
$boxes[33] = [406.9, 293.68, 446.0, 332.8];
$boxes[32] = [446.0, 293.68, 485.2, 332.8];
// Diagonal 46-57 (12 plots)
foreach([46,47,48,49,50,51,52,53,54,55,56,57] as $ri=>$no)
    $boxes[$no] = [$diagLeft[$ri], $diagRowY[$ri], 380.8, $diagRowY[$ri+1]];
// Plot 58 sits directly above plots 59-63 row
$boxes[58] = [338.0, 269.8, 380.8, 293.68];
// Row plots 59-63 (above horizontal road, left area) — same y-band as plots 33/32
$boxes[63] = [21,  293.68,  75, 332.8];
$boxes[62] = [75,  293.68, 129, 332.8];
$boxes[61] = [129, 293.68, 183, 332.8];
$boxes[60] = [183, 293.68, 237, 332.8];
$boxes[59] = [237, 293.68, 291, 332.8];
// Bottom row 64-89 — starts just right of MAIN ROAD (x≈13pts)
$bpWidths = [44.4,31.4,19.6,19.6,19.6,19.6,19.6,19.6,19.6,19.6,
             19.6,19.6,19.6,19.6,19.6,19.6,19.6,19.6,19.6,19.6,
             39.2,23.5,23.5,25.1,19.6,19.6];
$cx = 13.0; $by0 = 408.0; $by1 = 475.0;
foreach([64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89] as $bi=>$no) {
    $w = $bpWidths[$bi] ?? 19.6;
    $boxes[$no] = [$cx, $by0, $cx+$w, $by1];
    $cx += $w;
}
// Plots 1-9: right of plot 10 (x=564.9+), same y-band as plot 10 (y=272.7→332.8)
$p9x = 564.9; $p9w = 19.6; $p9y0 = 272.7; $p9y1 = 332.8;
foreach(range(1,9) as $i=>$no)
    $boxes[$no] = [$p9x + $i*$p9w, $p9y0, $p9x + ($i+1)*$p9w, $p9y1];

// Scale to display px
$px = [];
foreach($boxes as $no=>$b) {
    $px[$no] = [
        'x' => round($b[0]*$S, 1),
        'y' => round($b[1]*$S, 1),
        'w' => round(($b[2]-$b[0])*$S, 1),
        'h' => round(($b[3]-$b[1])*$S, 1),
    ];
}

// Plot sizes (Sq Yard labels from PDF)
$plotSizes = [
    // Diagonal
    46=>49,47=>55,48=>56,49=>58,50=>59,51=>57,52=>51,53=>56,54=>40,55=>39,56=>42,57=>46,58=>40,
    // Col-A & B
    45=>84,44=>50,43=>50,42=>50,41=>50,40=>50,39=>50,38=>50,37=>50,36=>50,35=>50,34=>50,
    20=>71,21=>50,22=>50,23=>50,24=>50,25=>50,26=>50,27=>50,28=>50,29=>50,30=>50,31=>50,
    33=>100,32=>100,
    // Col-C
    19=>91,18=>82,17=>82,16=>82,15=>82,14=>82,13=>82,12=>82,11=>82,10=>210,
    // Row 59-63
    63=>87,62=>60,61=>60,60=>60,59=>60,
    // Plots 1-9
    1=>60,2=>60,3=>60,4=>60,5=>60,6=>60,7=>60,8=>60,9=>60,
    // Bottom row
    64=>113,65=>50,66=>50,67=>50,68=>50,69=>50,70=>50,71=>50,72=>50,73=>50,74=>50,75=>50,
    76=>50,77=>50,78=>50,79=>50,80=>50,81=>50,82=>50,83=>50,84=>60,85=>60,86=>60,87=>60,88=>60,89=>60,
];

// DB colors
$plotColors = [];
foreach($dbPlots as $no=>$status)
    if(isset($STATUS_COLORS[$status]))
        $plotColors[$no] = $STATUS_COLORS[$status];

$statuses = [
  'available'      => ['label'=>'Available',        'color'=>'#FFC107'],
  'booked-advance' => ['label'=>'Booked (Advance)', 'color'=>'#20C997'],
  'booked'         => ['label'=>'Booked',           'color'=>'#28A745'],
  'hold'           => ['label'=>'Hold',             'color'=>'#A0522D'],
  'registry'       => ['label'=>'Registry Done',    'color'=>'#E53935'],
  'not-for-sale'   => ['label'=>'Not for Sale',     'color'=>'#9E9E9E'],
  'blacklist'      => ['label'=>'Black Listed',     'color'=>'#212529'],
  'issue'          => ['label'=>'Issue',            'color'=>'#6C757D'],
];
$statusCounts = array_fill_keys(array_keys($statuses), 0);
foreach($dbPlots as $s) if(isset($statusCounts[$s])) $statusCounts[$s]++;
?><!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width,initial-scale=1">
<title>ARAZI 319 – KATHOGAR Site Plan</title>
<style>
:root{
  --road:#3a3a3a;--road-line:#f7c948;--plot-default:#ffff00;--plot-border:#000;
}
*{box-sizing:border-box;margin:0;padding:0;}
body{background:#fff;font-family:Arial,sans-serif;font-size:12px;}

/* ── header ── */
.hdr{background:#1a3a6e;color:#fff;padding:7px 14px;display:flex;align-items:center;justify-content:space-between;flex-wrap:wrap;gap:6px;}
.hdr-title{font-size:15px;font-weight:bold;color:#ffd700;letter-spacing:.5px;}
.hdr-sub{font-size:10px;color:#aac4ff;margin-top:2px;}
.hdr-mode{font-size:10px;color:#aac4ff;}

/* ── legend ── */
.legend{background:#f8f8f8;border-bottom:2px solid #ddd;padding:6px 14px;display:flex;flex-wrap:wrap;gap:5px;align-items:center;}
.lbl{font-weight:bold;font-size:11px;margin-right:4px;}
.li{display:inline-flex;align-items:center;gap:4px;padding:3px 9px;border-radius:20px;border:2px solid transparent;cursor:pointer;font-size:11px;font-weight:600;background:#efefef;user-select:none;transition:all .12s;}
.li:hover{transform:translateY(-1px);box-shadow:0 2px 6px rgba(0,0,0,.15);}
.li.active{border-color:#1a3a6e;background:#e8f0fe;}
.ld{width:11px;height:11px;border-radius:50%;flex-shrink:0;}
.lc{font-size:9px;color:#888;font-weight:400;}

/* ── toolbar ── */
.toolbar{background:#f0f0f0;border-bottom:1px solid #ccc;padding:5px 14px;display:flex;flex-wrap:wrap;gap:5px;align-items:center;}
.toolbar label{font-size:11px;}
.toolbar input[type=number]{width:60px;padding:2px 5px;border:1px solid #bbb;border-radius:3px;font-size:11px;}
.toolbar input[type=color]{width:34px;height:26px;border:none;cursor:pointer;border-radius:3px;padding:1px;}
.btn{padding:3px 10px;border:1px solid #aaa;border-radius:3px;cursor:pointer;font-size:11px;font-weight:bold;}
.btn-apply{background:#ffd700;color:#1a3a6e;border-color:#c8a800;}
.btn-clear{background:#e05555;color:#fff;border-color:#c03;}
.btn-all{background:#666;color:#fff;border-color:#444;}
.qbtn{padding:3px 9px;border:none;border-radius:10px;cursor:pointer;font-size:10px;font-weight:600;color:#fff;}

/* ── responsive map wrapper ── */
.map-outer{overflow:auto;background:#fff;padding:12px;}
.map-scale{transform-origin:top left;}

/* ── map container ── */
.map-c{
  position:relative;
  width:1263px;
  height:890px;
  background:#fff;
}

/* ── roads ── */
.road{
  position:absolute;
  background:var(--road);
  z-index:2;
}
.road.h::after{
  content:'';
  position:absolute;
  top:50%;left:0;right:0;height:3px;margin-top:-1.5px;
  background:repeating-linear-gradient(90deg,var(--road-line) 0,var(--road-line) 18px,transparent 18px,transparent 30px);
}
.road.v::after{
  content:'';
  position:absolute;
  left:50%;top:0;bottom:0;width:3px;margin-left:-1.5px;
  background:repeating-linear-gradient(180deg,var(--road-line) 0,var(--road-line) 18px,transparent 18px,transparent 30px);
}
.road-lbl{
  position:absolute;color:#fff;font-size:10px;font-weight:bold;
  letter-spacing:2px;white-space:nowrap;z-index:6;pointer-events:none;
  text-transform:uppercase;
}

/* ── land zones ── */
.zone{
  position:absolute;display:flex;align-items:center;justify-content:center;
  flex-direction:column;text-align:center;z-index:1;font-weight:bold;
  font-size:13px;border:2px solid #bbb;
}

/* ── plots ── */
.plot{
  position:absolute;
  border:1.5px solid var(--plot-border);
  background:var(--plot-default);
  cursor:pointer;
  z-index:10;
  display:flex;
  flex-direction:column;
  align-items:center;
  justify-content:center;
  overflow:hidden;
  font-family:Arial,sans-serif;
  transition:opacity .15s;
}
.plot:hover{
  z-index:20;
  filter:brightness(1.12);
  outline:2px solid #000;
}
.plot.selected{
  z-index:25;
  outline:3px solid #000;
  box-shadow:0 0 0 3px #ffd700;
}
.plot .pno{
  font-size:10px;
  font-weight:bold;
  line-height:1.2;
  color:#000;
  text-align:center;
}
.plot .psz{
  font-size:7px;
  color:#333;
  line-height:1;
  text-align:center;
}

/* ── branding zone ── */
.brand-zone{
  position:absolute;z-index:3;background:#fff;
  border:1px solid #ddd;
  display:flex;flex-direction:column;align-items:center;justify-content:center;
  text-align:center;padding:8px;
}
.brand-zone .b1{font-size:11px;font-weight:bold;color:#8a0000;letter-spacing:.5px;}
.brand-zone .b2{font-size:14px;font-weight:bold;color:#1a3a6e;margin:3px 0;}
.brand-zone .b3{font-size:10px;color:#555;}
</style>
</head>
<body>

<!-- HEADER -->
<div class="hdr">
  <div>
    <div class="hdr-title">ARAZI No. 319 – KATHOGAR &nbsp;|&nbsp; Interactive Site Plan</div>
    <div class="hdr-sub">KANPUR NAGAR &nbsp;|&nbsp; 11 M.I.G K.D.A. Colony, Jajmau, Kanpur &nbsp;|&nbsp; HEED Real Estate Pvt. Ltd.</div>
  </div>
  <div class="hdr-mode">
    <?php if($arazi): ?>DB: Arazi <?=htmlspecialchars($arazi->legacy_arazi_code)?> (<?=count($dbPlots)?> plots)
    <?php else: ?>No DB record – manual mode<?php endif;?>
  </div>
</div>

<!-- LEGEND -->
<div class="legend">
  <span class="lbl">Status:</span>
  <div class="li active" data-filter="all">
    <span class="ld" style="background:#1a3a6e;"></span>All
    <span class="lc">(<?=array_sum($statusCounts)?>)</span>
  </div>
  <?php foreach($statuses as $key=>$s): ?>
  <div class="li" data-filter="<?=$key?>" data-color="<?=$s['color']?>">
    <span class="ld" style="background:<?=$s['color']?>;"></span>
    <?=$s['label']?> <span class="lc">(<?=$statusCounts[$key]?>)</span>
  </div>
  <?php endforeach; ?>
</div>

<!-- TOOLBAR -->
<div class="toolbar">
  <strong style="font-size:11px;">Manual:</strong>
  <label>Plot:</label>
  <input type="number" id="pNum" min="1" max="89" placeholder="No.">
  <label>Color:</label>
  <input type="color" id="pColor" value="#ff4444">
  <button class="btn btn-apply" onclick="applyColor()">Apply</button>
  <button class="btn btn-clear" onclick="clearPlot()">Clear</button>
  <button class="btn btn-all" onclick="clearAll()">Clear All</button>
  &nbsp;
  <?php foreach($statuses as $key=>$s): ?>
  <button class="qbtn"
    style="background:<?=$s['color']?>;<?=in_array($key,['available','not-for-sale'])?'color:#333;':''?>"
    onclick="pickColor('<?=$s['color']?>')">
    <?=$s['label']?>
  </button>
  <?php endforeach;?>
</div>

<!-- MAP -->
<div class="map-outer" id="mapOuter">
<div class="map-scale" id="mapScale">
<div class="map-c" id="mapC">

  <!-- ═══ ROADS ═══ -->
  <div class="road v" style="left:0;top:0;width:20px;height:893px;"></div>
  <div class="road v" style="left:571px;top:0;width:39px;height:499px;"></div>
  <div class="road v" style="left:728px;top:0;width:39px;height:499px;"></div>
  <div class="road h" style="left:0;top:499px;width:1263px;height:113px;"></div>
  <div class="road-lbl" style="left:50%;top:549px;transform:translateX(-50%);">20' ROAD</div>
  <!-- no second horizontal road below bottom plots -->

  <!-- ═══ ZONES ═══ -->
  <div class="brand-zone" style="left:25px;top:10px;width:460px;height:340px;">
    <div class="b1">HEED REAL ESTATE PVT. LTD.</div>
    <div class="b2">ARAZI No. 319 KATHOGAR<br>KANPUR NAGAR</div>
    <div class="b3">11 M.I.G K.D.A. Colony, Jajmau</div>
  </div>
  <!-- 2023 SQY sits above plots 1-9 (y=0 to 409px) -->
  <div class="zone" style="left:848px;top:0;width:415px;height:409px;background:#fffde7;border-color:#f9a825;">
    <div style="font-size:16px;color:#7a5800;font-weight:bold;">2023 SQY</div>
    <div style="font-size:10px;color:#aaa;margin-top:4px;">Reserved Area</div>
  </div>
  <!-- Land zones: directly below bottom plots row (by1=475 × 1.5 = 712.5px) -->
  <div class="zone" style="left:20px;top:714px;width:1030px;height:170px;background:#fce4ec;border-color:#c2185b;">
    <div style="font-size:13px;color:#880e4f;">319</div>
    <div style="font-size:18px;color:#880e4f;font-weight:bold;">26.05 biswa</div>
  </div>
  <div class="zone" style="left:1050px;top:714px;width:213px;height:170px;background:#fffde7;border-color:#f9a825;">
    <div style="font-size:15px;color:#7a5800;font-weight:bold;">10.81 biswa</div>
  </div>

  <!-- ═══ PLOTS ═══ -->
  <?php foreach($px as $no=>$p):
    $status  = $dbPlots[$no] ?? '';
    $color   = $plotColors[$no] ?? '#ffff00';
    $isDark  = in_array($status, ['blacklist','hold','registry','issue']);
    $textCol = $isDark ? '#fff' : '#000';
    $sz      = $plotSizes[$no] ?? '';
  ?>
  <div class="plot"
       id="plot-<?=$no?>"
       data-no="<?=$no?>"
       data-status="<?=htmlspecialchars($status)?>"
       style="left:<?=$p['x']?>px;top:<?=$p['y']?>px;width:<?=$p['w']?>px;height:<?=$p['h']?>px;background:<?=$color?>;"
       onclick="selectPlot(<?=$no?>)">
    <div class="pno" style="color:<?=$textCol?>"><?=$no?></div>
    <?php if($sz && $p['h']>=28): ?>
    <div class="psz" style="color:<?=$isDark?'#ddd':'#333'?>"><?=$sz?> sy</div>
    <?php endif;?>
  </div>
  <?php endforeach;?>

</div><!-- map-c -->
</div><!-- map-scale -->
</div><!-- map-outer -->

<script>
const STATUS_COLORS = <?=json_encode($STATUS_COLORS)?>;
const DB_COLORS     = <?=json_encode($plotColors)?>;
const colors        = Object.assign({}, DB_COLORS);
let selectedNo      = null;

/* ── Responsive scaling ── */
function scaleMap(){
  const wrap = document.getElementById('mapScale');
  const outer = document.getElementById('mapOuter');
  const available = outer.clientWidth - 24;
  const mapW = 1263;
  const scale = Math.min(1, available / mapW);
  wrap.style.transform = 'scale('+scale+')';
  wrap.style.width = mapW + 'px';
  // shrink outer height to match scaled map
  wrap.parentElement.style.height = Math.ceil(890 * scale + 24) + 'px';
}
window.addEventListener('resize', scaleMap);
scaleMap();

function getPlotEl(no){ return document.getElementById('plot-'+no); }

function applyColorToEl(no, color){
  const el = getPlotEl(no); if(!el) return;
  el.style.background = color;
  const dark = ['#212529','#A0522D','#E53935','#6C757D'];
  el.style.color = dark.some(d=>color.toLowerCase()===d.toLowerCase()) ? '#fff' : '#111';
}

function applyColor(){
  const no = document.getElementById('pNum').value.trim();
  const c  = document.getElementById('pColor').value;
  if(!no){ alert('Enter a plot number.'); return; }
  if(!getPlotEl(no)){ alert('Plot '+no+' not found on map.'); return; }
  colors[no] = c;
  applyColorToEl(no, c);
}

function clearPlot(){
  const no = document.getElementById('pNum').value.trim();
  delete colors[no];
  applyColorToEl(no, '#e2f0d9');
  if(selectedNo==no) setSelected(null);
}

function clearAll(){
  if(!confirm('Clear all colours?')) return;
  document.querySelectorAll('.plot').forEach(el=>{
    el.style.background='#e2f0d9';
    el.style.color='#111';
  });
  for(const k in colors) delete colors[k];
  setSelected(null);
}

function pickColor(c){ document.getElementById('pColor').value=c; }

function setSelected(no){
  if(selectedNo) { const e=getPlotEl(selectedNo); if(e) e.classList.remove('selected'); }
  selectedNo = no;
  if(no){ const e=getPlotEl(no); if(e) e.classList.add('selected'); }
}

function selectPlot(no){
  setSelected(no);
  document.getElementById('pNum').value = no;
}

/* Legend filter */
document.querySelectorAll('.li').forEach(li=>{
  li.addEventListener('click',function(){
    document.querySelectorAll('.li').forEach(x=>x.classList.remove('active'));
    li.classList.add('active');
    const filter = li.dataset.filter;
    const filterColor = li.dataset.color;

    document.querySelectorAll('.plot').forEach(el=>{
      if(filter==='all'){
        el.style.opacity='1';
      } else {
        const plotColor = colors[el.dataset.no] || '#e2f0d9';
        const match = filterColor && plotColor.toLowerCase()===filterColor.toLowerCase();
        el.style.opacity = match ? '1' : '0.18';
      }
    });
  });
});
</script>
</body>
</html>
