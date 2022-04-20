<?php

    require_once 'vendor/autoload.php'; // Composer autoload
    require_once "db/collections.php";
    require_once "PageBuilder.php";
    require_once "utils.php";

    try {
        $clientId = getClientId();
        $client = getClient($clientId, $clientsCollection);
        $sessions = $clientsCollection->find(['client' => $clientId]);
    } catch (Exception $e) {
        PageBuilder::printErrorPage(500, "<h2> Error: ".$e->getMessage()."</h2>");
    }

    require_once "parts/head.html";
?>

<main role="main">
    <div class="container">
        <?php PageBuilder::printHeader();?>
        <div class="row">
            <div class="col-md-auto">
                <div class="shadow-sm p-3 mb-5 bg-body rounded">
                    <?php PageBuilder::printClient($client); ?>
                </div>
                <?php PageBuilder::printSessions($sessions); ?>
            </div>
        </div>
        <?php PageBuilder::printFooter();?>
    </div>
</main>

<?php require_once "parts/tail.html";?>