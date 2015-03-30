
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.RetrivePatientAppoiments;
using Health.Back;

using Health.BE;


namespace Health.Svc
{
    /// <summary>
    ///Retorna appointments del paciente
    /// </summary>
    public class RetrivePatientAppoimentsService : BusinessService<RetrivePatientAppoimentsReq, RetrivePatientAppoimentsRes>
    {
        public override RetrivePatientAppoimentsRes Execute(RetrivePatientAppoimentsReq pServiceRequest)
        {
            RetrivePatientAppoimentsRes wRes = new RetrivePatientAppoimentsRes();
            PatientMedicament_ViewList wPatientMedicament_ViewBE = new PatientMedicament_ViewList();

            wRes.BusinessData = PatientsDAC.Retrive_Appointment(pServiceRequest.BusinessData.PatientId, pServiceRequest.BusinessData.StartDate, pServiceRequest.BusinessData.Status);

            //DateTime currentDate = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(DateTime.Now);

            if (wPatientMedicament_ViewBE.Count != 0)
                wRes.BusinessData = new Patient_Appointments_ViewList();

            return wRes;
        }


    }

}
