using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Transactions;
using System.Data.Common;

using Health.Back.BE;
using Health.BE;

namespace Health.Back
{
    public class PersonasDAC
    {
        public static void Create(Health.BE.PersonaBE personaBE)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                Health.Back.BE.Persona persona = new Health.Back.BE.Persona();
                persona.UserId = personaBE.UserId;
                persona.Apellido = personaBE.Apellido;
                persona.Nombre = personaBE.Nombre;
                persona.NroDocumento = personaBE.NroDocumento;
                persona.TipoDocumento = personaBE.TipoDocumento;
                persona.IdEstadocivil = personaBE.IdEstadocivil;
                persona.FechaNacimiento = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(personaBE.FechaNacimiento);
                persona.FechaAlta = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(System.DateTime.Now);
                persona.LastAccessTime = persona.FechaAlta;
                persona.LastAccessUserId = personaBE.LastAccessUserId;

                persona.Calle = personaBE.Calle;
                persona.CalleNumero = personaBE.CalleNumero;
                persona.Piso = personaBE.Piso;
                persona.IdPais = personaBE.IdPais;
                persona.IdProvincia = personaBE.IdProvincia;
                persona.IdLocalidad = personaBE.IdLocalidad;
                persona.Barrio = personaBE.Barrio;
                persona.mail = personaBE.mail;
                persona.Telefono1 = personaBE.Telefono1;
                persona.Telefono2 = personaBE.Telefono2;
                persona.Foto = personaBE.Foto;

                dc.Personas.AddObject(persona);
                dc.SaveChanges();
                personaBE.FechaAlta = persona.FechaAlta;
                personaBE.IdPersona = persona.IdPersona;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <returns></returns>
        public static List<PersonaBE> SearchByParams(string nombre, string apellido)
        {
            List<PersonaBE> wPersonasBEList = new List<PersonaBE>();
            List<Persona> wPersonas = null;

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(apellido))
                    wPersonas = dc.Personas.ToList<Persona>();
                else
                {
                    var Personas = from p in dc.Personas
                                       where
                                           (String.IsNullOrEmpty(nombre) || p.Nombre.Contains(nombre)
                                           || (String.IsNullOrEmpty(apellido) || p.Apellido.Contains(apellido)))
                                       select p;

                    wPersonas = Personas.ToList<Persona>();
                }
               
            

                foreach (Persona p in wPersonas)
                {
                   
                    wPersonasBEList.Add( (PersonaBE)p);
                }


            }
            return wPersonasBEList;
        }

        public static bool Exist(String nroDocumento)
        {
            
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                return dc.Personas.Any<Persona>(p => p.NroDocumento.Equals(nroDocumento));
                
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="personaBE"></param>
        public static void Update(PersonaBE personaBE)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                Persona wPersona = dc.Personas.Where(p => p.IdPersona.Equals(personaBE.IdPersona)).FirstOrDefault<Persona>();

                wPersona.Apellido = personaBE.Apellido;
                wPersona.Nombre = personaBE.Nombre;
                wPersona.NroDocumento = personaBE.NroDocumento;
                wPersona.TipoDocumento = personaBE.TipoDocumento;
                wPersona.IdEstadocivil = personaBE.IdEstadocivil;
                wPersona.FechaNacimiento = personaBE.FechaNacimiento;
                wPersona.Sexo = personaBE.Sexo;

                wPersona.Calle = personaBE.Calle;
                wPersona.CalleNumero = personaBE.CalleNumero;
                wPersona.Piso = personaBE.Piso;
                wPersona.IdPais = personaBE.IdPais;
                wPersona.IdProvincia = personaBE.IdProvincia;
                wPersona.IdLocalidad = personaBE.IdLocalidad;
                wPersona.Barrio = personaBE.Barrio;
                wPersona.mail = personaBE.mail;
                wPersona.Telefono1 = personaBE.Telefono1;
                wPersona.Telefono2 = personaBE.Telefono2;
                wPersona.Foto = personaBE.Foto;

                wPersona.LastAccessTime = System.DateTime.Now;
                wPersona.LastAccessUserId = personaBE.LastAccessUserId;
                wPersona.LastAccessTime = wPersona.LastAccessTime;
                wPersona.LastAccessUserId = personaBE.LastAccessUserId;
                dc.SaveChanges();
            }
        }
    }
    
}
