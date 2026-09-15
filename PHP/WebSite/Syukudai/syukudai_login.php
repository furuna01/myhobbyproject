<?php
ini_set('display_errors', '1');
ini_set('display_startup_errors', '1');
error_reporting(E_ALL);
require './answer/DbAccess.php';
session_start();

$error = '';

if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $username = filter_input(INPUT_POST, 'username');
    $password = filter_input(INPUT_POST, 'password');

    $username = ($username === null || $username === false) ? '' : trim($username);
    $password = ($password === null || $password === false) ? '' : trim($password);

    if ($username === '' || $password === '') {
        $error = 'ユーザー名かパスワードが入力されていません。';
    } else {
        $pdo = new DbAccess();
        $user_name = $pdo->checkLogin($username, $password);

        if ($user_name === null) {
            $error = 'ユーザー名かパスワードが間違っています。';
        } else {
            $_SESSION['username'] = $user_name[0]['username'];

            header('Location: syukudai_title.php');
            exit;
        }
    }
}
?>
<!DOCTYPE html>
<html>
<head>
  <meta charset="UTF-8">
</head>
<body style="background-color: #e0ffe0;">
  <h1>大数宿題正解者の管理サイトにようこそ！</h1>
  <a href = "../index.php">Back</a>
  <?php if ($error !== ''): ?>
    <p><?= htmlspecialchars($error, ENT_QUOTES, 'UTF-8') ?></p>
  <?php endif; ?>

  <form action="syukudai_login.php" method="POST">
    <label>ユーザー名：</label>
    <input type="text" name="username" required>

    <label>パスワード：</label>
    <input type="password" name="password" required>

    <button type="submit">Login</button>
  </form>
</body>
</html>