using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Health.Isvc.UpdateProfesional;
using Health.Back;

using Fwk.Security;
using Fwk.Security.Common;

namespace Health.Svc
{
    /// <summary>
    /// Actualiza profesional
    /// Actualiza persona
    /// Actualiza Lista de Roles si BusinessData.User distinto de  NULL
    /// </summary>
    public class UpdateProfesionalService : BusinessService<UpdateProfesionalReq, UpdateProfesionalRes>
    {
        public override UpdateProfesionalRes Execute(UpdateProfesionalReq pServiceRequest)
        {
            RolList lst = null;
            UpdateProfesionalRes wRes = new UpdateProfesionalRes();
            pServiceRequest.BusinessData.profesional.LastAccessUserId = Guid.Parse(pServiceRequest.ContextInformation.UserId);
            pServiceRequest.BusinessData.profesional.Persona.LastAccessUserId = Guid.Parse(pServiceRequest.ContextInformation.UserId);
            ProfesionalesDAC.Update(pServiceRequest.BusinessData.profesional);
            ///Ejemplo
            //A = 1,2,3, existent_roles
            //B = 2,3,5,  vienen del servicio q son los que quedan
            //B-A = 5, roles a agregar
            //A-B = 1, roles a eliminar
            #region ROLES A NIVEL DE SF
            if (pServiceRequest.BusinessData.User != null)
            {
                //Elimino todos los roles del usuario
                Fwk.Security.Common.RolList rolList_sf_A = FwkMembership.GetRolesForUser(pServiceRequest.BusinessData.User.UserName, pServiceRequest.SecurityProviderName);
                var roles_sf_A_ids = from r in rolList_sf_A select r.RolName;
                var roles_sf_B_ids = from r in pServiceRequest.BusinessData.User.GetRolList() where r.RolName.StartsWith("sf_") select r.RolName;

                //A-B roles a eliminar
                var roles_To_Delette_ids = roles_sf_A_ids.Except<string>(roles_sf_B_ids);

                if (roles_To_Delette_ids.Count() != 0)
                {
                    lst = new RolList();

                    var to_remove = rolList_sf_A.Where(r => roles_To_Delette_ids.Contains(r.RolName.Trim()));
                    lst.AddRange(to_remove);
                    FwkMembership.RemoveUserFromRoles(pServiceRequest.BusinessData.User.UserName, lst, pServiceRequest.SecurityProviderName);
                }

                //A-B roles a eliminar
                var roles_To_Add_ids = roles_sf_B_ids.Except<string>(roles_sf_A_ids);


                //B-A  roles a agregar
                if (roles_To_Add_ids.Count() != 0)
                {
                    lst = new RolList();
                    foreach (string rolName in roles_To_Add_ids)
                    {
                        lst.Add(new Rol(rolName));
                    }
                    //Asigno los nuevos roles del usuario
                    FwkMembership.CreateRolesToUser(lst, pServiceRequest.BusinessData.User.UserName, pServiceRequest.SecurityProviderName);
                }
            #endregion

                #region ROLES A NIVEL INSTITUCIONAL
                if (pServiceRequest.BusinessData.HealthInstitutionId.HasValue)
                {


                    Guid userId = new Guid(pServiceRequest.BusinessData.User.ProviderId.ToString());
                    ///Obtener los roles asignados previamente 
                    string[] existent_roles_A = ProfesionalesDAC.Get_HealtInstitute_UsersInRoles(userId, pServiceRequest.BusinessData.HealthInstitutionId.Value);
                    //vienen del servicio q son los que quedan
                    var roles_B = from r in pServiceRequest.BusinessData.User.GetRolList() where r.RolName.StartsWith("inst_") select r.RolName;
                    //Agregar
                    foreach (string rolName in roles_B.Except(existent_roles_A))
                    {
                        HealthInstitutionDAC.Profesional_UsersInRoles_Assign(
                            pServiceRequest.BusinessData.HealthInstitutionId.Value,
                            pServiceRequest.BusinessData.profesional.IdProfesional,
                           userId,
                            rolName);
                    }
                    //Quitar roles
                    foreach (string rolName in existent_roles_A.Except(roles_B))
                    {
                        HealthInstitutionDAC.Profesional_RemoveRol(
                            pServiceRequest.BusinessData.HealthInstitutionId.Value,
                            pServiceRequest.BusinessData.profesional.IdProfesional,
                            userId, rolName);
                    }

                }
            }
            return wRes;
        }

   #endregion
    }
}


