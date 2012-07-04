<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Ejemplo1_GridviewSinCSSFriendly.ascx.cs" Inherits="modulos_Ejemplo1_GridviewSinCSSFriendly" %>
    <script type="text/javascript"">
        $(document).ready(function() {
            var txtFiltro = '#'+'<%=txtFiltro.ClientID %>';
            var grillaJedis = '#'+'ctl00_ContentPlaceHolder1_Ejemplo1_GridviewSinCSSFriendly1_GridViewJedis';
            $(txtFiltro).quicksearch(grillaJedis + ' tbody tr');
        });
    </script>
    
    <h3>
    Ejemplo 1: Gridview sin CSS Friendly
    </h3>
    <p><strong>NOTA</strong>: Aqui voy a aclarar que en el ejemplono tiene un gridview, sino una tabla html que es la copia 
        textual del renderizado de un gridview. Esto es para que en el mismo ejemplo 
        pueda colocar uno <a href="../Ejemplo2_GridviewConCSSFriendly.aspx">con</a> y 
        <a href="../Ejemplo1_GridviewSinCSSFriendly.aspx">sin</a> CSS Friendly Adapter.</p>
    
     Filtrar: <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>
    <br />
   <table cellspacing="0" rules="all" border="1" id="ctl00_ContentPlaceHolder1_Ejemplo1_GridviewSinCSSFriendly1_GridViewJedis" style="border-collapse:collapse;">
		<tr>
			<th scope="col">Nombre</th><th scope="col">Fecha Nacimiento</th><th scope="col">enlace</th>
		</tr><tr>
			<td>Yoda</td><td>896 BBY</td><td>

                      <img id="ctl00_ContentPlaceHolder1_Ejemplo1_GridviewSinCSSFriendly1_GridViewJedis_ctl02_ImagenUrl" src="http://images3.wikia.nocookie.net/starwars/images/thumb/4/45/Yoda.jpg/250px-Yoda.jpg" style="height:113px;width:80px;border-width:0px;" />
                      
                 </td>
		</tr><tr>
			<td>Obi-Wan &quot;Ben&quot; Kenobi</td><td>57 BBY</td><td>

                      <img id="ctl00_ContentPlaceHolder1_Ejemplo1_GridviewSinCSSFriendly1_GridViewJedis_ctl03_ImagenUrl" src="http://images2.wikia.nocookie.net/starwars/images/thumb/9/94/Obi-wan_headshot.jpg/250px-Obi-wan_headshot.jpg" style="height:113px;width:80px;border-width:0px;" />
                      
                 </td>
		</tr><tr>
			<td>Qui-Gon Jinn</td><td>92 BBY</td><td>

                      <img id="ctl00_ContentPlaceHolder1_Ejemplo1_GridviewSinCSSFriendly1_GridViewJedis_ctl04_ImagenUrl" src="http://images2.wikia.nocookie.net/starwars/images/thumb/c/c0/Quigonheadshot.jpg/250px-Quigonheadshot.jpg" style="height:113px;width:80px;border-width:0px;" />
                      
                 </td>
		</tr><tr>
			<td>Anakin Skywalker</td><td>41.9 BBY</td><td>

                      <img id="ctl00_ContentPlaceHolder1_Ejemplo1_GridviewSinCSSFriendly1_GridViewJedis_ctl05_ImagenUrl" src="http://images3.wikia.nocookie.net/__cb20090414190851/starwars/images/thumb/8/89/AnakinEstGrumpy.jpg/250px-AnakinEstGrumpy.jpg" style="height:113px;width:80px;border-width:0px;" />
                      
                 </td>
		</tr><tr>
			<td>Ki(-Adi - Mundi)</td><td>92 BBY</td><td>

                      <img id="ctl00_ContentPlaceHolder1_Ejemplo1_GridviewSinCSSFriendly1_GridViewJedis_ctl06_ImagenUrl" src="http://images3.wikia.nocookie.net/starwars/images/thumb/9/9e/KiAdiMundi.jpg/250px-KiAdiMundi.jpg" style="height:113px;width:80px;border-width:0px;" />
                      
                 </td>
		</tr>
	</table>