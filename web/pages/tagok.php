<div class="row">
    <?php
    $aktev = intval(date('Y'));

    foreach ($tags as $tag) {
        $nev = $tag['csaladnev'].' '.$tag['utonev'];
        $datum = strtotime( $tag['szuletett']);
        echo '<div class="card m-2 p-2" style="width: 18rem;">'
            . '<img class="card-img-top rounded-circle img-thumbnail" src="'.$tag['kep'].'" alt="'.$nev.'">'
            . '<div class="card-body">'
            . '<h5 class="card-title">'.$nev.'</h5>'
            . '<p class="card-text">Kora: '.$aktev-date('Y',$datum).'</p>'
            . '<p class="card-text">Belépett: '.$tag['belepett'].'</p>'
            . '<a href="index.php?menu=befizetes&id='.$tag['id'].'" class="btn btn-primary">Befizetések</a>'
            . '  </div></div>';
    }
    ?>
</div> <!-- row vége -->
