namespace Meucci.Front.Alerts.Control
{
    partial class Marquee
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gaugeControl1 = new DevExpress.XtraGauges.Win.GaugeControl();
            this.digitalGauge1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.digitalBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            this.lnkInfo = new DevExpress.XtraEditors.HyperLinkEdit();
            this.gaugeControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.digitalGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkInfo.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.BackColor = System.Drawing.Color.Transparent;
            this.gaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl1.Controls.Add(this.lnkInfo);
            this.gaugeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.digitalGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(0, 0);
            this.gaugeControl1.Margin = new System.Windows.Forms.Padding(0);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(715, 62);
            this.gaugeControl1.TabIndex = 0;
            // 
            // digitalGauge1
            // 
            this.digitalGauge1.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#00FFFFFF");
            this.digitalGauge1.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:WhiteSmoke");
            this.digitalGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent[] {
            this.digitalBackgroundLayerComponent1});
            this.digitalGauge1.Bounds = new System.Drawing.Rectangle(6, 6, 703, 50);
            this.digitalGauge1.DigitCount = 5;
            this.digitalGauge1.Name = "digitalGauge1";
            this.digitalGauge1.Text = "00,000";
            // 
            // digitalBackgroundLayerComponent1
            // 
            this.digitalBackgroundLayerComponent1.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(259.8125F, 99.9625F);
            this.digitalBackgroundLayerComponent1.Name = "digitalBackgroundLayerComponent7";
            this.digitalBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style7;
            this.digitalBackgroundLayerComponent1.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(20F, 0F);
            this.digitalBackgroundLayerComponent1.ZOrder = 1000;
            // 
            // lnkInfo
            // 
            this.lnkInfo.EditValue = "+Info";
            this.lnkInfo.Location = new System.Drawing.Point(476, 15);
            this.lnkInfo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lnkInfo.Name = "lnkInfo";
            this.lnkInfo.Properties.AllowFocused = false;
            this.lnkInfo.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lnkInfo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lnkInfo.Properties.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.lnkInfo.Properties.Appearance.Options.UseBackColor = true;
            this.lnkInfo.Properties.Appearance.Options.UseFont = true;
            this.lnkInfo.Properties.Appearance.Options.UseForeColor = true;
            this.lnkInfo.Properties.Appearance.Options.UseTextOptions = true;
            this.lnkInfo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lnkInfo.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Transparent;
            this.lnkInfo.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.lnkInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lnkInfo.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lnkInfo.Size = new System.Drawing.Size(140, 26);
            this.lnkInfo.TabIndex = 0;
            this.lnkInfo.Click += new System.EventHandler(this.lnkInfo_Click);
            // 
            // Marquee
            // 
            this.Appearance.ForeColor = System.Drawing.Color.White;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.gaugeControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Marquee";
            this.Size = new System.Drawing.Size(715, 62);
            this.gaugeControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.digitalGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lnkInfo.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge digitalGauge1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent digitalBackgroundLayerComponent1;
        private DevExpress.XtraEditors.HyperLinkEdit lnkInfo;
    }
}
