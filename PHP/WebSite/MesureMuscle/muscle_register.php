<?php
require 'DbAccess.php';  //読み込むファイル
session_start();
if (!isset($_SESSION['username'])) {
    header('Location: muscle_login.php');
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
$mesured_date = filter_input(INPUT_POST, 'mesured_date');
$how_thick = filter_input(INPUT_POST, 'howthick');
$how_thick = (float)$how_thick - 2.1;
$how_thick = (string)$how_thick;


if(empty($mesured_date)) {
    print('Input the date when you mesured!');
    return;
}

$array = explode("-", $mesured_date);
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
    $pdo->insertMuscleMesuredInfo($username, $inputdate, $how_thick);
}catch(Exception $e) {
    print('Error occured!' . $e.getMessage());
}

print('<p>You inputed the muscle measure informations</p>');
print('<p> Inputed user name was ' . $username . '</p>');
print('<p> Inputed date you mesure how thick the arm was ' . $inputdate . '</p>');
print('<p> Inputed how thick was ' . $how_thick . 'cm </p>');
?>
<form method="GET" action="muscle_top.php">
<button type="submit">Back</button>
</form>
</body>
</html>