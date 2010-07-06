using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.ISVC.SearchRpt_ReadConfirmed
{
    [Serializable]
    public class SearchRpt_ReadConfirmedRequest : Request<Param>
    {
        public SearchRpt_ReadConfirmedRequest()
        {
            this.ServiceName = "SearchRpt_ReadConfirmedService";
        }
    }
        #region [BussinesData]

        [XmlInclude(typeof(Param)), Serializable]
        public class Param : Entity
        {

            #region [Private Members]
            private Guid _MessageId;
            #endregion

            #region [Properties]

            public Guid MessageId
            {
                get { return _MessageId; }
                set { _MessageId = value; }
            }

            #endregion
        }

        #endregion

    }

