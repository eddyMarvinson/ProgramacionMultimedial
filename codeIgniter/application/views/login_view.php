<!DOCTYPE html>  
<html>  
<head>  
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Login</title>
    <style type="text/css">
    body {
        margin:0;
        padding:0;
        line-height: 1.5em;
        font-family: "Trebuchet MS", Verdana, Helvetica, Arial;
        font-size: 12px;
        color: #000000;
        background: #999999;
    }
    
    a:link, a:visited { color: #0066CC; text-decoration: none} 
    a:active, a:hover { color: #008800; text-decoration: underline}

    #templatemo_container_wrapper {
        background: #999999;
    }
    #templatemo_container {
        width: 810px;
        margin: 0px auto;
        background: #FFFFFF;
    }
    #templatemo_top {
        clear: left;
        height: 25px;
        padding-top: 42px;
        padding-left: 30px;
        background: #a2cadf;
    }
    #templatemo_header {
        clear: left;
        height: 179px;
        text-align: center;
        background: #a2cadf;
    }
    #inner_header {
        height: 160px;
        background: #2271b3;
    }
    #templatemo_left_column {
        clear: left;
        float: left;
        width: 540px;
        padding-left: 20px;
    }
    #templatemo_right_column {
        float: right;
        width: 216px;
        padding-right: 15px;
    }
    #templatemo_footer {
        clear: both;
        padding-top: 18px;
        height: 37px;
        text-align: center;
        font-size: 11px;
        background: #a2cadf;
        color: #666666;
    }
    #templatemo_footer a {
        color: #666666;
    }

    #templatemo_site_title {
        padding-top: 65px;
        font-weight: bold;
        font-size: 32px;
        color: #FFFFFF;
    }
    .templatemo_spacer {
        clear: left;
        height: 18px;
    }
    .section_box2 {
        clear: left;
        margin-top: 10px;
        background: #F6F6F6;
        color: #000000;
    }
    .text_area {
        padding: 10px;
    }

    .title {
        padding-bottom: 12px;
        font-size: 18px;
        font-weight: bold;
        color: #0066CC;
    }

    form label{
        width:72px;
        font-weight:bold;
    }

    form input[type="text"],
    form input[type="password"]{
        width:180px;
        padding:3px 10px;
        border:1px solid #000000;
        border-radius:2px #000000;
        margin:8px 0;
    }

    form input[type="submit"]{
        width:100%;
        padding:5px 10px;
        border:1px solid #000;
        border-radius:5px;
        color:#fff;
        background-color:#000;
    } 
    form input[type="reset"]{
        width:100%;
        padding:6px 12px;
        border:1px solid #000;
        border-radius:4px;
        color:#000000;
        background-color:#FFFFFF;
    } 

    form input[type="submit"]:hover{
        cursor:pointer;
    }
    </style>
</head>

<body>
    <?php echo isset($error) ? $error : ''; ?>  
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
    <form method="post" action="<?php echo site_url('Login/process'); ?>">  
        <table>
        <tr>
            <td><label>Usuario</label></td>
            <td><input type="text" name="user"></td>
        </tr>
        <tr>
            <td><label>Contraseña</label></td>
            <td><input type="password" name="pass"></td>
        </tr>
        </table>
        <table>
            <tr>
            <td><input type="submit" value="Login"></td>  
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