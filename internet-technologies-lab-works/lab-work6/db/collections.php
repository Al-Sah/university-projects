<?php

require_once "ConnectionFactory.php";

try{
    $res = ConnectionFactory::getCollections();
    $clientsCollection = $res[0];
    $sessionsCollection = $res[1];
}catch(Exception $e) {
    require_once "ui-components.php";
    printErrorPage(500, "Exception: ".$e->getMessage());
}