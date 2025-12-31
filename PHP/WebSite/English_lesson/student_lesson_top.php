<?php
require 'DbAccess.php';
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
<h1>Lesson history</h1>
    <a href="Logout.php">Logout</a>
  <br>
  <br
  <div style="border: 1px solid #333; width: 1000px;">
  <form id = "form" method="POST" action="student_lesson_top.php">
   <p>if you want to search target span lessons, Input time of from and to, then push button Search</p>
    <p>Teacher name
    <select name="teacher_name">
      <?php 
     $pdo = new DbAccess();
         //この画面に来るログインユーザーは生徒だから、ログインユーザー先生の生徒を取得
     $rows = $pdo->getTeacherInfo($_SESSION['username']);
     if($rows === null) {
         print('<p>You can\'t get student information.</p>');
         return;
     }
     foreach($rows as $row) {
         print('<option value="' . $row['teacher_name'] . '">' . $row['teacher_name'] . '</option>');
     }
     ?>
     </select>
     </p>
    <p>Lesson date</p>
    <p>From
    <input type="date" name="from_date" />
    To
    <input type="date" name="to_date" /></p>
    <button type="submit">Search</button>
    </form>
  </div>
  <table border="1">
     <tr>
         <td>Teacher name</td>
         <td>Lesson date</td>
         <td style="width: 600px;">Lesson content</td>
         <td>Money status</td>
     </tr>
<?php
$rows = null;
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $student_name = filter_input(INPUT_POST, 'teacher_name');
    $from_date = filter_input(INPUT_POST, 'from_date');
    $to_date = filter_input(INPUT_POST, 'to_date');
    
    //日付の加工
    if(!empty($from_date)) {
        $from_date = str_replace('-', '/', $from_date);
        $from_date = $from_date . ' ' . '00:00';
    }
    if(!empty($to_date)) {
        $to_date = str_replace('-', '/', $to_date);
        $to_date = $to_date . ' ' . '23:59';
    }
    if(empty($student_name)) {
        print('<p>Input the student_name at least.');
        return;
    }
    $pod = new DbAccess();
    $rows = $pod->getDeginatedLessonInfo($student_name, $from_date, $to_date);
    if($rows === null) {
        print('You failed search the lesson inftomation!</p>');
    }
} else if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    $pod = new DbAccess();
    $rows = $pod->getAllLessonInfo($_SESSION['username']);
}
foreach ($rows as $row) {
    print(' <tr>');
    print('     <td>' . $row['teacher_name'] . '</td>');
    print('     <td>' . $row['lesson_date'] . '</td>');
    print('     <td style="width: 800px">' . $row['content'] . '</td>');
    print('     <td>' . $row['money_status'] . '</td>');
    print(' </tr>');
}
?>
 </table>
</body>
</html>