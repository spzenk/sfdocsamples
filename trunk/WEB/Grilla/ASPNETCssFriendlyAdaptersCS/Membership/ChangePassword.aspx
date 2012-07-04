<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="_ChangePassword" MasterPageFile="~/Examples.master" StyleSheetTheme="Basic" Title="ChangePassword Control Adapter: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" %>

<asp:Content runat="server" ContentPlaceHolderID="Prolog">
    <p>
        The ChangePassword control, like most other ASP.NET Membership controls, positions form elements in nested
        &lt;table&gt; tags. Templates are a great way to replace some of those &lt;table&gt; tags with &lt;div&gt;
        tags or other markup you prefer. Visual Studio's design view makes it easy to get started making these
        templates. Since you can put any markup you like in these templates, they can be quite "friendly" to CSS.
        There are, however, two circumstances where an adapter can help. 
    </p>
    <ol>
        <li>
            Even if you use templates, the unadapted version of the ChangePassword control creates at least one
            overall wrapper &lt;table&gt;. An adapter can replace that outer &lt;table&gt; with something preferable,
            like a &lt;div&gt; tag.
        </li>
        <li>
            And, of course, there is no need to use templates if you use an adapter that, by default, renders
            table-less markup that is easy to style with CSS.
        </li>
    </ol>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="LiveExample">
    <div id="SampleChangePassword">        
        <asp:ChangePassword runat="server" ID="changepassword1" SkinID="SampleChangePassword"
            CssSelectorClass="PrettyChangePassword"
            DisplayUserName="true" 
            
            CancelButtonImageUrl="" CancelButtonText="cancel" CancelButtonType="Button"
            ContinueButtonImageUrl="" ContinueButtonText="continue" ContinueButtonType="Button"
            ChangePasswordButtonImageUrl="" ChangePasswordButtonText="change my password" ChangePasswordButtonType="Button"
                            
            ChangePasswordTitleText="So ... you want to change your password?"
            ChangePasswordFailureText="Invalid credentials.  Please try again." 
            InstructionText="<strong>No Problem!</strong><br />- Confirm your user name.<br />- Type your old password.<br />- Type your new password twice." 
            PasswordLabelText="Old password:"
            NewPasswordLabelText="New password:" 
            ConfirmNewPasswordLabelText="Retype your new password:" 
            ConfirmPasswordCompareErrorMessage="<br />The new passwords you entered do not match."                       
            UserNameLabelText="User Name:"
            SuccessTitleText="Success!"
            SuccessText="You've got a new password!"

            ContinueDestinationPageUrl="LoginStatus.aspx"

            CreateUserText="Register here." CreateUserUrl="CreateUserWizard.aspx" CreateUserIconUrl="" 
            PasswordRecoveryText="Forgot your password?" PasswordRecoveryUrl="PasswordRecovery.aspx" PasswordRecoveryIconUrl="" 
        
            ToolTip="Use this form to change your password."
        >
       </asp:ChangePassword>    
    </div>
    <div class="membershipHint">
        <p><strong>Hints:</strong></p>
        <p>Use the following values when filling out the change password  form.</p>
        <ul>
            <li>User Name = <strong>fred</strong></li>
            <li>Old password = <strong>css!</strong></li>
            <li>New password = (use anything, it doesn't matter)</li>
            <li>Retype new password = (type the same new password, it has to match to avoid the validation error)</li>
        </ul>
        <p>When you click the "continue" button on the "Success!" page, you'll be taken to a page that 
            demonstrates the <a href="LoginStatus.aspx">LoginStatus</a> control.</p>
        <p>Please note that the password is not actually changed in the membership provider. Continue to 
            use <strong>css!</strong> when you log in as <strong>fred</strong>.</p>
        <p>What would you like to do next?</p>
        <ul>
            <li><a href="ChangePassword.aspx">return to step 1 of this control</a></li>
            <li><a href="Login.aspx">login/logout</a></li>
            <li><a href="CreateUserWizard.aspx">register</a></li>
            <li><a href="PasswordRecovery.aspx">recover a lost password</a></li>
        </ul>            
    </div>

</asp:Content>
