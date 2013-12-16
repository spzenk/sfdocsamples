using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WcfDispatcher;
using Fwk.Bases;
using Fwk.HelperFunctions;
using System.Reflection;


namespace WcfDispatcher_Host
{
    //WcfSvcHost.exe /service:D:\Projects\Allus\Bigbang\trunk\tools\WcfDispatcher\WcfDispatcher_Host\bin\Debug\WcfDispatcher.dll /config:D:\Projects\Allus\Bigbang\trunk\tools\WcfDispatcher\WcfDispatcher_Host\App.config
    class Program
    {
        static void Main(string[] args)
        {
            //string reqInfo = "Health.Isvc.RetrivePatients.RetrivePatientsReq, Health.SVC, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            //IServiceContract wRequest = (IServiceContract)ReflectionFunctions.CreateInstance(reqInfo);
            //Type reqType = Type.GetType(reqInfo);
            //Type reqType = ReflectionFunctions.CreateType(reqInfo);
           var d = Assembly.Load("Health.SVC");
            

            using (ServiceHost host = new ServiceHost(typeof(FwkService)))
            {
                host.Open();
                MetadataHelper.Log_ServiceHost(host);
                Console.ReadLine();
            }

            
        }

        void SetNetTcpBinding(ServiceHost host)
        {

            NetTcpBinding tcpBinding = new NetTcpBinding();
            Uri wUri = new Uri("net.tcp://santana:8001/FwkService1");
            tcpBinding.TransactionFlow = true;

            host.AddServiceEndpoint(typeof(IFwkService), tcpBinding, wUri);
            host.Open();
        }

    }


}
