using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProxyClients.ServiceReference.Asyc;
using System.ServiceModel;

namespace Allus.Cnn.Common.Proxy
{
    public class WrapperBase
    {
        public event ProxyEventHandler ProxyEvent;
        protected static readonly object singletonLock = new object();
       protected InfoClient proxy;

       public event AlertServiceEventHandler ProxyCallBackEvent;
     
       /// <summary>
       /// Lanza el evento para los colaboradores conectados
       /// </summary>
       /// <param name="e"><see cref="ProxyCallBackEventArgs">ProxyCallBackEventArgs</see> event args</param>
       protected void OnProxyCallBackEvent(InfoEventArgs e)
       {
           if (ProxyCallBackEvent != null)
           {
               ProxyCallBackEvent(this, e);
           }
       }
       /// <summary>
       /// Lanza el evento a los subcriptores ()
       /// </summary>
       /// <param name="e"><see cref="ProxyEventArgs">ProxyEventArgs</see> event args</param>
       protected void OnProxyEvent(ProxyEventArgs e)
       {
           if (ProxyEvent != null)
           {
               ProxyEvent(this, e);
           }
       }

       #region Llamadas a metodos del servicio InfoService

       /// <summary>
       /// Comienza una operacion asinc sobre el proxy <see cref="InfoClient">InfoClient</see>
       /// cuando se complete la operacion se llamara al metodo OnEndJoin para realizar  (proxy.EndJoin())
       /// </summary>
       /// <param name="p">El <see cref="Common.Colaborator">colaborador</see> que intenta ingresar</param>
       public void Connect(Allus.Cnn.Common.BE.Colaborator colaborator)
       {
           //Si lanza un error :
           //No se encontró el elemento de extremo predeterminado que hace referencia al contrato 
           //Se soluciona confugurando correctamente el contrato del lado del cliente:
           //Ir al endpoint correcto y establecer el nombre completo de la interfaz del servicio.
           //La interfaz debe ser la generada en el proxy ej:
           // contract="[Namenpase][Interfaz]"
           proxy = new InfoClient(new InstanceContext(this));
           IAsyncResult res = proxy.BeginConnect(colaborator, new AsyncCallback(OnEndConnect), null);

       }

       /// <summary>
       /// Es un callback que lo llama BeginJoin que 
       /// </summary>
       /// <param name="res">IAsyncResult</param>
       private void OnEndConnect(IAsyncResult res)
       {
           try
           {
               JoinStatusEnum Status = (JoinStatusEnum)proxy.EndConnect(res);

               ///Si retorna una coleccion nula se cierra la sesion del colaborador y se cierra el proxy
               if (Status == JoinStatusEnum.Error)
               {
                   ProxyEventArgs e = new ProxyEventArgs();
                   e.Status = JoinStatusEnum.Error;
                   e.Message= "Error al intentar conectar el servidor";
                   OnProxyEvent(e);
                   ExitSession();

               }
               else
               {
                   ProxyEventArgs e = new ProxyEventArgs();
                   e.Status = Status;
                   OnProxyEvent(e);//Evento para front end
                   proxy.ChannelFactory.Faulted += new EventHandler(ChannelFactory_Faulted);


               }
           }
           catch (Exception ex)
           {

               ProxyEventArgs e = new ProxyEventArgs();
               e.Status = JoinStatusEnum.Error;
               e.Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
               OnProxyEvent(e);
               ExitSession();
           }
       }
       void ChannelFactory_Faulted(object sender, EventArgs e)
       {
          // MessageBox.Show("ChannelFactory_Faulted", "Colaborador");
       }

       /// <summary>
       /// Envia mensajes
       /// </summary>
       /// <param name="to">A quien va dirigido el mensaje</param>
       /// <param name="msg">El mensaje</param>
       /// <param name="privado">si es rue llama InfoClient.Message()
       /// de lo contrarioInfoClient.BroadCastMessage() method</param>
       public void SendMessage(string to, string msg)
       {
           try
           {
               proxy.SendMessage(to, msg);
           }
           catch
           {
               ProxyEventArgs e = new ProxyEventArgs();
               e.Status = JoinStatusEnum.Error;
               //e.Message = "Error al intentar conectar el administrador";
               OnProxyEvent(e);
               ExitSession();
           }
       }

       /// <summary>
       /// Envia un ping al server 
       /// </summary>
       public void Ping()
       {
           proxy.Ping();
       }

       public bool ProxyNull()
       {
           return (proxy == null);
       }

       /// <summary>
       /// Llama InfoClient.Leave para sacar el colaborador de las session
       /// y AbortProxy() para cerrar el proxy
       /// </summary>
       public void ExitSession()
       {
           try
           {
               proxy.Disconnect();
           }
           catch { }
           finally
           {
               AbortProxy();
           }
       }
       /// <summary>
       /// Llama al metodo Abort y close del proxy 
       /// </summary>
       public void AbortProxy()
       {

           if (proxy != null)
           {
               proxy.Abort();
               proxy.Close();
               proxy = null;
           }

       }
       #endregion

     
    }
}
