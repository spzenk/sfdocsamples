<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_News.master" AutoEventWireup="true" ValidateRequest ="false" CodeBehind="WebForm1.aspx.cs" Inherits="Maria.Modules.Noticias.WebForm1" EnableSessionState="False" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="../../js/tinymce/jscripts/tiny_mce/tiny_mce_src.js"></script>

    <script type="text/javascript" src="../../js/my.js"></script>

    <script type="text/javascript">
        function x(val) {


            alert(val);

        };
        tinyMCE.init({
            mode: "exact",
            elements: "ctl00$ctl00$ContentCenter$ContentPlaceHolder1$TextBox1, ctl00$ctl00$ContentCenter$ContentPlaceHolder1$TextBox2", //ctl00$ctl00$ContentCenter$ContentPlaceHolder1$TextBox1
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
    </script>
<div>
    <div id="Detail">
        <asp:TextBox ID="TextBox0" runat="server" Width="892px" onchange="javascript:GetText('f')"></asp:TextBox>
    </div>
    <br />
    <textarea runat="server" id="TextBox1" name="TextBox1" rows="8" cols="50"> Esto es el TextArea</textarea>
    <br />
    <asp:Label ID="lblResult1" runat="server"></asp:Label>
    <br />
    <asp:TextBox ID="TextBox2" Rows="10" Columns="50" TextMode="MultiLine" EnableViewState="false" Text="Esto es el TextBox" runat="server" onchange="javascript:x(this)"></asp:TextBox>
    <br />
    <asp:Label ID="lblResult2" runat="server"></asp:Label>
    <br />
    <asp:Button ID="btnCreateNew" runat="server" Text="Crear noticia" CssClass="btGrisNegrita" onclick="btnCreateNew_Click"  />
    </div>
</asp:Content>
