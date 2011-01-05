<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_Admin.master" AutoEventWireup="true" CodeBehind="Admin_CreateNews.aspx.cs" Inherits="Maria.Modules.Admin.Admin_CreateNews" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register src="../../Usercontrol/News_Simple_Creator.ascx" tagname="News_Simple" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" src="../../Usercontrol/tinymce/jscripts/tiny_mce/tiny_mce_src.js"></script>
    <script type="text/javascript" >
        tinyMCE.init({
            mode: "textareas",
            elements: "TextBox1", //ctl00$cphMP_SuenoCelesteMain$dvwDetail$txtBody
            theme: "advanced",
            language: "es",
            plugins: "style,layer,table,save,advhr,advimage,advlink,emotions,spellchecker,iespell,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,preview",

            // Theme options - button# indicated the row# only
            theme_advanced_buttons3_add: "tablecontrols",
            table_styles: "Header 1=header1;Header 2=header2;Header 3=header3",
            table_cell_styles: "Header 1=header1;Header 2=header2;Header 3=header3;Table Cell=tableCel1",
            table_row_styles: "Header 1=header1;Header 2=header2;Header 3=header3;Table Row=tableRow1",

            theme_advanced_buttons1: "newdocument,|,bold,italic,underline,|,justifyleft,justifycenter,justifyright,fontselect,fontsizeselect,formatselect",
            theme_advanced_buttons2: "cut,copy,paste,|,bullist,numlist,|,outdent,indent,|,undo,redo,|,link,unlink,anchor,image,|,code,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "insertdate,inserttime,|,spellchecker,advhr,,removeformat,|,sub,sup,|,charmap,emotions",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom"
        });
    </script >
   <uc1:News_Simple ID="News_Simple1" runat="server" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
