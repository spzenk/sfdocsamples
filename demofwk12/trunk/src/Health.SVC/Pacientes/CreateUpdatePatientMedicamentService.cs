
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.CreateUpdatePatientMedicament;
using Health.Back;



namespace Health.Svc
{
    /// <summary>
    /// Performs the  Patient Medicament creation or update
    /// </summary>
    public class CreateUpdatePatientMedicamentService : BusinessService<CreateUpdatePatientMedicamentReq, CreateUpdatePatientMedicamentRes>
    {
        public override CreateUpdatePatientMedicamentRes Execute(CreateUpdatePatientMedicamentReq pServiceRequest)
        {
            CreateUpdatePatientMedicamentRes wRes = new CreateUpdatePatientMedicamentRes();

            if (pServiceRequest.BusinessData.EntityState == EntityState.Added)
                PatientsDAC.AddPatientMedicaments(pServiceRequest.BusinessData, Guid.Parse(pServiceRequest.ContextInformation.UserId));
            else
                PatientsDAC.UpdatePatientMedicaments_histoy(pServiceRequest.BusinessData, Guid.Parse(pServiceRequest.ContextInformation.UserId));


            return wRes;
        }


    }

}
