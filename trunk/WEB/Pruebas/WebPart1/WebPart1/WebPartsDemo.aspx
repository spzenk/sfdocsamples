<%@ Page Language="C#" %>
<%@ register tagprefix="uc1" tagname="SearchUserControl"   src="SearchUserControl.ascx" %>
<%@ register TagPrefix="uc2"   TagName="DisplayModeMenuCS"   Src="DisplayModeMenu.ascx" %>



<html>
<head id="Head1" runat="server">
  <title>Web Parts Page</title>
</head>
<body>
  <h1>Pagina principal de Action Line </h1>
  <form runat="server" id="form1">
  <asp:webpartmanager id="WebPartManager1" runat="server" />
  <uc2:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />

  <br />
  <table cellspacing="0" cellpadding="0" border="0">
    <tr>
   
      <td valign="top">
       <asp:webpartzone id="SideBarZone" runat="server" headertext="Sidebar" 
              BorderColor="#CCCCCC" Font-Names="Verdana" Padding="6">
        
           <EmptyZoneTextStyle Font-Size="0.8em" />
           <PartStyle Font-Size="0.8em" ForeColor="#333333" />
           <TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White" />
           <MenuLabelHoverStyle ForeColor="#E2DED6" />
           <MenuPopupStyle BackColor="#5D7B9D" BorderColor="#CCCCCC" BorderWidth="1px" 
               Font-Names="Verdana" Font-Size="0.6em" />
           <MenuVerbStyle BorderColor="#5D7B9D" BorderStyle="Solid" BorderWidth="1px" 
               ForeColor="White" />
           <PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" 
               ForeColor="White" />
        
        <zonetemplate>
        <asp:label runat="server" id="linksPart" title="Links">
          <a href="http://www.actionline.biz/">Action Line</a> 
          <br/>
              <a href="http://www.prominente.com.ar/">Prominente</a> 
              <br />
              <a href="http://www.tycon.com.ar/">Tycon</a> 
              <br />
              <a href="http://www.intertron.com.ar/IntertronWeb">Intertron</a> 
              <br />
              
                <br />
           </asp:label>
            <uc1:SearchUserControl id="searchPart" runat="server" title="Busqueda"/>

        </zonetemplate>
          
           <MenuVerbHoverStyle BackColor="#F7F6F3" BorderColor="#CCCCCC" 
               BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" />
           <PartChromeStyle BackColor="#F7F6F3" BorderColor="#E2DED6" Font-Names="Verdana" 
               ForeColor="White" />
           <HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" HorizontalAlign="Center" />
           <MenuLabelStyle ForeColor="White" />
          
      </asp:webpartzone>
      </td>
      <td valign="top">
      

       <asp:webpartzone id="MainZone" runat="server" headertext="Main" Height="140px" 
              Width="593px" BorderColor="#CCCCCC" Font-Names="Verdana" Padding="6">
             <EmptyZoneTextStyle Font-Size="0.8em" />
             <PartStyle Font-Size="0.8em" ForeColor="#333333" />
             <TitleBarVerbStyle Font-Size="0.6em" Font-Underline="False" ForeColor="White" />
             <MenuLabelHoverStyle ForeColor="#E2DED6" />
             <MenuPopupStyle BackColor="#5D7B9D" BorderColor="#CCCCCC" BorderWidth="1px" 
                 Font-Names="Verdana" Font-Size="0.6em" />
             <MenuVerbStyle BorderColor="#5D7B9D" BorderStyle="Solid" BorderWidth="1px" 
                 ForeColor="White" />
             <PartTitleStyle BackColor="#5D7B9D" Font-Bold="True" Font-Size="0.8em" 
                 ForeColor="White" />
             <zonetemplate>
             
                 <asp:label id="contentPart" runat="server" title="Contenido">
                  <h2>Bienbenido al sitio de Action Line</h2>
                  <p>Sitios preferidos</p>
                </asp:label>
                
             </zonetemplate>
             <MenuVerbHoverStyle BackColor="#F7F6F3" BorderColor="#CCCCCC" 
                 BorderStyle="Solid" BorderWidth="1px" ForeColor="#333333" />
             <PartChromeStyle BackColor="#F7F6F3" BorderColor="#E2DED6" Font-Names="Verdana" 
                 ForeColor="White" />
             <HeaderStyle Font-Size="0.7em" ForeColor="#CCCCCC" HorizontalAlign="Center" />
             <MenuLabelStyle ForeColor="White" />
     </asp:webpartzone>

      </td>
      <td valign="top">
      
          <asp:editorzone id="EditorZone1" runat="server">
            <zonetemplate>
              <asp:appearanceeditorpart runat="server" id="AppearanceEditorPart1" />
              <asp:layouteditorpart runat="server" id="LayoutEditorPart1" />
            </zonetemplate>
          </asp:editorzone>
          <asp:catalogzone id="CatalogZone1" runat="server" 
  headertext="Add Web Parts">
          <zonetemplate>
            <asp:declarativecatalogpart id="catalogpart1" runat="server" Title="Catalogo">
              <webPartsTemplate>
                 <asp:fileupload runat="server" id="upload1" title="Archivos subidos" />
                 <asp:calendar runat="server" id="cal1" Title="Calendario de equipo" />
                 <asp:Label runat= "server" id = "tsticks" title="Notas" ToolTip ="Agrega tus notas para recordatorios"/>
              </webPartsTemplate>
            </asp:declarativecatalogpart>
          </zonetemplate>
        </asp:catalogzone>
        </td>
      
    </tr>
  </table>
  </form>
</body>
</html>