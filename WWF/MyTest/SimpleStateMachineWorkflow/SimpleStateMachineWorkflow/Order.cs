using System;
using System.Collections.Generic;
using System.Text;
using System.Workflow.Activities;

namespace Microsoft.Samples.Workflow.SimpleStateMachineWorkflow
{
    [Serializable]
    public class NewOrderEventArgs : ExternalDataEventArgs
    {
        public NewOrderEventArgs(Guid itemId, string item, int quantity)
            : base(itemId)
        {
            this.orderItemId = itemId;
            this.orderItem = item;
            this.orderQuantity = quantity;
        }


        private Guid orderItemId;

        public Guid ItemId
        {
            get { return orderItemId; }
            set { orderItemId = value; }
        }
        private string orderItem;

        public string Item
        {
            get { return orderItem; }
            set { orderItem = value; }
        }
        private int orderQuantity;

        public int Quantity
        {
            get { return orderQuantity; }
            set { orderQuantity = value; }
        }


    }

}
