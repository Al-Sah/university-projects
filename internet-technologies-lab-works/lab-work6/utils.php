<?php


use MongoDB\BSON\ObjectId;
use MongoDB\Collection;
use MongoDB\Driver\Cursor;

function check_filter(): string {
    if (isset($_GET['clients-filter'])) {
        switch ($_GET['clients-filter']){
            case 'cf2':
                return ' (balance > 0)';
            case 'cf3':
                return ' (balance <= 0)';
            case 'cf4':
                if($_GET['number1'] and isset($_GET['number2']) !== null) {
                    return ' ('.$_GET['number1'].' <= balance <= '.$_GET['number2'].')';
                }
        }
    }
    return '(no filters)';
}

function get_clients(Collection $collection) : array{

    try{
        if (isset($_GET['clients-filter'])) {
            switch ($_GET['clients-filter']){
                case 'cf2':
                    return $collection->find( ['balance' => ['$gt' => 0]])->toArray();
                case 'cf3':
                    return $collection->find( ['balance' => ['$lt' => 0]])->toArray();
                case 'cf4':
                    if((isset($_GET['number1']) != null) && (isset($_GET['number2']) != null)) {
                        return $collection->find(
                            ['balance' => array(
                                '$gt' => intval($_GET['number1']-1),
                                '$lt' => intval($_GET['number2']+1))
                            ]
                        )->toArray();
                    }
            }
        }
        return $collection->find()->toArray();
    }catch(Exception $e) {
        print_error_page(500, "<h2> Error: ".$e->getMessage()."</h2>");
    }
}


function get_client_id_from_request(): MongoDB\BSON\ObjectID {

    if(array_key_exists("id", $_GET)){
        return new MongoDB\BSON\ObjectID($_GET['id']);
    }
    print_error_page(400, "key id was not sent");
}

function get_client(ObjectID $client_id, Collection $collection){

    try{
        $client = $collection->findOne(['_id' => $client_id]);
        if($client == null){
            print_error_page(data: "Client with id ".$_GET['id']." not found");
        }
        return $client;
    }catch(Exception $e) {
        print_error_page(500, "<h2> Error: ".$e->getMessage()."</h2>");
    }
}

function get_sessions(ObjectID $client_id, Collection $collection){

    try{
        return $collection->find(['client' => $client_id]);
    }catch(Exception $e) {
        print_error_page(500, "<h2> Error: ".$e->getMessage()."</h2>");
    }
}


function print_sessions_list(Cursor $sessions)
{
    $sessions = $sessions->toArray();
    if (count($sessions) == 0) {
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