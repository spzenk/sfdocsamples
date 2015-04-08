using Epiron.Front.Bases.Controls;
namespace Epiron.Front.Bases
{
    partial class FRM_AuthenticationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_AuthenticationForm));
            this.labelEpiron2 = new Epiron.Front.Bases.Controls.EP_Label();
            this.txtUserNameLogin = new Epiron.Front.Bases.Controls.EP_TextEdit();
            this.txtPassLogin = new Epiron.Front.Bases.Controls.EP_TextEdit();
            this.pnlInferior = new DevExpress.XtraEditors.PanelControl();
            this.buttonCommonEpiron2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAcept = new DevExpress.XtraEditors.SimpleButton();
            this.labelEpiron3 = new Epiron.Front.Bases.Controls.EP_Label();
            this.comboAuthenticationType1 = new Epiron.Front.Bases.Controls.ComboAuthenticationType();
            this.eP_Label1 = new Epiron.Front.Bases.Controls.EP_Label();
            this.cmbDomains = new Epiron.Front.Bases.Controls.ComboDomain();
            this.eP_Label2 = new Epiron.Front.Bases.Controls.EP_Label();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNameLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassLogin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).BeginInit();
            this.pnlInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.ExceptionViewer.TextMessageColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.ExceptionViewer.TextMessageForeColorColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.ExceptionViewer.Title = "Error de autenticación";
            // 
            // MessageViewer
            // 
            this.MessageViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(88)))), ((int)(((byte)(88)))), ((int)(((byte)(88)))));
            this.MessageViewer.TextMessageColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.MessageViewer.TextMessageForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.MessageViewer.Title = "Autenticación";
            // 
            // labelEpiron2
            // 
            this.labelEpiron2.CheckEditingABM = false;
            this.labelEpiron2.CheckEditingABMValue = false;
            this.labelEpiron2.Location = new System.Drawing.Point(29, 99);
            this.labelEpiron2.Name = "labelEpiron2";
            this.labelEpiron2.Size = new System.Drawing.Size(63, 13);
            this.labelEpiron2.TabIndex = 6;
            this.labelEpiron2.Text = "Contraseña :";
            this.labelEpiron2.TextUICode = null;
            // 
            // txtUserNameLogin
            // 
            this.txtUserNameLogin.CheckEditingABM = false;
            this.txtUserNameLogin.CheckEditingABMValue = false;
            this.txtUserNameLogin.CleanOnABM = false;
            this.txtUserNameLogin.EditValue = "";
            this.txtUserNameLogin.FocusedOnEditABM = false;
            this.txtUserNameLogin.Location = new System.Drawing.Point(162, 73);
            this.txtUserNameLogin.Name = "txtUserNameLogin";
            this.txtUserNameLogin.SelectOnEntry = false;
            this.txtUserNameLogin.Size = new System.Drawing.Size(198, 20);
            this.txtUserNameLogin.TabIndex = 0;
            this.txtUserNameLogin.TextUICode = null;
            this.txtUserNameLogin.TypeText = Epiron.Front.Bases.TypeText.Todos;
            this.txtUserNameLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUserNameLogin_KeyPress);
            // 
            // txtPassLogin
            // 
            this.txtPassLogin.CheckEditingABM = false;
            this.txtPassLogin.CheckEditingABMValue = false;
            this.txtPassLogin.CleanOnABM = false;
            this.txtPassLogin.EditValue = "";
            this.txtPassLogin.FocusedOnEditABM = false;
            this.txtPassLogin.Location = new System.Drawing.Point(162, 100);
            this.txtPassLogin.Name = "txtPassLogin";
            this.txtPassLogin.Properties.PasswordChar = '*';
            this.txtPassLogin.SelectOnEntry = false;
            this.txtPassLogin.Size = new System.Drawing.Size(198, 20);
            this.txtPassLogin.TabIndex = 2;
            this.txtPassLogin.TextUICode = null;
            this.txtPassLogin.TypeText = Epiron.Front.Bases.TypeText.Todos;
            this.txtPassLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassLogin_KeyPress);
            // 
            // pnlInferior
            // 
            this.pnlInferior.Controls.Add(this.buttonCommonEpiron2);
            this.pnlInferior.Controls.Add(this.btnAcept);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.Location = new System.Drawing.Point(0, 198);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Size = new System.Drawing.Size(394, 38);
            this.pnlInferior.TabIndex = 3;
            // 
            // buttonCommonEpiron2
            // 
            this.buttonCommonEpiron2.Location = new System.Drawing.Point(294, 8);
            this.buttonCommonEpiron2.Name = "buttonCommonEpiron2";
            this.buttonCommonEpiron2.Size = new System.Drawing.Size(90, 24);
            this.buttonCommonEpiron2.TabIndex = 10;
            this.buttonCommonEpiron2.Text = "Cancelar";
            this.buttonCommonEpiron2.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAcept
            // 
            this.btnAcept.Location = new System.Drawing.Point(183, 9);
            this.btnAcept.Name = "btnAcept";
            this.btnAcept.Size = new System.Drawing.Size(90, 24);
            this.btnAcept.TabIndex = 9;
            this.btnAcept.Text = "Aceptar";
            this.btnAcept.Click += new System.EventHandler(this.btnAcept_Click);
            // 
            // labelEpiron3
            // 
            this.labelEpiron3.CheckEditingABM = false;
            this.labelEpiron3.CheckEditingABMValue = false;
            this.labelEpiron3.Location = new System.Drawing.Point(29, 75);
            this.labelEpiron3.Name = "labelEpiron3";
            this.labelEpiron3.Size = new System.Drawing.Size(98, 13);
            this.labelEpiron3.TabIndex = 5;
            this.labelEpiron3.Text = "Nombre de Usuario :";
            this.labelEpiron3.TextUICode = null;
            // 
            // comboAuthenticationType1
            // 
            this.comboAuthenticationType1.CheckEditingABM = false;
            this.comboAuthenticationType1.CheckEditingABMValue = false;
            this.comboAuthenticationType1.DtAuthenticationType = null;
            this.comboAuthenticationType1.Key = resources.GetString("comboAuthenticationType1.Key");
            this.comboAuthenticationType1.Location = new System.Drawing.Point(162, 42);
            this.comboAuthenticationType1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.comboAuthenticationType1.Name = "comboAuthenticationType1";
            this.comboAuthenticationType1.PanelContainer = Epiron.Front.Bases.PanelEnum.LeftPanel_0;
            this.comboAuthenticationType1.ParentPanel = null;
            this.comboAuthenticationType1.Size = new System.Drawing.Size(198, 25);
            this.comboAuthenticationType1.TabIndex = 1;
            this.comboAuthenticationType1.TextUICode = null;
            this.comboAuthenticationType1.OnComboEditValueChanged += new System.EventHandler(this.OnComboEditValueChanged_ComboEditValueChanged);
            // 
            // eP_Label1
            // 
            this.eP_Label1.CheckEditingABM = false;
            this.eP_Label1.CheckEditingABMValue = false;
            this.eP_Label1.Location = new System.Drawing.Point(29, 42);
            this.eP_Label1.Name = "eP_Label1";
            this.eP_Label1.Size = new System.Drawing.Size(88, 13);
            this.eP_Label1.TabIndex = 7;
            this.eP_Label1.Text = "Tipo Autenticacion";
            this.eP_Label1.TextUICode = null;
            // 
            // cmbDomains
            // 
            this.cmbDomains.Key = resources.GetString("cmbDomains.Key");
            this.cmbDomains.Location = new System.Drawing.Point(162, 149);
            this.cmbDomains.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbDomains.Name = "cmbDomains";
            this.cmbDomains.PanelContainer = Epiron.Front.Bases.PanelEnum.LeftPanel_0;
            this.cmbDomains.ParentPanel = null;
            this.cmbDomains.Size = new System.Drawing.Size(198, 26);
            this.cmbDomains.TabIndex = 8;
            this.cmbDomains.WithTextSelection = false;
            // 
            // eP_Label2
            // 
            this.eP_Label2.CheckEditingABM = false;
            this.eP_Label2.CheckEditingABMValue = false;
            this.eP_Label2.Location = new System.Drawing.Point(29, 149);
            this.eP_Label2.Name = "eP_Label2";
            this.eP_Label2.Size = new System.Drawing.Size(42, 13);
            this.eP_Label2.TabIndex = 9;
            this.eP_Label2.Text = "Dominios";
            this.eP_Label2.TextUICode = null;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // FRM_AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 236);
            this.Controls.Add(this.eP_Label2);
            this.Controls.Add(this.cmbDomains);
            this.Controls.Add(this.eP_Label1);
            this.Controls.Add(this.comboAuthenticationType1);
            this.Controls.Add(this.labelEpiron3);
            this.Controls.Add(this.pnlInferior);
            this.Controls.Add(this.txtPassLogin);
            this.Controls.Add(this.txtUserNameLogin);
            this.Controls.Add(this.labelEpiron2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.MaximizeBox = false;
            this.Name = "FRM_AuthenticationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar Sesión";
            this.Activated += new System.EventHandler(this.FRM_AuthenticationForm_Activated);
            this.Load += new System.EventHandler(this.FRM_AuthenticationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtUserNameLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassLogin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlInferior)).EndInit();
            this.pnlInferior.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private EP_Label labelEpiron2;
        private EP_TextEdit txtUserNameLogin;
        private EP_TextEdit txtPassLogin;
        private DevExpress.XtraEditors.PanelControl pnlInferior;
        private DevExpress.XtraEditors.SimpleButton buttonCommonEpiron2;
        private DevExpress.XtraEditors.SimpleButton btnAcept;
        private EP_Label labelEpiron3;
        private Epiron.Front.Bases.Controls.ComboAuthenticationType comboAuthenticationType1;
      
        
        
        private EP_Label eP_Label1;
        private ComboDomain cmbDomains;
        private EP_Label eP_Label2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}