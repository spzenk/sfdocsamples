using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Health.BE;

namespace WindowsFormsApplication1
{
    public partial class richText : Form
    {
        public richText()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Pupulate(Create_Doc());
        }
         void Pupulate(string doc)
        {
            

            try
            {
                richEditControl1.Document.BeginUpdate();
                richEditControl1.Document.Sections[0].Margins.Left = 1;
                richEditControl1.Document.Sections[0].Margins.Right = 1;
                richEditControl1.Document.Sections[0].Margins.Top = 1;
                richEditControl1.ReadOnly = true;
                richEditControl1.HtmlText = doc;
              

                richEditControl1.Document.EndUpdate();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

         

        }
        string Create_Doc()
        {
            


            MedicalEventBE wMedicalEvent = new MedicalEventBE();
            wMedicalEvent.NombreEspesialidad = "Cirujia Estetica ";
            wMedicalEvent.NombreApellidoProfecional = "dsad ,d asdsadas";
            wMedicalEvent.InstitucionRazonSocial = "Eclipse";
            wMedicalEvent.Motivo = "Dolor de espalda";
            wMedicalEvent.Evolucion = " pdsAU LÑKSADJKLJ JdflkALASDJSKNKLC jcsdc";

            wMedicalEvent.Diagnosis = "  Audiencias Decreto 1172/2003, Autor, Fecha, Representado, Sintesis y Audiencias Completas";
            wMedicalEvent.PMOQuirurgico = "El Programa Médico Obligatorio (PMO) es una canasta básica de prestaciones a través de la cual los beneficiarios tienen derecho a recibir prestaciones médico asistenciales. La obra social debe brindar las prestaciones del Programa Médico Obligatorio (PMO) y otras coberturas obligatorias, sin carencias, preexistencias o exámenes de admisión.";
           string template = Fwk.HelperFunctions.FileFunctions.OpenTextFile(@"D:\Projects\sfdocsamples\WindowsFormsApplication\WindowsFormsApplication\SimpleEventView.htm");
            StringBuilder t = new StringBuilder(template);

            t.Replace("[PROFESIONAL]", String.Concat(wMedicalEvent.NombreApellidoProfecional, "  (", wMedicalEvent.NombreEspesialidad, ")"));


            t.Replace("[INST]", wMedicalEvent.InstitucionRazonSocial);
            t.Replace("[FECHA]", wMedicalEvent.CreatedDate.ToShortDateString());

            if (!string.IsNullOrEmpty(wMedicalEvent.Motivo))
                t.Replace("[MOTIVO]", wMedicalEvent.Motivo);
            else
                t.Replace("[MOTIVO]", "<br />");

            if (!string.IsNullOrEmpty(wMedicalEvent.Evolucion))
                t.Replace("[EVOLUCION]", wMedicalEvent.Evolucion);
            else
                t.Replace("[EVOLUCION]", "<br />");

            if (!String.IsNullOrEmpty(wMedicalEvent.PMOQuirurgico))
            {


                t.Replace("[PMO]", string.Concat(wMedicalEvent.PMOQuirurgico, "<br />"));

            }
            else
                t.Replace("[PMO]", "<br />");




            if (!string.IsNullOrEmpty(wMedicalEvent.Diagnosis))
                t.Replace("[DIAG]", wMedicalEvent.Diagnosis);
            else
                t.Replace("[DIAG]", "<br />");

            wMedicalEvent.IdTipoConsulta = 12;
            if (wMedicalEvent.IdTipoConsulta.HasValue)
            {
                
               
                    t.Replace("[TIPOCONSULTA]","lkjAS OIUOISA KDjlÑAS");

            }
            else
                t.Replace("[TIPOCONSULTA]", "<br />");

            t.Replace("[ESP]", wMedicalEvent.NombreEspesialidad);

            string tRowMedicamentTemplate = " <tr style=\"height: 30px\"> <td>[Date]</td>  <td>[MedicamentName]</td>  <td>[Status]</td>   <td>[NombreProfesional]</td>                          </tr>";

            StringBuilder strTableTows = new StringBuilder();
            //foreach (PatientMedicament_ViewBE med in wMedicalEvent.PatientMedicaments)
            //{
            //    strTableTows.AppendLine(tRowMedicamentTemplate);
            //    strTableTows.Replace("[MedicamentName]", med.MedicamentName);

            //    strTableTows.Replace("[Date]", med.CreatedDate.ToShortDateString());
            //    strTableTows.Replace("[Status]", med.MedicamentStatusInfo);

            //    strTableTows.Replace("[NombreProfesional]", med.NombreProfesional);



            //}
            //if (wMedicalEvent.PatientMedicaments.Count != 0)
            //{
            //    t.Replace("[MEDICAMENTOS]", strTableTows.ToString());
            //    t.Replace("[tbl_med_display]", "table");
            //}
            //else
            //{
                t.Replace("[MEDICAMENTOS]", String.Empty);
                t.Replace("[tbl_med_display]", "none");
            //}
            //chkDefinitivo.Checked = wMedicalEvent.IsDefinitive;
            //_Evento.PatientMedicaments;
            return t.ToString();
        }
    }
}
