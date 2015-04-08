using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epiron.Back.Bases.BE;
using Epiron.Back.Bases.Svc;

namespace Epiron.Front.Bases
{
   public  class Controller
    {
        public static MsgDialogBoxList MsgDialogBoxGet(int? LanguageId, string MsgDialogBoxName)
        {
            
                MsgDialogBoxGetRequest req = new MsgDialogBoxGetRequest();
                req.BusinessData.LanguageId = LanguageId;
                req.BusinessData.MsgDialogBoxName = MsgDialogBoxName;

                MsgDialogBoxGetResponse res = req.ExecuteService<MsgDialogBoxGetRequest, MsgDialogBoxGetResponse>(req);

                if (res.Error != null)
                    throw Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error);

                return res.BusinessData;

            

        }
    }
}
