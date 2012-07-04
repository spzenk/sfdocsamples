<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Ejemplo2_GridviewConCSSFriendly.ascx.cs" Inherits="modulos_Ejemplo2_GridviewConCSSFriendly" %>
    <script type="text/javascript"">
        $(document).ready(function() {
            var txtFiltro = '#'+'<%=txtFiltro.ClientID %>';
            var grillaJedis = '#'+'<%=GridViewJedis.ClientID %>';
            $(txtFiltro).quicksearch(grillaJedis + ' tbody tr');
        });
    </script>
    
    <h3>Ejemplo 2: Gridview <strong>con</strong> CSS Friendly</h3>
    <p><strong>NOTA</strong>: Aqui estoy utulizando un estilo especial con la propiedad 
        CSSSelectorClass (para utlizar las clases CSS de CSS Friendly Adapter)</p>
    
     Filtrar: <asp:TextBox ID="txtFiltro" runat="server"></asp:TextBox>
    <br />
    <asp:GridView ID="GridViewJedis" runat="server" CSSSelectorClass="YodaGrilla" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha Nacimiento" />
             <asp:TemplateField HeaderText="enlace">
                 <ItemTemplate>
                      <asp:Image ID="ImagenUrl" runat="server" ImageUrl='<%# Eval("ImagenURL") %>' Width="80px" Height="113px" />
                 </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>