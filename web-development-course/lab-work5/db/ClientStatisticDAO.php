<?php

require_once "models/ClientStatistic.php";
require_once "mapping/ClientStatisticMapper.php";
require_once "ConnectionFactory.php";

use models\ClientStatistic;

class ClientStatisticDAO{

    public static function get($clientId) : ClientStatistic{
        return ClientStatisticMapper::get($clientId);
    }
}