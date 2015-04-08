using Epiron.Front.Bases;
namespace Epiron.Gestion.Ribon
{
    partial class frmRibbonForm1
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.userContrlManager1 = new Epiron.Front.Bases.UserContrlManager(this.components);
            this.splitControl = new DevExpress.XtraEditors.SplitContainerControl();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl_LeftPanel_1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl_RightPanel = new DevExpress.XtraEditors.PanelControl();
            this.panelControl_FootherPanel = new DevExpress.XtraEditors.PanelControl();
            this.ExceptionViewer = new Epiron.Front.Bases.ExceptionViewComponent(this.components);
            this.MessageViewer = new Epiron.Front.Bases.MessageViewerComponent(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitControl)).BeginInit();
            this.splitControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_LeftPanel_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_RightPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_FootherPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.ExpandCollapseItem.Name = "";
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItem1});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 2;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(1151, 155);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Show dialog sample";
            this.barButtonItem1.Id = 1;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 764);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1151, 31);
            // 
            // userContrlManager1
            // 
            this.userContrlManager1.ParentForm = this;
            // 
            // splitControl
            // 
            this.splitControl.Location = new System.Drawing.Point(0, 157);
            this.splitControl.LookAndFeel.SkinName = "Office 2010 Black";
            this.splitControl.Name = "splitControl";
            this.splitControl.Panel1.Controls.Add(this.simpleButton3);
            this.splitControl.Panel1.Controls.Add(this.simpleButton2);
            this.splitControl.Panel1.Controls.Add(this.simpleButton1);
            this.splitControl.Panel1.Controls.Add(this.panelControl_LeftPanel_1);
            this.splitControl.Panel1.Text = "Panel1";
            this.splitControl.Panel2.Controls.Add(this.panelControl_RightPanel);
            this.splitControl.Panel2.Text = "Panel2";
            this.splitControl.Size = new System.Drawing.Size(1146, 534);
            this.splitControl.SplitterPosition = 205;
            this.splitControl.TabIndex = 2;
            this.splitControl.Text = "splitContainerControl1";
            // 
            // simpleButton3
            // 
            this.simpleButton3.Location = new System.Drawing.Point(12, 37);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(80, 23);
            this.simpleButton3.TabIndex = 3;
            this.simpleButton3.Text = "Dialog";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // simpleButton2
            // 
            this.simpleButton2.Location = new System.Drawing.Point(52, 76);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(40, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "2";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(10, 76);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(36, 23);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panelControl_LeftPanel_1
            // 
            this.panelControl_LeftPanel_1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl_LeftPanel_1.Location = new System.Drawing.Point(8, 124);
            this.panelControl_LeftPanel_1.Name = "panelControl_LeftPanel_1";
            this.panelControl_LeftPanel_1.Size = new System.Drawing.Size(197, 395);
            this.panelControl_LeftPanel_1.TabIndex = 0;
            this.panelControl_LeftPanel_1.Tag = "LeftPanel_1";
            // 
            // panelControl_RightPanel
            // 
            this.panelControl_RightPanel.Location = new System.Drawing.Point(1, 12);
            this.panelControl_RightPanel.Name = "panelControl_RightPanel";
            this.panelControl_RightPanel.Size = new System.Drawing.Size(967, 659);
            this.panelControl_RightPanel.TabIndex = 0;
            this.panelControl_RightPanel.Tag = "RightPanel";
            // 
            // panelControl_FootherPanel
            // 
            this.panelControl_FootherPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl_FootherPanel.Location = new System.Drawing.Point(0, 680);
            this.panelControl_FootherPanel.Name = "panelControl_FootherPanel";
            this.panelControl_FootherPanel.Size = new System.Drawing.Size(1151, 84);
            this.panelControl_FootherPanel.TabIndex = 3;
            this.panelControl_FootherPanel.Tag = "FootherPanel";
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.ExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ExceptionViewer.TextMessageColor = System.Drawing.Color.White;
            this.ExceptionViewer.TextMessageForeColorColor = System.Drawing.Color.Black;
            this.ExceptionViewer.Title = "";
            // 
            // MessageViewer
            // 
            this.MessageViewer.BackColor = System.Drawing.Color.Gray;
            this.MessageViewer.IconSize = Fwk.UI.Common.IconSize.Medium;
            this.MessageViewer.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
            this.MessageViewer.TextMessageColor = System.Drawing.Color.White;
            this.MessageViewer.TextMessageForeColor = System.Drawing.Color.Black;
            this.MessageViewer.Title = "Epiron gestion";
            // 
            // frmRibbonForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 795);
            this.Controls.Add(this.panelControl_FootherPanel);
            this.Controls.Add(this.splitControl);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Name = "frmRibbonForm1";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "frmRibbonForm1";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitControl)).EndInit();
            this.splitControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_LeftPanel_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_RightPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl_FootherPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private UserContrlManager userContrlManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.SplitContainerControl splitControl;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PanelControl panelControl_LeftPanel_1;
        private DevExpress.XtraEditors.PanelControl panelControl_RightPanel;
        private DevExpress.XtraEditors.PanelControl panelControl_FootherPanel;
        public Epiron.Front.Bases.ExceptionViewComponent ExceptionViewer;
        public Epiron.Front.Bases.MessageViewerComponent MessageViewer;
    }
}