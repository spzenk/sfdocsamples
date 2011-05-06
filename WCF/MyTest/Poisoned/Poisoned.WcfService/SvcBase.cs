using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace Poisoned.WcfService
{
    public class SvcBase
    {
        public ServiceHost Host = null;
        public  event EventHandler OnLogEvent = null;

        protected void Log(string msg)
        {
            if (OnLogEvent != null)
            {
                OnLogEvent(msg, new EventArgs());
            }
        }
    }
}
