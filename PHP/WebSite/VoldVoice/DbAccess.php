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
            $sql = "SELECT * FROM vold_voice_user_info WHERE username = :username AND password = :password;";
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
    public function getAllVoldVoiceResult($user_name) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT * FROM vold_voice_info WHERE username = :username ORDER BY first_accent ASC, first_accent_percentage ASC";
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
    public function getVoldVoiceResultByOrder($user_name, $target_content, $order) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "";
            if(empty($target_content)) {
                if($order === 'asc') {
                    $sql = "SELECT * FROM vold_voice_info WHERE username = :username ORDER BY first_accent_percentage ASC";
                }else {
                    $sql = "SELECT * FROM vold_voice_info WHERE username = :username ORDER BY first_accent_percentage DESC";
                }
               
            }else {
                if($order === 'asc') {
                    $sql = "SELECT * FROM vold_voice_info WHERE username = :username AND english_sentence = :english_sentence ORDER BY first_accent_percentage ASC";
                }else {
                    $sql = "SELECT * FROM vold_voice_info WHERE username = :username AND english_sentence = :english_sentence ORDER BY first_accent_percentage DESC";
                }
            }
            $stmt = $pdo->prepare($sql);
            if(empty($target_content)) {
                $stmt->bindParam(':username', $user_name);
            }else {
                $stmt->bindParam(':username', $user_name);
                $stmt->bindParam(':english_sentence', $target_content);
            }
           
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
    public function insertVoldVoiceInfo($user_name, $first_accent, $first_accent_percentage, $second_accent, $second_accent_percentage, $third_accent, $third_accent_percantage, $english_sentences){
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
            $sql = "INSERT INTO vold_voice_info VALUES (:username, :first_accent, :first_accent_percentage, :second_accent, :second_accent_percentage, :third_accent, :third_accent_percentage, :english_sentences, :created_time);";
            $stmt = $pdo->prepare($sql);
            if(!$stmt) {
                return false;
            }
            // 値をバインドする
            $stmt->bindParam(':username', $user_name);
            $stmt->bindParam(':first_accent', $first_accent);
            $stmt->bindParam(':first_accent_percentage', $first_accent_percentage);
            $stmt->bindParam(':second_accent', $second_accent);
            $stmt->bindParam(':second_accent_percentage', $second_accent_percentage);
            $stmt->bindParam(':third_accent', $third_accent);
            $stmt->bindParam(':third_accent_percentage', $third_accent_percantage);
            $stmt->bindParam(':english_sentences', $english_sentences);
            $stmt->bindParam(':created_time', $create_date);
            $stmt->execute();
            return true;
        }catch (Exception $e) {
            echo "Error occured. insertIP: " . $e->getMessage();
            $pdo = null;
            return false;
        }
    }
}
?>