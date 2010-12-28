<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DinMenu.ascx.cs" Inherits="Maria.Menues.DinMenu" %>
<asp:menu id="NavigationMenu"
        staticdisplaylevels="3"
        staticsubmenuindent="10" 
        orientation="Vertical"
        target="_blank"  
        runat="server" MaximumDynamicDisplayLevels="2">

        <LevelSelectedStyles>
            <asp:MenuItemStyle BackColor="White" BorderStyle="None" Font-Underline="False" 
                ForeColor="#003300" />
        </LevelSelectedStyles>
     <dynamicmenustyle backcolor="LightSkyBlue"
          forecolor="Black"
          borderstyle="Solid"
          borderwidth="1"
          bordercolor="Black" />

      

        <items>
          <asp:menuitem navigateurl="" 
            text="Municipalidad"
            tooltip="Municipalidad">
            <asp:menuitem 
              text="Institucional"
              tooltip="Institucional">
              <asp:menuitem navigateurl="\modules\Municipalidad\Muni_Inst_Cultura.aspx" 
                text="Cultura"
                tooltip="Cultura"/>
              <asp:menuitem navigateurl="\modules\Municipalidad\Muni_Inst_MedioAmbiente.aspx"
                text="Medio Ambiente"
                tooltip="Medio Ambiente"/>
               <asp:menuitem navigateurl="\modules\Municipalidad\Muni_Inst_Promocion_Social.aspx" 
                text="Promoción Social"
                tooltip="Promoción Social"/>
            </asp:menuitem>
            <asp:menuitem navigateurl=""
              text="Obras de Gobierno"
              tooltip="Obras de Gobierno">
              <asp:menuitem navigateurl="\modules\Municipalidad\Muni_Inst_ObrasConstrucción.aspx"
                text="Obras en Construcción"
                tooltip="Obras en Construcción"/>
              <asp:menuitem navigateurl="\modules\Municipalidad\Muni_Inst_ObrasPlanificadas.aspx"
                text="Obras Planificadas"
                tooltip="Obras Planificadas"/>
            </asp:menuitem>
          </asp:menuitem>
        </items>

      </asp:menu>