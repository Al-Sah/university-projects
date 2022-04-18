<?php


use models\GlobalStatistic;
use models\ClientStatistic;

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


function print_sessions_list($sessions){
    if (!$sessions) {
        echo "<p>No sessions found</p>";
        exit();
    }

    echo " <h3>Sessions list:</h3> <div class='list-group'>";
    foreach ($sessions as $session) {
        echo <<< SESSIONS_LIST
            <div class="list-group-item list-group-item-action d-flex w-100 justify-content-between">
                <div class="row justify-content-between">
                
                    <div class="col-md-auto">
                        <h5 class="mb-1"> Traffic </h5>
                        <table class="table">
                            <tr><td> in trafic </td><td> out trafic </td></tr>
                            <tr><td> $session->in_traffic MByte</td><td> $session->out_traffic MByte</td></tr>
                        </table>
                    </div>
                    
                    <div class="col-md-auto">
                        <h5 class="mb-1"> Time </h5>
                        <table class="table">
                            <tr><td> start </td><td> stop </td></tr>
                            <tr><td> $session->start </td><td> $session->stop </td></tr>
                        </table>
                    </div>
                </div>
            </div>
            SESSIONS_LIST;
    }
    echo "</div>";
}

function print_clients_list($clients){
    if (!$clients) {
        echo "<p>No clients found".check_filter()."</p>";
        exit();
    }

    echo "<h3>Clients list ".check_filter().":</h3> <div class='list-group'>";
    foreach ($clients as $client) {
        echo "<a href='/client-statistic.php?id=$client->id'class='list-group-item list-group-item-info' aria-current='true'>";
        print_client($client);
        echo '</a>';
    }
    echo "</div>";
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


function print_client_statistic(ClientStatistic $client_statistic){
    $time = $client_statistic->timeToFormat();
    echo <<< STAT
        <table class="table table-striped table-bordered ">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col"> Statistic </th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <th scope="row"> Time online </th>
          <td>$time</td>
        </tr>
        <tr>
          <th scope="row"> Out traffic sum </th>
          <td>$client_statistic->outTraffic MByte</td>
        </tr>
        <tr>
          <th scope="row"> In traffic sum </th>
          <td>$client_statistic->inTraffic MByte</td>
        </tr>
        <tr>
          <th scope="row"> Sessions count </th>
          <td>$client_statistic->sessions</td>
        </tr>
      </tbody>
    </table>
    STAT;
}


function print_client($client){
    echo <<< CLIENT
        <div class="d-flex w-100 justify-content-between ">
            <h5 class="mb-1">$client->name</h5>
            <small> Balance: $client->balance</small>
        </div>
        <p class="mb-1"> $client->login : $client->ip </p>
    CLIENT;
}


function print_global_statistic(GlobalStatistic $global_statistic)
{
    echo <<< STAT
        <table class="table table-striped table-bordered ">
      <thead>
        <tr>
          <th scope="col">#</th>
          <th scope="col"> Statistic </th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <th scope="row"> Clients </th>
          <td>$global_statistic->clients</td>
        </tr>
        <tr>
          <th scope="row"> Sessions </th>
          <td>$global_statistic->sessions</td>
        </tr>
        <tr>
          <th scope="row"> Time online in minutes (summary) </th>
          <td>$global_statistic->timeOnline</td>
        </tr>
        <tr>
          <th scope="row"> Out traffic sum </th>
          <td>$global_statistic->outTraffic MByte</td>
        </tr>
        <tr>
          <th scope="row"> In traffic sum </th>
          <td>$global_statistic->inTraffic MByte</td>
        </tr>
        <tr>
          <th scope="row"> Client (id) with max out traffic for one session </th>
          <td>$global_statistic->maxOut MByte</td>
        </tr>
        <tr>
          <th scope="row"> Client (id) with max in traffic for one session </th>
          <td>$global_statistic->maxIn MByte</td>
        </tr>
        
      </tbody>
    </table>
    STAT;
}