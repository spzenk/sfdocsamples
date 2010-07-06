using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;

namespace Allus.Cnn.ISVC.GetColaboratorDataByParams
{

    [Serializable]
    public class GetColaboratorDataByParamsResponse : Response<Result>
    {

    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        #region [Fields]

        private ColaboratorData _ColaboratorData;
        
        #endregion


        #region [Properties]

        public ColaboratorData ColaboratorData
        {
            get { return _ColaboratorData; }
            set { _ColaboratorData = value; }
        }

        #endregion
    }
}