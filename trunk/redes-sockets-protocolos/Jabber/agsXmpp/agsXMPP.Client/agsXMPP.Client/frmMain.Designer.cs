namespace agsXMPP.Client
{
    partial class frmMain
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
            this.txtTo = new System.Windows.Forms.TextBox();
            this.rosterControl = new agsXMPP.ui.roster.RosterControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAddContact = new System.Windows.Forms.Button();
            this.txtBare = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSendCommand = new System.Windows.Forms.Button();
            this.txtCmdValue = new System.Windows.Forms.TextBox();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtLogs.Location = new System.Drawing.Point(5, 32);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogs.Size = new System.Drawing.Size(300, 526);
            this.txtLogs.TabIndex = 0;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(736, 96);
            this.txtTo.Multiline = true;
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(168, 20);
            this.txtTo.TabIndex = 30;
            // 
            // rosterControl
            // 
            this.rosterControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.rosterControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rosterControl.ColorGroup = System.Drawing.SystemColors.Highlight;
            this.rosterControl.ColorResource = System.Drawing.SystemColors.ControlText;
            this.rosterControl.ColorRoot = System.Drawing.SystemColors.Highlight;
            this.rosterControl.ColorRoster = System.Drawing.SystemColors.ControlText;
            this.rosterControl.DefaultGroupName = "ungrouped";
            this.rosterControl.HideEmptyGroups = true;
            this.rosterControl.Location = new System.Drawing.Point(340, 60);
            this.rosterControl.Name = "rosterControl";
            this.rosterControl.Size = new System.Drawing.Size(318, 498);
            this.rosterControl.TabIndex = 32;
            this.rosterControl.SelectionChanged += new System.EventHandler(this.rosterControl_SelectionChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(758, 152);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(146, 20);
            this.textBox1.TabIndex = 33;
            // 
            // btnAddContact
            // 
            this.btnAddContact.BackColor = System.Drawing.Color.LightGray;
            this.btnAddContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddContact.Location = new System.Drawing.Point(664, 147);
            this.btnAddContact.Name = "btnAddContact";
            this.btnAddContact.Size = new System.Drawing.Size(88, 25);
            this.btnAddContact.TabIndex = 35;
            this.btnAddContact.Text = "Add contact";
            this.btnAddContact.UseVisualStyleBackColor = false;
            this.btnAddContact.Click += new System.EventHandler(this.btnAddContact_Click);
            // 
            // txtBare
            // 
            this.txtBare.Location = new System.Drawing.Point(736, 73);
            this.txtBare.Multiline = true;
            this.txtBare.Name = "txtBare";
            this.txtBare.Size = new System.Drawing.Size(168, 20);
            this.txtBare.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(693, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 20);
            this.label9.TabIndex = 37;
            this.label9.Text = "Bare";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(696, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 20);
            this.label10.TabIndex = 38;
            this.label10.Text = "User";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSendCommand
            // 
            this.btnSendCommand.BackColor = System.Drawing.Color.LightGray;
            this.btnSendCommand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendCommand.Location = new System.Drawing.Point(664, 189);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(88, 25);
            this.btnSendCommand.TabIndex = 39;
            this.btnSendCommand.Text = "Send command";
            this.btnSendCommand.UseVisualStyleBackColor = false;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // txtCmdValue
            // 
            this.txtCmdValue.Location = new System.Drawing.Point(758, 193);
            this.txtCmdValue.Multiline = true;
            this.txtCmdValue.Name = "txtCmdValue";
            this.txtCmdValue.Size = new System.Drawing.Size(146, 21);
            this.txtCmdValue.TabIndex = 40;
            this.txtCmdValue.Text = "1232";
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.LightGray;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Location = new System.Drawing.Point(340, 29);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Size = new System.Drawing.Size(88, 25);
            this.btnLogIn.TabIndex = 41;
            this.btnLogIn.Text = "Loging";
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 42;
            this.label1.Text = "Logs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(696, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Selected";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.LightGray;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Location = new System.Drawing.Point(453, 29);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(88, 25);
            this.btnLogOut.TabIndex = 44;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(969, 570);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogIn);
            this.Controls.Add(this.txtCmdValue);
            this.Controls.Add(this.btnSendCommand);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBare);
            this.Controls.Add(this.btnAddContact);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rosterControl);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtLogs);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test jabber client";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.TextBox txtTo;
        private agsXMPP.ui.roster.RosterControl rosterControl;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAddContact;
        private System.Windows.Forms.TextBox txtBare;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSendCommand;
        private System.Windows.Forms.TextBox txtCmdValue;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogOut;
    }
}

