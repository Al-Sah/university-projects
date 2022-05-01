<?php

namespace lib\db\models;


use DateTime;

class ClientStatistic
{

    public int $clientId;
    public int $sessions;
    public int $secondsOnline;

    /**
     * The sum of input and output traffic of client sessions.
     */
    public int $outTraffic;
    public int $inTraffic;

    function __construct(int $id, int $in, int $out, int $sessions, int $secondsOnline)
    {
        $this->clientId = $id;
        $this->inTraffic = $in;
        $this->outTraffic = $out;
        $this->sessions = $sessions;
        $this->secondsOnline = $secondsOnline;
    }

    public function timeToFormat($format = "%a days, %h hours, %i minutes and %s seconds"): string {
        return (new DateTime('@0'))->diff((new DateTime("@$this->secondsOnline")))->format($format);
    }
}