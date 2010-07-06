using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Allus.Cnn.ISVC.SearchRpt_ReadConfirmed;

namespace Allus.Cnn.Common.Reports
{
    public partial class UC_rpt_Confirmados : DevExpress.XtraEditors.XtraUserControl, IReport
    {
        public UC_rpt_Confirmados()
        {
            InitializeComponent();
        }





        #region IReport Members

        public void Populate(Guid pMessageId, string pMessageTitle)
        {
            SearchRpt_ReadConfirmedResponse wResponse = new SearchRpt_ReadConfirmedResponse();
            wResponse.BusinessData = Controller.SearchRpt_ReadConfirmed(pMessageId);

            //No SE USA EL LINQ DE ABAJO PORQUE SE FILTRAN LAS COLUMNAS POR LA PROPIEDAD FILTER
            //wResponse.BusinessData.ResultGraficos.Remove(wResponse.BusinessData.ResultGraficos.Find(p => p.Descripcion.Equals("Leidos")));

            if (wResponse.BusinessData != null)
            {
                resultGraficosBindingSource.DataSource = wResponse.BusinessData.ResultGraficos;                
             }
            else
            {
                wResponse.BusinessData = new Result();

                ResultGraficos wResultGraficosNoLeidos = new ResultGraficos();
                wResultGraficosNoLeidos.Descripcion = "No Leidos";
                wResultGraficosNoLeidos.Cantidad = 1;
                wResponse.BusinessData.ResultGraficos.Add(wResultGraficosNoLeidos);

                ResultGraficos wResultGraficosNoConfirmados = new ResultGraficos();
                wResultGraficosNoConfirmados.Descripcion = "No confirmados";
                wResultGraficosNoConfirmados.Cantidad = 0;
                wResponse.BusinessData.ResultGraficos.Add(wResultGraficosNoConfirmados);

                resultGraficosBindingSource.DataSource = wResponse.BusinessData.ResultGraficos;
            }

            if (!pMessageTitle.Trim().Equals(string.Empty))
                chartConfirmados.Titles[1].Text = pMessageTitle.Trim();
            else
                chartConfirmados.Titles[1].Text = "Sin asunto";

        }

        #endregion
    }
}
