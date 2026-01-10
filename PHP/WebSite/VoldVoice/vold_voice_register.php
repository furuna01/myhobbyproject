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
<h1>You registered vold voice information.</h1>
<?php
$user_name = $_SESSION['username'];
$first_accent = filter_input(INPUT_POST, 'first_accent');
$first_accent_percentage = filter_input(INPUT_POST, 'first_accent_percentage');
$second_accent = filter_input(INPUT_POST, 'second_accent');
$second_accent_percentage = filter_input(INPUT_POST, 'second_accent_percentage');
$third_accent = filter_input(INPUT_POST, 'third_accent');
$third_accent_percantage = filter_input(INPUT_POST, 'third_accent_percentage');
$content = filter_input(INPUT_POST, 'content');

if(empty($first_accent)) {
    print('Input the First accent!');
    return;
}
if(empty($first_accent_percentage)) {
    print('Input the First accent percentage!');
    return;
}
if(empty($second_accent)) {
    print('Input the second accent!');
    return;
}
if(empty($second_accent_percentage)) {
    print('Input the second accent percentage!');
    return;
}
if(empty($third_accent)) {
    print('Input the third accent!');
    return;
}
if(empty($third_accent_percantage)) {
    print('Input the third accent percentage!');
    return;
}
if(empty($content)) {
    print('Input the English sentences!');
    return;
}

$pdo = new DbAccess();

try {
    $pdo->insertVoldVoiceInfo($user_name, $first_accent, $first_accent_percentage, $second_accent, $second_accent_percentage, $third_accent, $third_accent_percantage, $content);
}catch(Exception $e) {
    print('Error occured!' . $e.getMessage());
}

print('<p>You inputed the Vold Voice informations</p>');
print('<p> Inputed frist accent was ' . $first_accent . '</p>');
print('<p>Inputed first accent percentage was ' . $first_accent_percentage . '</p>');
print('<p>Inputed second accent was ' . $second_accent . '</p>');
print('<p>Inputed second accent percentage was ' . $second_accent_percentage . '</p>');
print('<p>Inputed third accent was ' . $third_accent . '</p>');
print('<p>Inputed third accent percentage was ' . $third_accent_percantage . '</p>');
print('<p>Inputed English sentences was ' . $content . '</p>');
?>
<form method="GET" action="vold_voice_top.php">
<button type="submit">Back</button>
</form>
</body>
</html>
