<?php

    require "db/ConnectionFactory.php";
    require "db/ClientStatisticDAO.php";
    require "ui-components.php";
    require "utils.php";

    try{
        $pdo = ConnectionFactory::getPDO();
        $client = get_client($pdo);
        $client_statistic = ClientStatisticDAO::get($client->id);
        $sessions = get_sessions($pdo, $client->id);
    } catch (PDOException){
        print_error_page(500, "<h2> Error: ".$e->getMessage()."</h2>");
        exit;
    }

    require "parts/head.html";
?>

<main role="main">
    <div class="container">
        <?php print_header();?>
        <div class="row">
            <div class="col-md-8">
                <div class="shadow-sm p-3 mb-5 bg-body rounded">
                    <?php print_client($client); ?>
                </div>
                <?php
                    print_client_statistic($client_statistic);
                    print_sessions_list($sessions);
                ?>
            </div>
        </div>
        <?php print_footer();?>
    </div>
</main>

<?php require "parts/tail.html";?>