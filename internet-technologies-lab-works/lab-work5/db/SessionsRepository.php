<?php

require_once "ConnectionFactory.php";
require_once "mapping/SessionMapper.php";
require_once "models/Session.php";

class SessionsRepository
{
    private PDO $pdo;
    public function __construct(){
        $this->pdo = ConnectionFactory::getPDO();
    }

    /**
     * @throws Exception
     */
    public function getAllWhereClientId($value) : array {
        $sth = $this->pdo->prepare("SELECT * FROM `seanse` where client_id > :id");
        $sth->execute(array('id' => $value));
        $sessions = $sth->fetchAll(PDO::FETCH_OBJ);
        if(count($sessions) == 0){
            return array();
        }
        return $this->collect($sessions);
    }

    /**
     * @throws Exception
     */
    private function collect(array $sessions) : array{
        $result = array();
        foreach ($sessions as $session){
            $result[] = SessionMapper::getSession($session);
        }
        return $result;
    }
}