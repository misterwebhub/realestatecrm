<?php
$c = 'mysql:host=127.0.0.1;dbname=realestatecrm_run;charset=utf8mb4';
$pdo = new PDO($c, 'root', '');
$cols = $pdo->query('DESCRIBE customer_bond_payments')->fetchAll(PDO::FETCH_ASSOC);
echo json_encode($cols, JSON_PRETTY_PRINT);
