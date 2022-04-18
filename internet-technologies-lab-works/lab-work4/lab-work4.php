
<head>
    <meta charset="UTF-8">
    <title>The best</title>
</head>
<body>

    <h3>Написать скрипт подсчета количества показов страницы. </h3>
    Количество посещений хранить в текстовом файле.
    Использовать функции для работы с файлами (например fread, fwrite, fclose...).
    <br>

    <?php
        $filename = "count.txt";
        if (!file_exists($filename)) {
            touch($filename);
        }

        $file = file($filename);
        $count = implode($file);
        $count++;
        $countFile = fopen($filename,"w");
        fputs($countFile, $count);
        fclose($countFile);
        echo "<p> Просмотров: $count </p>";
    ?>

</body>