namespace Health.Front
{
    partial class frmMainRibon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainRibon));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.iCreatePatient = new DevExpress.XtraBars.BarButtonItem();
            this.iCreateProfesional = new DevExpress.XtraBars.BarButtonItem();
            this.iVademecum = new DevExpress.XtraBars.BarButtonItem();
            this.iSendMail = new DevExpress.XtraBars.BarButtonItem();
            this.iFindPatients = new DevExpress.XtraBars.BarButtonItem();
            this.iProfesionales = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.iAgenda = new DevExpress.XtraBars.BarButtonItem();
            this.iAgendas = new DevExpress.XtraBars.BarButtonItem();
            this.iCEI_10 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            this.iAboutHealth = new DevExpress.XtraBars.BarButtonItem();
            this.iClearCache = new DevExpress.XtraBars.BarButtonItem();
            this.rbPagePatient = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.iNuevaAtencion = new DevExpress.XtraBars.BarButtonItem();
            this.rbnpGroupLinks = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnPageAdministrcion = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnpGroupPersonas = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.group_Settings = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.statusBarItem_Usuario = new DevExpress.XtraBars.BarStaticItem();
            this.statusBarItem_Especialidad = new DevExpress.XtraBars.BarStaticItem();
            this.iHealtInst_Info = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonText = null;
            // 
            // 
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.ExpandCollapseItem.Name = "";
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.iCreatePatient,
            this.iCreateProfesional,
            this.iVademecum,
            this.iSendMail,
            this.iFindPatients,
            this.iProfesionales,
            this.barButtonItem2,
            this.barButtonItem4,
            this.iAgenda,
            this.iAgendas,
            this.iCEI_10,
            this.barButtonItem6,
            this.barButtonItem7,
            this.iAboutHealth,
            this.iClearCache});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 22;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageCategoryAlignment = DevExpress.XtraBars.Ribbon.RibbonPageCategoryAlignment.Right;
            this.ribbonControl1.PageHeaderItemLinks.Add(this.iAboutHealth);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbPagePatient,
            this.rbnPageAdministrcion,
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1042, 155);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.TransparentEditors = true;
            // 
            // iCreatePatient
            // 
            this.iCreatePatient.Caption = "Nuevo Paciente";
            this.iCreatePatient.Glyph = global::Health.Front.Properties.Resources.vcard_48;
            this.iCreatePatient.Id = 130;
            this.iCreatePatient.LargeGlyph = global::Health.Front.Properties.Resources.patient_add_32;
            this.iCreatePatient.Name = "iCreatePatient";
            this.iCreatePatient.Tag = "admin_patients_abm";
            this.iCreatePatient.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCrearPatient_ItemClick);
            // 
            // iCreateProfesional
            // 
            this.iCreateProfesional.Caption = "Nuevo profesional";
            this.iCreateProfesional.Glyph = global::Health.Front.Properties.Resources.doctor_add_32;
            this.iCreateProfesional.Id = 131;
            this.iCreateProfesional.LargeGlyph = global::Health.Front.Properties.Resources.doctor_add_32;
            this.iCreateProfesional.Name = "iCreateProfesional";
            this.iCreateProfesional.Tag = "admin_professional_abm";
            this.iCreateProfesional.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iNuevoMedico_ItemClick);
            // 
            // iVademecum
            // 
            this.iVademecum.Caption = "Vademecum";
            this.iVademecum.Glyph = global::Health.Front.Properties.Resources.link;
            this.iVademecum.Id = 4;
            this.iVademecum.Name = "iVademecum";
            this.iVademecum.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iVademecum_ItemClick);
            // 
            // iSendMail
            // 
            this.iSendMail.Caption = "Mail";
            this.iSendMail.Glyph = global::Health.Front.Properties.Resources.Send_Mail_24;
            this.iSendMail.Id = 5;
            this.iSendMail.LargeGlyph = global::Health.Front.Properties.Resources.Send_Mail_16;
            this.iSendMail.Name = "iSendMail";
            this.iSendMail.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iSendMail_ItemClick);
            // 
            // iFindPatients
            // 
            this.iFindPatients.Caption = "Buscar pacientes";
            this.iFindPatients.Glyph = global::Health.Front.Properties.Resources.file_find_Large;
            this.iFindPatients.Id = 6;
            this.iFindPatients.LargeGlyph = global::Health.Front.Properties.Resources.file_find_Large;
            this.iFindPatients.Name = "iFindPatients";
            this.iFindPatients.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iBuscar_ItemClick);
            // 
            // iProfesionales
            // 
            this.iProfesionales.Caption = "Profesionales";
            this.iProfesionales.Id = 8;
            this.iProfesionales.LargeGlyph = global::Health.Front.Properties.Resources.group_32;
            this.iProfesionales.Name = "iProfesionales";
            this.iProfesionales.Tag = "";
            this.iProfesionales.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Cerrar";
            this.barButtonItem2.Id = 10;
            this.barButtonItem2.LargeGlyph = global::Health.Front.Properties.Resources.close_32;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Cerrar";
            this.barButtonItem4.Id = 11;
            this.barButtonItem4.LargeGlyph = global::Health.Front.Properties.Resources.close_24;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // iAgenda
            // 
            this.iAgenda.Caption = "Agenda";
            this.iAgenda.Id = 12;
            this.iAgenda.LargeGlyph = global::Health.Front.Properties.Resources.doctor_clock_48;
            this.iAgenda.Name = "iAgenda";
            this.iAgenda.Tag = "atencion_ingreso";
            this.iAgenda.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iAgenda_ItemClick);
            // 
            // iAgendas
            // 
            this.iAgendas.Caption = "Agendas";
            this.iAgendas.Id = 13;
            this.iAgendas.LargeGlyph = global::Health.Front.Properties.Resources.appointment_scheduler_clock_48;
            this.iAgendas.Name = "iAgendas";
            this.iAgendas.Tag = "agenda_ingresar";
            this.iAgendas.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iAgendas_ItemClick);
            // 
            // iCEI_10
            // 
            this.iCEI_10.Caption = "CEI 10";
            this.iCEI_10.Id = 14;
            this.iCEI_10.LargeGlyph = global::Health.Front.Properties.Resources.cei10;
            this.iCEI_10.Name = "iCEI_10";
            this.iCEI_10.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCEI_10_ItemClick);
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "Estadistica 1";
            this.barButtonItem6.Id = 18;
            this.barButtonItem6.Name = "barButtonItem6";
            // 
            // barButtonItem7
            // 
            this.barButtonItem7.Caption = "Circulos";
            this.barButtonItem7.Id = 19;
            this.barButtonItem7.Name = "barButtonItem7";
            // 
            // iAboutHealth
            // 
            this.iAboutHealth.Caption = "Acerca de";
            this.iAboutHealth.Glyph = global::Health.Front.Properties.Resources.registry_clock_32;
            this.iAboutHealth.Id = 20;
            this.iAboutHealth.Name = "iAboutHealth";
            this.iAboutHealth.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnAboutHealth_ItemClick);
            // 
            // iClearCache
            // 
            this.iClearCache.Caption = "Eliminar datos temporales";
            this.iClearCache.Glyph = global::Health.Front.Properties.Resources.patient_cancel_32;
            this.iClearCache.Id = 21;
            this.iClearCache.Name = "iClearCache";
            this.iClearCache.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnClearCache_ItemClick);
            // 
            // rbPagePatient
            // 
            this.rbPagePatient.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.rbnpGroupLinks,
            this.ribbonPageGroup4});
            this.rbPagePatient.Name = "rbPagePatient";
            this.rbPagePatient.Text = "Atención";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.iAgenda);
            this.ribbonPageGroup1.ItemLinks.Add(this.iNuevaAtencion);
            this.ribbonPageGroup1.ItemLinks.Add(this.iSendMail);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // iNuevaAtencion
            // 
            this.iNuevaAtencion.Caption = "Consultar historia";
            this.iNuevaAtencion.Id = 105;
            this.iNuevaAtencion.LargeGlyph = global::Health.Front.Properties.Resources.medical_history_pen_48;
            this.iNuevaAtencion.LargeImageIndex = 0;
            this.iNuevaAtencion.Name = "iNuevaAtencion";
            this.iNuevaAtencion.Tag = "atencion_ingreso";
            this.iNuevaAtencion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iNuevaAtencion_ItemClick);
            // 
            // rbnpGroupLinks
            // 
            this.rbnpGroupLinks.AllowTextClipping = false;
            this.rbnpGroupLinks.ItemLinks.Add(this.iVademecum);
            this.rbnpGroupLinks.ItemLinks.Add(this.iCEI_10);
            this.rbnpGroupLinks.Name = "rbnpGroupLinks";
            this.rbnpGroupLinks.ShowCaptionButton = false;
            this.rbnpGroupLinks.Text = "Links de interes";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.AllowTextClipping = false;
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItem4);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "     ";
            // 
            // rbnPageAdministrcion
            // 
            this.rbnPageAdministrcion.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.rbnpGroupPersonas,
            this.ribbonPageGroup5,
            this.ribbonPageGroup3});
            this.rbnPageAdministrcion.Name = "rbnPageAdministrcion";
            this.rbnPageAdministrcion.Text = "Administracion";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.iAgendas);
            this.ribbonPageGroup2.ItemLinks.Add(this.iProfesionales);
            this.ribbonPageGroup2.ItemLinks.Add(this.iCreateProfesional);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Gestion profesional";
            // 
            // rbnpGroupPersonas
            // 
            this.rbnpGroupPersonas.AllowTextClipping = false;
            this.rbnpGroupPersonas.ItemLinks.Add(this.iCreatePatient);
            this.rbnpGroupPersonas.ItemLinks.Add(this.iFindPatients);
            this.rbnpGroupPersonas.Name = "rbnpGroupPersonas";
            this.rbnpGroupPersonas.Text = "Gestion de pacientes";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Profecionales";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.group_Settings});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Configuracion";
            // 
            // group_Settings
            // 
            this.group_Settings.ItemLinks.Add(this.iClearCache);
            this.group_Settings.Name = "group_Settings";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "help.png");
            this.imageList1.Images.SetKeyName(1, "remove-window.png");
            this.imageList1.Images.SetKeyName(2, "save.png");
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Cerrar";
            this.barButtonItem3.Id = 10;
            this.barButtonItem3.LargeGlyph = global::Health.Front.Properties.Resources.close_32;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.statusBarItem_Usuario,
            this.statusBarItem_Especialidad,
            this.iHealtInst_Info});
            this.barManager1.MaxItemId = 5;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1,
            this.repositoryItemTextEdit1});
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.statusBarItem_Usuario),
            new DevExpress.XtraBars.LinkPersistInfo(this.statusBarItem_Especialidad),
            new DevExpress.XtraBars.LinkPersistInfo(this.iHealtInst_Info)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // statusBarItem_Usuario
            // 
            this.statusBarItem_Usuario.Caption = "Usuario:";
            this.statusBarItem_Usuario.Glyph = global::Health.Front.Properties.Resources.vcard_16;
            this.statusBarItem_Usuario.Id = 2;
            this.statusBarItem_Usuario.Name = "statusBarItem_Usuario";
            this.statusBarItem_Usuario.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.statusBarItem_Usuario.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // statusBarItem_Especialidad
            // 
            this.statusBarItem_Especialidad.Caption = "Especialidad:";
            this.statusBarItem_Especialidad.Glyph = global::Health.Front.Properties.Resources.sym_contact_card__2_;
            this.statusBarItem_Especialidad.Id = 3;
            this.statusBarItem_Especialidad.Name = "statusBarItem_Especialidad";
            this.statusBarItem_Especialidad.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.statusBarItem_Especialidad.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // iHealtInst_Info
            // 
            this.iHealtInst_Info.Caption = "Institución";
            this.iHealtInst_Info.Description = "Informacion de la institución";
            this.iHealtInst_Info.Glyph = global::Health.Front.Properties.Resources.sym_contact_card__2_;
            this.iHealtInst_Info.Id = 4;
            this.iHealtInst_Info.Name = "iHealtInst_Info";
            this.iHealtInst_Info.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.iHealtInst_Info.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHealtInst_Info_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlTop.Size = new System.Drawing.Size(1042, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 631);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlBottom.Size = new System.Drawing.Size(1042, 31);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 631);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1042, 0);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 631);
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "Agenda";
            this.barButtonItem5.Id = 12;
            this.barButtonItem5.LargeGlyph = global::Health.Front.Properties.Resources.appointment_scheduler_clock_48;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // popupMenu1
            // 
            this.popupMenu1.ItemLinks.Add(this.iClearCache);
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbonControl1;
            // 
            // frmMainRibon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 662);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMainRibon";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Health Record 2012";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainRibon_Load);
            this.MdiChildActivate += new System.EventHandler(this.frmMainRibon_MdiChildActivate);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbPagePatient;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageAdministrcion;
        private DevExpress.XtraBars.BarButtonItem iNuevaAtencion;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnpGroupPersonas;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem iCreatePatient;
        private DevExpress.XtraBars.BarButtonItem iCreateProfesional;
        private DevExpress.XtraBars.BarButtonItem iVademecum;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnpGroupLinks;
        private DevExpress.XtraBars.BarButtonItem iSendMail;
        private DevExpress.XtraBars.BarButtonItem iFindPatients;

        private DevExpress.XtraBars.BarButtonItem iProfesionales;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem iAgenda;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarStaticItem statusBarItem_Usuario;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem iAgendas;
        private DevExpress.XtraBars.BarButtonItem iCEI_10;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup group_Settings;
        private DevExpress.XtraBars.BarStaticItem statusBarItem_Especialidad;
        private DevExpress.XtraBars.BarButtonItem iAboutHealth;
        private DevExpress.XtraBars.BarButtonItem iHealtInst_Info;
        private DevExpress.XtraBars.BarButtonItem iClearCache;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        

    }
}