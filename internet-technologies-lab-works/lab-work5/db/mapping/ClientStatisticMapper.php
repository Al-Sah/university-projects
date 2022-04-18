<?php

use models\ClientStatistic;

class ClientStatisticMapper{

    /**
     * @throws PDOException
     */
    public static function get($client_id): ClientStatistic {

        $pdo = ConnectionFactory::getPDO();

        $sessions = self::execute_statement($pdo, $client_id, "count")->count;
        if($sessions == 0){
            return new ClientStatistic($client_id, 0, 0, 0, 0);
        }

        $traffic = self::execute_statement($pdo, $client_id, "traffic", PDO::FETCH_ASSOC);
        $out_traffic_sum = $traffic['out'];
        $in_traffic_sum = $traffic['in'];
        $time_online = self::execute_statement($pdo, $client_id, "time")->seconds;


        return new ClientStatistic($client_id, $in_traffic_sum, $out_traffic_sum, $sessions, $time_online);
    }

    private const statements = array(
        "traffic" => "select sum(in_traffic) `in`, sum(out_traffic) `out` from seanse where client_id = :client_id",
        "time" => "select sum(timestampdiff(second, stop, start )) `seconds` from seanse where client_id = :client_id",
        "count" => "select count(id) `count` from seanse where client_id = :client_id"
    );

    private static function execute_statement($pdo, $id, $statement_name, $fetch_mode = PDO::FETCH_OBJ){
        $statement = $pdo->prepare(self::statements[$statement_name]);
        $statement->execute(array('client_id' => $id));
        return $statement->fetch($fetch_mode);
    }
}