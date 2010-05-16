using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Fabrikam;

namespace TradeRecordingService
{
      [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
        public class TradeRecorder : ITradeRecorder
        {

            public TradeRecorder()
            {
            }

            #region ITradeRecorder Members
            void ITradeRecorder.RecordTrades(Trade[] trades)
            {
                Console.WriteLine("Recording trade ...");


                foreach (Trade trade in trades)
                {
                    Console.WriteLine(string.Format("Recorded trade for {0}", trade));
                }
            }

            #endregion
        }

    
}
