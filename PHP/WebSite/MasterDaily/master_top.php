<?php
require 'DbAccess.php';
session_start();

if (!isset($_SESSION['username'])) {
    header('Location: master_login.php');
}
?>
<!DOCTYPE html>
<html>
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body style="background-color: #e0ffe0;">
<h1>Masterbate history</h1>
    <a href="Logout.php">Logout</a>
	<div style="border: 1px solid #333; width: 1000px;">
     <p>Input date where you masterbated and push the button register</p>
    <form id = "form" method="POST" action="master_register.php">
    <label>The day when you masterbated.
      <input type="date" name="master_date" />
    </label>
    <button type="submit">Register</button>
    </form>
    </div>
    <br>
    <div style="border: 1px solid #333; width: 1000px;">
  <form id = "form2" method="POST" action="master_top.php">
   <p>if you want to search target span date, Input time of from and to, then push button Search</p>
    <p>Master date</p>
    <p>From
    <input type="date" name="target_from_date" />
    To
    <input type="date" name="target_to_date" /></p>
    <button type="submit" name="action" value="asc">ASC</button>
    <button type="submit" name="action" value="desc">DESC</button>
    </form>
  </div>
 <br>
  <form id = "form3" method="POST" action="master_import.php">
   <button type="submit">Import</button>
   </form>
    <form id = "form3" method="POST" action="master_export.php">
   <button type="submit">Export</button>
   </form>
   <table border="1">
   <tr>
   <td>User name</td>
   <td>Date</td>
   </tr>
<?php
$pod = new DbAccess();
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $target_from_date = filter_input(INPUT_POST, 'target_from_date');
    $target_to_date = filter_input(INPUT_POST, 'target_to_date');
    
    if(empty($target_from_date) && !empty($target_to_date)) {
        $array = explode("-", $target_to_date);
        $year_to = $array[0];
        $month_to = $array[1];
        $day_to = $array[2];
        if(mb_strlen($month_to) === 1) {
            $month_to = '0' . $month_to;
        }
        if(mb_strlen($day_to) === 1) {
            $day_to = '0' . $day_to;
        }
        $target_to_date = $year_to . '年' . $month_to . '月' . $day_to . '日';
    }else if(!empty($target_from_date) && empty($target_to_date)) {
        $array = explode("-", $target_from_date);
        $year_from = $array[0];
        $month_from = $array[1];
        $day_from = $array[2];
        if(mb_strlen($month_from) === 1) {
            $month_from = '0' . $month_from;
        }
        if(mb_strlen($day_from) === 1) {
            $day_from = '0' . $day_from;
        }
        $target_from_date = $year_from . '年' . $month_from . '月' . $day_from . '日';
    }else if(!empty($target_from_date) && !empty($target_to_date)) {
        $array = explode("-", $target_from_date);
        $year_from = $array[0];
        $month_from = $array[1];
        $day_from = $array[2];
        
        $array = explode("-", $target_to_date);
        $year_to = $array[0];
        $month_to = $array[1];
        $day_to = $array[2];
        if(mb_strlen($month_from) === 1) {
            $month_from = '0' . $month_from;
        }
        if(mb_strlen($day_from) === 1) {
            $day_from = '0' . $day_from;
        }
        if(mb_strlen($month_to) === 1) {
            $month_to = '0' . $month_to;
        }
        if(mb_strlen($day_to) === 1) {
            $day_to = '0' . $day_to;
        }
        $target_from_date = $year_from . '年' . $month_from . '月' . $day_from . '日';
        $target_to_date = $year_to . '年' . $month_to . '月' . $day_to . '日';
    }else {
        $target_from_date = "";
        $target_to_date = "";
    }
    if ($_POST['action'] === 'asc') {
        $rows = $pod->getMasterResultByOrder($_SESSION['username'], $target_from_date, $target_to_date, 'asc');
    } else if ($_POST['action'] === 'desc') {
        $rows = $pod->getMasterResultByOrder($_SESSION['username'], $target_from_date, $target_to_date, 'desc');
    }
    if($rows === null) {
        print('You failed search the lesson inftomation!</p>');
    }
} else if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    $rows = $pod->getAllMasterInfo($_SESSION['username']);
}

foreach ($rows as $row) {
    print(' <tr>');
    print('     <td>' . $row['username'] . '</td>');
    print('     <td>' . $row['master_date'] . '</td>');
    print(' </tr>');
}
?>
</table>
</body>
</html>