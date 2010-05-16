using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Collections.Specialized;
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
using RKiss.WorkflowRemoting;

namespace WorkflowLibrary
{
	public sealed partial class Workflow4: SequentialWorkflowActivity
	{
		public Workflow4()
		{
			InitializeComponent();
		}

        private HybridDictionary _initData;
        public HybridDictionary InitData
        {
            get { return _initData; }
            set { _initData = value; }
        }
        public String Connector_msg1 = default(System.String);
        public String Return__ReturnValue_1 = default(System.String);

        private void Connector_Received(object sender, EventArgs e)
        {
            Console.WriteLine("LWC={0}, {1}.Received: {2}, CallContext: {3}", LCC.LogicalWorkflowContext.ContextId, this.Name, Connector_msg1, Helpers.ConvertListToText(LCC.GetKeys()));
        }
	}

}
