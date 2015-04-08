using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Epiron.Back.Bases.BE;

namespace Epiron.Back.Bases.Svc
{
    #region Request

    [Serializable]
    public class MsgDialogBoxGetRequest : Request<MsgDialogBoxGetRequestParams>
    {
        public MsgDialogBoxGetRequest()
        {
            base.ServiceName = "MsgDialogBoxGetService";
        }
    }

    [Serializable]
    public class MsgDialogBoxGetRequestParams : Entity
    {
        public Int32? LanguageId; //para que reciba null
        public string MsgDialogBoxName;

    }

    #endregion

    #region Response

    [Serializable]
    public class MsgDialogBoxGetResponse : Response<MsgDialogBoxList>
    {

    }

    #endregion
}
