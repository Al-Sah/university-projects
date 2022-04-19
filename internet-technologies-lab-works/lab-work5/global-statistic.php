<?php

    require_once "db/GlobalStatisticDAO.php";
    require_once "ui-components.php";
    require_once "utils.php";

    try{
        $globalStatistic = GlobalStatisticDAO::get();
    } catch (PDOException){
        printErrorPage(500, "<h2> Error: ".$e->getMessage()."</h2>");
        exit;
    }

    require "parts/head.html";
?>

<main role="main">
    <div class="container">
        <?php printHeader();?>
        <div class="row">
            <div class="col-md-8">
                <?php printGlobalStatistic($globalStatistic); ?>
            </div>
        </div>
        <?php printFooter();?>
    </div>
</main>

<?php require "parts/tail.html";?>
