<?php

    require_once __DIR__ . '/vendor/autoload.php'; // Composer autoload
    require_once "db/collections.php";
    require_once "ui-components.php";
    require_once "utils.php";

    $client_id = get_client_id_from_request();
    $client = get_client($client_id, $clients_collection);
    $sessions = get_sessions($client_id, $sessions_collection);

    require "parts/head.html";
?>

<main role="main">
    <div class="container">
        <?php print_header();?>
        <div class="row">
            <div class="col-md-auto">
                <div class="shadow-sm p-3 mb-5 bg-body rounded">
                    <?php print_client($client); ?>
                </div>
                <?php
                print_sessions_list($sessions);
                ?>
            </div>
        </div>
        <?php print_footer();?>
    </div>
</main>

<?php require "parts/tail.html";?>