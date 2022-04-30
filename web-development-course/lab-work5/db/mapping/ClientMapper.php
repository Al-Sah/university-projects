<?php

use models\Client;

class ClientMapper{

    public static function getClient($dbRow): Client{
        return new Client($dbRow->id, $dbRow->name, $dbRow->login, $dbRow->ip, $dbRow->balance);
    }
}