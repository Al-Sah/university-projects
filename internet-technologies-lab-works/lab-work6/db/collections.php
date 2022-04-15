<?php

require_once "ConnectionFactory.php";

try{
    $res = ConnectionFactory::getCollections();
    $clients_collection = $res[0];
    $seances_collection = $res[1];
}catch(Exception $e) {
    require_once "ui-components.php";
    print_error_page(500, "Exception: ".$e->getMessage());
}