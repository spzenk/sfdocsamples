using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Allus.Cnn.Common;
using Allus.Cnn;
using System.Net;

using Allus.Cnn.Common.Proxy;
using System.Threading;
using Allus.Cnn.Common.BE;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;


namespace Allus.Cnn.Admin
{
    public partial class AdminConsole : frmBaseP2P
    {
        #region fields
        Thread wGenThread;
        
        #endregion

        public AdminConsole()
        {
            InitializeComponent();
        }

        private void AdminConsole_Load(object sender, EventArgs e)
        {

            notifyIcon1.ShowBalloonTip(1000);

            InitControls();
            InitSession();
        }

        /// <summary>
        /// 
        ///
        /// </summary>
        protected override void InitControls()
        {
            base.InitControls();

            this.adminDomainGrid1.UserName = Controller.LoggedColaborator.Name;
            this.adminDomainGrid1.Admin = Controller.LoggedColaborator;
            this.adminDomainGrid1.PopulateAsync();
            this.btnPermissions.Enabled = base.ColaboratorData.IsConsoleAdmin;

            if (SettingStorage.Storage.MeshBEList == null)
            {
                SettingStorage.Storage.MeshBEList = new List<MeshBE>();
            }
            //Lleno la grilla de los mesh creados en situaciones anteriores
            this.meshBEBindingSource.DataSource = SettingStorage.Storage.MeshBEList;
            weatherControlSlim1.PopulateAsync();
          

        }

        /// <summary>
        /// Inicializa la instancia del wrapper bajo patron singleton
        /// Inicializa los manejadores del wrapper.-
        /// Inicializa el menejador del  BackgroundP2PConnector que lanza los eventos del wraper de forma asincrona.-
        /// </summary>
        void  InitSession()
        {
            base.InitSeccion();
            //base.LoadingForm = new frmLoading();
            //base.LoadingForm.Show();

            
            //base.BackgroundConnector.GlobalWrapper.WrapperCallBackEvent += new AlertServiceEventHandler(Wrapper_AlertServiceEvent);
            //base.BackgroundConnector.GlobalWrapper.ParticipeToMeshEvent += new ParticipeToMeshHandler(Wrapper_ParticipeToMesh);
            //base.BackgroundConnector.GlobalWrapper.ExitFromMeshEvent += new ParticipeToMeshHandler(Wrapper_ExitFromMeshEvent);
            //base.BackgroundConnector.GlobalWrapper.ExceptionEvent += new EventHandler<ExceptionEventArgs>(Wrapper_ExceptionEvent);
        
            
            MeshFactory.GlobalWrapper = base.BackgroundConnector.GlobalWrapper;

            base.BackgroundConnector.Event += new ConnectorWrapperHandler(BackConnector_Event);
            wGenThread = new Thread(new ThreadStart(base.BackgroundConnector.Start));
            wGenThread.Start();

        }

        /// <summary>
        /// Avisa a la consola de los cambio de estado de coneccion del Mesh (wrapper) global
        /// </summary>
        /// <param name="statusMessage"></param>
        /// <param name="msg"></param>
        /// <param name="status"></param>
        void BackConnector_Event(string statusMessage, string msg, JoinStatusEnum status)
        {
            if (this.InvokeRequired)
            {
                ConnectorWrapperHandler d = new ConnectorWrapperHandler(BackConnector_Event);
                this.Invoke(d, new object[] { statusMessage, msg, status });
            }
            else
            {
                SetConnectionControls(statusMessage, msg, status);
            }
        }

        protected override void SetConnectionControls(string statusMessage, string msg, JoinStatusEnum status)
        {
            lblConnectionStatus.Caption = statusMessage;
            base.LoadingForm.TextoEstado = statusMessage;

            this.btnConnect.Enabled = false;
            if (status == JoinStatusEnum.Connecting)
            {
                this.adminDomainGrid1.IsOnLine = false;
                panelControl1.Visible = false;
                this.lblConnectionStatus.Glyph = global::Allus.Cnn.Admin.Properties.Resources.ball_yellow;
                AddConnectionStatus(statusMessage, msg);
                return;
            }
            this.btnConnect.Enabled = true;


            if (status == JoinStatusEnum.OffLine || status == JoinStatusEnum.Disconnected)
            {
                this.adminDomainGrid1.IsOnLine = false;
                this.lblConnectionStatus.Glyph = global::Allus.Cnn.Admin.Properties.Resources.ball_yellow;
                panelControl1.Visible = true;
                btnConnect.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            }

            //"Desconectado"
            if (status == JoinStatusEnum.Error)
            {
                panelControl1.Visible = false;
                btnConnect.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
                //btnConnect.Caption = "Conectar";

                this.lblConnectionStatus.Glyph = global::Allus.Cnn.Admin.Properties.Resources.ball_red;
                AddConnectionStatus(statusMessage, msg);
                return;
            }
            //"Conectado"
            if (status == JoinStatusEnum.Connected || status == JoinStatusEnum.OnLine)
            {
                this.adminDomainGrid1.IsOnLine = true;
                panelControl1.Visible = true;
                btnConnect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

                this.lblConnectionStatus.Glyph = global::Allus.Cnn.Admin.Properties.Resources.ball_green;
                Thread wGenThread_Wrapper;
                wGenThread_Wrapper = new Thread(new ThreadStart(base.BackgroundConnector.GlobalWrapper.ConnectToExistentMeshes));

                base.LoadingForm.Close();

                wGenThread_Wrapper.Start();               
            }

            ClearConnectionStatus();
        }



