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
    public class PatientsDAC
    {
        public static List<PatientBE> SearchByParams(string nombre, string apellido)
        {
            List<PatientBE> wPatientsBEList = new List<PatientBE>();
            List<Patient> wPatients = null;

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                if (String.IsNullOrEmpty(nombre) || String.IsNullOrEmpty(apellido))
                    wPatients = dc.Patients.ToList<Patient>();
                else
                {
                    var Patients = from p in dc.Patients
                                    where
                                        (String.IsNullOrEmpty(nombre) || p.Persona.Nombre.Contains(nombre)
                                        || (String.IsNullOrEmpty(apellido) || p.Persona.Apellido.Contains(apellido)))
                                    select p;

                    wPatients = Patients.ToList<Patient>();
                }

                PatientBE wPatientBE = null;

                foreach (Patient p in wPatients)
                {
                    wPatientBE = (PatientBE)p;
                    wPatientBE.IdPersona = p.Persona.IdPersona;
                    wPatientBE.Persona = (PersonaBE)p.Persona;
                    wPatientsBEList.Add(wPatientBE);
                }


            }
            return wPatientsBEList;
        }

        public static PatientBE GetById(int patientId)
        {
            PatientBE wPatient = null;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                Patient Patient = dc.Patients.Where(p => p.PatientId.Equals(patientId)).FirstOrDefault<Patient>();

                wPatient = (PatientBE)Patient;
                wPatient.Persona = (PersonaBE)Patient.Persona;

            }
            return wPatient;
        }
        public static PatientBE GetByDoc(int nroDocumento)
        {
            PatientBE wPatient = null;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                Patient Patient = dc.Patients.Where(p => p.Persona.NroDocumento.Equals(nroDocumento)).FirstOrDefault<Patient>();

                wPatient = (PatientBE)Patient;
                wPatient.Persona = (PersonaBE)Patient.Persona;

            }
            return wPatient;
        }

        /// <summary>
        /// Crea Patient y persona
        /// </summary>
        /// <param name="PatientBE"></param>
        public static void Create(PatientBE PatientBE)
        {

            PersonasDAC.Create(PatientBE.Persona);

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                Patient p = new Patient();
                p.IdPersona = PatientBE.Persona.IdPersona;
                p.FechaAlta = PatientBE.Persona.FechaAlta;
                p.LastAccessTime = p.FechaAlta;
                p.LastAccessUserId = PatientBE.LastAccessUserId;

                dc.Patients.AddObject(p);
                dc.SaveChanges();
                PatientBE.PatientId = p.PatientId;
                PatientBE.IdPersona = p.IdPersona;
            }
          
        }


 

        /// <summary>
        /// crea un Patient asociandolo a una persona existente
        /// </summary>
        /// <param name="PatientBE"></param>
        public static void Asociar(PatientBE PatientBE)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                Patient p = new Patient();
                p.IdPersona = PatientBE.Persona.IdPersona;
                p.FechaAlta = System.DateTime.Now;
                p.LastAccessTime = p.FechaAlta;
                p.LastAccessUserId = PatientBE.LastAccessUserId;

                dc.Patients.AddObject(p);
                dc.SaveChanges();
                PatientBE.PatientId = p.PatientId;
            }
            
        }


        public static void Update(PatientBE Patient)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                Patient wPatient = dc.Patients.Where(p => p.PatientId.Equals(Patient.PatientId)).FirstOrDefault<Patient>();

                wPatient.Persona.Apellido = Patient.Persona.Apellido;
                wPatient.Persona.Nombre = Patient.Persona.Nombre;
                wPatient.Persona.NroDocumento = Patient.Persona.NroDocumento;
                wPatient.Persona.TipoDocumento = Patient.Persona.TipoDocumento;
                wPatient.Persona.IdEstadocivil = Patient.Persona.IdEstadocivil;
                wPatient.Persona.FechaNacimiento = Patient.Persona.FechaNacimiento;
                wPatient.Persona.Sexo = Patient.Persona.Sexo;

                wPatient.Persona.Calle = Patient.Persona.Calle;
                wPatient.Persona.CalleNumero = Patient.Persona.CalleNumero;
                wPatient.Persona.Piso = Patient.Persona.Piso;
                wPatient.Persona.IdPais = Patient.Persona.IdPais;
                wPatient.Persona.IdProvincia = Patient.Persona.IdProvincia;
                wPatient.Persona.IdLocalidad = Patient.Persona.IdLocalidad;
                wPatient.Persona.Barrio = Patient.Persona.Barrio;
                wPatient.Persona.mail = Patient.Persona.mail;
                wPatient.Persona.Telefono1 = Patient.Persona.Telefono1;
                wPatient.Persona.Telefono2 = Patient.Persona.Telefono2;
                wPatient.Persona.Foto = Patient.Persona.Foto;

                wPatient.LastAccessTime = System.DateTime.Now;
                wPatient.LastAccessUserId = Patient.LastAccessUserId;
                wPatient.Persona.LastAccessTime = wPatient.LastAccessTime.Value;
                wPatient.Persona.LastAccessUserId = Patient.Persona.LastAccessUserId;
                dc.SaveChanges();
            }
        }

        public static bool Persona_EstaAsociada(String nroDocumento)
        {

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                return dc.Patients.Any<Patient>(p => p.Persona.NroDocumento.Equals(nroDocumento));
            }
        }

        

     



    }
}

