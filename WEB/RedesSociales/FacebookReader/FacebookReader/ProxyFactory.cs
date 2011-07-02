using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.SocialNetworks.Facebook
{
    public class ProxyFactory
    {
       

        static ProxyFactory()
        {
          
          
        }

        public static WebProxy GetProxy()
        {
            WebProxy wWebProxy = new WebProxy("proxy", 3128);

            wWebProxy.Credentials = new System.Net.NetworkCredential("abrondani", "Luicho.0329", "ALLUS-AR");

            return wWebProxy;
        }
    }
}