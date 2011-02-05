<%@ Page Title="" Language="C#" MasterPageFile="~/AnimationExtender.master" AutoEventWireup="true" CodeBehind="AnimationExtender_MouseOver.aspx.cs" Inherits="AjaxControlToolkitSample.Modules.AnimationExtender_MouseOver" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id = "ff" class="EnvelopeContNews">
      
        

    <asp:Button ID="btnInfo" runat="server" Text="Button" />
    <div id="flyout" class="flyOutDiv2">
        <div style="float: right;">
            <asp:LinkButton ID="btnClose" runat="server" Text="X" OnClientClick="return false;"
                CssClass="flyOutDivCloseX" />
        </div>
        <br />
        <p>
            some content here for whatever text
        </p>
    </div>
        
    <cc1:AnimationExtender ID="OpenAnimation" runat="server" TargetControlID="btnInfo">
        <Animations>
                <OnClick>
                    <Sequence>
                       <%-- Disable the button --%>
                         <EnableAction Enabled="false"></EnableAction>
                       <%-- Show the flyout --%>
                        <Parallel AnimationTarget="flyout" Duration=".3" Fps="25">
                            <Move Horizontal="150" Vertical="-50" />
                            <Resize Height="260" Width="280" />
                            <Color AnimationTarget="flyout" PropertyKey="backgroundColor"
                                    StartValue="#AAAAAA" EndValue="#FFFFFF" />
                            
                        </Parallel>
                   
                    </Sequence>
                </OnClick>
        </Animations>
    </cc1:AnimationExtender>


    </div>
</asp:Content>
