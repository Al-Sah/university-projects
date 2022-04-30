<?php

require_once "models/GlobalStatistic.php";
require_once "mapping/GlobalStatisticMapper.php";
require_once "ConnectionFactory.php";

use models\GlobalStatistic;

class GlobalStatisticDAO{

    public static function get() : GlobalStatistic{
        return GlobalStatisticMapper::get();
    }
}