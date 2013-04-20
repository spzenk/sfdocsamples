<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ShoppingCart.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TreeView ID="EntertainmentTreeView" runat="server"   
            CssSelectorClass="SimpleEntertainmentTreeView" ExpandDepth="0" 
            ImageSet="Arrows" Width="399px" Height="210px">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <Nodes>
                <asp:TreeNode Text="Music" SelectAction="Expand">
                    <asp:TreeNode Text="Classical" />
                    <asp:TreeNode Text="Rock">
                        <asp:TreeNode Text="Electric" />
                        <asp:TreeNode Text="Acoustical" />
                    </asp:TreeNode>
                    <asp:TreeNode Text="Jazz" />
                </asp:TreeNode>
                <asp:TreeNode Text="Movies" SelectAction="Expand">
                    <asp:TreeNode Text="Action" />
                    <asp:TreeNode Text="Drama" />
                    <asp:TreeNode Text="Musical" />
                </asp:TreeNode>
            </Nodes>
            <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
                HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" 
                HorizontalPadding="0px" VerticalPadding="0px" ForeColor="#5555DD" />
        </asp:TreeView>
    </div>
    </form>
</body>
</html>
