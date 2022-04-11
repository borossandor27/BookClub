<?php
        /* adott azonosítójú tag eddigi befizetései */
        $id = filter_input(INPUT_GET, "id", FILTER_SANITIZE_NUMBER_INT);
        $answer = '';
        if(!filter_var($id, FILTER_VALIDATE_INT)){
            echo $answer;
        }
        require_once './connect.php';
        $sql = "SELECT datum, befizetes FROM befizetes WHERE id = $id ORDER BY datum DESC";
        if($result = $mysqli->query($sql)){
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
            echo $answer;