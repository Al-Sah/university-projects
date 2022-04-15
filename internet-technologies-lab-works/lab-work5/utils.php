<?php

function get_sessions($pdo, int $client_id){
    try{
        $sth = $pdo->prepare("SELECT * FROM `seanse` where client_id = :id");
        $sth->execute(array('id' => $client_id));
        return $sth->fetchAll(PDO::FETCH_OBJ);
    }catch(PDOException $e) {
        print_error_page(500, "<h2> Error: ".$e->getMessage()."</h2>");
        exit;
    }
}

function check_filter(): string {
    if (isset($_GET['clients-filter'])) {
        switch ($_GET['clients-filter']){
            case 'cf2':
                return ' (balance > 0)';
            case 'cf3':
                return ' (balance <= 0)';
        }
    }
    return '(no filters)';
}

function get_clients($pdo){

    $sql_str = 'SELECT * FROM `client`';

    if (isset($_GET['clients-filter'])) {
        switch ($_GET['clients-filter']){
            case 'cf2':
                $sql_str .= 'where balance > 0';
                break;
            case 'cf3':
                $sql_str .= 'where balance <= 0';
        }
    }

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
            $sth = $pdo->prepare("SELECT * FROM `client` where id = :id");
            $sth->execute(array('id' => $client_id));
            $client = $sth->fetch(PDO::FETCH_OBJ);
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