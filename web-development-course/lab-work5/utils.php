<?php

use lib\db\ClientsRepository;

function checkFilter(): string {
    $filter ="";
    if (isset($_GET['clients-filter'])) {
        $filter = $_GET['clients-filter'];
    }
    return match ($filter) {
        'cf2' => ' (balance > 0)',
        'cf3' => ' (balance <= 0)',
        default => '(no filters)',
    };
}

function getClients(ClientsRepository $clientsRepository): array{

    $filter = "";
    if (isset($_GET['clients-filter'])) {
        $filter = $_GET['clients-filter'];
    }
    return match ($filter) {
        'cf2' => $clientsRepository->getAllWhereBalanceGreater(0),
        'cf3' => $clientsRepository->getAllWhereBalanceLess(1),
        default => $clientsRepository->getAll(),
    };
}

function getClientId(): int {
    if(array_key_exists("id", $_GET)){
        if(!is_numeric($_GET['id'])){
            printErrorPage(400, "User id must be a number > 0");
            exit;
        } else{
            return $_GET['id'];
        }
    }
    printErrorPage(400, "key id was not sent");
    exit;
}