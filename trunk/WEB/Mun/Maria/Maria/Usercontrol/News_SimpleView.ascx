<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_SimpleView.ascx.cs" Inherits="Maria.Usercontrol.News_SimpleView" %>

<%@ Register src="NewsTitle.ascx" tagname="NewsTitle" tagprefix="uc1" %>

<%@ Register src="NewsFooter.ascx" tagname="NewsFooter" tagprefix="uc2" %>

<link href="../Styles/News.css" rel="stylesheet" type="text/css" />
<div style="padding: 5px 0px 15px 0px">
    <div >
        <asp:Panel ID="pnlTitle" runat="server">
            <uc1:NewsTitle ID="NewsTitle1" runat="server" />
        </asp:Panel>
        
                <div class="EnvelopeNewsBody">
            <asp:TextBox ID="TextBox2" runat="server" style="margin-bottom: 0px" BorderStyle="None" 
                        Height="100%" TextMode="MultiLine" Width="100%"></asp:TextBox> 
        </div>
    </div>
    <div>
        <uc2:NewsFooter ID="NewsFooter1" runat="server" />
    </div>
</div>
