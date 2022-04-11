<?php

class database {
    private $mysqli=null;
    public $err = false;
    public $errmessage = null;
    
    public function __construct($host="localhost", $user="root", $pass="", $db="bookclub") {
        $this->mysqli = new mysqli($host, $user, $pass, $db);
        if($this->mysqli->connect_errno ){
            echo 'Az adatbázis nem elérhető!';
            die();
        }
        $this->mysqli->set_charset("utf8");
    }
    
    public function __destruct() {
        $this->mysqli->close();
    }
    
    public function get_tags() {
        $sql = "SELECT `id`, `csaladnev`, `utonev`, `nem`, `szuletett`, `belepett` FROM `tagok` WHERE 1";
        $result = $this->mysqli->query($sql);
        $tags = array();

        if ($result->num_rows > 0) {
          // output data of each row
          while($row = $result->fetch_assoc()) {
              $kep = join(DIRECTORY_SEPARATOR, array('images', $row['csaladnev'].' '.$row['utonev'].'.jpg'));
              $row['kep'] = file_exists($kep)?$kep:join(DIRECTORY_SEPARATOR, array('images','NoImagePlaceholder.svg'));
              array_push($tags,$row);
          }
        } else {
          echo "0 results";
        }
        $result->free();
        return $tags;
    }
    
    public function get_tags_options($id) {
        $sql = "SELECT `id`, `csaladnev`, `utonev` FROM `tagok` WHERE 1";
        $result = $this->mysqli->query($sql);
        $tags = array();

        if ($result->num_rows > 0) {
            // output data of each row
            while($row = $result->fetch_assoc()) {
                if ($id == null || intval($id) != intval($row['id']) ) {
                    $tags[] = '<option value="'.$row['id'].'">'.$row['csaladnev'].' '.$row['utonev'].'</option>';
                } else {
                    $tags[] = '<option selected="selected" value="'.$row['id'].'">'.$row['csaladnev'].' '.$row['utonev'].'</option>';
                }
                
            }
        } else {
            echo "0 results";
        }
        $result->free();
        return $tags;
    }

    public function insert_payment($id, $datum, $befizetes) {
        $stmt = $this->mysqli->prepare("INSERT INTO `befizetes` (`id`, `datum`, `befizetes`) VALUES (?, ?, ?);");
        $stmt->bind_param("isi", $id, $datum, $befizetes);
        $stmt->execute();
        $answer = null;
        
        if ($this->mysqli->affected_rows === 1) {
            $answer = "A befizetés sikeres";
            $err = false;
            $this->errmessage = null;
        } else {
            $err = true;
            $this->errmessage = $this->mysqli->errno.' '.$this->mysqli->error;
            echo "0 results";
        }
    }
    
    public function get_tag_payments_table($id) {
        /* adott azonosítójú tag eddigi befizetései */
        $answer = '';
        if(!filter_var($id, FILTER_VALIDATE_INT)){
            return $answer;
        }
        $sql = "SELECT datum, befizetes FROM befizetes WHERE id = $id ORDER BY datum DESC";
        if($result = $this->mysqli->query($sql)){
            $answer = '<table class="table w-50 table-striped">
            <thead>
                <tr>
                    <th class="col-auto">Dátum</th>
                    <th class="col-auto">Összeg</th>
                </tr>
            </thead>
            <tbody>';
            $sum = 0;
           if($result->num_rows > 0){
                while ($row = $result->fetch_assoc()) {
//                    var_dump($row);
                    $sum += intval($row['befizetes']);
                    $answer .= '<tr><td>'.$row['datum'].'</td><td class="text-end">'.number_format($row['befizetes'],0,',',' ').' Ft</td></tr>';
                }            
            }
            $answer .= '</tbody>
            <tfoot>
                <tr>
                    <td>Összesen:</td>
                    <td class="text-end">'.number_format($sum,0,',',' ').' Ft</td>
                </tr>
            </tfoot>
        </table>';            
            } else {
                $answer = '<tr><td colspan=2>Nincs befizetése!</td></tr>';
            }
            $result->free();
            return $answer;
    }
}
