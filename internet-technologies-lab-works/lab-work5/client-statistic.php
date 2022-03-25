<?php
    require "utils.php";
    require "db-config.php";

    if(array_key_exists("id", $_GET)){
        if(!is_numeric($_GET['id'])){
            require "404.php";
            exit;
        } else{
            $client_id = $_GET['id'];
            $client = $pdo->query("SELECT * FROM `client` WHERE id = $client_id")->fetch(PDO::FETCH_OBJ);
            if(!$client){
                require "404.php";
                exit;
            }
        }
    }
?>

<!DOCTYPE html>
<html lang="ru">';
    <?php print_head('Lab-work5'); ?>
<body>
<div class="container">
    <?php require "header.html"; ?>
    <div class="row">
        <div class="col-md-8">
            <?php

            try{

                echo '<div class="shadow-sm p-3 mb-5 bg-body rounded">
                        <div class="d-flex w-100 justify-content-between ">
                            <h5 class="mb-1">'.$client->name.'</h5>
                            <small> Balance: '.$client->balance.'</small>
                        </div>
                        <p class="mb-1">'.$client->login.' : '.$client->ip.'</p></div>';

                $statement = $pdo->query("SELECT * FROM `seanse` where client_id = $client_id");
                $sessions = $statement->fetchAll(PDO::FETCH_OBJ);

                if ($sessions) {
                    print_sessions_list($sessions);
                } else{
                    echo "No sessions found";
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