namespace Fwk.SocialNetworks
{
    partial class FrmTwitter
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
            this.btn_Twitterizer_GetAllUserMessages = new System.Windows.Forms.Button();
            this.txtMentions = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStatuses = new System.Windows.Forms.TextBox();
            this.txtSavedSearches = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.enjine1 = new Fwk.SocialNetworks.Twitter.Enjine(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.txtSearchs = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Twitterizer_GetAllUserMessages
            // 
            this.btn_Twitterizer_GetAllUserMessages.Location = new System.Drawing.Point(13, 267);
            this.btn_Twitterizer_GetAllUserMessages.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Twitterizer_GetAllUserMessages.Name = "btn_Twitterizer_GetAllUserMessages";
            this.btn_Twitterizer_GetAllUserMessages.Size = new System.Drawing.Size(227, 43);
            this.btn_Twitterizer_GetAllUserMessages.TabIndex = 3;
            this.btn_Twitterizer_GetAllUserMessages.Text = "Twitterizer_GetAllUserMessages";
            this.btn_Twitterizer_GetAllUserMessages.UseVisualStyleBackColor = true;
            this.btn_Twitterizer_GetAllUserMessages.Click += new System.EventHandler(this.btn_Twitterizer_GetAllUserMessages_Click);
            // 
            // txtMentions
            // 
            this.txtMentions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMentions.Location = new System.Drawing.Point(257, 60);
            this.txtMentions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMentions.Multiline = true;
            this.txtMentions.Name = "txtMentions";
            this.txtMentions.Size = new System.Drawing.Size(379, 542);
            this.txtMentions.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mentions";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(639, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Statuses";
            // 
            // txtStatuses
            // 
            this.txtStatuses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtStatuses.Location = new System.Drawing.Point(643, 60);
            this.txtStatuses.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStatuses.Multiline = true;
            this.txtStatuses.Name = "txtStatuses";
            this.txtStatuses.Size = new System.Drawing.Size(304, 487);
            this.txtStatuses.TabIndex = 6;
            // 
            // txtSavedSearches
            // 
            this.txtSavedSearches.Location = new System.Drawing.Point(952, 40);
            this.txtSavedSearches.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSavedSearches.Multiline = true;
            this.txtSavedSearches.Name = "txtSavedSearches";
            this.txtSavedSearches.Size = new System.Drawing.Size(264, 85);
            this.txtSavedSearches.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(949, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Saved searches";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 318);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 43);
            this.button1.TabIndex = 10;
            this.button1.Text = "Twitter_GetSavedSearch";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Fwk.SocialNetworks.Test.Properties.Resources.twitter_t;
            this.pictureBox1.Location = new System.Drawing.Point(13, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(124, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.Image = global::Fwk.SocialNetworks.Test.Properties.Resources.twitter;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(13, 164);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 43);
            this.button2.TabIndex = 11;
            this.button2.Text = "Start log service";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(954, 231);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(203, 30);
            this.button3.TabIndex = 13;
            this.button3.Text = "Twitter_GetBySavedSearch";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(954, 182);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(215, 43);
            this.txtSearch.TabIndex = 14;
            // 
            // txtSearchs
            // 
            this.txtSearchs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchs.Location = new System.Drawing.Point(952, 267);
            this.txtSearchs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearchs.Multiline = true;
            this.txtSearchs.Name = "txtSearchs";
            this.txtSearchs.Size = new System.Drawing.Size(318, 324);
            this.txtSearchs.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(953, 163);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Query";
            // 
            // FrmTwitter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 613);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSearchs);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSavedSearches);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStatuses);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMentions);
            this.Controls.Add(this.btn_Twitterizer_GetAllUserMessages);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmTwitter";
            this.ShowIcon = false;
            this.Text = "Twitter log";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Twitterizer_GetAllUserMessages;
        private System.Windows.Forms.TextBox txtMentions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStatuses;
        private System.Windows.Forms.TextBox txtSavedSearches;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Fwk.SocialNetworks.Twitter.Enjine enjine1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TextBox txtSearchs;
        private System.Windows.Forms.Label label4;
    }
}