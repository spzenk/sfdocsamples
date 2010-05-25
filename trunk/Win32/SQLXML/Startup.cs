using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Text;

namespace ObjectStorePart1
{
	/// <summary>
	/// Summary description for Startup.
	/// </summary>
	public class Startup : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button buttonEmployeeForm;
        private System.Windows.Forms.Button buttonEmployeeVersion2;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxDatabase;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonTestObjectRepository;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new Startup());
        }

		public Startup()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.buttonEmployeeForm = new System.Windows.Forms.Button();
			this.buttonEmployeeVersion2 = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.textBoxServer = new System.Windows.Forms.TextBox();
			this.textBoxDatabase = new System.Windows.Forms.TextBox();
			this.textBoxLogin = new System.Windows.Forms.TextBox();
			this.textBoxPassword = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.buttonTestObjectRepository = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonEmployeeForm
			// 
			this.buttonEmployeeForm.Location = new System.Drawing.Point(224, 16);
			this.buttonEmployeeForm.Name = "buttonEmployeeForm";
			this.buttonEmployeeForm.Size = new System.Drawing.Size(160, 24);
			this.buttonEmployeeForm.TabIndex = 0;
			this.buttonEmployeeForm.Text = "Employee Form";
			this.buttonEmployeeForm.Click += new System.EventHandler(this.buttonEmployeeForm_Click);
			// 
			// buttonEmployeeVersion2
			// 
			this.buttonEmployeeVersion2.Location = new System.Drawing.Point(224, 48);
			this.buttonEmployeeVersion2.Name = "buttonEmployeeVersion2";
			this.buttonEmployeeVersion2.Size = new System.Drawing.Size(160, 24);
			this.buttonEmployeeVersion2.TabIndex = 1;
			this.buttonEmployeeVersion2.Text = "Employee Version 2 Form";
			this.buttonEmployeeVersion2.Click += new System.EventHandler(this.buttonEmployeeVersion2_Click);
			// 
			// buttonClose
			// 
			this.buttonClose.Location = new System.Drawing.Point(288, 224);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(96, 24);
			this.buttonClose.TabIndex = 2;
			this.buttonClose.Text = "Close";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			// 
			// textBoxServer
			// 
			this.textBoxServer.Location = new System.Drawing.Point(24, 24);
			this.textBoxServer.Name = "textBoxServer";
			this.textBoxServer.Size = new System.Drawing.Size(136, 20);
			this.textBoxServer.TabIndex = 3;
			this.textBoxServer.Text = "pcdesarrollo05";
			// 
			// textBoxDatabase
			// 
			this.textBoxDatabase.Location = new System.Drawing.Point(24, 72);
			this.textBoxDatabase.Name = "textBoxDatabase";
			this.textBoxDatabase.Size = new System.Drawing.Size(136, 20);
			this.textBoxDatabase.TabIndex = 4;
			this.textBoxDatabase.Text = "test";
			// 
			// textBoxLogin
			// 
			this.textBoxLogin.Location = new System.Drawing.Point(24, 120);
			this.textBoxLogin.Name = "textBoxLogin";
			this.textBoxLogin.Size = new System.Drawing.Size(136, 20);
			this.textBoxLogin.TabIndex = 5;
			this.textBoxLogin.Text = "sa";
			// 
			// textBoxPassword
			// 
			this.textBoxPassword.Location = new System.Drawing.Point(24, 168);
			this.textBoxPassword.Name = "textBoxPassword";
			this.textBoxPassword.PasswordChar = '*';
			this.textBoxPassword.Size = new System.Drawing.Size(136, 20);
			this.textBoxPassword.TabIndex = 6;
			this.textBoxPassword.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(136, 20);
			this.label1.TabIndex = 7;
			this.label1.Text = "Server";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(24, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 20);
			this.label2.TabIndex = 8;
			this.label2.Text = "Database";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(24, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(136, 20);
			this.label3.TabIndex = 9;
			this.label3.Text = "login";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(24, 152);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 20);
			this.label4.TabIndex = 10;
			this.label4.Text = "password";
			// 
			// buttonTestObjectRepository
			// 
			this.buttonTestObjectRepository.Location = new System.Drawing.Point(224, 96);
			this.buttonTestObjectRepository.Name = "buttonTestObjectRepository";
			this.buttonTestObjectRepository.Size = new System.Drawing.Size(160, 24);
			this.buttonTestObjectRepository.TabIndex = 11;
			this.buttonTestObjectRepository.Text = "Test Object Repository";
			this.buttonTestObjectRepository.Click += new System.EventHandler(this.buttonTestObjectRepository_Click);
			// 
			// Startup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(400, 266);
			this.Controls.Add(this.buttonTestObjectRepository);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBoxPassword);
			this.Controls.Add(this.textBoxLogin);
			this.Controls.Add(this.textBoxDatabase);
			this.Controls.Add(this.textBoxServer);
			this.Controls.Add(this.buttonClose);
			this.Controls.Add(this.buttonEmployeeVersion2);
			this.Controls.Add(this.buttonEmployeeForm);
			this.Name = "Startup";
			this.Text = "Startup";
			this.Load += new System.EventHandler(this.Startup_Load);
			this.ResumeLayout(false);

		}
		#endregion

        private void Startup_Load(object sender, System.EventArgs e)
        {
        
        }

        private void buttonEmployeeForm_Click(object sender, System.EventArgs e)
        {
            EmployeeForm form = new EmployeeForm();
            form.ObjectRepository = new ObjectRepository(BuildProviderString());
            form.ShowDialog();
        }

        private void buttonClose_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void buttonTestObjectRepository_Click(object sender, System.EventArgs e)
        {
            ORTestForm form = new ORTestForm();
            form.ObjectRepository = new ObjectRepository(BuildProviderString());
            form.ShowDialog();
        }

        private string BuildProviderString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("provider=sqloledb;server=");
            builder.Append(textBoxServer.Text);
            builder.Append(";uid=");
            builder.Append(textBoxLogin.Text);
            builder.Append(";password=");
            builder.Append(textBoxPassword.Text);
            builder.Append(";database=");
            builder.Append(textBoxDatabase.Text);
            return builder.ToString();
        }

        private void buttonEmployeeVersion2_Click(object sender, System.EventArgs e)
        {
            Employee2Form form = new Employee2Form();
            form.ObjectRepository = new ObjectRepository(BuildProviderString());
            form.ShowDialog();
        }

	}
}
