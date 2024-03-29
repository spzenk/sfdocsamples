<%@ Control Language="C#" Inherits="Pelsoft.Modules.GuestbookCS.ViewGuestbookCS"
    AutoEventWireup="true" CodeBehind="ViewGuestbookCS.ascx.cs" %>
<asp:DataList ID="lstContent" DataKeyField="ItemID" runat="server" CellPadding="4"
    OnItemDataBound="lstContent_ItemDataBound">
    <ItemTemplate>
        <table cellpadding="4" width="100%">
            <tr>
                <td valign="top" width="100%" align="left">
                    <asp:HyperLink ID="HyperLink1" NavigateUrl='<%# EditUrl("ItemID",DataBinder.Eval(Container.DataItem,"ItemID").ToString()) %>'
                        Visible="<%# IsEditable %>" runat="server">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/edit.gif" AlternateText="Edit"
                            Visible="<%#IsEditable%>" resourcekey="Edit" /></asp:HyperLink>
                    <asp:Label ID="lblContent" runat="server" CssClass="Normal" />
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:DataList>