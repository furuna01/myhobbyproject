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
    $user_name = $pdo->checkLogin($username, $password);
    if($user_name === null) {
        print('<p>User or Password was wrong!');
        return;
    }
    print('<p>18</p>');
    $result = $pdo->checkIfStudentTeacher($username);
    print('<p>20</p>');
    if($result === DbAccess::ERROR) {
        print('<p>Error occured!</p>');
        return;
    }
    // ログイン成功 → セッションに保存
    print('<p>username was ' . $user_name . '</p>');
    $_SESSION['username'] = $user_name[0]['username'];
    $_SESSION['userstatus'] = $user_name[0]['user_status'];
    //ユーザーステータスを取る
    $pdo = new DbAccess();
    if($result === DbAccess::STATUS_TEACHER) {
        header('Location: teacher_lesson_top.php');
    }else if($result === DbAccess::STATUS_STUDENT){
        header('Location: student_lesson_top.php');
    }
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