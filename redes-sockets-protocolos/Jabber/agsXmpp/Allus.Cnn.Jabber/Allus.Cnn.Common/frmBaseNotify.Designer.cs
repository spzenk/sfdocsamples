namespace Allus.Cnn.Common
{
    partial class frmBaseNotify
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
            DevExpress.XtraBars.Alerter.AlertButton alertButton2 = new DevExpress.XtraBars.Alerter.AlertButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.SuspendLayout();
            // 
            // fwkMailAgent1
            // 
            this.fwkMailAgent1.NewReceivedMail += new System.EventHandler<Fwk.Mail.NewReceivedMailEventArgs>(this.fwkMailAgent1_NewReceivedMail);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // alertControl1
            // 
            this.alertControl1.AutoFormDelay = 5000;
            alertButton2.Image = global::Allus.Cnn.Common.Properties.Resources.inbox_32;
            alertButton2.ImageDown = global::Allus.Cnn.Common.Properties.Resources.inbox_back_32;
            alertButton2.Name = "alertButton1";
            this.alertControl1.Buttons.Add(alertButton2);
            this.alertControl1.ButtonClick += new DevExpress.XtraBars.Alerter.AlertButtonClickEventHandler(this.alertControl1_ButtonClick);
            // 
            // frmBaseNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 318);
            this.Location = new System.Drawing.Point(0, 0);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Name = "frmBaseNotify";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmBaseNotify_Load);
            this.Activated += new System.EventHandler(this.frmBaseNotify_Activated);
            this.Resize += new System.EventHandler(this.frmBaseNotify_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NotifyIcon notifyIcon1;
        public DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        

    }
}