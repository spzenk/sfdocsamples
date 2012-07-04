<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataList.aspx.cs" Inherits="_DataList" MasterPageFile="~/Examples.master" StyleSheetTheme="Basic" Title="DataList Control Adapter: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<asp:Content runat="server" ContentPlaceHolderID="Prolog">
    <p>
        The unadapted DataList control renders its grid of data into an HTML &lt;table&gt;. An adapter could
        replace that table with a set of nested &lt;div&gt; tags but there are some advantages to retaining the
        &lt;table&gt;.  Therefore, the DataList adapter demonstrated here still renders a &lt;table&gt;.  The adapter 
        groups the rows into &lt;thead&gt;, &lt;tfoot&gt; and &lt;tbody&gt; sections.
    </p>
    <p>
        This makes it easy to create a set of CSS rules that control the appearance of the table.
    </p>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="LiveExample">
    <div id="SampleDataList">
        <asp:DataList id="MyDataList" SkinID="SampleDataList" DataSourceID="ContactsDS" RepeatColumns="4" RepeatDirection="Vertical" runat="server" CssSelectorClass="PrettyDataList">        
            
            <HeaderTemplate>
                Authors from Pubs
            </HeaderTemplate>
            
            <FooterTemplate>
                &nbsp;
            </FooterTemplate>

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
            
        </asp:DataList>
    </div>
    <asp:XmlDataSource ID="ContactsDS" DataFile="~/App_Data/contacts.xml" runat="server" XPath=".//Contacts/Contact" />
</asp:Content>
