<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UC1.ascx.cs" Inherits="UserControls_UC1" %>
<%@ Register Assembly="DevExpress.Web.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register assembly="DevExpress.Web.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.Web.ASPxPanel" tagprefix="dxp" %>
<%@ Register assembly="DevExpress.XtraCharts.v9.1.Web, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.XtraCharts.Web" tagprefix="dxchartsui" %>
<%@ Register assembly="DevExpress.XtraCharts.v9.1, Version=9.1.4.0, Culture=neutral, PublicKeyToken=5377c8e3b72b4073" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>
<script runat="server">
  private int results;
  
  [Personalizable]
  public int ResultsPerPage
  {
    get
      {return results;}
    
    set
      {results = value;}
  }    
</script>

<dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" Width="513px" 
    BackColor="White" Height="131px">
    <BottomRightCorner Height="5px" 
        Url="~/Images/ASPxRoundPanel/964777138/BottomRightCorner.png" Width="5px" />
    <NoHeaderTopRightCorner Height="5px" 
        Url="~/Images/ASPxRoundPanel/964777138/NoHeaderTopRightCorner.png" 
        Width="5px" />
    <HeaderRightEdge>
        <BackgroundImage HorizontalPosition="right" 
            ImageUrl="~/Images/ASPxRoundPanel/964777138/HeaderRightEdge.png" 
            Repeat="NoRepeat" VerticalPosition="bottom" />
    </HeaderRightEdge>
    <Border BorderColor="#8B8B8B" BorderStyle="Solid" BorderWidth="1px" />
    <HeaderLeftEdge>
        <BackgroundImage HorizontalPosition="left" 
            ImageUrl="~/Images/ASPxRoundPanel/964777138/HeaderLeftEdge.png" 
            Repeat="NoRepeat" VerticalPosition="bottom" />
    </HeaderLeftEdge>
    <HeaderStyle BackColor="#004080">
    <BorderLeft BorderStyle="None" />
    <BorderRight BorderStyle="None" />
    <BorderBottom BorderStyle="None" />
    </HeaderStyle>
    <TopRightCorner Height="5px" 
        Url="~/Images/ASPxRoundPanel/964777138/TopRightCorner.png" Width="5px" />
    <HeaderContent>
        <BackgroundImage HorizontalPosition="left" 
            ImageUrl="~/Images/ASPxRoundPanel/964777138/HeaderContent.png" Repeat="RepeatX" 
            VerticalPosition="bottom" />
    </HeaderContent>
    <NoHeaderTopLeftCorner Height="5px" 
        Url="~/Images/ASPxRoundPanel/964777138/NoHeaderTopLeftCorner.png" Width="5px" />
    <PanelCollection>
<dxp:PanelContent runat="server">
    <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" 
        DataSourceID="LinqDataSource1" Height="200px" Width="300px">
        <fillstyle filloptionstypename="SolidFillOptions">
<options 
            hiddenserializablestring="to be serialized"></options>
</fillstyle>
        <SeriesSerializable>
            <cc1:Series LabelTypeName="PieSeriesLabel" Name="Series 1" 
                PointOptionsTypeName="PiePointOptions" SeriesViewTypeName="PieSeriesView" 
                ArgumentDataMember="Name">
                <View HiddenSerializableString="to be serialized" RuntimeExploding="False">
                </View>
                <Label HiddenSerializableString="to be serialized" LineVisible="True" 
                    OverlappingOptionsTypeName="OverlappingOptions">
                    
<FillStyle FillOptionsTypeName="SolidFillOptions">
                        
<Options HiddenSerializableString="to be serialized" />
                    
</FillStyle>
                
</Label>
                <PointOptions HiddenSerializableString="to be serialized">
                </PointOptions>
                <LegendPointOptions HiddenSerializableString="to be serialized">
                </LegendPointOptions>
            </cc1:Series>
        </SeriesSerializable>
        <seriestemplate labeltypename="PieSeriesLabel" 
            pointoptionstypename="PiePointOptions" seriesviewtypename="PieSeriesView">
<view 
            hiddenserializablestring="to be serialized" runtimeexploding="False"></view>

<label 
            hiddenserializablestring="to be serialized" linevisible="True" 
            overlappingoptionstypename="OverlappingOptions">
<fillstyle 
            filloptionstypename="SolidFillOptions"><options 
            hiddenserializablestring="to be serialized"></options></fillstyle>
</label>

<pointoptions 
            hiddenserializablestring="to be serialized"></pointoptions>

<legendpointoptions 
            hiddenserializablestring="to be serialized"></legendpointoptions>
</seriestemplate>
    </dxchartsui:WebChartControl>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="DataClassesDataContext" GroupBy="Name" OrderGroupsBy="key" 
        Select="new (key as Name, it as TotalAmountByProductByYears)" 
        TableName="TotalAmountByProductByYears">
    </asp:LinqDataSource>
        </dxp:PanelContent>
</PanelCollection>
    <TopLeftCorner Height="5px" 
        Url="~/Images/ASPxRoundPanel/964777138/TopLeftCorner.png" Width="5px" />
    <BottomLeftCorner Height="5px" 
        Url="~/Images/ASPxRoundPanel/964777138/BottomLeftCorner.png" Width="5px" />
</dxrp:ASPxRoundPanel>
