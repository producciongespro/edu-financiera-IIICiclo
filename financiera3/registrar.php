<?php
    header('Access-Control-Allow-Origin: *');
    header("Access-Control-Allow-Headers: Origin, X-Requested-With, Content-Type, Accept");
    header('Access-Control-Allow-Methods: GET, POST, PUT, DELETE');
    header("Content-Type: text/html; charset=utf-8");
    sleep(1);
    require 'conexion.php';
    $intentos = $_GET['intentos'];
    $consulta= "INSERT INTO `records`(`intento`) VALUES ('$intentos')";
    $mysqli = conectarDB();
    $registro = mysqli_query($mysqli,$consulta) or die ("Problemas al insertar registro".mysqli_error($mysqli));
    if($registro > 0 )
    {
        $mjs="Registro exitoso";
        echo json_encode(array('error'=>false, 'mensaje'=>$mjs));
        exit;
    } else {
            $errors[] = "Error al registrar";
            echo json_encode(array('error'=>true, 'mensaje'=>$errors ));
        } 
?>