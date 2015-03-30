using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.BE;
using Fwk.Security.Common;

namespace Health.Isvc.CrearProfesional
{

    [Serializable]
    public class CrearProfesionalReq : Fwk.Bases.Request<Params>
    {

        public CrearProfesionalReq()
        {
            base.ServiceName = "CrearProfesionalService";
        }
    }

    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Fwk.Bases.Entity
    {

        public ProfesionalBE profesional { get; set; }
        private User _User;





        public User User
        {
            get { return _User; }
            set { _User = value; }
        }



       
    }

    [Serializable]
    public class CrearProfesionalRes : Fwk.Bases.Response<Result>
    {
    }
    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Fwk.Bases.Entity
    {
        public int IdProfesional { get; set; }
        public Guid UserId { get; set; }
    }
}