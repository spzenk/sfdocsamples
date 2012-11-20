using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Activation;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace SecureWcf
{


        [ServiceContract]
    public interface ICoreSecurityAspnet
    {
        //WCF service using jQuery[ Get Method] and retrieving data in JSON Format
        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json)]
        string Test_Get(string value);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, UriTemplate = "Test_Get_REST/{Value}",
       BodyStyle = WebMessageBodyStyle.Bare)]
        string Test_Get_REST(string value);


        [OperationContract]
        [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped, ResponseFormat = WebMessageFormat.Json)]
        string EnviarMensajeDesdeWCF();
    }
}