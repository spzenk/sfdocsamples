using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.BE;
using Health.Back.BE;
using Health.Entities;
using Health.BE.Enums;

namespace Health.Back
{
    /// <summary>
    /// 
    /// </summary>
    public class HealthInstitutionDAC
    {
        #region Security
        /// <summary>
        /// Crea una Institución
        /// Establece como profesional owner de  pHealthInstitution a pProfesionalId/pUserId
        /// </summary>
        /// <param name="pHealthInstitution">Institución</param>
        /// <param name="pProfesionalId">Profecional</param>
        /// <param name="pUserId"></param>
        public static void Create_From_Owner(Health.Back.BE.HealthInstitution pHealthInstitution, Int32 pProfesionalId, Guid pUserId)
        {
            Back.BE.HealthInstitution_Profesional wHealthInstitution_Profesional = new Back.BE.HealthInstitution_Profesional();
            Back.BE.HealtInstitute_UsersInRoles wHealtInstitute_UsersInRoles = new BE.HealtInstitute_UsersInRoles();

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                //Busco la institución padre si existe
                var parentHI = dc.HealthInstitutions.Where(p => !p.HealthInstitutionIdParent.HasValue
                    && p.HealthInstitution_Profesional.Any(prof => prof.ProfesionalId.Equals(pProfesionalId))).FirstOrDefault();
                if (parentHI != null)
                    pHealthInstitution.HealthInstitutionIdParent = parentHI.HealthInstitutionId;

                pHealthInstitution.HealthInstitutionId = Guid.NewGuid();
                pHealthInstitution.CreatedDate = System.DateTime.Now;
                dc.HealthInstitutions.AddObject(pHealthInstitution);

                wHealthInstitution_Profesional.HealthInstitutionId = pHealthInstitution.HealthInstitutionId;
                wHealthInstitution_Profesional.ProfesionalId = pProfesionalId;
                wHealthInstitution_Profesional.ActiveFlag = true;
                wHealthInstitution_Profesional.UserId = pUserId;
                wHealthInstitution_Profesional.IsLockedOut = false;
                wHealthInstitution_Profesional.IsOwner = true;
                dc.HealthInstitution_Profesional.AddObject(wHealthInstitution_Profesional);


                wHealtInstitute_UsersInRoles.UserId = pUserId;
                wHealtInstitute_UsersInRoles.HealthInstitutionId = pHealthInstitution.HealthInstitutionId;
                wHealtInstitute_UsersInRoles.RoleName = "inst_owner";

                dc.HealtInstitute_UsersInRoles.AddObject(wHealtInstitute_UsersInRoles);

                dc.SaveChanges();

            }


        }

