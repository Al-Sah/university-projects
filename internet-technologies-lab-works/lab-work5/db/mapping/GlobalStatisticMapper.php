<?php

use models\GlobalStatistic;
require_once "models/GlobalStatistic.php";

class GlobalStatisticMapper
{
    /**
     * @throws PDOException
     */
    public static function get(PDO $pdo): GlobalStatistic {

        $res = $pdo->query(self::statements["traffic"])->fetch(PDO::FETCH_ASSOC);
        $out_traffic = $res['out'];
        $in_traffic = $res['in'];

        $time = $pdo->query(self::statements["time"])->fetch(PDO::FETCH_OBJ)->minutes;
        $sessions = $pdo->query(self::statements["sessions"])->fetch(PDO::FETCH_OBJ)->count;
        $clients = $pdo->query(self::statements["clients"])->fetch(PDO::FETCH_OBJ)->count;
        $max_in = $pdo->query(self::statements["in_traffic"])->fetch(PDO::FETCH_OBJ)->client_id;
        $max_out = $pdo->query(self::statements["out_traffic"])->fetch(PDO::FETCH_OBJ)->client_id;

        return new GlobalStatistic($clients, $sessions, $time, $in_traffic, $out_traffic, $max_in, $max_out);
    }

    private const statements = array(
        "traffic" => "select sum(in_traffic) `in`, sum(out_traffic) `out` from seanse",
        "time" => "select sum(timestampdiff(minute, stop, start )) `minutes` from seanse",
        "sessions" => "select count(id) `count` from seanse",
        "clients" => "select count(id) `count` from client",
        "in_traffic" => "select client_id from seanse where in_traffic = (select max(in_traffic)from seanse)",
        "out_traffic" => "select client_id from seanse where out_traffic = (select max(out_traffic)from seanse)"
    );


}