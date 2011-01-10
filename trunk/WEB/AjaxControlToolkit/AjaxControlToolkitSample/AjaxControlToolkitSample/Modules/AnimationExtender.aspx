<%@ Page Title="" Language="C#" MasterPageFile="~/mariaDiv.Master" AutoEventWireup="true" CodeBehind="AnimationExtender.aspx.cs" Inherits="AjaxControlToolkitSample.AnimationExtender" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentLeft" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentCenter" runat="server">
<div id="Div3" class ="EnvelopeContNews">
        <asp:LinkButton ID="lnkBtnColHelp" runat="server" Text="Click Here" OnClientClick="return false;" />

        <div id="moveMe" class="flyOutDiv">
          <div style="float:right;">
         <asp:LinkButton ID="lnkBtnCloseColHelp" runat="server" Text="X" OnClientClick="return false;" CssClass="flyOutDivCloseX" />
          </div>
        <br />
             <p>
                some content here for whatever text
             </p>                         
        </div>
 
<cc1:AnimationExtender ID="AnimationExtender1" runat="server" TargetControlID="lnkBtnColHelp">
            <Animations>
                <OnClick>
                    <Sequence>
                        <EnableAction Enabled="false"></EnableAction>
 
                        <StyleAction AnimationTarget="moveMe" Attribute="display" Value="block"/>
                        <Parallel   AnimationTarget="moveMe" Duration=".5" Fps="30">
                            <Move Horizontal="350" Vertical="150"></Move>
                            <FadeIn Duration=".5"/>
                        </Parallel>
                        <Parallel AnimationTarget="moveMe" Duration=".5">
                             <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                            <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                        </Parallel>
                    </Sequence>
                </OnClick>
            </Animations>
       
        </cc1:AnimationExtender>

     
        <cc1:AnimationExtender ID="AnimationExtender2" runat="server" TargetControlID="lnkBtnCloseColHelp">
       
            <Animations>
                <OnClick>
                    <Sequence AnimationTarget="moveMe">
                        <Parallel AnimationTarget="moveMe" Duration=".7" Fps="20">
                            <Move Horizontal="350" Vertical="50"></Move>
                            <Scale ScaleFactor="0.05" FontUnit="px" />
                            <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                            <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                            <FadeOut />
                        </Parallel>
                        <StyleAction Attribute="display" Value="none"/>
                        <StyleAction Attribute="height" Value=""/>
                        <StyleAction Attribute="width" Value="400px"/>
                        <StyleAction Attribute="fontSize" Value="14px"/>
                        <EnableAction AnimationTarget="lnkBtnColHelp" Enabled="true" />
                    </Sequence>
                </OnClick>
            </Animations>
       
</cc1:AnimationExtender>


      
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentRight" runat="server">
</asp:Content>
