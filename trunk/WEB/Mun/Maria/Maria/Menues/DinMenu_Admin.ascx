<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DinMenu_Admin.ascx.cs" Inherits="Maria.Menues.DinMenu_Admin" %>
    
<link href="/Styles/Common.css" rel="stylesheet" type="text/css" />
  <link href="/Styles/Menu.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" language="javascript">
    
</script>

<div id="d1" style="width: 100%">

         <asp:Menu ID="NavigationMenu" StaticDisplayLevels="3" StaticSubMenuIndent="10" Orientation="Vertical"
        runat="server" MaximumDynamicDisplayLevels="2" Height="32%"
        Width="100%" ForeColor="#003300" Font-Names="Verdana" Font-Size="X-Small" 
                EnableViewState="False" >
        <LevelMenuItemStyles>
            <asp:MenuItemStyle BackColor="Black" ForeColor="#CCCCCC" Font-Bold = "True"/>
            <asp:MenuItemStyle BackColor="White" Font-Bold="True" BorderStyle="Outset" VerticalPadding="10" />
            <asp:MenuItemStyle BackColor="White" />
        </LevelMenuItemStyles>
        <LevelSelectedStyles>
            <asp:MenuItemStyle BackColor="#336699" ForeColor="#FFFFCC" />
            <asp:MenuItemStyle BackColor="#336699" ForeColor="#FFFFCC" />
            <asp:MenuItemStyle BackColor="#336699" ForeColor="#FFFFCC" />
        </LevelSelectedStyles>
        <Items>
            <asp:MenuItem NavigateUrl="" Text="Tramites" ToolTip="Tramites">
               
                    <asp:MenuItem NavigateUrl="/modules/Admin/Admin_CreateRichNews.aspx" Text="Crear nueva noticia"
                        ToolTip="Cree una nueva noticia" />
                    <asp:MenuItem NavigateUrl="/modules/Admin/Admin_ListEditorNews.aspx" Text="Buscar noticias"
                        ToolTip="Buscar noticias" />
            
              
            </asp:MenuItem>
        </Items>
    </asp:Menu>
 
    
</div>