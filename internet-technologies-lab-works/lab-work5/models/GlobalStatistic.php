<?php

namespace models;

class GlobalStatistic{

    /**
     * Number of clients and sessions stored in DB
     */
    public int $clients;
    public int $sessions;

    /**
     * time in minutes. Sum of duration all sessions
     */
    public int $time_online;

    /**
     * Sum of out and in traffic of all sessions
     */
    public int $out_traffic_sum;
    public int $in_traffic_sum;

    /**
     * client (id) with maximal in and out traffic
     */
    public int $max_out_traffic_client;
    public int $max_in_traffic_client;

    function __construct($clients, $sessions, $time_online, $sum_in, $sum_out, $max_in, $max_out)
    {
        $this->clients = $clients;
        $this->sessions = $sessions;
        $this->time_online = $time_online;

        $this->in_traffic_sum = $sum_in;
        $this->out_traffic_sum = $sum_out;

        $this->max_out_traffic_client = $max_out;
        $this->max_in_traffic_client = $max_in;
    }
}