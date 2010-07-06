using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Allus.Cnn.ISVC.SearchRpt_ReadConfirmed;
using DevExpress.XtraCharts;
using Allus.Cnn.Common.BE;


namespace Allus.Cnn.Common.Reports
{
    public partial class UC_rpt_Leidos : DevExpress.XtraEditors.XtraUserControl, IReport
    {
        public UC_rpt_Leidos()
        {
            InitializeComponent();
        }


        #region IReport Members

        public void Populate(Guid pMessageId, string pMessageTitle)
        {
            SearchRpt_ReadConfirmedResponse wResponse = new SearchRpt_ReadConfirmedResponse();
            wResponse.BusinessData = Controller.SearchRpt_ReadConfirmed(pMessageId);

            //Validamos que alg�n mensaje haya sido le�do sino debemos agregar a mano para que aparezca 100% No Leidos.
            if (wResponse.BusinessData != null)
            {
                resultGraficosBindingSource.DataSource = wResponse.BusinessData.ResultGraficos;

            }
            else
            {
                wResponse.BusinessData = new Result();

                ResultGraficos wResultGraficosLeidos = new ResultGraficos();
                wResultGraficosLeidos.Descripcion = "Leidos";
                wResultGraficosLeidos.Cantidad = 0;
                wResponse.BusinessData.ResultGraficos.Add(wResultGraficosLeidos);

                ResultGraficos wResultGraficosNoLeidos = new ResultGraficos();
                wResultGraficosNoLeidos.Descripcion = "No Leidos";
                wResultGraficosNoLeidos.Cantidad = 1;
                wResponse.BusinessData.ResultGraficos.Add(wResultGraficosNoLeidos);

                resultGraficosBindingSource.DataSource = wResponse.BusinessData.ResultGraficos;
            }

            if (!pMessageTitle.Trim().Equals(string.Empty))
                chartLeidos.Titles[1].Text = pMessageTitle.Trim();
            else
                chartLeidos.Titles[1].Text = "Sin asunto";

            
        }

        #endregion

        private void readConfirmedMessagesBEFrontBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
