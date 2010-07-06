namespace agsXMPP.Client
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.chkRegister = new System.Windows.Forms.CheckBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtResource = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtJid = new System.Windows.Forms.TextBox();
            this.chkSSL = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numPriority = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtSenMessage = new System.Windows.Forms.Button();
            this.rosterControl = new agsXMPP.ui.roster.RosterControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtBare = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.txtCmdValue = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).BeginInit();
            this.SuspendLayout();
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(626, 12);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogs.Size = new System.Drawing.Size(304, 454);
            this.txtLogs.TabIndex = 0;
            // 
            // chkRegister
            // 
            this.chkRegister.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRegister.Location = new System.Drawing.Point(83, 213);
            this.chkRegister.Name = "chkRegister";
            this.chkRegister.Size = new System.Drawing.Size(160, 16);
            this.chkRegister.TabIndex = 26;
            this.chkRegister.Text = "register new Account";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(179, 127);
            this.txtPort.MaxLength = 5;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(72, 20);
            this.txtPort.TabIndex = 5;
            this.txtPort.Text = "5222";
            // 
            // txtResource
            // 
            this.txtResource.Location = new System.Drawing.Point(83, 159);
            this.txtResource.Name = "txtResource";
            this.txtResource.Size = new System.Drawing.Size(168, 20);
            this.txtResource.TabIndex = 18;
            this.txtResource.Text = "AlertCnn";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(83, 95);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(168, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtJid
            // 
            this.txtJid.Location = new System.Drawing.Point(83, 21);
            this.txtJid.Name = "txtJid";
            this.txtJid.Size = new System.Drawing.Size(168, 20);
            this.txtJid.TabIndex = 1;
            // 
            // chkSSL
            // 
            this.chkSSL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSSL.Location = new System.Drawing.Point(83, 191);
            this.chkSSL.Name = "chkSSL";
            this.chkSSL.Size = new System.Drawing.Size(160, 16);
            this.chkSSL.TabIndex = 19;
            this.chkSSL.Text = "use SSL (old style SSL)";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(139, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Port:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Resource:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Priority:";
            // 
            // numPriority
            // 
            this.numPriority.Location = new System.Drawing.Point(83, 127);
            this.numPriority.Name = "numPriority";
            this.numPriority.Size = new System.Drawing.Size(40, 20);
            this.numPriority.TabIndex = 15;
            this.numPriority.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 20;
            this.label3.Text = "Password:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(80, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "user@server.org";
            // 
            // cmdLogin
            // 
            this.cmdLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdLogin.Location = new System.Drawing.Point(35, 253);
            this.cmdLogin.Name = "cmdLogin";
            this.cmdLogin.Size = new System.Drawing.Size(88, 24);
            this.cmdLogin.TabIndex = 21;
            this.cmdLogin.Text = "Login";
            this.cmdLogin.Click += new System.EventHandler(this.cmdLogin_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 13;
            this.label1.Text = "Jabber ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(83, 47);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(168, 20);
            this.txtServer.TabIndex = 2;
            this.txtServer.Text = "santana";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 47);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 16);
            this.label7.TabIndex = 28;
            this.label7.Text = "Server";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 549);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(373, 129);
            this.txtMessage.TabIndex = 29;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(52, 519);
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(168, 20);
            this.txtTo.TabIndex = 30;
            // 
            // txtSenMessage
            // 
            this.txtSenMessage.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtSenMessage.Location = new System.Drawing.Point(230, 519);
            this.txtSenMessage.Name = "txtSenMessage";
            this.txtSenMessage.Size = new System.Drawing.Size(88, 24);
            this.txtSenMessage.TabIndex = 31;
            this.txtSenMessage.Text = "Send";
            this.txtSenMessage.Click += new System.EventHandler(this.txtSenMessage_Click);
            // 
            // rosterControl
            // 
            this.rosterControl.ColorGroup = System.Drawing.SystemColors.Highlight;
            this.rosterControl.ColorResource = System.Drawing.SystemColors.ControlText;
            this.rosterControl.ColorRoot = System.Drawing.SystemColors.Highlight;
            this.rosterControl.ColorRoster = System.Drawing.SystemColors.ControlText;
            this.rosterControl.DefaultGroupName = "ungrouped";
            this.rosterControl.HideEmptyGroups = true;
            this.rosterControl.Location = new System.Drawing.Point(281, 21);
            this.rosterControl.Name = "rosterControl";
            this.rosterControl.Size = new System.Drawing.Size(264, 370);
            this.rosterControl.TabIndex = 32;
            this.rosterControl.SelectionChanged += new System.EventHandler(this.rosterControl_SelectionChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 446);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(168, 20);
            this.textBox1.TabIndex = 33;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 446);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 16);
            this.label8.TabIndex = 34;
            this.label8.Text = "User to add";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(309, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 24);
            this.button1.TabIndex = 35;
            this.button1.Text = "Add";
            // 
            // txtBare
            // 
            this.txtBare.Location = new System.Drawing.Point(52, 496);
            this.txtBare.Multiline = true;
            this.txtBare.Name = "txtBare";
            this.txtBare.Size = new System.Drawing.Size(168, 20);
            this.txtBare.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 496);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 20);
            this.label9.TabIndex = 37;
            this.label9.Text = "Bare";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 519);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "User";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSendCommand.Location = new System.Drawing.Point(626, 519);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(88, 24);
            this.btnSendCommand.TabIndex = 39;
            this.btnSendCommand.Text = "Send command";
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // txtCmdValue
            // 
            this.txtCmdValue.Location = new System.Drawing.Point(720, 523);
            this.txtCmdValue.Multiline = true;
            this.txtCmdValue.Name = "txtCmdValue";
            this.txtCmdValue.Size = new System.Drawing.Size(168, 20);
            this.txtCmdValue.TabIndex = 40;
            this.txtCmdValue.Text = "1232";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 690);
            this.Controls.Add(this.txtCmdValue);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBare);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rosterControl);
            this.Controls.Add(this.txtSenMessage);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.chkRegister);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtResource);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtJid);
            this.Controls.Add(this.chkSSL);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numPriority);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmdLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLogs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.numPriority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.CheckBox chkRegister;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtResource;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtJid;
        private System.Windows.Forms.CheckBox chkSSL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numPriority;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Button txtSenMessage;
        private agsXMPP.ui.roster.RosterControl rosterControl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtBare;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.TextBox txtCmdValue;
    }
}

