using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;
using System.Xml.Serialization;

namespace Allus.Cnn.ISVC.SearchMessagesReadConfirmed
{
    public class SearchMessagesReadConfirmedResponse : Response<Result>
    {

    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        #region Fields
        private List<ColaboratorData> _ColaboratorDataList;
        #endregion

        #region Properties
        public List<ColaboratorData> ColaboratorDataList
        {
            get { return _ColaboratorDataList; }
            set { _ColaboratorDataList = value; }
        }
        #endregion
    }
}
