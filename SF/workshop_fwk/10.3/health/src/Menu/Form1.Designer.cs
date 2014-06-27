namespace WindowsFormsApplication1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(3, 97);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(277, 60);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Editar menu de atencion de paciente";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 255);
            this.Controls.Add(this.simpleButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.ImageList imageList1;
    }
}

