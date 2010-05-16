using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
//http://www.codeproject.com/KB/WCF/WCF_CommOptions_part3.aspx

namespace MSMC_WCF_Service
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SendMailService : ISendMail
    {
        private ISendMailCallback callback = null;
        public SendMailService()
        {
             callback = OperationContext.Current.GetCallbackChannel<ISendMailCallback>();
        }
        public void SubmitMessage(MailMessage message)
        {
            Console.WriteLine("To      : " + message.ToAddress);
            Console.WriteLine("From    : " + message.FromAddress);
            Console.WriteLine("Subject : " + message.Subject);
            Console.WriteLine("Body    : " + message.Body);
        }
    }

}
