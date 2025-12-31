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
<h1>You changed the money status.</h1>
<?php
$student_name = filter_input(INPUT_POST, 'target_student_name');
$date = filter_input(INPUT_POST, 'target_date');
$hour = filter_input(INPUT_POST, 'target_hour');
$minites = filter_input(INPUT_POST, 'target_minites');

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

$date = str_replace('-', '/', $date);
$time = $date . ' ' . $hour . ':' . $minites;

print('<p>Target time was ' . $time . '</p>');
print('<p>Student name was ' . $student_name . '</p>');

$pdo = new DbAccess();
$result = 0;
try {
    $result = $pdo->changeMoneyStatus($student_name, $time);
}catch(Exception $e) {
    print('Error occured!' . $e.getMessage());
}
if($result === DbAccess::NO_DATA) {
    print('<p>There was no target time</p>');
}
if($result === DbAccess::NOT_RECIEVED_TO_RECIEVED) {
    print('<p>You changed the money status "Not recieved" to "Recieved"</p>');
}
if($result === DbAccess::RECIEVED_TO_NOTRECIEVED) {
    print('<p>You changed the money status "Recieved" to "Not recieved"</p>');
}
if($result === DbAccess::ERROR) {
    print('<p>Error occured.</p>');
}
?>
<form method="GET" action="teacher_lesson_top.php">
<button type="submit">Back</button>
</form>
</body>
</html>