<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CallBacks.aspx.cs" Inherits="UsoTreeList.CallBacks" %>

<%@ Register Assembly="DevExpress.Web.v8.2, Version=8.2.4.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>

<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v8.2, Version=8.2.4.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5"
    Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>

<%@ Register assembly="DevExpress.Web.v8.2, Version=8.2.4.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>

<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.2, Version=8.2.4.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dxwtl:ASPxTreeList ID="treeList" runat="server" 
            AutoGenerateColumns="False" ClientInstanceName="treeList" 
            DataSourceID="SiteMapDataSource1" Height="138px" 
            oncustomdatacallback="treeList_CustomDataCallback" Width="136px">
            <Columns>
                 
                <dxwtl:TreeListTextColumn FieldName="Description" ReadOnly="True" 
                    VisibleIndex="0">
                </dxwtl:TreeListTextColumn>
                <dxwtl:TreeListTextColumn FieldName="Title" ReadOnly="True" VisibleIndex="1">
                </dxwtl:TreeListTextColumn>
                <dxwtl:TreeListTextColumn FieldName="Url" ReadOnly="True" VisibleIndex="2">
                </dxwtl:TreeListTextColumn>
                 
            </Columns>
            <Settings ShowTreeLines="False" SuppressOuterGridLines="true" />
        <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeDblClick" />
        <ClientSideEvents CustomDataCallback="
        function(s, e) { document.getElementById('messageText').innerHTML = e.result; }"
            FocusedNodeChanged="function(s, e) { 
			var key = treeList.GetFocusedNodeKey();
			treeList.PerformCustomDataCallback(key); 
		}" />
		<Border BorderStyle="Solid" />
        </dxwtl:ASPxTreeList>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" />
        <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="200px">
            <PanelCollection>
                <dxp:PanelContent runat="server">
                    <span id="messageText">
                        <asp:Literal ID="messageLiteral" runat="server"></asp:Literal>
                    </span>
                </dxp:PanelContent>
</PanelCollection>
       
          
        
        </dxrp:ASPxRoundPanel>
    </div>
    </form>
</body>
</html>
