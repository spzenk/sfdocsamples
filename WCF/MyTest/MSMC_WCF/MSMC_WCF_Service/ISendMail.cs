using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MSMC_WCF_Service
{
    [ServiceContract(CallbackContract = typeof(ISendMailCallback), 
                     Namespace = "http://fwk", 
                     SessionMode = SessionMode.Required)]
    public interface ISendMail
    {
        [OperationContract(Name = "SubmitMessage", IsOneWay = true)]
        void SubmitMessage(MailMessage message);
    }

    public interface ISendMailCallback
    {
        [OperationContract(IsOneWay = true)]
        void Resived(int location);
    }

   


    //[ServiceContract]
    //public interface IQSMonitor
    //{
    //    [OperationContract(IsOneWay = true)]
    //    void ModState(string strMod, string strState);
    //}

    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    //public class QSMonitor : IQSMonitor
    //{
    //    QStateWnd parent = null;
    //    public QSMonitor(QStateWnd parent)
    //    {
    //        this.parent = parent;
    //    }
    //    public void ModState(string strMod, string strState)
    //    {
    //        parent.ProcessMessage(strMod, strState);
    //    }
    //}

}
