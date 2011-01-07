<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_News.master" AutoEventWireup="true" CodeBehind="Admin_CreateRichNews.aspx.cs" Inherits="Maria.Modules.Admin.Admin_CreateRichNews" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register src="../../Usercontrol/News_Rich_Creator.ascx" tagname="News_Rich_Creator" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="../../js/tinymce/jscripts/tiny_mce/tiny_mce_src.js"></script>
    <script type="text/javascript" >
        tinyMCE.init({
        mode: "textareas",
        elements: "ctl00_ctl00_ContentCenter_ContentPlaceHolder1_News_Rich_Creator1_txtBody,ctl00$ctl00$ContentCenter$ContentPlaceHolder1$News_Rich_Creator1$txtBody", //ctl00$cphMP_SuenoCelesteMain$dvwDetail$txtBody
            theme: "advanced",
            language: "es",
            entity_encoding : 'raw',
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
        function SaveMyPreciousValues() {

             tinyMCE.triggerSave(false, true);
             x = document.getElementById('ctl00_ctl00_ContentCenter_ContentPlaceHolder1_News_Rich_Creator1_txtBody');
            alert(x.value);
            document.getElementById('htmlTextValue').value = 'dasdasdad';

            alert(document.getElementById('htmlTextValue').value);
        
        };
        function x(txtName) {

            txtArea = document.getElementById(txtName);
            alert(txtArea.value);

        };  
        function GetText2(txtName) {

            tinyMCE.triggerSave(false, true);
            txtArea = document.getElementById(txtName);
            
            return txtArea.value;

        };
    </script >
    <input type="hidden" name="htmlTextValue" value="0" />
    <uc1:News_Rich_Creator ID="News_Rich_Creator1" runat="server" />
</asp:Content>
