<?php

use MongoDB\Driver\Cursor;

class PageBuilder {

    public static function printFooter(): void {
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

    public static function printHeader(): void{
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

    public static function printErrorPage(int $code = 404, string $data = null): void{
        http_response_code($code);
        require 'parts/head.html';
        if($code == 500){
            self::printErrorContent($code, $data);
        } else{
            self::printHeader();
            self::printErrorContent($code, $data);
            self::printFooter();
        }
        require 'parts/tail.html';
        exit();
    }

    public static function printClient($client): void {
        echo <<< CLIENT
            <div class="d-flex w-100 justify-content-between ">
                <h5 class="mb-1">$client->login</h5>
                <small> Balance: $client->balance</small>
            </div>
            <p class="mb-1"> ip $client->ip </p>
        CLIENT;
    }

    public static function printClients(array $clients): void{

        if (count($clients) == 0) {
            echo "<p>No clients found".self::getFilter()."</p>";
            return;
        }

        echo "<h3>Clients list ".self::getFilter().":</h3> <div class='list-group'>";
        foreach ($clients as $client) {
            echo "<a href='/client-statistic.php?id=$client->_id'class='list-group-item list-group-item-info' aria-current='true'>";
            self::printClient($client);
            echo '</a>';
        }
        echo "</div>";
    }


    public static function getFilterValue() : string {
        $filter ="";
        if (isset($_GET['clients-filter'])) {
            $filter = $_GET['clients-filter'];
        }
        return $filter;
    }


    public static function getFilter(): string {
        return match (self::getFilterValue()) {
            'cf2' => ' (balance > 0)',
            'cf3' => ' (balance <= 0)',
            'cf4' => ' ('.$_GET['number1'].' <= balance <= '.$_GET['number2'].')',
            default => '(no filters)',
        };
    }



    public static function printSessions(Cursor $sessions): void {

        $sessions = $sessions->toArray();
        if (count($sessions) == 0) {
            echo "<p>No sessions found</p>";
            return;
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
                    
                    <div class="col-md-auto">
                        <h5 class="mb-1"> Other </h5>
                        <table class="table">
                            <tr><td> price </td><td> ip </td></tr>
                            <tr><td> $session->price </td><td> $session->ip </td></tr>
                        </table>
                    </div>
                </div>
            </div>
            SESSIONS_LIST;
        }
        echo "</div>";
    }



    private static function printErrorContent($code, $data): void {
        echo "<div class='jumbotron p-4 bg-light'><div class='container'><h1 class='display-4'>Error $code</h1></div></div>";
        if($data != null){
            echo "<div class='container p-6 border-top border-bottom'>$data</div>";
        }
    }
}