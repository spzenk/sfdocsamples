namespace Win32Charter
{
    partial class ChatControl
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
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSay = new System.Windows.Forms.Button();
            this.btnWhisper = new System.Windows.Forms.Button();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(3, 186);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(233, 20);
            this.txtMessage.TabIndex = 7;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // btnSay
            // 
            this.btnSay.BackColor = System.Drawing.Color.SlateGray;
            this.btnSay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSay.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnSay.Location = new System.Drawing.Point(16, 212);
            this.btnSay.Name = "btnSay";
            this.btnSay.Size = new System.Drawing.Size(75, 23);
            this.btnSay.TabIndex = 6;
            this.btnSay.Text = "Say";
            this.btnSay.UseVisualStyleBackColor = false;
            this.btnSay.Click += new System.EventHandler(this.btnSay_Click);
            // 
            // btnWhisper
            // 
            this.btnWhisper.BackColor = System.Drawing.Color.SlateGray;
            this.btnWhisper.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWhisper.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnWhisper.Location = new System.Drawing.Point(106, 212);
            this.btnWhisper.Name = "btnWhisper";
            this.btnWhisper.Size = new System.Drawing.Size(75, 23);
            this.btnWhisper.TabIndex = 8;
            this.btnWhisper.Text = "Whisper";
            this.btnWhisper.UseVisualStyleBackColor = false;
            // 
            // txtMessages
            // 
            this.txtMessages.Location = new System.Drawing.Point(3, 58);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.Size = new System.Drawing.Size(364, 122);
            this.txtMessages.TabIndex = 9;
            // 
            // ChatControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.btnWhisper);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.btnSay);
            this.Name = "ChatControl";
            this.Size = new System.Drawing.Size(370, 244);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSay;
        private System.Windows.Forms.Button btnWhisper;
        private System.Windows.Forms.TextBox txtMessages;

    }
}
