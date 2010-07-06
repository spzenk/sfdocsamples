using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Admin
{
    public partial class Form1 : frmBase
    {
        private AlertService _Wrapper = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void messageCreatorContainer1_SendMessageEvent(object sender, EventArgs e)
        {
            messageCreatorContainer1.MeshName = "Consola";

            try
            {
                AlertMessage wAlertMessage = (AlertMessage)sender;
                wAlertMessage.MeshName = "Console";
                //Envio el mensaje al mesh por p2p
                _Wrapper.SendMessage(wAlertMessage);
                //Almaceno el mensaje en BD
                //Controller.CreateMessage(wAlertMessage, _adminColaborator, adminDomainGrid1.ColaboratorsCountInMesh);
                this.MessageViewer.Show("El mensaje se envió con éxito");
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }
            

        }
    }
}
        
