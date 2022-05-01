<?php

namespace lib\db\models;

class Client{

    public int $id;
    public string $name;
    public string $login;
    public string $ip;
    public string $balance;

    public function __construct(int $id, string $name, string $login, string $ip, string $balance)
    {
        $this->id = $id;
        $this->name = $name;
        $this->login = $login;
        $this->ip = $ip;
        $this->balance = $balance;
    }


}