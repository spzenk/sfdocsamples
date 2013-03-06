<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Edit Individual GridView Cells</title>
    <link href="css/basic.css" rel="stylesheet" type="text/css" /> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Editing individual GridView cells</h3>
        <h3>C#</h3>
        <ul>
            <li>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/GridViewEditCell.aspx">Accessing data stored in session</asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/GridViewEditCell2.aspx">Accessing data stored in session with UpdatePanel, Validator Controls and Paging &amp; Sorting</asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/GridViewEditCellSql.aspx">Accessing data via the SqlDataSource control</asp:HyperLink> **
            </li>
            <li>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/GridViewEditCellObject.aspx">Accessing data via the ObjectDataSource control</asp:HyperLink> **
            </li>
        </ul>
        <p></p>
        <ul>
            <li>
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/GridViewSpreadsheet.aspx">Gridview with spreadsheet styling accessing data stored in session</asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/GridViewSpreadsheetSql.aspx">Gridview with spreadsheet styling accessing via the SqlDataSource control</asp:HyperLink> **
            </li>
        </ul>
         
        <br />
        <h3>VB.NET</h3>
        <ul>
            <li>
                <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/GridViewEditCellVB.aspx">Accessing data stored in session</asp:HyperLink>
            </li>
            <li>
                <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/GridViewEditCell2VB.aspx">Accessing data stored in session with UpdatePanel, Validator Controls and Paging &amp; Sorting</asp:HyperLink>
            </li>
        </ul
        
        <br /><br />
        <p>
            <i>** These examples use MS SQL Server. The connection string in the
            <br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;web.config must configured correctly for these examples to work.</i>
        </p>
    </div>
    </form>
</body>
</html>
