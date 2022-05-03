<?php ?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title> lab-work7 </title>
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Bootstrap CSS -->
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" crossorigin="anonymous">
    <script src="index.js"></script>
</head>
<body>

<main role="main">
    <div class="container">

        <header class="d-flex justify-content-center py-3">
            <nav class="navbar navbar-light" >
                <ul class="nav nav-pills">
                    <li class="nav-item"> <button class="nav-link" onclick="renderForm()"> Home </button> </li>
                    <li class="nav-item"> <button class="nav-link" onclick="getGlobalStatistic()"> Global statistic </button> </li>
                </ul>
            </nav>
        </header>

        <div class="row">
            <div class="col" id="dynamic-content">
                <script>
                    renderForm()
                </script>
            </div>
        </div>

        <footer class="py-3 my-4">
            <ul class="nav nav-pills justify-content-center border-bottom pb-3 mb-3">
                <li class="nav-item">
                    <button class="nav-link px-2 text-muted" onclick="renderForm()"> Home </button>
                </li>
                <li class="nav-item">
                    <button class="nav-link px-2 text-muted" onclick="getGlobalStatistic()"> Global statistic </button>
                </li>
            </ul>
            <p class="text-center text-muted"> 2022; University al-sah :)</p>
        </footer>
    </div>
</main>

</body>
</html>
