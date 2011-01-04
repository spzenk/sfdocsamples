<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_SimpleView.ascx.cs" Inherits="Maria.Usercontrol.News_SimpleView" %>

<%@ Register src="NewsTitle.ascx" tagname="NewsTitle" tagprefix="uc1" %>

<%@ Register src="NewsFooter.ascx" tagname="NewsFooter" tagprefix="uc2" %>

<link href="../Styles/News.css" rel="stylesheet" type="text/css" />
<div >
    <div id="EnvelopeNew">
    
        <asp:Panel ID="pnlTitle" runat="server">
            
                <uc1:NewsTitle ID="NewsTitle1" runat="server" />
        
        </asp:Panel>
        
    </div>
    <div>
    <uc2:NewsFooter ID="NewsFooter1" runat="server" />
</div>
</div>

