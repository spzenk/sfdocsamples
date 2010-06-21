using  System;
using System.Collections.Generic;
using System.Text;
using Fwk.BusinessFacades;
using Fwk.Bases;
using System.Diagnostics;
using System.Runtime.Remoting.Lifetime;

namespace Fwk.Remoting
{
    /// <summary>
    /// Clase remota que se ejecuta en el servicio remoting dispatcher
    /// </summary>
    public class FwkRemoteObjectTest : MarshalByRefObject
    {
        List<string> clientList = new List<string>();

        private int _Value1 = 0;
        private string _CurrentClientName;
        private static int _StaticValue1 = 0;

        public override object InitializeLifetimeService()
        {
            ILease lease = (ILease)base.InitializeLifetimeService();
            if (lease.CurrentState == LeaseState.Initial)
            {
                //lease.InitialLeaseTime = TimeSpan.FromMinutes(1);
                //lease.SponsorshipTimeout = TimeSpan.FromMinutes(2);
                //lease.RenewOnCallTime = TimeSpan.FromSeconds(2);
                lease.InitialLeaseTime = TimeSpan.FromSeconds(5);
                lease.SponsorshipTimeout = TimeSpan.FromSeconds(10);
                lease.RenewOnCallTime = TimeSpan.FromSeconds(2);

            }
            return lease;
            //return base.InitializeLifetimeService();
        }
        
        public override System.Runtime.Remoting.ObjRef CreateObjRef(Type requestedType)
        {
            return base.CreateObjRef(requestedType);
        }
        //public FwkRemoteObjectTest()
        //{
        //    _EnvironmentUserName = Environment.UserName;
        //}
      

        public void Metodo1(string clientName)
        {
            //SimpleFacade wSimpleFacade = new SimpleFacade();
            if (clientList.Contains(clientName) == false)
            {
                clientList.Add(clientName);
            }
            _CurrentClientName = clientName;

        }
        public void SetValue_1(int value)
        {
            _Value1 = value;
            FwkRemoteObjectTest._StaticValue1 = value;
        }

        public Dictionary<string, string> GetStatus()
        {
            Dictionary<string, string> _Status = new Dictionary<string, string>();
            StringBuilder str = new StringBuilder();
            foreach (string s in clientList)
            {
                str.AppendLine(s);
            }
            _Status.Add("EnvironmentUserName:   ", Environment.UserName);
            _Status.Add("CurrentClient:         ", _CurrentClientName);
            _Status.Add("Value1:                ", _Value1.ToString());
            _Status.Add("Static Value1:                ", _StaticValue1.ToString());
            _Status.Add("Client List", str.ToString());

            return _Status;
        }

        public List<string> GetClients()
        {
            return clientList;
        }
    }
}
