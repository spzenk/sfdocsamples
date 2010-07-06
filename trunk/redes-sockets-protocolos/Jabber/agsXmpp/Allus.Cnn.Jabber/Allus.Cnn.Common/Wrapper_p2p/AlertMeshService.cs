using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Windows.Forms;
using System.ServiceModel.Description;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.Common
{
   
    /// <summary>
    /// Wraper a Sub mesh 
    /// </summary>
    public class AlertMeshService : AlertBase
    {
       
        #region WCF Methods
        public AlertMeshService(Colaborator colaborator,string meshId):base(colaborator)
        {
            _MeshId = meshId.Replace(Common.DOMAIN_SEPARATOR, Common.DOMAIN_P2P_SEPARATOR);
        }

        public override  void ConnectToMesh()
        {
            ProxyEventArgs pe = new ProxyEventArgs();
            pe.Status = JoinStatusEnum.Connecting;
            
            OnWrapperEvent(pe);

            //since this window is the service behavior use it as the instance context
            _site = new InstanceContext(this);


            //Generacion dinamica del mesh
            EndpointAddress endpointAddress = new EndpointAddress(string.Concat("net.p2p://Mesh/", _MeshId));
            NetPeerTcpBinding binding = new NetPeerTcpBinding("AlertBinding");
            binding.Security.Mode = SecurityMode.None;
            binding.MaxReceivedMessageSize = 665600;
            binding.Port = 0;


            ServiceEndpoint endpoint = new ServiceEndpoint(ContractDescription.GetContract(typeof(IAlert)), binding, endpointAddress);

            _channelFactory = new DuplexChannelFactory<IAlertChannel>(_site, endpoint);


            _participant = _channelFactory.CreateChannel();


            _ClientChannel = ((IClientChannel)_participant);
            _ClientChannel.OperationTimeout = new TimeSpan(0, 0, 15);


            _ParticipantStatus = _participant.GetProperty<IOnlineStatus>();
    

            _channelFactory.Faulted += new EventHandler(channelFactory_Faulted);

            _participant.InitMesh();



            // Estos nos indican cuando se corta la conexion con un channel o cuando nos conectamos a uno
            //_OnlineStatus = ((IOnlineStatus)_ParticipantStatus);
            //_OnlineStatus.Offline += new EventHandler(_OnlineStatus_Offline);
            //_OnlineStatus.Online += new EventHandler(_OnlineStatus_Online);


             pe = new ProxyEventArgs();
            pe.Status = JoinStatusEnum.Connected;
            OnWrapperEvent(pe);
        }


        #endregion

        

        

        
    }
}
