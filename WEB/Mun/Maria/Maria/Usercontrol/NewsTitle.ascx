<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsTitle.ascx.cs" Inherits="Maria.NewsTitle" %>
    
<link href="../Styles/Common.css" rel="stylesheet" type="text/css" />
<link href="../Styles/News.css" rel="stylesheet" type="text/css" />
<div  class="EnvelopeNewsHeader">
  
    <div class ="NewsHeaderTitle">
      
            <span id="NewsHeaderTitle">
            <img  alt="" src="../../Images/tilde_guion-griz.png" /></span>
            <asp:HyperLink ID="lblTitle" Target ="_blank" 
                NavigateUrl="~/Modules/Noticias/NewsFullView.aspx" runat="server" 
                CssClass="NewsHeaderTitle" Font-Underline="False">HyperLink</asp:HyperLink>
                
        
          
    </div>
</div>