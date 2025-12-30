<?php 
require 'DbAccess.php';
session_start();

if (!isset($_SESSION['username'])) {
    exit('ログインしてください');
}
?>
<!DOCTYPE html>
<html>
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body style="background-color: #e0ffe0;">
<h1>Lesson history</h1>
	<div style="border: 1px solid #333; width: 1000px;">
     <p>Input the lesson information and push the button register</p>
    <form id = "form" method="POST" action="register.php">
      <p>Student name</p>
      <input type="text" name="student_name" /><br/>
      <p>Lesson date
      <input type="date" name="lesson_date" />
     start hour
     <input type="text" name="hour" />
      start mintes
     <input type="text" name="minites" /></p>
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
    <p>Input the student name and lesson date if you recieve money from student or mistakenly change the money status</br>
    to "recieved" without getting money from a student
    <p>Student name</p>
    <input type="text" name="target_student_name" /><br/>
    <p>Lesson date
    <input type="date" name="target_date" />
    <p>start hour
    <input type="text" name="target_hour" />
    start mintes
    <input type="text" name="target_minites" /></p>
    <button type="submit">Change money status</button>
  </form>
  </div>
  <br>
  <br>
  <div style="border: 1px solid #333; width: 1000px;">
  <form id = "form2" method="POST" action="lesson_top.php">
   <p>if you want to search target span lessons, Input time of from and to, then push button Search</p>
    <p>Student name</p>
    <input type="text" name="deginated_student_name" /><br/>
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
         <td>Lesson date</td>
         <td style="width: 600px;">Lesson content</td>
         <td>Money status</td>
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
    $rows = $pod->getDeginatedLessonInfo($student_name, $from_date, $to_date);
    if($rows === null) {
        print('You failed search the lesson inftomation!');
    }
} else if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    $pod = new DbAccess();
    $rows = $pod->getAllLessonInfo();
}
foreach ($rows as $row) {
    print(' <tr>');
    print('     <td>' . $row['lesson_date'] . '</td>');
    print('     <td style="width: 800px">' . $row['content'] . '</td>');
    print('     <td>' . $row['money_status'] . '</td>');
    print(' </tr>');
}
?>
 </table>
</body>
</html>