        #region Callback methods [Avisos del servidor sobre mensajes nuevos]
        ///// <summary>
        ///// Callback de la llamada asincrona para obtener la lista de usuarios.-
        ///// </summary>
        ///// <param name="list"></param>
        //void Wrapper_EndGetUsersEvent(Colaborator[] list)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        EndGetUsersHandle d = new EndGetUsersHandle(Wrapper_EndGetUsersEvent);
        //        this.Invoke(d, new object[] { list });
        //    }
        //    else
        //    {
        //        Controller.ColaboratorList.AddRange(list);
        //    }
        //}
        //void Wrapper_ExceptionEvent(object sender, ExceptionEventArgs e)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        EventHandler<ExceptionEventArgs> d = new EventHandler<ExceptionEventArgs>(Wrapper_ExceptionEvent);
        //        this.Invoke(d, new object[] { sender, e });
        //    }
        //    else
        //    {
        //        //this.ExceptionViewer.Show(e.Ex);

        //        SetConnectionControls("Error de conexión..", Fwk.Exceptions.ExceptionHelper.GetAllMessageException(e.Ex), JoinStatusEnum.Error);
        //    }
        //}

        ////TODO: pasar al base
        ///// <summary>
        ///// Ocurre cuando el administrador invita a participar a un nuevo mesh
        ///// </summary>
        ///// <param name="MeshIs"></param>
        //void Wrapper_ParticipeToMesh(string MeshIs)
        //{
        //    AlertMeshService wrapper;
        //    ///si no existe el mesh/sala lo crea
        //    if (!base.WrapperList.ContainsKey(MeshIs))
        //    {
        //        wrapper = new AlertMeshService(Controller.LoggedColaborator, MeshIs);
        //        base.WrapperList.Add(MeshIs, wrapper);
        //        wrapper.WrapperCallBackEvent += new AlertServiceEventHandler(Wrapper_AlertServiceEvent);

        //        wrapper.ConnectToMesh();
        //    }
        //    else
        //    {
        //        wrapper = (AlertMeshService)base.WrapperList[MeshIs];
        //        if (wrapper != null)
        //        {
        //            wrapper.InvitationsCount++;
        //        }
        //    }
        //}
        ////TODO: pasar al base
        //void Wrapper_ExitFromMeshEvent(string MeshIs)
        //{
        //    ///Si existe lo elimina
        //    if ( base.WrapperList.ContainsKey(MeshIs))
        //    {
        //        AlertBase wrapper = (AlertBase) base.WrapperList[MeshIs];
        //        wrapper.InvitationsCount--;
        //        // Si el numero de invitaciones es 0 ya no hay administrador que tenga este mesh
        //        if (wrapper.InvitationsCount == 0)
        //        {
        //            wrapper.WrapperCallBackEvent -= new AlertServiceEventHandler(Wrapper_AlertServiceEvent);
        //            wrapper.DisconectToMesh();
        //             base.WrapperList.Remove(MeshIs);
        //        }

        //    }
        //}
        //void Wrapper_AlertServiceEvent(object sender, InfoEventArgs e)
        //{
        //    if (this.InvokeRequired)
        //    {
        //        AlertServiceEventHandler d = new AlertServiceEventHandler(Wrapper_AlertServiceEvent);
        //        this.Invoke(d, new object[] { sender, e });
        //    }
        //    else
        //    {
        //        switch (e.CallBackType)
        //        {
        //            case CallBackMessageType.Receive:
        //                Receive(e.Colaborator, e.Message);
        //                break;

        //            case CallBackMessageType.UserEnter:
        //                UserEnter(e.Colaborator);
        //                break;
        //            case CallBackMessageType.UserLeave:
        //                UserLeave(e.Colaborator);
        //                break;

        //        }
        //    }
        //}



