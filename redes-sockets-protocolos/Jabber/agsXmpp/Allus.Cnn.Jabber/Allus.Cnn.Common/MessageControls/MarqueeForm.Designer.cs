namespace Allus.Cnn.Common
{
    partial class MarqueeForm
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
            this.marquee1 = new Allus.Cnn.Common.Marquee();
            this.SuspendLayout();
            // 
            // marquee1
            // 
            this.marquee1.AutoSize = true;
            this.marquee1.BackColor = System.Drawing.Color.Transparent;
            this.marquee1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marquee1.ForeColor = System.Drawing.Color.White;
            this.marquee1.Location = new System.Drawing.Point(0, 0);
            this.marquee1.Name = "marquee1";
            this.marquee1.Size = new System.Drawing.Size(621, 56);
            this.marquee1.Speed = 0;
            this.marquee1.TabIndex = 0;
            this.marquee1.TextDirection = Allus.Cnn.Common.Direction.Right;
            this.marquee1.TextToShow = "Pueden retirar sus tickets en recursos humanos";
            this.marquee1.TimeToShow = 0;
            // 
            // MarqueeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(621, 56);
            this.Controls.Add(this.marquee1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MarqueeForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "AlertMessage";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.SystemColors.Control;
            this.Load += new System.EventHandler(this.MarqueeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Marquee marquee1;



    }
}