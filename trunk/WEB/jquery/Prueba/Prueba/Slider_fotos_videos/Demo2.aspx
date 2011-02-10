<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo2.aspx.cs" Inherits="Prueba.Slider_fotos_videos.Demo2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
   
 <meta content="text/html; charset=utf-8" http-equiv="Content-type">

 <title>AnythingSlider FX Demos</title>

 <!-- jQuery (required) & jQuery UI (for this demo only) -->
 <link type="text/css" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet">
 <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js" type="text/javascript"></script>
 <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type="text/javascript"></script>

 <!-- Anything Slider optional plugins -->
 <script src="js/jquery.easing.1.2.js" type="text/javascript"></script>
 <script src="js/swfobject.js" type="text/javascript"></script> <!-- http://ajax.googleapis.com/ajax/libs/swfobject/2.2/swfobject.js -->
 
 <!-- Anything Slider -->
 <link  type="text/css" href="css/anythingslider.css" rel="stylesheet">
 <script src="js/jquery.anythingslider.js" type="text/javascript"></script>

 <!-- AnythingSlider optional FX extension -->
 <script src="js/jquery.anythingslider.fx.min.js" type="text/javascript"></script>
 
 <!-- Demos page only -->
 <link rel="stylesheet" href="css/page.css" type="text/css" media="screen" />
 <link rel="stylesheet" href="colorbox/colorbox.css" type="text/css" media="screen" />
 <script type="text/javascript" src="js/demo.js"></script>
 <script type="text/javascript" src="colorbox/jquery.colorbox-min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
      <div>
        <h2 class="title">
            Demo 2: Thumbnails & A Lightbox and Captions</h2>
        <!-- AnythingSlider #3 -->
        <ul id="slider1">
          <li><img src="images/slide-civil-1.jpg" alt="" /></li>
       <li><img src="images/slide-env-1.jpg" alt="" /></li>
       <li><img src="images/slide-civil-2.jpg" alt="" /></li>
       <li><img src="images/slide-env-2.jpg" alt="" /></li>
        </ul>
    </div>
    </form>
</body>
</html>
