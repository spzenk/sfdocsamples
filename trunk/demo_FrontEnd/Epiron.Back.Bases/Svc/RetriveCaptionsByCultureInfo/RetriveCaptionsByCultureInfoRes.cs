using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Collections.Specialized;


namespace Epiron.Back.Bases.ISVC.RetriveCaptionsByCultureInfo
{
    [Serializable]
    public  class RetriveCaptionsByCultureInfoRes: Request<Result>
    {
      
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
    
   
 

        public UILanguageValues UILanguageValues
        {
            get;
            set;
        }
      
    }
}
