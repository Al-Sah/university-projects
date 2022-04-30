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
        $config = array(
            "name" => "itech_lab",
            "clientsCollection" => "clients",
            "sessionsCollection" => "sessions",
        );

        $mongo = new MongoDB\Client("mongodb://localhost:27017");
        if(!in_array($config["name"], iterator_to_array($mongo->listDatabaseNames()))) {
            throw new DataBaseNotFoundException("Database '".$config["name"]."' not found");
        }

        $database = $mongo->selectDatabase($config["name"]);
        ConnectionFactory::validateDatabase($database, $config["clientsCollection"], $config["sessionsCollection"]);
        return array(
            $database->selectCollection($config["clientsCollection"]),
            $database->selectCollection($config["sessionsCollection"])
        );
    }

    private static function validateDatabase(Database $database, $clients, $sessions): void
    {
        if(!in_array($sessions, iterator_to_array($database->listCollectionNames()))) {
            $database->createCollection($sessions);
        }
        if(!in_array($clients, iterator_to_array($database->listCollectionNames()))) {
            $database->createCollection($clients);
        }
    }
}