<?php

    require_once __DIR__ . '/vendor/autoload.php';
    use lib\db\ClientsRepository;
    use lib\db\ClientStatisticDAO;
    use lib\db\SessionsRepository;

    require_once "ui-components.php";
    require_once "utils.php";

    $client_id = getClientId();
    try{
        $client = (new ClientsRepository())->getById($client_id);
        $client_statistic = ClientStatisticDAO::get($client_id);
        $sessions =  (new SessionsRepository())->getAllWhereClientId($client_id);
    } catch (Exception $e){
        printErrorPage(500, "<h2> Error: ".$e->getMessage()."</h2>");
        exit;
    }

    require "parts/head.html";
?>

<main role="main">
    <div class="container">
        <?php printHeader();?>
        <div class="row">
            <div class="col-md-auto">
                <div class="shadow-sm p-3 mb-5 bg-body rounded">
                    <?php printClient($client); ?>
                </div>
                <?php
                    printClientStatistic($client_statistic);
                    printSessions($sessions);
                ?>
            </div>
        </div>
        <?php printFooter();?>
    </div>
</main>

<?php require "parts/tail.html";?>