<?php
session_start();
if(isset($_SESSION['user_id'])){
    header('Location:index.php');
}
?>
<!DOCTYPE html>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Login</title>
	<style type="text/css" media="all">@import "http://localhost/PrimerParcial/programa1/estilos.css";</style>
</head>

	<div id="templatemo_container_wrapper">
		<div class="templatemo_spacer"></div>
	<div id="templatemo_container">
	<div id="templatemo_top"></div>
  	<div id="templatemo_header">
      <div id="inner_header">
        <div id="templatemo_site_title">Login</div>
     </div>
  	</div>

  	<div id="templatemo_left_column">
  		<div class="text_area" align="justify">
  		<div class="section_box2" align="justify">
	<div class="title">Ingrese sus credenciales</div>

	</div>
	</div>
	<div class="text_area" align="justify">
	<div class="section_box2" align="justify">
	<form action="validation.php" method="post">
		<table>
		<tr>
			<td><label>usuario</label></td>
			<td><input type="text" name="user"></td>
		</tr>
		<tr>
			<td><label>contraseña</label></td>
			<td><input type="password" name="pass"></td>
		</tr>
		<tr>
			<td><input type="submit" name="Aceptar" value="Aceptar"></td>
			<td><input type="reset" name="Cancelar" value="Cancelar"></td>
		</tr>
		</table>
	</form>
	</div>
</div>	
	</div>

	<div id="templatemo_right_column">
	<div class="section_box2" align="justify">
	</div>
	</div>
	<div id="templatemo_footer"></div>
	</div>
	</div>
</body>
</html>