using System;
using System.Data;
using Fwk.Bases;
using Allus.Cnn.Common.BE;
using Allus.Cnn.Common.DAC;
using Allus.Cnn.ISVC.CreateMessage;

namespace Allus.Cnn.SVC
{
    public class CreateMessagesService : BusinessService<CreateMessagesRequest, CreateMessagesResponse>
    {
        public override CreateMessagesResponse Execute(CreateMessagesRequest pServiceRequest)
        {
            CreateMessagesResponse wRes = new CreateMessagesResponse();

            MessagesBE MessageBE = new MessagesBE();

            string xmlMapeado = 
                Fwk.HelperFunctions.SerializationFunctions .ReplaseTypeNameForSerialization(
                typeof(Allus.Cnn.ISVC.CreateMessage.Param),
                typeof(MessagesBE), pServiceRequest.BusinessData.GetXml());

            MessageBE = MessagesBE.GetFromXml<MessagesBE>(xmlMapeado);
            AlertDAC.CreateMessage(MessageBE);
            return wRes;
        }
    }

}
