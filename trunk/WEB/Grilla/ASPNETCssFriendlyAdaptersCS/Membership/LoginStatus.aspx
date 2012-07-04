<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LoginStatus.aspx.cs" Inherits="_LoginStatus" MasterPageFile="~/Examples.master" StyleSheetTheme="Basic" Title="LoginStatus Control Adapter: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" %>

<asp:Content runat="server" ContentPlaceHolderID="Prolog">
    <p>
        The LoginStatus control renders just a single &lt;span&gt; tag whose CSS class can be set using
        the LoginStatus' CssClass property. In the unadapted form, the &lt;span&gt; includes an inline
        style to set the border-width (zero by default). If you eschew inline styles, you can adapt the
        LoginStatus control to omit the style attribute on the &lt;span&gt;.
    </p>
    <p>
        This is a good example of using adapters to fine tune your rendered markup. Not all adapters have to result
        in massive changes to the markup like you see with the <a runat="server" href="~/Menu.aspx">Menu</a>
        or <a runat="server" href="~/TreeView.aspx">TreeView</a> adapters. It's perfectly reasonable to use adapters
        to make smaller changes, too.
    </p>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="LiveExample">
    <div id="SampleLoginStatus">
        <asp:LoginStatus ID="loginstatus1" runat="server" SkinID="SampleLoginStatus"
            CssSelectorClass="PrettyLoginStatus"
            LoginText="login" 
            LogoutText="logout"        
            LogoutAction="RedirectToLoginPage" 
            ToolTip="Click to login/logout."              
         />
    </div>
    
    <div class="membershipHint">
        <p><strong>Hints:</strong></p>
        <p>If the user is logged in, the logout link is displayed.  Otherwise, the login link is shown.</p>
        <p>In both cases, the link goes to the login page.</p>
        <p>What would you like to do next?</p>
        <ul>
            <li>Use the login/logout image shown above to log in or out.</li>
            <li><a href="CreateUserWizard.aspx">register</a></li>
            <li><a href="ChangePassword.aspx">change password</a></li>
            <li><a href="PasswordRecovery.aspx">recover password</a></li>
        </ul>        
    </div>
</asp:Content>
