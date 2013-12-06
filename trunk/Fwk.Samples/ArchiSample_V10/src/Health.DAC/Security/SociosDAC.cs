using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using Health.BE;
using Health.Back.BE;
using Health.Entities;

namespace Health.DAC
{
    public class  WebRegistrationDAC
    {

        #region Web registration
        
        /// <summary>
        /// Crea una solicitud. No establece IsApproved = true
        /// </summary>
        /// <param name="registrationRequest"></param>
        public static void CreateRegistrationRequest(RegistrationRequest registrationRequest)
        {
            using (Health.Entities.HealthLinQDataContext dc = new Health.Entities.HealthLinQDataContext(Common.CnnString))
            {
            
                registrationRequest.RequetsTime = System.DateTime.Now;

                dc.RegistrationRequests.InsertOnSubmit(registrationRequest);
                dc.SubmitChanges();
                
            }
        }

        public static RegistrationRequest Get_RegistrationRequest(string registrationCode)
        {
            using (Health.Entities.HealthLinQDataContext dc = new Health.Entities.HealthLinQDataContext(Common.CnnString))
            {
                var reg = dc.RegistrationRequests.Where(s => s.RegistrationCode.Trim().Equals(registrationCode.Trim())).FirstOrDefault<RegistrationRequest>();
                return reg;
            }

        }
        public static RegistrationRequest Get_RegistrationRequest_Id(int id)
        {
            
            using (Health.Entities.HealthLinQDataContext dc = new Health.Entities.HealthLinQDataContext(Common.CnnString))
            {
                var reg = dc.RegistrationRequests.Where(s => s.Id.Equals(id)).FirstOrDefault<RegistrationRequest>();
                return reg;
            }

        }

        /// <summary>
        /// Retorna sulicitud de registro por nombre
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static RegistrationRequest Get_RegistrationRequest(int id)
        {
            using (Health.Entities.HealthLinQDataContext dc = new Health.Entities.HealthLinQDataContext(Common.CnnString))
            {
                var reg = dc.RegistrationRequests.Where(s => s.Id.Equals(id)).FirstOrDefault<RegistrationRequest>();
                return reg;
            }

        }

        /// <summary>
        /// Retorna lista de sulicitud de registro
        /// </summary>
        /// <param name="isApproved"></param>
        /// <returns></returns>
        public static List<RegistrationRequest> Retrive_All_RegistrationRequest(bool? isApproved)
        {
            using (Health.Entities.HealthLinQDataContext dc = new Health.Entities.HealthLinQDataContext(Common.CnnString))
            {
                return dc.RegistrationRequests.Where(p=> (isApproved.HasValue || p.IsApproved.Equals(isApproved.Value))).ToList < RegistrationRequest>();
                
            }

        }
        #endregion
        //public static Profesional_FullViewBE GetByGuid(Guid id)
        //{

        //    using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
        //    {
        //        var user = dc.Profesional_FullView.Where(s => s.UserId.Equals(id)).FirstOrDefault<Profesional_FullView>();
        //        return new Profesional_FullViewBE(user);
                
        //    }
        //}

        /// <summary>
        /// Aprueva un registro de solicitud
        /// Establece IsApproved = true y user id a Socios donde  nrsocio coincida
        /// Si viene el nro abonado solo actualizaria un dato
        /// </summary>
        /// <param name="nroSocio">Numero de socio</param>
        /// <param name="userId">Id del usuario web generado</param>
        public static void Approve(int id)
        {
            using (Health.Entities.HealthLinQDataContext dc = new Health.Entities.HealthLinQDataContext(Common.CnnString))
            {
               var r =  dc.RegistrationRequests.Where    (p=> p.Id.Equals(id)).FirstOrDefault<RegistrationRequest>();

               r.IsApproved = true;
                

                dc.SubmitChanges();
            }
        }
        /// <summary>
        /// Registra el usuario en socios
        /// Establece active = false y user id a Socios donde  nrsocio coincida
        /// Si viene el nro abonado solo actualizaria un dato
        /// </summary>
        /// <param name="nroSocio">Numero de socio</param>
        /// <param name="userId">Id del usuario web generado</param>
        //public static void Desregistrar(int nroSocio, int? nroAbonado, Guid userId, bool isAuthorized)
        //{
        //    using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
        //    {
        //        var user = from s in dc.Socios
        //                   where

        //                       (s.NroSocio.Equals(nroSocio))

        //                       &&
        //                       (nroAbonado.HasValue.Equals(false) || s.NroAbonado.Equals(nroAbonado))
        //                   select s;

        //        foreach (Socio wSocio in user)
        //        {
        //            wSocio.UserId = null;
        //            wSocio.Active = isAuthorized;
        //        }
        //        dc.SubmitChanges();
        //    }
        //}

