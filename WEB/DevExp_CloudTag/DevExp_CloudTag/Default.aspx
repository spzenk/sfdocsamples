<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="DevExp_CloudTag._Default" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxEditors" tagprefix="dx" %>

<%@ Register assembly="DevExpress.Web.v11.1, Version=11.1.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxCloudControl" tagprefix="dx" %>



<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to Allus Global Bpo test
     
    </h2>
    <div>

    
    <dx:ASPxCloudControl ID="ASPxCloudControl1" runat="server" DataSourceID="ObjectDataSource1"
        Width="51%" NavigateUrlField="Url" NavigateUrlFormatString="javascript:void('{0}')"
        TextField="Text" ValueField="Priority" EnableViewState="False" 
            OnItemDataBound="ASPxCloudControl1_ItemDataBound" BackColor="#333333" 
            MinColor="#990000" onitemclick="ASPxCloudControl1_ItemClick">
        <RankProperties>
<dx:RankProperties></dx:RankProperties>
<dx:RankProperties></dx:RankProperties>
<dx:RankProperties></dx:RankProperties>
<dx:RankProperties></dx:RankProperties>
<dx:RankProperties></dx:RankProperties>
<dx:RankProperties></dx:RankProperties>
<dx:RankProperties ValueColor="#CC0066"></dx:RankProperties>
</RankProperties>
        <LinkStyle Color="#CC3300">
        </LinkStyle>
        <Border BorderColor="#003300" />
    </dx:ASPxCloudControl>
     
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="RetriveTags" TypeName="DevExp_CloudTag.DAC">
        </asp:ObjectDataSource>
</div>
    <p>
        To learn more about please redirect to <a href="http://www.allus.com.ar" title="Allus web dev ">Allus web dev</a>.
    </p>
    <p>
        You can also send an e-mail to <a href="mailto:marcelo.oviedo@allus.com.ar"
            title="Developers">Marcelo F Oviedo</a>.
    </p>
</asp:Content>
