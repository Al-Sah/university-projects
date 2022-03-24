<!DOCTYPE html>
<html lang="ru">

<head>
    <meta charset="UTF-8">
    <title>Lab-work 5</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css">
</head>

<body>
    <div class="container">

        <?php

        try{
            require_once "db-config.php";
        }catch(PDOException $e) {
            echo "<h1> Connection failed: ".$e->getMessage()."</h1>";
            echo phpinfo();
        }


        try{
            $statement = $pdo->query('SELECT * FROM `client`');
            $clients = $statement->fetchAll(PDO::FETCH_OBJ);

            if ($clients) {
                echo "<ul>";
                foreach ($clients as $client) {
                    echo "<li> $client->name <br></li>";
                }
                echo "</ul>";
            } else{
                echo "No clients found";
            }

        }catch(PDOException $e) {
            echo "<h2> Error: ".$e->getMessage()."</h2>";
        }

        ?>
    </div>

</body>
</html>
