using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Workflow.Runtime;
using System.Workflow.Runtime.Hosting;
using System.Workflow.Activities;
using System.Threading;
using ExpenseReportWorkflow;

namespace Fwk.SequentialWorkflow
{
    public delegate void GetApprovalDelegate(string message);
    public partial class Form1 : Form, IExpenseReportService
	{
        private WorkflowRuntime workflowRuntime = null;
        private WorkflowInstance workflowInstance = null;
        private ExternalDataExchangeService exchangeService = null;

       
		public Form1()
		{
			InitializeComponent();
            this.workflowRuntime = new WorkflowRuntime();
            exchangeService = new ExternalDataExchangeService();
            //This starts the runtime but does not execute any 
            //workflows until the application notifies it to start a workflow.
            this.workflowRuntime.StartRuntime();
            //Enlace entre el workFlow y exchangeService
            workflowRuntime.AddService(exchangeService);
            //exchangeService es asociado para que iteractue con el formulario .. ya que implementa la interfaz "IExpenseReportService" que tiene el atributo   [ExternalDataExchangeAttribute]
            exchangeService.AddService(this);
            workflowRuntime.WorkflowCompleted += new EventHandler<WorkflowCompletedEventArgs>(workflowRuntime_WorkflowCompleted);
		}



        //used to pass values back to the host application after the current WorkflowInstance has completed. 
        void workflowRuntime_WorkflowCompleted(object sender, WorkflowCompletedEventArgs e)
        {
            if (this.result.InvokeRequired)
            {
                this.result.Invoke(new EventHandler<WorkflowCompletedEventArgs> (this.workflowRuntime_WorkflowCompleted), sender, e);
            }
            else
            {
                this.result.Text = e.OutputParameters["ReportResult"].ToString();
                //this.amount.Text = string.Empty;
                //this.approveButton.Enabled = false;
                //this.rejectButton.Enabled = false;
            }


        }

        private void approveButton_Click(object sender, EventArgs e)
        {
            ExpenseReportApproved(null, new ExternalDataEventArgs(this.workflowInstance.InstanceId));
            this.submitButton.Enabled = true;

        }

        private void rejectButton_Click(object sender, EventArgs e)
        {
            ExpenseReportRejected(null, new ExternalDataEventArgs(this.workflowInstance.InstanceId));
            this.submitButton.Enabled = true;

        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            // Start the workflow.
            Dictionary<string, object> properties = new Dictionary<string, object>();
            properties.Add("ReportAmount", Int32.Parse(this.amount.Text));


            this.workflowInstance = workflowRuntime.CreateWorkflow(typeof(Fwk.SequentialWorkflow.ExpenseReportWorkflow), properties);
            this.workflowInstance.Start();
        }

        private void amount_TextChanged(object sender, EventArgs e)
        {
            submitButton.Enabled = amount.Text.Length > 0;
        }

        #region IExpenseReportService Members

        public void GetLeadApproval(string message)
        {
            if (this.approvalState.InvokeRequired)
                this.approvalState.Invoke(new GetApprovalDelegate
                    (this.GetLeadApproval), message);
            else
            {
                this.approvalState.Text = message;
                this.approveButton.Enabled = true;
                this.rejectButton.Enabled = true;
                this.approvalState.ForeColor = Color.Blue;
                // expand the panel
                //this.Height = this.MinimumSize.Height + this.panel1.Height;
                this.submitButton.Enabled = false;
            }

        }

        public void GetManagerApproval(string message)
        {
            if (this.approvalState.InvokeRequired)
                this.approvalState.Invoke(new GetApprovalDelegate
                    (this.GetManagerApproval), message);
            else
            {
                this.approvalState.Text = message;
                this.approvalState.ForeColor =  Color.Brown;
                this.approveButton.Enabled = true;
                this.rejectButton.Enabled = true;

                // expand the panel
                //this.Height = this.MinimumSize.Height + this.panel1.Height;
                this.submitButton.Enabled = false;
            }

        }

        public event EventHandler<ExternalDataEventArgs> ExpenseReportApproved;
        public event EventHandler<ExternalDataEventArgs> ExpenseReportRejected;
        #endregion
    }
}
