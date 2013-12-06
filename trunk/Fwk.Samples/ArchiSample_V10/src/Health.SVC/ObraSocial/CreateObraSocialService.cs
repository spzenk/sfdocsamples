using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.CreateObraSocial;
using Health.Back;

namespace Health.Svc
{
    /// <summary>
    /// </summary>
    public class CreateObraSocialService : BusinessService<CreateObraSocialReq, CreateObraSocialRes>
    {
        public override CreateObraSocialRes Execute(CreateObraSocialReq pServiceRequest)
        {
            CreateObraSocialRes wRes = new CreateObraSocialRes();
            bool existe = ObraSocialDAC.Existe(pServiceRequest.BusinessData.Mutual.Nombre);

            if (existe)
            {

                throw new Fwk.Exceptions.FunctionalException(String.Format("La obra social {0} ya existe en la base de datos",
                    pServiceRequest.BusinessData.Mutual.Nombre));
            }
            else
            {
                ObraSocialDAC.Create(pServiceRequest.BusinessData.Mutual);
            }

            return wRes;
        }


    }
}


