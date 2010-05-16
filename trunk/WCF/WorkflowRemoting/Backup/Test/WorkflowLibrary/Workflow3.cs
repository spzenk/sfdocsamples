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
//
using RKiss.ActivityLibrary;

namespace WorkflowLibrary
{
    public sealed partial class Workflow3 : OperationContractWorkflowBase
	{
		public Workflow3()
		{
			InitializeComponent();
		}

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Workflow2:   msg={0}", Workflow3_msg1);
            //throw new Exception("aaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
        }

        public String Workflow3_msg1 = default(System.String);
	}
}
