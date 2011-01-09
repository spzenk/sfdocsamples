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

    function f(arg) {
            target.value = arg._selectedDate.format("MM-dd-yyyy");
        };
       
    </script >
  <div id="Div3" class ="EnvelopeContNews">
      <div id="Div4" class="EnvelopeNews">
          <asp:Panel ID="pnlContent" runat="server" Height="100%">
              <div>
                  <asp:Panel ID="pnHeader" runat="server" CssClass="cpHeaderStatic">
                      <div>
                          <asp:Label ID="Label1" runat="server" Text="Nueva noticia" />
                      </div>
             
                  </asp:Panel>
              </div>
              <asp:Panel ID="pnlBody" runat="server" CssClass="EnvelopeNewsBody">
              <div id="d1">
                              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                  <ContentTemplate>
                                      <asp:Panel ID="pHeader" runat="server" CssClass="cpHeaderExpand">
                                          <asp:Label ID="lblText" runat="server" Text="Avanzada" />
                                      </asp:Panel>
                                      <asp:Panel ID="pBody" runat="server" CssClass="cpBody">
                                          <div>
                                              
                                              <asp:Label ID="Label3" runat="server" Text="Fecha de expiración" />
                                          </div>
                                          <div>
                                          <asp:ImageButton
                                        ID="btnCalenderPopup"
                                        Width="16" Height="16"
                                        runat="server"
                                        ImageUrl="~/Images/cal_16.png"
                                        CausesValidation="False" />
                                       <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                                  ErrorMessage="La fecha de expiracion debe ser mayor a hoy" ControlToValidate = "txtStartDate"
                                                   Type="Date" Display="Dynamic"></asp:RangeValidator>
                                              <asp:TextBox ID="txtStartDate" runat="server" Height="24px" Width="222px"></asp:TextBox>
                                              <cc1:CalendarExtender ID="CalendarExtender1" Format ="dd/MM/yyyy" TargetControlID="txtStartDate" runat="server" OnClientDateSelectionChanged="f">
                                              </cc1:CalendarExtender>
                                          </div>
                                      </asp:Panel>
                                      <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" TargetControlID="pBody"
                                          CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="true" TextLabelID="lblText"
                                          CollapsedText="+ Avanzada" ExpandedText="- Avanzada" CollapsedSize="0">
                                      </cc1:CollapsiblePanelExtender>
                                  </ContentTemplate>
                              </asp:UpdatePanel>
                          </div>
                  <div>
                      <asp:Label ID="Label2" runat="server" Text="Titulo " /></div>
                  <div>
                      <textarea runat="server" id="txtTitle" name="txtTitle" cols="10" style="width: 546px;
                          height: 39px"> </textarea>
                  </div>
                  <asp:Label ID="lblComments" runat="server" Text="Texto " />
                  <div>
                      <textarea runat="server" id="txtBody" name="txtBody" cols="10" style="width: 100%;
                          height: 400px"> </textarea>
                  </div>
                  <div>
                      <asp:Button ID="btnCreateNew" runat="server" Text="Crear noticia" OnClick="btnCreateNew_Click"
                          CssClass="btGrisNegrita" />
                  </div>
              </asp:Panel>
          </asp:Panel>
      </div>
    </div>
  
    
</asp:Content>
