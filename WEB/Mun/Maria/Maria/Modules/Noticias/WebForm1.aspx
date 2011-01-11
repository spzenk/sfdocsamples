<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_News.master" AutoEventWireup="true" ValidateRequest ="false" CodeBehind="WebForm1.aspx.cs" Inherits="Maria.Modules.Noticias.WebForm1" EnableSessionState="False" %>


<%@ Register src="../../Usercontrol/News_SimpleView.ascx" tagname="News_SimpleView" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="../../js/tinymce/jscripts/tiny_mce/tiny_mce_src.js"></script>

    <script type="text/javascript" src="../../js/my.js"></script>

    

    <div id="Detail">

     
    </div>
    <uc1:News_SimpleView ID="News_SimpleView1" runat="server" />
    <br />
    
    
   
</asp:Content>
