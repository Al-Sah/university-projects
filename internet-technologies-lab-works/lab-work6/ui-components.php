<?php

require_once "utils.php";

function print_footer(){
    echo <<< FOOTER
    <div class="container">
        <footer class="py-3 my-4">
            <ul class="nav justify-content-center border-bottom pb-3 mb-3">
                <li class="nav-item"><a href="/index.php" class="nav-link px-2 text-muted">Home</a></li>
                <li class="nav-item"><a href="/global-statistic.php" class="nav-link px-2 text-muted">Global statistic</a></li>
            </ul>
            <p class="text-center text-muted"> 2022; University al-sah :)</p>
        </footer>
    </div>
    FOOTER;
}


function print_header(){
    echo <<< HEADER
    <header class="d-flex justify-content-center py-3">
    <nav class="navbar navbar-light" >
        <ul class="nav nav-pills">
            <li class="nav-item"><a href="/index.php" class="nav-link active" aria-current="page">Home</a></li>
            <li class="nav-item"><a href="/global-statistic.php" class="nav-link">Global statistic</a></li>
        </ul>
    </nav>
    </header>
    HEADER;
}

function print_error_page(int $code = 404, string $data = null){

    http_response_code($code);
    function print_error_content($code, $data){
        echo "<div class='jumbotron p-4 bg-light'><div class='container'><h1 class='display-4'>Error $code</h1></div></div>";
        if($data != null){
            echo "<div class='container p-6 border-top border-bottom'>$data</div>";
        }
    }

    require 'parts/head.html';
    if($code == 500){
        print_error_content($code, $data);
    } else{
        print_header();
        print_error_content($code, $data);
        print_footer();
    }
    require 'parts/tail.html';
}


function print_client($client){
    echo <<< CLIENT
        <div class="d-flex w-100 justify-content-between ">
            <h5 class="mb-1">$client->login</h5>
            <small> Balance: $client->balance</small>
        </div>
        <p class="mb-1"> ip $client->ip </p>
    CLIENT;
}

function print_clients_list($clients){
    if (!$clients) {
        echo "<p>No clients found".check_filter()."</p>";
        return;
    }

    echo "<h3>Clients list ".check_filter().":</h3> <div class='list-group'>";
    foreach ($clients as $client) {
        echo "<a href='/client-statistic.php?id=$client->_id'class='list-group-item list-group-item-info' aria-current='true'>";
        print_client($client);
        echo '</a>';
    }
    echo "</div>";
}
