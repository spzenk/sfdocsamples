<%@ Page Title="" Language="C#" MasterPageFile="~/Maria_Admin.master"  ValidateRequest ="false" AutoEventWireup="true" CodeBehind="Admin_NewsUpdate.aspx.cs" Inherits="Maria.Modules.Admin.Admin_NewsUpdate" %>
<%@ Register src="../../Usercontrol/News_Collapsed_RichText.ascx" tagname="News_Collapsed_RichText" tagprefix="uc1" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  
     <script  type="text/javascript" src="../../js2/tinymce/jscripts/tiny_mce/tiny_mce_src.js"></script>
    <script type="text/javascript" >
        tinyMCE.init({
        mode: "exact",
        elements: "ctl00$ctl00$ContentCenter$ContentPlaceHolder1$News_Collapsed_RichText_TxtIntro$txtText,ctl00$ctl00$ContentCenter$ContentPlaceHolder1$News_Collapsed_RichText_Txt$txtText",
        theme: "advanced",
        //        language: "es",
        plugins: "pagebreak,style,layer,table,save,advhr,advimage,advlink,emotions,iespell,inlinepopups,insertdatetime,preview,media,searchreplace,print,contextmenu,paste,directionality,fullscreen,noneditable,visualchars,nonbreaking,xhtmlxtras,template,wordcount,advlist,autosave,ibrowser",

            // Theme options
            theme_advanced_buttons1: "save,newdocument,|,bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,styleselect,formatselect,fontselect,fontsizeselect",
            theme_advanced_buttons2: "cut,copy,paste,pastetext,pasteword,|,search,replace,|,bullist,numlist,|,outdent,indent,blockquote,|,undo,redo,|,link,unlink,anchor,image,cleanup,help,code,|,insertdate,inserttime,preview,|,forecolor,backcolor",
            theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,emotions,iespell,media,advhr,|,print,|,ltr,rtl,|,fullscreen",
            theme_advanced_buttons4: "insertlayer,moveforward,movebackward,absolute,|,styleprops,|,cite,abbr,acronym,del,ins,attribs,|,visualchars,nonbreaking,template,pagebreak,restoredraft,netImageBrowser",
            theme_advanced_toolbar_location: "top",
            theme_advanced_toolbar_align: "left",
            theme_advanced_statusbar_location: "bottom",
            theme_advanced_resizing: true

        // Example content CSS (should be your site CSS)
        content_css: "css/content.css",

        // Drop lists for link/image/media/template dialogs
        template_external_list_url: "lists/template_list.js",
        external_link_list_url: "lists/link_list.js",
        external_image_list_url: "lists/image_list.js",
        media_external_list_url: "lists/media_list.js",

        // Style formats
        style_formats: [
			{ title: 'Bold text', inline: 'b' },
			{ title: 'Red text', inline: 'span', styles: { color: '#ff0000'} },
			{ title: 'Red header', block: 'h1', styles: { color: '#ff0000'} },
			{ title: 'Example 1', inline: 'span', classes: 'example1' },
			{ title: 'Example 2', inline: 'span', classes: 'example2' },
			{ title: 'Table styles' },
			{ title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
		],

        formats: {
            alignleft: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'left' },
            aligncenter: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'center' },
            alignright: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'right' },
            alignfull: { selector: 'p,h1,h2,h3,h4,h5,h6,td,th,div,ul,ol,li,table,img', classes: 'full' },
            bold: { inline: 'span', 'classes': 'bold' },
            italic: { inline: 'span', 'classes': 'italic' },
            underline: { inline: 'span', 'classes': 'underline', exact: true },
            strikethrough: { inline: 'del' }
        },

        // Replace values for the template plugin
        template_replace_values: {
            username: "Some User",
            staffid: "991234", theme_advanced_buttons3_add: "ibrowser"
        }
    });

        function checkDate(sender, args) {
            var dt = new Date(); //Tien el dia ed hoy
            //sender._selectedDate Es lafecha edl calendario seleccionada
            //alert(dt.format(sender._format));
            if (sender._selectedDate < dt) {
                sender._textbox.set_Value(dt.format(sender._format));
            }
        }
       
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
              <div id="d1" >
                              <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                  <ContentTemplate>
                                      <asp:Panel ID="pHeader" runat="server" CssClass="cpHeaderExpand">
                                          <asp:Label ID="lblText" runat="server" Text="Avanzada" />
                                      </asp:Panel>
                                      <asp:Panel ID="pBody" runat="server" CssClass="cpBody" Width="612px">
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
                                              <asp:TextBox ID="txtStartDate" runat="server" Height="24px" Width="222px"></asp:TextBox>
                                              <cc1:CalendarExtender ID="CalendarExtender1" Format ="dd/MM/yyyy" TargetControlID="txtStartDate" runat="server" OnClientDateSelectionChanged="checkDate">
                                              </cc1:CalendarExtender>
                                              <asp:RangeValidator ID="RangeValidator1" runat="server" 
                                                  ControlToValidate="txtStartDate" Display="Dynamic"  
                                                  ErrorMessage="La fecha de expiracion debe ser mayor a hoy" Type="Date" 
                                                  SetFocusOnError="True" MaximumValue="1/1/2200"></asp:RangeValidator>
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
                                                  runat="server" ControlToValidate="txtStartDate" 
                                                  Display="Static" ErrorMessage="Formato Fecha incorrecto Ej. 25/11/2006" 
                                                   SetFocusOnError="True" 
                                                  ValidationExpression="\d{2}/\d{2}/\d{4}" ></asp:RegularExpressionValidator>
                                          </div>
                                
            
                                      </asp:Panel>
                                      <cc1:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="server" TargetControlID="pBody"
                                          CollapseControlID="pHeader" ExpandControlID="pHeader" Collapsed="true" TextLabelID="lblText"
                                          CollapsedText="+ Avanzada" ExpandedText="- Avanzada" CollapsedSize="0">
                                      </cc1:CollapsiblePanelExtender>
                                  </ContentTemplate>
                              </asp:UpdatePanel>
                          </div>
                  <div >
                      <asp:Label ID="Label2" runat="server" Text="Titulo " /></div>
                  <div >
                      <textarea runat="server" id="txtTitle" name="txtTitle"  style="width: 100%;
                          height: 39px; color: #165993; font-size: 13px; font-style: normal; font-weight: bold; font-family: Verdana;"> </textarea>
                  </div >
                     <div>
                      &nbsp;<uc1:News_Collapsed_RichText ID="News_Collapsed_RichText_TxtIntro" 
                          runat="server" />
                  </div>
                  <div>
                      &nbsp;<uc1:News_Collapsed_RichText ID="News_Collapsed_RichText_Txt" 
                          runat="server" />
   
                 </div>
                  <div>
                      <asp:Button ID="btnCreateNew" runat="server" Text="Actualizar noticia" OnClick="btnCreateNew_Click"
                          CssClass="btGrisNegrita" />
                  </div>
              </asp:Panel>
          </asp:Panel>
      </div>
    </div>
  
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
