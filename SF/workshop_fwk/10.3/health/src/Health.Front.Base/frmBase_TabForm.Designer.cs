namespace Health.Front
{
    partial class frmBase_TabForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBase_TabForm));
            this.SuspendLayout();
            // 
            // MessageViewer
            // 
            this.MessageViewer.Title = "Hemosoft";
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.Title = "Hemosoft";
            // 
            // frmBase_TabForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 593);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmBase_TabForm";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Text = "";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.frmBasegastos_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmBasegastos_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion




    }
}