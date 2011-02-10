<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo1.aspx.cs" Inherits="Prueba.Slider_fotos_videos.Demo1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>



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
 <link media="screen" type="text/css" href="css/anythingslider.css" rel="stylesheet">
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
            Demo 3: Sliding Captions</h2>
        <!-- AnythingSlider #3 -->
        <ul id="slider3">
            <li>
                <!-- Note this caption is before the image, all others it is after -->
                <div class="caption-top">
                    In Soviet Russia, concrete pours you!</div>
                <img src="images/slide-civil-1.jpg" alt="" />
            </li>
            <li>
                <img src="images/slide-env-1.jpg" alt="" />
                <div class="caption-right">
                    How many supervisors are there? Wrong! 5, who is taking the picture?</div>
            </li>
            <li>
                <img src="images/slide-civil-2.jpg" alt="" />
                <div class="caption-bottom">
                    Alas, the pylon would never make it to the hydrant, her true love.</div>
            </li>
            <li>
                <img src="images/slide-env-2.jpg" alt="" />
                <div class="caption-left">
                    Take a left at the traffic circle.</div>
            </li>
        </ul>
    </div>
    </form>
</body>
</html>
