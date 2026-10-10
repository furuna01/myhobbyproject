<?php
class DbAccess {
    public function insertUserInfo($ipaddress, $useragent, $page) {
        try{
            // 設定ファイルのパス
            $configFile = dirname(__DIR__, 0) . '/setting/config.properties';

            if (!file_exists($configFile)) {
                die("設定ファイルが見つかりません。");
            }

            // ファイルを読み込んで連想配列に変換
            $config = parse_ini_file($configFile);

            // 連想配列から値を取り出す
            $host     = $config['host'];
            $dbname   = $config['dbname'];
            $username = $config['username'];
            $password = $config['password'];
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $visitdate = date('Y-m-d H:i:s');
            $sql = "INSERT INTO user_info VALUES (:ipaddress, :useragent, :visitpage, :visitdate);";
            $stmt = $pdo->prepare($sql);
            if(!$stmt) {
                return false;
            }
            // 値をバインドする
            $stmt->bindParam(':ipaddress', $ipaddress);
            $stmt->bindParam(':useragent', $useragent);
            $stmt->bindParam(':visitpage', $page);
            $stmt->bindParam(':visitdate', $visitdate);
            $stmt->execute();
            return true;
        }catch (Exception $e) {
            throw $e;
        }
    }
    public function getUsers() {
        try {
            // 設定ファイルのパス
            $configFile = dirname(__DIR__, 0) . '/setting/config.properties';

            if (!file_exists($configFile)) {
                die("設定ファイルが見つかりません。");
            }

            // ファイルを読み込んで連想配列に変換
            $config = parse_ini_file($configFile);

            // 連想配列から値を取り出す
            $host     = $config['host'];
            $dbname   = $config['dbname'];
            $username = $config['username'];
            $password = $config['password'];
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT COUNT(DISTINCT ipaddress) AS usernumber FROM user_info";
            $stmt = $pdo->prepare($sql);
            $stmt->execute();
            
            $user = $stmt->fetch(PDO::FETCH_ASSOC);
            if (count($user) === 0) {
                return null;
            }
            return $user['usernumber'];
            
        }catch (Exception $e) {
            throw $e;
        }
    }
}