<?php

    require_once __DIR__ . '/vendor/autoload.php'; // Composer autoload
    require_once "db/collections.php";
    require_once "ui-components.php";
    require_once "utils.php";

    try {
        $clientId = getClientId();
        $client = getClient($clientId, $clientsCollection);
        $sessions = getSessions($clientId, $sessionsCollection);
    } catch (Exception $e) {
        printErrorPage(500, "<h2> Error: ".$e->getMessage()."</h2>");
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
                printSessions($sessions);
                ?>
            </div>
        </div>
        <?php printFooter();?>
    </div>
</main>

<?php require "parts/tail.html";?>