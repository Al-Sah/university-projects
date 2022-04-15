<?php
    require_once __DIR__ . '/vendor/autoload.php'; // Composer autoload

    require_once "db/config.php";
    require_once "ui-components.php";
    require_once "parts/head.html";

    $clients = get_clients($clients_collection);
?>

<main role="main">
    <div class="container">
        <?php print_header();?>
        <div class="row">
            <div class="col-md-8">
                <form action="index.php" method="get" class="shadow-sm p-3 mb-5 bg-body rounded">
                    <div class="form-check ">
                        <input class="form-check-input" type="radio" name="clients-filter" id="filter1" value="cf1">
                        <label class="form-check-label" for="filter1"> Show all clients </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="clients-filter" id="filter3" value="cf3">
                        <label class="form-check-label" for="filter3"> Show without money </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" name="clients-filter" id="filter2" value="cf2">
                        <label class="form-check-label" for="filter2"> Show with money </label>
                    </div>

                    <div class="p-2 mt-1">
                        <button type="submit" class="btn btn-success">Apply filter</button>
                    </div>
                </form>
            </div>
            <?php print_clients_list($clients) ?>
        </div>
        <?php print_footer();?>
    </div>
</main>

<?php require "parts/tail.html";?>


