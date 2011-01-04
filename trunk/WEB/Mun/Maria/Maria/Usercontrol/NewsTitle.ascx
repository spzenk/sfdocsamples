<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsTitle.ascx.cs" Inherits="Maria.NewsBase" %>
    

<link href="/Styles/News.css" rel="stylesheet" type="text/css" />

<div  class="EnvelopeNewsHeader">
    <div id="NewsHeaderNumeratorTitle">
        <span id="NewsHeaderNumerator"><asp:Label ID="lblDate" runat="server" Text="333"></asp:Label></span>
        <span id="NewsHeaderTitle">Noticia</span>
    </div>
    <div id="NewsHeaderBody">
        <span id="NewsHeaderText">
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </span>
    </div>
</div>