using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Allus.Cnn.Common.BE;
using Allus.Cnn.Common.DAC;
using Allus.Cnn.ISVC.UpdateReceivedMessages;

namespace Allus.Cnn.SVC
{
    public class UpdateReceivedMessagesService : BusinessService<UpdateReceivedMessagesRequest, UpdateReceivedMessagesResponse>
    {
        public override UpdateReceivedMessagesResponse Execute(UpdateReceivedMessagesRequest pServiceRequest)
        {
            UpdateReceivedMessagesResponse wRes = new UpdateReceivedMessagesResponse();

        

   
            AlertDAC.UpdateReceivedMessages(pServiceRequest.BusinessData.MessageId, pServiceRequest.BusinessData.Receptor, pServiceRequest.BusinessData.Confirmed.Value);
            return wRes;
        }
    }
}
