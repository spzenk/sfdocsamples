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

        private string _ClientName;
        private string _EnvironmentUserName;
        public void Metodo1(string clientName)
        {
            SimpleFacade wSimpleFacade = new SimpleFacade();
            _EnvironmentUserName = Environment.UserName;
            _ClientName = clientName;

        }
    }
}
