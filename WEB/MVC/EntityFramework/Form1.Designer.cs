namespace EntityFramework
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnGetXml = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(776, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(26, 83);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(555, 324);
            this.textBox1.TabIndex = 1;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(715, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(129, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(213, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Get product by id";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(36, 14);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(69, 20);
            this.txtId.TabIndex = 1;
            this.txtId.Text = "680";
            // 
            // btnGetXml
            // 
            this.btnGetXml.Location = new System.Drawing.Point(506, 25);
            this.btnGetXml.Name = "btnGetXml";
            this.btnGetXml.Size = new System.Drawing.Size(75, 23);
            this.btnGetXml.TabIndex = 5;
            this.btnGetXml.Text = "GetXml";
            this.btnGetXml.UseVisualStyleBackColor = true;
            this.btnGetXml.Click += new System.EventHandler(this.btnGetXml_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(191, 42);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(213, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Update";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(36, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(149, 20);
            this.txtName.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 564);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btnGetXml);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnGetXml;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtName;
    }
}

