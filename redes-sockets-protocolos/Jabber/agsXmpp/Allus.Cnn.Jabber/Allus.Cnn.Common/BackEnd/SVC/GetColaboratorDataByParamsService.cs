using System;
using System.Collections;
using System.Data;
using Fwk.Bases;
using Fwk.Exceptions;
using Allus.Cnn.Common;
using Allus.Cnn.Common.DAC;
using Allus.Cnn.ISVC.GetColaboratorDataByParams;

namespace Allus.Cnn.SVC
{
    public class GetColaboratorDataByParamsService : BusinessService<GetColaboratorDataByParamsRequest, GetColaboratorDataByParamsResponse>
    {
        public override GetColaboratorDataByParamsResponse Execute(GetColaboratorDataByParamsRequest pServiceRequest)
        {
            GetColaboratorDataByParamsResponse res = new GetColaboratorDataByParamsResponse();
            
            res.BusinessData.ColaboratorData = AlertDAC.GetColaboratorDataByParams(pServiceRequest.BusinessData.UserName);
            
            return res;
        }
    }
}
