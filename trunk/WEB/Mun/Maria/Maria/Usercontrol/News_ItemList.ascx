<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="News_ItemList.ascx.cs" Inherits="Maria.Usercontrol.News_ItemList" %>
<link href="../Styles/Common.css" rel="stylesheet" type="text/css" />
<link href="../Styles/News.css" rel="stylesheet" type="text/css" />

<div  class="EnvelopeNewsHeader">
  
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <div style="margin: 10px; padding: 5px; border: 1px outset #C0C0C0">
        <span>
            <asp:Image ID="imgImage" runat="server" ImageUrl="../Images/tilde_guion-griz.png" />
        </span><span>
            <asp:HyperLink ID="lblTitle" Target="_blank" NavigateUrl="~/Modules/Noticias/NewsFullView.aspx"
                runat="server" CssClass="NewsListItem" Font-Underline="False" Width="90%">HyperLink</asp:HyperLink>
        </span>
        <span>
            <asp:ImageButton ID="btnEdit" runat="server" ImageUrl="../Images/edit.png" Text="Editar"
                Height="20px" DescriptionUrl="~/Modules/Admin/Admin_NewsUpdate.aspx" 
            PostBackUrl="~/Modules/Admin/Admin_NewsUpdate.aspx" 
            ToolTip="Editar esta noticia" />
        </span>
              <span>
            <asp:ImageButton ID="btnRemove" runat="server" 
            ImageUrl="../Images/remov_16.png" Text="Eliminar esta noticia"
                Height="20px" DescriptionUrl="~/Modules/Admin/Admin_NewsUpdate.aspx" 
    
            ToolTip="Eliminar esta noticia"  
            OnClick="btnRemove_Click" style="width: 20px" />
        </span>
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    
        </ContentTemplate>
    </asp:UpdatePanel>
</div>