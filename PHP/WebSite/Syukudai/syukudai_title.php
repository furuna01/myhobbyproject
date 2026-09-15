<?php 
session_start();

if (!isset($_SESSION['username'])) {
    header('Location: syukudai_login.php');
}
?>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body style="background-color: #e0ffe0;">
<h1>大数宿題の管理サイト</h1>
<a href="Logout.php">Logout</a>
<p>宿題の正解者を調べたり、過去の問題を参照できます。</p>
<ul>
  <li><a href = "./answer/syukudai_top.php">宿題の正解者を見たい</a></li>
  <li><a href = "./problem/syukudai_problem_top.php">過去問を見たい</li>
</ul>
</body>
</html>