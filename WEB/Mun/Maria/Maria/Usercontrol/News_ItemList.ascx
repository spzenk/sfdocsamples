<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_ItemList.ascx.cs" Inherits="Maria.Usercontrol.News_ItemList" %>
<link href="/Styles/Common.css" rel="stylesheet" type="text/css" />
<link href="/Styles/News.css" rel="stylesheet" type="text/css" />
  <div>
   <img  alt="" src="../Images/tilde_guion-griz.png" 
                style="height: 15px; width: 15px" /> Hola
  </div>
<div  class="EnvelopeNewsHeader">
  
    <div style="margin: 20px; padding: 5px; border: 1px outset #C0C0C0" >
   <span>
   
   <img  alt="" src="../Images/tilde_guion-griz.png" 
                style="height: 15px; width: 15px" />
   </span>
            &nbsp;<span >
                <asp:HyperLink ID="lblTitle" Target ="_blank" 
                NavigateUrl="~/Modules/Noticias/NewsFullView.aspx" runat="server" 
                CssClass="NewsListItem" Font-Underline="False" Width ="90%">HyperLink</asp:HyperLink>
                
               </span>
                
        <span>
          <asp:ImageButton ID="btnSeach" 
                runat="server" ImageUrl="../Images/edit.png"  Text="buscar" 
                Height="20px"  DescriptionUrl ="~/Modules/Noticias/NewsFullView.aspx"/>
        </span>
          
    </div>
</div>