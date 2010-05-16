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
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Threading;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Runtime.Serialization;
//
using RKiss.WorkflowRemoting;
using InterfaceContract;
#endregion

namespace Server
{
    // wcf service for workflow exposing
    [ServiceBehavior(IncludeExceptionDetailInFaults=true)]
    public class WorkflowService : ITest
    {
        #region ITest Members
        //[WorkflowInvoker(WorkflowType = typeof(WorkflowLibrary.Workflow4), WorkflowInitDataKey="InitData", ResponseTime=45, CallContextActors = "InterfaceContract")] 
        [WorkflowInvoker(CallContextActors = "InterfaceContract, myActor")]
        //[WorkflowInvoker]
        public string SayHello(string msg)
        {
            throw new NotImplementedException();
        }

        [WorkflowInvoker(WorkflowType = typeof(WorkflowLibrary.Workflow6), CallContextActors = "InterfaceContract", WorkflowInitDataKey = "InitData")]
        //[WorkflowInvoker]
        public void OneWay(string msg)
        {
            throw new NotImplementedException();            
        }
        #endregion
    }

    // wcf service for workflow exposing
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class WorkflowService2 : IFireTest
    {
        #region ITest Members     
        [WorkflowInvoker]
        [OperationBehavior(TransactionAutoComplete=true, TransactionScopeRequired=true)]    
        public void Fire(string msg)
        {
            throw new NotImplementedException();
        }
        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = null;
            ServiceHost host2 = null;

            try
            {                 
                // WCF services 
                host = new ServiceHost(typeof(WorkflowService));
                host.Open();

                host2 = new ServiceHost(typeof(WorkflowService2));
                host2.Open();

                // remoting 
                string configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                RemotingConfiguration.Configure(configFile, false);
   
                // workflow 
                WorkflowRuntime wr = WorkflowHosting.Attach("WorkflowRuntimeConfig", "LocalServicesConfig");

                // workflowruntime handlers for trace purpose
                wr.WorkflowIdled += new EventHandler<WorkflowEventArgs>(wr_WorkflowIdled);
                wr.WorkflowPersisted += new EventHandler<WorkflowEventArgs>(wr_WorkflowPersisted);
                wr.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(wr_WorkflowCompleted);
                wr.WorkflowCreated += new EventHandler<WorkflowEventArgs>(wr_WorkflowCreated);
                wr.WorkflowStarted += new EventHandler<WorkflowEventArgs>(wr_WorkflowStarted);
                wr.WorkflowLoaded += new EventHandler<WorkflowEventArgs>(wr_WorkflowLoaded);
                wr.WorkflowUnloaded += new EventHandler<WorkflowEventArgs>(wr_WorkflowUnloaded);

                // processing
                Console.Write("Hit <enter> to exit server...\n");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            finally
            {
                // clean-up
                WorkflowHosting.Detach();

                if (host != null)
                    host.Close();
                if (host2 != null)
                    host2.Close();
            }
        }

        #region handlers
        static void wr_WorkflowUnloaded(object sender, WorkflowEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Unloaded:\t{0}", e.WorkflowInstance.InstanceId);
            Console.ResetColor();
        }

        static void wr_WorkflowLoaded(object sender, WorkflowEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Loaded:\t{0}", e.WorkflowInstance.InstanceId);
            Console.ResetColor();
        }

        static void wr_WorkflowStarted(object sender, WorkflowEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Started:\t{0}", e.WorkflowInstance.InstanceId);
            Console.ResetColor();
        }

        static void wr_WorkflowCreated(object sender, WorkflowEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Created:\t{0}, {1}", e.WorkflowInstance.InstanceId, e.WorkflowInstance.GetWorkflowDefinition().Name);
            Console.ResetColor();
        }

        static void wr_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Completed:\t{0}", e.WorkflowInstance.InstanceId);
            Console.ResetColor();
        }

        static void wr_WorkflowPersisted(object sender, WorkflowEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Persisted:\t{0}", e.WorkflowInstance.InstanceId);
            Console.ResetColor();
        }

        static void wr_WorkflowIdled(object sender, WorkflowEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Idled:\t\t{0}", e.WorkflowInstance.InstanceId);
            Console.ResetColor();
        }

        private static void process_Exited(object sender, EventArgs e)
        {
            // workflow
            WorkflowHosting.Detach();
        }
        #endregion
      
    }


    // for testing purpose
    //public class TestObject : MarshalByRefObject, ITest
    //{
    //    public string SayHello(string msg)
    //    {
    //        Console.WriteLine("RemObject.SayHello({0})", msg);
    //        return "Hello" + " " + msg;
    //    }

    //    [OneWay]
    //    public void OneWay(string msg)
    //    {
    //        //Thread.Sleep(3000);
    //        Console.WriteLine("RemObject.OneWay({0})", msg);
    //    }
    //}

}
