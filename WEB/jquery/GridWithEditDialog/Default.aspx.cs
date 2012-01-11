using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
	private CustomerService _customerService;

	#region Properties
	private bool IsAdd
	{
		get
		{
			return (!EditCustomerID.HasValue);
		}
	}

	private int? EditCustomerID
	{
		get
		{
			return (int?)ViewState["EditCustomerID"];
		}

		set
		{
			ViewState["EditCustomerID"] = value;
		}
	}

	#endregion


	protected void Page_Load(object sender, EventArgs e)
    {
		_customerService = new CustomerService();

		if (!IsPostBack)
		{
			GridDataBind();
		}
    }


	private void GridDataBind()
	{
		gvCustomers.DataSource = _customerService.GetAll();
		gvCustomers.DataBind();
	}


	protected void btnAddCustomer_Click(object sender, EventArgs e)
	{
		this.EditCustomerID = null;

		ClearEditCustomerForm();	//In case using non-modal

		RegisterStartupScript("jsUnblockDialog", "unblockDialog();");
	}


	private void ClearEditCustomerForm()
	{
		//Empty out text boxes
		var textBoxes=new List<Control>();
		FindControlsOfType(this.phrEditCustomer, typeof(TextBox), textBoxes);
		
		foreach (TextBox textBox in textBoxes)
			textBox.Text = "";

		//Clear validators
		var validators=new List<Control>();
		FindControlsOfType(this.phrEditCustomer, typeof(BaseValidator), validators);
	
		foreach (BaseValidator validator in validators)
			validator.IsValid = true;
	}


	static public void FindControlsOfType(Control root, Type controlType, List<Control> list)
	{
		if (root.GetType() == controlType || root.GetType().IsSubclassOf(controlType))
		{
			list.Add(root);
		}

		//Skip input controls
		if (!root.HasControls())
			return;

		foreach (Control control in root.Controls)
		{
			FindControlsOfType(control, controlType, list);
		}
	}


	protected void gvCustomer_RowDataBound(object sender, GridViewRowEventArgs e)
	{
		if (e.Row.DataItem == null)
			return;

		LinkButton btnEdit = (LinkButton)e.Row.FindControl("btnEdit");
		btnEdit.OnClientClick = "openDialogAndBlock('Edit Customer', '" + btnEdit.ClientID + "')";
	}


	protected void gvCustomers_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		int customerID = Convert.ToInt32(e.CommandArgument);

		switch (e.CommandName)
		{
			//Can't use just Edit and Delete or need to bypass RowEditing and Deleting
			case "EditCustomer":
				Customer customer = _customerService.GetByID(customerID);
				FillEditCustomerForm(customer);

				this.EditCustomerID = customerID;
				RegisterStartupScript("jsUnblockDialog", "unblockDialog();");
				
				//Setting timer to test longer loading
				//Thread.Sleep(2000);
				break;

			case "DeleteCustomer":
				_customerService.Delete(customerID);

				GridDataBind();
				break;
		}
	}

	private void FillEditCustomerForm(Customer customer)
	{
		txtFirstName.Text = customer.FirstName;
		txtLastName.Text = customer.LastName;
		txtEmail.Text = customer.Email;
		txtPhone.Text = customer.Phone;
		txtDateOfBirth.Text = customer.DateOfBirth.HasValue ? customer.DateOfBirth.Value.ToShortDateString() : "";
	}

	
	private void TriggerClientGridRefresh()
	{
		string script = "__doPostBack(\"" + btnRefreshGrid.ClientID + "\", \"\");";
		RegisterStartupScript("jsGridRefresh", script);
	}


	private void RegisterStartupScript(string key, string script)
	{
		ScriptManager.RegisterStartupScript(phrJsRunner, phrJsRunner.GetType(), key, script, true);
	}

	protected void btnSave_Click(object sender, EventArgs e)
	{
		if (!Page.IsValid)
			return;

		Customer customer;

		if (this.IsAdd)
			customer = new Customer();
		else
			customer = _customerService.GetByID(this.EditCustomerID.Value);

		customer.FirstName = txtFirstName.Text;
		customer.LastName = txtLastName.Text;
		customer.Email = txtEmail.Text;
		customer.Phone = txtPhone.Text;

		if (!String.IsNullOrEmpty(txtDateOfBirth.Text))
			customer.DateOfBirth = DateTime.Parse(txtDateOfBirth.Text);

		if (this.IsAdd)
			_customerService.Add(customer);
		else
			_customerService.Update(customer);

		HideEditCustomer();

		TriggerClientGridRefresh();
	}


	private void HideEditCustomer()
	{
		ClearEditCustomerForm();

		RegisterStartupScript("jsCloseDialg", "closeDialog();");
	}


	protected void btnCancel_Click(object sender, EventArgs e)
	{
		HideEditCustomer();
	}


	protected void btnRefreshGrid_Click(object sender, EventArgs e)
	{
		GridDataBind();
	}
}
