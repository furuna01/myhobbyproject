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
$teacher_name = filter_input(INPUT_POST, 'delete_teacher_name');
$student_name = filter_input(INPUT_POST, 'delete_student_name');
$date = filter_input(INPUT_POST, 'delete_lesson_date');

if(empty($student_name)) {
    print('Input the student name!');
    return;
}
if(empty($date)) {
    print('Input the lesson date!');
    return;
}

$pdo = new DbAccess();

try {
    $pdo->deleteLessonInfo($teacher_name, $student_name, $date);
}catch(Exception $e) {
    print('Error occured!' . $e.getMessage());
}

print('<p>You deleted the lesson informations</p>');
print('<p> Deleted teacher name was ' . $teacher_name . '</p>');
print('<p> Deleted student name was ' . $student_name . '</p>');
print('<p> Deleted date was ' . $date . '</p>');
?>
<form method="GET" action="teacher_lesson_top.php">
<button type="submit">Back</button>
</form>
</body>
</html>