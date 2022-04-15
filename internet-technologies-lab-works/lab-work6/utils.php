<?php


use MongoDB\Collection;

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
                    return $collection->find( ['balance' => ['$gt' => 0]])->toArray();;
                case 'cf3':
                    return $collection->find( ['balance' => ['$lt' => 0]])->toArray();;
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
        exit;
    }
}