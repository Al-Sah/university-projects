<?php

namespace lib\db\mapping;

use lib\db\ConnectionFactory;
use lib\db\models\GlobalStatistic;
use PDO;
use PDOException;

class GlobalStatisticMapper
{
    /**
     * @throws PDOException
     */
    public static function get(): GlobalStatistic {

        $pdo = ConnectionFactory::getPDO();

        $trafficSums = $pdo->query(self::statements["traffic"])->fetch(PDO::FETCH_ASSOC);
        $SumOut = $trafficSums['out'];
        $sumIn = $trafficSums['in'];

        $time = $pdo->query(self::statements["time"])->fetch(PDO::FETCH_OBJ)->minutes;
        $sessions = $pdo->query(self::statements["sessions"])->fetch(PDO::FETCH_OBJ)->count;
        $clients = $pdo->query(self::statements["clients"])->fetch(PDO::FETCH_OBJ)->count;
        $maxIn = $pdo->query(self::statements["inTraffic"])->fetch(PDO::FETCH_OBJ)->client_id;
        $maxOut = $pdo->query(self::statements["outTraffic"])->fetch(PDO::FETCH_OBJ)->client_id;

        return new GlobalStatistic($clients, $sessions, $time, $sumIn, $SumOut, $maxIn, $maxOut);
    }

    private const statements = array(
        "traffic" => "select sum(in_traffic) `in`, sum(out_traffic) `out` from seanse",
        "time" => "select sum(timestampdiff(minute, stop, start )) `minutes` from seanse",
        "sessions" => "select count(id) `count` from seanse",
        "clients" => "select count(id) `count` from client",
        "inTraffic" => "select client_id from seanse where in_traffic = (select max(in_traffic)from seanse)",
        "outTraffic" => "select client_id from seanse where out_traffic = (select max(out_traffic)from seanse)"
    );


}