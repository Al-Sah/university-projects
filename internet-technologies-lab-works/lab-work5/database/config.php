<?php

    $dsn = 'mysql:host=localhost;dbname=itech_labs';
    $username = "alx";
    $password = "zzz";

try{
    $pdo = new PDO($dsn, $username, $password);
}catch(PDOException $e) {
    http_response_code(500);
    print_error_page(500, "Connection failed: ".$e->getMessage());
    phpinfo();
    die();
}