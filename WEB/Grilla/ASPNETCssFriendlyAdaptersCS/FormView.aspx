<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormView.aspx.cs" Inherits="_FormView" MasterPageFile="~/Examples.master" StyleSheetTheme="Basic" Title="FormView Control Adapter: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" %>

<asp:Content runat="server" ContentPlaceHolderID="Prolog">
    <p>
        The FormView control is similar to the <a href="DetailsView.aspx">DetailsView</a>. Rather than
        using field tags like &lt;asp:BoundField&gt;, the FormView specifies its data using template
        tags like &lt;ItemTemplate&gt;. 
    </p>
    <p>
        Normally (i.e., when no adapter is used) the FormView renders a &lt;table&gt; to lay out the
        header, footer, paging and item data areas.
    </p>
    <p>
        An adapter can be used to replace this &lt;table&gt; with a few nested &lt;div&gt; tags whose
        appearance and position is easily styled with CSS.
    </p>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="LiveExample">
    <div id="SampleFormView">
        <asp:FormView ID="FormView1" Runat="server" SkinID="SampleFormView" DataSourceID="ContactsDS" HeaderText="Author Details" AllowPaging="True" CssSelectorClass="PrettyFormView">
            <ItemTemplate>
                <div class="Sample-Contact">
                    <div class="Sample-Name">
                        <%# XPath("./@au_fname")%> <%# XPath("./@au_lname")%>
                    </div>
                    <div class="Sample-Address">
                        <%# XPath("./@address")%><br />
                        <%# XPath("./@city")%>, <%# XPath("./@state")%><br />
                        <%# XPath("./@zip")%>
                    </div>
                    <div class="Sample-Phone">
                        <%# XPath("./@phone")%>
                    </div>
                </div>
            </ItemTemplate>
        </asp:FormView>
    </div>
    <asp:XmlDataSource ID="ContactsDS" DataFile="~/App_Data/contacts.xml" runat="server" XPath=".//Contacts/Contact" />
</asp:Content>
