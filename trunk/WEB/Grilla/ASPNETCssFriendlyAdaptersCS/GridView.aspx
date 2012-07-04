<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridView.aspx.cs" Inherits="_GridView" MasterPageFile="~/Examples.master" StyleSheetTheme="Basic" Title="GridView Control Adapter: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" %>

<asp:Content runat="server" ContentPlaceHolderID="Prolog">
    <p>
        The goal of the adapter for the GridView control is to create a &lt;table&gt; that is slimmer and better
        organized than what is produced without the adapter.  You could, of course, rewrite this adapter to
        completely eliminate the &lt;table&gt;, replacing it with a variety of &lt;div&gt; tags, etc.  However,
        a grid, fundamentally, is a table so it seems logical to leave it as such. 
    </p>
    <p>
        The adapted GridView eliminates the use of inline styles.  Rows within the &lt;table&gt; are organized
        into &lt;thead&gt;, &lt;tfoot&gt; and &lt;tbody&gt; sections.  These make it easier to read and understand
        the markup.  More importantly, these sections make it easy to create CSS rules that govern the appearance
        of particular rows within the &lt;table&gt;.
    </p>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="LiveExample">
    <div id="SampleGridView">
        <p>
            What happens when we run the Math methods over and over again? Here are some raw timing statistics. 
        </p>
        <asp:GridView runat="server" id="GridView1" CssSelectorClass="PrettyGridView" SkinID="SampleGridView" DataSourceID="MathOperationPerfDS" AllowPaging="true" AllowSorting="true" PageSize="10" AutoGenerateColumns="false" OnRowCreated="DoRowCreated">
            <pagersettings Position="TopAndBottom" />
            <columns>
                <asp:BoundField DataField="Operation" SortExpression="Operation" HeaderText="Operation" />
                <asp:BoundField DataField="Reps" SortExpression="Reps" HeaderText="Repetitions" />
                <asp:BoundField DataField="Duration" SortExpression="Duration" HeaderText="Total test duration milliseconds" />
                <asp:BoundField DataField="Average" SortExpression="Average" HeaderText="Average cost per rep microseconds" DataFormatString="{0:F4}" HtmlEncode="false" />
            </columns>
        </asp:GridView>
    </div>
    <asp:ObjectDataSource runat="server" id="MathOperationPerfDS" selectMethod="Fetch" typename="MathOperationPerf" />
</asp:Content>

