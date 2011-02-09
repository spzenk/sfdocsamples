<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Prueba.Menu_jquery.Menu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
     <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
      
  <link rel="stylesheet" type="text/css" href="styles/black-menu-style.css" />
         <script type="text/javascript" src="../JS/jquery-1.5.js"></script>
     
</head>

<body>
    <form id="form1" runat="server">
    
     <div class="wrapper">  
        <h1>Creando un menú desplegable en jQuery</h1>  
        <ul class="dropdown">  
            <li class="active">Visualizando: <span>Tutoriales</span></li>  
            <li class="first"><a href="#">Recursos</a></li>  
            <li><a href="#">Inspiración</a></li>  
            <li><a href="#">Contacto</a></li>  
            <li class="last"><a href="#">Ver más...</a></li>  
        </ul>  

    </div>
       <script type="text/javascript" src="../JS/black-menu.js"></script>
 
    </form>
</body>
</html>
