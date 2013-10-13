<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SampleWebApplication.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="Default.aspx.min.js"></script>
</head>
<body>
    <p>
        This sample script adds two numbers.</p>
    <form id="form1" runat="server">
    <div>
        <input type="text" id="text1" />
        <input type="text" id="text2" />
        <input type="button" id="button1" onclick="button1_onclick()" />
    </div>
    </form>
</body>
</html>
