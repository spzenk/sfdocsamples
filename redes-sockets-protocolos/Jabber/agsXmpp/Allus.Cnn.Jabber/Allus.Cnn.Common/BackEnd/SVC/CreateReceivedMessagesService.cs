using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Allus.Cnn.ISVC.CreateReceivedMessages;
using Fwk.Bases;
using Allus.Cnn.Common.BE;
using Allus.Cnn.Common.DAC;
//using BackEnd.BusinessEntities;
//using BackEnd.BusinessComponents;

namespace Allus.Cnn.SVC
{
    public class CreateReceivedMessagesService : BusinessService<CreateReceivedMessagesRequest, CreateReceivedMessagesResponse>
    {
        public override CreateReceivedMessagesResponse Execute(CreateReceivedMessagesRequest pServiceRequest)
        {
            CreateReceivedMessagesResponse wRes = new CreateReceivedMessagesResponse();

            ReceivedMessagesBE ReceivedMessageBE = new ReceivedMessagesBE();

            string xmlMapeado =
                Fwk.HelperFunctions.SerializationFunctions.ReplaseTypeNameForSerialization(
                typeof(Allus.Cnn.ISVC.CreateReceivedMessages.Param),
                typeof(ReceivedMessagesBE), pServiceRequest.BusinessData.GetXml());

            ReceivedMessageBE = ReceivedMessagesBE.GetFromXml<ReceivedMessagesBE>(xmlMapeado);
   

                AlertDAC.CreateReceivedMessages(ReceivedMessageBE);

           
            return wRes;
        }
    }
}
