namespace Allus.Cnn.Common
{
    partial class MessageCreatorSimple
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
            this.chkRequireConfirm = new DevExpress.XtraEditors.CheckEdit();
            this.imgMessage = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.txtUrl = new DevExpress.XtraEditors.TextEdit();
            this.lblMessage = new System.Windows.Forms.Label();
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMessageText = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.chkRequireConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessageText.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // chkRequireConfirm
            // 
            this.chkRequireConfirm.Location = new System.Drawing.Point(55, 39);
            this.chkRequireConfirm.Name = "chkRequireConfirm";
            this.chkRequireConfirm.Properties.Caption = "Requerir confirmación";
            this.chkRequireConfirm.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkRequireConfirm.Size = new System.Drawing.Size(141, 22);
            this.chkRequireConfirm.TabIndex = 1;
            // 
            // imgMessage
            // 
            this.imgMessage.Image = global::Allus.Cnn.Common.Properties.Resources.web_mail_32;
            this.imgMessage.Location = new System.Drawing.Point(6, 5);
            this.imgMessage.Name = "imgMessage";
            this.imgMessage.Size = new System.Drawing.Size(32, 32);
            this.imgMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgMessage.TabIndex = 28;
            this.imgMessage.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = global::Allus.Cnn.Common.Properties.Resources.web_16;
            this.pictureBox2.Location = new System.Drawing.Point(9, 279);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(34, 279);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(228, 20);
            this.txtUrl.TabIndex = 3;
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(3, 61);
            this.lblMessage.Margin = new System.Windows.Forms.Padding(0);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(47, 13);
            this.lblMessage.TabIndex = 29;
            this.lblMessage.Text = "Mensaje";
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTitle.Location = new System.Drawing.Point(54, 17);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(208, 20);
            this.txtTitle.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(56, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "Asunto";
            // 
            // txtMessageText
            // 
            this.txtMessageText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessageText.EditValue = "";
            this.txtMessageText.Location = new System.Drawing.Point(6, 78);
            this.txtMessageText.Name = "txtMessageText";
            this.txtMessageText.Properties.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.txtMessageText.Properties.Appearance.Options.UseForeColor = true;
            this.txtMessageText.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.White;
            this.txtMessageText.Properties.AppearanceReadOnly.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtMessageText.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.txtMessageText.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtMessageText.Properties.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText;
            this.txtMessageText.Size = new System.Drawing.Size(256, 196);
            this.txtMessageText.TabIndex = 2;
            // 
            // MessageCreatorSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkRequireConfirm);
            this.Controls.Add(this.imgMessage);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtMessageText);
            this.MinimumSize = new System.Drawing.Size(200, 308);
            this.Name = "MessageCreatorSimple";
            this.Size = new System.Drawing.Size(268, 308);
            ((System.ComponentModel.ISupportInitialize)(this.chkRequireConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessageText.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkRequireConfirm;
        private System.Windows.Forms.PictureBox imgMessage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.TextEdit txtUrl;
        private System.Windows.Forms.Label lblMessage;
        private DevExpress.XtraEditors.TextEdit txtTitle;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtMessageText;
    }
}
