<?php
require 'DbAccess.php';  //読み込むファイル
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
<h1>You registered vold voice information.</h1>
<?php
$master_date = filter_input(INPUT_POST, 'master_date');
$title = filter_input(INPUT_POST, 'title');
$genre = filter_input(INPUT_POST, 'genre');
if(empty($master_date)) {
    print('Input the date when you masterbate!');
    return;
}

$array = explode("-", $master_date);
$year = $array[0];
$month = $array[1];
$day = $array[2];

if(mb_strlen($month) === 1) {
    $month = '0' . $month;
}
if(mb_strlen($day) === 1) {
    $day = '0' . $day;
}

$inputdate = $year . '年' . $month . '月' . $day . '日';
$username = $_SESSION['username'];

$pdo = new DbAccess();

try {
    $pdo->insertMasterInfo($username, $inputdate, $title, $genre);
}catch(Exception $e) {
    print('Error occured!' . $e->getMessage());
}

print('<p>You inputed the master informations</p>');
print('<p> Inputed user name was ' . $username . '</p>');
print('<p> Inputed master date was ' . $inputdate . '</p>');
print('<p> Inputed title was ' . $title . '</p>');
print('<p> Inputed genre was ' . $genre . '</p>');
?>
<form method="GET" action="master_top.php">
<button type="submit">Back</button>
</form>
</body>
</html>