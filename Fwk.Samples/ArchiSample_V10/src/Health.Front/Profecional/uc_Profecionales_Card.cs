using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Isvc.GetProfesional;
using Health.Back.BE;
using Health.Entities;
using Health.Front.Scheduler;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Fwk.Bases;
using Fwk.Security.Common;
using Fwk.UI.Controller;
using Fwk.UI.Forms;
using Health.BE;
using Health.BE.Enums;

namespace Health.Front.profesional
{
    [ToolboxItem(true)]
    public partial class uc_Profesionales_Card : Xtra_UC_Base
    {

        internal ProfesionalBE profesionalBE = null;
        String[] profesionalRolList = null;
        ResourceSchedulingBE currentShiftSheduling = null;
        ResourceSchedulingList resourceSchedulingList = null;

        ParametroList _EspecialidadList = new ParametroList();

        public uc_Profesionales_Card()
        {
            InitializeComponent();

            txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            txtMatricula.RightToLeft = System.Windows.Forms.RightToLeft.No;
        }

        public void Init()
        {
            uc_Persona1.Init();

            cmbProfecion.Properties.DataSource = Controller.ProfecionesList;

            _EspecialidadList.AddRange(Controller.EspecialidadMedicaList.Where<ParametroBE>(p => p.IdParametro != (int)CommonValuesEnum.TodosComboBoxValue));

            cmbEspecialidad.Properties.DataSource = _EspecialidadList;
            cmbEspecialidad.Refresh();
            if (SecurityController.AllRolList == null)
                SecurityController.RefreshSecurity();

            var list = from rol in SecurityController.AllRolList where rol.RolName.StartsWith("inst_") select rol.RolName;
            lstBoxRoles.Items.AddRange(list.ToArray());

            lstBoxRoles.Refresh();

            base.Refresh();

            btnCrearResourceScheduling.Enabled = gridControl1.Enabled = FormBase.CheckRule("admin_professional_sheduling");

            btnResetPwd.Enabled = FormBase.CheckRule("admin_users_change_security");
            if (this.State == EntityUpdateEnum.UPDATED)
                lstBoxRoles.Enabled = FormBase.CheckRule("admin_users_change_security");
            else
                lstBoxRoles.Enabled = FormBase.CheckRule("admin_professional_abm");

            uc_MedioContacto1.Enabled = panelControl2.Enabled = uc_Persona1.Enabled = FormBase.CheckRule("admin_professional_abm");

            //Las reglas se comtinuan validando en el Populate dado q tambien dependen del profesional consultado
           
        }


        /// <summary>
        /// Se produce despues de Load (uc_Profesionales_Card_Load) y 
        /// Antes del load del formujlario
        /// </summary>
        /// <param name="idProfesional"></param>
        /// <param name="state"></param>
        internal void Populate(int idProfesional, EntityUpdateEnum state)
        {
            //El prof puede modificar sus propios datos
            if (idProfesional.Equals(Controller.CurrentProfesional.IdProfesional))
            {
                uc_MedioContacto1.Enabled = panelControl2.Enabled = uc_Persona1.Enabled = true;
            }

            this.State = state;
            if (State == Fwk.Bases.EntityUpdateEnum.NEW)
            {
                profesionalBE = new ProfesionalBE();
                profesionalBE.Persona = new PersonaBE();
                this.lblTitle.Text = "Alta de profesional";
            }

            if (State == Fwk.Bases.EntityUpdateEnum.UPDATED || State == Fwk.Bases.EntityUpdateEnum.NONE)
            {
                btnCheckUserName.Enabled = false;
                txtUsername.Properties.ReadOnly = true;
                GetProfesionalRes res = Controller.GetProfesional(idProfesional, true, true,false,null,Controller.CurrentHealthInstitution.HealthInstitutionId);

                profesionalBE = res.BusinessData.profesional;
                resourceSchedulingList = res.BusinessData.ResourceSchedulerList;
                profesionalRolList = res.BusinessData.User.Roles;
                
                this.lblTitle.Text = String.Concat("Targeta del profesional", "  ", profesionalBE.Persona.ApellidoNombre);
            }

            uc_Persona1.Populate(profesionalBE.Persona, State);
            txtUsername.Text = profesionalBE.UserName;
            txtMatricula.Text = profesionalBE.Matricula;
            schedulerShiftBindingSource.DataSource = resourceSchedulingList;
            gridView1.RefreshData();


            //cmbEspecialidad.Properties.DataSource = _EspecialidadList.Where(p => p.IdParametroRef.Equals(profesionalBE.IdProfesion));

            int index = 0;
            index = cmbEspecialidad.Properties.GetDataSourceRowIndex("IdParametro", (int)CommonValuesEnum.Ninguno);
            if (State == Fwk.Bases.EntityUpdateEnum.NEW)
            {
                cmbEspecialidad.ItemIndex = index;
                cmbProfecion.ItemIndex = 0;
            }
            else
            {
                if (profesionalBE.IdEspecialidad.HasValue)
                {
                    index = cmbEspecialidad.Properties.GetDataSourceRowIndex("IdParametro", profesionalBE.IdEspecialidad);
                }
                cmbEspecialidad.ItemIndex = index;
                
                index = cmbProfecion.Properties.GetDataSourceRowIndex("IdParametro", profesionalBE.IdProfesion);
                cmbProfecion.ItemIndex = index;
            }

            cmbEspecialidad.Refresh();
            cmbProfecion.Refresh();

            MachRolesGrid(profesionalRolList);



            uc_MedioContacto1.Persona = profesionalBE.Persona;
            uc_Persona1.Refresh();
            uc_MedioContacto1.Init();
            this.cmbProfecion.EditValueChanged += new System.EventHandler(this.cmbProfecion_EditValueChanged);
        }


