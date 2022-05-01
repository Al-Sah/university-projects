<?php

namespace lib\db\models;

use DateTime;

class Session{

    public DateTime $start;
    public DateTime $stop;

    /**
     * in, out: traffic usage during session;
     */
    public int $in;
    public int $out;
    public int $clientId;

    public function __construct(DateTime $start, DateTime $stop, int $in, int $out, int $clientId)
    {
        $this->start = $start;
        $this->stop = $stop;
        $this->in = $in;
        $this->out = $out;
        $this->clientId = $clientId;
    }

}