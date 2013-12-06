namespace Health.Front.Environment
{
    partial class frmHealthInst_Info
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.lblbRazonSocial = new DevExpress.XtraEditors.LabelControl();
            this.lblDesc = new DevExpress.XtraEditors.LabelControl();
            this.lblTipo = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 441);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(715, 28);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl1.Location = new System.Drawing.Point(46, 70);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(93, 21);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Razon social";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl2.Location = new System.Drawing.Point(46, 303);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 21);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Descripción";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl3.Location = new System.Drawing.Point(46, 131);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(136, 21);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Tipo de institución";
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Location = new System.Drawing.Point(487, 36);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Size = new System.Drawing.Size(153, 116);
            this.pictureEdit1.TabIndex = 4;
            // 
            // lblbRazonSocial
            // 
            this.lblbRazonSocial.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblbRazonSocial.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblbRazonSocial.Location = new System.Drawing.Point(219, 70);
            this.lblbRazonSocial.Name = "lblbRazonSocial";
            this.lblbRazonSocial.Size = new System.Drawing.Size(107, 21);
            this.lblbRazonSocial.TabIndex = 5;
            this.lblbRazonSocial.Text = "Razon social";
            // 
            // lblDesc
            // 
            this.lblDesc.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblDesc.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDesc.Location = new System.Drawing.Point(181, 303);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(93, 21);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Razon social";
            
            // 
            // lblTipo
            // 
            this.lblTipo.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblTipo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTipo.Location = new System.Drawing.Point(219, 131);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(93, 21);
            this.lblTipo.TabIndex = 7;
            this.lblTipo.Text = "Razon social";
            // 
            // frmHealthInst_Info
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 474);
            this.Controls.Add(this.lblTipo);
            this.Controls.Add(this.lblDesc);
            this.Controls.Add(this.lblbRazonSocial);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "frmHealthInst_Info";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Información de la institución";
            this.Load += new System.EventHandler(this.frmHealthInst_Info_Load);
            this.Controls.SetChildIndex(this.labelControl1, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.labelControl2, 0);
            this.Controls.SetChildIndex(this.labelControl3, 0);
            this.Controls.SetChildIndex(this.pictureEdit1, 0);
            this.Controls.SetChildIndex(this.lblbRazonSocial, 0);
            this.Controls.SetChildIndex(this.lblDesc, 0);
            this.Controls.SetChildIndex(this.lblTipo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.LabelControl lblbRazonSocial;
        private DevExpress.XtraEditors.LabelControl lblDesc;
        private DevExpress.XtraEditors.LabelControl lblTipo;
    }
}