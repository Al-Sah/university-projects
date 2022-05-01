<?php

namespace lib\db;

use lib\db\mapping\ClientStatisticMapper;
use lib\db\models\ClientStatistic;

class ClientStatisticDAO{

    public static function get($clientId) : ClientStatistic{
        return ClientStatisticMapper::get($clientId);
    }
}