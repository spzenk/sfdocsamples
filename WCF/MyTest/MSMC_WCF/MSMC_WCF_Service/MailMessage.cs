using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MSMC_WCF_Service
{
    [DataContract(Name = "MailMessage", Namespace = "http://fwk")]
    public class MailMessage
    {

        [DataMember(Name = "ToAddress", IsRequired = true, Order = 1)]
        public string ToAddress { get; set; }

        [DataMember(Name = "FromAddress", IsRequired = true, Order = 2)]
        public string FromAddress { get; set; }

        [DataMember(Name = "CCAddress", IsRequired = false, Order = 3)]
        public string CCAddress { get; set; }

        [DataMember(Name = "BCCAddress", IsRequired = false, Order = 4)]
        public string BCCAddress { get; set; }

        [DataMember(Name = "Subject", IsRequired = true, Order = 5)]
        public string Subject { get; set; }

        [DataMember(Name = "Body", IsRequired = true, Order = 6)]
        public string Body { get; set; }

    }
}
