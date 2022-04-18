<?php

namespace models;


class Client{

    public string $name;
    public string $login;
    public string $ip;
    public string $balance;

    public function __construct(string $name, string $login, string $ip, string $balance)
    {
        $this->name = $name;
        $this->login = $login;
        $this->ip = $ip;
        $this->balance = $balance;
    }


}