<?php
$c = 'mysql:host=127.0.0.1;dbname=realestatecrm_run;charset=utf8mb4';
$pdo = new PDO($c, 'root', '');
$rows = $pdo->query('select * from migrations order by id desc limit 40')->fetchAll(PDO::FETCH_ASSOC);
echo json_encode($rows, JSON_PRETTY_PRINT);
