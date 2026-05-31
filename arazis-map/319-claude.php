<?php
/*
 * ARAZI 319 – KATHOGAR Interactive Site Plan
 * Scale: PDF pts × 1.5 = display pixels
 * SVG canvas: 1263 × 892.5 px
 */

// ── Plot colour assignments (edit freely) ────────────────────
// 'sold' => red, 'booked' => orange, 'available' => default
// You can also use any hex colour directly.
$plotColors = [
    // Example overrides:
    // 10  => '#ff4444',   // red
    // 20  => '#ffaa00',   // orange/yellow
    // 45  => '#00cc44',   // green
];

// ── Bounding boxes in PDF points (×1.5 for canvas pixels) ───
// Format: plotNo => [x0, y0, x1, y1]  (PDF coordinate space, top-down)

$S = 1.5; // scale factor

// Col-A (plots 45→34): x0=406.9 x1=446.0
// Col-B (plots 20→31): x0=446.0 x1=485.2
// Col-C (plots 19→11): x0=511.3 x1=564.9
// Row y-tops for A/B:
$rowY = [43.0, 78.3, 97.8, 117.4, 137.0, 156.6, 176.2, 195.76,
         215.32, 234.88, 254.44, 274.12, 293.68, 332.8];

// Col-C row y-tops:
$rowYC = [43.0, 84.6, 108.2, 131.7, 155.2, 178.6, 202.1, 225.6, 249.1, 272.7, 332.8];

// Diagonal plots 46-57: right edge x=380.8
// [plotNo, left-x, y0, y1]
$diagRowY = [27.9, 54.3, 74.0, 93.5, 113.1, 132.6, 152.2, 171.8, 191.4, 211.0, 230.6, 250.2, 269.8];
$diagLeft = [338.4, 334.6, 333.4, 333.2, 332.7, 332.2, 337.8, 344.5, 352.2, 356.7, 355.5, 354.2];

// Bottom road y area: ~356-399 PDF pts
// Bottom plots (64-89 area): y0=399, y1=480 (approx)
$bottomY0 = 399; $bottomY1 = 480;
// bottom plot x positions: start at x=246, 15'=19.6pts each col
$bpStartX = 246.0;
$bpW      = 19.6;  // 15ft in PDF pts

// Build the JS boxes array
$boxes = [];

// Col-A
$colA = [45,44,43,42,41,40,39,38,37,36,35,34];
foreach($colA as $ri=>$no)
    $boxes[$no] = [406.9, $rowY[$ri], 446.0, $rowY[$ri+1]];

// Col-B
$colB = [20,21,22,23,24,25,26,27,28,29,30,31];
foreach($colB as $ri=>$no)
    $boxes[$no] = [446.0, $rowY[$ri], 485.2, $rowY[$ri+1]];

// Col-C
$colC = [19,18,17,16,15,14,13,12,11];
foreach($colC as $ri=>$no)
    $boxes[$no] = [511.3, $rowYC[$ri], 564.9, $rowYC[$ri+1]];

// Plot 10 (bottom-right of main grid)
$boxes[10] = [511.3, 272.7, 564.9, 332.8];

// Corner plots at bottom of main grid
$boxes[63] = [21.4,  306.0, 260.0, 332.8];
$boxes[33] = [406.9, 293.68, 446.0, 332.8];
$boxes[32] = [446.0, 293.68, 485.2, 332.8];

// Diagonal plots 46–57
$diagPlots = [46,47,48,49,50,51,52,53,54,55,56,57];
foreach($diagPlots as $ri=>$no)
    $boxes[$no] = [$diagLeft[$ri], $diagRowY[$ri], 380.8, $diagRowY[$ri+1]];

// Bottom row plots: approximate positions
// From PDF: bottom rows start around y=408 in PDF space
// Plot widths from dim labels (in PDF pts at 1.307pts/ft):
// 34'=44.4, 24'=31.4, then 15'×20=19.6 each, then 30'=39.2, 18'=23.5, 18'=23.5, 19.2'=25.1
$bpNums = [64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89];
$bpWidths = [44.4, 31.4,
             19.6,19.6,19.6,19.6,19.6,19.6,19.6,19.6,19.6,19.6,
             19.6,19.6,19.6,19.6,19.6,19.6,19.6,19.6,
             39.2, 23.5, 23.5, 25.1, 0, 0];
