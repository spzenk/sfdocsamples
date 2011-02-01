<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DinMenu_Tramites.ascx.cs" Inherits="Maria.Menues.DinMenu_Tramites" %>

  <link href="../Styles/Menu.css" rel="stylesheet" type="text/css" />
<div id="d1" style="width: 100%">

         <asp:Menu ID="NavigationMenu" StaticDisplayLevels="3" StaticSubMenuIndent="10" Orientation="Vertical"
        runat="server" MaximumDynamicDisplayLevels="2" Height="32%"
        Width="100%" ForeColor="#003300" Font-Names="Verdana" Font-Size="X-Small" 
                EnableViewState="False" >
        <LevelMenuItemStyles>
             <asp:MenuItemStyle BackColor="Black" ForeColor="#CCCCCC"  Font-Size =Larger Font-Bold="True" />
            <asp:MenuItemStyle BackColor="White" Font-Bold="False" BorderStyle="None" VerticalPadding="10" />
            <asp:MenuItemStyle BackColor="White" Font-Bold="False" BorderStyle="None" VerticalPadding="10" />
        </LevelMenuItemStyles>
        <LevelSelectedStyles>
            <asp:MenuItemStyle BackColor="#336699" ForeColor="#FFFFCC" />
            <asp:MenuItemStyle BackColor="#336699" ForeColor="#FFFFCC" />
            <asp:MenuItemStyle BackColor="#336699" ForeColor="#FFFFCC" />
        </LevelSelectedStyles>
        <Items>
            <asp:MenuItem NavigateUrl="" Text="Tramites" ToolTip="Tramites">
               
                    <asp:MenuItem NavigateUrl="~/Modules/Tramites/Tramites_LicenciaConducir.aspx" Text="Licencia de conducir"
                        ToolTip="Licencia de conducir" />
                    <asp:MenuItem NavigateUrl="~/Modules/Tramites/Tramites_Vehiculos.aspx" Text="Vehículos"
                        ToolTip="Vehículos" />
                    <asp:MenuItem NavigateUrl="~/Modules/Tramites/Tramites_Inmuebles.aspx"
                        Text="Inmuebles" ToolTip="Inmuebles" />
                  <asp:MenuItem NavigateUrl="~/Modules/Tramites/Tramites_RegistroCivil.aspx"
                        Text="Tramites de Registro Civil" ToolTip="Tramites de Registro Civil" />
            </asp:MenuItem>
        </Items>
    </asp:Menu>
 
    
</div>

