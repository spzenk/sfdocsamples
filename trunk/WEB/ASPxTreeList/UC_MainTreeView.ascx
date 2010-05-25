<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_MainTreeView.ascx.cs" Inherits="UsoTreeList.UC_MainTreeView" %>

<%@ Register assembly="DevExpress.Web.ASPxTreeList.v8.2, Version=8.2.4.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5" namespace="DevExpress.Web.ASPxTreeList" tagprefix="dxwtl" %>
<%@ Register assembly="DevExpress.Web.ASPxEditors.v8.2, Version=8.2.4.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5" namespace="DevExpress.Web.ASPxEditors" tagprefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v8.2, Version=8.2.4.0, Culture=neutral, PublicKeyToken=49d90c14d24271b5" namespace="DevExpress.Web.ASPxSiteMapControl" tagprefix="dxsm" %>
<div>
         <dxwtl:ASPxTreeList ID="treeList" runat="server" 
            AutoGenerateColumns="False" ClientInstanceName="treeList" 
            DataSourceID="SiteMapDataSource1" Height="138px" 
            oncustomdatacallback="treeList_CustomDataCallback" Width="136px" 
             oncustomcallback="treeList_CustomCallback">
            <Columns>
                 
                <dxwtl:TreeListTextColumn FieldName="Description" ReadOnly="True" 
                    VisibleIndex="0" Visible="False">
                </dxwtl:TreeListTextColumn>
                <dxwtl:TreeListTextColumn FieldName="Title" ReadOnly="True" VisibleIndex="0">
                </dxwtl:TreeListTextColumn>
                <dxwtl:TreeListTextColumn FieldName="Url" ReadOnly="True" VisibleIndex="2" 
                    Visible="False">
                </dxwtl:TreeListTextColumn>
                 
            </Columns>
            <Settings ShowTreeLines="False" SuppressOuterGridLines="true" ShowRoot="False" />
        <SettingsBehavior AllowFocusedNode="True" ExpandCollapseAction="NodeClick" 
                 AutoExpandAllNodes="True" />
        <ClientSideEvents CustomDataCallback="
        function(s, e) { 
        if(e.result != '') window.location.href = e.result; 
        }"
            FocusedNodeChanged="function(s, e) { 
			var key = treeList.GetFocusedNodeKey();
			treeList.PerformCustomDataCallback(key); 
		}" />
		<Border BorderStyle="Solid" />
        </dxwtl:ASPxTreeList>
        <asp:SiteMapDataSource ID="SiteMapDataSource1" runat="server" 
             EnableViewState="False" />
    </div>