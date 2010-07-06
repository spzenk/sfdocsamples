using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Allus.Cnn.Common;
using System.ServiceModel.Description;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common
{

    public delegate void ParticipeToMeshHandler(string MeshIs);
    /// <summary>
    /// Wrapper a mesh global
    /// Este es el Servicio de mesh que tienen todos los endpoints del sistema .-
    /// A partir de este se generan los sub mesh.-
    /// </summary>
    public class AlertService : AlertBase
    {
        public List<String> MeshIdList = new List<string>();
        
        public event ParticipeToMeshHandler ParticipeToMeshEvent;
        public event ParticipeToMeshHandler ExitFromMeshEvent;
        public event EventHandler<ExceptionEventArgs> ExceptionEvent;
        private ColaboratorData _ColaboratorData;

        public ColaboratorData ColaboratorData
        {
            get { return _ColaboratorData; }
            set { _ColaboratorData = value; }
        }
        #region WCF Methods
        public AlertService(Colaborator colaborator)
            : base(colaborator)
        {
            _ColaboratorData = Controller.GetColaboratorDataInstance();             
        }
        //este metodo es llamado des de un hilo como subtarea 
        public override void ConnectToMesh()
        {
     
            Fwk.Exceptions.TechnicalException te = null;
            ProxyEventArgs pe = new ProxyEventArgs();
            pe.Status = JoinStatusEnum.Connecting;
            OnWrapperEvent(pe);
            _site = new InstanceContext(this);
            try
            {

       

                NetPeerTcpBinding binding = new NetPeerTcpBinding("AlertBinding");
                _channelFactory = new DuplexChannelFactory<IAlertChannel>(_site, "AlertEndpoint");
                

                _participant = _channelFactory.CreateChannel();
                //_COMObjecct = ((ICommunicationObject)_channelFactory);

                _ClientChannel = ((IClientChannel)_participant);
                _ClientChannel.OperationTimeout = new TimeSpan(0, 0, 15);
           

                _ParticipantStatus = _participant.GetProperty<IOnlineStatus>();
                //_ParticipantStatus.Online += new EventHandler(ParticipantStatus_Online);
                //_ParticipantStatus.Offline += new EventHandler(ParticipantStatus_Offline);
                

                //Para que un cliente p2p se conecte al mesh se debe ejecutar almenos gun metodo
                _participant.InitMesh();
            }
            catch (System.InvalidOperationException io)
            {
                String err = "Verifique si tiene instalado los siguientes elementos : ";
                err = String.Concat(err, Environment.NewLine);
                err = String.Concat(err, "Ms XP SPK 3.0");
                err = String.Concat(err, Environment.NewLine);
                err = String.Concat(err, "Ms .net Framework 3.5 SPK 1");
                err = String.Concat(err, Environment.NewLine);
                err = String.Concat(err, "Protocolo peer to peer");


                te = new Fwk.Exceptions.TechnicalException(err, io);
              

            }
            catch (System.ServiceModel.CommunicationException e)
            {
                if (e.InnerException != null)
                {


                    int wNativeErrorCode = ((System.ComponentModel.Win32Exception)(e.InnerException)).NativeErrorCode;
                    String err = string.Empty;
                    ///p2p Error WSAEFAULT 10014 DE 
                    if (wNativeErrorCode == 10014)
                    {
                        err = "El servicio de protocolo p2p es posible que no este iniciado";
                        te =
                       new Fwk.Exceptions.TechnicalException(err, e);


                    }
                }

            }
            catch (Fwk.Exceptions.TechnicalException t)
            {
                te = t;
                
            }
            catch (Exception ex)
            {
                te = new Fwk.Exceptions.TechnicalException(ex.Message, ex);
            }
            if (te != null)
            {
                te.Source = "Cnn service";
                if (ExceptionEvent != null)
                    ExceptionEvent(this, new ExceptionEventArgs(te));
                pe = new ProxyEventArgs();
                pe.Status = JoinStatusEnum.Error;
                pe.Message = te.Message;
                OnWrapperEvent(pe);
                return;
            }

            //Para P2P  online/offline significa:
            //Online: el cliente esta conectado con uno o mas pares en el mesh
            //Offline: el cliente esta solo
            //_ParticipantStatus.Online += new EventHandler(ParticipantStatus_Online);
            //_ParticipantStatus.Offline += new EventHandler(ParticipantStatus_Offline);
            _ClientChannel.Opened += new EventHandler(_ClientChannel_Opened);
            _ClientChannel.Closing += new EventHandler(_ClientChannel_Closing);

            _channelFactory.Faulted += new EventHandler(channelFactory_Faulted);
          

            // Estos nos indican cuando se corta la conexion con un channel o cuando nos conectamos a uno
            //_OnlineStatus = ((IOnlineStatus)_ParticipantStatus);
            //_OnlineStatus.Online += new EventHandler(_OnlineStatus_Online);
            //_OnlineStatus.Offline += new EventHandler(_OnlineStatus_Offline);
          


             pe = new ProxyEventArgs();
            pe.Status = JoinStatusEnum.OnLine;
            OnWrapperEvent(pe);
        }

       
        /// <summary>
        /// Envia la señal de participacion en un mesh o sala a los colaboradores
        /// </summary>
        /// <param name="meshId"></param>
        public void ParticipeToMesh(string meshId)
        {
            _participant.JoinSubMesh(_Colaborator.Name, meshId);
        }
        
        /// <summary>
        /// Envia la señal de desconeccion del mesh a los colaboradores que lo tengan creado
        /// </summary>
        /// <param name="meshId"></param>
        public void ExitFromMesh(string meshId)
        {
            _participant.LeaveSubMesh(meshId);
        }

        /// <summary>
        /// Invitacion a prticipar del Mesh .- se valida si el id del mesh descompuesto en los dominios coincide con los dominios del
        /// colaborador
        /// </summary>
        /// <param name="sender">Quien envia la solicitudo de participar al mesh</param>
        /// <param name="meshId">Ej 1_1_2</param>
        public override void JoinSubMesh(string sender, string meshId)
        {
            //Si el que llamo al metodo es = al conectado no se realiza la operacion
            if (_Colaborator.Name.Equals(sender)) return;
            if (Participe(meshId) && ParticipeToMeshEvent != null)
            {
                ParticipeToMeshEvent(meshId);
            }
        }

        /// <summary>
        /// Recive notificacion de salir de un mesh
        /// </summary>
        /// <param name="meshId"></param>
        public override void LeaveSubMesh(string meshId)
        {
            if (ExitFromMeshEvent != null)
            {
                ExitFromMeshEvent(meshId);
            }
        }
        /// <summary>
        /// Verifica si puede participar
        /// </summary>
        /// <param name="meshId"></param>
        /// <returns></returns>
        bool Participe(string meshId)
        {
            //ColaboratorData colToValid = CsucursalId = mesh.SucursalId;ommon.GetColaboratorDataFromMeshId(meshId);
            MeshBE wMeshBE = new MeshBE(String.Empty, meshId);
            return wMeshBE.CanParticipeToMesh(_ColaboratorData);

        }

        /// <summary>
        /// Metodo que busca la existencia de meshes creados en los administradores
        /// solo responden los administradores a esta peticion
        /// </summary>
        /// <param name="sender"></param>
        public override void MeshRequest(string sender)
        {
            //Si el que llamo al metodo es = al conectado no se realiza la operacion
            if (_Colaborator.Name.Equals(sender)) return;

            if (_Colaborator.IsAdmin)//---->> solo si es administrador
            {
                ///Aviso alos colaboradores sobre los meshid creados 
                _participant.MeshResponse(_Colaborator.Name, MeshIdList.ToArray());
            }

        }

        /// <summary>
        /// Respuesta de MeshsRequest esta respuesta es para los admin
        /// </summary>
        /// <param name="sender">nombre de quien hace _participant.MeshResponse(...) Siempre debe ser un administrador</param>
        /// <param name="meshList">Lista enviada por algun administrador</param>
        public override void MeshResponse(string sender, String[] meshList)
        {
            //Si el que llamo al metodo es = al conectado no se realiza la operacion
            if (_Colaborator.Name.Equals(sender)) return;

            foreach (string meshId in meshList)
            {
                JoinSubMesh(sender,meshId);
            }


        }

        /// <summary>
        /// Envia una peticion a los administradores para q le entreguen la lista de meshes creados.-
        /// Ejecuta este metodo q lo capturara el Administrados y retornara el listado de mesh correspondiente
        /// El metodo lo receviran todos los administradores y c/u enviara su lista de mesh creados.-
        /// </summary>
        public void ConnectToExistentMeshes()
        {
          
             _participant.MeshRequest(_Colaborator.Name);
        }


        #endregion



       
    }
}
