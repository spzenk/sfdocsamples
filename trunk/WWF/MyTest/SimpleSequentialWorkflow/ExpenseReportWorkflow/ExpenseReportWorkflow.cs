using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Fwk.SequentialWorkflow
{
    public sealed partial class ExpenseReportWorkflow : SequentialWorkflowActivity
    {


        private int reportAmount = 0;

        public int ReportAmount
        {
            get { return reportAmount; }
            set { reportAmount = value; }
        }
        private string reportResult = "";

        public string ReportResult
        {
            get { return reportResult; }
            set { reportResult = value; }
        }

        public ExpenseReportWorkflow()
        {
            InitializeComponent();
        }

        private void DetermineApprovalContact(object sender, ConditionalEventArgs e)
        {
            if (this.reportAmount > 1000)
            {
                e.Result = true;
            }
            else
            {
                e.Result = false;
            }

        }

        private void ExpenseReportWorkflow_Initialized(object sender, EventArgs e)
        {

        }

        private void ExpenseReportWorkflow_Completed(object sender, EventArgs e)
        {

        }


        private void approveEvent_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.reportResult = "Report approved";
        }

        private void rejectEvent_Invoked(object sender, ExternalDataEventArgs e)
        {
            this.reportResult = "Report Rejected";
        }

        private void Show_Form1(object sender, EventArgs e)
        {
            
        }

        private void Show_Form2(object sender, EventArgs e)
        {

        }

    }

}
