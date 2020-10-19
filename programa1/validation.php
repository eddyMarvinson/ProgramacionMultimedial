<?php 
session_start();
include "conexion.inc.php";
$sql = "select * from usuario where ci = '".$_POST["user"]."' and clave = '".$_POST["pass"]."'";
$resultado = mysqli_query($conn, $sql);
$extraccion = mysqli_fetch_array($resultado);
if (isset($_POST["Aceptar"])){
	if ($extraccion == "") {
		header('Location:login.php');
	} else {
		$_SESSION["user_id"] = $_POST["user"];
		$_SESSION["user_background"] = '<body style="background-image:url(images/templatemo_bg.gif)">';
		header('Location:index.php');
	}
}
if (isset($_POST["Salir"])) {
	session_unset();
	header('Location:index.php');
}
if (isset($_POST["Actualizar"])) {
	$_SESSION["user_background"] = '<body style="background-color:'.$_POST["color"].'">';
	header('Location:index.php');
}
?>