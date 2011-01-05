<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_SimpleView.ascx.cs" Inherits="Maria.Usercontrol.News_SimpleView" %>

<%@ Register src="NewsTitle.ascx" tagname="NewsTitle" tagprefix="uc1" %>

<%@ Register src="NewsFooter.ascx" tagname="NewsFooter" tagprefix="uc2" %>

<link href="../Styles/News.css" rel="stylesheet" type="text/css" />
<div style="padding: 10px 0px 15px 15px; Height:100%; top: 15px; left: 0px; width: 86%; ">

           <div >
                <uc1:NewsTitle ID="NewsTitle1" runat="server" />
           </div>
            <div class="EnvelopeNewsBody">
            <asp:TextBox ID="TextBox2" runat="server" Style="margin-bottom: 0px" BorderStyle="None"
                Height="100%" TextMode="MultiLine" Width="100%" Font-Names="Verdana" 
                Font-Size="Small" ReadOnly="True"></asp:TextBox>
        </div>
    <%--<div style="border-style: none groove groove groove; border-width: thin; border-color: #CCCCCC; padding: 0px 0px 6px 0px;" >
    
        <div class="EnvelopeNewsBody">
            <asp:TextBox ID="TextBox2" runat="server" Style="margin-bottom: 0px" BorderStyle="None"
                Height="100%" TextMode="MultiLine" Width="100%" Font-Names="Verdana" 
                Font-Size="Small" ReadOnly="True"></asp:TextBox>
        </div>
    </div>--%>
    <div>
        <uc2:NewsFooter ID="NewsFooter1" runat="server" />
    </div>
</div>
