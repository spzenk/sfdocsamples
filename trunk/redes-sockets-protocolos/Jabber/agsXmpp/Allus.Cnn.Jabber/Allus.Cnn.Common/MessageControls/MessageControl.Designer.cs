namespace Allus.Cnn.Common
{
    partial class ClientMessageControl
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
            this.hyperLink = new DevExpress.XtraEditors.HyperLinkEdit();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblDate = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMessage = new DevExpress.XtraRichEdit.RichEditControl();
            this.imgMessage = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.imgMessageChecked = new System.Windows.Forms.PictureBox();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.hyperLink.Properties)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMessageChecked)).BeginInit();
            this.SuspendLayout();
            // 
            // hyperLink
            // 
            this.hyperLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hyperLink.EditValue = "www.gmail.com";
            this.hyperLink.Location = new System.Drawing.Point(37, 622);
            this.hyperLink.Name = "hyperLink";
            this.hyperLink.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Transparent;
            this.hyperLink.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.hyperLink.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hyperLink.Size = new System.Drawing.Size(881, 18);
            this.hyperLink.TabIndex = 5;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(69, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(40, 13);
            this.lblTitle.TabIndex = 6;
            this.lblTitle.Text = "Asunto";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDate.Appearance.ForeColor = System.Drawing.Color.SlateGray;
            this.lblDate.Appearance.Options.UseForeColor = true;
            this.lblDate.Location = new System.Drawing.Point(37, 653);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(27, 13);
            this.lblDate.TabIndex = 7;
            this.lblDate.Text = "fecha";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMessage);
            this.groupBox1.Controls.Add(this.imgMessage);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.imgMessageChecked);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.lblTitle);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.hyperLink);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(940, 672);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Leave += new System.EventHandler(this.groupBox1_Leave);
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // txtMessage
            // 
            this.txtMessage.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Simple;
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Location = new System.Drawing.Point(15, 58);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(920, 561);
            this.txtMessage.TabIndex = 17;
            this.txtMessage.Text = "richEditControl1";
            this.txtMessage.Views.SimpleView.Padding = new System.Windows.Forms.Padding(20, 25, 20, 25);
            // 
            // imgMessage
            // 
            this.imgMessage.Image = global::Allus.Cnn.Common.Properties.Resources.web_mail_32;
            this.imgMessage.Location = new System.Drawing.Point(15, 20);
            this.imgMessage.Name = "imgMessage";
            this.imgMessage.Size = new System.Drawing.Size(32, 32);
            this.imgMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgMessage.TabIndex = 16;
            this.imgMessage.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox3.Image = global::Allus.Cnn.Common.Properties.Resources.cal_16;
            this.pictureBox3.Location = new System.Drawing.Point(15, 650);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(16, 16);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = global::Allus.Cnn.Common.Properties.Resources.web_16;
            this.pictureBox2.Location = new System.Drawing.Point(15, 624);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            // 
            // imgMessageChecked
            // 
            this.imgMessageChecked.Image = global::Allus.Cnn.Common.Properties.Resources.confirm_16;
            this.imgMessageChecked.Location = new System.Drawing.Point(0, 0);
            this.imgMessageChecked.Name = "imgMessageChecked";
            this.imgMessageChecked.Size = new System.Drawing.Size(16, 16);
            this.imgMessageChecked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgMessageChecked.TabIndex = 12;
            this.imgMessageChecked.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Appearance.BackColor = System.Drawing.Color.White;
            this.btnClose.Appearance.BackColor2 = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseBackColor = true;
            this.btnClose.BackgroundImage = global::Allus.Cnn.Common.Properties.Resources.close_16;
            this.btnClose.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.btnClose.Image = global::Allus.Cnn.Common.Properties.Resources.close_16;
            this.btnClose.Location = new System.Drawing.Point(907, 0);
            this.btnClose.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 18);
            this.btnClose.TabIndex = 0;
            this.btnClose.ToolTip = "Cerrar este menseje";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ClientMessageControl
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "ClientMessageControl";
            this.Size = new System.Drawing.Size(940, 672);
            this.Load += new System.EventHandler(this.MessageControl_Load);
            this.Leave += new System.EventHandler(this.ClientMessageControl_Leave);
            this.Enter += new System.EventHandler(this.ClientMessageControl_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.hyperLink.Properties)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMessageChecked)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.HyperLinkEdit hyperLink;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblDate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox imgMessageChecked;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox imgMessage;
        private DevExpress.XtraRichEdit.RichEditControl txtMessage;
    }
}
