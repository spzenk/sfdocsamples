namespace AsimetricSimetricSample
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
            this.txtAsimDesEncriptado = new System.Windows.Forms.TextBox();
            this.btnAsimGenerar = new System.Windows.Forms.Button();
            this.chkSimetrica = new System.Windows.Forms.CheckBox();
            this.txtAsimLlavePublica = new System.Windows.Forms.TextBox();
            this.txtAsimEncriptado = new System.Windows.Forms.TextBox();
            this.txtAsimAEncriptar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAsimDesEncriptar = new System.Windows.Forms.Button();
            this.btnAsimEncriptar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtAsimDesEncriptado
            // 
            this.txtAsimDesEncriptado.Location = new System.Drawing.Point(12, 483);
            this.txtAsimDesEncriptado.Multiline = true;
            this.txtAsimDesEncriptado.Name = "txtAsimDesEncriptado";
            this.txtAsimDesEncriptado.Size = new System.Drawing.Size(436, 108);
            this.txtAsimDesEncriptado.TabIndex = 17;
            // 
            // btnAsimGenerar
            // 
            this.btnAsimGenerar.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAsimGenerar.Location = new System.Drawing.Point(466, 66);
            this.btnAsimGenerar.Name = "btnAsimGenerar";
            this.btnAsimGenerar.Size = new System.Drawing.Size(152, 34);
            this.btnAsimGenerar.TabIndex = 16;
            this.btnAsimGenerar.Text = "Generar Key";
            this.btnAsimGenerar.UseVisualStyleBackColor = true;
            this.btnAsimGenerar.Click += new System.EventHandler(this.btnAsimGenerar_Click);
            // 
            // chkSimetrica
            // 
            this.chkSimetrica.AutoSize = true;
            this.chkSimetrica.Location = new System.Drawing.Point(466, 115);
            this.chkSimetrica.Name = "chkSimetrica";
            this.chkSimetrica.Size = new System.Drawing.Size(117, 21);
            this.chkSimetrica.TabIndex = 15;
            this.chkSimetrica.Text = "Usa Simetrica";
            this.chkSimetrica.UseVisualStyleBackColor = true;
            // 
            // txtAsimLlavePublica
            // 
            this.txtAsimLlavePublica.Location = new System.Drawing.Point(12, 47);
            this.txtAsimLlavePublica.Multiline = true;
            this.txtAsimLlavePublica.Name = "txtAsimLlavePublica";
            this.txtAsimLlavePublica.Size = new System.Drawing.Size(436, 154);
            this.txtAsimLlavePublica.TabIndex = 14;
            // 
            // txtAsimEncriptado
            // 
            this.txtAsimEncriptado.Location = new System.Drawing.Point(12, 393);
            this.txtAsimEncriptado.Multiline = true;
            this.txtAsimEncriptado.Name = "txtAsimEncriptado";
            this.txtAsimEncriptado.Size = new System.Drawing.Size(436, 53);
            this.txtAsimEncriptado.TabIndex = 13;
            // 
            // txtAsimAEncriptar
            // 
            this.txtAsimAEncriptar.Location = new System.Drawing.Point(15, 277);
            this.txtAsimAEncriptar.Multiline = true;
            this.txtAsimAEncriptar.Name = "txtAsimAEncriptar";
            this.txtAsimAEncriptar.Size = new System.Drawing.Size(436, 85);
            this.txtAsimAEncriptar.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Texto a encriptar";
            // 
            // btnAsimDesEncriptar
            // 
            this.btnAsimDesEncriptar.Location = new System.Drawing.Point(550, 307);
            this.btnAsimDesEncriptar.Name = "btnAsimDesEncriptar";
            this.btnAsimDesEncriptar.Size = new System.Drawing.Size(142, 35);
            this.btnAsimDesEncriptar.TabIndex = 10;
            this.btnAsimDesEncriptar.Text = "DesEncriptar";
            this.btnAsimDesEncriptar.UseVisualStyleBackColor = true;
            this.btnAsimDesEncriptar.Click += new System.EventHandler(this.btnAsimDesEncriptar_Click);
            // 
            // btnAsimEncriptar
            // 
            this.btnAsimEncriptar.Location = new System.Drawing.Point(550, 220);
            this.btnAsimEncriptar.Name = "btnAsimEncriptar";
            this.btnAsimEncriptar.Size = new System.Drawing.Size(152, 34);
            this.btnAsimEncriptar.TabIndex = 9;
            this.btnAsimEncriptar.Text = "Encriptar";
            this.btnAsimEncriptar.UseVisualStyleBackColor = true;
            this.btnAsimEncriptar.Click += new System.EventHandler(this.btnAsimEncriptar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Llave publica";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 851);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAsimDesEncriptado);
            this.Controls.Add(this.btnAsimGenerar);
            this.Controls.Add(this.chkSimetrica);
            this.Controls.Add(this.txtAsimLlavePublica);
            this.Controls.Add(this.txtAsimEncriptado);
            this.Controls.Add(this.txtAsimAEncriptar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAsimDesEncriptar);
            this.Controls.Add(this.btnAsimEncriptar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAsimDesEncriptado;
        private System.Windows.Forms.Button btnAsimGenerar;
        private System.Windows.Forms.CheckBox chkSimetrica;
        private System.Windows.Forms.TextBox txtAsimLlavePublica;
        private System.Windows.Forms.TextBox txtAsimEncriptado;
        private System.Windows.Forms.TextBox txtAsimAEncriptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAsimDesEncriptar;
        private System.Windows.Forms.Button btnAsimEncriptar;
        private System.Windows.Forms.Label label2;
    }
}

