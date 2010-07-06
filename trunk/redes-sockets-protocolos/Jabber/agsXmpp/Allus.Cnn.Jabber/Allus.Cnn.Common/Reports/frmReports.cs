using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common.Reports
{
    public partial class frmReports : frmBaseDialog
    {
        MessagesBE _currentMessageBE = new MessagesBE();
        UC_rpt_Leidos _RptLeidos;
        UC_rpt_Confirmados _RptConfirmados;

        public frmReports()
        {
            InitializeComponent();
        }

        private void btnLeidos_Click(object sender, EventArgs e)
        {
            _RptLeidos = new UC_rpt_Leidos();
            _RptLeidos.Populate(_currentMessageBE.MessageId, _currentMessageBE.Title);
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(_RptLeidos);
            panelControl1.Controls[0].Dock = DockStyle.Fill;
        }

        private void btnConfirmados_Click(object sender, EventArgs e)
        {
            _RptConfirmados = new UC_rpt_Confirmados();
            _RptConfirmados.Populate(_currentMessageBE.MessageId, _currentMessageBE.Title);
            panelControl1.Controls.Clear();
            panelControl1.Controls.Add(_RptConfirmados);
            panelControl1.Controls[0].Dock = DockStyle.Fill;
        }

        private void frmReports_Load(object sender, EventArgs e)
        {
            messageGridFind1.Populate();
            btnConfirmados.Enabled = false;
            btnLeidos.Enabled = false;
        }


        private void messageGridFind1_OnGridClick(object sender, EventArgs e)
        {
            _currentMessageBE = messageGridFind1.CurrentMessage;

            if (_currentMessageBE == null)
                return;

            //Cargamos la grilla de estado de mensajes.
            uC_GridMessageStatus1.Populate(_currentMessageBE.MessageId, _currentMessageBE.MeshId);

            //Cargamos el gr�fico
            if (_currentMessageBE.RequireConfirm)
            {
                btnConfirmados.Enabled = true;
                btnLeidos.Enabled = true;
            }
            else
            {
                btnConfirmados.Enabled = false;
                btnLeidos.Enabled = true;
                btnLeidos_Click(sender, e);
                return;
            }
           
            if (panelControl1.Contains(_RptConfirmados))
                btnConfirmados_Click(sender, e);
            else
                btnLeidos_Click(sender, e);

        }
    }
}