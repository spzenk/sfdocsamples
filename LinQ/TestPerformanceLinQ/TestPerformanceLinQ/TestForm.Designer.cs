namespace TestPerformanceLinQ
{
    partial class TestForm
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
            this.components = new System.ComponentModel.Container();
            this.Objects = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExecute = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblRecordsCount = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewMuestras = new System.Windows.Forms.DataGridView();
            this.muestrasTimeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.totalMillisecondsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Objects.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMuestras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.muestrasTimeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Objects
            // 
            this.Objects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Objects.Controls.Add(this.tabPage1);
            this.Objects.Controls.Add(this.tabPage2);
            this.Objects.Location = new System.Drawing.Point(2, 33);
            this.Objects.Name = "Objects";
            this.Objects.SelectedIndex = 0;
            this.Objects.Size = new System.Drawing.Size(730, 414);
            this.Objects.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(722, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "LinQ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(716, 382);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(722, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Custom Objects";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExecute.Location = new System.Drawing.Point(6, 453);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(89, 33);
            this.btnExecute.TabIndex = 2;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Duracion (millesecons)";
            // 
            // lblDuracion
            // 
            this.lblDuracion.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblDuracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDuracion.Location = new System.Drawing.Point(133, 5);
            this.lblDuracion.Name = "lblDuracion";
            this.lblDuracion.Size = new System.Drawing.Size(139, 21);
            this.lblDuracion.TabIndex = 1;
            this.lblDuracion.Text = "0";
            this.lblDuracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Records count";
            // 
            // lblRecordsCount
            // 
            this.lblRecordsCount.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRecordsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRecordsCount.Location = new System.Drawing.Point(380, 9);
            this.lblRecordsCount.Name = "lblRecordsCount";
            this.lblRecordsCount.Size = new System.Drawing.Size(89, 21);
            this.lblRecordsCount.TabIndex = 4;
            this.lblRecordsCount.Text = "0";
            this.lblRecordsCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(524, 11);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(86, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(485, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cicles";
            // 
            // dataGridViewMuestras
            // 
            this.dataGridViewMuestras.AutoGenerateColumns = false;
            this.dataGridViewMuestras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMuestras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.totalMillisecondsDataGridViewTextBoxColumn});
            this.dataGridViewMuestras.DataSource = this.muestrasTimeBindingSource;
            this.dataGridViewMuestras.Location = new System.Drawing.Point(750, 55);
            this.dataGridViewMuestras.Name = "dataGridViewMuestras";
            this.dataGridViewMuestras.Size = new System.Drawing.Size(232, 385);
            this.dataGridViewMuestras.TabIndex = 7;
            // 
            // muestrasTimeBindingSource
            // 
            this.muestrasTimeBindingSource.DataSource = typeof(TestPerformanceLinQ.TestForm.MuestrasTime);
            // 
            // totalMillisecondsDataGridViewTextBoxColumn
            // 
            this.totalMillisecondsDataGridViewTextBoxColumn.DataPropertyName = "TotalMilliseconds";
            this.totalMillisecondsDataGridViewTextBoxColumn.HeaderText = "TotalMilliseconds";
            this.totalMillisecondsDataGridViewTextBoxColumn.Name = "totalMillisecondsDataGridViewTextBoxColumn";
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 498);
            this.Controls.Add(this.dataGridViewMuestras);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblRecordsCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblDuracion);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.Objects);
            this.Name = "TestForm";
            this.Text = "Form1";
            this.Objects.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMuestras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.muestrasTimeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl Objects;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblRecordsCount;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewMuestras;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalMillisecondsDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource muestrasTimeBindingSource;
    }
}

