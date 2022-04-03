<?php

    require "models/GlobalStatistic.php";
    require "ui-components.php";
    require "database/config.php";
    require "utils.php";

    $global_statistic = new GlobalStatistic($pdo);

    require "parts/head.html";
?>

<main role="main">
    <div class="container">
        <?php print_header();?>
        <div class="row">
            <div class="col-md-8">
                <?php print_global_statistic($global_statistic); ?>
            </div>
        </div>
        <?php print_footer();?>
    </div>
</main>

<?php require "parts/tail.html";?>
