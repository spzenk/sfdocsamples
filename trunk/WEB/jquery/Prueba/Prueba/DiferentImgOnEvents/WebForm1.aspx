<%@ Page Language="C#" AutoEventWireup="true"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<link href="style.css" rel="stylesheet" type="text/css" />
<script src="../JS/jquery-1.3.2.js" type="text/javascript"></script>
<script type ="text/javascript">
    $(document).ready(function () {

   
        $("#c").mouseenter(function () {
            $("#i").css("visibility", "visible");
//            $("#i").css("background-color", "White)");
        });
        $("#c").mouseleave(function () {
//            $("#i").css("background-color", "White)");
            $("#i").css("visibility", "hidden");
         
        });

//        $("#b").mouseenter(function () {
//           $("#i").css("background-image", "url('close_16.png')");
//       });

//        $("#b").mouseleave(function () {
//            $("#i").css("background-image", "url('close_carvon_16.png')");
//          
//        });

        $("#i").mouseenter(function () {
//            $("#i").css("background-color", "#768DD4");
            $("#i").css("background-image", "url('close_16.png')");
        });
        $("#i").mouseleave(function () {
//            $("#i").css("background-color", "White)");
            $("#i").css("background-image", "url('close_carvon_16.png')");
        });

    }); 
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
