using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Fabrikam
{
    /// <summary>
    /// sistema de contrato comercial
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class TradingSystem : ITradingService
    {
        #region ITradingService Members

        string ITradingService.BeginDeal()
        {
            string dealIdentifier = Guid.NewGuid().ToString();

            return dealIdentifier;
        }

        void ITradingService.AddTrade(Trade trade)
        {
            Console.WriteLine("Added trade for {0}", trade);
        }

        void ITradingService.AddFunction(string function)
        {
            Console.WriteLine("Added function {0}", function);
        }

        decimal ITradingService.Calculate()
        {
            
            Decimal value = DateTime.Now.Millisecond / 10;
            Console.WriteLine("Calculated value as {0}", value);
            return value;
        }

        /// <summary>
        /// Contrato de Compraventa
        /// </summary>
        void ITradingService.Purchase()
        {
            Console.WriteLine("Purchased!");
        }

        void ITradingService.EndDeal()
        {
            Console.WriteLine("Completed deal.");
        }

        #endregion
    }

}
