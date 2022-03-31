<?php

function get_sessions($pdo, int $client_id){
    try{
        $statement = $pdo->query("SELECT * FROM `seanse` where client_id = $client_id");
        $sessions = $statement->fetchAll(PDO::FETCH_OBJ);

        print_sessions_list($sessions);

    }catch(PDOException $e) {
        echo "<h2> Error: ".$e->getMessage()."</h2>";
    }
}

function get_clients($pdo){
    if ($_SERVER['REQUEST_METHOD'] == "GET" and isset($_GET['filter'])) {
        $sql_str = 'SELECT * FROM `client` where balance > 0';
    } else{
        $sql_str = 'SELECT * FROM `client`';
    }

    try{
        $statement = $pdo->query($sql_str);
        $clients = $statement->fetchAll(PDO::FETCH_OBJ);
        print_clients_list($clients);
    }catch(PDOException $e) {
        echo "<h2> Error: ".$e->getMessage()."</h2>";
    }
}

function get_client($pdo){
    if(array_key_exists("id", $_GET)){
        if(!is_numeric($_GET['id'])){
            print_error_page();
            exit;
        } else{
            $client_id = $_GET['id'];
            $client = $pdo->query("SELECT * FROM `client` WHERE id = $client_id")->fetch(PDO::FETCH_OBJ);
            if(!$client){
                print_error_page();
                exit;
            }
            return $client;
        }
    }
    return null;
}