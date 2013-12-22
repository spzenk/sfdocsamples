
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.ValidateActivationCode;
using Health.Back;
using Fwk.Exceptions;



namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class ValidateActivationCodeService : BusinessService<ValidateActivationCodeReq, ValidateActivationCodeRes>
    {
        public override ValidateActivationCodeRes Execute(ValidateActivationCodeReq pServiceRequest)
        {
            ValidateActivationCodeRes wRes = new ValidateActivationCodeRes();

            wRes.BusinessData = EnvironmentDAC.ValidateCode(pServiceRequest.BusinessData.Code);
            if (wRes.BusinessData == null )
                if (pServiceRequest.BusinessData.IsRegister)
                    throw new FunctionalException(1, "El código de activación ingresado parece que no se encuentra en nuestros registros/r/npor favor ingrese a www.health32.com/register para chequear su estado .-");
                else
                    throw new FunctionalException(2, "Su código de activación se encuentra vencido o inválido/r/npor favor ingrese a www.health32.com/register para chequear su estado .-");

            return wRes;
        }


    }

}
