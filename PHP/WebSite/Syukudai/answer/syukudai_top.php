<?php 
require 'DbAccess.php';
session_start();

if (!isset($_SESSION['username'])) {
    header('Location: syukudai_login.php');
}
?>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body style="background-color: #e0ffe0;">
<h1>大数宿題者の管理サイト</h1>
    <a href="../Logout.php">Logout</a>
    <a href = "../syukudai_title.php">戻る</a>
	<div style="border: 1px solid #333; width: 1000px;">
     <p>宿題を正解した大数の年月と名前、出身校を入力してください、なお、在校生の場合は出身校になるのでその扱いとします。</p>
    <form id = "form" method="POST" action="syukudai_register.php">
    <label>いつの大数の号の宿題を正解したか
      <input type="date" name="syukudai_date" />
    </label>
    <label>名前
    <input type="text" name="name" />
    </label>
    <label>出身校
    <input type="text" name="school" />
    </label>
    <button type="submit">登録</button>
    </form>
    </div>
    <div style="border: 1px solid #333; width: 1000px;">
    <form id = "form" method="POST" action="syukudai_top.php">
    <label>検索期間(いつから)
    <input type="date" name="from_syukudai_date" />
    </label>
    <br>
    <label>検索期間(いつまで)
    <input type="date" name="to_syukudai_date" />
    </label>
    <br>
    <label>名前
    <input type="text" name="target_name" />
    </label>
    <br>
    <label>出身校
    <input type="text" name="target_school" />
    </label>
    <br>
    <button type="submit">正解者検索</button>
    </form>
    </div>
    <div style="border: 1px solid #333; width: 1000px;">
    <table border="1">
    <tr>
        <td>名前</td>
        <td>出身校</td>
        <td>正解した号</td>
    </tr>
<?php
    if ($_SERVER['REQUEST_METHOD'] === 'GET') {
        $pdo = new DbAccess();
        $rows = $pdo->getAllSyukudaiInfo($_SESSION['username']);
        print('ユーザー名は ' . $_SESSION['username']);
        if ($rows === null) {
            print("No data!");
        }
    }
    else if($_SERVER['REQUEST_METHOD']=== 'POST') {
        $from_date = filter_input(INPUT_POST, 'from_syukudai_date') ?? '';
        $to_date = filter_input(INPUT_POST, 'to_syukudai_date') ?? '';
        $target_name = filter_input(INPUT_POST, 'target_name') ?? '';
        $target_school = filter_input(INPUT_POST, 'target_school') ?? '';
        $pdo = new DbAccess();

        $rows = $pdo->getTargetSyukudaiInfo($_SESSION['username'], $from_date, $to_date, $target_name, $target_school);
        print('ユーザー名は ' . $_SESSION['username']);
        if ($rows === null) {
            print("No data!");
        }
    }

foreach ($rows as $row) {
    print(' <tr>');
    print('     <td>' . $row['name'] . '</td>');
    print('     <td>' . $row['school'] . '</td>');
    print('     <td>' . $row['answer_date'] . ' </td>');
    print(' </tr>');
}
?>
</table>
</body>
</html>
