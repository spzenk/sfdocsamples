<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_FullViews.ascx.cs" Inherits="Maria.Usercontrol.News_FullViews" %>

<%@ Register src="NewsTitle.ascx" tagname="NewsTitle" tagprefix="uc1" %>

<%@ Register src="NewsFooter.ascx" tagname="NewsFooter" tagprefix="uc2" %>

<link href="../Styles/News.css" rel="stylesheet" type="text/css" />

<div style="padding: 10px 0px 15px 15px; Height:100%; top: 15px; left: 0px; width: 86%; ">

           <div >
                <uc1:NewsTitle ID="NewsTitle1" runat="server" />
           </div>
            <div class="EnvelopeNewsBody">
                   <asp:Label ID="TextBox2" runat="server"></asp:Label>
        </div>
 
    <div>
        <uc2:NewsFooter ID="NewsFooter1" runat="server" />
    </div>
</div>