        private void uc_Profesionales_Card_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            this.Init();


        }

        #region Roles
        /// <summary>
        /// Chequea los roles del usuario en la lista
        /// </summary>
        /// <param name="roles">Actual roles de usuario</param>
        void MachRolesGrid(string[] roles)
        {
            if (roles == null) return;
            lstBoxRoles.UnCheckAll();
            
            foreach (Rol lstRol in SecurityController.AllRolList.Where(r=>r.RolName.StartsWith("inst_")))
            {
                if (roles.Any(p => p.Equals(lstRol.RolName)))
                {
                    int i = lstBoxRoles.FindString(lstRol.RolName);
                    object odj = lstBoxRoles.GetItem(i);
                    lstBoxRoles.SetItemChecked(i, true);

                }
            }
        }

        /// <summary>
        /// Chequea todos los roles del usuario en la grilla
        /// </summary>
        /// <returns></returns>
        List<String> GetCheckedRolList()
        {
            List<String> wNewRolList = new List<string>();
            foreach (object obj in lstBoxRoles.CheckedItems)
            {
                wNewRolList.Add(obj.ToString());
            }
            return wNewRolList;
        }

        /// <summary>
        /// Determina si se modificaron los roles del usuario
        /// </summary>
        /// <returns>False No change</returns>
        bool CheckRolesChanged()
        {
            List<String> checkedRolList = GetCheckedRolList();
            foreach (string lstRol in profesionalRolList)
            {
                if (!checkedRolList.Contains(lstRol))
                    return true;
            }
            return false;
        }

        private void lstBoxRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rol= lstBoxRoles.Items[lstBoxRoles.SelectedIndex].ToString();

