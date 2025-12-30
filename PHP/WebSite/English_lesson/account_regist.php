<?php 
require 'DbAccess.php';
session_start();
if ($_SERVER['REQUEST_METHOD'] === 'POST') {
    $username = filter_input(INPUT_POST, 'regist_username');
    $password = filter_input(INPUT_POST, 'regist_password');
    print('username was ' . $username);
    print('password was ' . $password);
    if (trim($username) === '' || trim($password) === '') {
        print('<p>You didn\'t input username or password!</p>');
    }
    $pdo = new DbAccess();
    $result = $pdo->insertUserInfo($username, $password);
    if(!$result) {
        print('<p>Error happend!</p>');
        return;
    }
}
?>