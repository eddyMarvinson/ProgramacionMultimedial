<?php
session_start();
if(!isset($_SESSION['user_id'])){
    header('Location:login.php');
}
?>
<!DOCTYPE html>
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>Index</title>
	<style type="text/css" media="all">@import "http://localhost/PrimerParcial/programa1/estilos.css";</style>
</head>

	<div id="templatemo_container_wrapper">
		<div class="templatemo_spacer"></div>
	<div id="templatemo_container">
	<div id="templatemo_top"></div>
  	<div id="templatemo_header">
      <div id="inner_header">
        <div id="templatemo_site_title">Index</div>
     </div>
  	</div>

  	<body style=<?php echo '"background-color:'.$_SESSION['user_background'].'"';?> >
  	<div id="templatemo_left_column">
  		<div class="text_area" align="justify">
  		<div class="section_box2" align="justify">
	<div class="title">!Bienvenido
		<?php
		include "conexion.inc.php";
		$sql = "select * from identificador where ci = '".$_SESSION["user_id"]."'";
		$resultado = mysqli_query($conn, $sql);
		$fila = mysqli_fetch_row($resultado);
		echo $fila[1];
	?>!
	</div>

	</div>
	</div>
	<div class="text_area" align="justify">
	<div class="section_box2" align="justify">
	<p>Ejercicio realice lo mismo del punto (b) pero con PHP.</p>
	<table width="100%" border="3px solid purple">
		<tr bgcolor="#4040ff" style="color:#FFFFFF">
			<td>CH</td>
			<td>LP</td>
			<td>CB</td>
			<td>OR</td>
			<td>PT</td>
			<td>TJ</td>
			<td>SC</td>
			<td>BE</td>
			<td>PD</td>
			<td>TOTAL</td>
		</tr>	
	<?php
	include "conexion.inc.php";
	$sql = "select sum(n.nota >= 51 and i.lugarResidencia = '01') as CH, sum(n.nota >= 51 and i.lugarResidencia = '02') as LP, sum(n.nota >= 51 and i.lugarResidencia = '03') as CB, sum(n.nota >= 51 and i.lugarResidencia = '04') as ORU, sum(n.nota >= 51 and i.lugarResidencia = '05') as PT, sum(n.nota >= 51 and i.lugarResidencia = '06') as TJ, sum(n.nota >= 51 and i.lugarResidencia = '07') as SC, sum(n.nota >= 51 and i.lugarResidencia = '08') as BE, sum(n.nota >= 51 and i.lugarResidencia = '09') as PD, sum(n.nota >= 51) as TOTAL FROM identificador i, nota n, materia m  WHERE i.ci = n.ci and n.id_mat = m.id_mat";
	$resultado = mysqli_query($conn, $sql);
	$fila = mysqli_fetch_row($resultado);
	echo "<tr>";
	foreach ($fila as $value) {
		echo "<td>";
		echo $value;		
		echo "</td>";
	}
	echo "</td>";
	echo "</tr>";
	?>
	</table>
	</div>
</div>	
	</div>

	<div id="templatemo_right_column">
	<div class="section_box" align="justify">
		<div class="title">Foto de Perfil</div>
	<form action="validation.php" method="post">
		<img src = "<?php echo $_SESSION['user_img'];?>" width="120" height="80" class="templatemo_pic" />
		<table>
			<tr>
				<td>
					<select name="img">
						<option value="images/001.jpg">Básico</option>
						<option value="images/002.jpg">Nuevo</option>
					</select>
				</td>
				<td>
					<input type="submit" name="Cambiar" value="Cambiar">
				</td>
			</tr>
		</table>
	</form>
	</div>
	<div class="section_box" align="justify">
		<div class="title">Color de Fondo</div>
	<form action="validation.php" method="post">
		<table>
			<tr>
				<td>
				<select name="color">
    			<option value="#999999">Plomo</option> 
    			<option value="blue">Azul</option> 
    			<option value="red">Rojo</option> 
    			<option value="yellow">Amarillo</option> 
				</select>
				</td>
				<td>
				<input type="submit" name="Actualizar" value="Actualizar">
				</td>
			</tr>
		</table>
	</form>
	</div>

	<div class="section_box" align="justify">
	<form action="validation.php" method="post">
		<input type="submit" name="Salir" value="Salir">
	</form>
	</div>

	</div>
	<div id="templatemo_footer"></div>
	</div>
	</div>
</body>
</html>