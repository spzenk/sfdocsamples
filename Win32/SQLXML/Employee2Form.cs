using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace ObjectStorePart1
{
	public class Employee2Form : ObjectStorePart1.EmployeeForm
	{
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxWorkPhone;
        private System.Windows.Forms.TextBox textBoxCellPhone;
        private System.Windows.Forms.TextBox textBoxHomePhone;
		private System.ComponentModel.IContainer components = null;

		public Employee2Form()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.textBoxHomePhone = new System.Windows.Forms.TextBox();
            this.textBoxWorkPhone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxCellPhone = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxHomePhone
            // 
            this.textBoxHomePhone.Location = new System.Drawing.Point(40, 256);
            this.textBoxHomePhone.Name = "textBoxHomePhone";
            this.textBoxHomePhone.Size = new System.Drawing.Size(96, 20);
            this.textBoxHomePhone.TabIndex = 16;
            this.textBoxHomePhone.Text = "";
            // 
            // textBoxWorkPhone
            // 
            this.textBoxWorkPhone.Location = new System.Drawing.Point(152, 256);
            this.textBoxWorkPhone.Name = "textBoxWorkPhone";
            this.textBoxWorkPhone.Size = new System.Drawing.Size(96, 20);
            this.textBoxWorkPhone.TabIndex = 17;
            this.textBoxWorkPhone.Text = "";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(40, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 18;
            this.label6.Text = "Home Phone";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(152, 240);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "Work Phone";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(264, 240);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Cell Phone";
            // 
            // textBoxCellPhone
            // 
            this.textBoxCellPhone.Location = new System.Drawing.Point(264, 256);
            this.textBoxCellPhone.Name = "textBoxCellPhone";
            this.textBoxCellPhone.Size = new System.Drawing.Size(96, 20);
            this.textBoxCellPhone.TabIndex = 21;
            this.textBoxCellPhone.Text = "";
            // 
            // Employee2Form
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(584, 398);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.textBoxCellPhone,
                                                                          this.label8,
                                                                          this.label7,
                                                                          this.label6,
                                                                          this.textBoxWorkPhone,
                                                                          this.textBoxHomePhone});
            this.Name = "Employee2Form";
            this.Text = "Employee Version 2  Entry";
            this.Load += new System.EventHandler(this.Employee2Form_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void Employee2Form_Load(object sender, System.EventArgs e)
        {
        
        }
        
        protected override void BindEmployee()
        {
            if (_emp != null)
            {
                base.BindEmployee();
                textBoxHomePhone.DataBindings.Add("Text", (Employee2)_emp, "HomePhone");
                textBoxWorkPhone.DataBindings.Add("Text", (Employee2)_emp, "WorkPhone");
                textBoxCellPhone.DataBindings.Add("Text", (Employee2)_emp, "CellPhone");
            }
        }

        protected override void ClearBindings()
        {
            base.ClearBindings();
            textBoxHomePhone.DataBindings.Clear();
            textBoxWorkPhone.DataBindings.Clear();
            textBoxCellPhone.DataBindings.Clear();
            textBoxHomePhone.Text = "";
            textBoxWorkPhone.Text = "";
            textBoxCellPhone.Text = "";
        }

        protected override void buttonCreateEmployee_Click(object sender, System.EventArgs e)
        {
            _emp = new Employee2(-1, string.Empty, string.Empty, string.Empty);
            _emp._addressList.Add(new EmployeeAddress(AddressType.Home, string.Empty, string.Empty, string.Empty, string.Empty));
            _emp._addressList.Add(new EmployeeAddress(AddressType.Work, string.Empty, string.Empty, string.Empty, string.Empty));
            _emp._addressList.Add(new EmployeeAddress(AddressType.Other, string.Empty, string.Empty, string.Empty, string.Empty));
            ((Employee2)_emp).CellPhone = string.Empty;
            ((Employee2)_emp).HomePhone = string.Empty;
            ((Employee2)_emp).WorkPhone = string.Empty;
            ((Employee2)_emp).Project = new Project(string.Empty, -1);
            ClearBindings();
            BindEmployee();
        }

	}
}

