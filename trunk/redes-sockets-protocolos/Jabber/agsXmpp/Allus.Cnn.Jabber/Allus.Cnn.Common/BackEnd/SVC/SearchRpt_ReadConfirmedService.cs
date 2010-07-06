using System;
using System.Collections;
using System.Data;
using Fwk.Bases;
using Fwk.Exceptions;
using Allus.Cnn.Common;
using Allus.Cnn.Common.BE;
using Allus.Cnn.Common.DAC;
using Allus.Cnn.ISVC.SearchRpt_ReadConfirmed;

namespace Allus.Cnn.SVC
{
    public class SearchRpt_ReadConfirmedService : BusinessService<SearchRpt_ReadConfirmedRequest,SearchRpt_ReadConfirmedResponse>
    {
        public override SearchRpt_ReadConfirmedResponse Execute(SearchRpt_ReadConfirmedRequest pServiceRequest)
        {
            SearchRpt_ReadConfirmedResponse wRes = new SearchRpt_ReadConfirmedResponse();

            DataTable dt = AlertDAC.SearchRpt_ReadConfirmed(pServiceRequest.BusinessData.MessageId);
            if (dt != null)
            {
                ResultGraficos wResultGraficos;
                foreach (DataRow dr in dt.Rows)
                {
                    wResultGraficos = new ResultGraficos();
                    wResultGraficos.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                    wResultGraficos.Descripcion = dr["Descripcion"].ToString();
                    wRes.BusinessData.ResultGraficos.Add(wResultGraficos);

                }
            }
            else
                wRes = null;
        
            return wRes;
        }
    }


}
