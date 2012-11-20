using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace SecureWcf
{
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class CoreSecurityAspnet:ICoreSecurityAspnet
    {
        #region ICoreSecurityAspnet Members

        public string Test_Get(string value)
        {
            return string.Format("Testing Test_Get at {0}, your input is {1}", System.DateTime.Now.ToString(), value);
        }

        public string EnviarMensajeDesdeWCF()
        {
            return "Llamada a un servicio WCF desde jQuery.";
        }
          
        #endregion
    }
}