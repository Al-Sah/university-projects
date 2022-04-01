<?php

function get_sessions($pdo, int $client_id){
    try{
        $statement = $pdo->query("SELECT * FROM `seanse` where client_id = $client_id");
        return $statement->fetchAll(PDO::FETCH_OBJ);
    }catch(PDOException $e) {
        print_error_page(500, "<h2> Error: ".$e->getMessage()."</h2>");
        exit;
    }
}

function get_clients($pdo){
    if ($_SERVER['REQUEST_METHOD'] == "GET" and isset($_GET['filter'])) {
        $sql_str = 'SELECT * FROM `client` where balance > 0';
    } else{
        $sql_str = 'SELECT * FROM `client`';
    } // TODO advanced filters

    try{
        return $pdo->query($sql_str)->fetchAll(PDO::FETCH_OBJ);
    }catch(PDOException $e) {
        print_error_page(500, "<h2> Error: ".$e->getMessage()."</h2>");
        exit;
    }
}

function get_client($pdo){
    if(array_key_exists("id", $_GET)){
        if(!is_numeric($_GET['id'])){
            print_error_page(400, "User id must be a number > 0");
            exit;
        } else{
            $client_id = $_GET['id'];
            $client = $pdo->query("SELECT * FROM `client` WHERE id = $client_id")->fetch(PDO::FETCH_OBJ);
            if(!$client){
                print_error_page(data: "Client with id $client_id not found");
                exit;
            }
            return $client;
        }
    }
    print_error_page(400, "key id was not sent");
    exit;
}