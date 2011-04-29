<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="control1.ascx.cs" Inherits="Prueba.DinControls.control1" %>
<script src="../JS/jquery-1.3.2.js" type="text/javascript">

</script>

<script type ="text/javascript">


//    function showDivText() {
//        divObj = document.getElementById("Div");
//        if (divObj) {
//            if (divObj.textContent) { // FF
//                alert(divObj.textContent);
//            } else {  // IE                   
//                alert(divObj.innerText);  //alert ( divObj.innerHTML );
//            }
//        }
//    };

    function x() {

        divObj = document.getElementById("Hidden1");
        alert(divObj.value);
        divObj = document.getElementById("div");
        alert(divObj.textContent);
    }
//    $(document).ready(function () {

//        var id = $('#div').text();
//        alert(id);
//        $("#Button1").click(function () {
//            alert();
//        });


//    }); 
</script>
<div style = "top:20px;">
    <input id="Hidden1" type="hidden" value= "<%=this.controlId%>"/>
<div  id = "div"><%=this.controlId%></div>
<input id="Button2" type="button" value="button" onclick= "x();" />

<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</div>
