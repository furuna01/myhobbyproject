<?php
require __DIR__ . '/../answer/DbAccess.php';
session_start();

if (!isset($_SESSION['username'])) {
    header('Location: ../syukudai_login.php');
    exit;
}
$username = $_SESSION['username'];
if($username !== 'yonezawa' && $username !== 'testuser') {
    print("<p>サイトのオーナーのアカウントでないと入力できません");
    return ;
}
if (!isset($_FILES['upload_file'])
    || $_FILES['upload_file']['error'] !== UPLOAD_ERR_OK) {
    exit('ファイルを選択できませんでした。');
}

$file = $_FILES['upload_file'];

if ($file['size'] > 10 * 1024 * 1024) {
    exit('ファイルは10MB以下にしてください。');
}
if (!class_exists('finfo')) {
    exit('finfo がサーバーで有効になっていません。');
}
$finfo = new finfo(FILEINFO_MIME_TYPE);
$mimeType = $finfo->file($file['tmp_name']);

if ($mimeType !== 'application/pdf') {
    exit('PDFファイルのみアップロードできます。');
}

$uploadDir = __DIR__ . '/pdf';

if (!is_dir($uploadDir)) {
    mkdir($uploadDir, 0755, true);
}
if (!function_exists('random_bytes')) {
    exit('random_bytes がサーバーで使えません。');
}
$fileName = bin2hex(random_bytes(16)) . '.pdf';
$savePath = $uploadDir . '/' . $fileName;
$dbPath = 'pdf/' . $fileName;

if (!move_uploaded_file($file['tmp_name'], $savePath)) {
    exit('ファイルを保存できませんでした。');
}

$date = filter_input(INPUT_POST, 'syukudai_date');

if ($date === null || $date === false || $date === '') {
    unlink($savePath);
    exit('日付を入力してください。');
}

[$year, $month] = explode('-', $date);
$inputdate = sprintf('%04d年%02d月号', $year, $month);

$db = new DbAccess();
$success = $db->InsertFileInfo(
    $_SESSION['username'],
    $inputdate,
    $dbPath
);

if ($success !== true) {
    unlink($savePath);
    exit('DBへの登録に失敗しました。');
}
?>
<!DOCTYPE html>
<html>
<head>
  <meta charset="UTF-8">
</head>
<body style="background-color: #e0ffe0;">
  <p>登録しました。</p>
  <p>入力した号：<?= htmlspecialchars($inputdate, ENT_QUOTES, 'UTF-8') ?></p>

  <form method="GET" action="syukudai_problem_top.php">
    <button type="submit">戻る</button>
  </form>
</body>
</html>