        /// <summary>
        /// Procesa el mensaje
        /// </summary>
        /// <param name="sender">El <see cref="Common.Allus.Cnn.Common.Colaborator">que envia el mensaje</see></param>
        /// <param name="message">mensaje</param>
        protected override void Receive(Allus.Cnn.Common.BE.Colaborator sender, string message)
        {

            CurrentMessage = AlertMessage.GetFromXml<AlertMessage>(message);

            CurrentMessage.Sender = sender.Name;
            switch (CurrentMessage.MessageType)
            {
                case MessageType.SimpleText:
                    {
                        PopulateSimpleText();
                        break;
                    }
                case MessageType.RichText:
                    {
                        PopulateRichText();
                        break;
                    }
                case MessageType.Marquee:
                    {
                        PopulateMarquee();
                        break;
                    }
            }

        }

        #region [Populate Message]
        void PopulateSimpleText()
        {
            if (string.Compare(CurrentMessage.Sender.Trim(), base.ColaboratorData.Username.Trim()) == 0)
            {
                //No mostrar el alert para el que envia el msg
                uC_GridMessage_Sended.Populate(CurrentMessage);
            }
            else
            {
                ///Muestra ventana de mensaje
                if (string.IsNullOrEmpty(CurrentMessage.Title))
                    CurrentMessage.Title = "Sin asunto";

                uC_GridMessage_Recived.Populate(CurrentMessage);



                alertControl1.Show(null, CurrentMessage.Title, CurrentMessage.Text);
            }

        }
        private void PopulateRichText()
        {
            if (string.Compare(CurrentMessage.Sender.Trim(), base.ColaboratorData.Username.Trim()) == 0)
            {
                //No mostrar el alert para el que envia el msg
                uC_GridMessage_Sended.Populate(CurrentMessage);
            }
            else
            {

                if (string.IsNullOrEmpty(CurrentMessage.Title))
                    CurrentMessage.Title = "Sin asunto";

                uC_GridMessage_Recived.Populate(CurrentMessage);
                ///Muestra ventana de mensaje
                alertControl1.Show(null, CurrentMessage.Title, string.Empty);
            }
        }

        private void PopulateMarquee()
        {
            ///Muestra ventana de mensaje
            if (string.IsNullOrEmpty(CurrentMessage.Title))
                CurrentMessage.Title = "Sin asunto";
            if (string.Compare(CurrentMessage.Sender.Trim(), base.ColaboratorData.Username.Trim()) == 0)
            {
                //No mostrar el alert para el que envia el msg
                uC_GridMessage_Sended.Populate(CurrentMessage);
            }
            else
            {
                uC_GridMessage_Recived.Populate(CurrentMessage);
            }

            //MarqueeBE wBE = MarqueeBE.GetFromXml<MarqueeBE>(CurrentMessage.Tag.Text);
            //MarqueeForm wMarqueeF = new MarqueeForm();

            //wMarqueeF.Marquee.TextColor = System.Drawing.Color.FromArgb(wBE.Color);
            //wMarqueeF.Marquee.TextDirection = wBE.Direction;
            //wMarqueeF.Marquee.TextToShow = wBE.TextToShow;
            //wMarqueeF.Marquee.TimeToShow = wBE.TimeToShow;
            //wMarqueeF.Marquee.Position = wBE.Position;
            //wMarqueeF.Marquee.Shape = (DigitalBackgroundShapeSetType)Enum.Parse(typeof(DigitalBackgroundShapeSetType), wBE.Shape);
            //wMarqueeF.Marquee.Speed = wBE.Speed;
            //wMarqueeF.Marquee.DigitCount = wBE.DigitCount;
            //wMarqueeF.Marquee.Start();
            //wMarqueeF.Show();

        }
        #endregion
        /// <summary>
        /// Se  produce cuando un colaborador entra sesion
        /// </summary>
        /// <param name="pColaborator"></param>
        private void UserEnter(Colaborator pColaborator)
        {
            MeshFactory.UserJoin(pColaborator);
        }

        /// <summary>
        /// Se  produce cuando un colaborador cierra sesion
        /// </summary>
        /// <param name="pColaborator"></param>
        private void UserLeave(Colaborator pColaborator)
        {
            MeshFactory.UserLeave(pColaborator);
        }
        #endregion



        private void btnConnect_connect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitSession();
        }