$cx = 246.0;
$by0 = 408.0; $by1 = 475.0;
foreach($bpNums as $bi=>$no) {
    $w = isset($bpWidths[$bi]) ? $bpWidths[$bi] : 19.6;
    if($w <= 0) { $cx += 0; continue; }
    $boxes[$no] = [$cx, $by0, $cx+$w, $by1];
    $cx += $w;
}

// Scale all boxes to canvas pixels
$jsBoxes = [];
foreach($boxes as $no=>$b)
    $jsBoxes[$no] = array_map(fn($v)=>round($v*$S, 1), $b);

// Merge PHP colour config into JS
$jsColors = [];
foreach($plotColors as $no=>$c)
    $jsColors[(int)$no] = $c;

?><!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<title>ARAZI 319 – KATHOGAR Interactive Site Plan</title>
<style>
*{box-sizing:border-box;margin:0;padding:0;}
body{background:#e0dfd4;font-family:Arial,sans-serif;padding:8px;}
h2{text-align:center;color:#1a3a6e;font-size:14px;margin:4px 0 6px;}

/* toolbar */
.toolbar{display:flex;flex-wrap:wrap;gap:6px;align-items:center;
  background:#1a3a6e;color:#fff;padding:6px 10px;border-radius:4px;
  margin-bottom:6px;font-size:12px;}
.toolbar label{font-weight:bold;}
.toolbar input[type=number]{width:60px;padding:2px 4px;border-radius:3px;border:none;font-size:12px;}
.toolbar input[type=color]{width:36px;height:26px;border:none;cursor:pointer;border-radius:3px;}
.toolbar button{padding:3px 10px;border:none;border-radius:3px;cursor:pointer;font-size:12px;font-weight:bold;}
.btn-apply{background:#ffd700;color:#1a3a6e;}
.btn-clear{background:#e05555;color:#fff;}
.btn-clearall{background:#888;color:#fff;}

/* plot-list panel */
.layout{display:flex;gap:8px;align-items:flex-start;}
.panel{background:#fff;border:1px solid #bbb;border-radius:4px;padding:6px;
  width:220px;flex-shrink:0;font-size:11px;max-height:920px;overflow-y:auto;}
.panel h3{font-size:12px;color:#1a3a6e;margin-bottom:4px;border-bottom:1px solid #ddd;padding-bottom:3px;}
.plot-item{display:flex;justify-content:space-between;align-items:center;
  padding:2px 4px;border-radius:3px;margin-bottom:1px;cursor:pointer;}
.plot-item:hover{background:#eef;}
.plot-item .pname{font-weight:bold;}
.plot-item .pcolor{width:16px;height:16px;border:1px solid #aaa;border-radius:2px;display:inline-block;}

/* map container */
.map-wrap{position:relative;flex:1;border:3px solid #000;
  width:1263px;height:893px;overflow:hidden;flex-shrink:0;}
.map-wrap img{display:block;width:1263px;height:893px;}
canvas#overlay{position:absolute;top:0;left:0;pointer-events:none;}
</style>
</head>
<body>

<h2>ARAZI No. 319 – KATHOGAR &nbsp;|&nbsp; Interactive Site Plan &nbsp;|&nbsp; KANPUR NAGAR</h2>

<!-- TOOLBAR -->
<div class="toolbar">
  <label>Plot No:</label>
  <input type="number" id="plotNum" min="10" max="108" placeholder="e.g. 45">
  <label>Color:</label>
  <input type="color" id="plotColor" value="#ff4444" title="Pick colour">
  <button class="btn-apply" onclick="applyColor()">Apply</button>
  <button class="btn-clear" onclick="clearPlot()">Clear Plot</button>
  <button class="btn-clearall" onclick="clearAll()">Clear All</button>
  &nbsp;|&nbsp;
  <span>Quick:</span>
  <button style="background:#ff4444;color:#fff;padding:3px 8px;border:none;border-radius:3px;cursor:pointer;" onclick="setColor('#ff4444')">🔴 Sold</button>
  <button style="background:#ffaa00;color:#fff;padding:3px 8px;border:none;border-radius:3px;cursor:pointer;" onclick="setColor('#ffaa00')">🟠 Booked</button>
  <button style="background:#22cc44;color:#fff;padding:3px 8px;border:none;border-radius:3px;cursor:pointer;" onclick="setColor('#22cc44')">🟢 Available</button>
  <button style="background:#4488ff;color:#fff;padding:3px 8px;border:none;border-radius:3px;cursor:pointer;" onclick="setColor('#4488ff')">🔵 Reserved</button>
</div>

<div class="layout">

  <!-- SIDE PANEL: plot list -->
  <div class="panel">
    <h3>Plot List (click to select)</h3>
    <div id="plotList"></div>
  </div>

  <!-- MAP -->
  <div class="map-wrap" id="mapWrap">
    <img src="assets/319-plan.svg" alt="Site Plan" id="planImg">
    <canvas id="overlay" width="1263" height="893"></canvas>
  </div>

</div>

<script>
// ── Bounding boxes from PHP (PDF pts × 1.5) ─────────────────
const BOXES = <?= json_encode($jsBoxes) ?>;

// Initial colours from PHP config
const initColors = <?= json_encode($jsColors) ?>;

// Runtime colour state
const colors = {...initColors};

const canvas = document.getElementById('overlay');
const ctx    = canvas.getContext('2d');

// ── Draw all coloured overlays ────────────────────────────────
function redraw() {
  ctx.clearRect(0, 0, canvas.width, canvas.height);
  for (const [no, color] of Object.entries(colors)) {
    const b = BOXES[no];
    if (!b) continue;
    // fill with 50% opacity
    ctx.fillStyle = hexToRgba(color, 0.52);
    ctx.fillRect(b[0], b[1], b[2]-b[0], b[3]-b[1]);
    // border
    ctx.strokeStyle = color;
    ctx.lineWidth = 2;
    ctx.strokeRect(b[0]+1, b[1]+1, b[2]-b[0]-2, b[3]-b[1]-2);
  }
  renderList();
}

function hexToRgba(hex, alpha) {
  const r = parseInt(hex.slice(1,3),16);
  const g = parseInt(hex.slice(3,5),16);
  const b = parseInt(hex.slice(5,7),16);
  return `rgba(${r},${g},${b},${alpha})`;
}

// ── Toolbar actions ───────────────────────────────────────────
function applyColor() {
  const no = document.getElementById('plotNum').value.trim();
  const c  = document.getElementById('plotColor').value;
  if (!no) return alert('Enter a plot number first.');
  if (!BOXES[no]) return alert('Plot ' + no + ' not found in map data.');
  colors[no] = c;
  redraw();
}

function clearPlot() {
  const no = document.getElementById('plotNum').value.trim();
  delete colors[no];
  redraw();
}

function clearAll() {
  if (confirm('Clear all plot colours?')) {
    for (const k in colors) delete colors[k];
    redraw();
  }
}

function setColor(c) {
  document.getElementById('plotColor').value = c;
}

// ── Click on map to select plot ───────────────────────────────
canvas.style.pointerEvents = 'auto';
canvas.addEventListener('click', function(e) {
  const rect = canvas.getBoundingClientRect();
  const mx = (e.clientX - rect.left) * (canvas.width / rect.width);
  const my = (e.clientY - rect.top)  * (canvas.height / rect.height);
  for (const [no, b] of Object.entries(BOXES)) {
    if (mx >= b[0] && mx <= b[2] && my >= b[1] && my <= b[3]) {
      document.getElementById('plotNum').value = no;
      // highlight border briefly
      ctx.strokeStyle = '#000';
      ctx.lineWidth = 3;
      ctx.setLineDash([4,3]);
      ctx.strokeRect(b[0], b[1], b[2]-b[0], b[3]-b[1]);
      setTimeout(redraw, 600);
      return;
    }
  }
});

// ── Side panel plot list ──────────────────────────────────────
function renderList() {
  const allNos = Object.keys(BOXES).map(Number).sort((a,b)=>a-b);
  const div = document.getElementById('plotList');
  div.innerHTML = '';
  for (const no of allNos) {
    const color = colors[no] || '#ffffff';
    const hasColor = !!colors[no];
    const item = document.createElement('div');
    item.className = 'plot-item';
    item.style.background = hasColor ? hexToRgba(color, 0.18) : '';
    item.innerHTML = `<span class="pname">Plot ${no}</span>
      <span class="pcolor" style="background:${hasColor ? color : '#f5f5f5'};"></span>`;
    item.addEventListener('click', () => {
      document.getElementById('plotNum').value = no;
      // scroll canvas into view
      document.getElementById('mapWrap').scrollIntoView({behavior:'smooth',block:'nearest'});
    });
    div.appendChild(item);
  }
}

// ── Init ──────────────────────────────────────────────────────
redraw();
</script>
</body>
</html>
