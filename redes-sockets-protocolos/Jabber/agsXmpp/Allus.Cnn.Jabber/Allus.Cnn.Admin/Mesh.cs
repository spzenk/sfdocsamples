using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Allus.Cnn.Common;
using Allus.Cnn.Common.Proxy;
using DevExpress.XtraTreeList.Nodes;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Admin
{
    public delegate void FinalizeMeshHandler(string MeshId);
    public delegate void ConnectedMeshHandler(string MeshId,ProxyEventArgs e);
    public partial class Mesh : frmBaseDialog
    {
        [Category("Allus.Libraries")]
        public event EventHandler SendMessageEvent;
        #region Fields

        private MeshBE _MeshBE;
        [Browsable(false)]
        public MeshBE MeshBE
        {
            get { return _MeshBE; }
            set { _MeshBE = value; }
        }
        [Category("Allus.Libraries")]
        public event ConnectedMeshHandler ConnectedMeshEvent;
        [Category("Allus.Libraries")]
        public  event FinalizeMeshHandler FinalizeMeshEvent;
  

        private TreeListNode node;
        [Browsable(false)]
        public TreeListNode Node
        {
            get { return node; }
            set { node = value; }
        }
       
        
        AlertMeshService _Wrapper = null;
        Colaborator _AdminColaborator = null;
        #endregion

        public Mesh(Colaborator admin, string meshId, string meshName)
        {
            InitializeComponent();
            _MeshBE = new MeshBE(meshName,meshId);

            this.Text = _MeshBE.FriendlyName;
            
            _AdminColaborator = admin;

            InitControls();

        }

        private void messageCreatorContainer1_SendMessageEvent(object sender, EventArgs e)
        {
            
            try
            {
                 AlertMessage wAlertMessage =(AlertMessage)sender;
                 wAlertMessage.MeshName = _MeshBE.Name;
                 wAlertMessage.MeshId = _MeshBE.Id;
                 //Envio el mensaje al mesh por p2p
                 _Wrapper.SendMessage(wAlertMessage);
                //Almaceno el mensaje en BD
                 Controller.CreateMessage(wAlertMessage, _AdminColaborator, colaboratorsAdminGrid1.ColaboratorsCountInMesh);
                this.MessageViewer.Show("El mensaje se envi� con �xito");
                if(SendMessageEvent!=null)
                    SendMessageEvent(sender, new EventArgs());
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }
        }
        void InitControls()
        {
            _Wrapper = new AlertMeshService(_AdminColaborator, _MeshBE.Id);
            
            //_Wrapper.WrapperCallBackEvent += new AlertServiceEventHandler(Wrapper_AlertServiceEvent);
            _Wrapper.WrapperEvent += new ProxyEventHandler(Wrapper_ProxyEvent);

            ///Una ves conectado el proxy responde con el hendler 
            _Wrapper.ConnectToMesh();

            colaboratorsAdminGrid1.Populate(_MeshBE.Id);

        }
        #region Proxy events
      

     
        /// <summary>
        /// Se  produce cuando un colaborador entra sesion
        /// </summary>
        /// <param name="pColaborator"></param>
        public void UserJoin(Colaborator pColaborator)
        {
            colaboratorsAdminGrid1.Add(pColaborator);
        }
       /// <summary>
       /// Se  produce cuando un colaborador cierra sesion
       /// </summary>
       /// <param name="pColaborator"></param>
        public void UserLeave(Allus.Cnn.Common.BE.Colaborator pColaborator)
        {
            colaboratorsAdminGrid1.Remove(pColaborator);
        }

        void Wrapper_ProxyEvent(object sender, ProxyEventArgs e)
        {
            if (this.InvokeRequired)
            {
                ProxyEventHandler d = new ProxyEventHandler(Wrapper_ProxyEvent);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                switch (e.Status)
                {
                    case JoinStatusEnum.Error:
                        {
                            //SetConnectionControls("Error conectando...", e.Message, e.Status);
                            break;
                        }
                    case JoinStatusEnum.Disconnected:
                    case JoinStatusEnum.OffLine:
                        {
                            //SetConnectionControls("Esperando se�al", e.Message, e.Status);
                            break;
                        }
                    case JoinStatusEnum.Connecting:
                        {
                            //SetConnectionControls("Conectando", e.Message, e.Status);
                            break;
                        }
                    case JoinStatusEnum.Connected:
                        {
                            MeshFactory.GlobalWrapper.ParticipeToMesh(_MeshBE.Id);
                            break;
                        }
                    case JoinStatusEnum.OnLine:
                        {
                            //SetConnectionControls("Conectando", e.Message, e.Status);
                            break;
                        }
                }
            }
        }
        void Wrapper_AlertServiceEvent(object sender, InfoEventArgs e)
        {
            //if (this.InvokeRequired)
            //{
            //    AlertServiceEventHandler d = new AlertServiceEventHandler(Wrapper_AlertServiceEvent);
            //    this.Invoke(d, new object[] { sender, e });
            //}
            //else
            //{
            //    switch (e.CallBackType)
            //    {
            //        case CallBackMessageType.Receive:
            //            Receive(e.Colaborator, e.Message);
            //            break;

            //        case CallBackMessageType.UserEnter:
            //            UserJoin(e.Colaborator);
            //            break;
            //        case CallBackMessageType.UserLeave:
            //            UserLeave(e.Colaborator);
            //            break;

            //    }
            //}
        }

        #endregion



        private void btnFinalizeMesh_Click(object sender, EventArgs e)
        {
            
            if (FinalizeMeshEvent != null)
                FinalizeMeshEvent(_MeshBE.Id);

        }
        protected override void OnClosing(CancelEventArgs e)
        {
            this.Visible = false;
            e.Cancel = true;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }


        internal void DisconnectMesh()
        {
            _Wrapper.DisconectToMesh();
        }

        private void colaboratorsAdminGrid1_RefreshColaboratorEvent(object sender, EventArgs e)
        {
            colaboratorsAdminGrid1.Populate(_MeshBE.Id);
        }

       
    }

}