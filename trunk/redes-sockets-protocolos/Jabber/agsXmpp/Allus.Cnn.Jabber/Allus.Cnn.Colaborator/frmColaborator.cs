using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Allus.Cnn.Common;
using Allus.Cnn.Common.Proxy;
using System.Net;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Threading;
using Allus.Cnn.Common.BE;
using DevExpress.XtraGauges.Core.Model;


namespace Allus.Cnn.Colaborator
{
    public partial class frmColaborator : frmBaseP2P
    {
        #region Fields
        Thread wGenThread;
  
       
        #endregion

        public frmColaborator()
        {
            InitializeComponent();
        }

        private void frmColaborator_Load(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(1000);
            InitControls();
            InitSession();            
        }

       /// <summary>
        /// Llama al InitControls del base y llena weatherControlSlim1
       /// </summary>
        protected override void InitControls()
        {
            base.InitControls();

            weatherControlSlim1.LanguageWeather = "es";
            weatherControlSlim1.PopulateAsync();
        }

        /// <summary>
        /// Inicializa la instancia del wrapper bajo patron singleton.-
        /// Inicializa los manejadores del wrapper.-
        /// Inicializa el menejador del  BackgroundP2PConnector que lanza los eventos del wraper de forma asincrona.-
        /// </summary>
        void InitSession()
        {
            base.InitSeccion();
            //base.LoadingForm = new frmLoading();
            //base.LoadingForm.Show();
             //AlertService wGlobalWrapper = null;
             //wGlobalWrapper = new AlertService(Controller.LoggedColaborator);

            //wGlobalWrapper.WrapperCallBackEvent += new AlertServiceEventHandler(Wrapper_AlertServiceEvent);

            //wGlobalWrapper.ParticipeToMeshEvent += new ParticipeToMeshHandler(Wrapper_ParticipeToMesh);
            //wGlobalWrapper.ExitFromMeshEvent += new ParticipeToMeshHandler(Wrapper_ExitFromMeshEvent);
            //wGlobalWrapper.ExceptionEvent += new EventHandler<ExceptionEventArgs>(Wrapper_ExceptionEvent);

            //base.BackgroundP2PConnector = new BackgroundP2PConnector(wGlobalWrapper);

            base.BackgroundConnector.Event += new ConnectorWrapperHandler(BackConnector_Event);
            wGenThread = new Thread(new ThreadStart(base.BackgroundConnector.Start));
            wGenThread.Start();


        }

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
                panelControl1.Visible = false;
                this.lblConnectionStatus.Glyph = global::Allus.Cnn.Colaborator.Properties.Resources.ball_yellow;
                AddConnectionStatus(statusMessage, msg);
                return;
            }
            this.btnConnect.Enabled = true;
            //"Desconectado"
            if (status == JoinStatusEnum.OffLine || status == JoinStatusEnum.Disconnected)
            {
                this.lblConnectionStatus.Glyph = global::Allus.Cnn.Colaborator.Properties.Resources.ball_yellow;
                panelControl1.Visible = false;
                btnConnect.Caption = "Desconectar";
                btnConnect.Glyph = global::Allus.Cnn.Colaborator.Properties.Resources.internet_close_16;
            }
            //"Error"
            if (status == JoinStatusEnum.Error)
            {
                panelControl1.Visible = false;
                btnConnect.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;

                this.lblConnectionStatus.Glyph = global::Allus.Cnn.Colaborator.Properties.Resources.ball_red;
                AddConnectionStatus(statusMessage, msg);
                return;
            }
            //"Conectado"
            if (status == JoinStatusEnum.Connected || status == JoinStatusEnum.OnLine)
            {
                panelControl1.Visible = true;
                btnConnect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                this.lblConnectionStatus.Glyph = global::Allus.Cnn.Colaborator.Properties.Resources.ball_green;
                Thread wGenThread_Wrapper = new Thread(new ThreadStart(base.BackgroundConnector.GlobalWrapper.ConnectToExistentMeshes));
                base.LoadingForm.Close();
                wGenThread_Wrapper.Start();
            }
            ClearConnectionStatus();

        }


        #region Callback methods [Avisos del servidor sobre mensajes nuevos]

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
        //         wrapper = (AlertMeshService)base.WrapperList[MeshIs];
        //        if (wrapper != null)
        //        {
        //            wrapper.InvitationsCount++;
        //        }
        //    }
        //}

        //void Wrapper_ExitFromMeshEvent(string MeshIs)
        //{
        //    ///Si existe lo elimina
        //    if (base.WrapperList.ContainsKey(MeshIs))
        //    {
        //        AlertBase wrapper = (AlertBase)base.WrapperList[MeshIs];
        //        wrapper.InvitationsCount--;
        //        // Si el numero de invitaciones es 0 ya no hay administrador que tenga este mesh
        //        if (wrapper.InvitationsCount == 0)
        //        {
        //            wrapper.WrapperCallBackEvent -= new AlertServiceEventHandler(Wrapper_AlertServiceEvent);
        //            wrapper.DisconectToMesh();
        //            base.WrapperList.Remove(MeshIs);
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
        //        }
        //    }
        //}

        #endregion
        /// <summary>
        /// Procesa el mensaje
        /// </summary>
        /// <param name="sender">El <see cref="Common.Allus.Cnn.Common.Colaborator">que envia el mensaje</see></param>
        /// <param name="message">mensaje</param>
        protected override void Receive(Allus.Cnn.Common.BE.Colaborator sender, string message)
        {

            base.CurrentMessage = AlertMessage.GetFromXml<AlertMessage>(message);
            base.CurrentMessage.Sender = sender.Name;
            switch (base.CurrentMessage.MessageType)
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


        #region  Manejo de msj

       
        public static void AddtoPanel(Control pControlToAdd, Control pContainerControl)
        {

            if (pContainerControl.Contains(pControlToAdd)) return;

            pControlToAdd.Location = new System.Drawing.Point(1, 1);
            pControlToAdd.Width = pContainerControl.Width - 60;
            pControlToAdd.Height = pContainerControl.Height - 60;
            pControlToAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                   | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            pContainerControl.Controls.Clear();
            pContainerControl.Controls.Add(pControlToAdd);
            pControlToAdd.Dock = DockStyle.Fill;

        }

        #region [Populate Message]

        void PopulateSimpleText()
        {
            ///Muestra ventana de mensaje
            if (string.IsNullOrEmpty(base.CurrentMessage.Title))
                base.CurrentMessage.Title = "Sin asunto";

            uC_GridMessage1.Populate(base.CurrentMessage);

            //alertControl1.Show(null, base.CurrentMessage.Title, base.CurrentMessage.Text);
            alertControl1.Show(null, base.CurrentMessage.Title, base.CurrentMessage.Text, null, null, base.CurrentMessage.MessageGuid);
        }

        private void PopulateRichText()
        {
            ///Muestra ventana de mensaje
            if (string.IsNullOrEmpty(base.CurrentMessage.Title))
                base.CurrentMessage.Title = "Sin asunto";

            uC_GridMessage1.Populate(base.CurrentMessage);

            alertControl1.Show(null, base.CurrentMessage.Title,  base.CurrentMessage.TextNoRtf, null, null, base.CurrentMessage.MessageGuid);
        }

        private void PopulateMarquee()
        {
            ///Muestra ventana de mensaje
            if (string.IsNullOrEmpty(base.CurrentMessage.Title))
                base.CurrentMessage.Title = "Sin asunto";

            uC_GridMessage1.Populate(base.CurrentMessage);

            MarqueeBE wBE = MarqueeBE.GetFromXml<MarqueeBE>(base.CurrentMessage.Tag.Text);
            MarqueeForm wMarqueeF = new MarqueeForm();

            wMarqueeF.Marquee.TextColor = System.Drawing.Color.FromArgb(wBE.Color);
            wMarqueeF.Marquee.TextDirection = wBE.Direction;
            wMarqueeF.Marquee.TextToShow = wBE.TextToShow;
            wMarqueeF.Marquee.TimeToShow = wBE.TimeToShow;
            wMarqueeF.Marquee.Position = wBE.Position;
            wMarqueeF.Marquee.Shape = (DigitalBackgroundShapeSetType)Enum.Parse(typeof(DigitalBackgroundShapeSetType), wBE.Shape);
            wMarqueeF.Marquee.Speed = wBE.Speed;
            wMarqueeF.Marquee.DigitCount = wBE.DigitCount;
            wMarqueeF.Marquee.Link = base.CurrentMessage.Url;
            wMarqueeF.Marquee.LinkColor = System.Drawing.Color.FromArgb(wBE.TextoLinkColor);
            wMarqueeF.Marquee.LinkText = wBE.TextLink;
            wMarqueeF.Marquee.Start();
            wMarqueeF.Show();
        }

        #endregion
        #endregion

        private void btnConnect_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            InitSession();
        }

     
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
            base.BackgroundConnector.Stop();
            wGenThread.Abort();
            this.ForceClose();
        }

        private void iExit_Click(object sender, EventArgs e)
        {
            base.BackgroundConnector.Stop();
            wGenThread.Abort();
            this.ForceClose();
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

        private void alertControl1_ButtonClick(object sender, DevExpress.XtraBars.Alerter.AlertButtonClickEventArgs e)
        {          
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
        }
        

        private void uC_GridMessage1_OnGridClick(object sender, EventArgs e)
        {
            base.ClientMessageControl.Populate(uC_GridMessage1.CurrentMessage);
            base.ClientMessageControl.Dock = DockStyle.Fill;
            AddtoPanel(base.ClientMessageControl, panelControl1);
        }


        private void alertControl1_AlertClick(object sender, DevExpress.XtraBars.Alerter.AlertClickEventArgs e)
        {
            uC_GridMessage1.AlertClick(sender, e);
            alertControl1.AutoFormDelay = 0;
            this.WindowState = FormWindowState.Normal;
            this.Show();
            this.BringToFront();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            using (MailConfig wMailConfig = new MailConfig(true))
            {
                wMailConfig.ShowDialog();
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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

        private void btnClearCache_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            base.ClearCache();            
        }   

    }
}
