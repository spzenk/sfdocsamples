using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.Back.BE;
using Health.Entities;
using Health.Isvc.GetProfesional;
using Fwk.UI.Forms;

namespace Health.Front.profesional
{
    public partial class frmProfesionalCard : frmBase_Dialog
    {
        int _IdProfesional;
        public frmProfesionalCard()
        {
            InitializeComponent();
        }
        public frmProfesionalCard(Fwk.Bases.EntityUpdateEnum state, int idProfesional)
        {
            InitializeComponent();
            this.State = state;
            this._IdProfesional = idProfesional;
        }
        

        private void frmProfesionalCard_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            uc_Profesionales_Card1.Populate(_IdProfesional, this.State);
            //uc_Profesionales_Card1.Refresh();
            aceptCancelButtonBar1.AceptButtonEnabled = FormBase.CheckRule("admin_professional_abm") || FormBase.CheckRule("admin_users_change_security") || FormBase.CheckRule("admin_professional_sheduling");  

        }


        private void aceptCancelButtonBar1_ClickOkCancelEvent(object sender, DialogResult result)
        {
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                if (uc_Profesionales_Card1.CreateOrUpdate())
                    this.Close();
            }
            else
                this.Close();
        }

    }
}
