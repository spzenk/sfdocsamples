namespace Allus.Cnn.Admin
{
    partial class Mesh
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mesh));
            this.messageCreatorContainer1 = new Allus.Cnn.Common.MessageCreatorContainer();
            this.colaboratorsAdminGrid1 = new Allus.Cnn.Admin.ColaboratorsAdminGrid();
            this.btnFinalizeMesh = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // messageCreatorContainer1
            // 
            this.messageCreatorContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageCreatorContainer1.Location = new System.Drawing.Point(0, 0);
            this.messageCreatorContainer1.MeshName = null;
            this.messageCreatorContainer1.MinimumSize = new System.Drawing.Size(623, 503);
            this.messageCreatorContainer1.Name = "messageCreatorContainer1";
            this.messageCreatorContainer1.Size = new System.Drawing.Size(639, 651);
            this.messageCreatorContainer1.TabIndex = 0;
            this.messageCreatorContainer1.SendMessageEvent += new System.EventHandler(this.messageCreatorContainer1_SendMessageEvent);
            // 
            // colaboratorsAdminGrid1
            // 
            this.colaboratorsAdminGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.colaboratorsAdminGrid1.Location = new System.Drawing.Point(3, 30);
            this.colaboratorsAdminGrid1.Name = "colaboratorsAdminGrid1";
            this.colaboratorsAdminGrid1.Size = new System.Drawing.Size(352, 618);
            this.colaboratorsAdminGrid1.TabIndex = 18;
            this.colaboratorsAdminGrid1.RefreshColaboratorEvent += new System.EventHandler(this.colaboratorsAdminGrid1_RefreshColaboratorEvent);
            // 
            // btnFinalizeMesh
            // 
            this.btnFinalizeMesh.Image = global::Allus.Cnn.Admin.Properties.Resources.close_16;
            this.btnFinalizeMesh.Location = new System.Drawing.Point(3, 1);
            this.btnFinalizeMesh.Name = "btnFinalizeMesh";
            this.btnFinalizeMesh.Size = new System.Drawing.Size(105, 23);
            this.btnFinalizeMesh.TabIndex = 19;
            this.btnFinalizeMesh.Text = "Finalizar Sala";
            this.btnFinalizeMesh.Click += new System.EventHandler(this.btnFinalizeMesh_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::Allus.Cnn.Admin.Properties.Resources.zoom_out_16;
            this.simpleButton1.Location = new System.Drawing.Point(111, 1);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(105, 23);
            this.simpleButton1.TabIndex = 20;
            this.simpleButton1.Text = "Ocultar Sala";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.MinimumSize = new System.Drawing.Size(1003, 641);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(241)))), ((int)(((byte)(254)))));
            this.splitContainer1.Panel1.Controls.Add(this.simpleButton1);
            this.splitContainer1.Panel1.Controls.Add(this.btnFinalizeMesh);
            this.splitContainer1.Panel1.Controls.Add(this.colaboratorsAdminGrid1);
            this.splitContainer1.Panel1MinSize = 300;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.messageCreatorContainer1);
            this.splitContainer1.Size = new System.Drawing.Size(1007, 655);
            this.splitContainer1.SplitterDistance = 363;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 27;
            // 
            // Mesh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 655);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.MinimumSize = new System.Drawing.Size(1015, 689);
            this.Name = "Mesh";
            this.ShowIcon = true;
            this.Text = "Mesh";
            this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Allus.Cnn.Common.MessageCreatorContainer messageCreatorContainer1;
        private ColaboratorsAdminGrid colaboratorsAdminGrid1;
        private DevExpress.XtraEditors.SimpleButton btnFinalizeMesh;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.SplitContainer splitContainer1;

    }
}