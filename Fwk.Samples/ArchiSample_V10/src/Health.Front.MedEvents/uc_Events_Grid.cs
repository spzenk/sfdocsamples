using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Health.Back.BE;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Health.BE;
using System.Linq;
using Fwk.UI.Common;
//using Fwk.Security.Common;
namespace Health.Front.Events
{
    public partial class uc_Events_Grid : Xtra_UC_Base
    {
        MedicalEvent_ViewBE _Event;
        string template = string.Empty;
        string tRowMedicamentTemplate = string.Empty;
        public uc_Events_Grid()
        {
            InitializeComponent();

            template = Fwk.HelperFunctions.FileFunctions.OpenTextFile("SimpleEventView.htm");
            tRowMedicamentTemplate = " <tr style=\"height: 30px\"> <td>[MedicamentName]</td>  <td>[Permanente]</td>   <td>[IsSuspended]</td>                          </tr>";
        }

        public override void Refresh()
        {
            medicalEventViewListBindingSource.DataSource = Controller.RetriveMedicalEvent(Controller.CurrentPatient.PatientId);
            gridControl1.RefreshDataSource();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (_Event == null) return;

            using (frmEvent frm = new frmEvent())
            {
                frm.MedicalEventId = _Event.MedicalEventId;
                frm.Refresh();
                frm.ShowDialog();
            }
        }

        GridHitInfo _HitInfo = null;
        private void gridView1_MouseDown(object sender, MouseEventArgs e)
        {

            _HitInfo = gridView1.CalcHitInfo(new Point(e.X, e.Y));
            _Event = ((MedicalEvent_ViewBE)gridView1.GetRow(_HitInfo.RowHandle));
            if (_Event != null)
            {
                using (WaitCursorHelper w = new WaitCursorHelper(this))
                {
                    uc_docprontviewer_11.Pupulate(Create_Doc());
                }
            }

        }

        private void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        {
            if (e.Column == colMotivoOEspesialidad && e.IsGetData)
            {
                Health.BE.MedicalEvent_ViewBE be = (Health.BE.MedicalEvent_ViewBE)e.Row;
                if (String.IsNullOrEmpty(be.NombreTipoConsulta))
                    e.Value = be.NombreEspesialidad ;
                else
                    e.Value = be.NombreTipoConsulta;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

        }


        string Create_Doc()
        {
            if (_Event == null) return string.Empty;
            StringBuilder strTableTows = null;
            ParametroBE wParam;

            MedicalEventBE wMedicalEvent = Controller.GetMedicalEvent(_Event.MedicalEventId);

            StringBuilder t = new StringBuilder(template);

            t.Replace("[PROFESIONAL]", String.Concat(wMedicalEvent.NombreApellidoProfecional, "  (", wMedicalEvent.NombreEspesialidad, ")"));


            t.Replace("[INST]", wMedicalEvent.InstitucionRazonSocial);
            t.Replace("[FECHA]", wMedicalEvent.CreatedDate.ToShortDateString());

            if (!string.IsNullOrEmpty(wMedicalEvent.Motivo))
                t.Replace("[MOTIVO]",  wMedicalEvent.Motivo);
            else
                t.Replace("[MOTIVO]", "<br />");

            if (!string.IsNullOrEmpty(wMedicalEvent.Evolucion))
                t.Replace("[EVOLUCION]", wMedicalEvent.Evolucion);
            else
                t.Replace("[EVOLUCION]", "<br />");

            PMOFile pmo = null;
            if (!String.IsNullOrEmpty(wMedicalEvent.PMOQuirurgico))
            {
                pmo = Controller.PMOFileList.Where(p => p.Code.Equals(wMedicalEvent.PMOQuirurgico.Trim())).FirstOrDefault();
                if (pmo != null)
                {
                    t.Replace("[PMO_QUIR]", string.Concat(pmo.Description, "<br />"));
                    t.Replace("[pmo_quir_med_display]", "table");

                }

            }
            else
            {
                t.Replace("[PMO_QUIR]", "<br />");
                t.Replace("[pmo_quir_med_display]", "none");
            }


            if (wMedicalEvent.DetailView_MetodosComplementarios.Count != 0)
            {
                tRowMedicamentTemplate = " <tr style=\"height: 30px\"> <td>[DESC]</td>    <td>[OBS]</td> </tr>";
                 strTableTows = new StringBuilder();
                foreach (var det in wMedicalEvent.DetailView_MetodosComplementarios)
                {
                    strTableTows.AppendLine(tRowMedicamentTemplate);
                    strTableTows.Replace("[DESC]", det.Desc);

                    strTableTows.Replace("[OBS]", det.Observations);
                }
                t.Replace("[MetodoComplementario]", string.Concat(strTableTows.ToString(), "<br />"));
            }
            else
                t.Replace("[MetodoComplementario]",  "<br />");

            if (wMedicalEvent.DetailView_Diagnosis.Count != 0)
            {
                tRowMedicamentTemplate = " <tr style=\"height: 30px\"> <td>[DESC]</td>    <td>[OBS]</td> <td>[ALERT]</td> </tr>";
                strTableTows = new StringBuilder();
                foreach (var det in wMedicalEvent.DetailView_Diagnosis)
                {
                    strTableTows.AppendLine(tRowMedicamentTemplate);
                    strTableTows.Replace("[DESC]", det.Desc);

                    strTableTows.Replace("[OBS]", det.Observations);

                    strTableTows.Replace("[ALERT]", det.RelevanceTypeName);
                }
                t.Replace("[DIAG]", string.Concat(strTableTows.ToString(), "<br />"));

            }
            else
                t.Replace("[DIAG]", "<br />");

            if (wMedicalEvent.IdTipoConsulta.HasValue)
            {
                wParam = Controller.TipoEventoMedicoList.Where(p => p.IdParametro.Equals(Convert.ToInt32(wMedicalEvent.IdTipoConsulta))).FirstOrDefault();
                if (wParam != null)
                    t.Replace("[TIPOCONSULTA]", wParam.Nombre);

            }
            else
                t.Replace("[TIPOCONSULTA]", "<br />");

            t.Replace("[ESP]", wMedicalEvent.NombreEspesialidad);

            tRowMedicamentTemplate = " <tr style=\"height: 30px\"> <td>[Date]</td>  <td>[MedicamentName]</td>  <td>[Status]</td>   <td>[NombreProfesional]</td>                          </tr>";

             strTableTows = new StringBuilder();
            foreach (PatientMedicament_ViewBE med in wMedicalEvent.PatientMedicaments)
            {
                strTableTows.AppendLine(tRowMedicamentTemplate);
                strTableTows.Replace("[MedicamentName]", med.MedicamentName);

                strTableTows.Replace("[Date]", med.CreatedDate.ToShortDateString());
                strTableTows.Replace("[Status]", med.StatusDescription);

                strTableTows.Replace("[NombreProfesional]", med.NombreProfesional);



            }
            if (wMedicalEvent.PatientMedicaments.Count != 0)
            {
                t.Replace("[MEDICAMENTOS]", strTableTows.ToString());
                t.Replace("[tbl_med_display]", "table");
            }
            else
            {
                t.Replace("[MEDICAMENTOS]", String.Empty);
                t.Replace("[tbl_med_display]", "none");
            }
            //chkDefinitivo.Checked = wMedicalEvent.IsDefinitive;
            //_Evento.PatientMedicaments;
            return t.ToString();
        }

    }
}
