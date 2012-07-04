<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PasswordRecovery.aspx.cs" Inherits="_PasswordRecovery" MasterPageFile="~/Examples.master" StyleSheetTheme="Basic" Title="PasswordRecovery Control Adapter: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" %>

<asp:Content runat="server" ContentPlaceHolderID="Prolog">
    <p>
        The PasswordRecovery control follows a pattern similar what is used for <a href="ChangePassword.aspx">ChangePassword</a>.
        Both controls let you use templates to eliminate some, but not all, of the &lt;table&gt; tags that the control
        creates by default. An adapter can make the control more CSS friendly, regardless of whether or not you use
        templates.        
    </p>
    <p>
        All of the sample adapters for the Membership controls produce markup that is easier to style
        with CSS while retaining most of the control's original server-side logic.
    </p>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="LiveExample">
    <div id="SamplePasswordRecovery">
        <asp:PasswordRecovery runat="server" ID="passwordrecovery1" SkinID="SamplePasswordRecovery"             
            CssSelectorClass="PrettyPasswordRecovery"
            
            UserNameTitleText="Step 1" 
            UserNameLabelText="User Name:"
            UserNameInstructionText="Whose password are you recovering?"

            QuestionTitleText="Step 2"
            AnswerLabelText="Answer:"            
            QuestionLabelText="Security Question:"
            QuestionInstructionText="Please confirm your identity by answering this question."
            
            SuccessText="Your password has been emailed to you." 
            
            GeneralFailureText="Sorry, there has been a problem. Try again later."
            UserNameFailureText="There is a problem with the user name you provided.  Please try again."
            QuestionFailureText="The answer you provided is incorrect. Please check your records and try again."
           
            SubmitButtonImageUrl="" SubmitButtonText="go" SubmitButtonType="Button" 
            
            OnSendMailError="DoSendMailError" />       
    </div>
    <div class="membershipHint">
        <p><strong>Hints:</strong></p>
        <p>Use the following values when filling out the password recovery form.</p>
        <ul>
            <li>Step 1: User Name = <strong>fred</strong></li>
            <li>Step 2: Security Question Answer = <strong>Flintstone</strong></li>
        </ul>
        <p>What would you like to do next?</p>
        <ul>
            <li><a href="PasswordRecovery.aspx">return to step 1 of this control</a></li>
            <li><a href="Login.aspx">login/logout</a></li>
            <li><a href="CreateUserWizard.aspx">register</a></li>
            <li><a href="ChangePassword.aspx">change the password</a></li>            
        </ul>
    </div>
</asp:Content>
