<?php
class DbAccess {
    public function checkLogin($target_username, $target_password) {
        try {
            // 設定ファイルのパス
            $configFile = dirname(__DIR__, 2) . '/setting/config.properties';

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
            $sql = "SELECT * FROM syukudai_user_info WHERE username = :username AND password = :password;";
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
    public function insertSyukudaiInfo($user_name, $person_name, $school, $answer_date) {
        try{
            // 設定ファイルのパス
            $configFile = dirname(__DIR__, 2) . '/setting/config.properties';

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
            $create_date = date('Y-m-d H:i:s');
            $sql = "INSERT INTO syukudai_info VALUES (:user_name, :person_name, :school, :answer_date, :create_date);";
            $stmt = $pdo->prepare($sql);
            if(!$stmt) {
                return false;
            }
            // 値をバインドする
            $stmt->bindParam(':user_name', $user_name);
            $stmt->bindParam(':person_name', $person_name);
            $stmt->bindParam(':school', $school);
            $stmt->bindParam(':answer_date', $answer_date);
            $stmt->bindParam(':create_date', $create_date);
            $stmt->execute();
            return true;
        }catch (Exception $e) {
            print('<p>Exception happend!(InsertSyukudaiInfo)</p>');
            return null;
        }
    }
    public function getAllSyukudaiInfo($user_name) {
        try {
            // 設定ファイルのパス
            $configFile = dirname(__DIR__, 2) . '/setting/config.properties';

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
            $sql = "SELECT * FROM syukudai_info WHERE username = :username ORDER BY answer_date DESC";
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
    public function getTargetSyukudaiInfo($user_name, $from_date, $to_date, $target_name, $target_school) {
        try {
            // 設定ファイルのパス
            $configFile = dirname(__DIR__, 2) . '/setting/config.properties';

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
            $sql = "SELECT * FROM syukudai_info WHERE username = :username";
            $params = [
                ':username' => $user_name,
            ];
            if ($from_date !== '') {
                $fromInputDate = $this->makeInputDate($from_date);
                $sql .= ' AND answer_date >= :from_inputdate';
                $params[':from_inputdate'] = $fromInputDate;
            }
            
            if ($to_date !== '') {
                $toInputDate = $this->makeInputDate($to_date);
                $sql .= ' AND answer_date <= :to_inputdate';
                $params[':to_inputdate'] = $toInputDate;
            }
            
            if ($target_name !== '') {
                $sql .= ' AND name LIKE :target_name';
                $params[':target_name'] = '%' . $target_name . '%';
            }
            
            if ($target_school !== '') {
                $sql .= ' AND school LIKE :target_school';
                $params[':target_school'] = '%' . $target_school . '%';
            }
            
            
            $sql .= ' ORDER BY answer_date DESC';  
            $stmt = $pdo->prepare($sql);
            $stmt->execute($params);
            
            $user = $stmt->fetchAll(PDO::FETCH_ASSOC);
            if (count($user) === 0) {
                return null;
            }
            return $user;
            
        }catch (Throwable $e) {
            print('<p>エラー: ' . htmlspecialchars($e->getMessage(), ENT_QUOTES, 'UTF-8') . '</p>');
            return null;
        }
    }
    public function InsertFileInfo($user_name, $inputdate, $dbPath) {
        try {
            // 設定ファイルのパス
            $configFile = dirname(__DIR__, 2) . '/setting/config.properties';

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
            $create_date = date('Y-m-d H:i:s');
            $sql = "INSERT INTO syukudai_problem_info VALUES (:user_name, :problem_date, :problem_path, :create_date);";

            $stmt = $pdo->prepare($sql);
            if(!$stmt) {
                return false;
            }
            // 値をバインドする
            $stmt->bindParam(':user_name', $user_name);
            $stmt->bindParam(':problem_date', $inputdate);
            $stmt->bindParam(':problem_path', $dbPath);
            $stmt->bindParam(':create_date', $create_date);
            $stmt->execute();
            return true;
        }catch (Exception $e) {
            print('<p>エラー: ' . htmlspecialchars($e->getMessage(), ENT_QUOTES, 'UTF-8') . '</p>');
            return null;
        }
    }
    public function getAllProblemInfo($user_name) {
        try {
            // 設定ファイルのパス
            $configFile = dirname(__DIR__, 2) . '/setting/config.properties';

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
            $sql = "SELECT * FROM syukudai_problem_info WHERE username = :username ORDER BY problem_date DESC";
            $stmt = $pdo->prepare($sql);
            $stmt->bindParam(':username', $user_name);
            $stmt->execute();
            
            $user = $stmt->fetchAll(PDO::FETCH_ASSOC);
            if (count($user) === 0) {
                return null;
            }
            return $user;
        }catch (Exception $e) {
            print('<p>エラー: ' . htmlspecialchars($e->getMessage(), ENT_QUOTES, 'UTF-8') . '</p>');
            return null;
        }
    }
    private function makeInputDate(string $date): string
    {
        [$year, $month] = explode('-', $date);

        return sprintf('%04d年%02d月号', $year, $month);
    }
}
?>