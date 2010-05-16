//*****************************************************************************
//    Description.....Custom Remoting for Workflow
//                                
//    Author..........Roman Kiss, rkiss@pathcom.com
//    Copyright © 2006 ATZ Consulting Inc. (see included license.rtf file)        
//                        
//    Date Created:    07/07/06
//
//    Date        Modified By     Description
//-----------------------------------------------------------------------------
//    07/07/06    Roman Kiss     Initial Revision
//*****************************************************************************
//
#region References
using System;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Messaging;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.ServiceModel;
#endregion

// this assembly must be included on the client and server sides for a tightly coupled connectivity such as Remoting. 
namespace InterfaceContract
{
    #region For Test Purposes
    [ServiceContract]
    public interface ITest
    {
        [OperationContract]
        string SayHello(string msg);

        [OneWay]
        [OperationContract(IsOneWay=true)]
        void OneWay(string msg);
    }

    [ServiceContract]
    public interface IFireTest
    {
        [OneWay]
        [OperationContract(IsOneWay = true)]
        [TransactionFlow(TransactionFlowOption.Allowed)]
        void Fire(string msg);
    }



    [Serializable]
    [DataContract(Name = "LogicalTicket", Namespace = "InterfaceContract")]    
    public class LogicalTicket : ILogicalThreadAffinative 
    {
        private string _msg = default(string);
        private Guid _id = default(Guid);
        [DataMember]
        public string Msg
        {
            get { return _msg; }
            set { _msg = value; }
        }
        [DataMember]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public LogicalTicket()
        {            
        }
        public LogicalTicket(Guid id, string msg)
        {
            Msg = msg;
            Id = id;
        }
    }

    public interface Test
    {
        string Echo(string addr);
        string Address(string addr1, string addr2);
        object ProcessMessage(object message);
    }
    #endregion

}
