<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailsView.aspx.cs" Inherits="_DetailsView" MasterPageFile="~/Examples.master" StyleSheetTheme="Basic" Title="DetailsView Control Adapter: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" %>

<asp:Content runat="server" ContentPlaceHolderID="Prolog">
    <p>
        The DetailsView control is used to display one or more fields from a single data record.
        The unadapted version of the DetailsView control renders these fields as rows in an HTML
        &lt;table&gt;.  An adapter can be used to render an unordered list (&lt;ul&gt; and &lt;li&gt;
        tags) instead.
    </p>
    <p>
        The unadapted DetailsView uses table cells (&lt;td&gt; tags) to separate each field's descriptive
        (header) text from its value.  The adapted control uses &lt;span&gt; tags instead.  By styling
        these &lt;ul&gt;, &lt;li&gt; and &lt;span&gt; tags with CSS you can customize nearly every
        aspect of the DetailsView's appearance. 
    </p>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="LiveExample">
    <div id="SampleDetailsView">
        <asp:DetailsView ID="DetailsView1" Runat="server" SkinID="SampleDetailsView" DataSourceID="AuthorsDS" AutoGenerateRows="False" HeaderText="Author Details" AllowPaging="True" CssSelectorClass="PrettyDetailsView" OnItemUpdated="FakeItemUpdate">
            <Fields>
                <asp:BoundField HeaderText="ID" DataField="au_id" />
                <asp:BoundField HeaderText="Last name" DataField="au_lname" />
                <asp:BoundField HeaderText="First name" DataField="au_fname" />
                <asp:BoundField HeaderText="Phone" DataField="phone" />
                <asp:BoundField HeaderText="Street" DataField="address" />
                <asp:BoundField HeaderText="City" DataField="city" />
                <asp:BoundField HeaderText="State" DataField="state" />
                <asp:BoundField HeaderText="ZIP code" DataField="zip" />
                <asp:BoundField HeaderText="Contract" DataField="contract" />
                <asp:CommandField ShowEditButton="True" />
            </Fields>
        </asp:DetailsView>
        <asp:Panel ID="FakeUpdateReport" runat="server"></asp:Panel>
    </div>
    <asp:XmlDataSource ID="AuthorsDS" DataFile="~/App_Data/contacts.xml" runat="server" XPath='.//Contact[@au_lname="Ringer"]' />
</asp:Content>
