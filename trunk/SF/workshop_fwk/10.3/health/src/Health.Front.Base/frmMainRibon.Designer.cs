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
            this.iCrearPaciente = new DevExpress.XtraBars.BarButtonItem();
            this.iNuevoMedico = new DevExpress.XtraBars.BarButtonItem();
            this.iVademecum = new DevExpress.XtraBars.BarButtonItem();
            this.iSendMail = new DevExpress.XtraBars.BarButtonItem();
            this.iBuscar = new DevExpress.XtraBars.BarButtonItem();
            this.iVademecumImport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonGroup1 = new DevExpress.XtraBars.BarButtonGroup();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.iAgenda = new DevExpress.XtraBars.BarButtonItem();
            this.rbPagePaciente = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.iNuevaAtencion = new DevExpress.XtraBars.BarButtonItem();
            this.rbnpGroupLinks = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnPageAdministrcion = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.rbnpGroupPersonas = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
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
            this.iCrearPaciente,
            this.iNuevoMedico,
            this.iVademecum,
            this.iSendMail,
            this.iBuscar,
            this.iVademecumImport,
            this.barButtonItem1,
            this.barButtonGroup1,
            this.barButtonItem2,
            this.barButtonItem4,
            this.iAgenda});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ribbonControl1.MaxItemId = 13;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageCategoryAlignment = DevExpress.XtraBars.Ribbon.RibbonPageCategoryAlignment.Right;
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rbPagePaciente,
            this.rbnPageAdministrcion,
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(1042, 155);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.TransparentEditors = true;
            // 
            // iCrearPaciente
            // 
            this.iCrearPaciente.Caption = "Nuevo paciente";
            this.iCrearPaciente.Glyph = global::Health.Front.Properties.Resources.vcard;
            this.iCrearPaciente.Id = 130;
            this.iCrearPaciente.LargeGlyph = global::Health.Front.Properties.Resources.patient_add_32;
            this.iCrearPaciente.Name = "iCrearPaciente";
            this.iCrearPaciente.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iCrearPaciente_ItemClick);
            // 
            // iNuevoMedico
            // 
            this.iNuevoMedico.Caption = "Nuevo profecional";
            this.iNuevoMedico.Glyph = global::Health.Front.Properties.Resources.doctor_add_32;
            this.iNuevoMedico.Id = 131;
            this.iNuevoMedico.LargeGlyph = global::Health.Front.Properties.Resources.doctor_add_32;
            this.iNuevoMedico.Name = "iNuevoMedico";
            this.iNuevoMedico.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iNuevoMedico_ItemClick);
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
            // 
            // iBuscar
            // 
            this.iBuscar.Caption = "Buscar ";
            this.iBuscar.Glyph = global::Health.Front.Properties.Resources.file_find_Large;
            this.iBuscar.Id = 6;
            this.iBuscar.LargeGlyph = global::Health.Front.Properties.Resources.file_find_Large;
            this.iBuscar.Name = "iBuscar";
            this.iBuscar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iBuscar_ItemClick);
            // 
            // iVademecumImport
            // 
            this.iVademecumImport.Caption = "Vademecum Settings";
            this.iVademecumImport.Glyph = global::Health.Front.Properties.Resources.Shopping_Chart;
            this.iVademecumImport.Id = 7;
            this.iVademecumImport.Name = "iVademecumImport";
            this.iVademecumImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iVademecumImport_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Profecionales";
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.LargeGlyph = global::Health.Front.Properties.Resources.group_32;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonGroup1
            // 
            this.barButtonGroup1.Caption = "barButtonGroup1";
            this.barButtonGroup1.Id = 9;
            this.barButtonGroup1.Name = "barButtonGroup1";
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
            this.iAgenda.LargeGlyph = global::Health.Front.Properties.Resources.appointment_scheduler_clock_48;
            this.iAgenda.Name = "iAgenda";
            this.iAgenda.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iAgenda_ItemClick);
            // 
            // rbPagePaciente
            // 
            this.rbPagePaciente.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.rbnpGroupLinks,
            this.ribbonPageGroup4});
            this.rbPagePaciente.Name = "rbPagePaciente";
            this.rbPagePaciente.Text = "Paciente";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.iNuevaAtencion);
            this.ribbonPageGroup1.ItemLinks.Add(this.iBuscar);
            this.ribbonPageGroup1.ItemLinks.Add(this.iSendMail);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // iNuevaAtencion
            // 
            this.iNuevaAtencion.Caption = "Gestionar";
            this.iNuevaAtencion.Hint = "Crea un nuevo documento";
            this.iNuevaAtencion.Id = 105;
            this.iNuevaAtencion.LargeGlyph = global::Health.Front.Properties.Resources.medical_history_pen_48;
            this.iNuevaAtencion.LargeImageIndex = 0;
            this.iNuevaAtencion.Name = "iNuevaAtencion";
            this.iNuevaAtencion.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.iNuevaAtencion_ItemClick);
            // 
            // rbnpGroupLinks
            // 
            this.rbnpGroupLinks.AllowTextClipping = false;
            this.rbnpGroupLinks.ItemLinks.Add(this.iVademecum);
            this.rbnpGroupLinks.ItemLinks.Add(this.iVademecumImport);
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
            this.ribbonPageGroup3});
            this.rbnPageAdministrcion.Name = "rbnPageAdministrcion";
            this.rbnPageAdministrcion.Text = "Administracion";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup2.ItemLinks.Add(this.iAgenda);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Gestion profecional";
            // 
            // rbnpGroupPersonas
            // 
            this.rbnpGroupPersonas.AllowTextClipping = false;
            this.rbnpGroupPersonas.ItemLinks.Add(this.iCrearPaciente);
            this.rbnpGroupPersonas.ItemLinks.Add(this.iNuevoMedico);
            this.rbnpGroupPersonas.ItemLinks.Add(this.barButtonGroup1);
            this.rbnpGroupPersonas.Name = "rbnpGroupPersonas";
            this.rbnpGroupPersonas.Text = "Acceso rapido";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItem2);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
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
            // frmMainRibon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 662);
            this.Controls.Add(this.ribbonControl1);
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
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbPagePaciente;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rbnPageAdministrcion;
        private DevExpress.XtraBars.BarButtonItem iNuevaAtencion;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnpGroupPersonas;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraBars.BarButtonItem iCrearPaciente;
        private DevExpress.XtraBars.BarButtonItem iNuevoMedico;
        private DevExpress.XtraBars.BarButtonItem iVademecum;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rbnpGroupLinks;
        private DevExpress.XtraBars.BarButtonItem iSendMail;
        private DevExpress.XtraBars.BarButtonItem iBuscar;
        private DevExpress.XtraBars.BarButtonItem iVademecumImport;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonGroup barButtonGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem iAgenda;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        

    }
}