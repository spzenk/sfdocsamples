using Allus.Cnn.Common;
namespace Allus.Cnn.Admin
{
    partial class AdminDomainsScope
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
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.domainFilters1 = new Allus.Cnn.Common.DomainFilters();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.textFindPopUp1 = new Allus.Libs.Controls.TextFindPopUp();
            this.adminDomainGrid_Dest = new Allus.Cnn.Admin.AdminDomainGrid();
            this.adminDomainGrid_Source = new Allus.Cnn.Admin.AdminDomainGrid();
            this.colaboratorsAdminGrid1 = new Allus.Cnn.Admin.ColaboratorsAdminGrid();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Controls.Add(this.domainFilters1);
            this.popupContainerControl1.Location = new System.Drawing.Point(21, 143);
            this.popupContainerControl1.MaximumSize = new System.Drawing.Size(318, 122);
            this.popupContainerControl1.MinimumSize = new System.Drawing.Size(318, 122);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(318, 122);
            this.popupContainerControl1.TabIndex = 5;
            // 
            // domainFilters1
            // 
            this.domainFilters1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.domainFilters1.Location = new System.Drawing.Point(0, 0);
            this.domainFilters1.MaximumSize = new System.Drawing.Size(319, 122);
            this.domainFilters1.MinimumSize = new System.Drawing.Size(319, 122);
            this.domainFilters1.Name = "domainFilters1";
            this.domainFilters1.Size = new System.Drawing.Size(319, 122);
            this.domainFilters1.TabIndex = 0;
            this.domainFilters1.AceptDomainFilterEvent += new Allus.Cnn.Common.AceptDomainFilterHandler(this.domainFilters1_AceptDomainFilterEvent);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = global::Allus.Cnn.Admin.Properties.Resources.move_24;
            this.btnAdd.Location = new System.Drawing.Point(429, 232);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 33);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Agregar/actualizar";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Image = global::Allus.Cnn.Admin.Properties.Resources.save_16;
            this.simpleButton1.Location = new System.Drawing.Point(563, 232);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(131, 33);
            this.simpleButton1.TabIndex = 7;
            this.simpleButton1.Text = "Guardar permisos";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // textFindPopUp1
            // 
            this.textFindPopUp1.AllowAdvancedSearch = true;
            this.textFindPopUp1.Location = new System.Drawing.Point(4, 4);
            this.textFindPopUp1.Name = "textFindPopUp1";
            this.textFindPopUp1.PopupControl = this.popupContainerControl1;
            this.textFindPopUp1.Size = new System.Drawing.Size(396, 28);
            this.textFindPopUp1.TabIndex = 8;
            this.textFindPopUp1.OnFindTextBoxEnter += new System.EventHandler(this.textFindPopUp1_OnFindTextBoxEnter);
            this.textFindPopUp1.OnFindClick += new System.EventHandler(this.textFindPopUp1_OnFindClick);
            // 
            // adminDomainGrid_Dest
            // 
            this.adminDomainGrid_Dest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDomainGrid_Dest.IsOnLine = false;
            this.adminDomainGrid_Dest.Location = new System.Drawing.Point(405, 267);
            this.adminDomainGrid_Dest.Name = "adminDomainGrid_Dest";
            this.adminDomainGrid_Dest.RelatedDomains = null;
            this.adminDomainGrid_Dest.SFButtonMeshVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.adminDomainGrid_Dest.SFButtonRefreshVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.adminDomainGrid_Dest.SFButtonUncheckAllVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.adminDomainGrid_Dest.SFCheckDomainVisible = false;
            this.adminDomainGrid_Dest.SFColInMeshVisible = false;
            this.adminDomainGrid_Dest.Size = new System.Drawing.Size(288, 224);
            this.adminDomainGrid_Dest.TabIndex = 2;
            this.adminDomainGrid_Dest.UserName = null;
            // 
            // adminDomainGrid_Source
            // 
            this.adminDomainGrid_Source.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adminDomainGrid_Source.IsOnLine = false;
            this.adminDomainGrid_Source.Location = new System.Drawing.Point(405, 8);
            this.adminDomainGrid_Source.Name = "adminDomainGrid_Source";
            this.adminDomainGrid_Source.RelatedDomains = null;
            this.adminDomainGrid_Source.SFButtonMeshVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.adminDomainGrid_Source.SFButtonRefreshVisible = DevExpress.XtraBars.BarItemVisibility.Always;
            this.adminDomainGrid_Source.SFButtonUncheckAllVisible = DevExpress.XtraBars.BarItemVisibility.Always;
            this.adminDomainGrid_Source.SFCheckDomainVisible = true;
            this.adminDomainGrid_Source.SFColInMeshVisible = false;
            this.adminDomainGrid_Source.Size = new System.Drawing.Size(288, 222);
            this.adminDomainGrid_Source.TabIndex = 0;
            this.adminDomainGrid_Source.UserName = null;
            // 
            // colaboratorsAdminGrid1
            // 
            this.colaboratorsAdminGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.colaboratorsAdminGrid1.Location = new System.Drawing.Point(4, 36);
            this.colaboratorsAdminGrid1.Name = "colaboratorsAdminGrid1";
            this.colaboratorsAdminGrid1.Size = new System.Drawing.Size(396, 455);
            this.colaboratorsAdminGrid1.TabIndex = 1;
            this.colaboratorsAdminGrid1.SelectColaboratorEvent += new System.EventHandler(this.colaboratorsAdminGrid1_SelectColaboratorEvent);
            this.colaboratorsAdminGrid1.RefreshColaboratorEvent += new System.EventHandler(this.colaboratorsAdminGrid1_RefreshColaboratorEvent);
            // 
            // AdminDomainsScope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 496);
            this.Controls.Add(this.textFindPopUp1);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.adminDomainGrid_Dest);
            this.Controls.Add(this.adminDomainGrid_Source);
            this.Controls.Add(this.colaboratorsAdminGrid1);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.MinimumSize = new System.Drawing.Size(705, 524);
            this.Name = "AdminDomainsScope";
            this.Text = "Permisos ";
            this.Load += new System.EventHandler(this.AdminDomainsScope_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AdminDomainGrid adminDomainGrid_Source;
        private ColaboratorsAdminGrid colaboratorsAdminGrid1;
        private AdminDomainGrid adminDomainGrid_Dest;
        private DomainFilters domainFilters1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private Allus.Libs.Controls.TextFindPopUp textFindPopUp1;
    }
}