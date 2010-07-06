namespace Allus.Cnn.Common
{
    partial class frmAgentNotify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAgentNotify));
            this.Image = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.Image.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // Image
            // 
            this.Image.EditValue = global::Allus.Cnn.Common.Properties.Resources.web_mail_back_32;
            this.Image.Location = new System.Drawing.Point(1, 12);
            this.Image.Name = "Image";
            this.Image.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Image.Size = new System.Drawing.Size(77, 59);
            this.Image.TabIndex = 0;
            // 
            // frmAgentNotify
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.BackColor2 = System.Drawing.Color.Gray;
            this.Appearance.BorderColor = System.Drawing.Color.Black;
            this.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseBorderColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 176);
            this.Controls.Add(this.Image);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAgentNotify";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmAgentNotify_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Image.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit Image;
    }
}