<?php

namespace lib\db\mapping;

use lib\db\models\Client;

class ClientMapper{

    public static function getClient($dbRow): Client{
        return new Client($dbRow->id, $dbRow->name, $dbRow->login, $dbRow->ip, $dbRow->balance);
    }
}