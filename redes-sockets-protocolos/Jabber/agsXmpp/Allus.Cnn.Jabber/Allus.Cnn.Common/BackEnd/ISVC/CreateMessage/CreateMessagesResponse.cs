using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace Allus.Cnn.ISVC.CreateMessage
{

    [Serializable]
    public class CreateMessagesResponse : Response<Result>
    {
    }


    #region [BussinessData]

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        #region [Private Members]
        private System.String _Dummy;

        #endregion

        #region [Properties]

        #region [Dummy]
        [XmlElement(ElementName = "Dummy", DataType = "string")]
        public String Dummy
        {
            get { return _Dummy; }
            set { _Dummy = value; }
        }
        #endregion

        #endregion

      
    }

    #endregion
}

