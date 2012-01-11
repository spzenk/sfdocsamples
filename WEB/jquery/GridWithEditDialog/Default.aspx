<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <!-- from http://encosia.com/2009/10/11/do-you-know-about-this-undocumented-google-cdn-feature/ -->
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/themes/start/jquery-ui.css" type="text/css" rel="Stylesheet" />
	
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.0/jquery.min.js"></script>
	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.7.2/jquery-ui.min.js"></script>
	
	
	<script type="text/javascript" src="<%= ResolveUrl("~")%>Content/Scripts/jquery.blockUI.js"></script>
	
	<!-- fix for 1.1em default font size in Jquery UI -->
	<style type="text/css">
		.ui-widget{font-size:11px !important;}
		.ui-state-error-text{margin-left: 10px}
	</style>

	
	<script type="text/javascript">
		$(document).ready(function() {
			$("#divEditCustomer").dialog({
				autoOpen: false,
				modal: true,
				minHeight: 20,
				height: 'auto',
				width: 'auto',
				resizable: false,
				open: function(event, ui) {
					$(this).parent().appendTo("#divEditCustomerDlgContainer");
				},
			});
		});


		function closeDialog() {
			//Could cause an infinite loop because of "on close handling"
			$("#divEditCustomer").dialog('close');
		}
		
		function openDialog(title, linkID) {
		
			var pos = $("#" + linkID).position();
			var top = pos.top;
			var left = pos.left + $("#" + linkID).width() + 10;
			
			
			$("#divEditCustomer").dialog("option", "title", title);
			$("#divEditCustomer").dialog("option", "position", [left, top]);
			
			$("#divEditCustomer").dialog('open');
		}



		function openDialogAndBlock(title, linkID) {
			openDialog(title, linkID);

			//block it to clean out the data
			$("#divEditCustomer").block({
				message: '<img src="<%=ResolveUrl("~") %>content/images/async.gif" />',
				css: { border: '0px' },
				fadeIn: 0,
				//fadeOut: 0,
				overlayCSS: { backgroundColor: '#ffffff', opacity: 1 } 
			});
		}

		
		function unblockDialog() {
			$("#divEditCustomer").unblock();
		}

		function onTest() {
			$("#divEditCustomer").block({
				message: '<h1>Processing</h1>',
				css: { border: '3px solid #a00' },
				overlayCSS: { backgroundColor: '#ffffff', opacity: 1 } 
			});
		}
	</script>
	
