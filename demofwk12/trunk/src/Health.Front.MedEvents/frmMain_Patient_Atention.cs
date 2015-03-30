using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Forms;
using System.Globalization;
using Fwk.UI.Common;
using Fwk.Bases;
using System.Security.Principal;
using Fwk.Caching;
using Health.Back.BE;
using Fwk.UI.Controls.Menu.Tree;
using System.Runtime.Remoting.Messaging;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using Health.BE;
using Health.BE.Enums;

namespace Health.Front
{

    public partial class frmPatientAtencion : Fwk.UI.Forms.FormMDIChildBase
    {
        AppointmentBE _Appointment = null;
        public MedicalEventBE MedicalEvent = null;
        MedicalEventAlert_ViewList _MedicalEventAlert_ViewList = null;
        TreeMenu menu;
        Xtra_UC_Base CurrentControl = null;
        public PatientAllergyBE _PatientAllergy = null;
        PatientMedicament_ViewList _PatientMedicament_ViewList = null;
        public frmPatientAtencion()
        {
            InitializeComponent();
        }
        public frmPatientAtencion(AppointmentBE pAppointmentBE)
        {
            _Appointment = pAppointmentBE;
            InitializeComponent();

           
        }
        public override void Refresh()
        {
            PopulateAsync();

            base.Refresh();

        }
        #region PopulateSync

        /// <summary>
        /// Carga de manera asincrona los Dominios relacionados entre si en la grilla.-
        /// </summary>
        public void PopulateAsync()
        {
            Exception ex = null;
            DelegateWithOutAndRefParameters s = new DelegateWithOutAndRefParameters(Populate);

            s.BeginInvoke(out ex, new AsyncCallback(EndPopulate), null);
        }

        /// <summary>
        /// Fin de el metodo populate que fue llamado de forma asincrona
        /// </summary>
        /// <param name="res"></param>
        void EndPopulate(IAsyncResult res)
        {
            Exception ex;

            if (this.InvokeRequired)
            {
                AsyncCallback d = new AsyncCallback(EndPopulate);
                this.Invoke(d, new object[] { res });
            }
            else
            {
                AsyncResult result = (AsyncResult)res;

                DelegateWithOutAndRefParameters del = (DelegateWithOutAndRefParameters)result.AsyncDelegate;
                del.EndInvoke(out ex, res);
                if (ex != null)
                {
                    if (String.IsNullOrEmpty(ex.Source))
                        ex.Source = "frmPatientAtencion.EndPopulate";
                    this.ExceptionViewer.Show(ex);
                    return;
                }

                StringBuilder s = null;

                #region Datos Patient
                lblDNI.Text = ServiceCalls.CurrentPatient.Persona.NroDocumento;
                lblNombre.Text = ServiceCalls.CurrentPatient.Persona.ApellidoNombre;
                lblEdad.Text = ServiceCalls.CurrentPatient.Persona.GetLabelEdad();
                //TODO: Poner fecha nacimiento
                if (ServiceCalls.CurrentPatient.Persona.Foto == null)
                {
                    this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Clip;
                    if (ServiceCalls.CurrentPatient.Persona.Sexo.Equals((Int16)Sexo.Masculino))
                        pictureEdit1.Image = Health.Front.Base.Properties.Resource.User_M;
                    else
                        pictureEdit1.Image = Health.Front.Base.Properties.Resource.User_F;
                }
                else
                {
                    this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
                    pictureEdit1.Image = Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(ServiceCalls.CurrentPatient.Persona.Foto);
                }
                #endregion

                #region Allergies
                if (_PatientAllergy == null) return;
                {
                    if (!string.IsNullOrEmpty(_PatientAllergy.ToString()))
                    {
                        s = new StringBuilder();
                        btnAlertAllergy.Visible = true;


                        //Establezco los nombres de otras alergias para q se macheen con los ids de OtherAllergy
                        if (!string.IsNullOrEmpty(_PatientAllergy.OtherAllergy))
                        {
                            //Array de Ids
                            _PatientAllergy.OtherAllergy = _PatientAllergy.OtherAllergy.Replace(" ", "");
                            var listOther = _PatientAllergy.OtherAllergy.Split(',').ToList<string>();

                            //MAcheo de array con nombre de otras alergias
                            string[] x = (from p in ServiceCalls.AllergiesItemTypesList where listOther.Contains(p.IdParametro.ToString()) select p.Nombre).ToArray<string>();

                            x.ToList().ForEach(item => s.AppendLine(item));
                            _PatientAllergy.OtherNames = s.ToString();
                            s = null;
                        }
                        lblAllergiesInfo.Text = string.Empty;
                        lblAllergiesInfo.Text = _PatientAllergy.ToString();

                    }


                }

                #endregion

                #region Permanent medicaments


                if (_PatientMedicament_ViewList.Count != 0)
                {

                    s = new StringBuilder("El pasiente esta actualmente medicado: \r\n \r\n");
                    string strMedicamentRecord = "{0} {1} ";
                    _PatientMedicament_ViewList.ForEach(item =>
                    s.AppendLine(string.Format(strMedicamentRecord, item.MedicamentName, item.StatusDescription)));
                    lblAlertMedicament.Text = s.ToString();
                    btnAlertMedicament.Visible = true;
                }

                #endregion


                #region Diagnosis
                if (_MedicalEventAlert_ViewList.Count != 0)
                {

                    s = new StringBuilder("Alerta de diagnosticos: \r\n \r\n");
                    _MedicalEventAlert_ViewList.ForEach(item => s.AppendLine(item.Description));
                    lblAlertDiagnosis.Text = s.ToString();
                    btnAlertdiagnosis.Visible = true;
                }
                #endregion
            }
        }

