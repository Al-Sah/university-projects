<?php

class ClientStatistic
{
    private int $client_id;
    public string $time_online;
    public int $out_traffic_sum;
    public int $in_traffic_sum;
    public int $sessions_number;


    function __construct($id, $pdo) {
        $this->client_id = $id;
        try{
            $res = $pdo
                ->query("select sum(in_traffic) `in`, sum(out_traffic) `out` from seanse where client_id = $this->client_id")
                ->fetch(PDO::FETCH_ASSOC);

            $this->out_traffic_sum = $res['out'];
            $this->in_traffic_sum = $res['in'];

            $seconds = $pdo
                ->query("select sum(timestampdiff(second, stop, start )) `seconds` from seanse where client_id = $this->client_id")
                ->fetch(PDO::FETCH_OBJ)
                ->seconds;
            $this->time_online = ClientStatistic::seconds_to_time($seconds);

            $this->sessions_number = $pdo
                ->query("select count(id) `count` from seanse where client_id = $this->client_id")
                ->fetch(PDO::FETCH_OBJ)
                ->count;

        }catch (PDOException $exception){
            print_error_page(500, "<h2> Error: ".$exception->getMessage()."</h2>");
            exit;
        }
    }

    private static function seconds_to_time($seconds): string
    {
        return (new DateTime('@0'))
            ->diff((new DateTime("@$seconds")))
            ->format('%a days, %h hours, %i minutes and %s seconds');
    }
}