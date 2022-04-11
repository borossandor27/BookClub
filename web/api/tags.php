<?php
require_once '../connect.php';
$sql = "SELECT `id`, `csaladnev`, `utonev`, `nem`, `szuletett`, `belepett` FROM `tagok` WHERE 1";
$result = $conn->query($sql);
$tagok = array();
if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    $row['kep'] = join(DIRECTORY_SEPARATOR, array('images', $row['nem'].'.jpg'));
    array_push($tagok,$row);
  }
} else {
  echo "0 results";
}
$json = json_encode($tagok, true);
//echo '<pre>';
echo $json;
//
//echo '</pre>';

