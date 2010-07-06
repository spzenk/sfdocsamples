using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Allus.Cnn.Common.BE;
using Fwk.Exceptions;
using System.Windows.Forms;
using System.Net;

namespace Allus.Cnn.Common
{
    /// <summary>
    /// Delegado para los callbacks de los envios de mensajes al proxy.- delegate used for BroadcastEvent
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void AlertServiceEventHandler(object sender, InfoEventArgs e);
    public delegate void DelegateWithOutAndRefParameters(out Exception ex);
    public delegate void ConnectorWrapperHandler(string Status, string msg, JoinStatusEnum e);



    public static class Common
    {

        public static string DataConfig = "AlertDataConfig";
        public const int Timer_LowSpeed = 10000;
        public const int Timer_HihgtSpeed = 2000;
        public const string ServiceCacheName = "ServiceCache";
        /// <summary>
        /// Constante q reprecenta un valor nulo
        /// </summary>
        public const string NULL = "?";
        /// <summary>
        /// Separador de dominios usados para nombre de mesh de base de datos
        /// </summary>
        public const char DOMAIN_SEPARATOR = '$';
        /// <summary>
        /// Separador de dominios usados para nombre de mesh en p2p
        /// </summary>
        public const char DOMAIN_P2P_SEPARATOR = '_';

        public static ColaboratorData GetColaboratorDataFromMeshId(string meshId)
        {
            if (string.IsNullOrEmpty(meshId)) return null;
            String[] meshIdArray = meshId.Split(DOMAIN_P2P_SEPARATOR);
            
            ColaboratorData wColaboratorData = new ColaboratorData(new MeshBE(String.Empty, meshId));

            return wColaboratorData;
        }

        public static Exception ProcessException(ServiceError err)
        {
            if (err.Type == "FunctionalException")
            {
                return new FunctionalException(err.Message + Environment.NewLine + err.InnerMessageException);
            }
            if (err.Type == "TechnicalException")
            {
                return new TechnicalException(err.Message + Environment.NewLine + err.InnerMessageException);
            }
            return new Exception(err.Message + Environment.NewLine + err.InnerMessageException);
        }
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

        }
        public static string GetMachineIp()
        {
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            System.Net.IPEndPoint Address = new IPEndPoint(ipEntry.AddressList[0], 0);
            return ipEntry.AddressList[1].ToString();
        }
    }
  
    public enum JoinStatusEnum 
    { Connected=0, Exist=1, Error = 2 ,Disconnected=3,Connecting =4,OnLine =5,OffLine=6,Disconecting =7};
    public enum MessageType
    {
        SimpleText = 1,
        RichText = 2,
        Mail = 3,
        Marquee = 4,
        None = 5

    }
    public enum MessageStatus
    {
        Leido = 1,
        NoLeido = 2,
        LeidoYConfirmado= 3,
        LeidoYNoConfirmado = 4
    }



    /// <summary>
    /// Enumeracion de los distintos tipos de mensajes.-
    /// </summary>
    public enum CallBackMessageType { Receive, UserEnter, UserLeave };
    //main proxy event
    public delegate void ProxyEventHandler(object sender, ProxyEventArgs e);

    


 

  
    /// <summary>
    /// Clase que permite llevar a cabo alguna de los 4 acciones (Infocallback)
    /// (Receive, ReceiveBroadcast, UserEnter, UserLeave) <see cref="IInfoCallback">
    /// IInfoCallback</see> for more details
    /// 
    /// Esta clase se usa en los de callbacks al proxy del lado del cliente
    /// </summary>
    public class InfoEventArgs : EventArgs
    {
        /// <summary>
        /// <see cref="CallBackType">Tipo de Callback</see>
        /// </summary>
        public CallBackMessageType CallBackType;
        /// <summary>
        /// Mensaje de entrada
        /// </summary>
        public string Message = string.Empty;
        /// <summary>
        /// El <see cref="Commmon.Colaborator">colaborador</see> que creo el mensaje
        /// </summary>
        public Allus.Cnn.Common.BE.Colaborator Colaborator = null;
    }
    /// <summary>
    /// Proxy event args
    /// </summary>
    public class ProxyEventArgs : EventArgs
    {
        /// <summary>
        /// Lista de colaboradores </see>
        /// </summary>
        ///public Allus.Cnn.Common.BE.Colaborator colaborator;
        public JoinStatusEnum Status;
        public string StatusMessage;

        public string Message;

    }
    public class ExceptionEventArgs : EventArgs
    {
        private Exception _ex;

        public ExceptionEventArgs(Exception ex)
        {

            _ex = ex;
        }
        public Exception Ex
        {
            get { return _ex; }
            set { _ex = value; }
        }
    }

   
}
