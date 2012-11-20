<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WCFWebSite._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">


<script type="text/javascript">

    var varType;
    var varUrl;
    var varData;
    var varContentType;
    var varDataType;
    var varProcessData;

    function CallService() {
        $.ajax({
            type: varType, //GET or POST or PUT or DELETE verb
            url: varUrl, // Location of the service
            data: varData, //Data sent to server
            contentType: varContentType, // content type sent to server
            dataType: varDataType, //Expected data format from server
            processdata: varProcessData, //True or False
            success: function (msg) {//On Successfull service call
                ServiceSucceeded(msg);
            },
            error: ServiceFailed// When Service call fails
        });
    }

    function TestJSON_GET() {
       
        varType = "GET";
        varUrl = "service/CoreSecurityAspnet.svc/Test_Get?value=" + $('#frm_inputtext').val();
        varContentType = "application/json; charset=utf-8";
        varDataType = "json"; varProcessData = false; CallService();
    }

    function Test_POST_XML() {
        varType = "POST";
        varUrl = "service/CoreSecurityAspnet.svc/Test_POST_XML";
        varData = '{"value": "' + $('#frm_inputtext').val() + '"}';
        varContentType = "application/json; charset=utf-8";
        varDataType = "xml";
        varProcessData = true;
        CallService();
    }

    function ServiceSucceeded(result) {
        alert(result.toString());
        alert(result);
        alert(result[0]);
    }

    function ServiceFailed(result) {
        alert('Service call failed: ' + result.status + '' + result.statusText);
        varType = null; varUrl = null; varData = null; varContentType = null; varDataType = null; varProcessData = null;
    }
</script>
    <h2>
        Test calling WCF from ajax jquery 
    </h2>
    <p>
        Click to call service
    </p>
    <input id="Submit1" type="submit" value="Call WCF GET/REST Ajax" onclick="Test_POST_XML();return false;" />
    <input class="frm_inputtext"  id="txtAlias" type="text"  style="font-size:14px; width:200px;height:2em;background-color:#FFFFE6;"/>
    
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
</asp:Content>
