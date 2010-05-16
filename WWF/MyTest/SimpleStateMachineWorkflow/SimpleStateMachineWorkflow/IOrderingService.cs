using System;
using System.Workflow.Activities;
namespace Microsoft.Samples.Workflow.SimpleStateMachineWorkflow
{


    [ExternalDataExchange]
    public interface IOrderingService

    {
      
        void ItemStatusUpdate(Guid orderId, string newStatus);

        event EventHandler<NewOrderEventArgs> NewOrderEvent;

    }
}