        /// <summary>
        /// Carga Dominios relacionados entre al objeto _RelatedDomains que esta bindiado a la grilla
        /// </summary>
        void Populate(out Exception ex)
        {
            ex = null;

            try
            {
                _PatientAllergy = ServiceCalls.GetPatientAllergy(ServiceCalls.CurrentPatient.PatientId);
                _PatientMedicament_ViewList = ServiceCalls.RetrivePatientMedicaments(ServiceCalls.CurrentPatient.PatientId, null);
                _MedicalEventAlert_ViewList = ServiceCalls.RetriveMedicalEventAlert(ServiceCalls.CurrentPatient.PatientId,null, false);
                if (MedicalEvent == null)
                {
                    MedicalEvent = new MedicalEventBE();
                    MedicalEvent.MedicalEventId = -1;
                    if (this._Appointment != null)
                        MedicalEvent.AppointmentId = this._Appointment.AppointmentId;


                    MedicalEvent.ProfesionalId = ServiceCalls.CurrentProfesional.IdProfesional;
                    MedicalEvent.IdEspesialidad = ServiceCalls.CurrentProfesional.IdEspecialidad.Value;
                    MedicalEvent.PatientId = ServiceCalls.CurrentPatient.PatientId;
                    MedicalEvent.PatientMedicaments = _PatientMedicament_ViewList;
                    MedicalEvent.HealthInstitutionId = ServiceCalls.CurrentHealthInstitution.HealthInstitutionId;

                    MedicalEvent.MedicalEventId = ServiceCalls.CreateMedicalEvent(MedicalEvent);
                }
                else
                {
                    MedicalEvent.PatientMedicaments = _PatientMedicament_ViewList;
                }

            }
            catch (Exception err)
            {
                err.Source = "Origen de datos";
                ex = err;
            }
        }

        #endregion


        void LoadMenuFile()
        {
            try
            {
                treeList2.BeginUpdate();
                menu = Health.Front.Bases.Helper.LoadMenuFromFile(@"dat\m_patient.xml");
                this.treeMenuBindingSource.DataSource = menu.ItemList;


                treeList2.RefreshDataSource();
                treeList2.EndUpdate();

        
            }
            catch (InvalidOperationException e)
            {
                ExceptionViewer.Show(e);
            }
            catch (Exception ex2)
            {
                ExceptionViewer.Show(ex2);
            }
        }

        System.Collections.Generic.List<string> controls = new List<string>();
        void AddContronToPannel(Fwk.UI.Controls.Menu.Tree.MenuItem item, object obj)
        {
            using (WaitCursorHelper w = new WaitCursorHelper(this))
            {
                Xtra_UC_Base ctrl = null;
                Type T = Fwk.HelperFunctions.ReflectionFunctions.CreateType(item.AssemblyInfo);

                if (!controls.Contains(string.Concat(T.Name, item.ID)))
                {
                    ctrl = (Xtra_UC_Base)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(item.AssemblyInfo);

                    ctrl.Tag = item.Tag;
                    ctrl.Key = string.Concat(T.Name, item.ID);

                    this.panelControl1.Controls.Add(ctrl);
                    controls.Add(ctrl.Key);
                    ctrl.Dock = System.Windows.Forms.DockStyle.Fill;
                    ctrl.OnExitControlEvent += new EventHandler(ctrl_OnExitControlEvent);
                    ctrl.Populate(obj);

                    //ctrl.Populate(null);
                }
                else
                {
                    int i = this.panelControl1.Controls.IndexOfKey(T.Name);
                    ctrl = (Xtra_UC_Base)this.panelControl1.Controls[i];
                }
                btnClose.Visible = ctrl.ShowClose;
                btnSaveChanges.Visible = ctrl.ShowSave;
                CurrentControl = ctrl;
                ctrl.BringToFront();
                ctrl.Refresh();
            }
        }

        void RemoveControlFromPannel(Xtra_UC_Base ctrl)
        {

            if (ctrl != null)
            {
                ctrl.Exit();
                if (this.panelControl1.Contains(ctrl))
                {
                    this.panelControl1.Controls.Remove(ctrl);
                    controls.Remove(ctrl.Key);
                    if (this.panelControl1.Controls.Count != 0)
                    {
                        using (WaitCursorHelper w = new WaitCursorHelper(this))
                        {
                            btnClose.Visible = ctrl.ShowClose;
                            btnSaveChanges.Visible = ctrl.ShowSave;
                            ctrl = (Xtra_UC_Base)this.panelControl1.Controls[0];
                            ctrl.Refresh();
                        }
                    }
                }
            }



        }

