<?php

require_once '../vendor/autoload.php'; // Composer autoload
require_once 'ConnectionFactory.php';

use MongoDB\BSON\ObjectId;
use MongoDB\Collection;
use MongoDB\InsertOneResult;

function fillCollections(Collection $clients, Collection $sessions): void {

    for ($i = 0; $i < 2; $i++){
        $res = createClientDocument($clients);
        for ($j = 0; $j < 5; $j++){
              createSeanceDocument($sessions, $res->getInsertedId());
        }
    }
}

function createClientDocument(Collection $collection): InsertOneResult {

    $result =  $collection->insertOne(
        [
            'login' => 'user-' . uniqid(),
            'password' => password_hash(uniqid(),PASSWORD_DEFAULT),
            'ip' => sprintf("%d.%d.%d.%d", rand(0, 255), rand(0, 255), rand(0, 255), rand(0, 255)),
            'balance' => rand(-1000, 5000),
            'messages' => ["message1", "message2", "Message3", "Message4"]
        ]
    );
    echo " ******* New client: ".$result->getInsertedId()."\n";
    return $result;
}


function createSeanceDocument(Collection $collection, ObjectId $clientId): void {

    $inTraffic = rand(32, 100000);
    $outTraffic = rand(32, 100000);
    $price = ($inTraffic + $outTraffic) / 10000;

    $result = $collection->insertOne(
        [
            'start' => date('Y/m/d h:i:s a', time() - rand(60, 86400)),
            'end' => date('Y/m/d h:i:s a', time()),
            'in' => $inTraffic,
            'out' => $outTraffic,
            'ip' => sprintf("%d.%d.%d.%d", rand(0, 255), rand(0, 255), rand(0, 255), rand(0, 255)),
            'price' => $price,
            'client' => $clientId
        ]
    );
    echo "New session: ".$result->getInsertedId()."\n";
}


try{
    $res = ConnectionFactory::getCollections();
    $clients = $res[0];
    $sessions = $res[1];
}catch(Exception $e) {
    die("Failed to get collections");
}

fillCollections($clients, $sessions);