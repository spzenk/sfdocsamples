using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Async_Client;

namespace Async_Client
{
    public partial class Form1 : Form
    {
        Async_Client.ServiceReference1.Service1SoapClient svc4;
        svc1.Service1 svc;
        SF.Proxy.Service1 svc2;
        empleadoservice.empladoservice svc3;
        //ServiceReference1.Service1SoapClient svcClient = new Async_Client.ServiceReference1.Service1SoapClient();
        public Form1()
        {
            InitializeComponent();

            
            

         
        }

        void Exect()
        {
            svc = new svc1.Service1();
            svc.ExecuteServiceCompleted += new Async_Client.svc1.ExecuteServiceCompletedEventHandler(svc_ExecuteServiceCompleted);

            svc.ExecuteServiceAsync("Catherine");
            
        }

        void Exect2()
        {
            svc2 = new SF.Proxy.Service1();
            svc2.ExecuteServiceCompleted += new SF.Proxy.ExecuteServiceCompletedEventHandler(svc2_ExecuteServiceCompleted);

            svc2.ExecuteServiceAsync("Catherine");

        }
        void Exec3()
        {
            svc3 = new Async_Client.empleadoservice.empladoservice();
            svc3.HelloWorldCompleted += new Async_Client.empleadoservice.HelloWorldCompletedEventHandler(svc3_HelloWorldCompleted);
            svc3.HelloWorldAsync();

        
        }
        void Exec4()
        {
            svc4 = new Async_Client.ServiceReference1.Service1SoapClient();
            svc4.ExecuteServiceCompleted += new EventHandler<Async_Client.ServiceReference1.ExecuteServiceCompletedEventArgs>(svc4_ExecuteServiceCompleted);
            svc4.ExecuteServiceAsync("");

        
        }

        void svc4_ExecuteServiceCompleted(object sender, Async_Client.ServiceReference1.ExecuteServiceCompletedEventArgs e)
        {
            bindingSource1.DataSource = e.Result;
        }

        void svc3_HelloWorldCompleted(object sender, Async_Client.empleadoservice.HelloWorldCompletedEventArgs e)
        {


            string x = e.Result;
        }
        void svc2_ExecuteServiceCompleted(object sender, SF.Proxy.ExecuteServiceCompletedEventArgs e)
        {
            SF.Proxy.Employee emp = e.Result;

            bindingSource1.DataSource = emp;
        }
        void svc_ExecuteServiceCompleted(object sender, Async_Client.svc1.ExecuteServiceCompletedEventArgs e)
        {
            svc1.Employee empleado = e.Result;
            bindingSource1.DataSource = empleado;
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            Exec4();
           // CreateAsyncCall();
        }

        //void CreateAsyncCall()
        //{
               
        //    AsyncCallback cb = new AsyncCallback(Callback);
        //    IAsyncResult res = svcClient.BeginExecuteService("Catherine", cb, svcClient);
        //    //svcClient.EndExecuteService(res);

        //    while (!res.IsCompleted)
        //    {

        //    }
        //}

        //// when the asynchronous operation completes.
        //public static void Callback(IAsyncResult ar)
        //{
        //    // You passed in our instance of PrimeFactorizer in the third
        //    // parameter to BeginFactorize, which is accessible in the
        //    // AsyncState property.
        //    ServiceReference1.Service1SoapClient pf = (ServiceReference1.Service1SoapClient)ar.AsyncState;
            

        //    // Get the completed results.
        //    Async_Client.ServiceReference1.Employee emp = pf.EndExecuteService(ar);

        //}
    }
}
