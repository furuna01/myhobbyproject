<?php 
$dbAccessPath = __DIR__ . '/../answer/DbAccess.php';

if (!is_file($dbAccessPath)) {
    exit('DbAccess.php が見つかりません: ' . $dbAccessPath);
}

require_once $dbAccessPath;
//require __DIR__ . '/../answer/DbAccess.php';
session_start();

if (!isset($_SESSION['username'])) {
    header('Location: ../syukudai_login.php');
    exit;
}
?>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body style="background-color: #e0ffe0;">
<h1>大数宿題の過去問</h1>
<p><a href = "../syukudai_title.php">戻る</a></p>
<form id="form"
        method="POST"
        action="syukudai_problem_register.php"
        enctype="multipart/form-data">

<label>
いつの大数の号の宿題の問題をアップロードしたいか
<input type="date" name="syukudai_date" required>
</label>
<br><br>
<label>
  解答PDF
  <input type="file" name="upload_file" accept=".pdf,application/pdf" required>
</label>
<br><br>
<button type="submit">登録</button>
</form>
<table border="1">
<tr>
<td>見たい問題の号</td>
</tr>
<?php
    if ($_SERVER['REQUEST_METHOD'] === 'GET') {
        $rows = [];
        $error = '';
        
        try {
            $db = new DbAccess();
            $result = $db->getAllProblemInfo($_SESSION['username']);
        
            if (is_array($result)) {
                $rows = $result;
            }
        } catch (Exception $e) {
            $error = '問題一覧を取得できませんでした。';
            error_log($e->getMessage());
        }
    }
    foreach ($rows as $row) {
        print(' <tr>');
        print('     <td><a href = "' . $row['problem_path'] . '">' . $row['problem_date'] . '</a></td>');
        print(' </tr>');
    }
?>
</table>
</body>
</html>