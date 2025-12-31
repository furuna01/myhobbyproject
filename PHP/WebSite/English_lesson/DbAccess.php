<?php
class DbAccess {
    const NO_DATA = 0;
    const ERROR = -1;
    const NOT_RECIEVED_TO_RECIEVED = 1;
    const RECIEVED_TO_NOTRECIEVED = 2;
    const STATUS_TEACHER = 3;
    const STATUS_STUDENT = 4;
   /**
    * 先生用の画面でレッスンした内容の情報をDBに登録する
    * @param $student_name
    * @param $teacher_name
    * @param $lesson_date
    * @param $content
    * @return boolean
    */
    public function insertLessonInfo($student_name, $teacher_name, $lesson_date, $content) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $money_status = 'Not recieved';
            $create_date = date('Y-m-d H:i:s');
            $sql = "INSERT INTO lesson_info (lesson_date, content, create_date, money_status, student_name, teacher_name) VALUES  (:lesson_date, :content, :create_date, :money_status, :student_name, :teacher_name);";
            $stmt = $pdo->prepare($sql);
            if(!$stmt) {
                return false;
            }
            // 値をバインドする
            $stmt->bindParam(':lesson_date', $lesson_date);
            $stmt->bindParam(':content', $content);
            $stmt->bindParam(':create_date', $create_date);
            $stmt->bindParam(':money_status', $money_status);
            $stmt->bindParam(':student_name', $student_name);
            $stmt->bindParam(':teacher_name', $teacher_name);
            $stmt->execute();
            return true;
        }catch (Exception $e) {
            echo "Error occured. insertIP: " . $e->getMessage();
            $pdo = null;
            return false;
        }
    }
    /**
     * ユーザが先生か生徒かチェックする
     * @param $user_name
     * @return boolean| ログインユーザーが先生だったらtrue
     */
    public function checkIfStudentTeacher($user_name) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT * FROM lesson_user_info WHERE username = :username;";
            $stmt = $pdo->prepare($sql);
            if(!$stmt) {
                print('<p>68</p>');
                return self::ERROR;
            }
            $stmt->bindParam(':username', $user_name);
            // 実行
            $stmt->execute();
            // 結果を全行取得
            $row = $stmt->fetchAll(PDO::FETCH_ASSOC);
            if(count($row) === 0) {
                print('<p>74</p>');
                return self::ERROR;
            }
            if(strcasecmp($row[0]['user_status'], 'teacher') === 0) {
                print('<p>78</p>');
                return self::STATUS_TEACHER;
            }else {
                print('<p>81</p>');
                return self::STATUS_STUDENT;
            }
        }catch (Exception $e) {
            print('<p>86</p>');
            print "<p>Errow occured checkIfStudentTeac: " . $e->getMessage() . "</p>";
            return self::ERROR;
        }
    }
    public function getStudentInfo($teacher_name) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT teacher_name, student_name FROM teacher_student_info WHERE teacher_name = :teacher_name;";
            $stmt = $pdo->prepare($sql);
            $stmt->bindParam(':teacher_name', $teacher_name);
            if(!$stmt) {
                return null;
            }
            // 実行
            $stmt->execute();
            // 結果を全行取得
            $rows = $stmt->fetchAll(PDO::FETCH_ASSOC);
            return $rows;
        }catch(Exception $e) {
            print "<p>Errow occured getStudentInfo: " . $e->getMessage() . "</p>";
            return null;
        }
    }
    public function getTeacherInfo($student_name) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT teacher_name, student_name FROM teacher_student_info WHERE student_name = :student_name;";
            $stmt = $pdo->prepare($sql);
            $stmt->bindParam(':student_name', $student_name);
            if(!$stmt) {
                return null;
            }
            // 実行
            $stmt->execute();
            // 結果を全行取得
            $rows = $stmt->fetchAll(PDO::FETCH_ASSOC);
            return $rows;
        }catch(Exception $e) {
            print "<p>Errow occured getStudentInfo: " . $e->getMessage() . "</p>";
            return null;
        }
    }
    public function getAllLessonInfo() {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT * FROM lesson_info ORDER BY lesson_date DESC;";
            $stmt = $pdo->prepare($sql);
            if(!$stmt) {
                return null;
            }
            // 実行
            $stmt->execute();
            // 結果を全行取得
            $row = $stmt->fetchAll(PDO::FETCH_ASSOC);
            //echo row[0]['lesson_date'] . row[0]['content'];
            return $row;
        }catch(Exception $e) {
            echo 'Error occured. getAllLessonInfo: ' . $e->getMessage();
            $pdo = null;
            return null;
        }
    }
    public function changeMoneyStatus($student_name, $lesson_date) {
        ini_set('display_errors', 1);
        error_reporting(E_ALL);
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "SELECT * FROM lesson_info WHERE student_name = :student_name AND lesson_date = :lesson_date;";
            $stmt = $pdo->prepare($sql);
            if(!$stmt) {
                return self::ERROR;
            }
            $stmt->bindParam(':lesson_date', $lesson_date);
            $stmt->bindParam(':student_name', $student_name);
            // 実行
            $stmt->execute();
            // 結果を全行取得
            $row = $stmt->fetchAll(PDO::FETCH_ASSOC);
            if(count($row) == 0) {
                return self::NO_DATA;
            }
            $money_status = $row[0]['money_status'];
            //該当結果が存在したのでmoney_statusを変える
            $sql = "UPDATE lesson_info SET money_status = :money_status WHERE student_name = :student_name AND lesson_date = :lesson_date;";
            $stmt = $pdo->prepare($sql);
            if(!$stmt) {
                return self::ERROR;
            }
            $recieved = 'Recieved';
            $not_recieved = 'Not recieved';
            if(strcmp($money_status, 'Not recieved') === 0) {
                $stmt->bindParam(':money_status', $recieved);
            }else {
                $stmt->bindParam(':money_status', $not_recieved);
            }
            $stmt->bindParam(':lesson_date', $lesson_date);
            $stmt->bindParam(':student_name', $student_name);
            // 実行
            $stmt->execute();
            if(strcmp($money_status, 'Not recieved') === 0) {
                return self::NOT_RECIEVED_TO_RECIEVED;
            }else {
                return self::RECIEVED_TO_NOTRECIEVED;
            }
        }catch(Exception $e) {
            $pdo = null;
            return self::ERROR;
        }
    }
    public function getDeginatedLessonInfo($user_name, $from_date, $to_date) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            if(strcasecmp($_SESSION['userstatus'], 'teacher') === 0 ) {
                $sql = "SELECT * FROM lesson_info WHERE student_name = :student_name";
            }else {
                $sql = "SELECT * FROM lesson_info WHERE teacher_name = :teacher_name";
            }
            
            if(!empty($from_date) && empty($to_date)) {
                $sql .= " AND lesson_date >= :from_date";
                $sql .= ";";
                $stmt = $pdo->prepare($sql);
                if(!$stmt) {
                    print('<p>getDeginatedLessonInfo 144</p>');
                    return null;
                }
                if(strcasecmp($_SESSION['userstatus'], 'teacher') === 0 ) {
                    $stmt->bindParam(':student_name', $user_name);
                }else {
                    $stmt->bindParam(':teacher_name', $user_name);
                }
                $stmt->bindParam(':from_date', $from_date);
            }else if(empty($from_date) && !empty($to_date)) {
                $sql .= " AND lesson_date <= :to_date";
                $sql .= " ORDER BY lesson_date DESC;";
                $stmt = $pdo->prepare($sql);
                if(!$stmt) {
                    print('<p>getDeginatedLessonInfo 154</p>');
                    return null;
                }
                if(strcasecmp($_SESSION['userstatus'], 'teacher') === 0 ) {
                    $stmt->bindParam(':student_name', $user_name);
                }else {
                    $stmt->bindParam(':teacher_name', $user_name);
                }
                $stmt->bindParam(':to_date', $to_date);
            }else if(!empty($from_date) && !empty($to_date)) {
                $sql .= " AND lesson_date >= :from_date AND lesson_date <= :to_date";
                $sql .= " ORDER BY lesson_date DESC;";
                $stmt = $pdo->prepare($sql);
                if(!$stmt) {
                    print('<p>getDeginatedLessonInfo 164</p>');
                    return null;
                }
                if(strcasecmp($_SESSION['userstatus'], 'teacher') === 0 ) {
                    $stmt->bindParam(':student_name', $user_name);
                }else {
                    $stmt->bindParam(':teacher_name', $user_name);
                }
                $stmt->bindParam(':from_date', $from_date);
                $stmt->bindParam(':to_date', $to_date);
            }else {
                $sql .= " ORDER BY lesson_date DESC;";
                $stmt = $pdo->prepare($sql);
                if(strcasecmp($_SESSION['userstatus'], 'teacher') === 0 ) {
                    $stmt->bindParam(':student_name', $user_name);
                }else {
                    $stmt->bindParam(':teacher_name', $user_name);
                }
                if(!$stmt) {
                    print('<p>getDeginatedLessonInfo 175</p>');
                    return null;
                }
            }
            // 実行
            $stmt->execute();
            // 結果を全行取得
            $row = $stmt->fetchAll(PDO::FETCH_ASSOC);
            if(count($row) === 0) {
                print('<p>No data!</p>');
            }
            return $row;
            
        }catch (Exception $e) {
            print('<p>Exception happend! getDeginatedLessonInfo');
            return null;
        }
    }
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
            $sql = "SELECT * FROM lesson_user_info WHERE username = :username AND password = :password;";
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
    public function insertUserInfo($target_username, $target_password) {
        try {
            $host = "mysql3109.db.sakura.ne.jp";
            $dbname = "yonetti_web_learning";
            $username = "yonetti_web_learning";
            $password = "suminftyj1";
            $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
            $pdo = new PDO($dsn, $username, $password);
            $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $sql = "INSERT INTO lesson_user_info VALUES (:username, :password, :updated_date, :created_date)";
            $stmt = $pdo->prepare($sql);
            $created_date = date('Y-m-d H:i:s');
            $updated_date = date('Y-m-d H:i:s');
            $stmt->bindParam(':username', $target_username);
            $stmt->bindParam(':password', $target_password);
            $stmt->bindParam(':updated_date', $updated_date);
            $stmt->bindParam(':created_date', $created_date);
            $stmt->execute();
            return true;
        }catch (Exception $e) {
            print('<p>Exception happend!</p>');
            return false;
        }
    }
}
?>