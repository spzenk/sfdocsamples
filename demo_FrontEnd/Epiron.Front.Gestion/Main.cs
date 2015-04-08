using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Fwk.Security.Common;
using Epiron.Front.Bases;

namespace Epiron.Gestion
{
    public partial class Main : frmMainBase
    {

        public Main()
        {
            InitializeComponent();
          
        }
        private void Main_Load(object sender, EventArgs e)
        {

            try
            {
            
                this.AddContronToPannel(PanelEnum.LeftPanel_1, "Epiron.Front.Gestion.Sample1.UserControl1,Epiron.Front.Gestion.Sample1", Epiron.Gestion.Properties.Resources.Fotos_1);
                this.AddContronToPannel(PanelEnum.FootherPanel, "Meucci.Front.Alerts.MarqueeUC,Meucci.Front.Alerts", null);
                this.AdjustCulture();
                
                //ExceptionView.Show(new Exception("ASLDASJDASJDASÑJD "), "<SDFSASAD");
            }
            catch (Exception es)
            {
                MessageViewer.Show(es.Message);
            }

            DialogResult dr = Show("", "", "");
            //if (dr == System.Windows.Forms.DialogResult.Cancel)
            //    this.Close();
        }
        public DialogResult Show(String pMessage, string user, string password)
        {

            DialogResult dr;
            using (FRM_AuthenticationForm wAuthForm = new FRM_AuthenticationForm())
            {
                wAuthForm.Auth_Title_Font = Font;
                //wAuthForm.Auth_Title_Image = Auth_Title_Image;
                //wAuthForm.Auth_Title_Text = Auth_Title_Text;
                //wAuthForm.InitCredentials(user, password);
               dr= wAuthForm.ShowDialog(this);
               
            }
            return dr;
        }
        #region override methods  controls
        /// <summary>
        /// 
        /// </summary>
        /// <param name="panelEnum"></param>
        /// <returns></returns>
        public override DevExpress.XtraEditors.PanelControl Get_Panel(PanelEnum panelEnum)
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

        
        #endregion 

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.AddContronToPannel(PanelEnum.LeftPanel_1, "Epiron.Front.Gestion.Sample1.UserControl1,Epiron.Front.Gestion.Sample1", 10);

            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.ShowWaitForm();
            this.AddContronToPannel(PanelEnum.LeftPanel_1, "Epiron.Front.Gestion.Sample1.UserControl2,Epiron.Front.Gestion.Sample1", 10);
            this.CloseWaitForm();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            //Si NO hay referencia a la dll directa podemos DEBEMOS usar esto
            using (frmDialogBase frmDialog = this.GetDialog("Meucci.Front.Alerts.Form1,Meucci.Front.Alerts"))
            {
                frmDialog.AdjustCulture();
                frmDialog.ShowDialog();
            }

            //Si hay referencia a la dll directa podemos usar esto
            //using (Epiron.Meucci.Alerts.Form1 frm = new  Meucci.Alerts.Form1())
            //{
            //    frm.ShowDialog();
            //}
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
           
        }

       
    
        
    }
}