<?php
header('Content-Type: text/html; charset=utf-8');
session_start();
require_once './classes/database.php';
$db = new database();
$tags = $db->get_tags();
$menu = filter_input(INPUT_GET, "menu", FILTER_SANITIZE_STRING);
?>
<!DOCTYPE html>
<html>
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Bagoly Könyv Klub</title>
        <link rel="icon" type="image/x-icon" href="favicon.ico">
        <link rel="stylesheet" href="bootstrap-5.0.2-dist/css/bootstrap.min.css" />
        <script src="bootstrap-5.0.2-dist/js/bootstrap.min.js"></script>
        <link rel="stylesheet" href="css/bookclub.css" />
        <script src="js/bookclub.js" ></script>
    </head>
    <body>
        <header class="container">
            <h1 class="text-center">Bagoly Könyv Klub</h1>
            <ul class="nav justify-content-center">
              <li class="nav-item">
                  <a class="nav-link <?php echo $menu=='home'?'active':''; ?>" href="index.php?menu=home">Tagok</a>
              </li>
              <li class="nav-item">
                <a class="nav-link <?php echo $menu=='befizetes'?'active':''; ?>" href="index.php?menu=befizetes">Befizetés</a>
              </li>
              <li class="nav-item">
                  <a class="nav-link" href="https://www.dszcberegszaszi.hu/" target="_blank">Az iskola honlapja</a>
              </li>
            </ul>
        </header>
        <div class="container" id="tartalom">
            <?php
            switch ($menu) {
                case "befizetes":
                    include_once './pages/befizetes.php';
                    break;
                default:
                    include_once './pages/tagok.php';
                    break;
            }
            ?>
        </div> <!-- container vége -->
        <footer class="text-center container-fluid">
            <p>&COPY; Remek Elek, 2022</p>
        </footer>
    </body>
</html>