<?php

namespace lib\db;
use lib\db\models\GlobalStatistic;
use lib\db\mapping\GlobalStatisticMapper;

class GlobalStatisticDAO{

    public static function get() : GlobalStatistic{
        return GlobalStatisticMapper::get();
    }
}