<?php

use models\Session;

class SessionMapper{

    /**
     * @throws Exception
     */
    public static function getSession($dbRow) : Session{

        return new Session(
            new DateTime($dbRow->start),
            new DateTime($dbRow->stop),
            $dbRow->in_traffic,
            $dbRow->out_traffic,
            $dbRow->client_id
        );
    }
}