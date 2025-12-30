<?php
require_once("./const.php");
require_once("./EncodeDecode.php");
$Decode = new EncodeDecode();
$host = $Decode->Decode($host_encoded);
$dbName = $Decode->Decode($dbName_encoded);
$username = $Decode->Decode($username_encoded);
$password = $Decode->Decode($password_encoded);
$dsn = "mysql:host={$host};dbname={$dbName};charser=utf8mb4";
try {
    $PDO = new PDO($dsn, $username, $password);
    $PDO->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
    $PDO->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    print("接続成功！");

}catch (Exception $ex) {
    print($ex->getMessege());
}
?>