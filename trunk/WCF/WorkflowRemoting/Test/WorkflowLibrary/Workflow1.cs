using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace WorkflowLibrary
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

        public String enterActivity1_msg1 = default(System.String);
        public Guid callExternalMethodActivity1_workflowInstanceId1 = default(Guid);
        public String invokeEndpointActivity1__ReturnValue_1 = default(System.String);

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Workflow1: msg={0}", enterActivity1_msg1);
        }

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Workflow1: returnvalue={0}", invokeEndpointActivity1__ReturnValue_1);
        }

        private void callExternalMethodActivity1_MethodInvoking(object sender, EventArgs e)
        {
            callExternalMethodActivity1_workflowInstanceId1 = this.WorkflowInstanceId;
            Console.WriteLine("Workflow1: done\n");
        }

        
	}

}
