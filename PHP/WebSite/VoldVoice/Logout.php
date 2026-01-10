<?php
session_start();
session_destroy();
header('Location: lesson_login.php');
exit;
?>