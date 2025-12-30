<?php 
require 'DbAccess.php';
session_start();
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $username = filter_input(INPUT_POST, 'username');
    $password = filter_input(INPUT_POST, 'password');
    print('username was ' . $username);
    print('password was ' . $password);
    if (trim($username) === '' || trim($password) === '') {
        print('<p>You didn\'t input username or password!</p>');
    }
    $pdo = new DbAccess();
    $result = $pdo->checkLogin($username, $password);
    if($result == null) {
        print('<p>User or Password was wrong!');
        return;
    }
    // ログイン成功 → セッションに保存
    $_SESSION['username'] = $result[0]['username'];
    
    header('Location: lesson_top.php');
}
?>
<!DOCTYPE html>
<html>
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body style="background-color: #e0ffe0;">
	<h1>Wellcome to the English lesson management system!</h1>
		<form action="lesson_login.php" method="POST">
    		<label>Username：</label>
    		<input type="text" name="username" required>

    		<label>Password：</label>
    		<input type="password" name="password" required>
    		<button type="submit">Login</button>
		</form>
	</body>
</html>