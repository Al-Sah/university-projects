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
    public int $timeOnline;

    /**
     * Sum of out and in traffic of all sessions
     */
    public int $outTraffic;
    public int $inTraffic;

    /**
     * client (id) with maximal in and out traffic
     */
    public string $maxOut;
    public string $maxIn;

    public int $summaryPrice;

    function __construct(
        int $clients = 0,
        int $sessions = 0,
        string $maxIn = "",
        string $maxOut = "",
        int $timeOnline = 0,
        int $sumIn = 0,
        int $sumOut = 0,
        int $summaryPrice = 0){


        $this->clients = $clients;
        $this->sessions = $sessions;
        $this->timeOnline = $timeOnline;

        $this->inTraffic = $sumIn;
        $this->outTraffic = $sumOut;

        $this->maxOut = $maxOut;
        $this->maxIn = $maxIn;

        $this->summaryPrice = $summaryPrice;
    }
}