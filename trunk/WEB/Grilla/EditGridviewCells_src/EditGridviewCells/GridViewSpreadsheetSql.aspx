<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewSpreadsheetSql.aspx.cs" Inherits="GridViewSpreadsheetSql" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>GridView with spreadsheet styling using a SQL Data Source control</title>    
    <link href="css/spreadsheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <h3>GridView with spreadsheet styling using a SQL Data Source control</h3>
    <a href="Default.aspx">Back to Menu</a>
    <p>
        This example uses sample data which is stored in a SQL Server database.
        <br />The data is accessed via a SQL Data Source control.
        <br />Try clicking and editing the individual GridView cells.
    </p>    
    <div>        
        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#e9ecef" DataSourceID="SqlDataSource1" DataKeyNames="Id"
            BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" 
            OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" AutoGenerateColumns="False" OnRowUpdating="GridView1_RowUpdating" >
            <Columns>                
                <asp:ButtonField Text="SingleClick" CommandName="SingleClick" Visible="False"/>
                <asp:ButtonField Text="DoubleClick" CommandName="DoubleClick" Visible="False"/>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="RowLabelsLabel" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                        <asp:TextBox ID="RowLabels" runat="server" Text='<%# Eval("Id") %>' Width="40px" visible="false"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" CssClass="ssRowLabel" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="A" SortExpression="A">
                    <ItemTemplate>
                        <asp:Label ID="ALabel" runat="server" Text='<%# Eval("A") %>'></asp:Label>
                        <asp:TextBox ID="A" runat="server" Text='<%# Eval("A") %>' visible="false" CssClass="ssTextBox"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="ssCell" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="B" SortExpression="B">
                    <ItemTemplate>
                        <asp:Label ID="BLabel" runat="server" Text='<%# Eval("B") %>'></asp:Label>
                        <asp:TextBox ID="B" runat="server" Text='<%# Eval("B") %>' visible="false" CssClass="ssTextBox"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="ssCell" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="C" SortExpression="C">
                    <ItemTemplate>
                        <asp:Label ID="CLabel" runat="server" Text='<%# Eval("C") %>'></asp:Label>
                        <asp:TextBox ID="C" runat="server" Text='<%# Eval("C") %>' visible="false" CssClass="ssTextBox"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="ssCell" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="D" SortExpression="D">
                    <ItemTemplate>
                        <asp:Label ID="DLabel" runat="server" Text='<%# Eval("D") %>'></asp:Label>
                        <asp:TextBox ID="D" runat="server" Text='<%# Eval("D") %>' visible="false" CssClass="ssTextBox"></asp:TextBox>
                    </ItemTemplate>
                    <ItemStyle CssClass="ssCell" />
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="E" SortExpression="E">
                    <ItemTemplate>
                        <asp:Label ID="ELabel" runat="server" Text='<%# Eval("E") %>'></asp:Label>
                        <asp:TextBox ID="E" runat="server" Text='<%# Eval("E") %>' visible="false" CssClass="ssTextBox"></asp:TextBox>
                    </ItemTemplate>
                <ItemStyle CssClass="ssCell" />
                </asp:TemplateField>                  
                <asp:TemplateField HeaderText="F" SortExpression="F">
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
            SelectCommand="SELECT * FROM [Spreadsheet]" DeleteCommand="DELETE FROM [Spreadsheet] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Spreadsheet] ([A], [B], [C], [D], [E], [F]) VALUES (@A, @B, @C, @D, @E, @F)" UpdateCommand="UPDATE [Spreadsheet] SET [A] = @A, [B] = @B, [C] = @C, [D] = @D, [E] = @E, [F] = @F WHERE [Id] = @Id" >
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="A" Type="String" />
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
            <InsertParameters>
                <asp:Parameter Name="A" Type="String" />
                <asp:Parameter Name="B" Type="String" />
                <asp:Parameter Name="C" Type="String" />
                <asp:Parameter Name="D" Type="String" />
                <asp:Parameter Name="E" Type="String" />
                <asp:Parameter Name="F" Type="String" />
            </InsertParameters>
        </asp:SqlDataSource>         
     </div>
    </form>
</body>
</html>
