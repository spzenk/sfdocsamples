
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.CreateUpdatePatientAllergy;
using Health.Back;



namespace Health.Svc
{
    /// <summary>
    /// Performs the patien allergy creation or update
    /// </summary>
    public class CreateUpdatePatientAllergyService : BusinessService<CreateUpdatePatientAllergyReq, CreateUpdatePatientAllergyRes>
    {
        public override CreateUpdatePatientAllergyRes Execute(CreateUpdatePatientAllergyReq pServiceRequest)
        {
            CreateUpdatePatientAllergyRes wRes = new CreateUpdatePatientAllergyRes();

            if (pServiceRequest.BusinessData.EntityState== EntityState.Added)
                PatientsDAC.CreatePatientAllergy(pServiceRequest.BusinessData, Guid.Parse(pServiceRequest.ContextInformation.UserId));
            else
                PatientsDAC.UpdatePatientAllergy(pServiceRequest.BusinessData, Guid.Parse(pServiceRequest.ContextInformation.UserId));


            return wRes;
        }


    }

}
