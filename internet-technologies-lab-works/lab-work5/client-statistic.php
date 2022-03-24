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

                $client = $_GET['id'];
                $statement = $pdo->query("SELECT * FROM `seanse` where client_id = $client");
                $sessions = $statement->fetchAll(PDO::FETCH_OBJ);

                if ($sessions) {
                    echo " <h3>Sessions list:</h3> <div class='list-group'>";
                    foreach ($sessions as $session) {
                        echo '<div class="list-group-item list-group-item-action d-flex w-100 justify-content-between">
                                    <div class="row justify-content-between">
                                        <div class="col-md-auto">
                                        <h5 class="mb-1"> Traffic </h5>
                                        <table class="table">
                                            <tr>
                                                <td> in trafic </td>
                                                <td> out trafic </td>
                                            </tr>
                                            <tr>
                                                <td>'.$session->in_traffic.' MByte</td>
                                                <td>'.$session->out_traffic.' MByte</td>
                                            </tr>
                                        </table>
                                        </div>
                                        
                                        <div class="col-md-auto">
                                        <h5 class="mb-1"> Time </h5>
                                        <table class="table">
                                            <tr>
                                                <td> start </td>
                                                <td> stop </td>
                                            </tr>
                                            <tr>
                                                <td>'.$session->start.'</td>
                                                <td>'.$session->stop.'</td>
                                            </tr>
                                        </table>
                                        </div>
                                    </div>
                              </div>';
                    }
                    echo "</div>";
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