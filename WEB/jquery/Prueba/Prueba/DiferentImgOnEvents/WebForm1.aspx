<%@ Page Language="C#" AutoEventWireup="true"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link href="style.css" rel="stylesheet" type="text/css" />
<%--<script src="../JS/jquery-1.3.2.js" type="text/javascript"></script>--%>
    <script src="../JS/jquery-1.5.js" type="text/javascript"></script>
<script type ="text/javascript">
    $(document).ready(function () {
        //$("#i").css("visibility", "visible");
       // $("#i").css("visibility", "none");
        $(this).find('#b').stop(true, true).fadeOut();

        //Determina el inicio
        var start = 1;

        // Evento HOVER del #c
//////////        $("#c").hover(
//////////        function () {
//////////            //            $("#b").stop().fadeTo(500);
//////////            //            $("#i").stop().fadeTo(500);
//////////            if (start = 1) { 
//////////                $("#i").css("visibility", "visible"); //Se ejecuta solo una vez
//////////                start = 0;
//////////            }

//////////            $("#b").fadeTo(500, 1);
//////////            $("#i").fadeTo(500, 1);
//////////        },
//////////        function () {
//////////            //            $("#b").stop().fadeTo(500);
//////////            //            $("#i").stop().fadeTo(500);
//////////            $("#b").fadeTo(500, 0);
//////////            $("#i").fadeTo(500, 0);
//////////        });

        //MOUSE ENTER Y MOUSE LEAVE DE i
        $("#i").mouseenter(function () {
            //$("#img").append("background-color", "#768DD4");
            $("#i").css("background-image", "url('close_16.png')"); //.fadeTo(500, 1);
        });
        $("#i").mouseleave(function () {
            //            $("#.img").css("background-color", "#FFFFFF)");
            $("#i").css("background-image", "url('close_carvon_16.png')").fadeOut(1000, 1);

        });


        $('#c').hover(function () {
            if (start = 1) {
                $("#i").css("visibility", "visible"); //Se ejecuta solo una vez
                start = 0;
            }
            //$(this).find('#i').stop(true, true).fadeIn();
            //$(this).find('#b').stop(true, true).fadeIn();
            $("#i").stop(true, true).fadeIn();
            $('#b').stop(true, true).fadeIn();

        }, function () {
//            $(this).find('#i').stop(true, true).fadeOut();
//            $(this).find('#b').stop(true, true).fadeOut();
            $("#i").stop(true, true).fadeOut();
            $("#b").stop(true, true).fadeOut();
        });

    }); 

    //la velocidad de la animación debes modificar los valores de fadeTo(500).
</script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id ="c" class ="content" >
     <div id = "b" class ="barra" >
      <div id = "i" class ="img" ></div>
    </div>
    </div>
    </form>
</body>
</html>
