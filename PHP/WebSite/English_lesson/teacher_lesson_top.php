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
	<div style="border: 1px solid #333; width: 1000px;">
     <p>Input the lesson information and push the button register</p>
    <form id = "form" method="POST" action="register.php">
      <p>Student name
     <select name="student_name">
     <?php 
     $pdo = new DbAccess();
         //この画面に来るログインユーザーは先生だから、ログインユーザー先生の生徒を取得
     $rows = $pdo->getStudentInfo($_SESSION['username']);
     if($rows === null) {
         print('<p>You can\'t get student information.</p>');
         return;
     }
     foreach($rows as $row) {
         print('<option value="' . $row['student_name'] . '">' . $row['student_name'] . '</option>');
     }
     ?>
     </select>
     </p>
      <p>Lesson date
      <input type="date" name="lesson_date" />
     	start hour
       <select name="hour">
     <?php 
     for($count = 0; $count <= 23; $count ++) {
         if(strlen(strval($count)) === 1) {
             $count = '0' . strval($count);
         }else {
             $count = strval($count);
         }
         print('<option value="' . $count . '">' . $count . '</option>');
     } 
     ?>
     </select>
      start mintes
      <select name="minites">
     <?php 
     for($count = 0; $count <= 59; $count ++) {
         if(strlen(strval($count)) === 1) {
             $count = '0' . strval($count);
         }else {
             $count = strval($count);
         }
         print('<option value="' . $count . '">' . $count . '</option>');
     } 
     ?>
     </select>
     </p>
     <p>Lesson content</p>
     <textarea style="width: 600px; height: 400px;" name="content"></textarea>
     <br>
     <button type="submit">Register</button>
  </form>
  </div>
  <br>
  <br>
  <div style="border: 1px solid #333; width: 1000px;">
  <form id = "form2" method="POST" action="change_money_status.php">
    <p>Input the student name and lesson date if you recieve money from student or mistakenly change the money status<br>
    to "recieved" without getting money from a student
    <p>Student name
     <select name="target_student_name">
      <?php 
     $pdo = new DbAccess();
         //この画面に来るログインユーザーは先生だから、ログインユーザー先生の生徒を取得
     $rows = $pdo->getStudentInfo($_SESSION['username']);
     if($rows === null) {
         print('<p>You can\'t get student information.</p>');
         return;
     }
     foreach($rows as $row) {
         print('<option value="' . $row['student_name'] . '">' . $row['student_name'] . '</option>');
     }
     ?>
     </select>
     </p>
    <p>Lesson date
    <input type="date" name="target_date" />
    start hour
      <select name="target_hour">
     <?php 
     for($count = 0; $count <= 23; $count ++) {
         if(strlen(strval($count)) === 1) {
             $count = '0' . strval($count);
         }else {
             $count = strval($count);
         }
         print('<option value="' . $count . '">' . $count . '</option>');
     } 
     ?>
     </select>
      start mintes
      <select name="target_minites">
     <?php 
     for($count = 0; $count <= 59; $count ++) {
         if(strlen(strval($count)) === 1) {
             $count = '0' . strval($count);
         }else {
             $count = strval($count);
         }
         print('<option value="' . $count . '">' . $count . '</option>');
     } 
     ?>
     </select>
     </p>
    <button type="submit">Change money status</button>
  </form>
  </div>
  <br>
  <br>
  <div style="border: 1px solid #333; width: 1000px;">
  <form id = "form2" method="POST" action="teacher_lesson_top.php">
   <p>if you want to search target span lessons, Input time of from and to, then push button Search</p>
    <p>Student name
    <select name="deginated_student_name">
      <?php 
     $pdo = new DbAccess();
         //この画面に来るログインユーザーは先生だから、ログインユーザー先生の生徒を取得
     $rows = $pdo->getStudentInfo($_SESSION['username']);
     if($rows === null) {
         print('<p>You can\'t get student information.</p>');
         return;
     }
     foreach($rows as $row) {
         print('<option value="' . $row['student_name'] . '">' . $row['student_name'] . '</option>');
     }
     ?>
     </select>
     </p>
    <p>Lesson date</p>
    <p>From
    <input type="date" name="deginatedfrom_date" />
    To
    <input type="date" name="deginatedto_date" /></p>
    <button type="submit">Search</button>
    </form>
  </div>
  <table border="1">
     <tr>
         <td>Student name</td>
         <td>Lesson date</td>
         <td style="width: 600px;">Lesson content</td>
         <td>Money status</td>
         <td>Delete</td>
     </tr>
<?php
$rows = null;
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $student_name = filter_input(INPUT_POST, 'deginated_student_name');
    $from_date = filter_input(INPUT_POST, 'deginatedfrom_date');
    $to_date = filter_input(INPUT_POST, 'deginatedto_date');
    
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
    $rows = $pod->getDeginatedLessonInfo($_SESSION['username'], $student_name, $from_date, $to_date);
    if($rows === null) {
        print('You failed search the lesson inftomation!</p>');
    }
} else if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    $pod = new DbAccess();
    $rows = $pod->getAllLessonInfo($_SESSION['username']);
}
foreach ($rows as $row) {
    print(' <tr>');
    print('     <td>' . $row['student_name'] . '</td>');
    print('     <td>' . $row['lesson_date'] . '</td>');
    print('     <td style="width: 800px">' . $row['content'] . '</td>');
    print('     <td>' . $row['money_status'] . '</td>');
    print('     <td>');
    print('        <form method="POST" action="delete_lesson_info.php" style="display:inline;">');
    print('          <input type="hidden" name="delete_teacher_name" value="' . $_SESSION['username'] . '">');
    print('          <input type="hidden" name="delete_student_name" value="' . $row['student_name'] . '">');
    print('          <input type="hidden" name="delete_lesson_date" value="' . $row['lesson_date'] . '">');
    print('          <button type="submit">Delete</button>');
    print('        </form>');
    print('     </td>');
    print(' </tr>');
}
?>
 </table>
</body>
</html>