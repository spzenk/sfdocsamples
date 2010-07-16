using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Indy.Sockets.IndyFTP;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Indy
{
	/// <summary>
	/// Authored by Fakher Halim fakher@taskperformance.com.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox txtHost;
		private System.Windows.Forms.Label lblUserID;
		private System.Windows.Forms.TextBox txtUserName;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.Label lblHost;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox txtDirectory;
		private System.Windows.Forms.Label lbltxtDirectory;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Label lblFileName;
		private System.Windows.Forms.Label lblWarning;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnDownload;
		private System.Windows.Forms.ListBox lstDirectory;
		private System.Windows.Forms.Button btnLogin;
		FTP lFtp;
		private System.Windows.Forms.Button btnCdParent;
		private System.Windows.Forms.StatusBar statusBar1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
			this.btnDownload = new System.Windows.Forms.Button();
			this.txtHost = new System.Windows.Forms.TextBox();
			this.lblHost = new System.Windows.Forms.Label();
			this.lblUserID = new System.Windows.Forms.Label();
			this.lblPassword = new System.Windows.Forms.Label();
			this.txtUserName = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.txtDirectory = new System.Windows.Forms.TextBox();
			this.lbltxtDirectory = new System.Windows.Forms.Label();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.lblFileName = new System.Windows.Forms.Label();
			this.lblWarning = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lstDirectory = new System.Windows.Forms.ListBox();
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnCdParent = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.SuspendLayout();
			// 
			// btnDownload
			// 
			this.btnDownload.Location = new System.Drawing.Point(408, 96);
			this.btnDownload.Name = "btnDownload";
			this.btnDownload.Size = new System.Drawing.Size(96, 23);
			this.btnDownload.TabIndex = 0;
			this.btnDownload.Text = "DOWNLOAD";
			this.btnDownload.Visible = false;
			this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
			// 
			// txtHost
			// 
			this.txtHost.Location = new System.Drawing.Point(168, 56);
			this.txtHost.Name = "txtHost";
			this.txtHost.Size = new System.Drawing.Size(112, 20);
			this.txtHost.TabIndex = 1;
			this.txtHost.Text = "ftp.netscape.com";
			// 
			// lblHost
			// 
			this.lblHost.Location = new System.Drawing.Point(32, 56);
			this.lblHost.Name = "lblHost";
			this.lblHost.Size = new System.Drawing.Size(128, 23);
			this.lblHost.TabIndex = 2;
			this.lblHost.Text = "FTP Server Name";
			this.lblHost.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblUserID
			// 
			this.lblUserID.Location = new System.Drawing.Point(112, 88);
			this.lblUserID.Name = "lblUserID";
			this.lblUserID.Size = new System.Drawing.Size(48, 23);
			this.lblUserID.TabIndex = 2;
			this.lblUserID.Text = "User ID";
			this.lblUserID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblPassword
			// 
			this.lblPassword.Location = new System.Drawing.Point(104, 120);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(56, 23);
			this.lblPassword.TabIndex = 2;
			this.lblPassword.Text = "Password";
			this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtUserName
			// 
			this.txtUserName.Location = new System.Drawing.Point(168, 88);
			this.txtUserName.Name = "txtUserName";
			this.txtUserName.Size = new System.Drawing.Size(112, 20);
			this.txtUserName.TabIndex = 1;
			this.txtUserName.Text = "anonymous";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(168, 120);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(176, 20);
			this.txtPassword.TabIndex = 1;
			this.txtPassword.Text = "developer@mycompany.com";
			// 
			// txtDirectory
			// 
			this.txtDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtDirectory.Location = new System.Drawing.Point(32, 168);
			this.txtDirectory.Name = "txtDirectory";
			this.txtDirectory.Size = new System.Drawing.Size(504, 20);
			this.txtDirectory.TabIndex = 1;
			this.txtDirectory.Text = "";
			// 
			// lbltxtDirectory
			// 
			this.lbltxtDirectory.Location = new System.Drawing.Point(16, 144);
			this.lbltxtDirectory.Name = "lbltxtDirectory";
			this.lbltxtDirectory.Size = new System.Drawing.Size(56, 23);
			this.lbltxtDirectory.TabIndex = 2;
			this.lbltxtDirectory.Text = "Directory";
			this.lbltxtDirectory.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(376, 72);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(160, 20);
			this.txtFileName.TabIndex = 1;
			this.txtFileName.Text = "";
			this.txtFileName.Visible = false;
			// 
			// lblFileName
			// 
			this.lblFileName.Location = new System.Drawing.Point(400, 48);
			this.lblFileName.Name = "lblFileName";
			this.lblFileName.Size = new System.Drawing.Size(56, 23);
			this.lblFileName.TabIndex = 2;
			this.lblFileName.Text = "File Name";
			this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblWarning
			// 
			this.lblWarning.ForeColor = System.Drawing.Color.Red;
			this.lblWarning.Location = new System.Drawing.Point(32, 8);
			this.lblWarning.Name = "lblWarning";
			this.lblWarning.Size = new System.Drawing.Size(392, 16);
			this.lblWarning.TabIndex = 3;
			this.lblWarning.Text = "Please Change the following text boxes to actual Server, ID, Password.";
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
			this.label1.Location = new System.Drawing.Point(16, 344);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(512, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "Author: Fakher Halim (fakher@taskperformance.com)";
			// 
			// lstDirectory
			// 
			this.lstDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lstDirectory.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lstDirectory.ItemHeight = 14;
			this.lstDirectory.Location = new System.Drawing.Point(16, 192);
			this.lstDirectory.Name = "lstDirectory";
			this.lstDirectory.Size = new System.Drawing.Size(520, 144);
			this.lstDirectory.TabIndex = 4;
			this.lstDirectory.DoubleClick += new System.EventHandler(this.lstDirectory_DoubleClick);
			// 
			// btnLogin
			// 
			this.btnLogin.Location = new System.Drawing.Point(56, 88);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(48, 23);
			this.btnLogin.TabIndex = 5;
			this.btnLogin.Text = "Login";
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// btnCdParent
			// 
			this.btnCdParent.Location = new System.Drawing.Point(16, 168);
			this.btnCdParent.Name = "btnCdParent";
			this.btnCdParent.Size = new System.Drawing.Size(16, 24);
			this.btnCdParent.TabIndex = 6;
			this.btnCdParent.Text = "^";
			this.btnCdParent.Visible = false;
			this.btnCdParent.Click += new System.EventHandler(this.btnCdParent_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.statusBar1.Dock = System.Windows.Forms.DockStyle.None;
			this.statusBar1.Location = new System.Drawing.Point(0, 367);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(544, 22);
			this.statusBar1.TabIndex = 7;
			this.statusBar1.Text = "Please Enter Server Name, User ID/Password and Click Login Button";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 389);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.btnCdParent);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.lstDirectory);
			this.Controls.Add(this.lblWarning);
			this.Controls.Add(this.lblHost);
			this.Controls.Add(this.txtHost);
			this.Controls.Add(this.btnDownload);
			this.Controls.Add(this.lblUserID);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.txtUserName);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.txtDirectory);
			this.Controls.Add(this.lbltxtDirectory);
			this.Controls.Add(this.txtFileName);
			this.Controls.Add(this.lblFileName);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Indy based .NET FTP Demo";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Closed += new System.EventHandler(this.Form1_Closed);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void Form1_Load(object sender, System.EventArgs e) {
			lFtp = new FTP();
		}
		private void btnLogin_Click(object sender, System.EventArgs e) {
			if(txtDirectory.Text!="")//aleady logged in; disconnect first
				lFtp.Disconnect();

			statusBar1.Text=string.Format("Logging into {0} ..", txtHost.Text);
			lFtp.Host=txtHost.Text;
			lFtp.Username=txtUserName.Text;
			lFtp.Password=txtPassword.Text;
			try{lFtp.Connect();}catch(Exception ex){
				statusBar1.Text=ex.Message;return;
			}
			lFtp.Passive=true;
			drawDirectoryContents();
		}

		private void lstDirectory_DoubleClick(object sender, System.EventArgs e) {
			string sel=lstDirectory.SelectedItem.ToString();
			string[] fields=Regex.Split(sel, " +");
			const int startField=8;//the file/directory name starts after 8 fields 
			string name="";
			for(int field=startField; field< fields.Length; field++){
				name+=((field==startField)?"":" ")+fields[field];//add aditional space for name split into multiple fields
			}
/*Assuming 1. That a directory entry will have exactly one line.
		   2. I further assume that either a "-" or "d" will start it and indicate the item type.  
  These assumptions are incorrect with some servers. Some servers use their own directory format and there is no standard at all for that.
  As cutioned by J. Peter Mugaas - Indy Pit Crew http://www.nevrona.com/Indy
 */ 
			if(sel[0]=='d'){//directory on most of the Unix style ls -l servers
				statusBar1.Text=string.Format("Changing directoy to {0} ..", name);
				lFtp.ChangeDir(name);
				drawDirectoryContents();//redraw contents after changing directory
			}else{
				if(sel[0]=='-'){//plain file have '-' as first character, works on most of the servers
					txtFileName.Text=name;//update the name of file to download
					txtFileName.Visible=true;
					btnDownload.Visible=true;
				}
			}		
		}

		private void btnCdParent_Click(object sender, System.EventArgs e) {
			statusBar1.Text="Changing to Parent Directory ..";
			lFtp.ChangeDirUp();
			drawDirectoryContents();
		}
		private void btnDownload_Click(object sender, System.EventArgs e) {
			statusBar1.Text=string.Format("Downloading {0} into {1}..", txtFileName.Text, Environment.CurrentDirectory);
			btnDownload.Visible=txtFileName.Visible=false;
			lFtp.Get(txtFileName.Text, txtFileName.Text, true, false);
			statusBar1.Text=string.Format("Downloading of {0} into {1} is complete", txtFileName.Text, Environment.CurrentDirectory);
		}
		private void drawDirectoryContents(){
			statusBar1.Text="Listing directory contents ..";
			lstDirectory.Items.Clear();
			StringCollection ls=new StringCollection();
			try{lFtp.List(ls, "", true);}catch(Exception ex){
				statusBar1.Text=ex.Message;return;
			}
			foreach(string file in ls){
				lstDirectory.Items.Add(file);				
			}
			txtDirectory.Text=lFtp.RetrieveCurrentDir();
			btnCdParent.Visible=(txtDirectory.Text=="/")?false:true;
			txtFileName.Visible=btnDownload.Visible=false;
            statusBar1.Text="Complete";
		}

		private void Form1_Closed(object sender, System.EventArgs e) {
			lFtp.Disconnect();
		}

	}
}
