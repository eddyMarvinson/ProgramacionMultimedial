<!DOCTYPE html>  
<html>  
<head>  
    <title>Welcome</title>  
</head>  
	<h1>!Bienvenido
    <?php echo $this->session->userdata('user'); ?>!
    </h1> 
	<?php 
	echo '<body style="background-color:'.$this->session->userdata('color').'">';
	?>	
    <form action="<?php echo site_url('Login/update'); ?>" method="post">
		<table>
			<tr>
				<td>
				<select name="color">
    			<option value="blue">Azul</option> 
    			<option value="red">Rojo</option> 
    			<option value="yellow">Amarillo</option> 
				</select>
				</td>
				<td>
				<input type="submit" value="Update">
				</td>
			</tr>
		</table>
	</form>
	<?php echo anchor('Login/logout', 'Salir'); ?>
</body>  
</html>  