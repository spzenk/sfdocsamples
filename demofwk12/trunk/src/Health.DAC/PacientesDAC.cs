using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Transactions;
using System.Data.Common;
using Health.Entities;
using Health.Back.BE;
using Health.BE;
using Health.BE.Enums;


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
            Create_PlanVacunacion(PatientBE);
        }

        static void Create_PlanVacunacion(PatientBE PatientBE)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                PlanVacunacion plan;

                foreach (Vacuna v in dc.Vacunas.ToArray())
                {
                    //{"The INSERT statement conflicted with the FOREIGN KEY constraint \"FK_PlanVacunación_Vacunas\". 
                    //The conflict occurred in database \"Health\", table \"dbo.Vacunas\", column 'IdVacuna'.
                    plan = new PlanVacunacion();
                    plan.PatientId = PatientBE.PatientId;
                    plan.Codigo = v.Codigo;
                    plan.FechaPlaneada = PatientBE.Persona.FechaNacimiento.AddDays(Convert.ToInt16(v.Cantidad));
                    //plan.ProfesionalColocadorUserID = PatientBE.LastAccessUserId;
                    dc.PlanVacunacions.AddObject(plan);
                }
                dc.SaveChanges();
            }
        }
        static void Update_PlanVacunacion(PlanVacunacion_FullViewList planList)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                PlanVacunacion plan;
                foreach (PlanVacunacion_FullViewBE planVacunacionBE in planList)
                {
                    plan = dc.PlanVacunacions.Where(p => p.PatientId.Equals(planVacunacionBE.PatientId) && p.Codigo.Equals(planVacunacionBE.Codigo)).FirstOrDefault<PlanVacunacion>();

                    //plan.FechaPlaneada = planVacunacionBE.FechaPlaneada;
                    plan.FechaColocacion = planVacunacionBE.FechaColocacion;
                    plan.ProfesionalColocadorUserID = planVacunacionBE.ProfesionalColocadorUserID;
                    plan.NombreProfesionalQueColoco = planVacunacionBE.NombreProfesionalQueColoco;
                    plan.Lote = planVacunacionBE.NombreProfesionalQueColoco;
                    plan.FechaPlaneada_Alterada = planVacunacionBE.FechaPlaneada_Alterada;

                }
                dc.SaveChanges();
            }
        }

       
        public static void Update_FechaNAcimiento_PlanVacunacion(int idPatient, DateTime fechaActual, DateTime fechaNueva)
        {
            System.TimeSpan t = fechaNueva - fechaActual;

            using (Health.Back.BE.HealthEntities dc =
                new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var planList = dc.PlanVacunacions.Where(p => p.PatientId.Equals(idPatient));
                foreach (PlanVacunacion plan in planList)
                {
                    plan.FechaPlaneada = plan.FechaPlaneada + t;
                }
                dc.SaveChanges();
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
            Create_PlanVacunacion(PatientBE);
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

                wPatient.Persona.Street = Patient.Persona.Street;
                wPatient.Persona.StreetNumber = Patient.Persona.StreetNumber;
                wPatient.Persona.Floor = Patient.Persona.Floor;
                wPatient.Persona.CountryId = Patient.Persona.CountryId;
                wPatient.Persona.ProvinceId = Patient.Persona.ProvinceId;
                wPatient.Persona.CityId = Patient.Persona.CityId;
                wPatient.Persona.Neighborhood = Patient.Persona.Neighborhood;
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

        public static PlanVacunacion_FullViewList GetPlanVacunacion(int patientId)
        {
            PlanVacunacion_FullViewList list = new PlanVacunacion_FullViewList();
            PlanVacunacion_FullViewBE planVacunacion_FullViewBE;
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {


                var list_bd = dc.PlanVacunacion_FullView.Where(p => p.PatientId.Equals(patientId));

                foreach (PlanVacunacion_FullView pv in dc.PlanVacunacion_FullView.Where(p => p.PatientId.Equals(patientId)))
                {
                    planVacunacion_FullViewBE = new PlanVacunacion_FullViewBE();
                    planVacunacion_FullViewBE = (PlanVacunacion_FullViewBE)pv;
                    list.Add(planVacunacion_FullViewBE);
                }


            }
            return list;
        }

        public void RetrivePatient()
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var x = from p in dc.Patients
                        from mut in dc.MutualPorPacientes
                        where
                            p.PatientId.Equals(2)
                            && p.PatientId == mut.IdPaciente
                        select new { Nombrecito = p.PatientId, otro = mut.Mutual.Nombre };



                var y = from p in dc.Patients
                        where
                            p.PatientId.Equals(2)
                        select new { p.MutualPorPacientes };

                dc.Patients.Where<Patient>(p=> p.Persona.Nombre.StartsWith("ri"));

               // System.IO.DirectoryInfo d = new System.IO.DirectoryInfo();

                
                
            }
        }
        

        public static void UpdatePlanVacunacion(PlanVacunacion_FullViewList planVacunacion_FullViewList, Guid lastAccessUserId)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                foreach (PlanVacunacion_FullViewBE pv in planVacunacion_FullViewList)
                {
                    PlanVacunacion plan = dc.PlanVacunacions.Where(p => p.PatientId.Equals(pv.PatientId) && p.Codigo.Equals(pv.Codigo)).FirstOrDefault<PlanVacunacion>();
                    plan.FechaColocacion = pv.FechaColocacion;
                    plan.FechaPlaneada = pv.FechaPlaneada;
                    plan.NombreProfesionalQueColoco = pv.NombreProfesionalQueColoco;
                    plan.Lote = pv.Lote;
                    plan.CodigoVacunaSustituta = pv.CodigoVacunaSustituta;
                    plan.FechaPlaneada_Alterada = pv.FechaPlaneada_Alterada;
                }
                dc.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public static PatientAllergyBE GetPatientAllergy(int patientId)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                PatientAllergy patientAllergy_db = dc.PatientAllergies.Where(p => p.PatientId.Equals(patientId)  &&  p.Enabled.Equals(true)).FirstOrDefault<PatientAllergy>();

                if (patientAllergy_db != null)
                    return (PatientAllergyBE)patientAllergy_db;

                return null;
            }
        }

        public static void Create_PatientAllergy_History(PatientAllergyBE patientAllergyBE, Guid lastAccessUserId)
        {
            CreatePatientAllergy(patientAllergyBE, lastAccessUserId);

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                PatientAllergy atientAllergy_new = dc.PatientAllergies.Where(p => p.PatientId.Equals(patientAllergyBE.PatientId)).FirstOrDefault<PatientAllergy>();
                
                atientAllergy_new.Enabled = false;

                atientAllergy_new.LastAccessTime = System.DateTime.Now;
                atientAllergy_new.LastAccessUserId = lastAccessUserId;
                dc.SaveChanges();
            }
        }

        public static void UpdatePatientAllergy(PatientAllergyBE patientAllergyBE, Guid lastAccessUserId)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                PatientAllergy patientAllergy_db = dc.PatientAllergies.Where(p => p.PatientId.Equals(patientAllergyBE.PatientId)).FirstOrDefault<PatientAllergy>();

                patientAllergy_db.AnimalAllergy = patientAllergyBE.AnimalAllergy;
                patientAllergy_db.ChemicalAllergy = patientAllergyBE.ChemicalAllergy;
                patientAllergy_db.FoodAllergy = patientAllergyBE.FoodAllergy;
                patientAllergy_db.InsectAllergy = patientAllergyBE.InsectAllergy;
                patientAllergy_db.MedicamentsAllergy = patientAllergyBE.MedicamentsAllergy;
                patientAllergy_db.MiteAllergy = patientAllergyBE.MiteAllergy;
                patientAllergy_db.PollenAllergy = patientAllergyBE.PollenAllergy;
                patientAllergy_db.SunAllergy = patientAllergyBE.SunAllergy;

                patientAllergy_db.Observation = patientAllergyBE.Observation;
                patientAllergy_db.OtherAllergy = patientAllergyBE.OtherAllergy;

                patientAllergy_db.GeneralDetails = patientAllergyBE.GeneralDetails;
                patientAllergy_db.Enabled = patientAllergyBE.Enabled;
                patientAllergy_db.LastAccessTime = System.DateTime.Now;
                patientAllergy_db.LastAccessUserId = lastAccessUserId;
                dc.SaveChanges();
            }
        }

        public static void CreatePatientAllergy(PatientAllergyBE patientAllergyBE, Guid lastAccessUserId)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                PatientAllergy patientAllergy_db = new PatientAllergy();
                patientAllergy_db.PatientId = patientAllergyBE.PatientId;

                patientAllergy_db.AnimalAllergy = patientAllergyBE.AnimalAllergy;
                patientAllergy_db.ChemicalAllergy = patientAllergyBE.ChemicalAllergy;
                patientAllergy_db.FoodAllergy = patientAllergyBE.FoodAllergy;
                patientAllergy_db.InsectAllergy = patientAllergyBE.InsectAllergy;
                patientAllergy_db.MedicamentsAllergy = patientAllergyBE.MedicamentsAllergy;
                patientAllergy_db.MiteAllergy = patientAllergyBE.MiteAllergy;
                patientAllergy_db.PollenAllergy = patientAllergyBE.PollenAllergy;
                patientAllergy_db.SunAllergy = patientAllergyBE.SunAllergy;

                patientAllergy_db.Observation = patientAllergyBE.Observation;
                patientAllergy_db.OtherAllergy = patientAllergyBE.OtherAllergy;


                patientAllergy_db.GeneralDetails = patientAllergyBE.GeneralDetails;
                patientAllergy_db.MedicalEventId = patientAllergyBE.MedicalEventId;
                patientAllergy_db.Enabled = true;
                patientAllergy_db.LastAccessTime = System.DateTime.Now;
                patientAllergy_db.LastAccessUserId = lastAccessUserId;

                dc.PatientAllergies.AddObject(patientAllergy_db);
                dc.SaveChanges();
            }
        }

        /// <summary>
        /// Retorna medicamentos que el Patient toma regularmente
        /// La medicacion debe estar no suspendida y vigente
        /// Tambien retorna medicacion actual temporal (Esto falta desarrollar)
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public static PatientMedicament_ViewList RetrivePatientMedicaments(int patientId)
        {
            PatientMedicament_ViewList list = new PatientMedicament_ViewList();
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var list_db = dc.PatientMedicament_View.Where(
                    p => p.PatientId.Equals(patientId)
                    &&  !p.Status.Equals((int)MedicamentStatus.Suspendido)
                    && !p.Status.Equals((int)MedicamentStatus.Finalizado)
                    && !p.Status.Equals((int)MedicamentStatus.Deshabilitado)
                    && p.Enabled.Equals(true)
                    );

                foreach (PatientMedicament_View patientMedicament_db in list_db)
                {
                    list.Add((PatientMedicament_ViewBE)patientMedicament_db);
                }

            }
            return list;
        }

        /// <summary>
        /// retorna medicamentos de unevento determinado y
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="medicalEventId"></param>
        /// <returns></returns>
        public static PatientMedicament_ViewList RetrivePatientMedicaments(int patientId, int medicalEventId, bool includePermanets)
        {
            PatientMedicament_ViewList list = new PatientMedicament_ViewList();
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var list_db = dc.PatientMedicament_View.Where(
                    p => p.PatientId.Equals(patientId)
                    && p.MedicalEventId.Equals(medicalEventId)
                    );

                if (includePermanets)
                {
                    var list_Permanent_db = dc.PatientMedicament_View.Where(
                    p => p.PatientId.Equals(patientId)
                         && !p.MedicalEventId.Equals(medicalEventId)
                    && (p.Status.Equals((int)MedicamentStatus.Permanente) && p.Enabled
                    ));

                    foreach (PatientMedicament_View patientMedicament_db in list_Permanent_db)
                    {
                        list.Add((PatientMedicament_ViewBE)patientMedicament_db);
                    }

                }
                foreach (PatientMedicament_View patientMedicament_db in list_db)
                {
                    list.Add((PatientMedicament_ViewBE)patientMedicament_db);
                }

            }
            return list;
        }

         static PatientMedicamentBE GetPatientMedicament(int patientId, int patientMedicamentId)
        {
            
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                PatientMedicament patientMedicament_db = dc.PatientMedicaments.Where(p => p.PatientId.Equals(patientId) && p.PatientMedicamentId.Equals(patientMedicamentId)).FirstOrDefault<PatientMedicament>();

                if (patientMedicament_db != null)
                    return (PatientMedicamentBE)patientMedicament_db;

                return null;
               
                

            }
        
        }
         /// <summary>
         /// Retorna todos los medicamentos asignados al Patient
         /// No importa si fueron suspendidos 
         /// </summary>
         /// <param name="patientId"></param>
         /// <returns></returns>
         public static PatientMedicament_ViewList RetrivePatientMedicamentsAlls(int patientId)
         {
             PatientMedicament_ViewList list = new PatientMedicament_ViewList();
             using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
             {
                 var list_db = dc.PatientMedicament_View.Where(
                     p => p.PatientId.Equals(patientId)                  );

                 foreach (PatientMedicament_View patientMedicament_db in list_db)
                 {
                     list.Add((PatientMedicament_ViewBE)patientMedicament_db);
                 }

             }
             return list;
         }
        public static void AddPatientMedicaments(PatientMedicament_ViewBE patientMedicament_View, Guid createdUserId)
        {
            
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                PatientMedicament patientMedicament_db = new PatientMedicament();

                patientMedicament_db.Status = patientMedicament_View.Status;
                
                patientMedicament_db.MedicalEventId = patientMedicament_View.MedicalEventId;
                patientMedicament_db.PatientId = patientMedicament_View.PatientId;
                if(patientMedicament_View.PatientMedicamentId_Parent >=0)
                    patientMedicament_db.PatientMedicamentId_Parent = patientMedicament_View.PatientMedicamentId_Parent;

                patientMedicament_db.MedicamentName = patientMedicament_View.MedicamentName;
                patientMedicament_db.MedicamentPresentation = patientMedicament_View.MedicamentPresentation;
                patientMedicament_db.Dosis = patientMedicament_View.Dosis;
                patientMedicament_db.Periodicity_hours = patientMedicament_View.Periodicity_hours;
                patientMedicament_db.CreatedDate = System.DateTime.Now;
                patientMedicament_db.CreatedUserId = createdUserId;
                patientMedicament_db.DaysCount = patientMedicament_View.DaysCount;
                patientMedicament_db.Enabled = true;
                dc.PatientMedicaments.AddObject(patientMedicament_db);
                dc.SaveChanges();
            }
            
        }

        /// <summary>
        /// Crea un nuevo nuevo PatientMedicament a partir del que se pasa por parametros para mantener el historial
        /// al nuevo se le establece como parent el pasado por parametros 
        /// patientMedicament.PatientMedicamentId_Parent = patientMedicament.PatientMedicamentId;
        /// </summary>
        /// <param name="patientMedicament"></param>
        /// <param name="createdUserId"></param>
        public static void UpdatePatientMedicaments_histoy(PatientMedicament_ViewBE patientMedicament, Guid createdUserId)
        {
            patientMedicament.PatientMedicamentId_Parent = patientMedicament.PatientMedicamentId;
            
            AddPatientMedicaments(patientMedicament, createdUserId);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPatientMedicamentId"></param>
        public static void RemovePatientMedicaments(int pPatientMedicamentId)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                PatientMedicament patientMedicament_db = dc.PatientMedicaments.Where(p => p.PatientMedicamentId.Equals(pPatientMedicamentId)).FirstOrDefault<PatientMedicament>();

                dc.PatientMedicaments.DeleteObject(patientMedicament_db);
                dc.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientMedicament_View"></param>
        /// <param name="createdUserId"></param>
        public static void UpdatePatientMedicaments(PatientMedicament_ViewBE patientMedicament_View, Guid createdUserId)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                PatientMedicament patientMedicament_db = dc.PatientMedicaments.Where(p => p.PatientMedicamentId.Equals(patientMedicament_View.PatientMedicamentId)).FirstOrDefault<PatientMedicament>();

                if (patientMedicament_db == null) return;

                patientMedicament_db.Status = patientMedicament_View.Status;
                
                patientMedicament_db.MedicalEventId = patientMedicament_View.MedicalEventId;
                patientMedicament_db.PatientId = patientMedicament_View.PatientId;

                patientMedicament_db.PatientMedicamentId_Parent = patientMedicament_View.PatientMedicamentId_Parent;
                patientMedicament_db.MedicamentName = patientMedicament_View.MedicamentName;
                patientMedicament_db.MedicamentPresentation = patientMedicament_View.MedicamentPresentation;
                patientMedicament_db.Dosis = patientMedicament_View.Dosis;
                patientMedicament_db.Periodicity_hours = patientMedicament_View.Periodicity_hours;
                patientMedicament_db.CreatedDate = System.DateTime.Now;
                patientMedicament_db.CreatedUserId = createdUserId;
                patientMedicament_db.Enabled = patientMedicament_View.Enabled;
                patientMedicament_db.DaysCount = patientMedicament_View.DaysCount;

                dc.SaveChanges();
            }
        }


        public static void DisablePatientMedicaments(int patientMedicamentId, Guid guid,MedicamentStatus status)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                PatientMedicament patientMedicament_db = dc.PatientMedicaments.Where(p => p.PatientMedicamentId.Equals(patientMedicamentId)).FirstOrDefault<PatientMedicament>();

                if (patientMedicament_db != null)
                {
                    patientMedicament_db.Status = (int)status;
                    patientMedicament_db.Enabled = false;
                }
                dc.SaveChanges();
            }
        }




        /// <summary>
        /// Por el momento representa Turnos otorgados a un Patient determinado por patientId
        /// </summary>
        /// <param name="startDate">Puede ser nula . Fecha de inicio para la busqueda</param>
        /// <param name="status"></param>
        /// <param name="patientId"></param>
        /// <returns>Patient_Appointments_ViewList, Appointment con ProfesionalAppointment</returns>
        public static Patient_Appointments_ViewList Retrive_Appointment(int patientId, DateTime? startDate, int? status)
        {
            Patient_Appointments_ViewList list = new Patient_Appointments_ViewList();
            if (startDate.HasValue)
                startDate = Fwk.HelperFunctions.DateFunctions.GetStartDateTime(startDate.Value);

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var appointment_db = dc.Patient_Appointments_View.Where<Patient_Appointments_View>(p =>
                    (!startDate.HasValue || p.Start.Value >= startDate.Value)
                    && (!status.HasValue || status.Value.Equals(p.Status.Value))
                    && (p.PatientId.Equals(patientId))
                    );

                foreach (Patient_Appointments_View r in appointment_db)
                {
                    Patient_Appointments_ViewBE wAppoimentBE = (Patient_Appointments_ViewBE)r;
                    wAppoimentBE = (Patient_Appointments_ViewBE)r;
                    list.Add(wAppoimentBE);
                }
            }
            return list;
        }



       

      
    }
}

