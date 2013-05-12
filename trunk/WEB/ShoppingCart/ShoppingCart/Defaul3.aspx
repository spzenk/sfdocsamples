<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Defaul3.aspx.cs" Inherits="ShoppingCart.Defaul3" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
  #browser {
    font-family: Verdana, helvetica, arial, sans-serif;
    font-size: 68.75%;
  }
  </style>
    <script type="text/javascript" language="javascript">
        var varUrl;
        var varData;
        var svcRootPath;
        var lastArray = new Array();

        $(document).ready(function () {
            $("#browser").treeview();
            $("#add").click(function () {
                var branches = $("<li><span class='folder'>New Sublist</span><ul>" +
 		"<li><span class='file'>Item133</span></li>" +
 		"<li><span class='file'>Item2</span></li>" +
 		"</ul></li>").appendTo("#browser");
                $("#browser").treeview({
                    add: branches
                });
            });
        });

       
        function CallService() {
            $.ajax({
                type: "POST", 
                url: varUrl, 
                data: varData,
                contentType: "application/json; charset=utf-8", 
                dataType: "json", 
                processdata: true, 
                success: function (data) {
                    ServiceSucceeded(data);
                },
                error: ServiceFailed
            });
        }
      
        
    </script>

    <div id="ProductCategory_div" class="grid_3 alpha">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
        <asp:TreeView ID="trvCategories" ExpandDepth="1" runat="server" Width="168px" 
                    ImageSet="Arrows" NodeStyle-Height="20" DataSourceID="SiteMapDataSource1" Height="100%"
            LineImagesFolder="~/TreeLineImages" ViewStateMode="Enabled" 
                    onselectednodechanged="trvCategories_SelectedNodeChanged" 
                    ontreenodedatabound="trvCategories_TreeNodeDataBound">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <LevelStyles>
                <asp:TreeNodeStyle CssClass="nodeLevel1" ChildNodesPadding="8" />
                <asp:TreeNodeStyle CssClass="nodeLevel2" ChildNodesPadding="5" />
                <asp:TreeNodeStyle CssClass="nodeLevel3" ChildNodesPadding="5" />
            </LevelStyles>
            <NodeStyle Font-Names="Verdana" Font-Size="11px" ForeColor="Black" Height="20px" 
                HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="true" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD"    HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
             
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
              </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div id="centerContent_div" class="grid_9">
        <div class="frm_title_2" style="margin-top: 14px">            Listado de productos</div>
        <div class="cart-div" style="margin-top: 30px">
            <%--PRODUCT PANEL GRID VIEW--%>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
               
                    <div id="divGridView" class="">
                        <asp:GridView ID="GridView_Prod" runat="server" AutoGenerateColumns="False" CSSSelectorClass="YodaGrilla"
                            ToolTip="Lista de productos" BorderColor="White" CaptionAlign="Left" Width="100%"
                            ShowHeader="False"                             OnRowDataBound="GridView_Prod_RowDataBound">
                            <PagerSettings Position="TopAndBottom" FirstPageText="Ir al inicio" LastPageText="Ultima pagina"
                                Mode="NextPreviousFirstLast"></PagerSettings>
                            <Columns >
                     
                                <asp:TemplateField HeaderText="# to Buy">
                                    <ItemTemplate>
                                        <div style="height: 60px;border-style:none">
                                            <asp:TextBox ID="txtNumberToBuy" runat="server" AutoPostBack="False" BorderStyle="None"
                                                BorderWidth="1px" CausesValidation="True" SkinID="TextBoxSkin" TabIndex="20"
                                                Width="30px">1px</asp:TextBox>
                                            <ajaxToolkit:NumericUpDownExtender ID="txtNumberToBuy_NumericUpDownExtender" runat="server"
                                                Enabled="True" Maximum="1000" Minimum="0" RefValues="" ServiceDownMethod="" ServiceDownPath=""
                                                ServiceUpMethod="" Tag="" TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtNumberToBuy"
                                                Width="75">
                                            </ajaxToolkit:NumericUpDownExtender>
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="txtNumberToBuy"
                                                Display="Dynamic" ErrorMessage="Integer Value Required" Operator="DataTypeCheck"
                                                Type="Integer"></asp:CompareValidator>
                                        </div>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="100px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Description" HeaderText="Description" ReadOnly="True"
                                    SortExpression="Description" ItemStyle-CssClass="cart-catalog-col-desc"   />
                        <asp:BoundField DataField="Marca" HeaderText="Marca" ReadOnly="True"
                                    SortExpression="Marca" ItemStyle-CssClass="cart-catalog-col-marca"   />
                                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" Visible="false" SortExpression="Id"  />
                                <asp:BoundField DataField="Price" HeaderText="Price"  ReadOnly="True" SortExpression="Price" ItemStyle-CssClass="cart-catalog-col-price" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:c}"  />
                            </Columns>
                            <AlternatingRowStyle  BorderStyle="Solid" BorderWidth="1" BorderColor="#A8A7A6" />
                            <RowStyle BorderStyle="Solid" BorderWidth="1"  BorderColor="#A8A7A6" />
                            
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
