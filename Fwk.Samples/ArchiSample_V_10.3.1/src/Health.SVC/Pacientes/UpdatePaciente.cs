using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;

namespace Health.Isvc.UpdatePatient
{

    [Serializable]
    public class UpdatePatientReq : Fwk.Bases.Request<Params>
    {

        public UpdatePatientReq()
        {
            base.ServiceName = "UpdatePatientService";
        }
    }

    public class Params : Fwk.Bases.Entity
    {
        public PatientBE Patient { get; set; }

        public MutualPorPacienteList Mutuales { get; set; }

        public DateTime? AnteriorFechaNacimiento { get; set; }
    }

    [Serializable]
    public class UpdatePatientRes : Fwk.Bases.Response<DummyContract>
    {


    }

    
}