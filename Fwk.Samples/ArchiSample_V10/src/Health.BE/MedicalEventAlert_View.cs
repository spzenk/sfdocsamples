using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;

namespace Health.BE
{

    [XmlRoot("MedicalEventPMO_Diag_List"), SerializableAttribute]
    public class MedicalEventAlert_ViewList : Entities<MedicalEventAlert_View>
    {

    }
    [XmlInclude(typeof(MedicalEventPMO_Diag_View)), Serializable]
    public class MedicalEventAlert_View : Entity
    {
        public int AlertId { get; set; }
        public int MedicalEventIdCreation { get; set; }
        public DateTime CreationDate { get; set; }

        public String Profesional { get; set; }
        public String Description { get; set; }

        public Guid HealthInstitutionId { get; set; }

        public String Diagnosis { get; set; }
        public String InstitucionRazonSocial { get; set; }

        public int MedicalEventId { get; set; }
        public int ReferenceId { get; set; }

        public int AlertType { get; set; }
    }
}
