using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.ISVC.SearchColaboratorsByParams
{
    [Serializable]
    public class SearchColaboratorsByParamsResponse : Response<Result>
    {

    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        #region [Fields]

        private List<ColaboratorData> _ColaboratorDataList;
       


        #endregion


        #region [Properties]

        public List<ColaboratorData> ColaboratorDataList
        {
            get { return _ColaboratorDataList; }
            set { _ColaboratorDataList = value; }
        }



        #endregion
    }
}