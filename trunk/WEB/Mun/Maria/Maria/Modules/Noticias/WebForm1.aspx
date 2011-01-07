<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_News.master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Maria.Modules.Noticias.WebForm1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" src="../../js/tinymce/jscripts/tiny_mce/tiny_mce_src.js"></script>

    <script type="text/javascript" src="../../js/my.js"></script>

    <script type="text/javascript">
        function x(val) {

            //            texto = document.getElementById('ctl00$ctl00$ContentCenter$ContentPlaceHolder1$txtBody');
            //texto = document.getElementById('ctl00_ctl00_ContentCenter_ContentPlaceHolder1_txtBody');
            //texto = document.getElementById('ctl00_ctl00_ContentCenter_ContentPlaceHolder1_txtBody');

            //  texto = document.getElementById('ctl00_ctl00_ContentCenter_ContentPlaceHolder1_txtBody_ifr');
            // texto = document.getElementById('ctl00$ctl00$ContentCenter$ContentPlaceHolder1$txtBody');
            //
            //alert(texto.value);
            alert(val);
            //alert('Check value when posting: ' + TextBox1.vslue);
            //return TextBox1.value;
        };
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
    </script>

    <div id="Detail">
        <asp:TextBox ID="TextBox1" runat="server" Width="892px" onchange="javascript:GetText('f')"></asp:TextBox>
    </div>
    <textarea runat="server" id="txtBody" name="txtBody" rows="8" cols="50" onchange="javascript:x('d')"></textarea><asp:TextBox ID="TextBox2" Rows="10" Columns="50" TextMode="MultiLine" EnableViewState="false"
        Text="Write something here..." runat="server" onchange="javascript:x('d')"></asp:TextBox>
&nbsp;<asp:Button ID="btnCreateNew" runat="server" Text="Crear noticia" OnClick="btnCreateNew_Click"  OnClientClick="x('TextBox2');" CssClass="btGrisNegrita"  />
</asp:Content>
