using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ObjectStorePart1
{
	/// <summary>
	/// Summary description for EmployeeForm.
	/// </summary>
	public class EmployeeForm : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button buttonFetchEmployee;
        private System.Windows.Forms.TextBox textBoxEmployeeFirstName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGrid dataGridAddress;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.TextBox textBoxEmployeeLastName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxEmployeeID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxEmployeeTitle;
        private System.Windows.Forms.Button buttonPersistEmployee;

        protected Employee _emp = null;
        protected ObjectRepository _repository = null;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonCreateEmployee;
        private System.Windows.Forms.Button buttonRemoveEmployee;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public EmployeeForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.textBoxEmployeeFirstName = new System.Windows.Forms.TextBox();
            this.buttonFetchEmployee = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridAddress = new System.Windows.Forms.DataGrid();
            this.buttonClose = new System.Windows.Forms.Button();
            this.textBoxEmployeeLastName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxEmployeeID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxEmployeeTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonPersistEmployee = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCreateEmployee = new System.Windows.Forms.Button();
            this.buttonRemoveEmployee = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAddress)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxEmployeeFirstName
            // 
            this.textBoxEmployeeFirstName.Location = new System.Drawing.Point(120, 48);
            this.textBoxEmployeeFirstName.Name = "textBoxEmployeeFirstName";
            this.textBoxEmployeeFirstName.Size = new System.Drawing.Size(64, 20);
            this.textBoxEmployeeFirstName.TabIndex = 0;
            this.textBoxEmployeeFirstName.Text = "";
            // 
            // buttonFetchEmployee
            // 
            this.buttonFetchEmployee.Location = new System.Drawing.Point(24, 320);
            this.buttonFetchEmployee.Name = "buttonFetchEmployee";
            this.buttonFetchEmployee.Size = new System.Drawing.Size(96, 23);
            this.buttonFetchEmployee.TabIndex = 1;
            this.buttonFetchEmployee.Text = "Fetch Employee";
            this.buttonFetchEmployee.Click += new System.EventHandler(this.buttonFetchEmployee_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(120, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "first name";
            // 
            // dataGridAddress
            // 
            this.dataGridAddress.DataMember = "";
            this.dataGridAddress.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGridAddress.Location = new System.Drawing.Point(40, 120);
            this.dataGridAddress.Name = "dataGridAddress";
            this.dataGridAddress.Size = new System.Drawing.Size(520, 104);
            this.dataGridAddress.TabIndex = 3;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(472, 360);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 24);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Close";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // textBoxEmployeeLastName
            // 
            this.textBoxEmployeeLastName.Location = new System.Drawing.Point(200, 48);
            this.textBoxEmployeeLastName.Name = "textBoxEmployeeLastName";
            this.textBoxEmployeeLastName.Size = new System.Drawing.Size(104, 20);
            this.textBoxEmployeeLastName.TabIndex = 5;
            this.textBoxEmployeeLastName.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(200, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "last name";
            // 
            // textBoxEmployeeID
            // 
            this.textBoxEmployeeID.Location = new System.Drawing.Point(40, 48);
            this.textBoxEmployeeID.Name = "textBoxEmployeeID";
            this.textBoxEmployeeID.Size = new System.Drawing.Size(56, 20);
            this.textBoxEmployeeID.TabIndex = 7;
            this.textBoxEmployeeID.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(40, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Employee ID";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Addresses";
            // 
            // textBoxEmployeeTitle
            // 
            this.textBoxEmployeeTitle.Location = new System.Drawing.Point(328, 48);
            this.textBoxEmployeeTitle.Name = "textBoxEmployeeTitle";
            this.textBoxEmployeeTitle.Size = new System.Drawing.Size(104, 20);
            this.textBoxEmployeeTitle.TabIndex = 10;
            this.textBoxEmployeeTitle.Text = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(328, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "title";
            // 
            // buttonPersistEmployee
            // 
            this.buttonPersistEmployee.Location = new System.Drawing.Point(128, 320);
            this.buttonPersistEmployee.Name = "buttonPersistEmployee";
            this.buttonPersistEmployee.Size = new System.Drawing.Size(104, 24);
            this.buttonPersistEmployee.TabIndex = 12;
            this.buttonPersistEmployee.Text = "Persist Employee";
            this.buttonPersistEmployee.Click += new System.EventHandler(this.buttonPersistEmployee_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(472, 320);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(80, 24);
            this.buttonClear.TabIndex = 13;
            this.buttonClear.Text = "Clear";
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonCreateEmployee
            // 
            this.buttonCreateEmployee.Location = new System.Drawing.Point(240, 320);
            this.buttonCreateEmployee.Name = "buttonCreateEmployee";
            this.buttonCreateEmployee.Size = new System.Drawing.Size(104, 24);
            this.buttonCreateEmployee.TabIndex = 14;
            this.buttonCreateEmployee.Text = "Create Employee";
            this.buttonCreateEmployee.Click += new System.EventHandler(this.buttonCreateEmployee_Click);
            // 
            // buttonRemoveEmployee
            // 
            this.buttonRemoveEmployee.Location = new System.Drawing.Point(352, 320);
            this.buttonRemoveEmployee.Name = "buttonRemoveEmployee";
            this.buttonRemoveEmployee.Size = new System.Drawing.Size(112, 24);
            this.buttonRemoveEmployee.TabIndex = 15;
            this.buttonRemoveEmployee.Text = "Remove Employee";
            this.buttonRemoveEmployee.Click += new System.EventHandler(this.buttonRemoveEmlpoyee_Click);
            // 
            // EmployeeForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(584, 398);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.buttonRemoveEmployee,
                                                                          this.buttonCreateEmployee,
                                                                          this.buttonClear,
                                                                          this.buttonPersistEmployee,
                                                                          this.label5,
                                                                          this.textBoxEmployeeTitle,
                                                                          this.label4,
                                                                          this.label3,
                                                                          this.textBoxEmployeeID,
                                                                          this.label2,
                                                                          this.textBoxEmployeeLastName,
                                                                          this.buttonClose,
                                                                          this.dataGridAddress,
                                                                          this.label1,
                                                                          this.buttonFetchEmployee,
                                                                          this.textBoxEmployeeFirstName});
            this.Name = "EmployeeForm";
            this.Text = "Employee Entry";
            this.Load += new System.EventHandler(this.EmployeeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridAddress)).EndInit();
            this.ResumeLayout(false);

        }
		#endregion

        private void EmployeeForm_Load(object sender, System.EventArgs e)
        {
        }

        public ObjectRepository ObjectRepository
        {
            set 
            {
                _repository = value;
            }
        }

        protected virtual void buttonFetchEmployee_Click(object sender, System.EventArgs e)
        {
            Employee[] emps = _repository.GetEmployee(textBoxEmployeeLastName.Text);
            ClearBindings(); 
            if (emps != null && emps.Length > 0)
            {
                _emp = emps[0];
                BindEmployee();
            }
            else
            {
                _emp = null;   
            }       
        }

        protected virtual void BindEmployee()
        {
            if (_emp != null)
            {
                textBoxEmployeeFirstName.DataBindings.Add("Text", _emp, "FName");
                textBoxEmployeeLastName.DataBindings.Add("Text", _emp, "LName");
                textBoxEmployeeID.DataBindings.Add("Text", _emp, "ID");
                textBoxEmployeeTitle.DataBindings.Add("Text", _emp, "Title");
                dataGridAddress.DataSource = _emp._addressList;   
            }
        }

        protected virtual void ClearBindings()
        {
            textBoxEmployeeFirstName.DataBindings.Clear();
            textBoxEmployeeLastName.DataBindings.Clear();
            textBoxEmployeeID.DataBindings.Clear();
            textBoxEmployeeTitle.DataBindings.Clear();  
            dataGridAddress.DataSource = null;

            textBoxEmployeeFirstName.Text = "";
            textBoxEmployeeLastName.Text = "";
            textBoxEmployeeID.Text = "";
            textBoxEmployeeTitle.Text = "";
        }

        private void buttonClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void buttonPersistEmployee_Click(object sender, System.EventArgs e)
        {   
            if (_emp != null)
            {  
                _repository.PersistEmployee(_emp);
            }
        }

        private void buttonClear_Click(object sender, System.EventArgs e)
        {
            ClearBindings();
            _emp = null;
        }

        protected virtual void buttonCreateEmployee_Click(object sender, System.EventArgs e)
        {
            _emp = new Employee(-1, string.Empty, string.Empty, string.Empty);
            _emp._addressList.Add(new EmployeeAddress(AddressType.Home, string.Empty, string.Empty, string.Empty, string.Empty));
            _emp._addressList.Add(new EmployeeAddress(AddressType.Work, string.Empty, string.Empty, string.Empty, string.Empty));
            _emp._addressList.Add(new EmployeeAddress(AddressType.Other, string.Empty, string.Empty, string.Empty, string.Empty));
            ClearBindings();
            BindEmployee();
        }

        private void buttonRemoveEmlpoyee_Click(object sender, System.EventArgs e)
        {
            if (_emp != null)
            {
                _repository.RemoveEmployee(_emp);
                ClearBindings();
            }
        }

	}
}
