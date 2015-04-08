namespace Epiron.Front.Bases
{
    partial class Xtra_UC_Base
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
            this.components = new System.ComponentModel.Container();
            this.multilanguageSetting1 = new Epiron.Front.Bases.MultilanguageSetting(this.components);
            this.MessageViewer = new Epiron.Front.Bases.MessageViewerComponent(this.components);
            this.ExceptionViewer = new Epiron.Front.Bases.ExceptionViewComponent(this.components);
            this.SuspendLayout();
            // 
            // MessageViewer
            // 
            this.MessageViewer.BackColor = System.Drawing.Color.Gray;
            this.MessageViewer.IconSize = Fwk.UI.Common.IconSize.Medium;
            this.MessageViewer.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
            this.MessageViewer.TextMessageColor = System.Drawing.Color.White;
            this.MessageViewer.TextMessageForeColor = System.Drawing.Color.Black;
            this.MessageViewer.Title = "Epiron gestion";
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.ExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ExceptionViewer.TextMessageColor = System.Drawing.Color.White;
            this.ExceptionViewer.TextMessageForeColorColor = System.Drawing.Color.Black;
            this.ExceptionViewer.Title = "";
            // 
            // Xtra_UC_Base
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "Xtra_UC_Base";
            this.Size = new System.Drawing.Size(520, 438);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Xtra_UC_Base_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private MultilanguageSetting multilanguageSetting1;
        public MessageViewerComponent MessageViewer;
        public ExceptionViewComponent ExceptionViewer;
    }
}
