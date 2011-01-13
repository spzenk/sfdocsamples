<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_Admin.master" AutoEventWireup="true" CodeBehind="Admin_ListEditorNews.aspx.cs" Inherits="Maria.Modules.Admin.Admin_ListEditorNews" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div>

<div class="NewsHeaderTitle">
<h1>Ingrece parte del título de la noticia</h1>
</div>
    <div class="NewsHeaderTitle">
        <span id="spam2">
            <asp:TextBox ID="txtSearch" runat="server" Width="323px"></asp:TextBox>
        </span><span id="Span1">
            <asp:ImageButton ID="btnSeach" runat="server" ImageUrl="../../Images/search.png"
                Text="buscar" OnClick="btnSeach_Click" Height="20px" /></span>
    </div>
            <asp:Panel ID="pnlNewscontainer" runat="server">
            </asp:Panel>
    
</div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
