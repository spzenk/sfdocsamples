<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateUserWizard.aspx.cs" Inherits="_CreateUserWizard" MasterPageFile="~/Examples.master" StyleSheetTheme="Basic" Title="CreateUserWizard Control Adapter: ASP.NET 2.0 CSS Friendly Control Adapters 1.0" %>

<asp:Content runat="server" ContentPlaceHolderID="Prolog">
    <p>
        The CreateUserWizard control is a kind of CompositeControl like the other ASP.NET Membership controls.
        So it isn't surprising that, like most of the ASP.NET Membership controls, it normally produces nested 
        &lt;table&gt; tags and frequently uses inline styling. An adapter can produce less bulky markup that positions
        content with CSS rather than tables.
    </p>
    <p>
        This sample CreateUserWizard adapter supports many, but not all, of the control's features.  For example,
        the sample adapter supports the optional templates for the CreateUserWizardStep and CompleteWizardStep but
        the does not support navigation templates or extra wizard steps.
    </p>
</asp:Content>

<asp:Content runat="server" ContentPlaceHolderID="LiveExample">
    <div id="SampleCreateUserWizard">
        <asp:CreateUserWizard ID="createuserwizard1" runat="server" SkinID="SampleCreateUserWizard"
            CssSelectorClass="PrettyCreateUserWizard"
            HeaderText="REGISTRATION"
            InstructionText="<strong>We're glad you want to become a member!</strong><br />- Enter a user name and password of your choice (type your password twice to ensure against mistakes).<br />- Enter your email address (this is where we'll send your password if you ever forget it).<br />- Make up a question and answer that only you will know (we'll use this information to confirm your identity before sending your password via email)." 
            UserNameLabelText="User Name:"            
            PasswordLabelText="Password:"
            PasswordHintText="Please see the HINT box below for the user name and password that can be used with this sample." 
            ConfirmPasswordLabelText="Confirm Password:"
            EmailLabelText="Email:"
            QuestionLabelText="Security Question:"
            AnswerLabelText="Answer to your Security Question:"
            CompleteSuccessText="Your account has been created successfully. You're already logged in so just click the continue button to get started."

            ContinueDestinationPageUrl="LoginStatus.aspx"
            ContinueButtonImageUrl="" ContinueButtonText="continue" ContinueButtonType="Button"             
            CreateUserButtonImageUrl="" CreateUserButtonText="create user" CreateUserButtonType="Button"
                        
            ToolTip="Please register.">
            <WizardSteps>
                <asp:CreateUserWizardStep runat="server">
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>    
    </div>
    <div class="membershipHint">
        <p><strong>Hints:</strong></p>
        <p>Use the following values when filling out the create user wizard form.</p>
        <ul>
            <li>User Name = <strong>fred</strong></li>
            <li>Password and Confirm Password = <strong>css!</strong></li>
        </ul>
        <p>(It doesn't matter what you type for the email and the security question and answer.)</p>    
        <p>When you click the "continue" button on the "Complete" page, you'll be taken to a page that 
            demonstrates the <a href="LoginStatus.aspx">LoginStatus</a> control.</p>
        <p>Please note that an account isn't actually created within the membership system (in fact, 
            the <strong>fred</strong> account already exists) but the control will behave as if it's creating an account.</p>
        <p>What would you like to do next?</p>
        <ul>
            <li><a href="CreateUserWizard.aspx">return to step 1 of this control</a></li>
            <li><a href="Login.aspx">login/logout</a></li>
            <li><a href="ChangePassword.aspx">change the password</a></li>
            <li><a href="PasswordRecovery.aspx">recover a lost password</a></li>
        </ul>            
</div>    
</asp:Content>
