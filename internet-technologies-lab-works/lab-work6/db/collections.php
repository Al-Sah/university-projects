<?php

use MongoDB\Collection;

require_once "ConnectionFactory.php";

try{
    $res = ConnectionFactory::getCollections();

    /**
     * @var Collection
     */
    $clientsCollection = $res[0];
    /**
     * @var Collection
     */
    $sessionsCollection = $res[1];
}catch(Exception $e) {
    require_once "PageBuilder.php";
    PageBuilder::printErrorPage(500, "Exception: ".$e->getMessage());
}