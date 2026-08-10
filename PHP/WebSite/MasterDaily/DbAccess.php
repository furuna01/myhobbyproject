<?php
class DbAccess {
    
    public function checkLogin($target_username, $target_password) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT * FROM master_user_info WHERE username = :username AND password = :password;";
            $stmt = $pdo->prepare($sql);
            $stmt->bindParam(':username', $target_username);
            $stmt->bindParam(':password', $target_password);
            $stmt->execute();
            
            $user = $stmt->fetchAll(PDO::FETCH_ASSOC);
            if (count($user) === 0) {
                print('<p>205</p>');
                return null;
            }
            return $user;
            
        }catch (Exception $e) {
            print('<p>Exception happend!</p>');
            return null;
        }
    }
    public function insertMasterInfo($user_name, $inputdate, $title, $genre) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $create_date = date('Y-m-d H:i:s');
            $sql = "INSERT INTO master_date VALUES (:username, :master_date, :created_time, :title, :genre);";
            $stmt = $pdo->prepare($sql);
            if(!$stmt) {
                return false;
            }
            // 値をバインドする
            $stmt->bindParam(':username', $user_name);
            $stmt->bindParam(':master_date', $inputdate);
            $stmt->bindParam(':created_time', $create_date);
            $stmt->bindParam(':title', $title);
            $stmt->bindParam(':genre', $genre);
            $stmt->execute();
            return true;
        }catch (Exception $e) {
            echo "Error occured. insertMasterInfo: " . $e->getMessage();
            $pdo = null;
            return false;
        }
    }
    public function getAllMasterInfo($user_name) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT * FROM master_date WHERE username = :username ORDER BY master_date DESC";
            $stmt = $pdo->prepare($sql);
            $stmt->bindParam(':username', $user_name);
            $stmt->execute();
            
            $user = $stmt->fetchAll(PDO::FETCH_ASSOC);
            if (count($user) === 0) {
                return null;
            }
            return $user;
            
        }catch (Exception $e) {
            print('<p>Exception happend!</p>');
            return null;
        }
    }
    public function getMasterResultByOrder($user_name, $target_from_date, $target_to_date, $order) {
        try{
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            
            if(empty($target_from_date) && !empty($target_to_date)) {
                $sql = "SELECT * FROM master_date WHERE username = :username AND master_date <= :target_to_date";
            }else if(!empty($target_from_date) && empty($target_to_date)) {
                $sql = "SELECT * FROM master_date WHERE username = :username AND master_date >= :target_from_date";
            }else if(!empty($target_from_date) && !empty($target_to_date)) {
                $sql = "SELECT * FROM master_date WHERE username = :username AND master_date >= :target_from_date AND master_date <= :target_to_date";
            }else if(empty($target_from_date) && empty($target_to_date)){
                $sql = "SELECT * FROM master_date WHERE username = :username";
            }
            if($order === 'asc') {
                $sql .= ' ORDER BY master_date ASC;';
            }else if($order === 'desc'){
                $sql .= ' ORDER BY master_date DESC;';
            }
            $stmt = $pdo->prepare($sql);
            if(empty($target_from_date) && (!empty($target_to_date))) {
                $stmt->bindParam(':username', $user_name);
                $stmt->bindParam(':target_to_date', $target_to_date);
            }else if((!empty($target_from_date)) && empty($target_to_date)) {
                $stmt->bindParam(':username', $user_name);
                $stmt->bindParam(':target_from_date', $target_from_date);
            }else if((!empty($target_from_date)) && (!empty($target_to_date))) {
                $stmt->bindParam(':username', $user_name);
                $stmt->bindParam(':target_from_date', $target_from_date);
                $stmt->bindParam(':target_to_date', $target_to_date);
            }else{
                $stmt->bindParam(':username', $user_name);
            }
            $stmt->execute();
            
            $user = $stmt->fetchAll(PDO::FETCH_ASSOC);
            if (count($user) === 0) {
                return null;
            }
            return $user;
        }catch (Exception $e) {
        print('<p>Exception happend!</p>');
        return null;
        }
    }
}
?>