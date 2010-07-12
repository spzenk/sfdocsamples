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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.rosterControl = new agsXMPP.ui.roster.RosterControl();
            this.txtNewContact = new System.Windows.Forms.TextBox();
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
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnChat = new System.Windows.Forms.Button();
            this.btnInRooms = new System.Windows.Forms.Button();
            this.treeGC = new System.Windows.Forms.TreeView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRoom = new System.Windows.Forms.TextBox();
            this.txtNick = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ils16 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
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
            this.txtLogs.Size = new System.Drawing.Size(300, 595);
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
            this.rosterControl.Size = new System.Drawing.Size(318, 372);
            this.rosterControl.TabIndex = 32;
            this.rosterControl.SelectionChanged += new System.EventHandler(this.rosterControl_SelectionChanged);
            // 
            // txtNewContact
            // 
            this.txtNewContact.Location = new System.Drawing.Point(758, 200);
            this.txtNewContact.Name = "txtNewContact";
            this.txtNewContact.Size = new System.Drawing.Size(146, 20);
            this.txtNewContact.TabIndex = 33;
            // 
            // btnAddContact
            // 
            this.btnAddContact.BackColor = System.Drawing.Color.LightGray;
            this.btnAddContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddContact.Location = new System.Drawing.Point(664, 195);
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
            this.btnSendCommand.Location = new System.Drawing.Point(664, 266);
            this.btnSendCommand.Name = "btnSendCommand";
            this.btnSendCommand.Size = new System.Drawing.Size(97, 25);
            this.btnSendCommand.TabIndex = 39;
            this.btnSendCommand.Text = "Send command";
            this.btnSendCommand.UseVisualStyleBackColor = false;
            this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
            // 
            // txtCmdValue
            // 
            this.txtCmdValue.Location = new System.Drawing.Point(777, 266);
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
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Selected user";
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
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.LightGray;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Location = new System.Drawing.Point(579, 29);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(88, 25);
            this.btnRegister.TabIndex = 45;
            this.btnRegister.Text = "Regiter";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnChat
            // 
            this.btnChat.BackColor = System.Drawing.Color.LightGray;
            this.btnChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChat.Location = new System.Drawing.Point(796, 45);
            this.btnChat.Name = "btnChat";
            this.btnChat.Size = new System.Drawing.Size(53, 25);
            this.btnChat.TabIndex = 46;
            this.btnChat.Text = "chat";
            this.btnChat.UseVisualStyleBackColor = false;
            this.btnChat.Click += new System.EventHandler(this.btnChat_Click);
            // 
            // btnInRooms
            // 
            this.btnInRooms.AllowDrop = true;
            this.btnInRooms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInRooms.BackColor = System.Drawing.Color.LightGray;
            this.btnInRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInRooms.Location = new System.Drawing.Point(27, 121);
            this.btnInRooms.Name = "btnInRooms";
            this.btnInRooms.Size = new System.Drawing.Size(88, 25);
            this.btnInRooms.TabIndex = 47;
            this.btnInRooms.Text = "Enter";
            this.btnInRooms.UseVisualStyleBackColor = false;
            this.btnInRooms.Click += new System.EventHandler(this.btnInRooms_Click);
            // 
            // treeGC
            // 
            this.treeGC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.treeGC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeGC.ImageIndex = 0;
            this.treeGC.ImageList = this.ils16;
            this.treeGC.Location = new System.Drawing.Point(340, 453);
            this.treeGC.Name = "treeGC";
            this.treeGC.SelectedImageIndex = 0;
            this.treeGC.Size = new System.Drawing.Size(318, 170);
            this.treeGC.TabIndex = 48;
            this.treeGC.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeGC_AfterSelect);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "Selected room";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRoom
            // 
            this.txtRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRoom.Location = new System.Drawing.Point(24, 51);
            this.txtRoom.Name = "txtRoom";
            this.txtRoom.Size = new System.Drawing.Size(251, 20);
            this.txtRoom.TabIndex = 49;
            // 
            // txtNick
            // 
            this.txtNick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNick.Location = new System.Drawing.Point(27, 95);
            this.txtNick.Name = "txtNick";
            this.txtNick.Size = new System.Drawing.Size(251, 20);
            this.txtNick.TabIndex = 52;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(24, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "Nick";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(337, 431);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 20);
            this.label5.TabIndex = 54;
            this.label5.Text = "Rooms";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ils16
            // 
            this.ils16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ils16.ImageStream")));
            this.ils16.TransparentColor = System.Drawing.Color.Transparent;
            this.ils16.Images.SetKeyName(0, "application_xp_terminal.png");
            this.ils16.Images.SetKeyName(1, "folder_user.png");
            this.ils16.Images.SetKeyName(2, "group.png");
            this.ils16.Images.SetKeyName(3, "user.png");
            this.ils16.Images.SetKeyName(4, "comments.png");
            this.ils16.Images.SetKeyName(5, "server.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.btnInRooms);
            this.groupBox1.Controls.Add(this.txtRoom);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNick);
            this.groupBox1.Location = new System.Drawing.Point(675, 445);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(300, 165);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.LightGray;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(675, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 25);
            this.button1.TabIndex = 56;
            this.button1.Text = "Find users";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(995, 639);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.treeGC);
            this.Controls.Add(this.btnChat);
            this.Controls.Add(this.btnRegister);
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
            this.Controls.Add(this.txtNewContact);
            this.Controls.Add(this.rosterControl);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtLogs);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test jabber client";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.TextBox txtTo;
        private agsXMPP.ui.roster.RosterControl rosterControl;
        private System.Windows.Forms.TextBox txtNewContact;
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
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnChat;
        private System.Windows.Forms.Button btnInRooms;
        private System.Windows.Forms.TreeView treeGC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRoom;
        private System.Windows.Forms.TextBox txtNick;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ImageList ils16;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}

