<?php
    require "database/config.php";
    require "ui-components.php";
    require "utils.php";

    $client = get_client($pdo);

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
                <?php get_sessions($pdo, $client->id);?>
            </div>
        </div>
        <?php print_footer();?>
    </div>
</main>

<?php require "parts/tail.html";?>