<?php
$conn = new mysqli('localhost', 'root', '', 'bookclub');
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
$conn->set_charset("utf8");

