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
	public sealed partial class Workflow2: SequentialWorkflowActivity
	{
		public Workflow2()
		{
			InitializeComponent();
		}

        public String Connector_msg1 = default(System.String);
        public Guid callExternalMethodActivity1_workflowInstanceId1 = default(Guid);

     
        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Workflow2:   msg={0}", Connector_msg1);
        }

        private void callExternalMethodActivity1_MethodInvoking(object sender, EventArgs e)
        {
            callExternalMethodActivity1_workflowInstanceId1 = this.WorkflowInstanceId;
            Console.WriteLine("Workflow2:   done");
        }
	}

}