            lblRolDescription.Text= SecurityController.AllRolList.Where(r => r.RolName.Equals(rol)).FirstOrDefault().Description;
        }
        #endregion


        private void btnCrearResourceScheduling_Click(object sender, EventArgs e)
        {
            CreateResourceScheduling(null);

        }

        private void CreateResourceScheduling(ResourceSchedulingBE currentShiftSheduling)
        {
            using (frmResouceScheduling frm = new frmResouceScheduling(profesionalBE.IdProfesional))
            {
                if (this.resourceSchedulingList == null)
                    this.resourceSchedulingList = new ResourceSchedulingList();

                if (currentShiftSheduling != null)
                {
                    frm.SchedulerShift = currentShiftSheduling;
                    frm.State = Fwk.Bases.EntityUpdateEnum.UPDATED;
                }
                else
                    frm.State = Fwk.Bases.EntityUpdateEnum.NEW;

                frm.ResourceSchedulingList = resourceSchedulingList;

                
                if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    frm.SchedulerShift.EntityState = Fwk.Bases.EntityState.Added;

                    if( frm.State == Fwk.Bases.EntityUpdateEnum.NEW)
                    {
                        frm.SchedulerShift.ResourceId = profesionalBE.IdProfesional;
                        resourceSchedulingList.Add(frm.SchedulerShift);
                        schedulerShiftBindingSource.DataSource = resourceSchedulingList;
                    }
                        

                    
                    gridControl1.RefreshDataSource();
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HasErrors()
        {
            dxErrorProvider1.ClearErrors();

            if (String.IsNullOrEmpty(txtMatricula.Text))
            {
                dxErrorProvider1.SetError(txtMatricula, "Ingerse matrícula");
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
                return dxErrorProvider1.HasErrors;
            }

            if (cmbEspecialidad.EditValue == null)
            {
                dxErrorProvider1.SetError(cmbEspecialidad, "Debe seleccionar especialidad");
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
                return dxErrorProvider1.HasErrors;
            }

            #region Inicio sesion
           
            if (this.State == EntityUpdateEnum.NEW)
            {
                try
                {
                    bool exist = Fwk.UI.Controller.SecurityController.ValidateUserExist(txtUsername.Text.Trim());

                    if (exist)
                    {
                        dxErrorProvider1.SetError(txtUsername, "El nombre de usuario ya se encuentra registrado \r\n por favor elija otro", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                        txtUsername.SelectAll();
                        xtraTabControl1.SelectedTabPage = xtraTabPage_Sesion;
                        btnCheckUserName.Image = global::Health.Front.Properties.Resources.User_3_Stop;

                        return dxErrorProvider1.HasErrors;
                    }
                }
                catch (Exception ex)
                {
                    this.ExceptionViewer.Show(ex);
                }

                if (String.IsNullOrEmpty(txtPassword.Text))
                {
                    dxErrorProvider1.SetError(txtConfrirmPassword, "La clave de usuario no puede estar enblanco", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    xtraTabControl1.SelectedTabPage = xtraTabPage_Sesion;
                    MessageViewer.Show(dxErrorProvider1.GetError(txtConfrirmPassword));
                    txtConfrirmPassword.SelectAll();
                    return true;
                }
                if (!txtConfrirmPassword.Text.Equals(txtPassword.Text))
                {
                    dxErrorProvider1.SetError(txtConfrirmPassword, "La clave y confirmación de la misma deben ser iguales", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    xtraTabControl1.SelectedTabPage = xtraTabPage_Sesion;

                    txtConfrirmPassword.SelectAll();
                    MessageViewer.Show(dxErrorProvider1.GetError(txtConfrirmPassword));
                    return true;
                }
            }
            #endregion

            //Si tiene permitido modificar seguridad
            if (FormBase.CheckRule("admin_users_change_security") == true)
            {
                if (GetCheckedRolList().Count == 0)
                {
                    dxErrorProvider1.SetError(lblSelRol, "Debe seleccionar al menos un rol para el usuario");

                    xtraTabControl1.SelectedTabPage = xtraTabPage_Sesion; ;
                    return true;
                }
            }
            //Si no tiene permitido modificar admin_professional_sheduling 
            if (btnCrearResourceScheduling.Enabled) // -> admin_professional_sheduling
                if (resourceSchedulingList == null || resourceSchedulingList.Count == 0)
                {

                    xtraTabControl1.SelectedTabPage = xtraTabPage2; ;
                    MessageViewer.Show("No ah definido la programación de turnos del profesional");

                    return true;
                }
            return false;


        }

        /// <summary>
        /// Crea o actualiza informacion del profeional
        /// </summary>
        /// <returns></returns>
        internal bool CreateOrUpdate()
        {
            User wUser = null;
            if (uc_Persona1.HasErrors())
            {
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
                return false;
            }
            if (HasErrors()) return false;
            try
            {
                uc_Persona1.SetPersona();
                uc_MedioContacto1.SetPersona();
                profesionalBE.Persona = uc_Persona1.Persona;

                profesionalBE.Matricula = this.txtMatricula.Text;
                profesionalBE.IdEspecialidad = (int)this.cmbEspecialidad.EditValue;
                profesionalBE.IdProfesion = (int)this.cmbProfecion.EditValue;

                if (State == Fwk.Bases.EntityUpdateEnum.NEW)
                {
                    wUser = new User();
                    wUser.UserName = txtUsername.Text;
                    wUser.Password = txtPassword.Text.Trim();
                    wUser.IsApproved = true;
                    wUser.IsLockedOut = false;

                    List<String> wNewRolList = GetCheckedRolList();

                    wUser.Roles = wNewRolList.ToArray();

                    Controller.CrearProfesional(profesionalBE, wUser);
                    if (resourceSchedulingList != null && resourceSchedulingList.Count != 0)
                        Controller.CreateResourceScheduling(resourceSchedulingList,Controller.CurrentHealthInstitution.HealthInstitutionId);

                    this.MessageViewer.Show(String.Format("{0}, se creo con exito", profesionalBE.Persona.ApellidoNombre.Trim()));
                }

                if (State == Fwk.Bases.EntityUpdateEnum.UPDATED)
                {
                    if (CheckRolesChanged())
                    {
                        wUser = new User();
                        wUser.UserName = txtUsername.Text;
                        wUser.ProviderId = profesionalBE.Persona.UserId;
                        wUser.Roles = GetCheckedRolList().ToArray();
                    }

                    Controller.UpdateProfesional(profesionalBE, wUser,Controller.CurrentHealthInstitution.HealthInstitutionId);

                    //La lista de las posibles actualizaciones no se envian en este metodo ya que se actualizan automaticamente cuando se trata de un Patient en state = UPDATED
                    var varlist = resourceSchedulingList.Where(p => p.EntityState.Equals(Fwk.Bases.EntityState.Added)).ToList<ResourceSchedulingBE>();
                    ResourceSchedulingList list = new ResourceSchedulingList();
                    list.AddRange(varlist);
                    if (list.Count != 0)
                        Controller.CreateResourceScheduling(list,Controller.CurrentHealthInstitution.HealthInstitutionId);

                    this.MessageViewer.Show(String.Format("{0}, se actualizó con exito", profesionalBE.Persona.ApellidoNombre.Trim()));
                }
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
                return false;
            }
            return true;

        }



        GridHitInfo _HitInfo = null;
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {

            //  if (e.Button != MouseButtons.Right) return;
            _HitInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            currentShiftSheduling = ((ResourceSchedulingBE)gridView1.GetRow(_HitInfo.RowHandle));

        }

        /// <summary>
        /// Edición
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            using (frmResouceScheduling frm = new frmResouceScheduling())
            {
                if (currentShiftSheduling.EntityState == Fwk.Bases.EntityState.Changed)
                {
                    frm.ResourceSchedulingList = resourceSchedulingList;
                    frm.State = Fwk.Bases.EntityUpdateEnum.UPDATED;
                    frm.SchedulerShift = currentShiftSheduling;
                    if (frm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (frm.SchedulerShift.EntityState == Fwk.Bases.EntityState.Changed)
                        {
                            try
                            {
                                Controller.UpdateResourceSheduling(frm.SchedulerShift,Controller.CurrentHealthInstitution.HealthInstitutionId);
                            }
                            catch (Exception ex)
                            {

                                this.ExceptionViewer.Show(ex);
                                return;
                            }
                        }
                        schedulerShiftBindingSource.DataSource = resourceSchedulingList;
                        gridControl1.RefreshDataSource();
                    }
                }
                if (currentShiftSheduling.EntityState == Fwk.Bases.EntityState.Added)
                {
                    ///Actualiza uno nuevo : Es desir que todavia no esta en la base de datos
                    CreateResourceScheduling(currentShiftSheduling);
                }
            }
        }


        private void btnPreview_Click(object sender, EventArgs e)
        {
            using (frmShiftsControls frm = new frmShiftsControls())
            {
                frm.ShiftSchedulingList = resourceSchedulingList;
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// Preguntar al sistema de seguridad si este nombre no esta siendo utilizado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheckUserName_Click(object sender, EventArgs e)
        {
            dxErrorProvider1.ClearErrors();
            try
            {
                bool exist = Fwk.UI.Controller.SecurityController.ValidateUserExist(txtUsername.Text.Trim());

                if (exist)
                {
                    dxErrorProvider1.SetError(txtUsername, "El nombre de usuario ya se encuentra registrado \r\n por favor elija otro", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    txtUsername.SelectAll();
                    xtraTabControl1.SelectedTabPage = xtraTabPage_Sesion;
                    btnCheckUserName.Image = global::Health.Front.Properties.Resources.User_3_Stop;
                }
                else
                {
                    this.MessageViewer.Show("Nombre de usuario disponible");
                    btnCheckUserName.Image = global::Health.Front.Properties.Resources.User_4_Check;
                }
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }
        }

        private void btnResetPwd_Click(object sender, EventArgs e)
        {
            this.MessageViewer.MessageBoxButtons = MessageBoxButtons.YesNo;
            this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Question;
            DialogResult r = this.MessageViewer.Show("Esta a punto de reestablacer la clave de inicio de sesión del usuario, esta seguro ?");
            base.SetMessageViewInfoDefault();
            if (r == DialogResult.Yes)
            {
                if (String.IsNullOrEmpty(txtPassword.Text))
                {
                    dxErrorProvider1.SetError(txtConfrirmPassword, "La clave de usuario no puede estar enblanco", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    txtConfrirmPassword.SelectAll();
                    return;
                }
                if (!txtConfrirmPassword.Text.Equals(txtPassword.Text))
                {
                    dxErrorProvider1.SetError(txtConfrirmPassword, "La clave y confrirmacion de la misma deben ser iguales", DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                    txtConfrirmPassword.SelectAll();
                    return;
                }
                try
                {
                    SecurityController.UserResetPassword(this.profesionalBE.UserName, txtUsername.Text);
                }
                catch (Exception ex)
                {
                    this.ExceptionViewer.Show(ex);
                }
            }
        }

        private void cmbProfecion_EditValueChanged(object sender, EventArgs e)
        {

            cmbEspecialidad.Properties.DataSource = _EspecialidadList.Where(p => 
                p.IdParametroRef.Equals((int)this.cmbProfecion.EditValue)
                || p.IdParametro.Equals((int)CommonValuesEnum.Ninguno)).ToList<ParametroBE>();

            cmbEspecialidad.Refresh();
        }

      


    }
}
