<?php

    require "db/config.php";
    require "db/mapping/GlobalStatisticMapper.php";
    require "ui-components.php";
    require "utils.php";

    try{
        $global_statistic = GlobalStatisticMapper::get($pdo);
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
                <?php print_global_statistic($global_statistic); ?>
            </div>
        </div>
        <?php print_footer();?>
    </div>
</main>

<?php require "parts/tail.html";?>