        public void ClearConnectionStatus()
        {
            MessageLogs = null;
            MessageLogs = new StringBuilder();
            txtMessageLogger.Text = string.Empty;
            

        }
        public void AddConnectionStatus(string status, string msg)
        {

            if (!string.IsNullOrEmpty(msg))
            {

                MessageLogs.AppendLine(msg);
                MessageLogs.AppendLine("----------------------------------------------------------------------");
                MessageLogs.AppendLine();
                txtMessageLogger.Text = MessageLogs.ToString();
            }
            lblConnectionStatus.Caption = status;
            

        }
        private void iExit_Click(object sender, EventArgs e)
        {
            SettingStorage.Save();
            base.BackgroundConnector.Stop();
            wGenThread.Abort();
            this.ForceClose();
        }

        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SettingStorage.Save();
            base.BackgroundConnector.Stop();
            wGenThread.Abort();
            this.ForceClose();
        }


        private void messageCreator1_SendMessageEvent(object sender, EventArgs e)
        {
            try
            {
                AlertMessage wAlertMessage = (AlertMessage)sender;
                wAlertMessage.MeshName = "Console";
                //Envio el mensaje al mesh por p2p
                base.BackgroundConnector.GlobalWrapper.SendMessage(wAlertMessage);
                //Almaceno el mensaje en BD
                Controller.CreateMessage(wAlertMessage, Controller.LoggedColaborator, adminDomainGrid1.ColaboratorsCountInMesh);
                this.MessageViewer.Show("El mensaje ha sido enviado con éxito");
            }
            catch (Exception ex)
            {
                this.ExceptionViewer.Show(ex);
            }
        }

        /// <summary>
        /// Muestrs el boton de permisos para administrar dominios de usuarios
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPermision_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (AdminDomainsScope frm = new AdminDomainsScope())
            {
                frm.ShowDialog();
            }
        }

        private void grdMeshs_DoubleClick(object sender, EventArgs e)
        {
            MeshBE wMeshBE = (MeshBE)((System.Windows.Forms.BindingSource)gridView1.DataSource).Current;
            bool wIsNew = false;
            MeshFactory.ShowMesh(wMeshBE, out wIsNew);
            //Es nuevo dado que provino de la cache y el mesh no fue creado desde el treeview
            if (wIsNew)
            {
                adminDomainGrid1.GenerateAndShowMesh(wMeshBE);
            }
        }

        private void adminDomainGrid1_ExceptionEvent(object sender, ExceptionEventArgs e)
        {
            this.ExceptionViewer.Show(e.Ex);
            SetConnectionControls("Error conectando...", e.Ex.Message, JoinStatusEnum.Error);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (MailConfig wMailConfig = new MailConfig())
            {
                wMailConfig.ShowDialog();
            }
        }

        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Allus.Cnn.Common.Reports.frmReports wReports = new Allus.Cnn.Common.Reports.frmReports();
            wReports.ShowDialog();
        }


        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            base.ClearCache();
        }



        private void uC_GridMessage_Recived_OnGridClick(object sender, EventArgs e)
        {
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage3;
            base.ClientMessageControl.Populate(uC_GridMessage_Recived.CurrentMessage);

            Common.Common.AddtoPanel(base.ClientMessageControl, pnlMessages);
            base.ClientMessageControl.Dock = DockStyle.Fill;
        }

        private void uC_GridMessage_Sended_OnGridClick(object sender, EventArgs e)
        {
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage3;
            base.ClientMessageControl.Populate(uC_GridMessage_Sended.CurrentMessage);

            Common.Common.AddtoPanel(base.ClientMessageControl, pnlMessages);
            base.ClientMessageControl.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Mensajes proveniente de los formularios meshes (formularios q envian mensajes)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adminDomainGrid1_SendMessageEvent(object sender, EventArgs e)
        {
            CurrentMessage = (AlertMessage)sender;

            uC_GridMessage_Sended.Populate(CurrentMessage);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adminDomainGrid1_OnMeshChangedEvent(object sender, EventArgs e)
        {
            grdMeshs.RefreshDataSource();
        }

        private void adminDomainGrid1_FinalizeMeshEvent(string MeshId)
        {
            
            base.BackgroundConnector.GlobalWrapper.ExitFromMesh(MeshId);
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            using (WeatherConfig frm = new WeatherConfig())
            {
                frm.OnButtonClick += new EventHandler(wWeatherConfig_ButtonClick);
                frm.WindowState = FormWindowState.Normal;
                frm.TopMost = true;
                frm.StartPosition = FormStartPosition.CenterScreen;
                frm.ShowDialog();
            }
        }

        private void wWeatherConfig_ButtonClick(object sender, EventArgs e)
        {
            weatherControlSlim1.LocationCode = SettingStorage.Storage.LocationBE.Code;
            weatherControlSlim1.LocationName = SettingStorage.Storage.LocationBE.Name;
            
            weatherControlSlim1.PopulateAsync();
        }


    }
}