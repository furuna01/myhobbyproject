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
            $sql = "SELECT * FROM muscle_user_info WHERE username = :username AND password = :password;";
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

    public function insertMuscleMesuredInfo($user_name, $inputdate, $howthick) {
        try{
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $create_date = date('Y-m-d H:i:s');
            $sql = "INSERT INTO arm_muscle_info VALUES (:username, :mesured_date, :howthick, :created_time, :maxthick, :minthick, :difference);";
            $stmt = $pdo->prepare($sql);
            if(!$stmt) {
                return false;
            }
            $maxthick = $this->getMaxThick($user_name);
            $minthick = $this->getMinThick($user_name);
            $difference = $this->getDifference($user_name, $howthick);
            if($howthick > $maxthick) {
                $maxthick = $howthick;
            }
            if($howthick < $minthick) {
                $minthick = $howthick;
            }
            // 値をバインドする
            $stmt->bindParam(':username', $user_name);
            $stmt->bindParam(':mesured_date', $inputdate);
            $stmt->bindParam(':howthick', $howthick);
            $stmt->bindParam(':created_time', $create_date);
            $stmt->bindParam(':maxthick', $maxthick);
            $stmt->bindParam(':minthick', $minthick);
            $stmt->bindParam(':difference', $difference);
            $stmt->execute();
            return true;
        }catch (Exception $e) {
            print('<p>Exception happend!</p>');
            return null;
        }
    }
    public function getAllMesureMuscleInfo($user_name) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT * FROM arm_muscle_info WHERE username = :username ORDER BY mesured_date DESC";
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
    private function getMaxThick($user_name) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT MAX(howthick) AS maxthick FROM arm_muscle_info WHERE username = :username;";
            $stmt = $pdo->prepare($sql);
            $stmt->bindParam(':username', $user_name);
            $stmt->execute();
            
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
            $max_thick = $result['maxthick'];
            return $max_thick;
        }catch (Exception $e) {
            print('<p>Exception happend!</p>');
            return null;
        }
    }
    private function getMinThick($user_name) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT MIN(howthick) AS minthick FROM arm_muscle_info WHERE username = :username;";
            $stmt = $pdo->prepare($sql);
            $stmt->bindParam(':username', $user_name);
            $stmt->execute();
            
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
            $min_thick = $result['minthick'];
            return $min_thick;
        }catch (Exception $e) {
            print('<p>Exception happend!</p>');
            return null;
        }
    }
    private function getDifference($user_name, $recent_thick) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT howthick FROM arm_muscle_info WHERE username = :username ORDER BY mesured_date ASC LIMIT 1";
            $stmt = $pdo->prepare($sql);
            $stmt->bindParam(':username', $user_name);
            $stmt->execute();
            
            $result = $stmt->fetch(PDO::FETCH_ASSOC);
            $last_howthick = (float)$result['howthick'];
            $recent_thick = (float)$recent_thick;
            $difference = $recent_thick - $last_howthick;
            $difference = (string)$difference;
            return $difference;
        }catch (Exception $e) {
            print('<p>Exception happend!</p>');
            return null;
        }
    }
}
?>