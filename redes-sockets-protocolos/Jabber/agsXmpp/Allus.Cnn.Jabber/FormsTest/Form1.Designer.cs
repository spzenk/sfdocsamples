namespace FormsTest
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
            this.btnTest = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnTest.Appearance.Options.UseFont = true;
            this.btnTest.Location = new System.Drawing.Point(27, 59);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(118, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Testear Formulario";
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 134);
            this.Controls.Add(this.btnTest);
            this.Name = "Form1";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnTest;
    }
}

