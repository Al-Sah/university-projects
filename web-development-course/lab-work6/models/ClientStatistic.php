<?php

namespace models;

use DateTime;

class ClientStatistic
{

    public string $clientId;
    public int $sessions;
    public int $secondsOnline;

    /**
     * The sum of input and output traffic of client sessions.
     */
    public int $outTraffic;
    public int $inTraffic;

    public int $summaryPrice;

    function __construct(string $id, int $in, int $out, int $sessions, int $secondsOnline, int $summaryPrice)
    {
        $this->clientId = $id;
        $this->inTraffic = $in;
        $this->outTraffic = $out;
        $this->sessions = $sessions;
        $this->secondsOnline = $secondsOnline;
        $this->summaryPrice = $summaryPrice;
    }

    public function timeToFormat($format = "%a days, %h hours, %i minutes and %s seconds"): string {
        return (new DateTime('@0'))->diff((new DateTime("@$this->secondsOnline")))->format($format);
    }
}