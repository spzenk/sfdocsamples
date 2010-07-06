namespace Allus.Cnn.Admin
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
            this.messageCreatorContainer1 = new Allus.Cnn.Common.MessageCreatorContainer();
            this.SuspendLayout();
            // 
            // messageCreatorContainer1
            // 
            this.messageCreatorContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageCreatorContainer1.Location = new System.Drawing.Point(0, 0);
            this.messageCreatorContainer1.MeshName = null;
            this.messageCreatorContainer1.Name = "messageCreatorContainer1";
            this.messageCreatorContainer1.Size = new System.Drawing.Size(747, 527);
            this.messageCreatorContainer1.TabIndex = 0;
            this.messageCreatorContainer1.SendMessageEvent += new System.EventHandler(this.messageCreatorContainer1_SendMessageEvent);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 527);
            this.Controls.Add(this.messageCreatorContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Allus.Cnn.Common.MessageCreatorContainer messageCreatorContainer1;
    }
}