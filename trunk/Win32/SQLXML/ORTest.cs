using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ObjectStorePart1
{
	public class ORTestForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.Container components = null;

        private ObjectRepository _repository = null;
        private System.Windows.Forms.Button buttonPersistEmployee;
        private System.Windows.Forms.Button buttonRemoveEmployee;
        private System.Windows.Forms.Button buttonFetchEmployee;
        private System.Windows.Forms.Button buttonUpdateEmployee;
        private System.Windows.Forms.Button buttonPersistMultipleEmployees;
        private System.Windows.Forms.Button buttonPersistEmployee2;
        private System.Windows.Forms.Button buttonRevmoveEmployeeVersion2;
        private System.Windows.Forms.Button buttonCLose;
        private System.Windows.Forms.Button buttonFetchEmployeeVersion2;

		public ORTestForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

        public ObjectRepository ObjectRepository
        {
            set 
            {
                _repository = value;
                _repository.CleanDatabase();
            }
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.buttonPersistEmployee = new System.Windows.Forms.Button();
            this.buttonRemoveEmployee = new System.Windows.Forms.Button();
            this.buttonFetchEmployee = new System.Windows.Forms.Button();
            this.buttonUpdateEmployee = new System.Windows.Forms.Button();
            this.buttonPersistMultipleEmployees = new System.Windows.Forms.Button();
            this.buttonPersistEmployee2 = new System.Windows.Forms.Button();
            this.buttonRevmoveEmployeeVersion2 = new System.Windows.Forms.Button();
            this.buttonFetchEmployeeVersion2 = new System.Windows.Forms.Button();
            this.buttonCLose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonPersistEmployee
            // 
            this.buttonPersistEmployee.Location = new System.Drawing.Point(56, 72);
            this.buttonPersistEmployee.Name = "buttonPersistEmployee";
            this.buttonPersistEmployee.Size = new System.Drawing.Size(144, 23);
            this.buttonPersistEmployee.TabIndex = 0;
            this.buttonPersistEmployee.Text = "Persist Employee";
            this.buttonPersistEmployee.Click += new System.EventHandler(this.buttonPersistEmployee_Click);
            // 
            // buttonRemoveEmployee
            // 
            this.buttonRemoveEmployee.Location = new System.Drawing.Point(56, 116);
            this.buttonRemoveEmployee.Name = "buttonRemoveEmployee";
            this.buttonRemoveEmployee.Size = new System.Drawing.Size(144, 23);
            this.buttonRemoveEmployee.TabIndex = 1;
            this.buttonRemoveEmployee.Text = "Remove Employee";
            this.buttonRemoveEmployee.Click += new System.EventHandler(this.buttonRemoveEmployee_Click);
            // 
            // buttonFetchEmployee
            // 
            this.buttonFetchEmployee.Location = new System.Drawing.Point(56, 156);
            this.buttonFetchEmployee.Name = "buttonFetchEmployee";
            this.buttonFetchEmployee.Size = new System.Drawing.Size(144, 23);
            this.buttonFetchEmployee.TabIndex = 2;
            this.buttonFetchEmployee.Text = "Fetch Employee";
            this.buttonFetchEmployee.Click += new System.EventHandler(this.buttonFetchEmployee_Click);
            // 
            // buttonUpdateEmployee
            // 
            this.buttonUpdateEmployee.Location = new System.Drawing.Point(56, 198);
            this.buttonUpdateEmployee.Name = "buttonUpdateEmployee";
            this.buttonUpdateEmployee.Size = new System.Drawing.Size(144, 23);
            this.buttonUpdateEmployee.TabIndex = 3;
            this.buttonUpdateEmployee.Text = "Update Employee";
            this.buttonUpdateEmployee.Click += new System.EventHandler(this.buttonUpdateEmployee_Click);
            // 
            // buttonPersistMultipleEmployees
            // 
            this.buttonPersistMultipleEmployees.Location = new System.Drawing.Point(56, 240);
            this.buttonPersistMultipleEmployees.Name = "buttonPersistMultipleEmployees";
            this.buttonPersistMultipleEmployees.Size = new System.Drawing.Size(144, 23);
            this.buttonPersistMultipleEmployees.TabIndex = 4;
            this.buttonPersistMultipleEmployees.Text = "Persist Multiple Employees";
            this.buttonPersistMultipleEmployees.Click += new System.EventHandler(this.buttonPersistMultipleEmployees_Click);
            // 
            // buttonPersistEmployee2
            // 
            this.buttonPersistEmployee2.Location = new System.Drawing.Point(240, 72);
            this.buttonPersistEmployee2.Name = "buttonPersistEmployee2";
            this.buttonPersistEmployee2.Size = new System.Drawing.Size(144, 23);
            this.buttonPersistEmployee2.TabIndex = 5;
            this.buttonPersistEmployee2.Text = "Persist Employee 2.0";
            this.buttonPersistEmployee2.Click += new System.EventHandler(this.buttonPersistEmployee2_Click);
            // 
            // buttonRevmoveEmployeeVersion2
            // 
            this.buttonRevmoveEmployeeVersion2.Location = new System.Drawing.Point(240, 116);
            this.buttonRevmoveEmployeeVersion2.Name = "buttonRevmoveEmployeeVersion2";
            this.buttonRevmoveEmployeeVersion2.Size = new System.Drawing.Size(144, 23);
            this.buttonRevmoveEmployeeVersion2.TabIndex = 6;
            this.buttonRevmoveEmployeeVersion2.Text = "Remove Employee 2.0";
            this.buttonRevmoveEmployeeVersion2.Click += new System.EventHandler(this.buttonRevmoveEmployeeVersion2_Click);
            // 
            // buttonFetchEmployeeVersion2
            // 
            this.buttonFetchEmployeeVersion2.Location = new System.Drawing.Point(240, 156);
            this.buttonFetchEmployeeVersion2.Name = "buttonFetchEmployeeVersion2";
            this.buttonFetchEmployeeVersion2.Size = new System.Drawing.Size(144, 23);
            this.buttonFetchEmployeeVersion2.TabIndex = 7;
            this.buttonFetchEmployeeVersion2.Text = "Fetch Employee 2.0";
            this.buttonFetchEmployeeVersion2.Click += new System.EventHandler(this.buttonFetchEmployeeVersion2_Click);
            // 
            // buttonCLose
            // 
            this.buttonCLose.Location = new System.Drawing.Point(240, 240);
            this.buttonCLose.Name = "buttonCLose";
            this.buttonCLose.Size = new System.Drawing.Size(144, 24);
            this.buttonCLose.TabIndex = 8;
            this.buttonCLose.Text = "Close";
            this.buttonCLose.Click += new System.EventHandler(this.buttonCLose_Click);
            // 
            // ORTestForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(416, 286);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                          this.buttonCLose,
                                                                          this.buttonFetchEmployeeVersion2,
                                                                          this.buttonRevmoveEmployeeVersion2,
                                                                          this.buttonPersistEmployee2,
                                                                          this.buttonPersistMultipleEmployees,
                                                                          this.buttonUpdateEmployee,
                                                                          this.buttonFetchEmployee,
                                                                          this.buttonRemoveEmployee,
                                                                          this.buttonPersistEmployee});
            this.Name = "ORTestForm";
            this.Text = "Object Repository Test";
            this.Load += new System.EventHandler(this.ORTestForm_Load);
            this.ResumeLayout(false);

        }
		#endregion

        private void ORTestForm_Load(object sender, System.EventArgs e)
        {
        
        }

        private void buttonPersistEmployee_Click(object sender, System.EventArgs e)
        {
            // create a simple employee
            Employee emp = CreateSampleEmployee();
            _repository.PersistEmployee(emp);         // persist to repository

            _repository.CleanDatabase();   
        }

        private void buttonRemoveEmployee_Click(object sender, System.EventArgs e)
        {
            // add a sample employee to delete
            Employee emp = CreateSampleEmployee();
            _repository.PersistEmployee(emp);       // persist it
            _repository.RemoveEmployee(emp);            // now remove it
            
            _repository.CleanDatabase();
        }

        private void buttonFetchEmployee_Click(object sender, System.EventArgs e)
        {
            // add a sample employee to fetch
            _repository.PersistEmployee(CreateSampleEmployee());
            _repository.PersistEmployee(CreateSampleEmployee2());
            Employee[] emp = _repository.GetEmployee("Jones");
            _repository.CleanDatabase();
        }

        private void buttonUpdateEmployee_Click(object sender, System.EventArgs e)
        {
            // add a sample employee to fetch and then update
            _repository.PersistEmployee(CreateSampleEmployee());
            Employee[] employees = _repository.GetEmployee("Jones"); 
            employees[0]._addressList.RemoveAt(0);  //remove an address
            employees[0].Title = "Director"; //update the title
            _repository.PersistEmployee(employees[0]);  //save update employee  
            
            _repository.CleanDatabase();             
        }

        private void buttonPersistMultipleEmployees_Click(object sender, System.EventArgs e)
        {   
            Employee[] employees = null;
            Employee[] employeesToPersist = new Employee[2];            
            // add a sample employee to fetch and then update
            _repository.PersistEmployee(CreateSampleEmployee());
            employees = _repository.GetEmployee("Jones");
            employees.CopyTo(employeesToPersist,0);
            employeesToPersist[0]._addressList.RemoveAt(0);  //remove an address
            employeesToPersist[0].Title = "Director"; //update the title
            
            // create a new employee
            employeesToPersist[1] = CreateSampleEmployee3();
            
            //now persist updated and inserted employees            
            _repository.PersistEmployees(employeesToPersist);

            _repository.CleanDatabase();
        }
	    
        private Employee CreateSampleEmployee()
        {
            Employee emp = new Employee(1, "Jeffrey", "Jones", "SYSTEMS ANALYST");
            emp._addressList.Add((object)new EmployeeAddress(AddressType.Home, "111 Oak", "Redmond", "WA", "98052"));
            emp._addressList.Add((object)new EmployeeAddress(AddressType.Work, "1111 North Corporate Road", 
                "Redmond", "WA", "98052")); 
            return emp;
        }

        private Employee CreateSampleEmployee2()
        {
            Employee emp = new Employee(2, "Sam", "Jones", "DBA");
            emp._addressList.Add((object)new EmployeeAddress(AddressType.Home, "222 Hill Street", "Redmond", "WA", "98052"));
            return emp;
        }

        private Employee CreateSampleEmployee3()
        {
            Employee2 emp = new Employee2(3, "Jim", "Smith", "Developer");
            emp._addressList.Add((object)new EmployeeAddress(AddressType.Other, "333 Bourbon Street", "Redmond", "WA", "98052"));
            return emp;
        }

        private Employee2 CreateSampleEmployeeVersion2()
        {
            Employee2 emp = new Employee2(3, "Don", "Johnson", "Developer");
            emp._addressList.Add((object)new EmployeeAddress(AddressType.Other, "7878 Fleet Street", "Redmond", "WA", "98052"));
            emp.CellPhone = "555-555-5151";
            emp.HomePhone = "111-111-9090";
            emp.Project = new Project("Code Refactoring",1);
            return emp;
        }


        private void buttonPersistEmployee2_Click(object sender, System.EventArgs e)
        {
            // create a sample employee 2.0
            Employee2 emp = CreateSampleEmployeeVersion2();
            _repository.PersistEmployee(emp);         // persist to repository
            _repository.CleanDatabase();   
        }

        private void buttonRevmoveEmployeeVersion2_Click(object sender, System.EventArgs e)
        {
            // add a sample employee 2.0 to delete
            Employee emp = CreateSampleEmployeeVersion2();
            _repository.PersistEmployee(emp);       // persist it
            _repository.RemoveEmployee(emp);        // now remove it
            
            _repository.CleanDatabase();
        }

        private void buttonFetchEmployeeVersion2_Click(object sender, System.EventArgs e)
        {
            // add a sample employee to fetch
            _repository.PersistEmployee(CreateSampleEmployeeVersion2());
            Employee[] employees = _repository.GetEmployee("Johnson");;

            _repository.CleanDatabase();
        }

        private void buttonCLose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
