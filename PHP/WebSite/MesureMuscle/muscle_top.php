<?php
require 'DbAccess.php';
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
<h1>History of how thick the arm is</h1>
    <a href="Logout.php">Logout</a>
	<div style="border: 1px solid #333; width: 1000px;">
     <p>Input date when you mesured how thick the arm was and push the button register</p>
    <form id = "form" method="POST" action="muscle_register.php">
    <label>The day when you mesured.
      <input type="date" name="mesured_date" />
    </label>
    <label>How thick
    <input type="text" name="howthick" />
    </label>
    <button type="submit">Register</button>
    </form>
    </div>
    <br>
    <div style="border: 1px solid #333; width: 1000px;">
    <table border="1">
    <tr>
        <td>username</td>
        <td>mesure_date</td>
        <td>how thick</td>
        <td>maxthick</td>
        <td>minthick</td>
        <td>difference of most past and most recent</td>
    </tr>
<?php
    if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    $pdo = new DbAccess();
    $rows = $pdo->getAllMesureMuscleInfo($_SESSION['username']);
    print('User name was ' . $_SESSION['username']);
    if ($rows === null) {
        print("No data!");
    }
}

foreach ($rows as $row) {
    print(' <tr>');
    print('     <td>' . $row['username'] . '</td>');
    print('     <td>' . $row['mesured_date'] . '</td>');
    print('     <td>' . $row['howthick'] . 'cm </td>');
    print('     <td>' . $row['maxthick'] . 'cm </td>');
    print('     <td>' . $row['minthick'] . 'cm </td>');
    print('     <td>' . $row['difference'] . 'cm </td>');
    print(' </tr>');
}
?>
</table>
</body>
</html>