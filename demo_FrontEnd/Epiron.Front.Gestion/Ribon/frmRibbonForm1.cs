using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Epiron.Front.Bases;

namespace Epiron.Gestion.Ribon
{
    public partial class frmRibbonForm1 : DevExpress.XtraBars.Ribbon.RibbonForm, IfrmMainBase
    {
        public frmRibbonForm1()
        {
            InitializeComponent();
            try
            {
                userContrlManager1.AddContronToPannel(PanelEnum.LeftPanel_1, "Epiron.Front.Gestion.Sample1.UserControl1,Epiron.Front.Gestion", 10);
                userContrlManager1.AddContronToPannel(PanelEnum.FootherPanel, "Meucci.Front.Alerts.MarqueeUC,Meucci.Front.Alerts", null);
            }
            catch (Exception es)
            {
                this.MessageViewer.Show(es.Message);
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {

            //Si NO hay referencia a la dll directa podemos DEBEMOS usar esto
            using (frmDialogBase frmDialog = userContrlManager1.GetDialog("Meucci.Front.Alerts.Form1,Meucci.Front.Alerts"))
            {
                frmDialog.ShowDialog();
            }

            //Si hay referencia a la dll directa podemos usar esto
            //using (Epiron.Meucci.Alerts.Form1 frm = new  Meucci.Alerts.Form1())
            //{
            //    frm.ShowDialog();
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="panelEnum"></param>
        /// <returns></returns>
        public DevExpress.XtraEditors.PanelControl Get_Panel(PanelEnum panelEnum)
        {
            DevExpress.XtraEditors.PanelControl panel = null;
            switch (panelEnum)
            {
                case PanelEnum.FootherPanel:
                    panel = this.panelControl_FootherPanel;
                    break;
                case PanelEnum.LeftPanel_1:
                    panel = this.panelControl_LeftPanel_1;
                    break;
                case PanelEnum.RightPanel:
                    panel = this.panelControl_RightPanel;
                    break;
            }
            return panel;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            userContrlManager1.AddContronToPannel(PanelEnum.LeftPanel_1, "Epiron.Front.Gestion.Sample1.UserControl1,Epiron.Front.Gestion.Sample1", 10);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            userContrlManager1.AddContronToPannel(PanelEnum.LeftPanel_1, "Epiron.Front.Gestion.Sample1.UserControl2,Epiron.Front.Gestion.Sample1", 10);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            using (frmDialogBase frmDialog = userContrlManager1.GetDialog("Meucci.Front.Alerts.Form1,Meucci.Front.Alerts"))
            {
                frmDialog.ShowDialog();
            }
        }
    }
}