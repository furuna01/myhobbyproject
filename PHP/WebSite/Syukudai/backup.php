<?php
session_start();
if (!isset($_SESSION['username'])) {
    header('Location: syukudai_login.php');
    
}
try{
    $host = "mysql3109.db.sakura.ne.jp";
    $dbname = "yonetti_web_learning";
    $username = "yonetti_web_learning";
    $password = "suminftyj1";
    $dsn = "mysql:host={$host};dbname={$dbname};charset=utf8";
    $pdo = new PDO($dsn, $username, $password);
    $pdo->setAttribute(PDO::ATTR_EMULATE_PREPARES, false);
    $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);

    $accountforother = 'accountforother';
    $user_name = 'yonezawa';

    // --------------------------------------------------
    // 1. syukudai_info の過去データを消す
    // --------------------------------------------------
    $sql = "DELETE FROM syukudai_info WHERE username = :accountforother";
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':accountforother', $accountforother);
    $stmt->execute();

    // --------------------------------------------------
    // 2. syukudai_info にコピーする
    // --------------------------------------------------
    $sql  = "INSERT INTO syukudai_info (username, name, school, answer_date, created_time) ";
    $sql .= "SELECT :accountforother, name, school, answer_date, NOW() ";
    $sql .= "FROM syukudai_info ";
    $sql .= "WHERE username = :user_name;";

    $stmt = $pdo->prepare($sql); // ★ prepare が必要
    $stmt->bindParam(':accountforother', $accountforother);
    $stmt->bindParam(':user_name', $user_name);
    $stmt->execute();

    // --------------------------------------------------
    // 3. syukudai_problem_info の過去データを消す
    // --------------------------------------------------
    $sql = "DELETE FROM syukudai_problem_info WHERE username = :accountforother";
    $stmt = $pdo->prepare($sql);
    $stmt->bindParam(':accountforother', $accountforother);
    $stmt->execute();

    // --------------------------------------------------
    // 4. syukudai_problem_info にコピーする
    // --------------------------------------------------
    $sql  = "INSERT INTO syukudai_problem_info (username, problem_date, problem_path, created_time) ";
    $sql .= "SELECT :accountforother, problem_date, problem_path, NOW() ";
    $sql .= "FROM syukudai_problem_info ";
    $sql .= "WHERE username = :user_name;";

    $stmt = $pdo->prepare($sql); // ★ prepare が必要
    $stmt->bindParam(':accountforother', $accountforother);
    $stmt->bindParam(':user_name', $user_name);
    $stmt->execute();
}catch (Exception $e) {
    throw $e;
}
?>
<!DOCTYPE html>
<html>
<head>
  <meta charset="UTF-8">
</head>
<body style="background-color: #e0ffe0;">
<p>正常に実行されました</p>
</body>
</html>