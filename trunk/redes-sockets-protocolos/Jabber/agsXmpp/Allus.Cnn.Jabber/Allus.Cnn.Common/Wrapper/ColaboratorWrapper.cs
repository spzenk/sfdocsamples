using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.ServiceModel;
using System.Windows.Forms;
using ProxyClients.ServiceReference.Asyc;
using Allus.Cnn.Common;
using System.ServiceModel.Channels;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common.Proxy
{
    public class ColaboratorWrapper : WrapperBase,IInfoCallback
    {

        #region Properties
        static ColaboratorWrapper singleton = null;
  
        private delegate void HandleErrorDelegate();
        #endregion

        

        #region Costructor
        private ColaboratorWrapper()
        { }
        /// <summary>
        /// Retorna un singleton <see cref="Wrapper">Wrapper</see>
        /// </summary>
        /// <returns>El Wrapper al proxy<see cref="Wrapper">Wrapper</see></returns>
        public static ColaboratorWrapper GetInstance()
        {
            //(wraper thread-safe) wraper aplica el patron singleton en una seccion critica
            lock (singletonLock)
            {
                if (singleton == null)
                {
                    singleton = new ColaboratorWrapper();
                }
                return singleton;
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


        #region IInfoCallback Members Para eventos Asincronos... No se utilizan
         public void UserEnter(Colaborator Colaborator)
        {
            throw new NotImplementedException();
        }

        public void UserLeave(Colaborator Colaborator)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginReceive(Colaborator sender, string message, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndReceive(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginReceiveBroadcast(Colaborator sender, string message, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndReceiveBroadcast(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUserEnter(Colaborator Colaborator, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndUserEnter(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        public IAsyncResult BeginUserLeave(Colaborator Colaborator, AsyncCallback callback, object asyncState)
        {
            throw new NotImplementedException();
        }

        public void EndUserLeave(IAsyncResult result)
        {
            throw new NotImplementedException();
        }

        #endregion
        #endregion

      






    }

}
