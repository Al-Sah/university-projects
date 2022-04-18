<?php

namespace models;

use DateTime;

class ClientStatistic
{

    public int $client_id;
    public int $sessions;
    public int $seconds_online;

    /**
     * The sum of input and output traffic of client sessions.
     */
    public int $out_traffic_sum;
    public int $in_traffic_sum;

    function __construct($id, $in, $out, $sessions, $seconds_online)
    {
        $this->client_id = $id;
        $this->in_traffic_sum = $in;
        $this->out_traffic_sum = $out;
        $this->sessions = $sessions;
        $this->seconds_online = $seconds_online;
    }

    public function timeToFormat($format = "%a days, %h hours, %i minutes and %s seconds"): string {
        return (new DateTime('@0'))->diff((new DateTime("@$this->seconds_online")))->format($format);
    }
}