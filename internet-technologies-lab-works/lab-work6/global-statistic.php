<?php

    require_once 'vendor/autoload.php'; // Composer autoload
    require_once "db/collections.php";
    require_once "PageBuilder.php";
    require_once "utils.php";


try{
        $globalStatistic = getGlobalStatistic($clientsCollection->countDocuments(), $sessionsCollection);
    } catch (Exception $e){
        PageBuilder::printErrorPage(500, "<h2> Error: ".$e->getMessage()."</h2>");
    }

    require "parts/head.html";
?>

<main role="main">
    <div class="container">
        <?php PageBuilder::printHeader();?>
        <div class="row">
            <div class="col-md-8">
                <?php PageBuilder::printGlobalStatistic($globalStatistic); ?>
            </div>
        </div>
        <?php PageBuilder::printFooter();?>
    </div>
</main>

<?php require "parts/tail.html";?>
