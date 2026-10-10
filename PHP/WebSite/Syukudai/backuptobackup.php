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

    // トランザクション開始（処理を安全に行うため推奨）
    $pdo->beginTransaction();

    // 1. syukudai_info_backup の全削除
    $sql = "DELETE FROM syukudai_info_backup;";
    $stmt = $pdo->prepare($sql);
    $stmt->execute();

    // 2. syukudai_info からコピー
    $sql  = "INSERT INTO syukudai_info_backup (username, name, school, answer_date, created_time) ";
    $sql .= "SELECT username, name, school, answer_date, NOW() ";
    $sql .= "FROM syukudai_info;";
    $stmt = $pdo->prepare($sql);
    $stmt->execute();

    // 3. syukudai_problem_info_backup の全削除
    $sql = "DELETE FROM syukudai_problem_info_backup;";
    $stmt = $pdo->prepare($sql);
    $stmt->execute();

    // 4. syukudai_problem_info からコピー
    $sql  = "INSERT INTO syukudai_problem_info_backup (username, problem_date, problem_path, created_time) ";
    $sql .= "SELECT username, problem_date, problem_path, NOW() ";
    $sql .= "FROM syukudai_problem_info;";
    $stmt = $pdo->prepare($sql);
    $stmt->execute();

    // 処理を確定
    $pdo->commit();

} catch (Exception $e) {
    // エラーが起きた場合はロールバックして画面に表示
    if (isset($pdo) && $pdo->inTransaction()) {
        $pdo->rollBack();
    }
    exit('エラーが発生しました: ' . htmlspecialchars($e->getMessage(), ENT_QUOTES, 'UTF-8'));
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