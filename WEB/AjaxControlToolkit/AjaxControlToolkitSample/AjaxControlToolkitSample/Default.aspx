<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AjaxControlToolkitSample._Default" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Animation Extender Test</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            Click inside the panels
            <hr/>
            Animation within UpdatePanel:
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="MyPanel" runat="server" BackColor="Brown" Width="200px" Height="200px"/>
                    <ajaxToolkit:AnimationExtender id="MyExtender" runat="server" targetcontrolid="MyPanel">
                      <Animations>
                        <OnClick>
                            <Sequence>
                              <EnableAction Enabled="false" />
                              <Color AnimationTarget="MyPanel"
                                Duration="1"
                                StartValue="#FF0000"
                                EndValue="#666666"
                                Property="style"
                                PropertyKey="backgroundColor" />
                              <Color AnimationTarget="MyPanel"
                                Duration="1"
                                StartValue="#FF0000"
                                EndValue="#666666"
                                Property="style"
                                PropertyKey="backgroundColor" />
                              <EnableAction Enabled="true" />
                            </Sequence>
                        </OnClick>
                      </Animations>
                    </ajaxToolkit:AnimationExtender>
                </ContentTemplate>
            </asp:UpdatePanel>
            
         
            <telerik:RadAjaxPanel ID="RadAjaxPanel1" runat="server">
                    <asp:Panel ID="Panel1" runat="server" BackColor="Brown"  Width="200px" Height="200px"/>
                    <ajaxToolkit:AnimationExtender id="AnimationExtender1" runat="server" targetcontrolid="Panel1">
                      <Animations>
                        <OnClick>
                            <Sequence>
                              <EnableAction Enabled="false" />
                              <Color AnimationTarget="Panel1"
                                Duration="1"
                                StartValue="#FF0000"
                                EndValue="#666666"
                                Property="style"
                                PropertyKey="backgroundColor" />
                              <Color AnimationTarget="Panel1"
                                Duration="1"
                                StartValue="#FF0000"
                                EndValue="#666666"
                                Property="style"
                                PropertyKey="backgroundColor" />
                              <EnableAction Enabled="true" />
                            </Sequence>
                        </OnClick>
                      </Animations>
                    </ajaxToolkit:AnimationExtender>
            </telerik:RadAjaxPanel>
        </div>
    </form>
</body>
</html>
>
