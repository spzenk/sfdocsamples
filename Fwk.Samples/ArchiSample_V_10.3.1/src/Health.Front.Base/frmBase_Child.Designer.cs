namespace Health.Front
{
    partial class frmBase_Child
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
            this.SuspendLayout();
            // 
            // MessageViewer
            // 
            this.MessageViewer.IconSize = Fwk.UI.Common.IconSize.Large;
            this.MessageViewer.Title = "Healt 32";
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.Title = "Healt 32";
            // 
            // frmBase_Child
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1067, 737);
            this.Name = "frmBase_Child";
            this.ShowIcon = false;
            this.Text = "frmBase_Child";
            this.ResumeLayout(false);

        }

        #endregion
    }
}