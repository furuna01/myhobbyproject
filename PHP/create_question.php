<!DOCTYPE html>
<html lang="ja">
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>瞬間英作文問題登録画面</title>
        <style type="text/css">
            body {
                background-color: skyblue;
            }
            input[type="textarea"] {
                width: 400pt;
                height: 40pt;
            }
            div.sentence {
                border: ridge 3px;
            }
        </style>
    </head>
    <body>
        <h1>瞬間英作文問題登録画面</h1>
        <form action = "create_question.php" method = "POST">
            <p>日本語</p>
            <input type = "textarea" class = "Japanese_sentence" name ="Japanese_sentence">
            <p>英語</p>
            <input type = "textarea" class = "English_sentence" name ="English_sentence">
            <input type = "submit" value ="作成">
            <h2>作成した問題一覧</h2>
            <?php
                require_once("./const.php");
                require_once("./DBAccess.php");
                $DataBase = new DBAccess();
                if($_SERVER["REQUEST_METHOD"] == "POST") {
                    //データベースにフォームのデータを登録する
                    $japanese = $_POST["Japanese_sentence"];
                    $english = $_POST["English_sentence"];
                    $DataBase->registerEnglishSentences($english, $japanese, TABLE_NAME);
                }
                $sentences = $DataBase->getAllTableData(TABLE_NAME);
                foreach ($sentences as $sentence) {
                    echo '<div class="sentence">';
                    echo "<p>{$sentence["japanese"]}</p>";
                    echo "<p>{$sentence["english"]}</p>";
                    echo '</div>';
                }
                $DataBase->CloseDataBase();
            ?>
         </form>
    </body>
</html>