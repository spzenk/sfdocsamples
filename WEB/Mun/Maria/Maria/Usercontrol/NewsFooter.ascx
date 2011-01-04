<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsFooter.ascx.cs" Inherits="Maria.Usercontrol.NewsFooter" %>
<link href="/Styles/News.css" rel="stylesheet" type="text/css" />
 <div class ="EnvelopeNewsBody">
<div style = "padding-top: 7px"  >
        <div style=" border-color: #C0C0C0; border-top-style: solid; border-width: 2px" >
        </div>
       
    <div style="font-family: verdana; font-size: x-small; color: #669999" >
        <span id="NewsFooerText0">
            <img alt="" src="../Images/cal_16.png" /></span>
        <span id="NewsFooerText1">Publicado </span>
        <span id="NewsFooerText2">
            <asp:Label ID="lblDate" runat="server"></asp:Label>
        </span>
    </div>
  </div>
</div>