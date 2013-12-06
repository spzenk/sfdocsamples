using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.RetriveProfesionales;
using Health.Back;
using Health.BE;


namespace Health.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class RetriveProfesionalesService : BusinessService<RetriveProfesionalesReq, RetriveProfesionalesRes>
    {
        public override RetriveProfesionalesRes Execute(RetriveProfesionalesReq pServiceRequest)
        {
            RetriveProfesionalesRes wRes = new RetriveProfesionalesRes();

            List<Profesional_FullViewBE> wProfesional_FullView_List = null;

            

            if (pServiceRequest.BusinessData.HealthInstId.HasValue)
            {
                ///Busca profecionales ya relacionados con una Institución 


                //Si es padre
                if (HealthInstitutionDAC.IsParent(pServiceRequest.BusinessData.HealthInstId.Value))
                {
                    //Profesionales directamente relacionados 
                    wProfesional_FullView_List = ProfesionalesDAC.SearchBy_HealthInstRelated(pServiceRequest.BusinessData.HealthInstId.Value);
                    //Lista de id de profesionales ya incluidos n la lista
                    List<Int32> prof_ids_JustRetrived = (from s in wProfesional_FullView_List select s.IdProfesional).ToList<Int32>();

                    //Instituciones hijas                     
                    List<Guid> inst_chids_ids = HealthInstitutionDAC.RetriveHealthInstitution_Childs_Ids(pServiceRequest.BusinessData.HealthInstId.Value);
                    foreach (Guid id in inst_chids_ids)
                    {
                        var only_inthis_child_List = ProfesionalesDAC.SearchBy_HealthInstRelated(pServiceRequest.BusinessData.HealthInstId.Value, prof_ids_JustRetrived);
                        wProfesional_FullView_List.AddRange(only_inthis_child_List);
                        //Lista de id de profesionales ya incluidos en la lista wProfesional_FullView_List
                        prof_ids_JustRetrived.AddRange((from s in wProfesional_FullView_List select s.IdProfesional).ToList<Int32>());
                    }
                }
                else // Si es Hijo
                {
                    //Profecionales directamente relacionados
                    wProfesional_FullView_List = ProfesionalesDAC.SearchBy_HealthInstRelated(pServiceRequest.BusinessData.HealthInstId.Value);
                }
            }
            else
            {
                ///Busca profecionales solo por nobre y apellido
                wProfesional_FullView_List = ProfesionalesDAC.SearchByParams(pServiceRequest.BusinessData.Nombre, pServiceRequest.BusinessData.Apellido);
            }
            wRes.BusinessData.AddRange(wProfesional_FullView_List);
            return wRes;
        }


    }

}
