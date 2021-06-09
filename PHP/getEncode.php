<?php
require_once ("./EncodeDecode.php");

$host = "mysql1032.db.sakura.ne.jp";
$dbName = "returnee-web_english";
$dsn = "mysql:host={$host};dbname={$dbName};charser=utf8mb4";
$username = "returnee-web";
$password = "Suminftyj-1";


$encode = new EncodeDecode();
$encode_host = $encode->Encode($password);
print($encode_host);
$decode_host = $encode->Decode($encode_host);
print($decode_host);
?>