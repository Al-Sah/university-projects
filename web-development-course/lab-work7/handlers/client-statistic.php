<?php

    require_once '../vendor/autoload.php';
    require_once '../ui-components.php';
    use lib\db\ClientsRepository;
    use lib\db\ClientStatisticDAO;
    use lib\db\SessionsRepository;

    $clientId = null;
    if(array_key_exists("id", $_GET) && is_numeric($_GET['id'])){
        $clientId = $_GET['id'];
    }
    if($clientId == null){
        printError(400, "User id must be a number > 0");
        exit;
    }

    try{
        $client = (new ClientsRepository())->getById($clientId);
        $statistic = ClientStatisticDAO::get($clientId);
        $sessions =  (new SessionsRepository())->getAllWhereClientId($clientId);
    } catch (Exception $e){
        printError(400);
        exit;
    }
?>


<?php
    echo <<< CLIENT
        <div class="shadow-sm p-3 mb-5 bg-body rounded">
            <div class="d-flex w-100 justify-content-between ">
                <h5 class="mb-1">$client->name</h5>
                <small> Balance: $client->balance</small>
            </div>
            <p class="mb-1"> $client->login : $client->ip </p>
        </div>
    CLIENT;

    printClientStatistic($statistic);
    printSessions($sessions);
?>
