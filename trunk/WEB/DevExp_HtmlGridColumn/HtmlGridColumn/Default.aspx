<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<%@ Register assembly="DevExpress.Web.ASPxGridView.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
      Mostrar datos Html  en grid view
    </h2>
    <dx:ASPxGridView ID="ASPxGridView1" runat="server" 
            AutoGenerateColumns="False" Width="515px">
            <Columns>
                <dx:GridViewDataTextColumn Caption="Texto Formateado" VisibleIndex="0" FieldName="col1">
                </dx:GridViewDataTextColumn>
            </Columns>
        </dx:ASPxGridView>
    
</asp:Content>
