<?php
    require 'vendor/autoload.php'; // Composer autoload

    require "db/config.php";
    require "ui-components.php";
    require "parts/head.html";
?>

<main role="main">
    <div class="container">
        <?php print_header();?>
        <div class="row">
            <div class="col-md-8">
                <h1>Hello world</h1>
            </div>
        </div>
        <?php print_footer();?>
    </div>
</main>

<?php require "parts/tail.html";?>


