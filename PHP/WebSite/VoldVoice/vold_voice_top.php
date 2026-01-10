<?php 
require 'DbAccess.php';
session_start();

if (!isset($_SESSION['username'])) {
    header('Location: vold_voice_login.php');
}
?>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
</head>
<body style="background-color: #e0ffe0;">
<h1>Score of the Vold Voice</h1>
<a href="Logout.php">Logout</a>
<div style="border: 1px solid #333; width: 1000px;">
<p>Input the score of Vold Voice</p>
<form id = "form" method="POST" action="vold_voice_register.php">
<table>
<tr>
<td>
<p>Accent</p>
</td>
<td>
<p>Percent</p>
</td>
</tr>
<tr>
<td>
<label>First Accent
<input type="text" name="first_accent" />
</label>
</td>
<td>
<label>First Accent Percentage
<input type="text" name="first_accent_percentage" />
</label>
</td>
</tr>
<tr>
<td>
<label>Second Accent
<input type="text" name="second_accent" />
</label>
</td>
<td>
<label>Second Accent Percentage
<input type="text" name="second_accent_percentage" />
</label>
</td>
</tr>
<tr>
<td>
<label>third Accent
<input type="text" name="third_accent" />
</label>
</td>
<td>
<label>Third Accent Percentage
<input type="text" name="third_accent_percentage" />
</label>
</td>
</tr>
</table>
 <p>Englislh sentence</p>
     <textarea style="width: 600px; height: 150px;" name="content"></textarea>
     <br>
     <button type="submit">Register</button>
  </form>
  </div>
  <br>
  <div style="border: 1px solid #333; width: 700px;">
 <form method="POST" action="vold_voice_top.php">
 <p>Target English sentence</p>
 <p>This system search the target english sentence with depending on how first accent percentage is low or high.</p>
 <textarea style="width: 600px; height: 150px;" name="target_content"></textarea>
     <br>
     <button type="submit" name="action" value="asc">ASC</button>
    <button type="submit" name="action" value="desc">DESC</button>
  </form>
 </div>
 
 <?php
$rows = null;
$pod = new DbAccess();
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $target_content = filter_input(INPUT_POST, 'target_content');
    if ($_POST['action'] === 'asc') {
        $rows = $pod->getVoldVoiceResultByOrder($_SESSION['username'], $target_content, 'asc');
    } elseif ($_POST['action'] === 'desc') {
        $rows = $pod->getVoldVoiceResultByOrder($_SESSION['username'], $target_content, 'desc');
    }
} else if ($_SERVER['REQUEST_METHOD'] === 'GET') {
    $rows = $pod->getAllVoldVoiceResult($_SESSION['username']);
}
foreach ($rows as $row) {
    print('<table border="1">');
    print('<tr>');
    print('<td>');
    print('<p>Accent</p>');
    print('</td>');
    print('<td>');
    print('<p>Percent</p>');
    print('</td>');
    print('</tr>');
    print('<tr>');
    print('<td>');
    print('<p>First Accent: ');
    print($row['first_accent']);
    print('</p>');
    print('</td>');
    print('<td>');
    print('<p>First Accent Percentage ');
    print($row['first_accent_percentage'] . '%');
    print('</p>');
    print('</td>');
    print('</tr>');
    print('<tr>');
    print('<td>');
    print('<p>Second Accent: ');
    print($row['second_accent']);
    print('</p>');
    print('</td>');
    print('<td>');
    print('<p>Second Accent Percentage ');
    print($row['second_accent_percentage'] . '%');
    print('</p>');
    print('</td>');
    print('</tr>');
    print('<tr>');
    print('<td>');
    print('<p>third Accent: ');
    print($row['third_accent']);
    print('</p>');
    print('</td>');
    print('<td>');
    print('<p>Third Accent Percentage ');
    print($row['third_accent_percentage'] . '%');
    print('</p>');
    print('</td>');
    print('</tr>');
    print('</table>');
    print('<br>');
    print('<p>The sentences that you said.');
    print('<div style="border: 1px solid #333; width: 600px;">');
    print($row['english_sentence']);
    print('</div>');
}
?>
</body>
</html>  