        void ctrl_OnExitControlEvent(object sender, EventArgs e)
        {
            if (this.panelControl1.Contains((Xtra_UC_Base)sender))
            {
                RemoveControlFromPannel((Xtra_UC_Base)sender);
                //this.panelControl1.Controls.Remove((Xtra_UC_Base)sender);
            }
        }

        private void treeList2_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            if (e.Node == null) return;
            Fwk.UI.Controls.Menu.Tree.MenuItem item = (Fwk.UI.Controls.Menu.Tree.MenuItem)treeList2.GetDataRecordByNode(e.Node);
            if (!String.IsNullOrEmpty(item.AssemblyInfo))
            {
                if(FormBase.CheckRule(item.AuthRule))
                {
                    AddContronToPannel(item, null);
                }
            }
        }

        private void treeList2_KeyDown(object sender, KeyEventArgs e)
        {
            TreeList tl = sender as TreeList;
            if (tl.FocusedNode != null)
            {
                if (e.KeyCode == Keys.Right)
                {
                    if (!tl.FocusedNode.Expanded && tl.FocusedNode.HasChildren)
                        tl.FocusedNode.Expanded = true;
                    else tl.MoveNextVisible();
                }
                if (e.KeyCode == Keys.Left)
                {
                    if (tl.FocusedNode.Expanded)
                        tl.FocusedNode.Expanded = false;
                    else tl.MovePrevVisible();
                }
            }
        }

        private void treeList2_MouseClick(object sender, MouseEventArgs e)
        {
            TreeList tl = sender as TreeList;
            if (tl.FocusedNode != null)
                if (tl.FocusedNode.HasChildren)
                    tl.FocusedNode.Expanded = !tl.FocusedNode.Expanded;
        }


        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (CurrentControl != null)
                using (WaitCursorHelper c = new WaitCursorHelper(this))
                {
                    CurrentControl.AceptChanges(false);
                }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
 
                this.Close();
        
        }

        public DialogResult CheckCloseForm()
        {   
            string str = string.Concat("Finalizar la atencion de ", ServiceCalls.CurrentPatient.Persona.ApellidoNombre, "?");
            this.MessageViewer.Title = "Atención de pacientes";
            this.MessageViewer.MessageBoxButtons = MessageBoxButtons.YesNo;
            this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Question;
         
            DialogResult res = this.MessageViewer.Show(str);
            this.SetMessageViewInfoDefault();
            if (CurrentControl != null)
                using (WaitCursorHelper c = new WaitCursorHelper(this))
                {
                    //al pasarle true en AceptChanges, no se llama metodo estatico PopulateAsync que es innecesario dado q cera cerrado este formulario
                    CurrentControl.AceptChanges(true);
                }

            return res;

        }

        /// <summary>
        /// Se llama a este metodo desde algun control hijo
        /// </summary>
        /// <param name="control"></param>
       public static void PopulateAsync(Control control)
       {
           if (control.Parent.GetType() == typeof(frmPatientAtencion))
               ((frmPatientAtencion)control.Parent).PopulateAsync();
           else
               PopulateAsync(control.Parent);
       }

        /// <summary>
        /// Obtiene el formulario padre
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
       public static frmPatientAtencion GetInstance(Control control)
        {
            if (control.Parent.GetType() == typeof(frmPatientAtencion))
                return ((frmPatientAtencion)control.Parent);
            else
                return GetInstance(control.Parent);

        }

        private void frmPatientAtencion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (CurrentControl != null)
                    using (WaitCursorHelper c = new WaitCursorHelper(this))
                    {
                        CurrentControl.Refresh();
                    }
            }
        }

        private void frmPatientAtencion_Load(object sender, EventArgs e)
        {
         
            LoadMenuFile();

            //treeList2.Nodes[0].ExpandAll()treeList2.FocusedNode.ExpandAll();

           
        }

        private void frmPatientAtencion_Leave(object sender, EventArgs e)
        {
            if (_Appointment != null)
            {
                _Appointment.Status = (int)AppoimantsStatus_SP.Cerrado;
                try
                {
                    ServiceCalls.UpdateAppoimentStatus(_Appointment);
                }
                catch (Exception ex)
                {
                    this.ExceptionViewer.Show(ex);
                }
            }
            
        }

        private void treeList2_NodeCellStyle(object sender, GetCustomNodeCellStyleEventArgs e)
        {

            if (e.Column.FieldName != "DisplayName") return;

            Fwk.UI.Controls.Menu.Tree.MenuItem m = (Fwk.UI.Controls.Menu.Tree.MenuItem)treeList2.GetDataRecordByNode(e.Node);
            if (String.IsNullOrEmpty(m.AuthorizationRuleName)) return;

            if (!FormBase.CheckRule(m.AuthorizationRuleName))
            {
                //e.Appearance.BackColor = Color.FromArgb(80, 255, 0, 255);
                e.Appearance.ForeColor = Color.Gray;
                
                //e.Appearance.Font = new Font(e.Appearance.Font, FontStyle.Bold);
            }

        }

        
    }
    
}