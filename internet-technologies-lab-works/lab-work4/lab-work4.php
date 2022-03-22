
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
        $file = file("count.txt");
        $count = implode($file);
        $count++;
        $countFile = fopen("count.txt","w");
        fputs($countFile, $count);
        fclose($countFile);
        echo "<p> Просмотров: $count </p>";
    ?>

</body>