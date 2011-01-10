<%@ Page Title="" Language="C#" MasterPageFile="~/AnimationExtender.master" AutoEventWireup="true" CodeBehind="AnimationExtender_MouseOver.aspx.cs" Inherits="AjaxControlToolkitSample.Modules.AnimationExtender_MouseOver" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div id = "ff" class="EnvelopeContNews">
        <div id="flyout" class="flyOutDiv1">
            <asp:LinkButton ID="btnInfo" runat="server" Text="Ayuda 1" OnClientClick="return false;" />
        </div>
        <div id="info" class="flyOutDiv1">
            <asp:LinkButton ID="LinkButton2" runat="server" Text="Ayuda 2" OnClientClick="return false;" />
        </div>
        <cc1:AnimationExtender ID="OpenAnimation" runat="server" TargetControlID="btnInfo">
            <Animations>
    <OnClick>
        <Sequence>

            <EnableAction Enabled="false" /> 
     
            <Parallel AnimationTarget="flyout" Duration=".3" Fps="25">
                <Move Horizontal="150" Vertical="-50" />
                <Resize Height="300" Width="280" />
                <Color AnimationTarget="flyout" PropertyKey="backgroundColor"
                        StartValue="#AAAAAA" EndValue="#FFFFFF" />
            </Parallel>
      
            <FadeIn AnimationTarget="info" Duration=".2"/>
  
            <Parallel AnimationTarget="info" Duration=".5">
                <Color PropertyKey="color"
                        StartValue="#666666" EndValue="#FF0000" />
                <Color PropertyKey="borderColor"
                        StartValue="#666666" EndValue="#FF0000" />
            </Parallel>
            <Parallel AnimationTarget="info" Duration=".5">
                <Color PropertyKey="color"
                        StartValue="#FF0000" EndValue="#666666" />
                <Color PropertyKey="borderColor"
                        StartValue="#FF0000" EndValue="#666666" />
                <FadeIn AnimationTarget="btnCloseParent" MaximumOpacity=".9" />
            </Parallel>
        </Sequence>
    </OnClick>
            </Animations>
        </cc1:AnimationExtender>
    </div>
</asp:Content>
