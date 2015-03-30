using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Transactions;
using System.Data.Common;
using Health.Entities;
using Health.Back.BE;
using Health.BE;

namespace Health.Back
{

    /// <summary>
    /// 
    /// </summary>
    public class ProfesionalesDAC
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <returns></returns>
        public static List<Profesional_FullViewBE> SearchByParams(string nombre, string apellido)
        {
            Profesional_FullViewList wProfesionalsBEList = new Profesional_FullViewList();
            List<Profesional_FullView> wProfesionals = null;

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(apellido))
                    wProfesionals = dc.Profesional_FullView.ToList<Profesional_FullView>();
                else
                {
                    var Profesionals = from p in dc.Profesional_FullView
                                       where
                                           (String.IsNullOrEmpty(nombre) || p.Nombre.Contains(nombre)
                                           || (String.IsNullOrEmpty(apellido) || p.Apellido.Contains(apellido)))
                                       select p;

                    wProfesionals = Profesionals.ToList<Profesional_FullView>();
                }

                Profesional_FullViewBE wProfesionalBE = null;

                foreach (Profesional_FullView p in wProfesionals)
                {
                    wProfesionalBE = (Profesional_FullViewBE)p;
                    wProfesionalsBEList.Add(wProfesionalBE);
                }


            }
            return wProfesionalsBEList;
        }

        /// <summary>
        /// Retorna Profesionales directamente relacionados in la inst
        /// Retorna  Profesional_FullViewBE
        /// </summary>
        /// <param name="healthInstId"></param>
        /// <returns></returns>
        public static List<Profesional_FullViewBE> SearchBy_HealthInstRelated(Guid healthInstId, List<Int32> prof_ids_JustRetrived = null)
        {
            Profesional_FullViewList wProfesionalsBEList = new Profesional_FullViewList();
            Profesional_FullViewBE wProfesionalBE=null;
            if (prof_ids_JustRetrived == null) prof_ids_JustRetrived = new List<int>();
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                //Profesionales de la institucion
        

                var wProfesionals_DB = from p in dc.Profesional_FullView
                                       from hp in dc.HealthInstitution_Profesional
                                       where
                                            hp.HealthInstitutionId.Equals(healthInstId)
                                           && hp.ProfesionalId.Equals(p.IdProfesional)
                                           && (prof_ids_JustRetrived.Count().Equals(0) || !prof_ids_JustRetrived.Contains(p.IdProfesional)) //Exeptua los just retriveds
                                       select p;

                foreach (var item in wProfesionals_DB)
                {
                    wProfesionalBE = (Profesional_FullViewBE)item;
                    //wProfesionalBE.HealthInstitution_Profesional = (HealthInstitution_ProfesionalBE)item.Prof_hp;
                    wProfesionalsBEList.Add(wProfesionalBE);
                }
            }
            return wProfesionalsBEList;
        }



        /// <summary>
        /// Retorna TODAS las HealthInstitution_Profesional del Profesional
        /// </summary>
        /// <param name="pPrefesionalId"></param>
        /// <returns></returns>
        public static Health.BE.HealthInstitution_ProfesionalList Retrive_HealthInstitution_Relationships(int pPrefesionalId)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                List<Health.Back.BE.HealthInstitution_Profesional> list2 = null;
                
                    list2 = (from p in dc.HealthInstitution_Profesional
                             where                             
                             p.ProfesionalId.Equals(pPrefesionalId) 
                             
                             select p).ToList<Health.Back.BE.HealthInstitution_Profesional>();

                    HealthInstitution_ProfesionalList list = new HealthInstitution_ProfesionalList();
                    HealthInstitution_ProfesionalBE wBE;

                foreach (Health.Back.BE.HealthInstitution_Profesional i in list2)
                {
                    wBE = (HealthInstitution_ProfesionalBE)i;
                    //Asignar el array de Roles a cada profesional
                    var health_roles = from r in dc.HealtInstitute_UsersInRoles where r.HealthInstitutionId.Equals(i.HealthInstitutionId) select r.RoleName;
                    if (health_roles.Count() != 0)
                        wBE.Roles = health_roles.ToArray<string>();

                    list.Add(wBE);
                }

                return list;
            }

        }

       

        /// <summary>
        /// Retorna lista brebe con 
        /// IdProfesional,Nombre,Apellido
        /// </summary>
        /// <param name="nombreapellido"></param>
        /// <returns></returns>
        public static Profesional_FullViewList SearchByParams_SimpleList(string nombreapellido)
        {
            Profesional_FullViewList wProfesionalsBEList = new Profesional_FullViewList();

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                    var Profesionals = from p in dc.Profesional_FullView
                                       where
                                           String.IsNullOrEmpty(nombreapellido) ||  (p.Nombre.Contains(nombreapellido) || p.Apellido.Contains(nombreapellido))
                                       select new Profesional_FullViewBE {IdProfesional=p.IdProfesional, Nombre = p.Nombre, Apellido = p.Apellido };

                    wProfesionalsBEList.AddRange(Profesionals.ToList<Profesional_FullViewBE>());
            }
            return wProfesionalsBEList;
        }


        public static String[] Get_HealtInstitute_UsersInRoles(Guid userId, Guid healthIsntId)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var roles = from p in dc.HealtInstitute_UsersInRoles
                            where
                               p.UserId.Equals(userId) 
                               && p.HealthInstitutionId.Equals(healthIsntId)
                            select p.RoleName;

                return roles.ToArray();
            }

        }


        /// <summary>
        /// Obtiene un profesional por Id
        /// </summary>
        /// <param name="IdProfesional"></param>
        /// <returns></returns>
        public static Profesional_FullViewBE Get_FullView_ById(int idProfesional)
        {
            Profesional_FullViewBE wProfesional = null;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                Profesional_FullView profesional_db = dc.Profesional_FullView.Where(p => p.IdProfesional.Equals(idProfesional)).FirstOrDefault<Profesional_FullView>();

                wProfesional = (Profesional_FullViewBE)profesional_db;
            }
            return wProfesional;
        }

        /// <summary>
        /// Obtiene un profesional por Id
        /// </summary>
        /// <param name="idProfesional"></param>
        /// <returns></returns>
        public static ProfesionalBE GetById(int idProfesional)
        {
            ProfesionalBE wProfesional = null;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                //var result = from p in dc.Profesionals from e in dc.Parametros 
                //                    where (p.IdEspecialidad == e.IdParametro )
                //                    &&  p.IdProfesional.Equals(idProfesional) 
                //             select new {profesional= p,Especialidad = e.Nombre,Persona=p.Persona};
                // var x = result.FirstOrDefault();

                // if (x != null)
                // {
                //     wProfesional = (ProfesionalBE)x.profesional;
                //     wProfesional.Persona = (PersonaBE)x.Persona;
                //     wProfesional.NombreEspecialidad = x.Especialidad;
                // }
                var x = dc.Profesional_FullView.Where(p => p.IdProfesional.Equals(idProfesional)).FirstOrDefault();
                if (x != null)
                {
                    wProfesional = new ProfesionalBE();
                    wProfesional.Persona = new PersonaBE();

                    wProfesional.IdEspecialidad = x.IdEspecialidad;
                    wProfesional.Persona.IdEstadocivil = x.IdEstadocivil;
                    wProfesional.Matricula = x.Matricula;
                    wProfesional.IdProfesional = x.IdProfesional;
                    wProfesional.IdProfesion = x.IdProfesion;
                    //wProfesional.NombreProfecion = x.NombreProfecion;

                    wProfesional.Persona.Apellido = x.Apellido;
                    wProfesional.Persona.Nombre = x.Nombre;
                    wProfesional.Persona.Sexo = x.Sexo;
                    wProfesional.Persona.FechaAlta = x.FechaAlta.Value;
                    wProfesional.Persona.UserId = x.UserId;
                    wProfesional.Persona.FechaNacimiento = x.FechaNacimiento;
                    wProfesional.Persona.NroDocumento = x.NroDocumento;
                    wProfesional.Persona.TipoDocumento = x.TipoDocumento;
                    wProfesional.UserName = x.UserName;

                    wProfesional.NombreEspecialidad = x.NombreEspecialidad;


                    wProfesional.Persona.Street = x.Street;
                    wProfesional.Persona.StreetNumber = x.StreetNumber;
                    wProfesional.Persona.Floor = x.Floor;
                    wProfesional.Persona.CountryId = x.CountryId;
                    wProfesional.Persona.ProvinceId = x.ProvinceId;
                    wProfesional.Persona.CityId = x.CityId;
                    wProfesional.Persona.Neighborhood = x.Neighborhood;
                    wProfesional.Persona.mail = x.mail;
                    wProfesional.Persona.Telefono1 = x.Telefono1;
                    wProfesional.Persona.Telefono2 = x.Telefono2;
                    wProfesional.Persona.Foto = x.Foto;

                    wProfesional.FechaAlta = x.FechaAlta;




                }
            }
            return wProfesional;
        }

        public static PersonaBE Get_Person_Basic_Info(int idProfesional)
        {
           
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
         
                var x = dc.Profesionals.Where(p => p.IdProfesional.Equals(idProfesional)).FirstOrDefault();
                if (x != null)
                {

                    return (PersonaBE)x.Persona;
                }
            }
            return null;
        }
        public static ProfesionalBE GetByUserGuid(Guid userGuid)
        {
            ProfesionalBE wProfesional = null;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var x = dc.Profesional_FullView.Where(p => p.UserId.Value.Equals(userGuid)).FirstOrDefault();
                if (x != null)
                {
                    wProfesional = new ProfesionalBE();
                    wProfesional.Persona = new PersonaBE();

                    wProfesional.IdEspecialidad = x.IdEspecialidad;
                    wProfesional.Persona.IdEstadocivil = x.IdEstadocivil;
                    wProfesional.Matricula = x.Matricula;
                    wProfesional.IdProfesional = x.IdProfesional;
                    wProfesional.IdProfesion = x.IdProfesion;
                    //wProfesional.NombreProfecion = x.NombreProfecion;

                    wProfesional.Persona.Apellido = x.Apellido;
                    wProfesional.Persona.Nombre = x.Nombre;
                    wProfesional.Persona.Sexo = x.Sexo;
                    wProfesional.Persona.FechaAlta = x.FechaAlta.Value;
                    wProfesional.Persona.UserId = x.UserId;
                    wProfesional.Persona.FechaNacimiento = x.FechaNacimiento;
                    wProfesional.Persona.NroDocumento = x.NroDocumento;
                    wProfesional.Persona.TipoDocumento = x.TipoDocumento;
                    wProfesional.UserName = x.UserName;

                    wProfesional.NombreEspecialidad = x.NombreEspecialidad;
                    wProfesional.Persona.Street = x.Street;
                    wProfesional.Persona.StreetNumber = x.StreetNumber;
                    wProfesional.Persona.Floor = x.Floor;
                    wProfesional.Persona.CountryId = x.CountryId;
                    wProfesional.Persona.ProvinceId = x.ProvinceId;
                    wProfesional.Persona.CityId = x.CityId;
                    wProfesional.Persona.Neighborhood = x.Neighborhood;
                    wProfesional.Persona.mail = x.mail;
                    wProfesional.Persona.Telefono1 = x.Telefono1;
                    wProfesional.Persona.Telefono2 = x.Telefono2;
                    wProfesional.Persona.Foto = x.Foto;


                    wProfesional.FechaAlta = x.FechaAlta;

                }
            }
            return wProfesional;
        }

        public static Profesional_FullView Get_Profesional_FullView_ByUserGuid(Guid userGuid)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                return dc.Profesional_FullView.Where(p => p.UserId.Value.Equals(userGuid)).FirstOrDefault();

            }
        }
        /// <summary>
        /// Obtiene un profesional por userName
        /// </summary>
        /// <param name="IdProfesional"></param>
        /// <returns></returns>
        public static Profesional_FullViewBE Get_FullView_ByName(string userName)
        {
            Profesional_FullViewBE wProfesional = null;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
     
                Profesional_FullView profesional_db = dc.Profesional_FullView.Where(p => p.UserName.Equals(userName)).FirstOrDefault<Profesional_FullView>();

                wProfesional = (Profesional_FullViewBE)profesional_db;
            }
            return wProfesional;
        }


        /// <summary>
        /// Crea un profesional y clase persona
        /// </summary>
        /// <param name="profesionalBE"></param>
        public static void Create(ProfesionalBE profesionalBE)
        {
            PersonasDAC.Create(profesionalBE.Persona);
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                Health.Back.BE.Profesional p = new Health.Back.BE.Profesional();

                p.IdPersona = profesionalBE.Persona.IdPersona;

                p.FechaAlta = profesionalBE.Persona.FechaAlta;
                p.Matricula = profesionalBE.Matricula;
                p.IdEspecialidad = profesionalBE.IdEspecialidad;
                p.IdProfesion = profesionalBE.IdProfesion;
                p.LastAccessTime = p.FechaAlta;
                p.LastAccessUserId = profesionalBE.LastAccessUserId;

                dc.Profesionals.AddObject(p);
                dc.SaveChanges();

                profesionalBE.IdProfesional = p.IdProfesional;
                profesionalBE.IdPersona = p.IdPersona;
            }
        }

        /// <summary>
        /// Asocia un profesional a una persona existente
        /// </summary>
        /// <param name="profesionalBE"></param>
        public static void Asociar(ProfesionalBE profesionalBE)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                Health.Back.BE.Profesional profesional = new Health.Back.BE.Profesional();
                profesional.IdPersona = profesionalBE.IdPersona;

                profesional.FechaAlta = System.DateTime.Now;
                profesional.Matricula = profesionalBE.Matricula;
                profesional.IdEspecialidad = profesionalBE.IdEspecialidad;
                profesional.LastAccessTime = profesional.FechaAlta;
                profesional.LastAccessUserId = profesionalBE.LastAccessUserId;

                dc.Profesionals.AddObject(profesional);
                dc.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profesional"></param>
        public static void Update(ProfesionalBE profesional)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                Health.Back.BE.Profesional wProfesional = dc.Profesionals.Where(p => p.IdProfesional.Equals(profesional.IdProfesional)).FirstOrDefault<Health.Back.BE.Profesional>();

                wProfesional.Persona.Apellido = profesional.Persona.Apellido;
                wProfesional.Persona.Nombre = profesional.Persona.Nombre;
                wProfesional.Persona.NroDocumento = profesional.Persona.NroDocumento;
                wProfesional.Persona.TipoDocumento = profesional.Persona.TipoDocumento;
                wProfesional.Persona.IdEstadocivil = profesional.Persona.IdEstadocivil;
                wProfesional.Persona.FechaNacimiento = profesional.Persona.FechaNacimiento;
                wProfesional.Persona.Sexo = profesional.Persona.Sexo;

                wProfesional.Persona.Street = profesional.Persona.Street;
                wProfesional.Persona.StreetNumber = profesional.Persona.StreetNumber;
                wProfesional.Persona.Floor = profesional.Persona.Floor;
                wProfesional.Persona.CountryId = profesional.Persona.CountryId;
                wProfesional.Persona.ProvinceId = profesional.Persona.ProvinceId;
                wProfesional.Persona.CityId = profesional.Persona.CityId;
                wProfesional.Persona.Neighborhood = profesional.Persona.Neighborhood;
                wProfesional.Persona.mail = profesional.Persona.mail;
                wProfesional.Persona.Telefono1 = profesional.Persona.Telefono1;
                wProfesional.Persona.Telefono2 = profesional.Persona.Telefono2;
                wProfesional.Persona.Foto = profesional.Persona.Foto;
                wProfesional.Matricula = profesional.Matricula;

                wProfesional.LastAccessTime = System.DateTime.Now;
                wProfesional.LastAccessUserId = profesional.LastAccessUserId;
                wProfesional.Persona.LastAccessTime = wProfesional.LastAccessTime.Value;
                wProfesional.Persona.LastAccessUserId = profesional.LastAccessUserId.Value;
                dc.SaveChanges();
            }
        }

        /// <summary>
        /// Detecta si la persona esta asociado a algun profesional, atraves de su documento
        /// </summary>
        /// <param name="nroDocumento">Nro de documento</param>
        /// <returns></returns>
        public static bool Persona_EstaAsociada(String nroDocumento)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                return dc.Profesionals.Any<Health.Back.BE.Profesional>(p => p.Persona.NroDocumento.Equals(nroDocumento));
            }
        }



        internal static Profesional_FullView Get_ByParams(string nroDocumento, string matricula)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var user = from s in dc.Profesional_FullView
                           where
                           s.NroDocumento.Equals(nroDocumento)
                           &&
                           (s.Matricula.Equals(matricula))
                           select s;

                return user.FirstOrDefault<Profesional_FullView>();
            }

        }


        /// <summary>
        /// Retorna  HealthInstitutionList del Profesional donde el Profesional es ouner
        /// </summary>
        /// <param name="pPrefesionalId"></param>
        /// <returns></returns>
        public static Health.BE.HealthInstitutionList Retrive_HealthInstitution(int pPrefesionalId, Boolean asOwner, Boolean asAdmin)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                List<Health.Back.BE.HealthInstitution> list2 = null;
                if (asOwner)
                    list2 = (from s in dc.HealthInstitutions
                            from p in dc.HealthInstitution_Profesional
                            where
                             s.HealthInstitutionId.Equals(p.HealthInstitutionId) &&
                             p.ProfesionalId.Equals(pPrefesionalId) &&
                            asOwner && p.IsOwner.Equals(true)
                             select s).ToList < Health.Back.BE.HealthInstitution>();

                if (asAdmin)
                    list2 = (from s in dc.HealthInstitutions
                            from p in dc.HealthInstitution_Profesional
                            where
                             s.HealthInstitutionId.Equals(p.HealthInstitutionId) &&
                             p.ProfesionalId.Equals(pPrefesionalId) &&
                                p.IsAdmin.Equals(true)
                            select s).ToList < Health.Back.BE.HealthInstitution>();

                HealthInstitutionList wHealthInstitutionList = new HealthInstitutionList();
                HealthInstitutionBE wHealthInstitutionBE;

                foreach (Health.Back.BE.HealthInstitution i in list2)
                {
                    wHealthInstitutionBE = (HealthInstitutionBE)i;
                    //Si es argentina rellenar nombres
                    if (wHealthInstitutionBE.CountryId == 11000)
                    {
                        wHealthInstitutionBE.Province = i.Parametro2.Nombre;
                        wHealthInstitutionBE.City = i.Parametro1.Nombre;
                        wHealthInstitutionBE.Country = i.Parametro.Nombre;//FK_HealthInstitution_Parametros_Country

                    }
                    wHealthInstitutionList.Add(wHealthInstitutionBE);
                }

                return wHealthInstitutionList;
            }

        }


        #region Subscriptions messages etc

        /// Lista brebe de posibles Profesionales para invitar con 
        /// IdProfesional,Nombre,Apellido
        /// </summary>
        /// <param name="nombreapellido">Filtro</param>
        /// <returns>HealthInstitutions_SuscriptionRequestsList</returns>
        public static HealthInstitutions_SuscriptionRequestsList Search_Pending_HealthInstitutionsSuscriptionInfo(int profesionalId)
        {

           return HealthInstitutionDAC.Retrive_PendingSubscriptions_SimpleList(profesionalId);
            
            
           // HealthInstitutions_SuscriptionRequestsList list = new HealthInstitutions_SuscriptionRequestsList();

            //using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            //{

            //    ///Busca a los que ya se le enviaron solicitudes
            //    var wHealthInstitution_pendings = HealthInstitutionDAC.Retrive_PendingSubscriptions_SimpleList(profesionalId);

            //    list.AddRange(wHealthInstitution_pendings.ToList<HealthInstitutions_SuscriptionRequestsBE>());

            //}
            // return list;
        }


        #endregion


    }
}
