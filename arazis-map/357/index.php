<?php require_once __DIR__ . '/../no-cache.php'; ?>
<!doctype html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta charset="utf-8" />
  <title>Arazi Map 357</title>
  <style>
    html,body{height:100%; margin:0; padding:0; font-family:Arial, Helvetica, sans-serif;}
    #wrap{width:100%; max-width:900px; margin:20px auto;}
    #main{display:flex; align-items:stretch;}
    #cols{flex:1 1 auto;}
    .road-h{background-image:url('road2.jpg'); background-size:100% 100%; height:14px; width:100%;}
    .road-v{background-image:url('road1.jpg'); background-size:100% 100%; width:22px; flex:0 0 auto;}
    table.grid{width:100%; border-collapse:collapse; table-layout:fixed;}
    table.grid td{border:1px solid #999; padding:0; height:70px;}
    .marker{
      height:100%; width:100%;
      display:flex; align-items:center; justify-content:center;
      text-align:center; font-weight:bold; font-size:14px; color:#000;
      box-sizing:border-box;
      background-color:#FFC107; /* default = available, overwritten by JS from DB status */
      background-size:cover;
    }
    .marker.split{display:flex; flex-direction:row; padding:0;}
    .marker.split .half{flex:1 1 50%; height:90px;   display:flex; align-items:center; justify-content:center; border-right:1px solid #000;}
    .marker.split .half:last-child{border-right:none;}
    .side-col table.grid td{height:44px;}
    @media (max-width:480px){ .marker{font-size:11px;} }
  </style>
</head>
<body>
<form method="post" action="./index.php" id="form1">
<div id="wrap">

  <div id="main">
    <div id="cols">

      <!-- top strip: 18 (label), 37, 38, 39 -->
      <table class="grid">
        <tr>
          <td style="width:14%;"><div class="marker" style="background:#eee;"> </div></td>
          <td style="width:14%;"></td>
          <td colspan="3"><div class="marker" data-plot="37" style="background-image:url(amar.gif);">37</div></td>
          <td style="width:14%;"><div class="marker" data-plot="38" style="background-image:url(amar.gif);">38</div></td>
          <td style="width:14%;"><div class="marker" data-plot="39">39</div></td>
        </tr>
      </table>

      <div class="road-h"></div>

      <!-- row: 36-31, 30/30A -->
      <table class="grid">
        <tr>
          <td><div class="marker" data-plot="36">36</div></td>
          <td><div class="marker" data-plot="35">35</div></td>
          <td><div class="marker" data-plot="34">34</div></td>
          <td><div class="marker" data-plot="33">33</div></td>
          <td><div class="marker" data-plot="32">32</div></td>
          <td><div class="marker" data-plot="31">31</div></td>
          <td>
            <div class="marker split">
              <div class="half" data-plot="30A">30A</div>
              <div class="half" data-plot="30">30</div>
            </div>
          </td>
        </tr>
        <tr>
          <td><div class="marker" data-plot="23">23</div></td>
          <td><div class="marker" data-plot="24">24</div></td>
          <td><div class="marker" data-plot="25">25</div></td>
          <td><div class="marker" data-plot="26">26</div></td>
          <td><div class="marker" data-plot="27">27</div></td>
          <td><div class="marker" data-plot="28">28</div></td>
          <td><div class="marker" data-plot="29">29</div></td>
        </tr>
      </table>

      <div class="road-h"></div>

      <!-- row: 22-16/16A, 9-15 -->
      <table class="grid">
        <tr>
          <td><div class="marker" data-plot="22">22</div></td>
          <td><div class="marker" data-plot="21">21</div></td>
          <td><div class="marker" data-plot="20">20</div></td>
          <td><div class="marker" data-plot="19">19</div></td>
          <td><div class="marker" data-plot="18b">18</div></td>
          <td><div class="marker" data-plot="17">17</div></td>
          <td>
            <div class="marker split">
              <div class="half" data-plot="16A">16A</div>
              <div class="half" data-plot="16">16</div>
            </div>
          </td>
        </tr>
        <tr>
          <td><div class="marker" data-plot="9">9</div></td>
          <td><div class="marker" data-plot="10">10</div></td>
          <td><div class="marker" data-plot="11">11</div></td>
          <td><div class="marker" data-plot="12">12</div></td>
          <td><div class="marker" data-plot="13">13</div></td>
          <td><div class="marker" data-plot="14">14</div></td>
          <td><div class="marker" data-plot="15">15</div></td>
        </tr>
      </table>

      <div class="road-h"></div>

      <!-- bottom row: 8-1 -->
      <table class="grid">
        <tr>
          <td><div class="marker" data-plot="8">8</div></td>
          <td><div class="marker" data-plot="7">7</div></td>
          <td><div class="marker" data-plot="6">6</div></td>
          <td><div class="marker" data-plot="5">5</div></td>
          <td><div class="marker" data-plot="4">4</div></td>
          <td><div class="marker" data-plot="3">3</div></td>
          <td><div class="marker" data-plot="2">2</div></td>
          <td><div class="marker" data-plot="1">1</div></td>
        </tr>
      </table>

    </div>

    <div class="road-v"></div>

    <!-- right-hand side column: 40-51 -->
    <div class="side-col" style="flex:0 0 15%;">
      <table class="grid">
        <?php foreach (range(40, 51) as $n): ?>
        <tr><td><div class="marker" data-plot="<?= $n ?>"><?= $n ?></div></td></tr>
        <?php endforeach; ?>
      </table>
    </div>
  </div>

</div>

<?php
// Load shared DB credentials
require __DIR__ . '/../db-config.php';
$dbHost = MAP_DB_HOST;
$dbPort = MAP_DB_PORT;
$dbName = MAP_DB_NAME;
$dbUser = MAP_DB_USER;
$dbPass = MAP_DB_PASS;
$plots = [];

try {
    $dsn = "mysql:host={$dbHost};port={$dbPort};dbname={$dbName};charset=utf8mb4";
    $pdo = new PDO($dsn, $dbUser, $dbPass, [PDO::ATTR_ERRMODE => PDO::ERRMODE_EXCEPTION]);

    $legacyCode = 357;

    $aStmt = $pdo->prepare('SELECT id FROM arazis WHERE legacy_arazi_code = ? LIMIT 1');
    $aStmt->execute([$legacyCode]);
    $araziId = $aStmt->fetchColumn() ?: $legacyCode;

    $stmt = $pdo->prepare('SELECT p.id, p.title, p.area, p.status, p.description
                           FROM plots p
                           JOIN arazis a ON p.arazi_id = a.id
                           WHERE a.legacy_arazi_code = ?');
    $stmt->execute([$legacyCode]);
    $rows = $stmt->fetchAll(PDO::FETCH_ASSOC);

    if (empty($rows)) {
        $stmt = $pdo->prepare('SELECT id, title, area, status, description
                               FROM plots WHERE arazi_id = ?');
        $stmt->execute([$araziId]);
        $rows = $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    foreach ($rows as $r) {
        $plotId = $r['id'];
        $dbStatus = strtolower(trim($r['status'] ?? ''));

        $status = in_array($dbStatus, ['available','booked_advance','booked','hold','registry','blacklist','not_for_sale','issue'])
                  ? $dbStatus : null;

        if (!$status || $status === 'available') {
            $regStmt = $pdo->prepare("SELECT COUNT(*) FROM registries WHERE plot_id = ? AND (status = 'completed' OR payment_status = 'completed')");
            $regStmt->execute([$plotId]);
            if ($regStmt->fetchColumn() > 0) {
                $status = 'registry';
            } else {
                $bkStmt = $pdo->prepare("SELECT 1 FROM bookings WHERE plot_id = ? AND (status IS NULL OR status != 'expired') LIMIT 1");
                $bkStmt->execute([$plotId]);
                if ($bkStmt->fetchColumn() > 0) $status = 'booked';
            }
        }

        if (strpos(strtolower($r['description'] ?? ''), 'issue') !== false || empty($r['area']) || (float)$r['area'] <= 0) {
            $status = 'issue';
        }

        $plots[] = [
            'id' => $plotId,
            // plot title behaves like the plot number; exact key, never LIKE-matched
            'plot_number' => trim((string) $r['title']),
            'title' => trim((string) $r['title']),
            'area' => $r['area'],
            'status' => $status ?: 'available'
        ];
    }
} catch (Throwable $e) {
    // fail quiet on the map page; markers just default to available
}
?>

<script>
window.plots = <?php echo json_encode($plots, JSON_UNESCAPED_SLASHES | JSON_UNESCAPED_UNICODE); ?> || [];

document.addEventListener('DOMContentLoaded', function () {
    const colorMap = {
        'available': '#FFC107',
        'booked': '#28A745',
        'booked_advance': '#28A745',
        'not_for_sale': '#9E9E9E',
        'blacklist': '#212529',
        'hold': '#A0522D',
        'registry': '#E53935',
        'issue': '#FFC107'
    };
    const darkColors = ['#212529', '#28A745', '#E53935', '#A0522D'];

    const statusMap = {};
    window.plots.forEach(p => {
        // exact plot title match (e.g. "1", "16A", "30A") — never substring
        statusMap[String(p.plot_number).toUpperCase()] = String(p.status).toLowerCase();
    });

    document.querySelectorAll('[data-plot]').forEach(marker => {
        // "18b" is a de-duplication suffix for the map's own repeated "18"
        // label cell; it always maps back to plot "18" in the database.
        const key = marker.getAttribute('data-plot').replace(/b$/i, '').toUpperCase();
        const status = statusMap[key] || 'available';
        const color = colorMap[status] || '#FFC107';

        marker.style.backgroundColor = color;
        marker.style.color = darkColors.includes(color) ? '#fff' : '#000';
    });
});
</script>
</form>
</body>
</html>

<script><?php readfile(__DIR__ . '/../plot-click-popup.js'); ?></script>
