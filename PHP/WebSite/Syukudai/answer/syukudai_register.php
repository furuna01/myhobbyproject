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
$username = $_SESSION['username'];
if($username !== 'yonezawa' && $username !== 'testuser') {
    print("<p>サイトのオーナーのアカウントでないと入力できません");
    return ;
}

$answer_date = filter_input(INPUT_POST, 'syukudai_date');
$name = filter_input(INPUT_POST, 'name');
$school = filter_input(INPUT_POST, 'school');

if(empty($answer_date)) {
    print('Input the date when you mesured!');
    return;
}
[$year, $month] = explode('-', $answer_date);

$inputdate = sprintf('%04d年%02d月号', $year, $month);

$pdo = new DbAccess();

try {
    $pdo->insertSyukudaiInfo($username, $name, $school, $inputdate);
}catch(Exception $e) {
    print('Error occured!' . $e.getMessage());
}

print('<p>宿題正解者の情報を入力しました。</p>');
print('<p>入力したユーザー名は ' . $username . '</p>');
print('<p>入力した正解者名は ' . $name . '</p>');
print('<p>入力した正解者の出身校は ' . $school . '</p>');
print('<p>入力した正解号の月は ' . $inputdate . '</p>');

?>
<form method="GET" action="syukudai_top.php">
<button type="submit">Back</button>
</form>
</body>
</html>