using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Windows.Forms;
using Allus.Cnn.Common;
using ProxyClients.ServiceReference.Asyc;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common.Proxy
{

    public delegate void HandleErrorDelegate();
    public  delegate void EndGetUsersHandle(Colaborator[] list);


    /// <summary>
    /// No se puede heredar de Wrapper
    /// </summary>
    public sealed class AdminWrapper : WrapperBase,IInfoCallback
    {
        #region Properties
        static AdminWrapper singleton = null;
       
      
        public event EndGetUsersHandle EndGetUsersEvent;
        
      
        #endregion

        #region Costructor
        private AdminWrapper()
        { }
        /// <summary>
        /// Retorna un singleton <see cref="Wrapper">Wrapper</see>
        /// </summary>
        /// <returns>El Wrapper al proxy<see cref="Wrapper">Wrapper</see></returns>
        public static AdminWrapper GetInstance()
        {
            //(wraper thread-safe) wrapper aplica el patron singleton en una seccion critica
            lock (singletonLock)
            {
                if (singleton == null)
                {
                    singleton = new AdminWrapper();
                }
                return singleton;
            }
        }

        #endregion

        #region IInfo Members

        
        public List<Colaborator> GetConnectedUsers()
        {
            List<Colaborator> wColaboratorList = null;
            try
            {
                wColaboratorList = new List<Colaborator>();
                Colaborator[] list = proxy.GetColaborators();
                wColaboratorList.AddRange(list);

            }
            catch (System.TimeoutException )
            {
                throw new Exception ( "El servicor esta tardando demasiado en responder intente conectarce nuevamente");
            }

            return wColaboratorList;
        }

        public void GetConnectedUsersAsync()
        {
            try
            {

                proxy.BeginGetColaborators(new AsyncCallback(EndGetConnectedUsers), null);


            }
            catch (System.TimeoutException)
            {
                throw new Exception("El servicor esta tardando demasiado en responder intente conectarce nuevamente");
            }



        }
        void EndGetConnectedUsers(IAsyncResult res)
        {

            Colaborator[] list = proxy.EndGetColaborators(res);


            if (EndGetUsersEvent != null)
            {
                EndGetUsersEvent(list);
            }
        }
        #endregion



        #region IInfoCallback Members

        public void Receive(Allus.Cnn.Common.BE.Colaborator sender, string message)
        {


            InfoEventArgs e = new InfoEventArgs();
            e.Message = message;
            e.CallBackType = CallBackMessageType.Receive;
            e.Colaborator = sender;
            OnProxyCallBackEvent(e);

        }


        /// <summary>
        /// Inicia sesion un nuevo colaborador 
        /// </summary>
        /// <param name="sender">The <see cref="Common.Colaborator">current chatter</see></param>
        /// <param name="message">The message</param>
        public void UserEnter(Allus.Cnn.Common.BE.Colaborator colaborator)
        {
            UserEnterLeave(colaborator, CallBackMessageType.UserEnter);
        }

        /// <summary>
        /// Se produce cuando un colaborador se desconecta..y el server avisa del suceso
        /// </summary>
        /// <param name="colaborator"></see></param>
        public void UserLeave(Allus.Cnn.Common.BE.Colaborator colaborator)
        {
            UserEnterLeave(colaborator, CallBackMessageType.UserLeave);
        }


        private void UserEnterLeave(Allus.Cnn.Common.BE.Colaborator colaborator, CallBackMessageType callbackType)
        {
            InfoEventArgs e = new InfoEventArgs();
            e.Colaborator = colaborator;
            e.CallBackType = callbackType;
            OnProxyCallBackEvent(e);

        }


        IAsyncResult IInfoCallback.BeginReceive(Colaborator sender, string message, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        void IInfoCallback.EndReceive(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

      


        IAsyncResult IInfoCallback.BeginUserEnter(Colaborator Colaborator, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        void IInfoCallback.EndUserEnter(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

     

        IAsyncResult IInfoCallback.BeginUserLeave(Colaborator Colaborator, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        void IInfoCallback.EndUserLeave(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        #endregion

        
    }
}
