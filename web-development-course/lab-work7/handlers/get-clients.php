<?php

    header("Content-Type: application/json; charset=UTF-8");
    require_once '../vendor/autoload.php';
    use lib\db\ClientsRepository;

    $repository = new ClientsRepository();
    $clients = null;

    $filter = "";
    if (isset($_GET['filter'])) {
        $filter = $_GET['filter'];
    }

    $clients = match ($filter) {
        'cf2' => $repository->getAllWhereBalanceGreater(0),
        'cf3' => $repository->getAllWhereBalanceLess(1),
        default => $repository->getAll(),
    };

    echo json_encode($clients);