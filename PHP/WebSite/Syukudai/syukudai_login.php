<?php
require 'DbAccess.php';
session_start();
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $username = filter_input(INPUT_POST, 'username');
    $password = filter_input(INPUT_POST, 'password');
    print('ユーザー名は ' . $username);
    print('パスワードは ' . $password);
    if (trim($username) === '' || trim($password) === '') {
        print('<p>ユーザー名かパスワードが入力されていません</p>');
    }
    $pdo = new DbAccess();
    $user_name = $pdo->checkLogin($username, $password);
    if($user_name === null) {
        print('<p>ユーザー名かパスワードが間違っています!</p>');
        return;
    }
    // ログイン成功 → セッションに保存
    print('<p>ユーザー名は ' . $user_name . '</p>');
    $_SESSION['username'] = $user_name[0]['username'];
    
    header('Location: syukudai_top.php');
}
?>
<!DOCTYPE html>
<html>
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body style="background-color: #e0ffe0;">
	<h1>大数宿題正解者の管理サイトにようこそ！</h1>
		<form action="syukudai_login.php" method="POST">
    		<label>ユーザー名：</label>
    		<input type="text" name="username" required>

    		<label>パスワード：</label>
    		<input type="password" name="password" required>
    		<button type="submit">Login</button>
		</form>
	</body>
</html>