namespace BaseComponents1
{
    partial class BaseComboCheckActive
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.baseCheck2 = new BaseComponents1.BaseCheck();
            this.SuspendLayout();
            // 
            // baseLabel1
            // 
            this.baseLabel1._AnchorLabel = System.Windows.Forms.AnchorStyles.Left;
            this.baseLabel1.Size = new System.Drawing.Size(122, 20);
            // 
            // baseCheck1
            // 
            this.baseCheck1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.baseCheck1.TabIndex = 2;
            // 
            // baseCombo1
            // 
            this.baseCombo1._SizeCombo = new System.Drawing.Size(175, 20);
            this.baseCombo1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.baseCombo1.Location = new System.Drawing.Point(133, 3);
            this.baseCombo1.Size = new System.Drawing.Size(175, 24);
            // 
            // baseCheck2
            // 
            this.baseCheck2._BehaviorInNew = false;
            this.baseCheck2._Checked = false;
            this.baseCheck2._CheckEditingABM = false;
            this.baseCheck2._CleanOnABM_SetFalse = false;
            this.baseCheck2._CleanOnABM_SetTrue = false;
            this.baseCheck2._Enabled = true;
            this.baseCheck2._FontSize = 8.25F;
            this.baseCheck2._TabIndex = 0;
            this.baseCheck2._Text = "Activo";
            this.baseCheck2._Visible = true;
            this.baseCheck2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.baseCheck2.Location = new System.Drawing.Point(310, 1);
            this.baseCheck2.Name = "baseCheck2";
            this.baseCheck2.Size = new System.Drawing.Size(57, 21);
            this.baseCheck2.TabIndex = 2;
            this.baseCheck2._CheckedChanged += new System.EventHandler(this.baseCheck2__CheckedChanged);
            // 
            // BaseComboCheckActive
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.baseCheck2);
            this.Name = "BaseComboCheckActive";
            this.Size = new System.Drawing.Size(369, 25);
            this.Controls.SetChildIndex(this.baseCombo1, 0);
            this.Controls.SetChildIndex(this.baseCheck2, 0);
            this.Controls.SetChildIndex(this.baseCheck1, 0);
            this.Controls.SetChildIndex(this.baseLabel1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private BaseCheck baseCheck2;

    }
}
