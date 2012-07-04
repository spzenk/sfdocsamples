<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="_Login" MasterPageFile="~/Examples.master" StyleSheetTheme="Basic" Title="Login Control Adapter: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" %>

<asp:Content runat="server" ContentPlaceHolderID="Prolog">
    <p>
        The Login control presents a simple HTML form for gathering user credentials. When submitted,
        the web server's Membership Provider determines if the credentials are valid correct and valid.
        If so, the user is considered "logged in" and, typically, has access to more of the web site than 
        an anonymous visitor.
    </p>
    <p>
        The server-side functionality provided by the Login control is useful and does not warrant adaptation.
        After all, validating credentials has nothing to do with how the form that gathers those credentials is
        presented. So, the goal of the Login control's adapter is to improve the markup used in the form's
        presentation without touching the server-side functionality. In particular, the adapted HTML uses
        &lt;div&gt; rather than &lt;table&gt; tags to position form elements.  Likewise, the adapted HTML avoids
        inline CSS styles. (Exception: Internal validators used by the Login control may still
        render inline styles even when the sample Login adapter is used.)
    </p>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="LiveExample">
    <asp:LoginView ID="loginview1" runat="server">
        <LoggedInTemplate>
            <asp:LoginName ID="loginname1" runat="server" ToolTip="Welcome back!" FormatString ="Welcome back, {0}! " />                    
            <asp:LoginStatus ID="loginstatus1" runat="server" 
                LogoutText="Please logout"        
                LogoutAction="RedirectToLoginPage" 
                ToolTip="click to logout" />
            to see the Login form.                
        </LoggedInTemplate>
        <AnonymousTemplate>
            <div id="SampleLogin">
                <asp:Login runat="server" ID="login1" SkinID="SampleLogin"
                    CssSelectorClass="PrettyLogin"
                    DestinationPageUrl="LoginStatus.aspx"
                    LoginButtonImageUrl="" LoginButtonText="Login" LoginButtonType="Button"
                    UserNameLabelText="User Name:"
                    PasswordLabelText="Password:" 
                    TitleText="Login" 
                    RememberMeText="Remember me next time." 

                    FailureText="Your login attempt was not successful. Please try again." 

                    CreateUserText="Register here." CreateUserUrl="CreateUserWizard.aspx" CreateUserIconUrl="" 
                    PasswordRecoveryText="Forgot your password?" PasswordRecoveryUrl="PasswordRecovery.aspx" PasswordRecoveryIconUrl="" 

                    ToolTip="Please login." />
            </div>  
        </AnonymousTemplate>
    </asp:LoginView>    
   
    <div class="membershipHint">
        <p><strong>Hints:</strong></p>
        <p>Use the following values when filling out the login form.</p>
        <ul>
            <li>User Name = <strong>fred</strong></li>
            <li>Password = <strong>css!</strong></li>
        </ul>
        <p>If your user name and password are correct, you'll be taken to a page that 
            demonstrates the <a href="LoginStatus.aspx">LoginStatus</a> control.</p>       
        <p>Please note that the login form does <em>not</em> display if the user is already logged in.</p>
        <p>What would you like to do next?</p>
        <ul>
            <li><a href="Login.aspx">refresh this page</a></li>
            <li><a href="CreateUserWizard.aspx">register</a></li>
            <li><a href="ChangePassword.aspx">change the password</a></li>
            <li><a href="PasswordRecovery.aspx">recover a lost password</a></li>
        </ul>
    </div>
    
</asp:Content>
