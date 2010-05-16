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
using System.Diagnostics;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Workflow.Runtime;
using System.Workflow.ComponentModel.Compiler;
//
using InterfaceContract;
using RKiss.WorkflowRemoting;
#endregion

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = string.Empty;
            Process.GetCurrentProcess().Exited += new EventHandler(process_Exited);

            // test option
            bool bIsStateMachineTest = false;

            try
            {
                // hosting remoting 
                string configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                RemotingConfiguration.Configure(configFile, false);

                // hosting workflow and trace handlers
                WorkflowRuntime wr = WorkflowHosting.Attach("WorkflowRuntimeConfig", "LocalServicesConfig");
                wr.WorkflowIdled += new EventHandler<WorkflowEventArgs>(wr_WorkflowIdled);
                wr.WorkflowPersisted += new EventHandler<WorkflowEventArgs>(wr_WorkflowPersisted);
                wr.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(wr_WorkflowCompleted);
                wr.WorkflowCreated += new EventHandler<WorkflowEventArgs>(wr_WorkflowCreated);
                wr.WorkflowStarted += new EventHandler<WorkflowEventArgs>(wr_WorkflowStarted);
                wr.WorkflowLoaded += new EventHandler<WorkflowEventArgs>(wr_WorkflowLoaded);
                wr.WorkflowUnloaded += new EventHandler<WorkflowEventArgs>(wr_WorkflowUnloaded);

                // workflow init data
                Dictionary<string, object> dictionary = new Dictionary<string, object>();
                HybridDictionary initData = new HybridDictionary();
                initData["abc"] = 12345;
                dictionary.Add("InitData", initData);
                dictionary.Add("Counter", 10);

                // create and persiste our test state machine (myWorkflow6), - SqlWorkflowPersistenceService is required 
                Guid stateMachineId = Guid.NewGuid();
                bool bIsUnloaded = WorkflowInvoker.CreateAndUnload("myWorkflow6", dictionary, stateMachineId);
                Console.WriteLine("StateMachine {0} has been created and unloaded={1}\n\n", stateMachineId, bIsUnloaded);

                for (int ii = 0; ii < 10000; ii++)
                {
                    // each call will have an unique context
                    using (LogicalWorkflowContext lwc = LCC.LogicalWorkflowContext)
                    {
                        // application specific Context for test purpose
                        CallContext.SetData("LogicalTicket", new LogicalTicket(Guid.NewGuid(), Convert.ToString(ii)));
                        CallContext.SetData("Ticket", Guid.NewGuid());
                        lwc.Properties["MyTest"] = DateTime.Now;

                        // some workflow init data                      
                        lwc.WorkflowInitData["InitData"] = initData;

                        // use this Guid (for persisted state machine) - SqlWorkflowPersistenceService is required 
                        //lwc.WorkflowId = stateMachineId;

                        // endpoint scenarios for some kind of tests
                        string endpoint = "wf://localhost/myWorkflow5";   // tcp remoting (workflow5)
                        //endpoint = "tcp://localhost:1234/myWorkflow5";  // null remoting 
                        //endpoint = "tcp://localhost:1234/myWorkflow6";  // tcp remoting - state machine
                        //endpoint = "wf://localhost/myWorkflow6";        // null remoting - state machine
                        //endpoint = "tcp://localhost:1234/myWorkflow4";  // tcp remoting with chaining (workflow4 -> workflow5)
                        //endpoint = "wf://localhost/myWorkflow4";        // null remoting
                        //endpoint = "wf://localhost/myWorkflow7";        // null remoting - workflow craeted by xoml 
                        //endpoint = "wcf://myWorkflow4";                   // wcf/workflow invoker
                        

                        
                        if (bIsStateMachineTest)
                        {
                            // action 1: - standard way 
                            ITest test = (ITest)Activator.GetObject(typeof(ITest), endpoint);
                            response = test.SayHello(string.Format("[{0}]: Hello world", ii));

                            // use the same state machine - SqlWorkflowPersistenceService is required 
                            LCC.LogicalWorkflowContext.WorkflowId = stateMachineId;

                            // action 2: - another way how to invoke workflow
                            WorkflowInvoker.Contract<ITest>(endpoint).OneWay(string.Format("[{0}]: Hello world", ii));
                            //response = WorkflowInvoker.Contract<ITest>(endpoint).SayHello(string.Format("[{0}]: Hello world", ii));
                        }
                        else
                        {
                            // action 1:
                            ITest test = (ITest)Activator.GetObject(typeof(ITest), endpoint);
                            response = test.SayHello(string.Format("[{0}]: Hello world", ii));

                            // action 2:
                            //WorkflowInvoker.Contract<ITest>(endpoint).OneWay(string.Format("[{0}]: Hello world", ii));
                        }

                        // show CallContext
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("LWC={0}, Client.Response:    {1}, CallContext: {2}", LCC.LogicalWorkflowContext.ContextId, response, ConvertListToText(LCC.GetKeys()));
                        Console.ResetColor();

                        Console.ReadLine();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException == null ? ex : ex.InnerException);
                Console.ReadLine();
            }
            finally
            {
                // workflow
                WorkflowHosting.Detach();
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

        #region helpers
        private static string ConvertListToText(List<string> list)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string text in list)
            {
                sb.Append(text);
                sb.Append(", ");
            }
            return sb.ToString().TrimEnd(new char[] { ' ', ',' });
        }
        #endregion
    }
}

// add assembly (example)
//TypeProvider typeProvider = new TypeProvider(null);
//typeProvider.AddAssembly(typeof(RKiss.ActivityLibrary.OperationContractWorkflowBase).Assembly);
//wr.AddService(typeProvider); 