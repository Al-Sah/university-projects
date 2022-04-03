<?php

class GlobalStatistic{

    public int $clients;
    public int $sessions;

    public string $time_online;
    public int $out_traffic_sum;
    public int $in_traffic_sum;

    public int $max_out_traffic_client;
    public int $max_in_traffic_client;


    function __construct($pdo) {

        try{
            $res = $pdo->query("select sum(in_traffic) `in`, sum(out_traffic) `out` from seanse")
                ->fetch(PDO::FETCH_ASSOC);
            $this->out_traffic_sum = $res['out'];
            $this->in_traffic_sum = $res['in'];

            $this->time_online = $pdo->query("select sum(timestampdiff(minute, stop, start )) `minutes` from seanse")
                ->fetch(PDO::FETCH_OBJ)
                ->minutes;

            $this->sessions = $pdo->query("select count(id) `count` from seanse")->fetch(PDO::FETCH_OBJ)->count;
            $this->clients = $pdo->query("select count(id) `count` from client")->fetch(PDO::FETCH_OBJ)->count;

            $this->max_in_traffic_client = $pdo
                ->query("select client_id from seanse where in_traffic = (select max(in_traffic)from seanse)")
                ->fetch(PDO::FETCH_OBJ)
                ->client_id;

            $this->max_out_traffic_client = $pdo
                ->query("select client_id from seanse where out_traffic = (select max(out_traffic)from seanse)")
                ->fetch(PDO::FETCH_OBJ)
                ->client_id;

        }catch (PDOException $exception){
            print_error_page(500, "<h2> Error: ".$exception->getMessage()."</h2>");
            exit;
        }
    }

}