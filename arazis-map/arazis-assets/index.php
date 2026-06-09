<?php
// Bootstrap Laravel for DB access
$laravelBase = dirname(__DIR__);
require $laravelBase . '/vendor/autoload.php';
$app = require_once $laravelBase . '/bootstrap/app.php';
$kernel = $app->make(Illuminate\Contracts\Http\Kernel::class);
$app->make('config'); // boot config
try {
    $app->boot();
} catch (\Throwable $e) {}

// Scan subdirectories that have an index.php
$mapsDir = __DIR__;
$maps = [];
foreach (glob($mapsDir . '/*/index.php') as $file) {
    $folder = basename(dirname($file));
    $maps[] = $folder;
}
sort($maps);

// Try to get arazi info from DB for each folder name
$araziInfo = [];
try {
    $arazis = \App\Models\Arazi::whereIn('legacy_arazi_code', $maps)->get()->keyBy('legacy_arazi_code');
    foreach ($maps as $folder) {
        $a = $arazis[$folder] ?? null;
        $araziInfo[$folder] = [
            'label'    => $a?->legacy_arazi_code ?? $folder,
            'location' => $a?->location ?? '',
            'size'     => $a ? (($a->size ?? '') . ' ' . ($a->unit ?? '')) : '',
            'plots'    => $a ? ($a->plots()->count()) : null,
            'id'       => $a?->id,
        ];
    }
} catch (\Throwable $e) {
    foreach ($maps as $folder) {
        $araziInfo[$folder] = ['label' => $folder, 'location' => '', 'size' => '', 'plots' => null, 'id' => null];
    }
}

$baseUrl = rtrim(dirname($_SERVER['SCRIPT_NAME']), '/');
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>All Arazi Maps</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.0/font/bootstrap-icons.css">
    <style>
        body { background: #f4f6fb; min-height: 100vh; }
        .page-header {
            background: linear-gradient(135deg, #1a1a2e 0%, #16213e 60%, #0f3460 100%);
            color: #fff;
            padding: 48px 0 36px;
            margin-bottom: 40px;
            box-shadow: 0 4px 24px rgba(0,0,0,0.18);
        }
        .page-header h1 { font-size: 2.4rem; font-weight: 700; letter-spacing: 1px; }
        .page-header p { opacity: .75; font-size: 1.05rem; }
        .map-card {
            background: #fff;
            border-radius: 16px;
            box-shadow: 0 2px 16px rgba(0,0,0,0.08);
            transition: transform .18s, box-shadow .18s;
            cursor: pointer;
            text-decoration: none;
            color: inherit;
            display: block;
            overflow: hidden;
            border: 2px solid transparent;
        }
        .map-card:hover {
            transform: translateY(-6px);
            box-shadow: 0 10px 36px rgba(0,0,0,0.14);
            border-color: #0f3460;
            color: inherit;
            text-decoration: none;
        }
        .map-card-icon {
            background: linear-gradient(135deg, #0f3460, #e94560);
            height: 110px;
            display: flex;
            align-items: center;
            justify-content: center;
            font-size: 3rem;
            color: #fff;
        }
        .map-card-body { padding: 20px 22px 18px; }
        .map-card-title { font-size: 1.35rem; font-weight: 700; color: #1a1a2e; margin-bottom: 6px; }
        .map-card-meta { font-size: .85rem; color: #6c757d; }
        .map-card-meta span { display: inline-flex; align-items: center; gap: 4px; margin-right: 12px; }
        .badge-plots { background: #e8f4fd; color: #0f3460; font-size: .8rem; padding: 3px 10px; border-radius: 20px; font-weight: 600; }
        .empty-state { text-align: center; padding: 80px 0; color: #aaa; }
        .empty-state i { font-size: 4rem; margin-bottom: 16px; display: block; }
        .search-wrap { max-width: 400px; }
        .search-wrap input { border-radius: 30px; padding-left: 16px; border: 1.5px solid #dee2e6; }
        .search-wrap input:focus { border-color: #0f3460; box-shadow: none; }
    </style>
</head>
<body>

<div class="page-header">
    <div class="container">
        <div class="d-flex align-items-center justify-content-between flex-wrap gap-3">
            <div>
                <h1><i class="bi bi-map me-2"></i>All Arazi Maps</h1>
                <p class="mb-0">Click any arazi to view its interactive plot map</p>
            </div>
            <div class="search-wrap">
                <input type="text" id="mapSearch" class="form-control" placeholder="&#128269; Search arazi...">
            </div>
        </div>
    </div>
</div>

<div class="container pb-5">
    <?php if (empty($maps)): ?>
        <div class="empty-state">
            <i class="bi bi-folder-x"></i>
            <p>No arazi maps found. Add a folder with <code>index.php</code> inside <code>arazis-map/</code>.</p>
        </div>
    <?php else: ?>
        <div class="mb-3 text-muted small"><?= count($maps) ?> map<?= count($maps) !== 1 ? 's' : '' ?> available</div>
        <div class="row g-4" id="mapGrid">
            <?php foreach ($maps as $folder):
                $info = $araziInfo[$folder];
                $url  = $baseUrl . '/' . rawurlencode($folder) . '/index.php';
                $icons = ['bi-geo-alt-fill','bi-layers-fill','bi-map-fill','bi-grid-fill'];
                $icon  = $icons[crc32($folder) % count($icons)];
            ?>
            <div class="col-sm-6 col-md-4 col-lg-3 map-item" data-name="<?= htmlspecialchars(strtolower($folder)) ?>">
                <a href="<?= htmlspecialchars($url) ?>" class="map-card" target="_blank">
                    <div class="map-card-icon">
                        <i class="bi <?= $icon ?>"></i>
                    </div>
                    <div class="map-card-body">
                        <div class="map-card-title">Arazi <?= htmlspecialchars($info['label']) ?></div>
                        <div class="map-card-meta">
                            <?php if ($info['location']): ?>
                                <span><i class="bi bi-geo-alt"></i><?= htmlspecialchars($info['location']) ?></span>
                            <?php endif; ?>
                            <?php if (trim($info['size'])): ?>
                                <span><i class="bi bi-rulers"></i><?= htmlspecialchars(trim($info['size'])) ?></span>
                            <?php endif; ?>
                        </div>
                        <?php if ($info['plots'] !== null): ?>
                            <div class="mt-2">
                                <span class="badge-plots"><i class="bi bi-grid"></i> <?= $info['plots'] ?> plots</span>
                            </div>
                        <?php endif; ?>
                    </div>
                </a>
            </div>
            <?php endforeach; ?>
        </div>
    <?php endif; ?>
</div>

<script>
    document.getElementById('mapSearch')?.addEventListener('input', function(){
        const q = this.value.toLowerCase().trim();
        document.querySelectorAll('.map-item').forEach(function(el){
            el.style.display = (!q || el.dataset.name.includes(q)) ? '' : 'none';
        });
    });
</script>
</body>
</html>
