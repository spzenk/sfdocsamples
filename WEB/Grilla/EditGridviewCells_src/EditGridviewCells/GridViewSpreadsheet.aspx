<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewSpreadsheet.aspx.cs" Inherits="GridViewSpreadsheet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>GridView with spreadsheet styling</title>    
    <link href="css/spreadsheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">    
    <h3>GridView with spreadsheet styling</h3>
    <a href="Default.aspx">Back to Menu</a>
    <p>
        This example uses sample data which is stored in session.
        <br />Try clicking and editing the individual GridView cells.
    </p>    
    <div>        
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#e9ecef" 
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" 
            OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnRowUpdating="GridView1_RowUpdating">
            <Columns>                
                <asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="False"/>
                <asp:ButtonField Text="DoubleClick" CommandName="DoubleClick" Visible="False"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="RowLabelsLabel" runat="server" Text='<%# Eval("Id") %>'></asp:Label>                        
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass="ssRowLabel" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="A">
                    <ItemTemplate>
                        <asp:Label ID="ALabel" runat="server" Text='<%# Eval("A") %>'></asp:Label>
                        <asp:TextBox ID="A" runat="server" Text='<%# Eval("A") %>' visible="false" CssClass="ssTextBox"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="ssCell" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="B">
                    <ItemTemplate>
                        <asp:Label ID="BLabel" runat="server" Text='<%# Eval("B") %>'></asp:Label>
                        <asp:TextBox ID="B" runat="server" Text='<%# Eval("B") %>' visible="false" CssClass="ssTextBox"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="ssCell" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="C">
                    <ItemTemplate>
                        <asp:Label ID="CLabel" runat="server" Text='<%# Eval("C") %>'></asp:Label>
                        <asp:TextBox ID="C" runat="server" Text='<%# Eval("C") %>' visible="false" CssClass="ssTextBox"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="ssCell" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="D">
                    <ItemTemplate>
                        <asp:Label ID="DLabel" runat="server" Text='<%# Eval("D") %>'></asp:Label>
                        <asp:TextBox ID="D" runat="server" Text='<%# Eval("D") %>' visible="false" CssClass="ssTextBox"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="ssCell" />
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="E">
                    <ItemTemplate>
                        <asp:Label ID="ELabel" runat="server" Text='<%# Eval("E") %>'></asp:Label>
                        <asp:TextBox ID="E" runat="server" Text='<%# Eval("E") %>' visible="false" CssClass="ssTextBox"></asp:TextBox>
                    </ItemTemplate>
                <ItemStyle CssClass="ssCell" />
                </asp:TemplateField>                  
                <asp:TemplateField HeaderText="F">
                    <ItemTemplate>
                        <asp:Label ID="FLabel" runat="server" Text='<%# Eval("F") %>'></asp:Label>
                        <asp:TextBox ID="F" runat="server" Text='<%# Eval("F") %>' visible="false" CssClass="ssTextBox"></asp:TextBox>
                    </ItemTemplate>
                <ItemStyle CssClass="ssCell" />
                </asp:TemplateField>                                                                     
            </Columns>
            <HeaderStyle CssClass="ssHeader" />
        </asp:GridView>
        <br />
        <asp:Label id="Message" runat="server" CssClass="message"></asp:Label> 
     </div>
    </form>
</body>
</html>
