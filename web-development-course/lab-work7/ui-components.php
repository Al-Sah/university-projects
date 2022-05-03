<?php
use lib\db\models\ClientStatistic;

function printSessions(array $sessions): void {

    if (count($sessions) == 0) {
        echo "<p>No sessions found</p>";
        return;
    }

    echo " <h3>Sessions list:</h3> <div class='list-group'>";
    foreach ($sessions as $session) {
        $start = $session->start->format('Y-m-d H:i:s');
        $stop = $session->stop->format('Y-m-d H:i:s');
        echo <<< SESSIONS_LIST
            <div class="list-group-item list-group-item-action d-flex w-100 justify-content-between">
                <div class="row justify-content-between">
                
                    <div class="col-md-auto">
                        <h5 class="mb-1"> Traffic </h5>
                        <table class="table">
                            <tr><td> in trafic </td><td> out trafic </td></tr>
                            <tr><td> $session->in MByte</td><td> $session->out MByte</td></tr>
                        </table>
                    </div>
                    
                    <div class="col-md-auto">
                        <h5 class="mb-1"> Time </h5>
                        <table class="table">
                            <tr><td> start </td><td> stop </td></tr>
                            <tr><td> $start </td><td> $stop </td></tr>
                        </table>
                    </div>
                </div>
            </div>
            SESSIONS_LIST;
    }
    echo "</div>";
}



function printError(int $code = 404, string $data = null): void {
    http_response_code($code);
    echo "<div class='jumbotron p-4 bg-light'><div class='container'><h1 class='display-4'>Error $code</h1></div></div>";
    if($data != null){
        echo "<div class='container p-6 border-top border-bottom'>$data</div>";
    }
}


function printClientStatistic(ClientStatistic $statistic): void {

    $time = $statistic->timeToFormat();
    echo <<< CLIENT_STATISTIC
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
          <td>$statistic->outTraffic MByte</td>
        </tr>
        <tr>
          <th scope="row"> In traffic sum </th>
          <td>$statistic->inTraffic MByte</td>
        </tr>
        <tr>
          <th scope="row"> Sessions count </th>
          <td>$statistic->sessions</td>
        </tr>
      </tbody>
    </table>
    CLIENT_STATISTIC;
}