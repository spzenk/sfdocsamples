using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Allus.Cnn.Common.BE;
using System.Net;

namespace Allus.Cnn.Common
{
    public partial class frmBaseP2P : frmBaseNotify
    {
        #region Members
        protected StringBuilder MessageLogs = new StringBuilder();
        protected Dictionary<string, AlertBase> WrapperList = new Dictionary<string, AlertBase>();
        protected ColaboratorData ColaboratorData = null;
        protected Allus.Cnn.Common.BackgroundP2PConnector BackgroundConnector;
        protected frmLoading LoadingForm;
        protected AlertMessage CurrentMessage;
        protected ClientMessageControl ClientMessageControl = new ClientMessageControl();
        #endregion

        public frmBaseP2P()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Este codigo solo se ejecuta una sola vez:
        /// Inicializa:
        /// Colaborator(el de p2p) y ColaboratorData
        /// </summary>
        protected virtual void InitControls()
        {
            Controller.LoggedColaborator = new Colaborator();
            try
            {
                ///TODO: Hacer Async la carga del ColaboratorData
                ColaboratorData = Controller.GetColaboratorDataInstance();
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
                this.ForceClose();
            }


            

            Controller.LoggedColaborator.MachineIp = Common.GetMachineIp();
            Controller.LoggedColaborator.IsAdmin = true;
            Controller.LoggedColaborator.Name = Environment.UserName; 
            Controller.LoggedColaborator.HostName = Dns.GetHostName();//moviedo  //Dns.GetHostEntry(Dns.GetHostName()).HostName; --> moviedo.allus.com.ar

            ///TODO: Hacer Async la carga del ColaboratorData
            ColaboratorData.MachineIp = Controller.LoggedColaborator.MachineIp;
            ColaboratorData.HostName = Controller.LoggedColaborator.HostName; 

            //Creacion del wrapper global
            AlertService wGlobalWrapper = new AlertService(Controller.LoggedColaborator);
            
            
            wGlobalWrapper.WrapperCallBackEvent += new AlertServiceEventHandler(Wrapper_AlertServiceEvent);
            //Evento para participar del mesh
            wGlobalWrapper.ParticipeToMeshEvent += new ParticipeToMeshHandler(Wrapper_ParticipeToMesh);
            //Evento para salir del mesh
            wGlobalWrapper.ExitFromMeshEvent += new ParticipeToMeshHandler(Wrapper_ExitFromMeshEvent);

            BackgroundConnector = new BackgroundP2PConnector(wGlobalWrapper);

            

        }

        protected virtual void InitSeccion()
        {
            LoadingForm = new frmLoading();
            LoadingForm.Show();
        }

        #region Wrapper events
        /// <summary>
        /// Ocurre cuando el administrador invita a participar a un nuevo mesh
        /// </summary>
        /// <param name="MeshIs"></param>
        void Wrapper_ParticipeToMesh(string MeshIs)
        {
            AlertMeshService wrapper;
            ///si no existe el mesh/sala lo crea
            if (!WrapperList.ContainsKey(MeshIs))
            {
                wrapper = new AlertMeshService(Controller.LoggedColaborator, MeshIs);
                WrapperList.Add(MeshIs, wrapper);
                wrapper.WrapperCallBackEvent += new AlertServiceEventHandler(Wrapper_AlertServiceEvent);

                wrapper.ConnectToMesh();
            }
            else
            {
                wrapper = (AlertMeshService)WrapperList[MeshIs];
                if (wrapper != null)
                {
                    wrapper.InvitationsCount++;
                }
            }
        }

        void Wrapper_ExitFromMeshEvent(string MeshIs)
        {
            ///Si existe lo elimina
            if (WrapperList.ContainsKey(MeshIs))
            {
                AlertBase wrapper = (AlertBase)WrapperList[MeshIs];
                wrapper.InvitationsCount--;
                // Si el numero de invitaciones es 0 ya no hay administrador que tenga este mesh
                if (wrapper.InvitationsCount == 0)
                {
                    wrapper.WrapperCallBackEvent -= new AlertServiceEventHandler(Wrapper_AlertServiceEvent);
                    wrapper.DisconectToMesh();
                    WrapperList.Remove(MeshIs);
                }

            }
        }

        void Wrapper_AlertServiceEvent(object sender, InfoEventArgs e)
        {
            if (this.InvokeRequired)
            {
                AlertServiceEventHandler d = new AlertServiceEventHandler(Wrapper_AlertServiceEvent);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                switch (e.CallBackType)
                {
                    case CallBackMessageType.Receive:
                        Receive(e.Colaborator, e.Message);
                        break;
                }
            }
        }
        void Wrapper_ExceptionEvent(object sender, ExceptionEventArgs e)
        {
            if (this.InvokeRequired)
            {
                EventHandler<ExceptionEventArgs> d = new EventHandler<ExceptionEventArgs>(Wrapper_ExceptionEvent);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                //this.ExceptionViewer.Show(e.Ex);

                SetConnectionControls("Error de conexión..", Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e.Ex), JoinStatusEnum.Error);
            }
        }
        #endregion

        #region Virtual Methods
        protected virtual void SetConnectionControls(string statusMessage, string msg, JoinStatusEnum status)
        { }
        protected virtual void Receive(Allus.Cnn.Common.BE.Colaborator sender, string message)
        { }

        #endregion

    }
}
