using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.Specialized;
using System.Collections;
using System.Drawing;
using System.Runtime.Remoting.Messaging;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
//
using RKiss.ActivityLibrary;
using RKiss.WorkflowRemoting;

namespace WorkflowLibrary
{
	public sealed partial class Workflow5 : OperationContractWorkflowBase 
	{
		public Workflow5()
		{
			InitializeComponent();
		}

        private HybridDictionary _initData;
        public HybridDictionary InitData
        {
            get { return _initData; }
            set { _initData = value; }
        }
	
        public String Workflow5_msg1 = default(System.String);

        private void Workflow5_Received(object sender, EventArgs e)
        {
            Console.WriteLine("LWC={0}, {1}.Received: {2}, CallContext: {3}", LCC.LogicalWorkflowContext.ContextId, this.Name, Workflow5_msg1, Helpers.ConvertListToText(LCC.GetKeys()));
        }
	}

}
