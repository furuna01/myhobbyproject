<!DOCTYPE html>
<html>
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body style="background-color: #e0ffe0;">
<h1>Register date screen</h1>
<?php
require 'DbAccess.php';
session_start();

if (!isset($_SESSION['username'])) {
    header('Location: lesson_login.php');
}

$file_path = './kiroku.txt';
$lines = null;
try {
    $lines = file($file_path);
}catch (Exception $e) {
    print('<p>Exception happend!' . $e->getMessage() . '</p>');
}


$user_name = $_SESSION['username'];
$lines = file($file_path);

try {
    $host = "mysql3109.db.sakura.ne.jp";
    $dbname = "yonetti_web_learning";
    $username = "yonetti_web_learning";
    $password = "suminftyj1";
    $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
    $pdo = new PDO($dsn, $username, $password);
    $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
    
    foreach ($lines as $line) {
        //一行ずつDBに挿入
        $sql = "INSERT INTO master_date VALUES (:username, :master_date, :created_time);";
        $stmt = $pdo->prepare($sql);
        if(!$stmt) {
            print('<p>Error occured! 22!');
        }
        $temp = explode('年', $line);
        $year = $temp[0];
        $temp2 = explode('月', $temp[1]);
        $month = $temp2[0];
        $temp3 = explode('日', $temp2[1]);
        $day = $temp3[0];
        if(mb_strlen($month) === 1) {
            $month = '0' . $month;
        }
        if(mb_strlen($day) === 1) {
            $day = '0' . $day;
        }
        $master_date = $year . '年' . $month . '月' . $day . '日';
        
        $stmt->bindParam(':username', $user_name);
        $stmt->bindParam(':master_date', $master_date);
        $create_date = date('Y-m-d H:i:s');
        $stmt->bindParam(':created_time', $create_date);
        $stmt->execute();
        print('<p>' . $master_date . 'was completed!</p>');
    }
}catch (Exception $e) {
    print('<p>Exception happend!' . $e->getMessage() . '</p>');
}
?>
</body>
</html>