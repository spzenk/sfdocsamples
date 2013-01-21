namespace Test.Keepcon
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
            this.components = new System.ComponentModel.Container();
            this.btnSendBath = new System.Windows.Forms.Button();
            this.txtImport = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtSetId = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblCheckResultClock = new System.Windows.Forms.Label();
            this.lblSend_Clock = new System.Windows.Forms.Label();
            this.btnStop_Checkresult = new System.Windows.Forms.Button();
            this.btnStop_SendContent = new System.Windows.Forms.Button();
            this.btnStart_CheckResult = new System.Windows.Forms.Button();
            this.btnStart_SendContent = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.keepconengine1 = new Allus.Keepcon.Keepconengine(this.components);
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSendBath
            // 
            this.btnSendBath.Location = new System.Drawing.Point(1, 20);
            this.btnSendBath.Name = "btnSendBath";
            this.btnSendBath.Size = new System.Drawing.Size(143, 28);
            this.btnSendBath.TabIndex = 0;
            this.btnSendBath.Text = "1 -Send xml bath";
            this.btnSendBath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendBath.UseVisualStyleBackColor = true;
            this.btnSendBath.Click += new System.EventHandler(this.btnSendBath_Click);
            // 
            // txtImport
            // 
            this.txtImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImport.Location = new System.Drawing.Point(305, 185);
            this.txtImport.Multiline = true;
            this.txtImport.Name = "txtImport";
            this.txtImport.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtImport.Size = new System.Drawing.Size(651, 233);
            this.txtImport.TabIndex = 1;
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.Location = new System.Drawing.Point(305, 444);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(686, 120);
            this.txtResult.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(408, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 33);
            this.button2.TabIndex = 3;
            this.button2.Text = "check xml Export";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(538, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(117, 24);
            this.button3.TabIndex = 4;
            this.button3.Text = "check xml response";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1, 54);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(133, 26);
            this.button4.TabIndex = 5;
            this.button4.Text = "2 - Check results";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnCheckResult_Click);
            // 
            // txtSetId
            // 
            this.txtSetId.Location = new System.Drawing.Point(147, 97);
            this.txtSetId.Name = "txtSetId";
            this.txtSetId.Size = new System.Drawing.Size(379, 20);
            this.txtSetId.TabIndex = 6;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1, 94);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(133, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "3 - Send ack";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(538, 45);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(143, 27);
            this.button6.TabIndex = 8;
            this.button6.Text = "Send xml 1";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(763, 150);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lblCheckResultClock);
            this.tabPage2.Controls.Add(this.lblSend_Clock);
            this.tabPage2.Controls.Add(this.btnStop_Checkresult);
            this.tabPage2.Controls.Add(this.btnStop_SendContent);
            this.tabPage2.Controls.Add(this.btnStart_CheckResult);
            this.tabPage2.Controls.Add(this.btnStart_SendContent);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(755, 124);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Engine";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblCheckResultClock
            // 
            this.lblCheckResultClock.AutoSize = true;
            this.lblCheckResultClock.Location = new System.Drawing.Point(486, 69);
            this.lblCheckResultClock.Name = "lblCheckResultClock";
            this.lblCheckResultClock.Size = new System.Drawing.Size(35, 13);
            this.lblCheckResultClock.TabIndex = 6;
            this.lblCheckResultClock.Text = "label1";
            // 
            // lblSend_Clock
            // 
            this.lblSend_Clock.AutoSize = true;
            this.lblSend_Clock.Location = new System.Drawing.Point(486, 14);
            this.lblSend_Clock.Name = "lblSend_Clock";
            this.lblSend_Clock.Size = new System.Drawing.Size(35, 13);
            this.lblSend_Clock.TabIndex = 5;
            this.lblSend_Clock.Text = "label1";
            // 
            // btnStop_Checkresult
            // 
            this.btnStop_Checkresult.Enabled = false;
            this.btnStop_Checkresult.Location = new System.Drawing.Point(226, 69);
            this.btnStop_Checkresult.Name = "btnStop_Checkresult";
            this.btnStop_Checkresult.Size = new System.Drawing.Size(143, 28);
            this.btnStop_Checkresult.TabIndex = 4;
            this.btnStop_Checkresult.Text = "STOP Send content";
            this.btnStop_Checkresult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop_Checkresult.UseVisualStyleBackColor = true;
            this.btnStop_Checkresult.Click += new System.EventHandler(this.btnStop_Checkresult_Click);
            // 
            // btnStop_SendContent
            // 
            this.btnStop_SendContent.Enabled = false;
            this.btnStop_SendContent.Location = new System.Drawing.Point(226, 3);
            this.btnStop_SendContent.Name = "btnStop_SendContent";
            this.btnStop_SendContent.Size = new System.Drawing.Size(143, 28);
            this.btnStop_SendContent.TabIndex = 3;
            this.btnStop_SendContent.Text = "STOP Send content";
            this.btnStop_SendContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStop_SendContent.UseVisualStyleBackColor = true;
            this.btnStop_SendContent.Click += new System.EventHandler(this.btnStop_SendContent_Click);
            // 
            // btnStart_CheckResult
            // 
            this.btnStart_CheckResult.Location = new System.Drawing.Point(51, 69);
            this.btnStart_CheckResult.Name = "btnStart_CheckResult";
            this.btnStart_CheckResult.Size = new System.Drawing.Size(143, 28);
            this.btnStart_CheckResult.TabIndex = 2;
            this.btnStart_CheckResult.Text = "Start check results";
            this.btnStart_CheckResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart_CheckResult.UseVisualStyleBackColor = true;
            this.btnStart_CheckResult.Click += new System.EventHandler(this.btnStart_CheckResult_Click);
            // 
            // btnStart_SendContent
            // 
            this.btnStart_SendContent.Location = new System.Drawing.Point(51, 6);
            this.btnStart_SendContent.Name = "btnStart_SendContent";
            this.btnStart_SendContent.Size = new System.Drawing.Size(143, 28);
            this.btnStart_SendContent.TabIndex = 1;
            this.btnStart_SendContent.Text = "Start Send content";
            this.btnStart_SendContent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStart_SendContent.UseVisualStyleBackColor = true;
            this.btnStart_SendContent.Click += new System.EventHandler(this.btnEngine_StartSVC_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtSetId);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.btnSendBath);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(755, 124);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Keepcon component";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // keepconengine1
            // 
            this.keepconengine1.SussessEvent += new Allus.Keepcon.SussessHandler(this.keepconengine1_SussessEvent);
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogs.Location = new System.Drawing.Point(12, 185);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogs.Size = new System.Drawing.Size(287, 389);
            this.txtLogs.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 596);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtImport);
            this.Name = "Form1";
            this.Text = "Keepcont test service";
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSendBath;
        private System.Windows.Forms.TextBox txtImport;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtSetId;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnStart_SendContent;
        private Allus.Keepcon.Keepconengine keepconengine1;
        private System.Windows.Forms.Button btnStart_CheckResult;
        private System.Windows.Forms.Button btnStop_Checkresult;
        private System.Windows.Forms.Button btnStop_SendContent;
        private System.Windows.Forms.Label lblSend_Clock;
        private System.Windows.Forms.Label lblCheckResultClock;
        private System.Windows.Forms.TextBox txtLogs;
    }
}

