namespace Health.Front.Scheduler
{
    partial class uc_shedule_profecional_timeline
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
            this.lblProfesional = new System.Windows.Forms.Label();
            this.lblFechaSeleccionada = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnViewResourceScheduling = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDAysWeek = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.lblEspesialidad = new System.Windows.Forms.Label();
            this.uc_ShiftsControls1 = new Health.Front.Scheduler.uc_ShiftsControls();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.BackColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Size = new System.Drawing.Size(876, 38);
            this.lblTitle.Text = "                              Asignación de turnos";
            // 
            // lblProfesional
            // 
            this.lblProfesional.AutoSize = true;
            this.lblProfesional.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblProfesional.ForeColor = System.Drawing.Color.Brown;
            this.lblProfesional.Location = new System.Drawing.Point(5, 10);
            this.lblProfesional.Name = "lblProfesional";
            this.lblProfesional.Size = new System.Drawing.Size(48, 17);
            this.lblProfesional.TabIndex = 20;
            this.lblProfesional.Text = "label1";
            // 
            // lblFechaSeleccionada
            // 
            this.lblFechaSeleccionada.AutoSize = true;
            this.lblFechaSeleccionada.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblFechaSeleccionada.ForeColor = System.Drawing.Color.DimGray;
            this.lblFechaSeleccionada.Location = new System.Drawing.Point(39, 126);
            this.lblFechaSeleccionada.Name = "lblFechaSeleccionada";
            this.lblFechaSeleccionada.Size = new System.Drawing.Size(48, 17);
            this.lblFechaSeleccionada.TabIndex = 21;
            this.lblFechaSeleccionada.Text = "label1";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Health.Front.Properties.Resources.calendar;
            this.pictureBox2.Location = new System.Drawing.Point(9, 119);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
            // 
            // btnViewResourceScheduling
            // 
            this.btnViewResourceScheduling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnViewResourceScheduling.Image = global::Health.Front.Properties.Resources.vcard_32;
            this.btnViewResourceScheduling.Location = new System.Drawing.Point(614, 9);
            this.btnViewResourceScheduling.Name = "btnViewResourceScheduling";
            this.btnViewResourceScheduling.Size = new System.Drawing.Size(140, 35);
            this.btnViewResourceScheduling.TabIndex = 24;
            this.btnViewResourceScheduling.Text = "Ver mas";
            this.btnViewResourceScheduling.Click += new System.EventHandler(this.btnViewResourceScheduling_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(292, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Dias disponibles";
            // 
            // lblDAysWeek
            // 
            this.lblDAysWeek.AutoSize = true;
            this.lblDAysWeek.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblDAysWeek.Location = new System.Drawing.Point(292, 35);
            this.lblDAysWeek.Name = "lblDAysWeek";
            this.lblDAysWeek.Size = new System.Drawing.Size(102, 17);
            this.lblDAysWeek.TabIndex = 26;
            this.lblDAysWeek.Text = "Dias disponibles";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.lblEspesialidad);
            this.groupControl1.Controls.Add(this.lblDAysWeek);
            this.groupControl1.Controls.Add(this.btnViewResourceScheduling);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.lblProfesional);
            this.groupControl1.Location = new System.Drawing.Point(103, 45);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(770, 72);
            this.groupControl1.TabIndex = 27;
            // 
            // lblEspesialidad
            // 
            this.lblEspesialidad.AutoSize = true;
            this.lblEspesialidad.Font = new System.Drawing.Font("Tahoma", 7.8F);
            this.lblEspesialidad.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblEspesialidad.Location = new System.Drawing.Point(9, 44);
            this.lblEspesialidad.Name = "lblEspesialidad";
            this.lblEspesialidad.Size = new System.Drawing.Size(42, 17);
            this.lblEspesialidad.TabIndex = 27;
            this.lblEspesialidad.Text = "label1";
            // 
            // uc_ShiftsControls1
            // 
            this.uc_ShiftsControls1.AcceptButton = null;
            this.uc_ShiftsControls1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uc_ShiftsControls1.CancelButton = null;
            this.uc_ShiftsControls1.Key = null;
            this.uc_ShiftsControls1.Location = new System.Drawing.Point(8, 152);
            this.uc_ShiftsControls1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uc_ShiftsControls1.Name = "uc_ShiftsControls1";
            this.uc_ShiftsControls1.ShowClose = false;
            this.uc_ShiftsControls1.Size = new System.Drawing.Size(860, 443);
            this.uc_ShiftsControls1.TabIndex = 6;
            this.uc_ShiftsControls1.ShiftsDoubleClick += new System.EventHandler(this.uc_ShiftsControls1_ShiftsDoubleClick);
            this.uc_ShiftsControls1.OnCreateAppoimentsEvent += new System.EventHandler(this.uc_ShiftsControls1_OnCreateAppoimentsEvent);
            this.uc_ShiftsControls1.OnChangeStatusEvent += new System.EventHandler(this.uc_ShiftsControls1_OnChangeStatusEvent);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::Health.Front.Properties.Resources.User_M;
            this.pictureEdit1.Enabled = false;
            this.pictureEdit1.Location = new System.Drawing.Point(3, 21);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Size = new System.Drawing.Size(103, 96);
            this.pictureEdit1.TabIndex = 28;
            // 
            // uc_shedule_profecional_timeline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lblFechaSeleccionada);
            this.Controls.Add(this.uc_ShiftsControls1);
            this.Name = "uc_shedule_profecional_timeline";
            this.Size = new System.Drawing.Size(876, 598);
            this.Controls.SetChildIndex(this.uc_ShiftsControls1, 0);
            this.Controls.SetChildIndex(this.lblFechaSeleccionada, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.pictureEdit1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProfesional;
        private System.Windows.Forms.Label lblFechaSeleccionada;
        private System.Windows.Forms.PictureBox pictureBox2;
        private DevExpress.XtraEditors.SimpleButton btnViewResourceScheduling;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDAysWeek;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label lblEspesialidad;
        private uc_ShiftsControls uc_ShiftsControls1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;

    }
}
