namespace Asymetric_1.Client
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtNoCifrado = new System.Windows.Forms.TextBox();
            this.btnDEncrypt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCifrado = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(79, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Valor inicial";
            // 
            // txtNoCifrado
            // 
            this.txtNoCifrado.AcceptsReturn = true;
            this.txtNoCifrado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNoCifrado.Location = new System.Drawing.Point(70, 258);
            this.txtNoCifrado.Multiline = true;
            this.txtNoCifrado.Name = "txtNoCifrado";
            this.txtNoCifrado.Size = new System.Drawing.Size(421, 97);
            this.txtNoCifrado.TabIndex = 11;
            // 
            // btnDEncrypt
            // 
            this.btnDEncrypt.Location = new System.Drawing.Point(118, 386);
            this.btnDEncrypt.Name = "btnDEncrypt";
            this.btnDEncrypt.Size = new System.Drawing.Size(81, 41);
            this.btnDEncrypt.TabIndex = 10;
            this.btnDEncrypt.Text = "Desencriptar";
            this.btnDEncrypt.UseVisualStyleBackColor = true;
            this.btnDEncrypt.Click += new System.EventHandler(this.btnDEncrypt_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Valor encriptado";
            // 
            // txtCifrado
            // 
            this.txtCifrado.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCifrado.Location = new System.Drawing.Point(70, 69);
            this.txtCifrado.Multiline = true;
            this.txtCifrado.Name = "txtCifrado";
            this.txtCifrado.ReadOnly = true;
            this.txtCifrado.Size = new System.Drawing.Size(421, 158);
            this.txtCifrado.TabIndex = 8;
            this.txtCifrado.Text = "CqtkVdUZ1hBH6+sk+wVHW5jXyTxqn7B3tqhl9WaGi/lnHpKMdqYsnEyGu4saxcSCr1h2pIXsqmUiIZhtr" +
                "p+X/weLcIeid/x380ioxFRefQ7uwnPtBcXh/9JQljUQnDj+t/F8SYKtSS/oVAksplTiTUdST3v9dpo25" +
                "N/WBEVtU5U=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 518);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNoCifrado);
            this.Controls.Add(this.btnDEncrypt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCifrado);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNoCifrado;
        private System.Windows.Forms.Button btnDEncrypt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCifrado;
    }
}

