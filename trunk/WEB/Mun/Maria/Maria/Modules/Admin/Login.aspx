<%@ Page Title="" Language="C#" MasterPageFile="~/SurveyWeb.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BigBang.FrontEnd.Survey.Web.Login" ValidateRequest="false" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dxpc" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.ExpressApp.Web.Templates.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.ASPxTreeList.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.Web.ASPxTreeList" TagPrefix="dxwtl" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register assembly="DevExpress.Web.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxCallback" tagprefix="dxcb" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="LoginContainer">
        <!-- (+) Login -->
        <dxrp:ASPxRoundPanel id="pnlLogin" runat="server" backcolor="White" cssfilepath="~/App_Themes/Aqua/{0}/styles.css" csspostfix="Aqua">
            <HeaderTemplate>
                Bienvenido a BigBang
            </HeaderTemplate>
            <TopEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpTopEdge.gif" Repeat="RepeatX" VerticalPosition="Top" />
            </TopEdge>
            <LeftEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpLeftEdge.gif" Repeat="RepeatY" VerticalPosition="Top" />
            </LeftEdge>
            <BottomRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpBottomRight.png" Width="7px" />
            <ContentPaddings Padding="14px" />
            <NoHeaderTopRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpNoHeaderTopRight.png" Width="7px" />
            <RightEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpRightEdge.gif" Repeat="RepeatY" VerticalPosition="Top" />
            </RightEdge>
            <HeaderRightEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX" VerticalPosition="Top" />
            </HeaderRightEdge>
            <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            <HeaderLeftEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX" VerticalPosition="Top" />
            </HeaderLeftEdge>
            <HeaderStyle BackColor="#E0EDFF">
            <BorderBottom BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            </HeaderStyle>
            <BottomEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpBottomEdge.gif" Repeat="RepeatX" VerticalPosition="Bottom" />
            </BottomEdge>
            <TopRightCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpTopRight.png" Width="7px" />
            <HeaderContent>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX" VerticalPosition="Top" />
            </HeaderContent>
            <NoHeaderTopEdge BackColor="White">
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpNoHeaderTopEdge.gif" Repeat="RepeatX" VerticalPosition="Top" />
            </NoHeaderTopEdge>
            <NoHeaderTopLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpNoHeaderTopLeft.png" Width="7px" />
            <PanelCollection>
                <dxrp:PanelContent ID="PanelContent1" runat="server">
                    <!-- (+) Contenido -->
                    <table width="100%">
                        <tr>
                            <td align="center">
                                <table border="0" cellpadding="0" cellspacing="10" class="LoginTable">
                                    <tr>
                                        <td align="right" width="120px" height="28px">
                                            <asp:Label ID="AuthModeLabel" runat="server" AssociatedControlID="AuthenticationMode">Autenticación: 
                                            </asp:Label>
                                        </td>
                                        <td width="250px" align="left">
                                            <dxe:ASPxComboBox ID="AuthenticationMode" runat="server" AutoPostBack="True" 
                                                ValueType="System.Int32" Width="250px" onload="AuthenticationMode_Load">
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            <asp:Label ID="DomainLabel" runat="server" AssociatedControlID="Domains">Dominio: </asp:Label>
                                        </td>
                                        <td  align="left">
                                            <dxe:ASPxComboBox ID="Domains" runat="server" Width="250px" 
                                                ValueType="System.String" onload="Domains_Load">
                                                <DisabledStyle  BackColor="#EEEEEE" ForeColor="#AAAAAA"></DisabledStyle>
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                </table>
                                <asp:UpdatePanel ID="uplLogin" runat="server" EnableViewState="true">
                                    <ContentTemplate>
                                        <asp:Login ID="Login1" runat="server" 
                                            DestinationPageUrl="~/Forms/RecordSetMannager/SelectRecordSet.aspx" 
                                            FailureText="Verifique Usuario o Clave."
                                            LoginButtonText="Iniciar Sesión" PasswordRequiredErrorMessage="La Clave es requerida."
                                            RememberMeText="Recordarme la próxima vez" TitleText="Ingrese sus Credenciales"
                                            UserNameLabelText="Usuario" UserNameRequiredErrorMessage="El Usuario es requerido."
                                            PasswordLabelText="Clave:" onauthenticate="Login1_Authenticate">
                                            <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
                                            <LayoutTemplate>
                                                <table cellpadding="0" cellspacing="10" class="LoginTable">
                                                    <tr>
                                                        <td align="right" width="120px">
                                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuario: </asp:Label>
                                                        </td>
                                                        <td width="250px" align="left">
                                                            <dxe:ASPxTextBox ID="UserName" runat="server" MaxLength="30" Width="180px" 
                                                                style="display: inline;" onload="UserName_Load">
                                                                <DisabledStyle BackColor="#EEEEEE" ForeColor="#AAAAAA"></DisabledStyle>
                                                            </dxe:ASPxTextBox>
                                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                                ErrorMessage="El Usuario es requerido." ToolTip="El Usuario es requerido." 
                                                                ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Clave: </asp:Label>
                                                        </td>
                                                        <td align="left">
                                                            <dxe:ASPxTextBox ID="Password" runat="server" MaxLength="30" Password="true"
                                                                    Width="180px" style="display: inline;">
                                                                <DisabledStyle BackColor="#EEEEEE" ForeColor="#AAAAAA"></DisabledStyle>
                                                            </dxe:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;
                                                        </td>
                                                        <td align="center" style="width: 250px;">
                                                            <dxe:ASPxButton ID="LoginButton" runat="server" 
                                                                CommandName="Login" Text="Iniciar Sesión"
                                                                ValidationGroup="Login1" Width="120px" CssClass="FloatLeft" />
                                                            <dxe:ASPxButton ID="ChangePasswordButton" runat="server"
                                                                CommandName="Login" Text="Cambiar Clave"
                                                                ValidationGroup="Login1" Width="120px" CssClass="FloatRight" 
                                                                ClientInstanceName="CambiarClaveButton" 
                                                                CommandArgument="CambiarClave" oncommand="ChangePasswordButton_Command" />
                                                        </td>
                                                    </tr>
                                                </table>
                                                <div style="padding: 10px; color: red; width: 500px; text-align: center; font-size: 10px;">
                                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                </div>
                                            </LayoutTemplate>
                                        </asp:Login>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="Login1" EventName="LoggedIn" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:UpdateProgress AssociatedUpdatePanelID="uplLogin" runat="server" ID="upnlprgFilters"  DisplayAfter="1">
                                    <ProgressTemplate>
                                        <div id="progressFilters">
                                            <br />
                                            <img src="../Images/bb_logo_00010.png" />
                                            &nbsp; Consultando servidor...
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </td>
                        </tr>
                    </table>
                    <!-- (-) Contenido -->
                </dxrp:PanelContent>
            </PanelCollection>
            <TopLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpTopLeft.png" Width="7px" />
            <BottomLeftCorner Height="7px" Url="~/App_Themes/Aqua/Web/rpBottomLeft.png" Width="7px" />
        </dxrp:ASPxRoundPanel>    
        <!-- (-) Login -->
    </div>
</asp:Content>