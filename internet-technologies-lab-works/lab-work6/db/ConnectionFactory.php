<?php

use MongoDB\Database;
use MongoDB\Driver\Exception\RuntimeException as DriverRuntimeException;
use MongoDB\Exception\InvalidArgumentException;
use MongoDB\Exception\UnsupportedException;

require_once "DataBaseNotFoundException.php";

class ConnectionFactory
{
    /**
     * @return array of 2 items: 'clients' and 'sessions' collections
     * @throws DataBaseNotFoundException
     * @throws InvalidArgumentException
     *
     * selectCollection() call can produce
     * @throws UnsupportedException if options are not supported by the selected server
     * @throws DriverRuntimeException for other driver errors (e.g. connection errors)
     */
    public static function getCollections(): array
    {
        $db_config = array(
            "db_name" => "itech_lab",
            "clients_collection" => "clients",
            "sessions_collection" => "sessions",
        );

        $mongo = new MongoDB\Client("mongodb://localhost:27017");
        if(!in_array($db_config["db_name"], iterator_to_array($mongo->listDatabaseNames()))) {

            throw new DataBaseNotFoundException("Database '".$db_config["db_name"]."' not found");
        }
        $database = $mongo->selectDatabase($db_config["db_name"]);
        ConnectionFactory::validate_database($database, $db_config["clients_collection"], $db_config["sessions_collection"]);
        return array(
            $database->selectCollection($db_config["clients_collection"]),
            $database->selectCollection($db_config["sessions_collection"])
        );
    }

    private static function validate_database(Database $database, $clients, $sessions){
        if(!in_array($sessions, iterator_to_array($database->listCollectionNames()))) {
            $database->createCollection($sessions);
        }
        if(!in_array($clients, iterator_to_array($database->listCollectionNames()))) {
            $database->createCollection($clients);
        }
    }
}