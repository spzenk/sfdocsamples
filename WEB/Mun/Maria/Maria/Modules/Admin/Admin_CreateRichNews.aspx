<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_News.master" AutoEventWireup="true"  ValidateRequest ="false" CodeBehind="Admin_CreateRichNews.aspx.cs" Inherits="Maria.Modules.Admin.Admin_CreateRichNews" EnableSessionState="False" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script  type="text/javascript" src="../../js/tinymce/jscripts/tiny_mce/tiny_mce_src.js"></script>
    <script type="text/javascript" >
        tinyMCE.init({
        mode: "exact",
        elements: "ctl00$ctl00$ContentCenter$ContentPlaceHolder1$txtBody,ctl00$ctl00$ContentCenter$ContentPlaceHolder1$TextBox1, ctl00$ctl00$ContentCenter$ContentPlaceHolder1$TextBox2", //ctl00$cphMP_SuenoCelesteMain$dvwDetail$txtBody
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
  <div id="Div3" class ="EnvelopeContNews">

        <div id="Div4" class="EnvelopeNews">

             
                        <asp:Panel ID="pnlContent" runat="server" Height="100%">
                            <asp:Panel ID="pnHeader" runat="server" CssClass="cpHeaderStatic">
                                <asp:Label ID="Label1" runat="server" Text="Nueva noticia" />
                          </asp:Panel>
                        <asp:Panel ID="pnlBody" runat="server" CssClass="EnvelopeNewsBody">
                           
                                      <div><asp:Label ID="Label2" runat="server" Text="Titulo " /></div>
                                        
                                   <div>
                                   <textarea runat="server" id="txtTitle" name="txtTitle" cols ="10"
                                            style="width: 546px; height: 39px"> </textarea>
                                      
                              </div>
                                        <asp:Label ID="lblComments" runat="server" Text="Texto " />
                                      <div>
                                     <textarea runat="server" id="txtBody" name="txtBody" cols ="10"
                                            style="width: 546px; height: 39px"> </textarea>
                                    
                             
                            </div>
                           
                          <div>
                            <asp:Button ID="btnCreateNew" runat="server" Text="Crear noticia" OnClick="btnCreateNew_Click"   CssClass="btGrisNegrita"/>
                           </div>
                        </asp:Panel>
                    </asp:Panel>
         

        </div>
    </div>
  
    
</asp:Content>
