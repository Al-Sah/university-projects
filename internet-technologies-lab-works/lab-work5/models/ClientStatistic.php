<?php

class ClientStatistic{

    private int $client_id;
    public string $time_online;
    public int $out_traffic_sum;
    public int $in_traffic_sum;
    public int $sessions;
    private PDO $pdo;

    function __construct($id, PDO $pdo) {
        $this->client_id = $id;
        $this->pdo = $pdo;
        $select_statements = array(
            "traffic" => "select sum(in_traffic) `in`, sum(out_traffic) `out` from seanse where client_id = :client_id",
            "time" => "select sum(timestampdiff(second, stop, start )) `seconds` from seanse where client_id = :client_id",
            "count" => "select count(id) `count` from seanse where client_id = :client_id"
        );

        try{
            $res = $this->execute_statement($select_statements['traffic'], PDO::FETCH_ASSOC);
            $this->out_traffic_sum = $res['out'];
            $this->in_traffic_sum = $res['in'];

            $res = $this->execute_statement($select_statements['time'], PDO::FETCH_OBJ)->seconds;
            $this->time_online = ClientStatistic::seconds_to_time($res);

            $this->sessions = $this->execute_statement($select_statements['count'], PDO::FETCH_OBJ)->count;
        }catch (PDOException $exception){
            print_error_page(500, "<h2> Error: ".$exception->getMessage()."</h2>");
            exit;
        }
    }

    private function execute_statement($statement, $fetch_mode){
        $sth = $this->pdo->prepare($statement);
        $sth->execute(array('client_id' => $this->client_id));
        return $sth->fetch($fetch_mode);
    }

    private static function seconds_to_time($seconds): string{
        return (new DateTime('@0'))
            ->diff((new DateTime("@$seconds")))
            ->format('%a days, %h hours, %i minutes and %s seconds');
    }
}