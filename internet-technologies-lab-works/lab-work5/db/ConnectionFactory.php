<?php

class ConnectionFactory{

    private static string $dsn = 'mysql:host=localhost;dbname=itech_labs';
    private static string $username = "alx";
    private static string $password = "zzz";

    /**
     * @throws PDOException if the attempt to connect to the requested database fails.
    */
    public static function getPDO(): PDO{
        $pdo = new PDO(self::$dsn, self::$username, self::$password);
        $pdo->setAttribute(PDO::ATTR_ERRMODE,PDO::ERRMODE_EXCEPTION);
        return $pdo;
    }

}