<?php

use MongoDB\BSON\ObjectId;
use MongoDB\Collection;
use MongoDB\InsertOneResult;

function fill_collections(Collection $clients_collection, Collection $seances_collection){

    $clients_collection->deleteMany([]);
    $seances_collection->deleteMany([]);

    for ($i = 0; $i < 10; $i++){
        $res = create_client_document($clients_collection);
        for ($j = 0; $j < 10; $j++){
              create_seance_document($seances_collection, $res->getInsertedId());
        }
    }
}

function create_client_document(Collection $collection): InsertOneResult
{
    return $collection->insertOne(
        [
            'login' => 'user-' . uniqid(),
            'password' => password_hash(uniqid(),PASSWORD_DEFAULT),
            'ip' => sprintf("%d.%d.%d.%d", rand(0, 255), rand(0, 255), rand(0, 255), rand(0, 255)),
            'balance' => rand(-1000, 5000),
            'messages' => ["message1", "message2", "Message3", "Message4"]
        ]
    );
}


function create_seance_document(Collection $collection, ObjectId $clientId){

    $in_traffic = rand(32, 100000);
    $out_traffic = rand(32, 100000);
    $price = ($in_traffic + $out_traffic) / 10000;

    $collection->insertOne(
        [
            'start' => date('Y/m/d h:i:s a', time() - rand(60, 86400)),
            'end' => date('Y/m/d h:i:s a', time()),
            'in' => $in_traffic,
            'out' => $out_traffic,
            'ip' => sprintf("%d.%d.%d.%d", rand(0, 255), rand(0, 255), rand(0, 255), rand(0, 255)),
            'price' => $price,
            'client' => $clientId
        ]
    );
}