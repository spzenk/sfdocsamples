using Epiron.Front.Bases.Controls;
namespace Meucci.Front.Alerts
{
    partial class pepeCont
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
            this.eP_Label1 = new Epiron.Front.Bases.Controls.EP_Label();
            this.multilanguageSetting1 = new Epiron.Front.Bases.MultilanguageSetting();
            this.SuspendLayout();
            // 
            // eP_Label1
            // 
            this.eP_Label1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.eP_Label1.Location = new System.Drawing.Point(55, 32);
            this.eP_Label1.Name = "eP_Label1";
            this.eP_Label1.Size = new System.Drawing.Size(81, 24);
            this.eP_Label1.TabIndex = 0;
            this.eP_Label1.Text = "eP_Label1";
            // 
            // pepeCont
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.eP_Label1);
            this.Name = "pepeCont";
            this.ResumeLayout(false);

        }

        #endregion

        private EP_Label eP_Label1;
        private  Epiron.Front.Bases.MultilanguageSetting multilanguageSetting1;
    }
}
