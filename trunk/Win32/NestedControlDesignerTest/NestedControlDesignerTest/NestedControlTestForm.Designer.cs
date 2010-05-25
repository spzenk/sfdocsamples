namespace NestedControlDesignerTest
{
	partial class NestedControlTestForm
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
            this.improvedTestControl1 = new ImprovedNestedControlDesignerLibrary.ImprovedTestControl();
            this.lboxNames = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.testControl1 = new NestedControlDesignerLibrary.TestControl();
            this.cboxNumbers = new System.Windows.Forms.ComboBox();
            this.improvedTestControl1.WorkingArea.SuspendLayout();
            this.improvedTestControl1.SuspendLayout();
            this.testControl1.WorkingArea.SuspendLayout();
            this.testControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // improvedTestControl1
            // 
            this.improvedTestControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.improvedTestControl1.Caption = "Improved Test Control";
            this.improvedTestControl1.Location = new System.Drawing.Point(179, 25);
            this.improvedTestControl1.Name = "improvedTestControl1";
            this.improvedTestControl1.Size = new System.Drawing.Size(148, 259);
            this.improvedTestControl1.TabIndex = 1;
            // 
            // improvedTestControl1.WorkingArea
            // 
            this.improvedTestControl1.WorkingArea.BackColor = System.Drawing.Color.Bisque;
            this.improvedTestControl1.WorkingArea.Controls.Add(this.lboxNames);
            this.improvedTestControl1.WorkingArea.Controls.Add(this.label1);
            this.improvedTestControl1.WorkingArea.Location = new System.Drawing.Point(0, 28);
            this.improvedTestControl1.WorkingArea.Name = "WorkingArea";
            this.improvedTestControl1.WorkingArea.Size = new System.Drawing.Size(146, 229);
            this.improvedTestControl1.WorkingArea.TabIndex = 1;
            // 
            // lboxNames
            // 
            this.lboxNames.FormattingEnabled = true;
            this.lboxNames.Items.AddRange(new object[] {
            "Tom",
            "Nelly",
            "Olive",
            "Andy",
            "Jenson",
            "Laura"});
            this.lboxNames.Location = new System.Drawing.Point(12, 24);
            this.lboxNames.Name = "lboxNames";
            this.lboxNames.Size = new System.Drawing.Size(120, 82);
            this.lboxNames.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Names:";
            // 
            // testControl1
            // 
            this.testControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.testControl1.Location = new System.Drawing.Point(12, 11);
            this.testControl1.Name = "testControl1";
            this.testControl1.Size = new System.Drawing.Size(148, 138);
            this.testControl1.TabIndex = 0;
            // 
            // testControl1.WorkingArea
            // 
            this.testControl1.WorkingArea.BackColor = System.Drawing.Color.MistyRose;
            this.testControl1.WorkingArea.Controls.Add(this.cboxNumbers);
            this.testControl1.WorkingArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testControl1.WorkingArea.Location = new System.Drawing.Point(0, 28);
            this.testControl1.WorkingArea.Name = "WorkingArea";
            this.testControl1.WorkingArea.Size = new System.Drawing.Size(146, 108);
            this.testControl1.WorkingArea.TabIndex = 1;
            // 
            // cboxNumbers
            // 
            this.cboxNumbers.FormattingEnabled = true;
            this.cboxNumbers.Items.AddRange(new object[] {
            "One",
            "Two",
            "Three",
            "Four"});
            this.cboxNumbers.Location = new System.Drawing.Point(13, 29);
            this.cboxNumbers.Name = "cboxNumbers";
            this.cboxNumbers.Size = new System.Drawing.Size(121, 21);
            this.cboxNumbers.TabIndex = 0;
            // 
            // NestedControlTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 281);
            this.Controls.Add(this.improvedTestControl1);
            this.Controls.Add(this.testControl1);
            this.Name = "NestedControlTestForm";
            this.Text = "Nested Control Designer Demo";
            this.Load += new System.EventHandler(this.NestedControlTestForm_Load);
            this.improvedTestControl1.WorkingArea.ResumeLayout(false);
            this.improvedTestControl1.WorkingArea.PerformLayout();
            this.improvedTestControl1.ResumeLayout(false);
            this.testControl1.WorkingArea.ResumeLayout(false);
            this.testControl1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private NestedControlDesignerLibrary.TestControl testControl1;
		private System.Windows.Forms.ComboBox cboxNumbers;
		private ImprovedNestedControlDesignerLibrary.ImprovedTestControl improvedTestControl1;
		private System.Windows.Forms.ListBox lboxNames;
		private System.Windows.Forms.Label label1;
	}
}

