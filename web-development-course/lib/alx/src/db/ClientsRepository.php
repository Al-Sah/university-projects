<?php
namespace lib\db;


use lib\db\mapping\ClientMapper;
use lib\db\models\Client;
use PDO;
use PDOException;

class ClientsRepository{

    private PDO $pdo;
    public function __construct(){
        $this->pdo = ConnectionFactory::getPDO();
    }

    public function getById($id) : Client{
        $sth = $this->pdo->prepare("SELECT * FROM `client` where id = :id");
        $sth->execute(array('id' => $id));
        $res = $sth->fetch(PDO::FETCH_OBJ);
        if(!$res){
            throw new PDOException("Client with id $id not found");
        }
        return ClientMapper::getClient($res);
    }

    public function getAll() : array {
        $clients = $this->pdo->query("SELECT * FROM `client`")->fetchAll(PDO::FETCH_OBJ);
        if(count($clients) == 0){
            return array();
        }
        return $this->collect($clients);
    }

    public function getAllWhereBalanceGreater(int $value) : array {
        $sth = $this->pdo->prepare("SELECT * FROM `client` where balance > :balance");
        $sth->execute(array('balance' => $value));
        $clients = $sth->fetchAll(PDO::FETCH_OBJ);
        if(count($clients) == 0){
            return array();
        }
        return $this->collect($clients);
    }

    public function getAllWhereBalanceLess(int $value) : array {
        $sth = $this->pdo->prepare("SELECT * FROM `client` where balance < :balance");
        $sth->execute(array('balance' => $value));
        $clients = $sth->fetchAll(PDO::FETCH_OBJ);

        if(count($clients) == 0){
            return array();
        }
        return $this->collect($clients);
    }

    private function collect(array $clients) : array{
        $result = array();
        foreach ($clients as $client){
            $result[] = ClientMapper::getClient($client);
        }
        return $result;
    }

}