namespace BaseComponents1
{
    partial class BaseComboCheck
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
            this.baseCombo1 = new BaseComponents1.BaseCombo();
            this.baseLabel1 = new BaseComponents1.BaseLabel();
            this.baseCheck1 = new BaseComponents1.BaseCheck();
            this.SuspendLayout();
            // 
            // baseCombo1
            // 
            this.baseCombo1._Enabled = true;
            this.baseCombo1._FontSize = 8.25F;
            this.baseCombo1._SizeCombo = new System.Drawing.Size(162, 20);
            this.baseCombo1._TabIndex = 0;
            this.baseCombo1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.baseCombo1.Location = new System.Drawing.Point(88, 1);
            this.baseCombo1.Name = "baseCombo1";
            this.baseCombo1.Size = new System.Drawing.Size(162, 24);
            this.baseCombo1.TabIndex = 1;
            this.baseCombo1._ComboEditValueChanged += new System.EventHandler(this.baseCombo1__ComboEditValueChanged);
            // 
            // baseLabel1
            // 
            this.baseLabel1._AnchorLabel = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.baseLabel1._AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Default;
            this.baseLabel1._Enabled = true;
            this.baseLabel1._FontSize = 8.25F;
            this.baseLabel1._TabIndex = 0;
            this.baseLabel1._Text = "labelControl1";
            this.baseLabel1._TextOptions = DevExpress.Utils.WordWrap.Default;
            this.baseLabel1._Visible = true;
            this.baseLabel1.Location = new System.Drawing.Point(5, 5);
            this.baseLabel1.Name = "baseLabel1";
            this.baseLabel1.Size = new System.Drawing.Size(84, 17);
            this.baseLabel1.TabIndex = 0;
            this.baseLabel1.TabStop = false;
            this.baseLabel1.Load += new System.EventHandler(this.baseLabel1_Load);
            // 
            // baseCheck1
            // 
            this.baseCheck1._BehaviorInNew = false;
            this.baseCheck1._Checked = false;
            this.baseCheck1._CheckEditingABM = false;
            this.baseCheck1._CleanOnABM_SetFalse = false;
            this.baseCheck1._CleanOnABM_SetTrue = false;
            this.baseCheck1._Enabled = true;
            this.baseCheck1._FontSize = 8.25F;
            this.baseCheck1._TabIndex = 0;
            this.baseCheck1._Text = "checkEdit1";
            this.baseCheck1._Visible = true;
            this.baseCheck1.Location = new System.Drawing.Point(0, 0);
            this.baseCheck1.Name = "baseCheck1";
            this.baseCheck1.Size = new System.Drawing.Size(89, 19);
            this.baseCheck1.TabIndex = 1;
            this.baseCheck1._CheckedChanged += new System.EventHandler(this.baseCheck1__CheckedChanged);
            // 
            // BaseComboCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseCombo1);
            this.Controls.Add(this.baseLabel1);
            this.Controls.Add(this.baseCheck1);
            this.Name = "BaseComboCheck";
            this.Size = new System.Drawing.Size(250, 25);
            this.ResumeLayout(false);

        }

        #endregion

        public BaseLabel baseLabel1;
        public BaseCheck baseCheck1;
        public BaseCombo baseCombo1;

    }
}
