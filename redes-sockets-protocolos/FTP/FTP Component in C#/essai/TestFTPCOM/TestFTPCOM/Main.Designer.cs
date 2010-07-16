namespace TestFTPCOM
{
    partial class Main
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
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.ServerView = new System.Windows.Forms.ListView();
            this.schName = new System.Windows.Forms.ColumnHeader();
            this.schSize = new System.Windows.Forms.ColumnHeader();
            this.schType = new System.Windows.Forms.ColumnHeader();
            this.schModified = new System.Windows.Forms.ColumnHeader();
            this.contextMenuServer = new System.Windows.Forms.ContextMenu();
            this.MnuServerNewFolder = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.MenuDownload = new System.Windows.Forms.MenuItem();
            this.MnuServerRename = new System.Windows.Forms.MenuItem();
            this.MenuDelete = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.MnuServerProperties = new System.Windows.Forms.MenuItem();
            this.ImgListServerSmall = new System.Windows.Forms.ImageList(this.components);
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.BtnClose = new System.Windows.Forms.Button();
            this.BTConnect = new System.Windows.Forms.Button();
            this.EFPassword = new System.Windows.Forms.TextBox();
            this.Text1 = new System.Windows.Forms.Label();
            this.EFUsername = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CBFTPServer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chSize = new System.Windows.Forms.ColumnHeader();
            this.LocalView = new System.Windows.Forms.ListView();
            this.chType = new System.Windows.Forms.ColumnHeader();
            this.chModified = new System.Windows.Forms.ColumnHeader();
            this.ImgListViewLarge = new System.Windows.Forms.ImageList(this.components);
            this.ImgListViewSmall = new System.Windows.Forms.ImageList(this.components);
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.TextLog = new System.Windows.Forms.RichTextBox();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.SplitView = new System.Windows.Forms.Splitter();
            this.ftpc = new FTPCom.FTPC();
            this.SuspendLayout();
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3,
            this.menuItem4,
            this.menuItem5});
            this.menuItem1.Text = "File";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "New";
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.Text = "Open...";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 2;
            this.menuItem4.Text = "-";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.Text = "Quit";
            // 
            // ServerView
            // 
            this.ServerView.AllowDrop = true;
            this.ServerView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.schName,
            this.schSize,
            this.schType,
            this.schModified});
            this.ServerView.ContextMenu = this.contextMenuServer;
            this.ServerView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerView.LabelEdit = true;
            this.ServerView.Location = new System.Drawing.Point(124, 42);
            this.ServerView.Name = "ServerView";
            this.ServerView.Size = new System.Drawing.Size(734, 335);
            this.ServerView.SmallImageList = this.ImgListServerSmall;
            this.ServerView.TabIndex = 21;
            this.ServerView.UseCompatibleStateImageBehavior = false;
            this.ServerView.View = System.Windows.Forms.View.Details;
            this.ServerView.ItemActivate += new System.EventHandler(this.ServerView_ItemActivate);
            this.ServerView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.ServerView_AfterLabelEdit);
            this.ServerView.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ServerView_MouseMove);
            this.ServerView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ServerView_MouseDown);
            this.ServerView.BeforeLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.ServerView_BeforeLabelEdit);
            // 
            // schName
            // 
            this.schName.Text = "Name";
            this.schName.Width = 120;
            // 
            // schSize
            // 
            this.schSize.Text = "Size";
            // 
            // schType
            // 
            this.schType.Text = "Type";
            // 
            // schModified
            // 
            this.schModified.Text = "Modified";
            // 
            // contextMenuServer
            // 
            this.contextMenuServer.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MnuServerNewFolder,
            this.menuItem7,
            this.MenuDownload,
            this.MnuServerRename,
            this.MenuDelete,
            this.menuItem8,
            this.MnuServerProperties});
            // 
            // MnuServerNewFolder
            // 
            this.MnuServerNewFolder.Index = 0;
            this.MnuServerNewFolder.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.MnuServerNewFolder.Text = "New Folder";
            this.MnuServerNewFolder.Click += new System.EventHandler(this.MnuServerNewFolder_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "-";
            // 
            // MenuDownload
            // 
            this.MenuDownload.Index = 2;
            this.MenuDownload.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.MenuDownload.Text = "Download";
            this.MenuDownload.Click += new System.EventHandler(this.MenuDownload_Click);
            // 
            // MnuServerRename
            // 
            this.MnuServerRename.Index = 3;
            this.MnuServerRename.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.MnuServerRename.Text = "Rename";
            this.MnuServerRename.Click += new System.EventHandler(this.MnuServerRename_Click);
            // 
            // MenuDelete
            // 
            this.MenuDelete.Index = 4;
            this.MenuDelete.Shortcut = System.Windows.Forms.Shortcut.Del;
            this.MenuDelete.Text = "Delete";
            this.MenuDelete.Click += new System.EventHandler(this.MenuDelete_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 5;
            this.menuItem8.Text = "-";
            // 
            // MnuServerProperties
            // 
            this.MnuServerProperties.Index = 6;
            this.MnuServerProperties.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
            this.MnuServerProperties.Text = "Properties";
            // 
            // ImgListServerSmall
            // 
            this.ImgListServerSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImgListServerSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.ImgListServerSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1});
            // 
            // BtnClose
            // 
            this.BtnClose.Location = new System.Drawing.Point(672, 8);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(56, 24);
            this.BtnClose.TabIndex = 29;
            this.BtnClose.Text = "Close";
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // BTConnect
            // 
            this.BTConnect.Location = new System.Drawing.Point(592, 8);
            this.BTConnect.Name = "BTConnect";
            this.BTConnect.Size = new System.Drawing.Size(64, 24);
            this.BTConnect.TabIndex = 28;
            this.BTConnect.Text = "Connect";
            this.BTConnect.Click += new System.EventHandler(this.BTConnect_Click);
            // 
            // EFPassword
            // 
            this.EFPassword.Location = new System.Drawing.Point(456, 8);
            this.EFPassword.Name = "EFPassword";
            this.EFPassword.Size = new System.Drawing.Size(104, 20);
            this.EFPassword.TabIndex = 27;
            this.EFPassword.Text = "anonymous@free.fr";
            // 
            // Text1
            // 
            this.Text1.Location = new System.Drawing.Point(392, 8);
            this.Text1.Name = "Text1";
            this.Text1.Size = new System.Drawing.Size(88, 16);
            this.Text1.TabIndex = 26;
            this.Text1.Text = "Password :";
            // 
            // EFUsername
            // 
            this.EFUsername.Location = new System.Drawing.Point(304, 8);
            this.EFUsername.Name = "EFUsername";
            this.EFUsername.Size = new System.Drawing.Size(80, 20);
            this.EFUsername.TabIndex = 25;
            this.EFUsername.Text = "anonymous";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(240, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "Username :";
            // 
            // CBFTPServer
            // 
            this.CBFTPServer.Items.AddRange(new object[] {
            "localhost"});
            this.CBFTPServer.Location = new System.Drawing.Point(80, 8);
            this.CBFTPServer.Name = "CBFTPServer";
            this.CBFTPServer.Size = new System.Drawing.Size(136, 21);
            this.CBFTPServer.TabIndex = 22;
            this.CBFTPServer.Text = "localhost";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "FTP Server :";
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 120;
            // 
            // chSize
            // 
            this.chSize.Text = "Size";
            // 
            // LocalView
            // 
            this.LocalView.AllowDrop = true;
            this.LocalView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chSize,
            this.chType,
            this.chModified});
            this.LocalView.Dock = System.Windows.Forms.DockStyle.Left;
            this.LocalView.LabelEdit = true;
            this.LocalView.LargeImageList = this.ImgListViewLarge;
            this.LocalView.Location = new System.Drawing.Point(3, 42);
            this.LocalView.Name = "LocalView";
            this.LocalView.Size = new System.Drawing.Size(121, 335);
            this.LocalView.SmallImageList = this.ImgListViewSmall;
            this.LocalView.TabIndex = 19;
            this.LocalView.UseCompatibleStateImageBehavior = false;
            this.LocalView.View = System.Windows.Forms.View.Details;
            // 
            // chType
            // 
            this.chType.Text = "Type";
            // 
            // chModified
            // 
            this.chModified.Text = "Modified";
            this.chModified.Width = 120;
            // 
            // ImgListViewLarge
            // 
            this.ImgListViewLarge.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImgListViewLarge.ImageSize = new System.Drawing.Size(16, 16);
            this.ImgListViewLarge.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ImgListViewSmall
            // 
            this.ImgListViewSmall.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ImgListViewSmall.ImageSize = new System.Drawing.Size(16, 16);
            this.ImgListViewSmall.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(3, 377);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(855, 3);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // TextLog
            // 
            this.TextLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.TextLog.Location = new System.Drawing.Point(3, 380);
            this.TextLog.Name = "TextLog";
            this.TextLog.ReadOnly = true;
            this.TextLog.Size = new System.Drawing.Size(855, 64);
            this.TextLog.TabIndex = 17;
            this.TextLog.Text = "";
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(3, 444);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(855, 22);
            this.statusBar1.TabIndex = 15;
            this.statusBar1.Text = "statusBar1";
            // 
            // toolBar1
            // 
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Location = new System.Drawing.Point(3, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(855, 42);
            this.toolBar1.TabIndex = 16;
            // 
            // SplitView
            // 
            this.SplitView.Location = new System.Drawing.Point(0, 0);
            this.SplitView.Name = "SplitView";
            this.SplitView.Size = new System.Drawing.Size(3, 466);
            this.SplitView.TabIndex = 20;
            this.SplitView.TabStop = false;
            // 
            // ftpc
            // 
            this.ftpc.Hostname = "";
            this.ftpc.LocalFolder = "c:\\temp";
            this.ftpc.Password = "";
            this.ftpc.Port = 21;
            this.ftpc.RemoteFolder = "";
            this.ftpc.Type = "A";
            this.ftpc.Username = "";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 466);
            this.Controls.Add(this.ServerView);
            this.Controls.Add(this.BtnClose);
            this.Controls.Add(this.BTConnect);
            this.Controls.Add(this.EFPassword);
            this.Controls.Add(this.Text1);
            this.Controls.Add(this.EFUsername);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBFTPServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LocalView);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.TextLog);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.SplitView);
            this.Menu = this.mainMenu1;
            this.Name = "Main";
            this.Text = "Main";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.ListView ServerView;
        private System.Windows.Forms.ColumnHeader schName;
        private System.Windows.Forms.ColumnHeader schSize;
        private System.Windows.Forms.ColumnHeader schType;
        private System.Windows.Forms.ColumnHeader schModified;
        private System.Windows.Forms.ContextMenu contextMenuServer;
        private System.Windows.Forms.MenuItem MnuServerNewFolder;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem MenuDownload;
        private System.Windows.Forms.MenuItem MnuServerRename;
        private System.Windows.Forms.MenuItem MenuDelete;
        private System.Windows.Forms.MenuItem menuItem8;
        private System.Windows.Forms.MenuItem MnuServerProperties;
        private System.Windows.Forms.ImageList ImgListServerSmall;
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.Button BTConnect;
        private System.Windows.Forms.TextBox EFPassword;
        private System.Windows.Forms.Label Text1;
        private System.Windows.Forms.TextBox EFUsername;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CBFTPServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chSize;
        private System.Windows.Forms.ListView LocalView;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chModified;
        private System.Windows.Forms.ImageList ImgListViewLarge;
        private System.Windows.Forms.ImageList ImgListViewSmall;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RichTextBox TextLog;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.ToolBar toolBar1;
        private System.Windows.Forms.Splitter SplitView;
       
    }
}