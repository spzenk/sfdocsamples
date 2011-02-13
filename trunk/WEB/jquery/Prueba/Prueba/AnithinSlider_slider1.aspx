<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AnithinSlider_slider1.aspx.cs" Inherits="Prueba.AnithinSlider_slider1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-type" content="text/html; charset=utf-8" />
    <title>Ejemplos de jQuery Sliders</title>
    <!-- jQuery (required) & jQuery UI (for this demo only) -->
    <link rel="stylesheet" href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" type="text/css" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js"></script>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"></script>


  <script type="text/javascript">
      
          $(function () {
        $('#slider1').anythingSlider({
        buildNavigation: true,
        themeDirectory: 'Slider_fotos_videos/css/theme-{themeName}.css',
            theme: 'metallic'
        });
    });
    </script>
 
 
    <!-- Anything Slider optional plugins -->
    <script type="text/javascript" src="Slider_fotos_videos/js/jquery.easing.1.2.js"></script>
    <script type="text/javascript" src="Slider_fotos_videos/js/swfobject.js"></script>
    
    <!-- Anything Slider -->
    <link rel="stylesheet" href="Slider_fotos_videos/css/anythingslider.css" type="text/css"    media="screen" />
    
    <!-- AnythingSlider optional FX extension -->
    <script type="text/javascript" src="Slider_fotos_videos/js/jquery.anythingslider.fx.min.js"></script>

    <!-- Demos page only -->
    <link rel="stylesheet" href="Slider_fotos_videos/css/page.css" type="text/css" media="screen" />
    <link rel="stylesheet" href="Slider_fotos_videos/colorbox/colorbox.css" type="text/css" media="screen" />
    <script type="text/javascript" src="Slider_fotos_videos/js/demo.js"></script>
    <script type="text/javascript" src="Slider_fotos_videos/colorbox/jquery.colorbox-min.js"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h2 class="title">Slider desde un directorio diferente</h2>
        
        <ul id="slider1">
            <li>
                <img src="Slider_fotos_videos/images/slide-civil-1.jpg" alt="" /></li>
            <li>
                <img src="Slider_fotos_videos/images/slide-env-1.jpg" alt="" /></li>
            <li>
                <img src="Slider_fotos_videos/images/slide-civil-2.jpg" alt="" /></li>
            <li>
                <img src="Slider_fotos_videos/images/slide-env-2.jpg" alt="" /></li>
        </ul>
    </div>
    </form>
</body>
</html>
