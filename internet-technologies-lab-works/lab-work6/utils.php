<?php


use MongoDB\BSON\ObjectId;
use MongoDB\Collection;


require_once "PageBuilder.php";

/**
 * @throws Exception
*/
function getClients(Collection $clients) : array{
    return match (PageBuilder::getFilterValue()) {
        'cf2' => $clients->find(['balance' => ['$gt' => 0]])->toArray(),
        'cf3' => $clients->find(['balance' => ['$lt' => 0]])->toArray(),
        'cf4' => $clients->find(
            ['balance' => array(
                '$gt' => intval($_GET['number1'] - 1),
                '$lt' => intval($_GET['number2'] + 1))
            ]
        )->toArray(),
        default => $clients->find()->toArray(),
    };
}


/**
 * @throws Exception
 */
function getClientId(): ObjectID {
    if(array_key_exists("id", $_GET)){
        return new ObjectID($_GET['id']);
    }
    throw new Exception("key id was not found"); // FIXME
}


function getClient(ObjectID $client_id, Collection $collection){

    try{
        $client = $collection->findOne(['_id' => $client_id]);
        if($client == null){
            printErrorPage(data: "Client with id ".$_GET['id']." not found"); // FIXME
        }
        return $client;
    }catch(Exception $e) {
        printErrorPage(500, "<h2> Error: ".$e->getMessage()."</h2>"); // FIXME
    }
}