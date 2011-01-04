<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsTitle.ascx.cs" Inherits="Maria.NewsTitle" %>
    

<link href="/Styles/News.css" rel="stylesheet" type="text/css" />

<div  class="EnvelopeNewsHeader">
  <%--  <div id="NewsHeaderNumeratorTitle">
        <span id="NewsHeaderTitle"><asp:Label ID="lblDate" runat="server" Text="333"></asp:Label></span>
       
    </div>--%>
    <div id="NewsHeaderTitle">
        <span >
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </span>
    </div>
</div>