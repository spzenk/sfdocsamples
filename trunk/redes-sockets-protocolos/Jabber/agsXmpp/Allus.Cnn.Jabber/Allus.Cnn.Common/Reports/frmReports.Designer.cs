namespace Allus.Cnn.Common.Reports
{
    partial class frmReports
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
            this.btnLeidos = new DevExpress.XtraEditors.SimpleButton();
            this.btnConfirmados = new DevExpress.XtraEditors.SimpleButton();
            this.messageGridFind1 = new Allus.Cnn.Common.MessageGridFind();
            this.uC_GridMessageStatus1 = new Allus.Cnn.Common.UC_GridMessageStatus();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLeidos
            // 
            this.btnLeidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnLeidos.AutoSizeInLayoutControl = false;
            this.btnLeidos.Location = new System.Drawing.Point(150, 3);
            this.btnLeidos.MaximumSize = new System.Drawing.Size(70, 23);
            this.btnLeidos.MinimumSize = new System.Drawing.Size(70, 23);
            this.btnLeidos.Name = "btnLeidos";
            this.btnLeidos.Size = new System.Drawing.Size(70, 23);
            this.btnLeidos.TabIndex = 2;
            this.btnLeidos.Text = "Leidos";
            this.btnLeidos.Click += new System.EventHandler(this.btnLeidos_Click);
            // 
            // btnConfirmados
            // 
            this.btnConfirmados.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnConfirmados.AutoSizeInLayoutControl = false;
            this.btnConfirmados.Location = new System.Drawing.Point(236, 3);
            this.btnConfirmados.MaximumSize = new System.Drawing.Size(70, 23);
            this.btnConfirmados.MinimumSize = new System.Drawing.Size(70, 23);
            this.btnConfirmados.Name = "btnConfirmados";
            this.btnConfirmados.Size = new System.Drawing.Size(70, 23);
            this.btnConfirmados.TabIndex = 3;
            this.btnConfirmados.Text = "Confirmados";
            this.btnConfirmados.Click += new System.EventHandler(this.btnConfirmados_Click);
            // 
            // messageGridFind1
            // 
            this.messageGridFind1.CurrentMessage = null;
            this.messageGridFind1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageGridFind1.Location = new System.Drawing.Point(0, 0);
            this.messageGridFind1.Name = "messageGridFind1";
            this.messageGridFind1.Size = new System.Drawing.Size(367, 654);
            this.messageGridFind1.TabIndex = 6;
            this.messageGridFind1.OnGridClick += new System.EventHandler(this.messageGridFind1_OnGridClick);
            // 
            // uC_GridMessageStatus1
            // 
            this.uC_GridMessageStatus1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uC_GridMessageStatus1.Location = new System.Drawing.Point(8, 356);
            this.uC_GridMessageStatus1.Name = "uC_GridMessageStatus1";
            this.uC_GridMessageStatus1.Size = new System.Drawing.Size(415, 298);
            this.uC_GridMessageStatus1.TabIndex = 7;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.messageGridFind1);
            this.splitContainerControl1.Panel1.MinSize = 300;
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.btnConfirmados);
            this.splitContainerControl1.Panel2.Controls.Add(this.btnLeidos);
            this.splitContainerControl1.Panel2.Controls.Add(this.panelControl1);
            this.splitContainerControl1.Panel2.Controls.Add(this.uC_GridMessageStatus1);
            this.splitContainerControl1.Panel2.MinSize = 300;
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(799, 654);
            this.splitContainerControl1.SplitterPosition = 367;
            this.splitContainerControl1.TabIndex = 8;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.Location = new System.Drawing.Point(8, 32);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(415, 318);
            this.panelControl1.TabIndex = 1;
            // 
            // frmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(799, 654);
            this.Controls.Add(this.splitContainerControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "frmReports";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Reportes";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.Load += new System.EventHandler(this.frmReports_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnLeidos;
        private DevExpress.XtraEditors.SimpleButton btnConfirmados;
        private MessageGridFind messageGridFind1;
        private UC_GridMessageStatus uC_GridMessageStatus1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}