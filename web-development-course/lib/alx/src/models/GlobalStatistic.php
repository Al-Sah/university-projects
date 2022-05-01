<?php

namespace lib\db\models;

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
    public int $maxOut;
    public int $maxIn;

    function __construct(int $clients, int $sessions, int $timeOnline, int $sumIn, int $sumOut, int $maxIn, int $maxOut)
    {
        $this->clients = $clients;
        $this->sessions = $sessions;
        $this->timeOnline = $timeOnline;

        $this->inTraffic = $sumIn;
        $this->outTraffic = $sumOut;

        $this->maxOut = $maxOut;
        $this->maxIn = $maxIn;
    }
}