        /// <summary>
        /// Autoriza el usuario en estado  active = true y user id del generado
        /// </summary>
        /// <param name="nroSocio"></param>
        /// <param name="userId"></param>
        //public static void Activar(int nroSocio,int? nroAbonado)
        //{
        //    using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
        //    {
        //        var users = from s in dc.Socios 
        //                   where 
        //                   s.NroSocio.Equals(nroSocio)
        //                    &&
        //                       (nroAbonado.HasValue.Equals(false) || s.NroAbonado.Equals(nroAbonado))
        //                   select s;

        //        foreach (Socio wSocio in users)
        //        {
        //            wSocio.Active = true;
        //        }
        //        dc.SubmitChanges();

                
        //    }
        //}
        /// <summary>
        /// Autoriza el usuario en estado  active = true y user id del generado
        /// </summary>
        /// <param name="userId"></param>
        //public static void Activar(Guid userId)
        //{
        //    using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
        //    {
        //        var users = from s in dc.Socios
        //                    where
        //                    s.UserId.Equals(userId)
                             
        //                    select s;
        //        foreach (Socio wSocio in users)
        //        {
        //            wSocio.Active = true;
        //        }
        //        dc.SubmitChanges();


        //    }
        //}
        /// <summary>
        /// desautoriza el usuario en estado  active = true y user id del generado
        /// </summary>
        /// <param name="userId"></param>
        //public static void Desactivar(Guid userId)
        //{
        //    using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
        //    {
        //        var users = from s in dc.Socios
        //                    where
        //                    s.UserId.Equals(userId)
        //                    select s;

        //        foreach (Socio wSocio in users)
        //        {
        //            wSocio.Active = false;
        //        }
        //        dc.SubmitChanges();


        //    }
        //}
        /// <summary>
        /// desautoriza el usuario en estado  active = true y user id del generado
        /// </summary>
        /// <param name="nroSocio"></param>
        /// <param name="userId"></param>
        //public static void Desactivar(int nroSocio, int? nroAbonado)
        //{
        //    using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
        //    {
        //        var users = from s in dc.Socios
        //                    where
        //                    s.NroSocio.Equals(nroSocio)
        //                     &&
        //                        (nroAbonado.HasValue.Equals(false) || s.NroAbonado.Equals(nroAbonado))
        //                    select s;

        //        foreach (Socio wSocio in users)
        //        {
        //            wSocio.Active = false;
        //        }
        //        dc.SubmitChanges();


        //    }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nroSocio"></param>
        /// <returns></returns>
        //public static bool Exist(string nroSocio)
        //{
        //    using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
        //    {
        //        return dc.Socios.Any<Socio>(s => s.NroSocio.Equals(nroSocio));
        //    }
        //}

        /// <summary>
        /// Retorna todos los Socios y abonados
        /// </summary>
        /// <returns></returns>
        //public static List<factura_socio_list> RetriveAll(bool isRegisteredOnly)
        //{
        //    List<factura_socio_list> factura_socio_list = new List<Health.BE.Linq2SQL.factura_socio_list>();
        //    factura_socio_list view = null;
        //    using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
        //    {

        //        var socios = from s in dc.socios_views
        //                     where
        //                    (isRegisteredOnly.Equals(true) && s.UserId != null)
        //                        || isRegisteredOnly.Equals(false)
        //                     select s;

        //        foreach (socios_view s in socios)
        //        {
        //            view = new factura_socio_list();
        //            if (!string.IsNullOrEmpty(s.Apellido))
        //                view.NOMBRES_ABONADOS = string.Concat(s.Apellido.Trim(), ", ", s.Nombre).Trim();
        //            else
        //                view.NOMBRES_ABONADOS =  s.Nombre.Trim();

        //            view.ABONADO_NRO = s.NroAbonado;
        //            view.SOCIO_NRO = s.NroSocio;
        //            view.DIRECCION = s.Direccion;
        //            view.Email = s.Email;
        //            view.UserName = s.UserName;
        //            view.UserId = s.UserId;
        //            view.IsImported = 1;
        //            if (isRegisteredOnly)
        //            {
        //                view.IsRegistered = 1;
        //            }
        //            else
        //            {
        //                if (s.UserId != null)
        //                    view.IsRegistered = 1;
        //                else
        //                    view.IsRegistered = 0;
        //            }

        //            view.IsAuthorized = s.Active;
        //            factura_socio_list.Add(view);

        //        }
        //        return factura_socio_list;
        //    }
        //}




        //public static aspnet_User Get_AspNetUSer(Guid userId)
        //{
        //    try
        //    {
        //        using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
        //        {

        //            var user = from s in dc.aspnet_Users
        //                       where
        //                       s.UserId.Equals(userId)


        //                       select s;

        //            return user.FirstOrDefault<aspnet_User>();
                    
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
