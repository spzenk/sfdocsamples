namespace Allus.Cnn.Common
{
    partial class WeatherControlSlim
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeatherControlSlim));
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblLastRecord = new DevExpress.XtraEditors.LabelControl();
            this.lblRegion = new DevExpress.XtraEditors.LabelControl();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTRMax = new DevExpress.XtraEditors.LabelControl();
            this.PicTomorrow = new DevExpress.XtraEditors.PictureEdit();
            this.lblFechaToday = new DevExpress.XtraEditors.LabelControl();
            this.lblFechaTomorrow = new DevExpress.XtraEditors.LabelControl();
            this.lblTMin = new DevExpress.XtraEditors.LabelControl();
            this.lblTRMin = new DevExpress.XtraEditors.LabelControl();
            this.picToday = new DevExpress.XtraEditors.PictureEdit();
            this.lblTMax = new DevExpress.XtraEditors.LabelControl();
            this.lblTemperature = new DevExpress.XtraEditors.LabelControl();
            this.picCurrent = new DevExpress.XtraEditors.PictureEdit();
            this.ImageCollectionClima = new DevExpress.Utils.ImageCollection(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.timerClima = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTomorrow.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToday.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionClima)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblLastRecord);
            this.panel1.Controls.Add(this.lblRegion);
            this.panel1.Controls.Add(this.popupContainerEdit1);
            this.panel1.Controls.Add(this.lblTemperature);
            this.panel1.Controls.Add(this.picCurrent);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(170, 49);
            this.panel1.TabIndex = 0;
            // 
            // lblLastRecord
            // 
            this.lblLastRecord.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastRecord.Appearance.Options.UseFont = true;
            this.lblLastRecord.Appearance.Options.UseTextOptions = true;
            this.lblLastRecord.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblLastRecord.Location = new System.Drawing.Point(20, 36);
            this.lblLastRecord.Name = "lblLastRecord";
            this.lblLastRecord.Size = new System.Drawing.Size(0, 9);
            this.lblLastRecord.TabIndex = 4;
            // 
            // lblRegion
            // 
            this.lblRegion.Appearance.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRegion.Appearance.Options.UseFont = true;
            this.lblRegion.Location = new System.Drawing.Point(57, 0);
            this.lblRegion.Name = "lblRegion";
            this.lblRegion.Size = new System.Drawing.Size(0, 11);
            this.lblRegion.TabIndex = 3;
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.popupContainerEdit1.Location = new System.Drawing.Point(138, 13);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Properties.PopupSizeable = false;
            this.popupContainerEdit1.Properties.ShowPopupCloseButton = false;
            this.popupContainerEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.popupContainerEdit1.Size = new System.Drawing.Size(19, 20);
            this.popupContainerEdit1.TabIndex = 2;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.popupContainerControl1.Appearance.Options.UseBackColor = true;
            this.popupContainerControl1.Controls.Add(this.panel2);
            this.popupContainerControl1.Location = new System.Drawing.Point(3, 48);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(239, 53);
            this.popupContainerControl1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Allus.Cnn.Common.Properties.Resources.wdgt_day;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Controls.Add(this.lblTRMax);
            this.panel2.Controls.Add(this.PicTomorrow);
            this.panel2.Controls.Add(this.lblFechaToday);
            this.panel2.Controls.Add(this.lblFechaTomorrow);
            this.panel2.Controls.Add(this.lblTMin);
            this.panel2.Controls.Add(this.lblTRMin);
            this.panel2.Controls.Add(this.picToday);
            this.panel2.Controls.Add(this.lblTMax);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.ForeColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(239, 53);
            this.panel2.TabIndex = 0;
            // 
            // lblTRMax
            // 
            this.lblTRMax.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTRMax.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTRMax.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTRMax.Appearance.Options.UseBackColor = true;
            this.lblTRMax.Appearance.Options.UseFont = true;
            this.lblTRMax.Appearance.Options.UseForeColor = true;
            this.lblTRMax.Location = new System.Drawing.Point(212, 24);
            this.lblTRMax.Name = "lblTRMax";
            this.lblTRMax.Size = new System.Drawing.Size(16, 14);
            this.lblTRMax.TabIndex = 9;
            this.lblTRMax.Text = "--°";
            // 
            // PicTomorrow
            // 
            this.PicTomorrow.EditValue = ((object)(resources.GetObject("PicTomorrow.EditValue")));
            this.PicTomorrow.Location = new System.Drawing.Point(120, 5);
            this.PicTomorrow.Name = "PicTomorrow";
            this.PicTomorrow.Properties.AllowFocused = false;
            this.PicTomorrow.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.PicTomorrow.Properties.Appearance.Options.UseBackColor = true;
            this.PicTomorrow.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.PicTomorrow.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.PicTomorrow.Size = new System.Drawing.Size(63, 41);
            this.PicTomorrow.TabIndex = 3;
            // 
            // lblFechaToday
            // 
            this.lblFechaToday.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaToday.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.lblFechaToday.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblFechaToday.Appearance.Options.UseBackColor = true;
            this.lblFechaToday.Appearance.Options.UseFont = true;
            this.lblFechaToday.Appearance.Options.UseForeColor = true;
            this.lblFechaToday.Location = new System.Drawing.Point(65, 5);
            this.lblFechaToday.Name = "lblFechaToday";
            this.lblFechaToday.Size = new System.Drawing.Size(20, 13);
            this.lblFechaToday.TabIndex = 4;
            this.lblFechaToday.Text = "--/--";
            // 
            // lblFechaTomorrow
            // 
            this.lblFechaTomorrow.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaTomorrow.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.lblFechaTomorrow.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblFechaTomorrow.Appearance.Options.UseBackColor = true;
            this.lblFechaTomorrow.Appearance.Options.UseFont = true;
            this.lblFechaTomorrow.Appearance.Options.UseForeColor = true;
            this.lblFechaTomorrow.Location = new System.Drawing.Point(188, 5);
            this.lblFechaTomorrow.Name = "lblFechaTomorrow";
            this.lblFechaTomorrow.Size = new System.Drawing.Size(20, 13);
            this.lblFechaTomorrow.TabIndex = 5;
            this.lblFechaTomorrow.Text = "--/--";
            // 
            // lblTMin
            // 
            this.lblTMin.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTMin.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTMin.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTMin.Appearance.Options.UseBackColor = true;
            this.lblTMin.Appearance.Options.UseFont = true;
            this.lblTMin.Appearance.Options.UseForeColor = true;
            this.lblTMin.Location = new System.Drawing.Point(65, 24);
            this.lblTMin.Name = "lblTMin";
            this.lblTMin.Size = new System.Drawing.Size(16, 14);
            this.lblTMin.TabIndex = 6;
            this.lblTMin.Text = "--°";
            // 
            // lblTRMin
            // 
            this.lblTRMin.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTRMin.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTRMin.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTRMin.Appearance.Options.UseBackColor = true;
            this.lblTRMin.Appearance.Options.UseFont = true;
            this.lblTRMin.Appearance.Options.UseForeColor = true;
            this.lblTRMin.Location = new System.Drawing.Point(184, 24);
            this.lblTRMin.Name = "lblTRMin";
            this.lblTRMin.Size = new System.Drawing.Size(16, 14);
            this.lblTRMin.TabIndex = 8;
            this.lblTRMin.Text = "--°";
            // 
            // picToday
            // 
            this.picToday.EditValue = ((object)(resources.GetObject("picToday.EditValue")));
            this.picToday.Location = new System.Drawing.Point(6, 5);
            this.picToday.Name = "picToday";
            this.picToday.Properties.AllowFocused = false;
            this.picToday.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picToday.Properties.Appearance.Options.UseBackColor = true;
            this.picToday.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picToday.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picToday.Size = new System.Drawing.Size(63, 41);
            this.picToday.TabIndex = 2;
            // 
            // lblTMax
            // 
            this.lblTMax.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTMax.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblTMax.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTMax.Appearance.Options.UseBackColor = true;
            this.lblTMax.Appearance.Options.UseFont = true;
            this.lblTMax.Appearance.Options.UseForeColor = true;
            this.lblTMax.Location = new System.Drawing.Point(92, 24);
            this.lblTMax.Name = "lblTMax";
            this.lblTMax.Size = new System.Drawing.Size(16, 14);
            this.lblTMax.TabIndex = 7;
            this.lblTMax.Text = "--°";
            // 
            // lblTemperature
            // 
            this.lblTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTemperature.Appearance.Font = new System.Drawing.Font("Tahoma", 20F);
            this.lblTemperature.Appearance.Options.UseFont = true;
            this.lblTemperature.Location = new System.Drawing.Point(82, 7);
            this.lblTemperature.Name = "lblTemperature";
            this.lblTemperature.Size = new System.Drawing.Size(33, 33);
            this.lblTemperature.TabIndex = 1;
            this.lblTemperature.Text = "--°";
            // 
            // picCurrent
            // 
            this.picCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picCurrent.EditValue = ((object)(resources.GetObject("picCurrent.EditValue")));
            this.picCurrent.Location = new System.Drawing.Point(5, 3);
            this.picCurrent.Name = "picCurrent";
            this.picCurrent.Properties.AllowFocused = false;
            this.picCurrent.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picCurrent.Properties.Appearance.Options.UseBackColor = true;
            this.picCurrent.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picCurrent.Properties.ShowMenu = false;
            this.picCurrent.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.picCurrent.Size = new System.Drawing.Size(66, 39);
            this.picCurrent.TabIndex = 1;
            // 
            // ImageCollectionClima
            // 
            this.ImageCollectionClima.ImageSize = new System.Drawing.Size(96, 96);
            this.ImageCollectionClima.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("ImageCollectionClima.ImageStream")));
            this.ImageCollectionClima.Images.SetKeyName(0, "47s.png");
            this.ImageCollectionClima.Images.SetKeyName(1, "0d.png");
            this.ImageCollectionClima.Images.SetKeyName(2, "0n.png");
            this.ImageCollectionClima.Images.SetKeyName(3, "0s.png");
            this.ImageCollectionClima.Images.SetKeyName(4, "1d.png");
            this.ImageCollectionClima.Images.SetKeyName(5, "1n.png");
            this.ImageCollectionClima.Images.SetKeyName(6, "1s.png");
            this.ImageCollectionClima.Images.SetKeyName(7, "2d.png");
            this.ImageCollectionClima.Images.SetKeyName(8, "2n.png");
            this.ImageCollectionClima.Images.SetKeyName(9, "2s.png");
            this.ImageCollectionClima.Images.SetKeyName(10, "3d.png");
            this.ImageCollectionClima.Images.SetKeyName(11, "3n.png");
            this.ImageCollectionClima.Images.SetKeyName(12, "3s.png");
            this.ImageCollectionClima.Images.SetKeyName(13, "4d.png");
            this.ImageCollectionClima.Images.SetKeyName(14, "4n.png");
            this.ImageCollectionClima.Images.SetKeyName(15, "4s.png");
            this.ImageCollectionClima.Images.SetKeyName(16, "5d.png");
            this.ImageCollectionClima.Images.SetKeyName(17, "5n.png");
            this.ImageCollectionClima.Images.SetKeyName(18, "5s.png");
            this.ImageCollectionClima.Images.SetKeyName(19, "6d.png");
            this.ImageCollectionClima.Images.SetKeyName(20, "6n.png");
            this.ImageCollectionClima.Images.SetKeyName(21, "6s.png");
            this.ImageCollectionClima.Images.SetKeyName(22, "7d.png");
            this.ImageCollectionClima.Images.SetKeyName(23, "7n.png");
            this.ImageCollectionClima.Images.SetKeyName(24, "7s.png");
            this.ImageCollectionClima.Images.SetKeyName(25, "8d.png");
            this.ImageCollectionClima.Images.SetKeyName(26, "8n.png");
            this.ImageCollectionClima.Images.SetKeyName(27, "8s.png");
            this.ImageCollectionClima.Images.SetKeyName(28, "9d.png");
            this.ImageCollectionClima.Images.SetKeyName(29, "9n.png");
            this.ImageCollectionClima.Images.SetKeyName(30, "9s.png");
            this.ImageCollectionClima.Images.SetKeyName(31, "10d.png");
            this.ImageCollectionClima.Images.SetKeyName(32, "10n.png");
            this.ImageCollectionClima.Images.SetKeyName(33, "10s.png");
            this.ImageCollectionClima.Images.SetKeyName(34, "11d.png");
            this.ImageCollectionClima.Images.SetKeyName(35, "11n.png");
            this.ImageCollectionClima.Images.SetKeyName(36, "11s.png");
            this.ImageCollectionClima.Images.SetKeyName(37, "12d.png");
            this.ImageCollectionClima.Images.SetKeyName(38, "12n.png");
            this.ImageCollectionClima.Images.SetKeyName(39, "12s.png");
            this.ImageCollectionClima.Images.SetKeyName(40, "13d.png");
            this.ImageCollectionClima.Images.SetKeyName(41, "13n.png");
            this.ImageCollectionClima.Images.SetKeyName(42, "13s.png");
            this.ImageCollectionClima.Images.SetKeyName(43, "14d.png");
            this.ImageCollectionClima.Images.SetKeyName(44, "14n.png");
            this.ImageCollectionClima.Images.SetKeyName(45, "14s.png");
            this.ImageCollectionClima.Images.SetKeyName(46, "15d.png");
            this.ImageCollectionClima.Images.SetKeyName(47, "15n.png");
            this.ImageCollectionClima.Images.SetKeyName(48, "15s.png");
            this.ImageCollectionClima.Images.SetKeyName(49, "16d.png");
            this.ImageCollectionClima.Images.SetKeyName(50, "16n.png");
            this.ImageCollectionClima.Images.SetKeyName(51, "16s.png");
            this.ImageCollectionClima.Images.SetKeyName(52, "17d.png");
            this.ImageCollectionClima.Images.SetKeyName(53, "17n.png");
            this.ImageCollectionClima.Images.SetKeyName(54, "17s.png");
            this.ImageCollectionClima.Images.SetKeyName(55, "18d.png");
            this.ImageCollectionClima.Images.SetKeyName(56, "18n.png");
            this.ImageCollectionClima.Images.SetKeyName(57, "18s.png");
            this.ImageCollectionClima.Images.SetKeyName(58, "19d.png");
            this.ImageCollectionClima.Images.SetKeyName(59, "19n.png");
            this.ImageCollectionClima.Images.SetKeyName(60, "19s.png");
            this.ImageCollectionClima.Images.SetKeyName(61, "20d.png");
            this.ImageCollectionClima.Images.SetKeyName(62, "20n.png");
            this.ImageCollectionClima.Images.SetKeyName(63, "20s.png");
            this.ImageCollectionClima.Images.SetKeyName(64, "21d.png");
            this.ImageCollectionClima.Images.SetKeyName(65, "21n.png");
            this.ImageCollectionClima.Images.SetKeyName(66, "21s.png");
            this.ImageCollectionClima.Images.SetKeyName(67, "22d.png");
            this.ImageCollectionClima.Images.SetKeyName(68, "22n.png");
            this.ImageCollectionClima.Images.SetKeyName(69, "22s.png");
            this.ImageCollectionClima.Images.SetKeyName(70, "23d.png");
            this.ImageCollectionClima.Images.SetKeyName(71, "23n.png");
            this.ImageCollectionClima.Images.SetKeyName(72, "23s.png");
            this.ImageCollectionClima.Images.SetKeyName(73, "24d.png");
            this.ImageCollectionClima.Images.SetKeyName(74, "24n.png");
            this.ImageCollectionClima.Images.SetKeyName(75, "24s.png");
            this.ImageCollectionClima.Images.SetKeyName(76, "25d.png");
            this.ImageCollectionClima.Images.SetKeyName(77, "25n.png");
            this.ImageCollectionClima.Images.SetKeyName(78, "25s.png");
            this.ImageCollectionClima.Images.SetKeyName(79, "26d.png");
            this.ImageCollectionClima.Images.SetKeyName(80, "26n.png");
            this.ImageCollectionClima.Images.SetKeyName(81, "26s.png");
            this.ImageCollectionClima.Images.SetKeyName(82, "27d.png");
            this.ImageCollectionClima.Images.SetKeyName(83, "27n.png");
            this.ImageCollectionClima.Images.SetKeyName(84, "27s.png");
            this.ImageCollectionClima.Images.SetKeyName(85, "28d.png");
            this.ImageCollectionClima.Images.SetKeyName(86, "28n.png");
            this.ImageCollectionClima.Images.SetKeyName(87, "28s.png");
            this.ImageCollectionClima.Images.SetKeyName(88, "29d.png");
            this.ImageCollectionClima.Images.SetKeyName(89, "29n.png");
            this.ImageCollectionClima.Images.SetKeyName(90, "29s.png");
            this.ImageCollectionClima.Images.SetKeyName(91, "30d.png");
            this.ImageCollectionClima.Images.SetKeyName(92, "30n.png");
            this.ImageCollectionClima.Images.SetKeyName(93, "30s.png");
            this.ImageCollectionClima.Images.SetKeyName(94, "31d.png");
            this.ImageCollectionClima.Images.SetKeyName(95, "31n.png");
            this.ImageCollectionClima.Images.SetKeyName(96, "31s.png");
            this.ImageCollectionClima.Images.SetKeyName(97, "32d.png");
            this.ImageCollectionClima.Images.SetKeyName(98, "32n.png");
            this.ImageCollectionClima.Images.SetKeyName(99, "32s.png");
            this.ImageCollectionClima.Images.SetKeyName(100, "33d.png");
            this.ImageCollectionClima.Images.SetKeyName(101, "33n.png");
            this.ImageCollectionClima.Images.SetKeyName(102, "33s.png");
            this.ImageCollectionClima.Images.SetKeyName(103, "34d.png");
            this.ImageCollectionClima.Images.SetKeyName(104, "34n.png");
            this.ImageCollectionClima.Images.SetKeyName(105, "34s.png");
            this.ImageCollectionClima.Images.SetKeyName(106, "35d.png");
            this.ImageCollectionClima.Images.SetKeyName(107, "35n.png");
            this.ImageCollectionClima.Images.SetKeyName(108, "35s.png");
            this.ImageCollectionClima.Images.SetKeyName(109, "36d.png");
            this.ImageCollectionClima.Images.SetKeyName(110, "36n.png");
            this.ImageCollectionClima.Images.SetKeyName(111, "36s.png");
            this.ImageCollectionClima.Images.SetKeyName(112, "37d.png");
            this.ImageCollectionClima.Images.SetKeyName(113, "37n.png");
            this.ImageCollectionClima.Images.SetKeyName(114, "37s.png");
            this.ImageCollectionClima.Images.SetKeyName(115, "38d.png");
            this.ImageCollectionClima.Images.SetKeyName(116, "38n.png");
            this.ImageCollectionClima.Images.SetKeyName(117, "38s.png");
            this.ImageCollectionClima.Images.SetKeyName(118, "39d.png");
            this.ImageCollectionClima.Images.SetKeyName(119, "39n.png");
            this.ImageCollectionClima.Images.SetKeyName(120, "39s.png");
            this.ImageCollectionClima.Images.SetKeyName(121, "40d.png");
            this.ImageCollectionClima.Images.SetKeyName(122, "40n.png");
            this.ImageCollectionClima.Images.SetKeyName(123, "40s.png");
            this.ImageCollectionClima.Images.SetKeyName(124, "41d.png");
            this.ImageCollectionClima.Images.SetKeyName(125, "41n.png");
            this.ImageCollectionClima.Images.SetKeyName(126, "41s.png");
            this.ImageCollectionClima.Images.SetKeyName(127, "42d.png");
            this.ImageCollectionClima.Images.SetKeyName(128, "42n.png");
            this.ImageCollectionClima.Images.SetKeyName(129, "42s.png");
            this.ImageCollectionClima.Images.SetKeyName(130, "43d.png");
            this.ImageCollectionClima.Images.SetKeyName(131, "43n.png");
            this.ImageCollectionClima.Images.SetKeyName(132, "43s.png");
            this.ImageCollectionClima.Images.SetKeyName(133, "44d.png");
            this.ImageCollectionClima.Images.SetKeyName(134, "44n.png");
            this.ImageCollectionClima.Images.SetKeyName(135, "44s.png");
            this.ImageCollectionClima.Images.SetKeyName(136, "45d.png");
            this.ImageCollectionClima.Images.SetKeyName(137, "45n.png");
            this.ImageCollectionClima.Images.SetKeyName(138, "45s.png");
            this.ImageCollectionClima.Images.SetKeyName(139, "46d.png");
            this.ImageCollectionClima.Images.SetKeyName(140, "46n.png");
            this.ImageCollectionClima.Images.SetKeyName(141, "46s.png");
            this.ImageCollectionClima.Images.SetKeyName(142, "47d.png");
            this.ImageCollectionClima.Images.SetKeyName(143, "47n.png");
            this.ImageCollectionClima.Images.SetKeyName(144, "3200s.png");
            this.ImageCollectionClima.Images.SetKeyName(145, "3200d.png");
            this.ImageCollectionClima.Images.SetKeyName(146, "3200n.png");
            // 
            // toolTipController1
            // 
            this.toolTipController1.AutoPopDelay = 30000;
            this.toolTipController1.CloseOnClick = DevExpress.Utils.DefaultBoolean.True;
            this.toolTipController1.Rounded = true;
            // 
            // timerClima
            // 
            this.timerClima.Enabled = true;
            this.timerClima.Interval = 900000;
            this.timerClima.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(161, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = global::Allus.Cnn.Common.Properties.Resources.refresh;
            this.toolStripMenuItem1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.toolStripMenuItem1.Text = "Actualizar Clima";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // WeatherControlSlim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(170, 49);
            this.MinimumSize = new System.Drawing.Size(170, 49);
            this.Name = "WeatherControlSlim";
            this.Size = new System.Drawing.Size(170, 49);
            this.Load += new System.EventHandler(this.WeatherControlSlim_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicTomorrow.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToday.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCurrent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImageCollectionClima)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.PictureEdit picCurrent;
        private DevExpress.XtraEditors.LabelControl lblTemperature;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraEditors.LabelControl lblTMin;
        private DevExpress.XtraEditors.LabelControl lblFechaTomorrow;
        private DevExpress.XtraEditors.LabelControl lblFechaToday;
        private DevExpress.XtraEditors.PictureEdit PicTomorrow;
        private DevExpress.XtraEditors.PictureEdit picToday;
        private DevExpress.XtraEditors.LabelControl lblTRMax;
        private DevExpress.XtraEditors.LabelControl lblTRMin;
        private DevExpress.XtraEditors.LabelControl lblTMax;
        private DevExpress.Utils.ImageCollection ImageCollectionClima;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.LabelControl lblRegion;
        private System.Windows.Forms.Timer timerClima;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private DevExpress.XtraEditors.LabelControl lblLastRecord;
    }
}
