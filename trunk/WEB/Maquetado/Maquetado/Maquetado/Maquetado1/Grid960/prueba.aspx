<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="prueba.aspx.cs" Inherits="Maquetado.Maquetado1.prueba" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="css/text.css" rel="stylesheet" type="text/css" />
    <link href="css/reset.css" rel="stylesheet" type="text/css" />
    <link href="css/960.css" rel="stylesheet" type="text/css" />
    <link href="prueba.aspx" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
   <div id="top">
    <!--empiezo con mi contenedor de 12 columnas-->
    <div class="container_12">
        <!--agrego un div que va ha estar ubicado 720px a la derecha y va tener un ancho de 220px-->
        <div class="grid_3 prefix_9">
        </div><!--grid_3-->
        <div class="clear"></div>
    </div><!--container_12-->
</div><!--top-->
<!--luego creo otro contenedor de 960px-->
<div class="container_12" id="bodyMain">
    <!--agrego un div de 960px, recordemos que son 940px los que podemos utilizar, por los márgenes-->
    <div class="grid_12" id="header">
        <a id="logo" title="Vos-Vos" href="#"></a>
        <img id="ciudad-logo" alt="VV City" src="images/ciudad-logo.gif"/>
    </div>
    <div class="clear"></div>
    <!--hago lo mismo para el menu, ya que se despliega por todo el layout-->
    <div class="grid_12" id="menu">
    </div><!--menu-->
    <!--lo mismo ... observen que cada uno de los grid_12 tienen un ID que les da su estilo-->
    <div class="grid_12" id="contentMain">
        <!--separo en una columna de 620px y le agrego el alpha porque es la primera columna-->
    	<div class="grid_8 alpha">
            <!--divido en 2, como se dan cuenta la primera tiene alpha-->
            <div class="grid_4 alpha">
            </div>
            <!--la ultima tiene el omega-->
            <div class="grid_4 omega">
            </div>
        </div>
        <!--tenia una columna de 620px, esta es de los restantes 940px-->
        <div class="grid_4 omega">
        </div>
        <div class="clear"></div>
    </div><!--contentMain-->
    <div class="clear"></div>
    <!--como se dan cuenta, aquí muevo mi div de 300px o grid_4 ocho columnas a la derecha (640px)-->
    <div class="grid_4 prefix_8" id="footer">
    </div><!--footer-->
</div><!--bodyMain-->
    </form>
</body>
</html>
