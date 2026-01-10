<?php
session_start();
session_destroy();
header('Location: vold_voice_login.php');
exit;
?>