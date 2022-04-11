<?php
$id = filter_input(INPUT_GET, 'id' , FILTER_SANITIZE_NUMBER_INT);
if(filter_input(INPUT_POST, "adat", FILTER_VALIDATE_BOOLEAN, FILTER_NULL_ON_FAILURE)){
    $id = filter_input(INPUT_POST,"tagid", FILTER_SANITIZE_NUMBER_INT);
    $datestring = filter_input(INPUT_POST, "datum");
    $befizetes = filter_input(INPUT_POST,"payment", FILTER_VALIDATE_INT );
    
    $datearray = date_parse($datestring);
    if(checkdate($datearray['month'], $datearray['day'], $datearray['year'])){
        $db->insert_payment($id, $datestring, $befizetes);
        if($db->err){
            echo '<p id="eredmeny" class="p-3 m-2 bg-danger text-white">Sikertelen rögzítés!</p>';
        } else {
            echo '<p id="eredmeny" class="p-3 m-2 bg-success text-white">Sikeres rögzítés!</p>';
        }
    } else {
        echo '<p id="eredmeny" class="text-danger">Érvénytelen adatok!</p>';
    }
}

?>

<form id="new" class="row" method="POST">
    <?php

    ?>
    

    <fieldset>
        <legend></legend>
        <div class="col-6 m-2">
            <select class="form-select" aria-label="Tag kiválasztása" name="tagid" id="tagid" onChange="showPayments()">
                <?php
                foreach ($db->get_tags_options($id) as $value) {
                    echo $value;
                }
                ?>
            </select>
        </div>
        <div class="col-6 m-2">
            <input type="date" class="form-control" name="datum" placeholder="befizetés napja" value="<?php echo date('Y-m-d'); ?>" required>
            <div class="valid-feedback">
                Looks good!
            </div>
        </div>
        <div class="col-6 m-2">
            <input type="number" class="form-control text-end pe-5" name="payment" placeholder="összeg" min="100" max="10000" step="50" value="2000" required>
            <div class="valid-feedback">
                Looks good!
            </div>
        </div>
        <div>
            <!--<button type="submit" class="btn btn-success" onclick="rogzit()">Rögzít</button>-->
            <button type="submit" class="btn btn-success" name="adat" value="true">Új befizetés</button>
        </div>

    </fieldset>
</form>
<div id="befizetesek">
<?php
if($id != null){
    //-- befizetések megjelenítése
    echo $db->get_tag_payments_table($id);
}
?>    
</div>
<script>
 
function showPayments() {
    var select = document.getElementById('tagid');
    var id = select.options[select.selectedIndex].value;
    console.log(id); 

    var xmlhttp = new XMLHttpRequest();
    xmlhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("befizetesek").innerHTML = this.responseText;
        }
    };
    xmlhttp.open("GET", "api/showPayments.php?id=" + id, true);
    xmlhttp.send();
}
</script>

