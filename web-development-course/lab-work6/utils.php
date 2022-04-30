<?php


use models\ClientStatistic;
use models\GlobalStatistic;
use MongoDB\BSON\ObjectId;
use MongoDB\Collection;
use MongoDB\Driver\Exception\RuntimeException as DriverRuntimeException;
use MongoDB\Exception\InvalidArgumentException;
use MongoDB\Exception\UnsupportedException;


require_once "PageBuilder.php";
require_once "models/ClientStatistic.php";

/**
 * @throws UnsupportedException if options are not supported by the selected server
 * @throws InvalidArgumentException for parameter/option parsing errors
 * @throws DriverRuntimeException for other driver errors (e.g. connection errors)
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

function getClientId(): ObjectID {
    if(array_key_exists("id", $_GET)){
        return new ObjectID($_GET['id']);
    }
    throw new InvalidArgumentException("key id was not found");
}

/**
 * @throws UnsupportedException if options are not supported by the selected server
 * @throws InvalidArgumentException for parameter/option parsing errors
 * @throws DriverRuntimeException for other driver errors (e.g. connection errors)
 * @throws ClientNotFountException
*/
function getClient(ObjectID $client_id, Collection $collection): object{
    $client = $collection->findOne(['_id' => $client_id]);
    if($client == null || count($client) == 0){
        throw new ClientNotFountException("Client with id ".$_GET['id']." not found");
    }
    return $client;
}


/**
 * @throws Exception if DataTime creation fails
 */
function getClientStatistic(ObjectID $clientId, Collection $sessions) : ClientStatistic{

    $clientSessions = $sessions->find(['client' => $clientId])->toArray();
    if(count($clientSessions) == 0){
        return new ClientStatistic($clientId->serialize(), 0,0,0,0,0);
    }
    $inTraffic = 0;
    $outTraffic = 0;
    $price = 0;
    $time = 0;

    foreach ($clientSessions as $session){
        $inTraffic += $session->in;
        $outTraffic += $session->out;
        $price += $session->price;
        $time += (new DateTime($session->end))->getTimestamp() - (new DateTime($session->start))->getTimestamp();
    }
    return new ClientStatistic($clientId->serialize(), $inTraffic,$outTraffic,count($clientSessions),$time,$price);
}


/**
 * @throws Exception
 */
function getGlobalStatistic(int $clients, Collection $sessionsCollection) : GlobalStatistic{

    $sessions = $sessionsCollection->find()->toArray();
    if(count($sessions) == 0){
        return new GlobalStatistic($clients);
    }

    $statistic = new GlobalStatistic($clients, count($sessions), $sessions[0]->client, $sessions[0]->client);
    $maxIn = $sessions[0]->in;
    $maxOut = $sessions[0]->out;
    foreach ($sessions as $session){
        $statistic->inTraffic += $session->in;
        $statistic->outTraffic += $session->out;
        if($session->in > $maxIn){
            $maxIn = $session->in;
            $statistic->maxIn = $session->client;
        }
        if($session->out > $maxOut){
            $maxOut = $session->out;
            $statistic->maxOut = $session->client;
        }
        $statistic->summaryPrice += $session->price;
        $statistic->timeOnline += (new DateTime($session->end))->getTimestamp() - (new DateTime($session->start))->getTimestamp();
    }
    return $statistic;
}