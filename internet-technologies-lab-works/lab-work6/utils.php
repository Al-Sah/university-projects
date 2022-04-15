<?php


use MongoDB\Collection;

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

function get_clients(Collection $collection){

    try{
        if (isset($_GET['clients-filter'])) {
            switch ($_GET['clients-filter']){
                case 'cf2':
                    return $collection->find( ['balance' => ['$gt' => 0]]);
                case 'cf3':
                    return $collection->find( ['balance' => ['$lt' => 0]]);
            }
        }
        return $collection->find();
    }catch(Exception $e) {
        print_error_page(500, "<h2> Error: ".$e->getMessage()."</h2>");
        exit;
    }
}