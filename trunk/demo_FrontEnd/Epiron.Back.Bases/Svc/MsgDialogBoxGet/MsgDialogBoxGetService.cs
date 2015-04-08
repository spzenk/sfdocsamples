using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiron.Back.Bases.DAC;
using Fwk.Bases;

namespace Epiron.Back.Bases.Svc
{
    public class MsgDialogBoxGetService : BusinessService<MsgDialogBoxGetRequest, MsgDialogBoxGetResponse>
    {

        public override MsgDialogBoxGetResponse Execute(MsgDialogBoxGetRequest pServiceRequest)
        {
            MsgDialogBoxGetResponse wRes = new MsgDialogBoxGetResponse();

            Int32? lenguage = pServiceRequest.BusinessData.LanguageId;
            String Name = pServiceRequest.BusinessData.MsgDialogBoxName;

            wRes.BusinessData = MsgDialogBoxDAC.MsgDialogBoxGet(Name, lenguage);

            return wRes;
        }
    }
}
