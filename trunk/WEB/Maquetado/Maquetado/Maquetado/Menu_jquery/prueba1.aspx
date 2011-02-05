<%--
http://web.ontuts.com/tutoriales/creando-un-menu-desplegable-en-jquery/--%>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prueba1.aspx.cs" Inherits="Maquetado.Menu_jquery.prueba1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
     <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rel="stylesheet" type="text/css" href="styles/prueba1.css" />
    <link rel="stylesheet" type="text/css" href="styles/jquery.hrzAccordion.examples.css" />
    
    <script type="text/javascript" src="JS/jquery_1.4.js"></script>
        <script type="text/javascript" src="JS/prueba1.js"></script>
    <script type="text/javascript" src="JS/jquery.easing.1.3.js"></script>
    <script type="text/javascript" src="JS/jquery.hrzAccordion.js"></script>
    <script type="text/javascript" src="JS/jquery.hrzAccordion.examples.js"></script>

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
    </form>
</body>
</html>
