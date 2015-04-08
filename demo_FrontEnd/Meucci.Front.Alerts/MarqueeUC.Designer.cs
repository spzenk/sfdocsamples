namespace Meucci.Front.Alerts
{
    partial class MarqueeUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MarqueeUC));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeMenuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.marquee1 = new Meucci.Front.Alerts.Control.Marquee();
            ((System.ComponentModel.ISupportInitialize)(this.treeMenuBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "help.png");
            this.imageList1.Images.SetKeyName(1, "remove-window.png");
            this.imageList1.Images.SetKeyName(2, "write.png");
            this.imageList1.Images.SetKeyName(3, "Antivirus-icon_24.png");
            this.imageList1.Images.SetKeyName(4, "blood_32.png");
            this.imageList1.Images.SetKeyName(5, "laboratorio_32.png");
            this.imageList1.Images.SetKeyName(6, "heart-icon_48.png");
            this.imageList1.Images.SetKeyName(7, "nurse-icon.png");
            this.imageList1.Images.SetKeyName(8, "heart-blood-icon_32.png");
            this.imageList1.Images.SetKeyName(9, "CruzRoja.png");
            this.imageList1.Images.SetKeyName(10, "Ball (Green).png");
            this.imageList1.Images.SetKeyName(11, "Ball (Yellow).png");
            this.imageList1.Images.SetKeyName(12, "Chart.png");
            this.imageList1.Images.SetKeyName(13, "docs_24.ico");
            this.imageList1.Images.SetKeyName(14, "edit_24.ico");
            this.imageList1.Images.SetKeyName(15, "fax_24.ico");
            this.imageList1.Images.SetKeyName(16, "hist_24.ico");
            this.imageList1.Images.SetKeyName(17, "image_24.ico");
            this.imageList1.Images.SetKeyName(18, "prefs_24.ico");
            this.imageList1.Images.SetKeyName(19, "confg_24.ico");
            this.imageList1.Images.SetKeyName(20, "create_contact (2).png");
            this.imageList1.Images.SetKeyName(21, "ic_btn_search (2).png");
            this.imageList1.Images.SetKeyName(22, "ic_emergency (2).png");
            this.imageList1.Images.SetKeyName(23, "ic_maps_indicator_current_position_anim1 (2).png");
            this.imageList1.Images.SetKeyName(24, "stat_sys_signal_2 (2).png");
            // 
            // treeMenuBindingSource
            // 
            this.treeMenuBindingSource.DataSource = typeof(Fwk.UI.Controls.Menu.Tree.TreeMenu);
            // 
            // marquee1
            // 
            this.marquee1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.marquee1.Appearance.ForeColor = System.Drawing.Color.White;
            this.marquee1.Appearance.Options.UseBackColor = true;
            this.marquee1.Appearance.Options.UseForeColor = true;
            this.marquee1.AutoSize = true;
            this.marquee1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marquee1.Link = null;
            this.marquee1.LinkText = "https://www.facebook.com/epironallus";
            this.marquee1.Location = new System.Drawing.Point(0, 0);
            this.marquee1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.marquee1.Name = "marquee1";
            this.marquee1.Shape = DevExpress.XtraGauges.Core.Model.DigitalBackgroundShapeSetType.Style8;
            this.marquee1.Size = new System.Drawing.Size(927, 110);
            this.marquee1.Speed = 0;
            this.marquee1.TabIndex = 6;
            this.marquee1.TextDirection = Meucci.Front.Alerts.Control.Direction.Right;
            this.marquee1.TextToShow = "Allus Global BPO Center es la compañía lider en America Latina en la provision de" +
    " soluciones BPO inteligentes. BPO Services y Call center en Colombia y ...";
            this.marquee1.TimeToShow = 12;
            // 
            // Marquee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.marquee1);
            this.Name = "Marquee";
            this.PanelContainer = Epiron.Front.Bases.PanelEnum.LeftPanel_1;
            this.Size = new System.Drawing.Size(927, 110);
            ((System.ComponentModel.ISupportInitialize)(this.treeMenuBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource treeMenuBindingSource;
        private System.Windows.Forms.ImageList imageList1;
        private Meucci.Front.Alerts.Control.Marquee marquee1;
    }
}
