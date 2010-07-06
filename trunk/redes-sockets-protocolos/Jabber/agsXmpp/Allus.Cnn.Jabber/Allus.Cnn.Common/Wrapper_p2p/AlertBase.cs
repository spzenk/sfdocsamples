using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common
{
  

    [ServiceContract(Namespace = "http://Allus.wpfchat", CallbackContract = typeof(IAlert))]
    public interface IAlert
    {
        [OperationContract(IsOneWay = true)]
        void GroupMessage(string[] colaboratosTo, string msg);

        [OperationContract(IsOneWay = true)]
        void Message(Colaborator from, string msg);

        [OperationContract(IsOneWay = true)]
        void Connect(Colaborator colaborator);

        [OperationContract(IsOneWay = true)]
        void InitMesh();

        [OperationContract(IsOneWay = true)]
        void JoinSubMesh(string sender, string meshId);

        [OperationContract(IsOneWay = true)]
        void LeaveSubMesh(string meshId);

        [OperationContract(IsOneWay = true)]
        void Disconnect(Colaborator colaborator);
        [OperationContract(IsOneWay = true)]
         void MeshRequest(string sender);
        [OperationContract(IsOneWay = true)]
        void MeshResponse(string sender ,String[] meshIdList );
    }

   
    public interface IAlertChannel : IAlert, IClientChannel
    {
    }
    public abstract class AlertBase : IAlert
    {
        #region Events
        public event ProxyEventHandler WrapperEvent;

        /// <summary>
        /// Evento lanzado cuando llega un callback de otro cliente del mesh
        /// </summary>
        public event AlertServiceEventHandler WrapperCallBackEvent;

        /// <summary>
        /// Lanza el evento para los colaboradores conectados
        /// </summary>
        protected void OnWrapperCallBackEvent(InfoEventArgs e)
        {
            if (WrapperCallBackEvent != null)
            {
                WrapperCallBackEvent(this, e);
            }
        }
        /// <summary>
        /// Lanza el evento a los subcriptores ()
        /// </summary>
        protected void OnWrapperEvent(ProxyEventArgs e)
        {
            if (WrapperEvent != null)
            {
                WrapperEvent(this, e);
            }
        }
        #endregion

        #region Instance Fields && constructors
        /// <summary>
        /// Identifica el numero de invitaciones para este mesh.- 
        /// Esto es debido a que este mesh puede ser generado (salas) desde multiples administradores
        /// El valor de inicio es uno ya que cuando se crea es por que ya pertenece a una invitacion de 
        /// un administrador
        /// </summary>
        public int InvitationsCount = 1;
        //the chat member name
        protected string _MeshId;
        protected Colaborator _Colaborator;
        protected IClientChannel _ClientChannel;
        protected IOnlineStatus _OnlineStatus;

        //the channel instance where we execute our service methods against
        protected IAlertChannel _participant;
        //the instance context which in this case is our window since it is the service host
        protected InstanceContext _site;

        //the factory to create our chat channel
        protected ChannelFactory<IAlertChannel> _channelFactory;
      
        //Interfaz provista por el canal q indica cuando estamos online u off-line.- 
        protected IOnlineStatus _ParticipantStatus;
        //a generic delegate to execute a thread against that accepts no args
        protected delegate void NoArgDelegate();
        public AlertBase(Colaborator colaborator)
        { _Colaborator = colaborator; }
        #endregion

        
        public abstract void ConnectToMesh();

        public void DisconectToMesh()
        {
            if (_participant == null) return;
            if (_participant.State == CommunicationState.Opened)
            {
                _participant.Disconnect(_Colaborator);

            }
            _participant.Close();
        }
        public void SendMessage(AlertMessage alertMessage)
        {
            
            _participant.Message(_Colaborator, alertMessage.GetXml());
            
        }


        #region IOnline.Status Event Handlers
        protected void _ClientChannel_Closing(object sender, EventArgs e)
        {
            // _participant.Disconnect(_Colaborator);
         
            ProxyEventArgs pe = new ProxyEventArgs();
            pe.Status = JoinStatusEnum.OffLine;
            OnWrapperEvent(pe);
        }


        protected void _ClientChannel_Opened(object sender, EventArgs e)
        {
            _participant.Connect(_Colaborator);

            ProxyEventArgs pe = new ProxyEventArgs();
            pe.Status = JoinStatusEnum.OnLine;
            OnWrapperEvent(pe);
        }
        protected void channelFactory_Faulted(object sender, EventArgs e)
        {
            ProxyEventArgs pe = new ProxyEventArgs();
            pe.Status = JoinStatusEnum.Error;
            OnWrapperEvent(pe);
        }
        

        
       
        
   

        #endregion

        #region IAlert Members

       

        /// <summary>
        /// Llego un msg
        /// </summary>
        /// <param name="from"></param>
        /// <param name="msg"></param>
        public void Message(Colaborator from, string msg)
        {
            InfoEventArgs pe = new InfoEventArgs();
            pe.CallBackType = CallBackMessageType.Receive;
            pe.Colaborator = from;
            pe.Message = msg;
            OnWrapperCallBackEvent(pe);
        }

        /// <summary>
        /// Se conecto alguien
        /// </summary>
        /// <param name="colaborator"></param>
        public void Connect(Colaborator colaborator)
        {
            if (colaborator.Name.Equals(_Colaborator.Name)) return;//Si la entrada prviene del mismo enviador se retorna.-
            if (!_Colaborator.IsAdmin) return;//La info es solo importante para administradores.-

            InfoEventArgs pe = new InfoEventArgs();
            pe.CallBackType = CallBackMessageType.UserEnter;
            pe.Colaborator = colaborator;
            OnWrapperCallBackEvent(pe);

        }
        /// <summary>
        /// Solo se usa para inicializar el mesh
        /// </summary>
        public void InitMesh()
        {

        }
        /// <summary>
        /// Se desconecto alguien
        /// </summary>
        /// <param name="colaborator">Colaborador q se desconecto</param>
        public void Disconnect(Colaborator colaborator)
        {
            if (colaborator.Name.Equals(_Colaborator.Name)) return;//Si la entrada prviene del mismo enviador se retorna.-
            if (!_Colaborator.IsAdmin) return;//La info es solo importante para administradores.-
            
            InfoEventArgs pe = new InfoEventArgs();
            pe.CallBackType = CallBackMessageType.UserLeave;
            pe.Colaborator = colaborator;
            OnWrapperCallBackEvent(pe);
        }

        #region [Solo se implementan estos mesh en el wraper Global]
        /// <summary>
        /// Recive una invitacion a participar  una sala o mesh
        /// </summary>
        /// <param name="meshId"></param>
        public virtual void JoinSubMesh(string sender, string meshId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Recive una peticion para finalizar  una sala o mesh
        /// </summary>
        /// <param name="meshId"></param>
        public virtual void LeaveSubMesh(string meshId)
        {
            throw new NotImplementedException();
        }
        public void GroupMessage(string[] colaboratosTo, string msg)
        {
            throw new NotImplementedException();
        }
        public virtual void MeshRequest(string sender)
        {
            throw new NotImplementedException();
        }

        public virtual void MeshResponse(string sender, string[] meshIdList)
        {
            throw new NotImplementedException();
        }

     
        #endregion

        #endregion

        public bool ProxyNull()
        {
            if(_participant == null) return false;
            if(_participant.State == CommunicationState.Opening) return false;

            bool disconectedOrFaulted = (_participant.State == CommunicationState.Faulted
                || _participant.State == CommunicationState.Closed
                  || _participant.State == CommunicationState.Closing
               
                );
            return disconectedOrFaulted;
        }

        ///// <summary>
        ///// Envia un ping al server 
        ///// </summary>
        //public void Ping()
        //{
        //    _participant.InputSession.Id;
        //}

      
    }

 

}
