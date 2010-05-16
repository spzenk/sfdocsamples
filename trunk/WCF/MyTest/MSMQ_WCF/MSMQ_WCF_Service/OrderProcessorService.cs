using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MSMQ_WCF_Service
{
    // This service class that implements the service contract.
    // This added code writes output to the console window.
    public class OrderProcessorService : IOrderProcessor
    {
        List<PurchaseOrder> _Orders = new List<PurchaseOrder>();

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitPurchaseOrder(PurchaseOrder po)
        {
            _Orders.Add(po);
            Console.WriteLine("Processing {0} ", po);
        }
    
   }

   
}
