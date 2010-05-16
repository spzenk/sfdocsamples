using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Workflow.Activities;

namespace Fwk.SequentialWorkflow
{
    /// <summary>
    /// This interface enables the workflow and host application to communicate by using a predefined protocol.
    /// </summary>
    [ExternalDataExchangeAttribute]
	public interface IExpenseReportService
	{
        void GetLeadApproval(string message);
        void GetManagerApproval(string message);
        event EventHandler<ExternalDataEventArgs> ExpenseReportApproved;
        event EventHandler<ExternalDataEventArgs> ExpenseReportRejected;

	}
}
