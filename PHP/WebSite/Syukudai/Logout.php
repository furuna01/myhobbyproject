<?php
session_start();
session_destroy();
header('Location: syukudai_login.php');
exit;
?>