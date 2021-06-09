<?php
require_once("./const.php");
require_once("./EncodeDecode.php");
require_once("./FileCommon.php");
class DBAccess {
    private $PDO;
    function __construct() {

    }
    public function registerEnglishSentences($english, $japanese, $table_name)
    {
        $Decode = new EncodeDecode();
        $host = $Decode->Decode(HOST_ENCODED);
        $dbName = $Decode->Decode(DBNAME_ENCODED);
        $username = $Decode->Decode(USERNAME_ENCODED);
        $password = $Decode->Decode(PASSWORD_ENCODED);
        $dns = "mysql:host={$host};dbname={$dbName};charser=utf8mb4";

        $PDO = new PDO($dns, $username, $password);
        $PDO->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
        $PDO->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        try {
            $file = new FileCommon(KEY_FILE);
            $data = $file->getFileData();
            $idnumber = (int)$data;
            $idnumber ++;
            //echo "before prepare";
            $sql_sentence = "INSERT INTO {$table_name} (id, english, japanese, updatedtime, createtime) VALUES (:id, :english, :japanese, :updatedtime, :createtime)";
            $stmt = $PDO->prepare($sql_sentence);
            $PDO->beginTransaction();
            //echo (string)$idnumber;
            //echo $english;
            //echo $japanese;
            $stmt->bindParam(':id', $idnumber, PDO::PARAM_INT);
            $stmt->bindParam(':english', $english, PDO::PARAM_STR);
            $stmt->bindParam(':japanese', $japanese, PDO::PARAM_STR);
            $nowdate = date('Y/m/d H:i:s');
            $stmt->bindParam(':updatedtime', $nowdate, PDO::PARAM_STR);
            $stmt->bindParam(':createtime', $nowdate, PDO::PARAM_STR);
            $stmt->execute();
            $PDO->commit();
            $file->inputFileData((string)$idnumber);
        }catch (PDOException $e) {
            $PDO->rollback();
            print("Error : " + $e->getMessege());
        }
        finally {
        }
    }
    public function getAllTableData($table_name) {
        $Decode = new EncodeDecode();
        $host = $Decode->Decode(HOST_ENCODED);
        $dbName = $Decode->Decode(DBNAME_ENCODED);
        $username = $Decode->Decode(USERNAME_ENCODED);
        $password = $Decode->Decode(PASSWORD_ENCODED);
        $dns = "mysql:host={$host};dbname={$dbName};charser=utf8mb4";

        $PDO = new PDO($dns, $username, $password);
        $PDO->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
        $PDO->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        try {
            $stmt = $PDO->prepare("SELECT * FROM {$table_name}");
            $stmt->execute();
            $result = $stmt->fetchAll();
            return $result;
        }catch(Exception $ex) {
            print("Error : " + $e->getMessege());
        }finally {
        }
    }
    public function CloseDataBase() {
        $PDO = null;
    }
}
?>