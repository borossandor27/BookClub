<?php
        $mysqli = new mysqli("localhost", "root", "", "bookclub");
        if($mysqli->connect_errno ){
            echo 'Az adatbázis nem elérhető!';
            die();
        }
        $mysqli->set_charset("utf8");