</head>
<body>
    <form id="form1" runat="server">
		<asp:ScriptManager ID="scriptManager" runat="server" />
		
		<h1>Customers</h1>
		<div id="divEditCustomerDlgContainer">	
			<div id="divEditCustomer" style="display:none">
					
				<asp:UpdatePanel ID="upnlEditCustomer" runat="server">
					<ContentTemplate>
						<asp:PlaceHolder ID="phrEditCustomer" runat="server">
							<table cellpadding="3" cellspacing="1">
							<tr>
								<td>
									*First Name:
								</td>
								<td>
									<asp:TextBox ID="txtFirstName" Columns="40" MaxLength="50" runat="server" />
									<asp:RequiredFieldValidator ID="vtxtFirstName" runat="server" EnableClientScript="false" CssClass="ui-state-error-text" Display="Dynamic" ErrorMessage="Required." ControlToValidate="txtFirstName" />
								</td>
							</tr>
							<tr>
								<td>
									*Last Name:
								</td>
								<td>
									<asp:TextBox ID="txtLastName" Columns="40" MaxLength="50" runat="server" />
									<asp:RequiredFieldValidator ID="vtxtLastName" runat="server" EnableClientScript="false"  CssClass="ui-state-error-text" Display="Dynamic" ErrorMessage="Required." ControlToValidate="txtLastName" />
								</td>
							</tr>
							
							<tr>
								<td>
									*Email:
								</td>
								<td>
									<asp:TextBox ID="txtEmail" Columns="40" MaxLength="50" runat="server" />
									<asp:RequiredFieldValidator ID="vtxtEmail" runat="server" EnableClientScript="false"  CssClass="ui-state-error-text" Display="Dynamic" ErrorMessage="Required." ControlToValidate="txtEmail" />
									<asp:RegularExpressionValidator ID="vtxtEmail2" runat="server" EnableClientScript="false" CssClass="ui-state-error-text"
											ControlToValidate="txtEmail" ValidationExpression=".*@.*\..*" ErrorMessage="Not a valid email."  Display="Dynamic"/>

								</td>
							</tr>
							
								<tr>
								<td>
									Phone:
								</td>
								<td>
									<asp:TextBox ID="txtPhone" Columns="20" MaxLength="20" runat="server" />
								</td>
							</tr>
							
							
							<tr>
								<td>
									Date of Birth:
								</td>
								<td>
									<asp:TextBox ID="txtDateOfBirth" Columns="10" MaxLength="20" runat="server" />
									<asp:CompareValidator  ID="vtxtDateOfBirth"  runat="server"  EnableClientScript="false" CssClass="ui-state-error-text"
											   ControlToValidate="txtDateOfBirth" ErrorMessage="Not a valid date."
											   Operator="DataTypeCheck" Type="Date" />


								</td>
							</tr>
							<tr>
								<td colspan="2" align="right">
									<asp:Button ID="btnSave" onclick="btnSave_Click" Text="Save" runat="server" />
									<asp:Button ID="btnCancel" onclick="btnCancel_Click" onClientClick="closeDialog()" CausesValidation="false" Text="Cancel" runat="server" />
								</td>
							</tr>
							</table>
								
						</asp:PlaceHolder>
						
						
					</ContentTemplate>
							
				</asp:UpdatePanel>
			
			</div>
		</div>	<!-- divEditCustomerDlgContainer -->
				
		 
		<!--
		<br /><br />
		<input type="button" id="btnTest" onclick="onTest" value="Test" />
		<br /><br />
		-->
		
		<asp:UpdatePanel ID="upnlCustomers" UpdateMode="Conditional" runat="server">
			<ContentTemplate>
				<asp:LinkButton ID="btnAddCustomer" Text="Add Customer" runat="server" OnClientClick="openDialogAndBlock('Add Customer', 'btnAddCustomer')" CausesValidation="false" onclick="btnAddCustomer_Click"></asp:LinkButton>		
				<br /><br />						
	
				<asp:GridView ID="gvCustomers" runat="server"
									AutoGenerateColumns="False" CellPadding="4" CellSpacing="1"
									onRowDataBound="gvCustomer_RowDataBound"
									onRowCommand="gvCustomers_RowCommand">
					<Columns>
						<asp:TemplateField HeaderText="Name">
							<ItemTemplate>
								<%# Eval("FirstName") + " " + Eval("LastName")%> 
							</ItemTemplate>
						</asp:TemplateField>
						<asp:BoundField DataField="Phone" HeaderText="Phone" />
						<asp:BoundField DataField="Email" HeaderText="Email" />
						<asp:BoundField DataField="DateOfBirth" HeaderText="Date Of Birth" DataFormatString="{0:MMMM d, yyyy}" />
						<asp:TemplateField HeaderText="Actions">
							<ItemTemplate>
								<asp:LinkButton ID="btnEdit" Text="Edit" CommandName="EditCustomer" CausesValidation="false" CommandArgument='<%#Eval("ID")%>' runat="server"></asp:LinkButton>	
								<asp:LinkButton ID="btnDelete" Text="Delete" CommandName="DeleteCustomer" CausesValidation="false" CommandArgument='<%#Eval("ID")%>' runat="server"></asp:LinkButton>	
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>
				
				<asp:LinkButton ID="btnRefreshGrid" CausesValidation="false" OnClick="btnRefreshGrid_Click" style="display:none" runat="server"></asp:LinkButton>		
		
				
			</ContentTemplate>
		</asp:UpdatePanel>
		
		
		<asp:UpdatePanel ID="upnlJsRunner" UpdateMode="Always" runat="server">
			<ContentTemplate>
				<asp:PlaceHolder ID="phrJsRunner" runat="server"></asp:PlaceHolder>
			</ContentTemplate>
		</asp:UpdatePanel>
    </form>
</body>
</html>