        /// <summary>
        /// Elimina rol a Institución
        /// Si es inst_owner o inst_admin establece .IsAdmin o.IsOwbner a falce respectivamente y posteriormente elimina el rol
        /// Si NO : l SOLO Elimina el rol
        /// </summary>
        /// <param name="pHealthInstitutionId"></param>
        /// <param name="userId"></param>
        /// <param name="rolName"></param>
        public static void Profesional_RemoveRol(Guid pHealthInstitutionId, Int32 pProfesionalId, Guid userId, string rolName)
        {
            Back.BE.HealthInstitution_Profesional wHealthInstitution_Profesional = null;
            Back.BE.HealtInstitute_UsersInRoles wHealtInstitute_UsersInRoles = null;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                wHealthInstitution_Profesional = dc.HealthInstitution_Profesional.Where(p =>
                                                  p.HealthInstitutionId.Equals(pHealthInstitutionId) &&
                                                  p.Profesional.IdProfesional.Equals(pProfesionalId)).FirstOrDefault();

                //Si solo queda un unico rol el cual sera removido el usuario queda automaticamente en estado no vigente
                if (dc.HealtInstitute_UsersInRoles.Count(p => p.UserId.Equals(userId) && p.HealthInstitutionId.Equals(pHealthInstitutionId)) == 1)
                {
                    wHealthInstitution_Profesional.ActiveFlag = false;
                    wHealthInstitution_Profesional.IsOwner = false;
                    wHealthInstitution_Profesional.IsAdmin = false;
                }
                else
                {
                    if (rolName.Equals("inst_owner") || rolName.Equals("inst_admin"))
                    {
                        if (rolName.Equals("inst_owner"))
                            wHealthInstitution_Profesional.IsOwner = false;

                        if (rolName.Equals("inst_admin"))
                            wHealthInstitution_Profesional.IsAdmin = false;
                    }
                }

                //busca la entidad HealtInstitute_UsersInRoles
                wHealtInstitute_UsersInRoles = dc.HealtInstitute_UsersInRoles.Where(p =>
                      p.UserId.Equals(userId) &&
                      p.HealthInstitutionId.Equals(pHealthInstitutionId) &&
                      p.RoleName.Equals(rolName)).FirstOrDefault();

                //Elimina la entidad HealtInstitute_UsersInRoles
                if (wHealtInstitute_UsersInRoles != null)
                    dc.HealtInstitute_UsersInRoles.DeleteObject(wHealtInstitute_UsersInRoles);

                dc.SaveChanges();
            }
        }

       

        /// <summary>
        /// Crea HealtInstitute_UsersInRoles = inst_admin
        /// Crea HealthInstitution_Profesional
        /// </summary>
        /// <param name="pHealthInstitutionId"></param>
        /// <param name="pProfesionalId_ToAssign"></param>
        /// <param name="pUserId"></param>
        public static void Profesional_Associate_As_AdminOwner(Guid pHealthInstitutionId, Int32 pProfesionalId_ToAssign, Guid pUserId, string rolname)
        {
            Back.BE.HealthInstitution_Profesional wHealthInstitution_Profesional = new Back.BE.HealthInstitution_Profesional();
            Back.BE.HealtInstitute_UsersInRoles wHealtInstitute_UsersInRoles = new BE.HealtInstitute_UsersInRoles();
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                wHealtInstitute_UsersInRoles.UserId = pUserId;
                wHealtInstitute_UsersInRoles.HealthInstitutionId = pHealthInstitutionId;
                wHealtInstitute_UsersInRoles.RoleName = rolname;

                wHealthInstitution_Profesional.IsAdmin = true;
                wHealthInstitution_Profesional.HealthInstitutionId = pHealthInstitutionId;
                wHealthInstitution_Profesional.ProfesionalId = pProfesionalId_ToAssign;
                wHealthInstitution_Profesional.UserId = pUserId;

                dc.HealthInstitution_Profesional.AddObject(wHealthInstitution_Profesional);
                dc.HealtInstitute_UsersInRoles.AddObject(wHealtInstitute_UsersInRoles);

                dc.SaveChanges();
            }

        }

        /// <summary>
        /// Asigna y/o crea un rol
        /// </summary>
        /// <param name="pHealthInstitutionId"></param>
        /// <param name="pProfesionalId_ToAssign"></param>
        /// <param name="pUserId"></param>
        /// <param name="roleName"></param>
        public static void Profesional_UsersInRoles_Assign(Guid pHealthInstitutionId, Int32 pProfesionalId_ToAssign, Guid pUserId, string roleName)
        {
            Back.BE.HealthInstitution_Profesional wHealthInstitution_Profesional = new Back.BE.HealthInstitution_Profesional();
            Back.BE.HealtInstitute_UsersInRoles wHealtInstitute_UsersInRoles = new BE.HealtInstitute_UsersInRoles();
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                //Si no existe la relacion del profesional con la inst.. se genera
                if (!dc.HealthInstitution_Profesional.Any(p =>
                 p.HealthInstitutionId.Equals(pHealthInstitutionId)
                 && p.Profesional.IdProfesional.Equals(pProfesionalId_ToAssign)))
                {
                    wHealthInstitution_Profesional.HealthInstitutionId = pHealthInstitutionId;
                    wHealthInstitution_Profesional.ProfesionalId = pProfesionalId_ToAssign;
                    wHealthInstitution_Profesional.UserId = pUserId;
                    wHealthInstitution_Profesional.IsLockedOut = false;
                    wHealthInstitution_Profesional.ActiveFlag = true;

                    if (roleName.Equals("inst_owner") || roleName.Equals("inst_admin"))
                    {
                        wHealthInstitution_Profesional.IsAdmin = roleName.Equals("inst_admin");
                        wHealthInstitution_Profesional.IsOwner = roleName.Equals("inst_owner");
                    }
                    dc.HealthInstitution_Profesional.AddObject(wHealthInstitution_Profesional);
                }


                wHealtInstitute_UsersInRoles.UserId = pUserId;
                wHealtInstitute_UsersInRoles.HealthInstitutionId = pHealthInstitutionId;
                wHealtInstitute_UsersInRoles.RoleName = roleName;

                dc.HealtInstitute_UsersInRoles.AddObject(wHealtInstitute_UsersInRoles);

                dc.SaveChanges();
            }
        }

      

        /// <summary>
        /// Bloquea un Profesional IsLockedOut = true
        /// </summary>
        /// <param name="pHealthInstitutionId"></param>
        /// <param name="pProfesionalId"></param>
        /// <param name="lockout">Si True : bloquea</param>
        public static void Profesional_Lock_Unlock(Guid pHealthInstitutionId, Int32 pProfesionalId, bool lockout)
        {

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                var wHealthInstitution_Profesional = dc.HealthInstitution_Profesional.Where(p =>
                                   p.HealthInstitutionId.Equals(pHealthInstitutionId) &&
                                   p.Profesional.IdProfesional.Equals(pProfesionalId)).FirstOrDefault();

                wHealthInstitution_Profesional.IsLockedOut = lockout;



                dc.SaveChanges();
            }
        }

        /// <summary>
        /// Establece a un Profesiona ActiveFlag = true  y elimina toda relacion con roles
        /// </summary>
        /// <param name="pHealthInstitutionId"></param>
        /// <param name="pProfesionalId"></param>
        public static void Profesional_Remove(Guid pHealthInstitutionId, Int32 pProfesionalId)
        {

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                var wHealthInstitution_Profesional = dc.HealthInstitution_Profesional.Where(p =>
                                    p.HealthInstitutionId.Equals(pHealthInstitutionId) &&
                                    p.Profesional.IdProfesional.Equals(pProfesionalId)).FirstOrDefault();

                wHealthInstitution_Profesional.ActiveFlag = false;

                var roles = dc.HealtInstitute_UsersInRoles.Where(p => p.UserId.Equals(wHealthInstitution_Profesional.UserId) && p.HealthInstitutionId.Equals(pHealthInstitutionId)).FirstOrDefault();
                dc.HealtInstitute_UsersInRoles.DeleteObject(roles);


                dc.SaveChanges();
            }
        }

        /// <summary>
        /// Retorna True si el usuario tiene autoirizacion en la institución
        /// </summary>
        /// <param name="pHealthInstitutionId"></param>
        /// <param name="pProfesionalId"></param>
        public static bool AuthenticateUser(Guid pHealthInstitutionId,  Int32? pProfesionalId,Guid? userId)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                return dc.HealthInstitution_Profesional.Any(p =>
                                   p.HealthInstitutionId.Equals(pHealthInstitutionId) &&
                                   (!pProfesionalId.HasValue || p.ProfesionalId.Equals(pProfesionalId.Value)) &&
                                   (!userId.HasValue || p.UserId.Equals(userId.Value))
                                   );
         
            }
        }


           /// <summary>
        /// Retorna HealthInstitution_ProfesionalBE por userid o profesionalid
        /// </summary>
        /// <param name="pHealthInstitutionId"></param>
        /// <param name="pProfesionalId"></param>
        public static HealthInstitution_ProfesionalBE Get_HealthInstitution_Profesional(Guid pHealthInstitutionId, Int32? pProfesionalId,Guid? userId)
        {
            HealthInstitution_ProfesionalBE wHealthInstitution_ProfesionalBE = null;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

              var wHealthInstitution_Profesional = dc.HealthInstitution_Profesional.Where(p =>
                                   p.HealthInstitutionId.Equals(pHealthInstitutionId) &&
                                   (!pProfesionalId.HasValue || p.ProfesionalId.Equals(pProfesionalId.Value)) &&
                                   (!userId.HasValue || p.UserId.Equals(userId.Value))
                                   ).FirstOrDefault();

              if (wHealthInstitution_Profesional != null)
              {
                  wHealthInstitution_ProfesionalBE = (HealthInstitution_ProfesionalBE)wHealthInstitution_Profesional;
                  //Asignar el array de Roles 
                  wHealthInstitution_ProfesionalBE.Roles = (from r in dc.HealtInstitute_UsersInRoles
                                                            where r.HealthInstitutionId.Equals(pHealthInstitutionId)
                                                            && r.UserId.Equals(wHealthInstitution_ProfesionalBE.UserId)
                                                            select r.RoleName).ToArray<string>();
              }

             
            }
            return wHealthInstitution_ProfesionalBE;
        }
        
        #endregion

        /// <summary>
        /// Retorna HealthInstitutionList filtrando por RazonSocial
        /// </summary>
        /// <param name="textToSearh">Filtro</param>
        /// <returns></returns>
        public static HealthInstitutionList RetriveHealthInstitutionByParams(string textToSearh)
        {
            HealthInstitutionList wHealthInstitutionList = null;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                var list = dc.HealthInstitutions.Where(s => s.RazonSocial.Contains(textToSearh));

                wHealthInstitutionList = new HealthInstitutionList();
                foreach (Health.Back.BE.HealthInstitution p in list)
                {
                    wHealthInstitutionList.Add((HealthInstitutionBE)p);
                }


                return wHealthInstitutionList;
            }
        }

        /// <summary>
        /// Retorna HealthInstitutionList filtrando por healttInstId
        /// 
        /// obtiene la institucion por id mas sus hermanas y padre
        /// </summary>
        /// <param name="textToSearh">Filtro</param>
        /// <returns></returns>
        public static HealthInstitutionList RetriveHealthInstitution_Relateds(Guid healttInstId)
        {
            HealthInstitutionList wHealthInstitutionList = new HealthInstitutionList ();
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                Health.Back.BE.HealthInstitution inst = dc.HealthInstitutions.Where(s => s.HealthInstitutionId.Equals(healttInstId)).FirstOrDefault();
                if (inst != null)
                    wHealthInstitutionList.Add((HealthInstitutionBE)inst);
               

                //Si es padre buscar hijas.. Si no tiene valor es por q es padre
                if (!inst.HealthInstitutionIdParent.HasValue)
                {
                    var childs = dc.HealthInstitutions.Where(s => s.HealthInstitutionIdParent.Equals(healttInstId));
                    foreach (Health.Back.BE.HealthInstitution p in childs)
                    {
                        wHealthInstitutionList.Add((HealthInstitutionBE)p);
                    }
                }
                //Buscar hermanas
                else
                {
                    var subyasents = dc.HealthInstitutions.Where(s => s.HealthInstitutionIdParent.Equals(inst.HealthInstitutionIdParent));
                    foreach (Health.Back.BE.HealthInstitution p in subyasents)
                    {
                        wHealthInstitutionList.Add((HealthInstitutionBE)p);
                    }
                }
                //Agregar el padre
                inst = dc.HealthInstitutions.Where(s => s.HealthInstitutionId.Equals(inst.HealthInstitutionIdParent)).FirstOrDefault();
                if (inst != null)
                    wHealthInstitutionList.Add((HealthInstitutionBE)inst);
               


                return wHealthInstitutionList;
            }
        }

        /// <summary>
        /// Retorna los Guid hijos
        /// </summary>
        /// <param name="healttInstId"></param>
        /// <returns></returns>
        public static List<Guid> RetriveHealthInstitution_Childs_Ids(Guid healttInstId)
        {
            HealthInstitutionList wHealthInstitutionList = new HealthInstitutionList();
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {


                var childs = from s in dc.HealthInstitutions where s.HealthInstitutionIdParent.Equals(healttInstId) select s.HealthInstitutionId;
                if (childs.Count() != 0)
                    return childs.ToList<Guid>();
                else
                    return null;


            }
        }

        /// <summary>
        /// Retorna HealthInstitution por guid y/o userGuid
        /// </summary>
        /// <param name="id">HealthInstitution ID</param>
        /// <param name="userId">Guid of the user</param>
        /// <returns></returns>
        public static HealthInstitutionBE GetById(Guid id, Guid? userId)
        {
            HealthInstitution_ProfesionalBE wProfesional = null;
            HealthInstitutionBE wHealthInstitutionBE = null;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                Health.Back.BE.HealthInstitution wHealthInstitution = dc.HealthInstitutions.Where(s => s.HealthInstitutionId.Equals(id)).FirstOrDefault<Health.Back.BE.HealthInstitution>();

                wHealthInstitutionBE = (HealthInstitutionBE)wHealthInstitution;

                if (userId.HasValue)
                {
                    //Si es owner o admin cargo la informacion extra roles y profesionales asociados
                    bool adminOrowner = wHealthInstitution.HealthInstitution_Profesional.Any(p => p.UserId.Equals(userId) && (p.IsOwner || p.IsOwner));
                    wHealthInstitutionBE.ProfesionalList = new HealthInstitution_ProfesionalList();
                    foreach (HealthInstitution_Profesional p in wHealthInstitution.HealthInstitution_Profesional)
                    {
                        wProfesional = (HealthInstitution_ProfesionalBE)p;
                        wHealthInstitutionBE.ProfesionalList.Add(wProfesional);
                        wProfesional.FullName = string.Concat(p.Profesional.Persona.Nombre.Trim(), ", ", p.Profesional.Persona.Apellido.Trim());
                    }

                    if (adminOrowner)
                    {
                        wHealthInstitutionBE.UsersInRoles = new HealtInstitute_UsersInRolesList();
                        foreach (HealtInstitute_UsersInRoles p in wHealthInstitution.HealtInstitute_UsersInRoles)
                        {
                            wHealthInstitutionBE.UsersInRoles.Add((HealtInstitute_UsersInRolesBE)p);
                        }
                    }
                }

                return wHealthInstitutionBE;
            }
        }


        /// <summary>
        /// Retorna HealthInstitution por guid
        /// </summary>
        /// <param name="id">HealthInstitution ID</param>
        /// <returns></returns>
        public static HealthInstitutionBE GetById_Simplifaied(Guid id)
        {

            HealthInstitutionBE wHealthInstitutionBE = null;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                Health.Back.BE.HealthInstitution wHealthInstitution = dc.HealthInstitutions.Where(s => s.HealthInstitutionId.Equals(id)).FirstOrDefault<Health.Back.BE.HealthInstitution>();

                wHealthInstitutionBE = (HealthInstitutionBE)wHealthInstitution;



                return wHealthInstitutionBE;
            }
        }

        /// <summary>
        /// Retorna los profecionales activos de una healthInstitute
        /// </summary>
        /// <param name="profesionalId">Profesional para no incluir</param>
        /// <param name="healthInstituteId">Institusion</param>
        /// <returns></returns>
        public static HealthInstitution_ProfesionalList Profesionals_Retrive_AllRelated(int profesionalId, Guid healthInstituteId)
        {
            HealthInstitution_ProfesionalList wProfesionalsBEList = new HealthInstitution_ProfesionalList();

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                ///Profesionales que ya pertenecen  a la institución Esta es una lista para quitar
                var profesionals_exist = from hp in dc.HealthInstitution_Profesional
                                         from p in dc.Profesional_FullView
                                         where
                                             hp.HealthInstitutionId.Equals(healthInstituteId) &&
                                             hp.ProfesionalId.Equals(p.IdProfesional) &&
                                             hp.ProfesionalId.Equals(profesionalId) == false &&
                                             hp.ActiveFlag.Equals(true)

                                         select new HealthInstitution_ProfesionalBE
                                         {
                                             ProfesionalId = p.IdProfesional,
                                             FullName = String.Concat(p.Apellido, p.Nombre),
                                             IsAdmin = hp.IsAdmin,
                                             IsLockedOut = hp.IsLockedOut,
                                             IsOwner = hp.IsOwner,
                                             UserId = hp.UserId,
                                         };
                //Asignar el array de Roles a cada profesionals_exist
                var health_roles = from r in dc.HealtInstitute_UsersInRoles where r.HealthInstitutionId.Equals(healthInstituteId) select r;
                foreach (HealthInstitution_ProfesionalBE p in profesionals_exist)
                {
                    p.Roles = (from r in health_roles select r.RoleName).ToArray<string>();
                }


                wProfesionalsBEList.AddRange(profesionals_exist.ToList<HealthInstitution_ProfesionalBE>());

            }
            return wProfesionalsBEList;
        }


        /// <summary>
        /// Determina si es padre
        /// </summary>
        /// <param name="healthInstitutionId"></param>
        /// <returns></returns>
        public static bool IsParent(Guid healthInstitutionId)
        {

           using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                return dc.HealthInstitutions.Any(s => s.HealthInstitutionId.Equals(healthInstitutionId) && !s.HealthInstitutionIdParent.HasValue);
            }
            
        }

        #region Subscription Req
        /// <summary>
        /// Crea un pedido de subscripcion 
        /// </summary>
        /// <param name="pProfesionalId_From"></param>
        /// <param name="pProfesionalId_To"></param>
        /// <param name="pHealthInstitutionId"></param>
        /// <param name="rolname"></param>
        /// <param name="msg"></param>
        public static void CreateSubscription_Req(int pProfesionalId_From, int pProfesionalId_To, Guid pHealthInstitutionId, string pRolName, string pMessage)
        {
            using (HealthLinQDataContext dc = new HealthLinQDataContext(Common.CnnString))
            {
                HealthInstitutions_SuscriptionRequest req = new HealthInstitutions_SuscriptionRequest();
                req.HealthInstitutionId = pHealthInstitutionId;
                req.Profesional_To = pProfesionalId_To;
                req.ProfesionalId_From = pProfesionalId_From;
                req.RequestSend = DateTime.Now;
                if (!string.IsNullOrEmpty(pMessage))
                    req.Message = pMessage;
                if (!string.IsNullOrEmpty(pRolName))
                    req.RoleName = pRolName;
                dc.HealthInstitutions_SuscriptionRequests.InsertOnSubmit(req);
                dc.SubmitChanges();
            }
        }


        /// <summary>
        /// Lista brebe de posibles profecionales para invitar con 
        /// IdProfesional,Nombre,Apellido
        /// </summary>
        /// <param name="nombreapellido">Filtro</param>
        /// <returns>HealthInstitutions_SuscriptionRequestsList</returns>
        public static HealthInstitutions_SuscriptionRequestsList SearchProfesionals_ToSuscriptionInfo(int profesionalId, Guid healthInstituteId, string nombreapellido)
        {
            HealthInstitutions_SuscriptionRequestsList wProfesionalsBEList = new HealthInstitutions_SuscriptionRequestsList();

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                ///Busca a los que ya se le enviaron solicitudes
                var profesionals_pendings = HealthInstitutionDAC.Retrive_Subscriptions_SimpleList(healthInstituteId);

                ///Profesionales que ya pertenecen  a la institución Esta es un alista para quitar
                var profesionals_exist = from hp in dc.HealthInstitution_Profesional
                                         from p in dc.Profesional_FullView
                                         where
                                             hp.HealthInstitutionId.Equals(healthInstituteId) &&
                                             hp.ProfesionalId.Equals(p.IdProfesional) &&
                                             hp.ProfesionalId.Equals(profesionalId) == false
                                         select new HealthInstitutions_SuscriptionRequestsBE { Profesional_To = p.IdProfesional, Nombre_To = p.Nombre, Apellido_To = p.Apellido };


                Int32[] ids_pendings = (from s in profesionals_pendings select s.Profesional_To).ToArray();
                Int32[] ids_exists = (from s in profesionals_exist select s.Profesional_To).ToArray();

                var profesionals_All = from p in dc.Profesional_FullView
                                       where
                                        !(ids_pendings.Contains(p.IdProfesional)) &&  //excluye profesionals_pendings
                                        !(ids_exists.Contains(p.IdProfesional)) &&// excluye profesionals_exist
                                         (String.IsNullOrEmpty(nombreapellido) || p.Nombre.Contains(nombreapellido) || p.Apellido.Contains(nombreapellido))
                                       select new HealthInstitutions_SuscriptionRequestsBE { Profesional_To = p.IdProfesional, Nombre_To = p.Nombre, Apellido_To = p.Apellido, Status = (int)SubscriptionRequestStatus.Null };

                wProfesionalsBEList.AddRange(profesionals_pendings.ToList<HealthInstitutions_SuscriptionRequestsBE>());
                wProfesionalsBEList.AddRange(profesionals_All.ToList<HealthInstitutions_SuscriptionRequestsBE>());
            }
            return wProfesionalsBEList;
        }

        /// <summary>
        ///  Retorna lista  <see cref="HealthInstitutions_SuscriptionRequestsList"/> con solo id , nombre + datos de la subscripción 
        /// </summary>
        /// <param name="healthInstituteId"></param>
        /// <returns></returns>
        internal static HealthInstitutions_SuscriptionRequestsList Retrive_Subscriptions_SimpleList(Guid healthInstituteId)
        {
            HealthInstitutions_SuscriptionRequestsList wProfesionalsBEList = new HealthInstitutions_SuscriptionRequestsList();
            using (HealthLinQDataContext dc = new HealthLinQDataContext(Common.CnnString))
            {
                var AllProfesionals = from p in dc.HealthInstitutions_SuscriptionRequests
                                      from prof in dc.Profesionals
                                      where

                                          p.HealthInstitutionId.Equals(healthInstituteId)
                                          && prof.IdProfesional.Equals(p.Profesional_To)
                                      select new HealthInstitutions_SuscriptionRequestsBE
                                      {
                                          Profesional_To = prof.IdProfesional,
                                          Nombre_To = prof.Persona.Nombre,
                                          Apellido_To = prof.Persona.Apellido,
                                          RequestSend = p.RequestSend,
                                          Status = p.State,
                                          Message = p.Message
                                      };


                wProfesionalsBEList.AddRange(AllProfesionals.ToList<HealthInstitutions_SuscriptionRequestsBE>());
            }
            return wProfesionalsBEList;
        }


        /// <summary>
        /// Lista usada para ver las solicitudes al profecional 
        /// Retorna lista  <see cref="HealthInstitutions_SuscriptionRequestsList"/> con solo id , nombre + datos de la subscripción 
        /// Se retorna Nombre y apellido es del usuario que solicita
        /// </summary>
        /// <param name="pIdProfesional">Id del profesional que desea ver sus solicitudes pendientes</param>
        /// <returns></returns>
        internal static HealthInstitutions_SuscriptionRequestsList Retrive_PendingSubscriptions_SimpleList(int pIdProfesional)
        {
            HealthInstitutions_SuscriptionRequestsList wProfesionalsBEList = new HealthInstitutions_SuscriptionRequestsList();
            using (HealthLinQDataContext dc = new HealthLinQDataContext(Common.CnnString))
            {
                var AllProfesionals = from p in dc.HealthInstitutions_SuscriptionRequests
                                      from h in dc.HealthInstitutions
                                      from prof_from in dc.Profesionals
                                  
                                      where

                                          p.Profesional_To.Equals(pIdProfesional)
                                                && h.HealthInstitutionId.Equals(p.HealthInstitutionId)
                                          && prof_from.IdProfesional.Equals(p.ProfesionalId_From)
                                    
                                          && !p.State.Equals(SubscriptionRequestStatus.Rechazado)
                                          && !p.State.Equals(SubscriptionRequestStatus.Expirado)
                                      select new HealthInstitutions_SuscriptionRequestsBE
                                      {
                                          Profesional_To = p.Profesional_To,
                                          Profesional_From = p.ProfesionalId_From,
                                          Nombre_From = prof_from.Persona.Nombre,
                                          Apellido_From = prof_from.Persona.Apellido,
                                          RequestSend = p.RequestSend,
                                          Status = p.State,
                                          HealthInsId = h.HealthInstitutionId,
                                          HealthInstName = h.RazonSocial,
                                          SenderIsOwner = p.SenderIsOwner,
                                          Message = p.Message
                                      };


                wProfesionalsBEList.AddRange(AllProfesionals.ToList<HealthInstitutions_SuscriptionRequestsBE>());
            }
            return wProfesionalsBEList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pHealthInstitutionId"></param>
        /// <param name="pIdProfesional_To"></param>
        /// <param name="status"></param>
        public static void Update_Subscriptions_Status(Guid pHealthInstitutionId, int pIdProfesional_To, SubscriptionRequestStatus status)
        {
            HealthInstitutions_SuscriptionRequestsList wProfesionalsBEList = new HealthInstitutions_SuscriptionRequestsList();
            using (HealthLinQDataContext dc = new HealthLinQDataContext(Common.CnnString))
            {
                var wSuscription = dc.HealthInstitutions_SuscriptionRequests.Where(p => p.Profesional_To.Equals(pIdProfesional_To)
                                   && p.HealthInstitutionId.Equals(p.HealthInstitutionId)).FirstOrDefault();

                wSuscription.State = (int)status;
                dc.SubmitChanges();
            }

        }


        internal static void Remove_SubscriptionReq(Guid pHealthInstitutionId, int pIdProfesional_To)
        {
            HealthInstitutions_SuscriptionRequestsList wProfesionalsBEList = new HealthInstitutions_SuscriptionRequestsList();
            using (HealthLinQDataContext dc = new HealthLinQDataContext(Common.CnnString))
            {
                var wSuscription = dc.HealthInstitutions_SuscriptionRequests.Where(p => p.Profesional_To.Equals(pIdProfesional_To)
                                          && p.HealthInstitutionId.Equals(p.HealthInstitutionId)).FirstOrDefault();



                dc.HealthInstitutions_SuscriptionRequests.DeleteOnSubmit(wSuscription);
                dc.SubmitChanges();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="pHealthInstitutionId"></param>
        /// <param name="pIdProfesional_To"></param>
        /// <param name="status"></param>
        public static void Acept_Subscriptions_Req(Guid pHealthInstitutionId, int pIdProfesional_To, Guid user_guid)
        {
            HealthInstitutions_SuscriptionRequestsList wProfesionalsBEList = new HealthInstitutions_SuscriptionRequestsList();
            using (HealthLinQDataContext dc = new HealthLinQDataContext(Common.CnnString))
            {
                var wSuscription = dc.HealthInstitutions_SuscriptionRequests.Where(p => p.Profesional_To.Equals(pIdProfesional_To)
                                          && p.HealthInstitutionId.Equals(p.HealthInstitutionId)).FirstOrDefault();



                //Asociar el profecional
                Profesional_Associate_As_AdminOwner(pHealthInstitutionId, pIdProfesional_To, user_guid, wSuscription.RoleName);


                //Elimina la subscripcion
                dc.HealthInstitutions_SuscriptionRequests.DeleteOnSubmit(wSuscription);
                dc.SubmitChanges();



            }

        }
        #endregion





    
    }
}
