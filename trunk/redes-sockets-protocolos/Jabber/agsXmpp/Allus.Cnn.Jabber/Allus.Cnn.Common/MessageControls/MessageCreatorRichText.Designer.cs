namespace Allus.Cnn.Common
{
    partial class MessageCreatorRichText
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
            this.txtTitle = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.richEditSimpleControl1 = new Allus.Libs.Controls.RrichEditBarMannagerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.chkRequireConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkRequireConfirm
            // 
            this.chkRequireConfirm.Location = new System.Drawing.Point(364, 17);
            this.chkRequireConfirm.Name = "chkRequireConfirm";
            this.chkRequireConfirm.Properties.Caption = "Requerir confirmaci�n";
            this.chkRequireConfirm.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chkRequireConfirm.Size = new System.Drawing.Size(141, 22);
            this.chkRequireConfirm.TabIndex = 39;
            // 
            // imgMessage
            // 
            this.imgMessage.Image = global::Allus.Cnn.Common.Properties.Resources.web_mail_32;
            this.imgMessage.Location = new System.Drawing.Point(3, 3);
            this.imgMessage.Name = "imgMessage";
            this.imgMessage.Size = new System.Drawing.Size(32, 32);
            this.imgMessage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgMessage.TabIndex = 35;
            this.imgMessage.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.Image = global::Allus.Cnn.Common.Properties.Resources.web_16;
            this.pictureBox2.Location = new System.Drawing.Point(4, 499);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(16, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 34;
            this.pictureBox2.TabStop = false;
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUrl.Location = new System.Drawing.Point(29, 499);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(360, 20);
            this.txtUrl.TabIndex = 37;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(63, 17);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(249, 20);
            this.txtTitle.TabIndex = 38;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.SteelBlue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(63, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(40, 13);
            this.labelControl1.TabIndex = 33;
            this.labelControl1.Text = "Asunto";
            // 
            // richEditSimpleControl1
            // 
            this.richEditSimpleControl1.AutoScroll = true;
            this.richEditSimpleControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richEditSimpleControl1.Location = new System.Drawing.Point(3, 3);
            this.richEditSimpleControl1.Name = "richEditSimpleControl1";
            this.richEditSimpleControl1.RtfText = "{\\rtf1\\deff0{\\fonttbl{\\f0 Times New Roman;}}{\\colortbl\\red0\\green0\\blue0 ;}{\\*\\li" +
                "stoverridetable}{\\stylesheet {\\ql\\cf0 Normal;}{\\*\\cs1\\cf0 Default Paragraph Font" +
                ";}}{\\sectd\\pard\\plain\\ql\\par}}";
            this.richEditSimpleControl1.Size = new System.Drawing.Size(483, 430);
            this.richEditSimpleControl1.TabIndex = 40;
            this.richEditSimpleControl1.Load += new System.EventHandler(this.richEditSimpleControl1_Load);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.richEditSimpleControl1);
            this.panelControl1.Location = new System.Drawing.Point(3, 57);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(489, 436);
            this.panelControl1.TabIndex = 41;
            // 
            // MessageCreatorRichText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.chkRequireConfirm);
            this.Controls.Add(this.imgMessage);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.labelControl1);
            this.MinimumSize = new System.Drawing.Size(495, 338);
            this.Name = "MessageCreatorRichText";
            this.Size = new System.Drawing.Size(495, 527);
            ((System.ComponentModel.ISupportInitialize)(this.chkRequireConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUrl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTitle.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckEdit chkRequireConfirm;
        private System.Windows.Forms.PictureBox imgMessage;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.TextEdit txtUrl;
        private DevExpress.XtraEditors.TextEdit txtTitle;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Allus.Libs.Controls.RrichEditBarMannagerControl richEditSimpleControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}
