<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="main_menu_2.ascx.cs" Inherits="ShoppingCart.main_menu_2" %>
<script type="text/javascript" language="javascript">
    $(document).ready(function () {
        $('#img_search').click(function () {
            var s = $("#searchField").val();
            var path = Getrootpath('');
            document.location.href = path + '/News.aspx?t=' + s;
            return false;
        });
        $("#searchField").keydown(function (event) {
            if (event.which == 13) {
                $("#searchField").fadeIn();
                $("#searchField").focus().select();
                var s = $("#searchField").val();
                var path = Getrootpath('');
                document.location.href = path + '/News.aspx?t=' + s;
                return false;
            }
        });

    });
</script>
<div >
<ul id="menu"> 
   <li><a class="menuv_a"  href="/Default.aspx">Inicio</a> 
    </li> 
    <li><a class="menuv_a" href="/building.aspx">Supermercado</a> 
        <ul id="servicios"> 
   
            <li>
                <img class="corner_inset_left src" alt="" src="/img/corner_inset_left.png" />
                <a class="menuv_a" href="/building.aspx">Misión y visión</a>
                <img class="corner_inset_right src" alt="" src="/img/corner_inset_right.png" />
            </li>
                
              <li><a class="menuv_a" href="/building.aspx" title="Mision y vicion">Servicios y producción</a></li>
              <li><a class="menuv_a" href="/building.aspx" title="">Red El Delfin</a></li>
              <li><a class="menuv_a" href="/building.aspx" title="">Capital humano</a></li>
              <li><a class="menuv_a" href="/building.aspx" title="">Hacer pedidos </a></li>
             <li class ="last">
                <img class="corner_left src" alt="" src="/img/corner_left.png" />
                <img class="middle src" src="/img/dot.gif" alt=""/>
                <img class="corner_right src" alt="" src="/img/corner_right.png" />
            </li>
        </ul> 
    </li>
    <li><a class="menuv_a" href="/building.aspx">Supermercado</a>
        <ul id="cooperativa">
            <li>
                <img class="corner_inset_left src" alt="" src="/img/corner_inset_left.png" />
                <a class="menuv_a" href="/About.aspx">Quienes somos</a>
                <img class="corner_inset_right src" alt="" src="/img/corner_inset_right.png" />
            </li>
            <li><a class="menuv_a" href="/building.aspx">Contactar</a></li>
            
            <li><a class="menuv_a" href="/building.aspx">Hacer pedidos</a></li>
             <li class ="last">
                <img class="corner_left src" alt="" src="/img/corner_left.png" />
               <img class="middle src" src="/img/dot.gif" alt="" />
                <img class="corner_right src" alt="" src="/img/corner_right.png" />
            </li>
        </ul>
    </li>
         <li class="logo" >       
    </li> 
</ul> 
<div style="float:right">
                <a href="http://ar.linkedin.com/in/marcelooviedo" style="font-size: 12px;
                    text-decoration: none;"><span style="font: 80% Arial,sans-serif; color: #0783B6;">
                        <img src="http://www.linkedin.com/img/webpromo/btn_in_20x15.png" width="20" height="15"
                            alt="Ver el perfil de Marcelo Oviedo en LinkedIn" style="vertical-align: middle"
                            border="0" />Marcelo Oviedo</span></a>
                         </div>
</div>