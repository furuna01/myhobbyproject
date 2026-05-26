<?php
session_start();
session_destroy();
header('Location: muscle_login.php');
exit;
?>