namespace Health.Front.Events
{
    partial class frmEvent
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
            this.uc_event_view1 = new Health.Front.Events.uc_event_view();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.CancelButtonText = "Salir";
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 638);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(922, 28);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // uc_event_view1
            // 
            this.uc_event_view1.AcceptButton = null;
            this.uc_event_view1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uc_event_view1.CancelButton = null;
            this.uc_event_view1.Location = new System.Drawing.Point(3, 5);
            this.uc_event_view1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uc_event_view1.Name = "uc_event_view1";
            this.uc_event_view1.Size = new System.Drawing.Size(922, 625);
            this.uc_event_view1.TabIndex = 1;
            // 
            // frmEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(928, 671);
            this.Controls.Add(this.uc_event_view1);
            this.Name = "frmEvent";
            this.Text = "Consulta de atencion médica";
            this.Controls.SetChildIndex(this.uc_event_view1, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private uc_event_view uc_event_view1;
    }
}