//  Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Workflow.Runtime;

namespace Microsoft.WorkflowServices.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowServiceHost workflowHost = new WorkflowServiceHost(typeof(Microsoft.WorkflowServices.Samples.ServiceWorkflow));
            

            workflowHost.Description.Behaviors.Find<WorkflowRuntimeBehavior>().WorkflowRuntime.WorkflowTerminated += delegate(object sender, WorkflowTerminatedEventArgs e) { Console.WriteLine("WorkflowTerminated: " + e.Exception.Message); };
            workflowHost.Description.Behaviors.Find<WorkflowRuntimeBehavior>().WorkflowRuntime.WorkflowCompleted += delegate(object sender, WorkflowCompletedEventArgs e) { Console.WriteLine("WorkflowCompleted: " + e.WorkflowInstance.InstanceId.ToString()); };
            workflowHost.Open();
            Console.WriteLine("WorkflowServiceHost is ready.");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Press <enter> to exit.");
            Console.ResetColor();
            Console.ReadLine();
            workflowHost.Close();
        }
    }
}
