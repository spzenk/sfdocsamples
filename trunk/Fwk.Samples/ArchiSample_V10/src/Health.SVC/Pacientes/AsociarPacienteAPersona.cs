using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;

namespace Health.Isvc.AsociarPatientAPersona
{

    [Serializable]
    public class AsociarPatientAPersonaReq : Fwk.Bases.Request<Params>
    {

        public AsociarPatientAPersonaReq()
        {
            base.ServiceName = "AsociarPatientAPersonaService";
        }
    }

    public class Params : Fwk.Bases.Entity
    {
        public PatientBE Patient { get; set; }

        public MutualPorPacienteList Mutuales { get; set; }

        public bool PersonaNeedsUpdate { get; set; }

        //public DateTime? AnteriorFechaNacimiento { get; set; }
    }

    [Serializable]
    public class AsociarPatientAPersonaRes : Fwk.Bases.Response<DummyContract>
    {


    }

    
}