namespace Allus.Cnn.Common
{
    partial class MessageCreatorContainer
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
            this.components = new System.ComponentModel.Container();
            this.radioGroup1 = new DevExpress.XtraEditors.RadioGroup();
            this.MessagebindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnSend = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.popupContainerEdit_MessageType = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.radioGroup_MessageType = new DevExpress.XtraEditors.RadioGroup();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.imgMessageChecked = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessagebindingSource)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit_MessageType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup_MessageType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMessageChecked)).BeginInit();
            this.SuspendLayout();
            // 
            // radioGroup1
            // 
            this.radioGroup1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MessagebindingSource, "Priority", true));
            this.radioGroup1.EditValue = 1;
            this.radioGroup1.Location = new System.Drawing.Point(272, 34);
            this.radioGroup1.Name = "radioGroup1";
            this.radioGroup1.Properties.Columns = 1;
            this.radioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(0, "Baja"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Media"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Alta")});
            this.radioGroup1.Size = new System.Drawing.Size(80, 90);
            this.radioGroup1.TabIndex = 22;
            this.radioGroup1.ToolTip = "Seleccione una prioridad para el mensaje";
            this.radioGroup1.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.radioGroup1.Visible = false;
            this.radioGroup1.SelectedIndexChanged += new System.EventHandler(this.radioGroup1_SelectedIndexChanged);
            this.radioGroup1.MouseLeave += new System.EventHandler(this.radioGroup1_MouseLeave);
            // 
            // MessagebindingSource
            // 
            this.MessagebindingSource.DataSource = typeof(Allus.Cnn.Common.BE.AlertMessage);
            // 
            // btnSend
            // 
            this.btnSend.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSend.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSend.Appearance.Options.UseFont = true;
            this.btnSend.Appearance.Options.UseForeColor = true;
            this.btnSend.Image = global::Allus.Cnn.Common.Properties.Resources.Send_Mail_16;
            this.btnSend.Location = new System.Drawing.Point(193, 10);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(73, 24);
            this.btnSend.TabIndex = 23;
            this.btnSend.Text = "Enviar";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioGroup1);
            this.groupBox1.Controls.Add(this.popupContainerEdit_MessageType);
            this.groupBox1.Controls.Add(this.popupContainerControl1);
            this.groupBox1.Controls.Add(this.btnSend);
            this.groupBox1.Controls.Add(this.panelControl1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.imgMessageChecked);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(379, 503);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // popupContainerEdit_MessageType
            // 
            this.popupContainerEdit_MessageType.EditValue = "Tipo de mensaje";
            this.popupContainerEdit_MessageType.Location = new System.Drawing.Point(21, 13);
            this.popupContainerEdit_MessageType.Name = "popupContainerEdit_MessageType";
            this.popupContainerEdit_MessageType.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.popupContainerEdit_MessageType.Properties.Appearance.Options.UseBackColor = true;
            this.popupContainerEdit_MessageType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Down)});
            this.popupContainerEdit_MessageType.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit_MessageType.Size = new System.Drawing.Size(166, 20);
            this.popupContainerEdit_MessageType.TabIndex = 26;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.popupContainerControl1.Appearance.Options.UseBackColor = true;
            this.popupContainerControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.popupContainerControl1.Controls.Add(this.radioGroup_MessageType);
            this.popupContainerControl1.Location = new System.Drawing.Point(21, 34);
            this.popupContainerControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.popupContainerControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(166, 101);
            this.popupContainerControl1.TabIndex = 25;
            // 
            // radioGroup_MessageType
            // 
            this.radioGroup_MessageType.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.MessagebindingSource, "Priority", true));
            this.radioGroup_MessageType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radioGroup_MessageType.Location = new System.Drawing.Point(2, 2);
            this.radioGroup_MessageType.Name = "radioGroup_MessageType";
            this.radioGroup_MessageType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.radioGroup_MessageType.Properties.Columns = 1;
            this.radioGroup_MessageType.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(1, "Texto simple"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(2, "Texto enriquecido"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(4, "Marquesina")});
            this.radioGroup_MessageType.Size = new System.Drawing.Size(162, 97);
            this.radioGroup_MessageType.TabIndex = 23;
            this.radioGroup_MessageType.ToolTip = "Seleccione una prioridad para el mensaje";
            this.radioGroup_MessageType.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information;
            this.radioGroup_MessageType.SelectedIndexChanged += new System.EventHandler(this.radioGroup_MessageType_SelectedIndexChanged);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.AutoSize = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Location = new System.Drawing.Point(8, 44);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(362, 450);
            this.panelControl1.TabIndex = 24;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Allus.Cnn.Common.Properties.Resources.impt_16;
            this.pictureBox1.Location = new System.Drawing.Point(290, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(16, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.toolTipController1.SetTitle(this.pictureBox1, "Prioridad");
            this.pictureBox1.MouseHover += new System.EventHandler(this.pictureBox1_MouseHover);
            // 
            // imgMessageChecked
            // 
            this.imgMessageChecked.Image = global::Allus.Cnn.Common.Properties.Resources.confirm_16;
            this.imgMessageChecked.Location = new System.Drawing.Point(-4, -3);
            this.imgMessageChecked.Name = "imgMessageChecked";
            this.imgMessageChecked.Size = new System.Drawing.Size(16, 16);
            this.imgMessageChecked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imgMessageChecked.TabIndex = 12;
            this.imgMessageChecked.TabStop = false;
            // 
            // MessageCreatorContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.MinimumSize = new System.Drawing.Size(379, 503);
            this.Name = "MessageCreatorContainer";
            this.Size = new System.Drawing.Size(379, 503);
            this.Load += new System.EventHandler(this.MessageCreator_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessagebindingSource)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit_MessageType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroup_MessageType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMessageChecked)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.RadioGroup radioGroup1;
        private System.Windows.Forms.BindingSource MessagebindingSource;
        private DevExpress.XtraEditors.SimpleButton btnSend;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox imgMessageChecked;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit_MessageType;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraEditors.RadioGroup radioGroup_MessageType;
    }
}
