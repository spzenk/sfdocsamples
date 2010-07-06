namespace Allus.Cnn.Common
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
            this.lnkInfo = new DevExpress.XtraEditors.HyperLinkEdit();
            this.digitalGauge1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge();
            this.digitalBackgroundLayerComponent1 = new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent();
            this.labelComponent1 = new DevExpress.XtraGauges.Win.Base.LabelComponent();
            this.gaugeControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lnkInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalGauge1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gaugeControl1
            // 
            this.gaugeControl1.AutoLayout = false;
            this.gaugeControl1.BackColor = System.Drawing.Color.Transparent;
            this.gaugeControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.gaugeControl1.Controls.Add(this.lnkInfo);
            this.gaugeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gaugeControl1.Gauges.AddRange(new DevExpress.XtraGauges.Base.IGauge[] {
            this.digitalGauge1});
            this.gaugeControl1.Location = new System.Drawing.Point(0, 0);
            this.gaugeControl1.Margin = new System.Windows.Forms.Padding(0);
            this.gaugeControl1.Name = "gaugeControl1";
            this.gaugeControl1.Size = new System.Drawing.Size(615, 50);
            this.gaugeControl1.TabIndex = 0;
            // 
            // lnkInfo
            // 
            this.lnkInfo.EditValue = "+Info";
            this.lnkInfo.Location = new System.Drawing.Point(484, 23);
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
            this.lnkInfo.Size = new System.Drawing.Size(120, 21);
            this.lnkInfo.TabIndex = 0;
            this.lnkInfo.Click += new System.EventHandler(this.lnkInfo_Click);
            // 
            // digitalGauge1
            // 
            this.digitalGauge1.AppearanceOff.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:#00FFFFFF");
            this.digitalGauge1.AppearanceOn.ContentBrush = new DevExpress.XtraGauges.Core.Drawing.SolidBrushObject("Color:Yellow");
            this.digitalGauge1.BackgroundLayers.AddRange(new DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent[] {
            this.digitalBackgroundLayerComponent1});
            this.digitalGauge1.Bounds = new System.Drawing.Rectangle(6, 6, 607, 41);
            this.digitalGauge1.DigitCount = 30;
            this.digitalGauge1.Labels.AddRange(new DevExpress.XtraGauges.Win.Base.LabelComponent[] {
            this.labelComponent1});
            this.digitalGauge1.Name = "digitalGauge1";
            this.digitalGauge1.Text = "";
            // 
            // digitalBackgroundLayerComponent1
            // 
            this.digitalBackgroundLayerComponent1.BottomRight = new DevExpress.XtraGauges.Core.Base.PointF2D(1458.875F, 99.9625F);
            this.digitalBackgroundLayerComponent1.Name = "digitalBackgroundLayerComponent1";
            this.digitalBackgroundLayerComponent1.ShapeType = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style7;
            this.digitalBackgroundLayerComponent1.TopLeft = new DevExpress.XtraGauges.Core.Base.PointF2D(20F, 0F);
            // 
            // labelComponent1
            // 
            this.labelComponent1.Name = "labelComponent1";
            this.labelComponent1.Text = "AllusCnn";
            // 
            // Marquee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.gaugeControl1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Marquee";
            this.Size = new System.Drawing.Size(615, 50);
            this.gaugeControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lnkInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalGauge1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digitalBackgroundLayerComponent1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelComponent1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraGauges.Win.GaugeControl gaugeControl1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalBackgroundLayerComponent digitalBackgroundLayerComponent1;
        private DevExpress.XtraGauges.Win.Gauges.Digital.DigitalGauge digitalGauge1;
        private DevExpress.XtraGauges.Win.Base.LabelComponent labelComponent1;
        private DevExpress.XtraEditors.HyperLinkEdit lnkInfo;
    }
}
