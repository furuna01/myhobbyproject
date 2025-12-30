<?php
require 'DbAccess.php';  //読み込むファイル
session_start();
if (!isset($_SESSION['username'])) {
    header('Location: lesson_login.php');
}
?>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body style="background-color: #e0ffe0;">
<h1>You registered lesson information.</h1>
<?php
$student_name = filter_input(INPUT_POST, 'student_name');
//ここにログインしているのは先生のみ
$teacher_name = $_SESSION['username'];
$date = filter_input(INPUT_POST, 'lesson_date');
$hour = filter_input(INPUT_POST, 'hour');
$minites = filter_input(INPUT_POST, 'minites');
$content = filter_input(INPUT_POST, 'content');

if(empty($student_name)) {
    print('Input the student name!');
    return;
}
if(empty($date)) {
    print('Input the lesson date!');
    return;
}
if(empty($hour)) {
    print('Input the hour');
    return;
}
if(empty($minites)) {
    print('Input the minites');
    return;
}
if(empty($content)) {
    print('Input the content');
    return;
}

$date = str_replace('-', '/', $date);
$time = $date . ' ' . $hour . ':' . $minites;
$pdo = new DbAccess();

try {
    $pdo->insertLessonInfo($student_name, $teacher_name, $time, $content);
}catch(Exception $e) {
    print('Error occured!' . $e.getMessage());
}

print('<p>You inputed the lesson informations</p>');
print('<p> Student name was ' . $student_name . '</p>');
print('<p>inputed time was ' . $time . '</p>');
print('<p>inputed content was ' . $content . '</p>');
?>
<p>You did not get lesson fee</p>
<form method="GET" action="lesson_top.php">
<button type="submit">Back</button>
</form>
</body>
</html>