using Allus.Cnn.Common;
namespace Allus.Cnn.Colaborator
{
    partial class frmColaborator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmColaborator));
            this.alertMessageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.imageListColumnImages = new System.Windows.Forms.ImageList(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnConnect = new DevExpress.XtraBars.BarButtonItem();
            this.btnClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnconfig = new DevExpress.XtraBars.BarSubItem();
            this.btnMail = new DevExpress.XtraBars.BarButtonItem();
            this.btnClima = new DevExpress.XtraBars.BarButtonItem();
            this.btnClearCache = new DevExpress.XtraBars.BarButtonItem();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.lblConnectionStatus = new DevExpress.XtraBars.BarStaticItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barCheckItem2 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem3 = new DevExpress.XtraBars.BarCheckItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.uC_GridMessage1 = new Allus.Cnn.Common.UC_GridMessage();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txtMessageLogger = new System.Windows.Forms.TextBox();
            this.weatherControlSlim1 = new Allus.Cnn.Common.WeatherControlSlim();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.alertMessageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientMessageControl
            // 
            this.ClientMessageControl.Appearance.BackColor = System.Drawing.Color.White;
            this.ClientMessageControl.Appearance.Options.UseBackColor = true;
            this.ClientMessageControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.ClientMessageControl.LookAndFeel.UseDefaultLookAndFeel = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Se está ejecutando la consola de colaboradores";
            this.notifyIcon1.BalloonTipTitle = "Consola de Colaboradores de Darwin";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Darwin Colaborador";
            // 
            // alertControl1
            // 
            this.alertControl1.AllowHtmlText = true;
            this.alertControl1.AlertClick += new DevExpress.XtraBars.Alerter.AlertClickEventHandler(this.alertControl1_AlertClick);
            // 
            // alertMessageBindingSource
            // 
            this.alertMessageBindingSource.DataSource = typeof(Allus.Cnn.Common.BE.AlertMessage);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList2.Images.SetKeyName(0, "");
            this.imageList2.Images.SetKeyName(1, "");
            this.imageList2.Images.SetKeyName(2, "");
            this.imageList2.Images.SetKeyName(3, "");
            this.imageList2.Images.SetKeyName(4, "");
            this.imageList2.Images.SetKeyName(5, "");
            // 
            // imageList3
            // 
            this.imageList3.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList3.ImageStream")));
            this.imageList3.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList3.Images.SetKeyName(0, "");
            this.imageList3.Images.SetKeyName(1, "");
            this.imageList3.Images.SetKeyName(2, "");
            this.imageList3.Images.SetKeyName(3, "attach.png");
            // 
            // imageListColumnImages
            // 
            this.imageListColumnImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListColumnImages.ImageStream")));
            this.imageListColumnImages.TransparentColor = System.Drawing.Color.Magenta;
            this.imageListColumnImages.Images.SetKeyName(0, "");
            this.imageListColumnImages.Images.SetKeyName(1, "");
            this.imageListColumnImages.Images.SetKeyName(2, "");
            this.imageListColumnImages.Images.SetKeyName(3, "");
            // 
            // barManager1
            // 
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.AllowShowToolbarsPopup = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barCheckItem1,
            this.barSubItem1,
            this.barCheckItem2,
            this.barCheckItem3,
            this.btnConnect,
            this.btnClose,
            this.lblConnectionStatus,
            this.btnconfig,
            this.btnMail,
            this.btnClima,
            this.barButtonItem3,
            this.barButtonItem1,
            this.btnClearCache});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 18;
            this.barManager1.StatusBar = this.bar1;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnConnect),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.None, false, this.btnClose, false),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnconfig)});
            this.bar2.OptionsBar.AllowQuickCustomization = false;
            this.bar2.OptionsBar.DrawDragBorder = false;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Menu Principal";
            // 
            // btnConnect
            // 
            this.btnConnect.Caption = "Conectar";
            this.btnConnect.Glyph = global::Allus.Cnn.Colaborator.Properties.Resources.internet_ok_16;
            this.btnConnect.Id = 4;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnConnect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.btnConnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnConnect_ItemClick);
            // 
            // btnClose
            // 
            this.btnClose.Caption = "Cerrar";
            this.btnClose.Glyph = global::Allus.Cnn.Colaborator.Properties.Resources.close_16;
            this.btnClose.Id = 5;
            this.btnClose.Name = "btnClose";
            this.btnClose.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClose_ItemClick);
            // 
            // btnconfig
            // 
            this.btnconfig.Caption = "Configuración";
            this.btnconfig.Glyph = global::Allus.Cnn.Colaborator.Properties.Resources.Write_Mail_16;
            this.btnconfig.Id = 10;
            this.btnconfig.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnMail),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClima),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnClearCache)});
            this.btnconfig.Name = "btnconfig";
            this.btnconfig.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // btnMail
            // 
            this.btnMail.Caption = "Mail";
            this.btnMail.Glyph = global::Allus.Cnn.Colaborator.Properties.Resources.email;
            this.btnMail.Id = 11;
            this.btnMail.Name = "btnMail";
            this.btnMail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // btnClima
            // 
            this.btnClima.Caption = "Clima";
            this.btnClima.Glyph = global::Allus.Cnn.Colaborator.Properties.Resources.weather2;
            this.btnClima.Id = 12;
            this.btnClima.Name = "btnClima";
            this.btnClima.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // btnClearCache
            // 
            this.btnClearCache.Caption = "Eliminar datos";
            this.btnClearCache.Glyph = global::Allus.Cnn.Colaborator.Properties.Resources.file_del_16;
            this.btnClearCache.Id = 17;
            this.btnClearCache.Name = "btnClearCache";
            this.btnClearCache.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClearCache_ItemClick);
            // 
            // bar1
            // 
            this.bar1.BarName = "Custom 3";
            this.bar1.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.lblConnectionStatus)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Custom 3";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.Caption = "iStatus";
            this.lblConnectionStatus.Glyph = global::Allus.Cnn.Colaborator.Properties.Resources.ball_yellow;
            this.lblConnectionStatus.Id = 8;
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.lblConnectionStatus.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 0;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem_GroupBy";
            this.barSubItem1.Id = 1;
            this.barSubItem1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barCheckItem3)});
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barCheckItem2
            // 
            this.barCheckItem2.Caption = "barCheckItem_Date";
            this.barCheckItem2.Id = 2;
            this.barCheckItem2.Name = "barCheckItem2";
            // 
            // barCheckItem3
            // 
            this.barCheckItem3.Caption = "barCheckItem_Priority";
            this.barCheckItem3.Id = 3;
            this.barCheckItem3.Name = "barCheckItem3";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 14;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 16;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.splitContainerControl1.Appearance.Options.UseBackColor = true;
            this.splitContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 23);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.uC_GridMessage1);
            this.splitContainerControl1.Panel1.MinSize = 270;
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.AppearanceCaption.BackColor = System.Drawing.Color.White;
            this.splitContainerControl1.Panel2.AppearanceCaption.ForeColor = System.Drawing.Color.Transparent;
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseBackColor = true;
            this.splitContainerControl1.Panel2.AppearanceCaption.Options.UseForeColor = true;
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.txtMessageLogger);
            this.splitContainerControl1.Panel2.MinSize = 300;
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(657, 472);
            this.splitContainerControl1.SplitterPosition = 270;
            this.splitContainerControl1.TabIndex = 10;
            // 
            // uC_GridMessage1
            // 
            this.uC_GridMessage1.CurrentMessage = null;
            this.uC_GridMessage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_GridMessage1.Location = new System.Drawing.Point(0, 0);
            this.uC_GridMessage1.Name = "uC_GridMessage1";
            this.uC_GridMessage1.RecivedGrid = true;
            this.uC_GridMessage1.Size = new System.Drawing.Size(270, 466);
            this.uC_GridMessage1.TabIndex = 0;
            this.uC_GridMessage1.OnGridClick += new System.EventHandler(this.uC_GridMessage1_OnGridClick);
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panelControl1.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(375, 466);
            this.panelControl1.TabIndex = 23;
            // 
            // txtMessageLogger
            // 
            this.txtMessageLogger.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessageLogger.BackColor = System.Drawing.Color.White;
            this.txtMessageLogger.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessageLogger.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessageLogger.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.txtMessageLogger.Location = new System.Drawing.Point(79, 60);
            this.txtMessageLogger.Multiline = true;
            this.txtMessageLogger.Name = "txtMessageLogger";
            this.txtMessageLogger.ReadOnly = true;
            this.txtMessageLogger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMessageLogger.Size = new System.Drawing.Size(295, 323);
            this.txtMessageLogger.TabIndex = 19;
            // 
            // weatherControlSlim1
            // 
            this.weatherControlSlim1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.weatherControlSlim1.BackColor = System.Drawing.Color.Transparent;
            this.weatherControlSlim1.LanguageWeather = null;
            this.weatherControlSlim1.Location = new System.Drawing.Point(491, 504);
            this.weatherControlSlim1.LocationCode = null;
            this.weatherControlSlim1.LocationName = "";
            this.weatherControlSlim1.MaximumSize = new System.Drawing.Size(170, 46);
            this.weatherControlSlim1.MinimumSize = new System.Drawing.Size(160, 42);
            this.weatherControlSlim1.Name = "weatherControlSlim1";
            this.weatherControlSlim1.Size = new System.Drawing.Size(160, 46);
            this.weatherControlSlim1.TabIndex = 24;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iExit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(106, 26);
            // 
            // iExit
            // 
            this.iExit.Image = ((System.Drawing.Image)(resources.GetObject("iExit.Image")));
            this.iExit.Name = "iExit";
            this.iExit.Size = new System.Drawing.Size(105, 22);
            this.iExit.Text = "Salir";
            this.iExit.Click += new System.EventHandler(this.iExit_Click);
            // 
            // frmColaborator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 584);
            this.Controls.Add(this.weatherControlSlim1);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.InitFormVisible = true;
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.MinimumSize = new System.Drawing.Size(627, 605);
            this.Name = "frmColaborator";
            this.NotifyText = "Darwin Colaborador";
            this.Text = "Darwin Colaborador";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.frmColaborator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alertMessageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource alertMessageBindingSource;
        private System.Windows.Forms.ImageList imageListColumnImages;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.ImageList imageList3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem2;
        private DevExpress.XtraBars.BarCheckItem barCheckItem3;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraBars.BarButtonItem btnConnect;
        private DevExpress.XtraBars.BarButtonItem btnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iExit;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarStaticItem lblConnectionStatus;
        public System.Windows.Forms.TextBox txtMessageLogger;

        private Allus.Cnn.Common.UC_GridMessage uC_GridMessage1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraBars.BarSubItem btnconfig;
        private DevExpress.XtraBars.BarButtonItem btnMail;
        private DevExpress.XtraBars.BarButtonItem btnClima;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem btnClearCache;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private WeatherControlSlim weatherControlSlim1;
    }
}

