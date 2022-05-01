<?php

namespace lib\db\mapping;

use lib\db\ConnectionFactory;
use lib\db\models\ClientStatistic;
use PDO;
use PDOException;

class ClientStatisticMapper{

    /**
     * @throws PDOException
     */
    public static function get($clientId): ClientStatistic {

        $pdo = ConnectionFactory::getPDO();

        $sessions = self::executeStatement($pdo, $clientId, "count")->count;
        if($sessions == 0){
            return new ClientStatistic($clientId, 0, 0, 0, 0);
        }

        $traffic = self::executeStatement($pdo, $clientId, "traffic", PDO::FETCH_ASSOC);
        $outTraffic = $traffic['out'];
        $inTraffic = $traffic['in'];
        $timeOnline = self::executeStatement($pdo, $clientId, "time")->seconds;


        return new ClientStatistic($clientId, $inTraffic, $outTraffic, $sessions, $timeOnline);
    }

    private const statements = array(
        "traffic" => "select sum(in_traffic) `in`, sum(out_traffic) `out` from seanse where client_id = :id",
        "time" => "select sum(timestampdiff(second, stop, start )) `seconds` from seanse where client_id = :id",
        "count" => "select count(id) `count` from seanse where client_id = :id"
    );

    private static function executeStatement($pdo, $id, $statementName, $fetchMode = PDO::FETCH_OBJ){
        $statement = $pdo->prepare(self::statements[$statementName]);
        $statement->execute(array('id' => $id));
        return $statement->fetch($fetchMode);
    }
}