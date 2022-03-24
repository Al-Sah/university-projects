<!DOCTYPE html>
<html lang="ru">

<head>
    <meta charset="UTF-8">
    <title>Lab-work 5</title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous">

</head>


<body>

    <div class="container">

        <?php require "header.html"; ?>

        <div class="row">
            <div class="col-md-8">
                <?php

                try{
                    require_once "db-config.php";
                }catch(PDOException $e) {
                    echo "<h1> Connection failed: ".$e->getMessage()."</h1>";
                    echo phpinfo();
                    exit();
                }

                try{
                    $statement = $pdo->query('SELECT * FROM `client`');
                    $clients = $statement->fetchAll(PDO::FETCH_OBJ);

                    if ($clients) {
                        echo " <h3>Clients list:</h3> <div class='list-group'>";
                        foreach ($clients as $client) {
                            echo "<a href='/client-statistic.php?id=$client->id' class='list-group-item list-group-item-info' aria-current='true'>".'
                                    <div class="d-flex w-100 justify-content-between">
                                        <h5 class="mb-1">'.$client->name.'</h5>
                                        <small> Balance: '.$client->balance.'</small>
                                    </div>
                                    <p class="mb-1">'.$client->login.' : '.$client->ip.'</p>
                                </a>';
                        }
                        echo "</div>";
                    } else{
                        echo "No clients found";
                    }

                }catch(PDOException $e) {
                    echo "<h2> Error: ".$e->getMessage()."</h2>";
                }

                ?>
            </div>
        </div>

        <?php require "footer.html"; ?>

    </div>
</body>
</html>
