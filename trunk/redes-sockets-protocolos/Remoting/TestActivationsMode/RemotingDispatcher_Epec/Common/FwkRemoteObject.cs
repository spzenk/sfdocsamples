using  System;
using System.Collections.Generic;
using System.Text;
using Fwk.BusinessFacades;
using Fwk.Bases;
using System.Diagnostics;

namespace Fwk.Remoting
{
    /// <summary>
    /// Clase remota que se ejecuta en el servicio remoting dispatcher
    /// </summary>
    public class FwkRemoteObjectTest : MarshalByRefObject
    {
        //public FwkRemoteObjectTest()
        //{
        //    _EnvironmentUserName = Environment.UserName;
        //}
        List<string> clientList = new List<string>();
        
        private int _Value1 = 0;
        private string _CurrentClientName;


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
            _Status.Add("Client List", str.ToString());

            return _Status;
        }

        public List<string> GetClients()
        {
            return clientList;
        }
    }
}
