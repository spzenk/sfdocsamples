namespace Fwk.SequentialWorkflow
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
            this.result = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.approvalState = new System.Windows.Forms.Label();
            this.approveButton = new System.Windows.Forms.Button();
            this.rejectButton = new System.Windows.Forms.Button();
            this.amount = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(27, 66);
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Size = new System.Drawing.Size(162, 20);
            this.result.TabIndex = 11;
            this.result.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Result";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.approvalState);
            this.panel1.Controls.Add(this.approveButton);
            this.panel1.Controls.Add(this.rejectButton);
            this.panel1.Location = new System.Drawing.Point(21, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(172, 66);
            this.panel1.TabIndex = 14;
            // 
            // approvalState
            // 
            this.approvalState.AutoSize = true;
            this.approvalState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.approvalState.Location = new System.Drawing.Point(10, 9);
            this.approvalState.Name = "approvalState";
            this.approvalState.Size = new System.Drawing.Size(49, 13);
            this.approvalState.TabIndex = 4;
            this.approvalState.Text = "Approval";
            // 
            // approveButton
            // 
            this.approveButton.Enabled = false;
            this.approveButton.Location = new System.Drawing.Point(11, 25);
            this.approveButton.Name = "approveButton";
            this.approveButton.Size = new System.Drawing.Size(75, 23);
            this.approveButton.TabIndex = 0;
            this.approveButton.Text = "Approve";
            this.approveButton.Click += new System.EventHandler(this.approveButton_Click);
            // 
            // rejectButton
            // 
            this.rejectButton.Enabled = false;
            this.rejectButton.Location = new System.Drawing.Point(86, 25);
            this.rejectButton.Name = "rejectButton";
            this.rejectButton.Size = new System.Drawing.Size(75, 23);
            this.rejectButton.TabIndex = 1;
            this.rejectButton.Text = "Reject";
            this.rejectButton.Click += new System.EventHandler(this.rejectButton_Click);
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(27, 25);
            this.amount.MaxLength = 9;
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(162, 20);
            this.amount.TabIndex = 9;
            this.amount.TextChanged += new System.EventHandler(this.amount_TextChanged);
            // 
            // submitButton
            // 
            this.submitButton.Enabled = false;
            this.submitButton.Location = new System.Drawing.Point(70, 91);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 12;
            this.submitButton.Text = "Submit";
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Amount";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(221, 201);
            this.Controls.Add(this.result);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.TextBox result;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label approvalState;
        private System.Windows.Forms.Button approveButton;
        private System.Windows.Forms.Button rejectButton;
        private System.Windows.Forms.TextBox amount;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label1;
	}
}