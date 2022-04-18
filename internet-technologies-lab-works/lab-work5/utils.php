<?php

function check_filter(): string {
    if (isset($_GET['clients-filter'])) {
        switch ($_GET['clients-filter']){
            case 'cf2':
                return ' (balance > 0)';
            case 'cf3':
                return ' (balance <= 0)';
        }
    }
    return '(no filters)';
}

function get_clients(ClientsRepository $clientsRepository): array{

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

function get_client_id(): int {
    if(array_key_exists("id", $_GET)){
        if(!is_numeric($_GET['id'])){
            print_error_page(400, "User id must be a number > 0");
            exit;
        } else{
            return $_GET['id'];
        }
    }
    print_error_page(400, "key id was not sent");
    exit;
}