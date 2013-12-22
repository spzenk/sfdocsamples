using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Transactions;
using System.Data.Common;
using Health.Entities;
using Health.Back.BE;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Health.BE;
using Health.BE.Enums;
namespace Health.Back
{
    public class MedicalEventDAC
    {
        public static int CreateMedicalEvent(MedicalEventBE medicalEvent, Guid createdUserId)
        {

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                MedicalEvent medicalEvent_db = new MedicalEvent();


                medicalEvent_db.MedicalEventId_Parent = medicalEvent.MedicalEventId_Parent;
                medicalEvent_db.ProfesionalId = medicalEvent.ProfesionalId;

                medicalEvent_db.PatientId = medicalEvent.PatientId;

                medicalEvent_db.IdEspesialidad = medicalEvent.IdEspesialidad;
                medicalEvent_db.IdTipoConsulta = medicalEvent.IdTipoConsulta;

                medicalEvent_db.Motivo = medicalEvent.Motivo;
   
                medicalEvent_db.MetodoComplementario = medicalEvent.MetodoComplementario;
                medicalEvent_db.Evolucion = medicalEvent.Evolucion;
                medicalEvent_db.AppointmentId = medicalEvent.AppointmentId;

                medicalEvent_db.CreatedDate = System.DateTime.Now;
                medicalEvent_db.CreatedUserId = createdUserId;
                medicalEvent_db.HealthInstitutionId = medicalEvent.HealthInstitutionId;

                dc.MedicalEvents.AddObject(medicalEvent_db);
                dc.SaveChanges();
                return medicalEvent_db.MedicalEventId;
            }
        }
        public static void UpdateMedicalEvent(MedicalEventBE medicalEvent, Guid createdUserId)
        {

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                MedicalEvent medicalEvent_db = dc.MedicalEvents.Where(p => p.MedicalEventId.Equals(medicalEvent.MedicalEventId)).FirstOrDefault<MedicalEvent>();


                medicalEvent_db.MedicalEventId_Parent = medicalEvent.MedicalEventId_Parent;
                medicalEvent_db.ProfesionalId = medicalEvent.ProfesionalId;

                medicalEvent_db.PatientId = medicalEvent.PatientId;

                medicalEvent_db.IdEspesialidad = medicalEvent.IdEspesialidad;
                medicalEvent_db.IdTipoConsulta = medicalEvent.IdTipoConsulta;

                medicalEvent_db.Motivo = medicalEvent.Motivo;
      
                medicalEvent_db.Evolucion = medicalEvent.Evolucion;

   
                medicalEvent_db.MetodoComplementario = medicalEvent.MetodoComplementario;
                medicalEvent_db.AppointmentId = medicalEvent.AppointmentId;
                medicalEvent_db.HealthInstitutionId = medicalEvent.HealthInstitutionId;
                //medicalEvent_db.CreatedDate = System.DateTime.Now;
                //medicalEvent_db.CreatedUserId = createdUserId;
                dc.SaveChanges();

            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        public static MedicalEvent_ViewList RetrivePatientEvent(int patientId)
        {
            MedicalEvent_ViewList list = new MedicalEvent_ViewList();
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                var list_db = dc.MedicalEvent_View.Where(p => p.PatientId.Equals(patientId));

                foreach (MedicalEvent_View item_db in list_db)
                {
                    list.Add((MedicalEvent_ViewBE)item_db);
                }

            }
            return list;
        }


        /// <summary>
        /// Obtiene Medical event y medicamentos con full detalles.
        /// Utiliza SP: MedicalEvent_g
        /// </summary>
        /// <param name="pMedicalEventId"></param>
        /// <returns></returns>
        public static MedicalEventBE GetEvent(int pMedicalEventId)
        {

            Database wDatabase = null;
            DbCommand wCmd = null;


            MedicalEventBE wMedicalEven = null;

            wDatabase = DatabaseFactory.CreateDatabase(Common.CnnStringName);
            wCmd = wDatabase.GetStoredProcCommand("MedicalEvent_g");
            wDatabase.AddInParameter(wCmd, "MedicalEventId", System.Data.DbType.Int32, pMedicalEventId);

            IDataReader reader = wDatabase.ExecuteReader(wCmd);

           

            #region Fill MedicalEven
            while (reader.Read())
            {
                wMedicalEven = new MedicalEventBE();

                if (reader["CreatedDate"] != DBNull.Value)
                    wMedicalEven.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                if (reader["IdTipoConsulta"] != DBNull.Value)
                    wMedicalEven.IdTipoConsulta = Convert.ToInt32(reader["IdTipoConsulta"]);
                wMedicalEven.Motivo = reader["Motivo"].ToString().Trim();
                wMedicalEven.NombreEspesialidad = reader["NombreEspesialidad"].ToString().Trim();
                wMedicalEven.Evolucion = reader["Evolucion"].ToString().Trim();
                
                wMedicalEven.NombreApellidoProfecional = reader["Profesional"].ToString();

                wMedicalEven.InstitucionRazonSocial = reader["RazonSocial"].ToString();
                if (reader["HealthInstitutionId"] != DBNull.Value)
                    wMedicalEven.HealthInstitutionId = new Guid(reader["HealthInstitutionId"].ToString());
            }
            #endregion

            #region Fill PatientMedicament View
            reader.NextResult();
            wMedicalEven.PatientMedicaments = new PatientMedicament_ViewList();
            PatientMedicament_ViewBE wPatientMedicament_View = null;
            while (reader.Read())
            {
                wPatientMedicament_View = new PatientMedicament_ViewBE();
                wPatientMedicament_View.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                if (reader["DaysCount"] != DBNull.Value)
                    wPatientMedicament_View.DaysCount = Convert.ToInt16(reader["DaysCount"]);

                wPatientMedicament_View.Dosis = reader["Dosis"].ToString().Trim();
                wPatientMedicament_View.Enabled = Convert.ToBoolean(reader["Enabled"]);
                wPatientMedicament_View.Status = Convert.ToInt32(reader["Status"]);
                wPatientMedicament_View.MedicamentName = reader["MedicamentName"].ToString();
                wPatientMedicament_View.MedicamentPresentation = reader["MedicamentPresentation"].ToString();
                wPatientMedicament_View.NombreProfesional = reader["NombreProfesional"].ToString();
                if (reader["Periodicity_hours"] != DBNull.Value)
                    wPatientMedicament_View.Periodicity_hours = Convert.ToInt16(reader["Periodicity_hours"]);

                wPatientMedicament_View.NombreProfesional = reader["NombreProfesional"].ToString().Trim();
                wPatientMedicament_View.ApellidoProfesional = reader["ApellidoProfesional"].ToString().Trim();

                wMedicalEven.PatientMedicaments.Add(wPatientMedicament_View);
            }



            #endregion

            #region Fill Details
            reader.NextResult();

            wMedicalEven.MedicalEventDetail_ViewList = new MedicalEventDetail_ViewList();
            MedicalEventDetail_ViewBE wMedicalEventDetail_ViewBE = null;
            while (reader.Read())
            {
                wMedicalEventDetail_ViewBE = new MedicalEventDetail_ViewBE();
                wMedicalEventDetail_ViewBE.Id = Convert.ToInt32(reader["Id"]);
                wMedicalEventDetail_ViewBE.Code = reader["Code"].ToString().Trim();
                wMedicalEventDetail_ViewBE.DetailType = Convert.ToInt16(reader["DetailType"]);
                if (reader["RelevanceType"] != DBNull.Value)
                {
                    wMedicalEventDetail_ViewBE.RelevanceTypeName = reader["RelevanceTypeName"].ToString().Trim();
                    wMedicalEventDetail_ViewBE.RelevanceType = Convert.ToInt16(reader["RelevanceType"]);
                }
                wMedicalEventDetail_ViewBE.Desc = reader["Desc"].ToString();
                wMedicalEventDetail_ViewBE.Observations = reader["Observations"].ToString();
                
                wMedicalEven.MedicalEventDetail_ViewList.Add(wMedicalEventDetail_ViewBE);
            }

            #endregion


            reader.Dispose();

            return wMedicalEven;

        }


        public static void Create_MedicalEventAlert(int medicalEventId, string description, AlertTypeEnum alertType, int referenceId)
        {

            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                MedicalEventAlert wMedicalEventAlert = new MedicalEventAlert();

                wMedicalEventAlert.CreationDate = DateTime.Now;
                
                wMedicalEventAlert.Enabled = true;
                wMedicalEventAlert.ReferenceId = referenceId;
                wMedicalEventAlert.MedicalEventId = medicalEventId;
                wMedicalEventAlert.Description = description;
                wMedicalEventAlert.AlertType = (int)alertType;
                dc.MedicalEventAlerts.AddObject(wMedicalEventAlert);
                dc.SaveChanges();
            }
        }

        //public static void Update_MedicalEventAlert(int alertId, int medicalEventId_Update, string description, bool enabled)
        //{

        //    using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
        //    {

        //        var wMedicalEventAlert = dc.MedicalEventAlerts.Where(p => p.AlertId.Equals(alertId)).FirstOrDefault();
        //        if (wMedicalEventAlert != null)
        //        {
                    
        //            wMedicalEventAlert.Description = description;
        //            wMedicalEventAlert.Enabled = enabled;

        //            dc.SaveChanges();
        //        }
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="startDate"></param>
        /// <param name="retriveHistory"></param>
        /// <returns></returns>
        public static MedicalEventAlert_ViewList Retrive_MedicalEventAlerts(int patientId, DateTime? startDate, bool retriveHistory)
        {
            Database wDatabase = null;
            DbCommand wCmd = null;
            MedicalEventAlert_View wMedicalEven = null;


            MedicalEventAlert_ViewList list = new MedicalEventAlert_ViewList();
            ///TODO: Mejorar este sp para q traifga segun el tipo de alerta
            wDatabase = DatabaseFactory.CreateDatabase(Common.CnnStringName);
            wCmd = wDatabase.GetStoredProcCommand("MedicalEventAlerts_s_params");
            wDatabase.AddInParameter(wCmd, "@PatientId", System.Data.DbType.Int32, patientId);
            if (startDate.HasValue)
                wDatabase.AddInParameter(wCmd, "@StartDate", System.Data.DbType.DateTime, startDate);
            //Si retriveHistory== true  CheckEnabled deberia ser =false por lo tanto el NEGADO
            wDatabase.AddInParameter(wCmd, "@CheckEnabled", System.Data.DbType.Boolean, !retriveHistory);

            //wDatabase.AddInParameter(wCmd, "@AlertType", System.Data.DbType.Int32, 1);
            
            IDataReader reader = wDatabase.ExecuteReader(wCmd);

            #region Fill IDataReader with DIAGNOSIS
            while (reader.Read())
            {
              
                wMedicalEven = new MedicalEventAlert_View();

                if (reader["AlertId"] != DBNull.Value)
                    wMedicalEven.AlertType = Convert.ToInt32(reader["AlertType"]);

                wMedicalEven.AlertId = Convert.ToInt32(reader["AlertId"]);

                wMedicalEven.ReferenceId = Convert.ToInt32(reader["ReferenceId"]);

                if (reader["MedicalEventId"] != DBNull.Value)
                    wMedicalEven.MedicalEventId = Convert.ToInt32(reader["MedicalEventId"]);
               if (reader["CreationDate"] != DBNull.Value)
                    wMedicalEven.CreationDate = Convert.ToDateTime(reader["CreationDate"]);

                wMedicalEven.Profesional = reader["Profesional"].ToString();
         
                wMedicalEven.InstitucionRazonSocial = reader["RazonSocial"].ToString();
                if (reader["HealthInstitutionId"] != DBNull.Value)
                    wMedicalEven.HealthInstitutionId = new Guid(reader["HealthInstitutionId"].ToString());


                wMedicalEven.Description = reader["Description"].ToString();
                list.Add(wMedicalEven);
            }

            //reader.NextResult();

            //wMedicalEven.PatientMedicaments = new PatientMedicament_ViewList();
            //PatientMedicament_ViewBE wPatientMedicament_View = null;
            //while (reader.Read())
            //{

            //    if (reader["AlertId"] != DBNull.Value)
            //        wMedicalEven.AlertId = Convert.ToInt32(reader["AlertId"]);
            //    if (reader["MedicalEventIdCreation"] != DBNull.Value)
            //        wMedicalEven.MedicalEventIdCreation = Convert.ToInt32(reader["MedicalEventIdCreation"]);

            //    if (reader["CreatedDate"] != DBNull.Value)
            //        wMedicalEven.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
            //    wMedicalEven.NombreApellidoProfecional = reader["Profesional"].ToString();

            //    wMedicalEven.InstitucionRazonSocial = reader["RazonSocial"].ToString();
            //    if (reader["HealthInstitutionId"] != DBNull.Value)
            //        wMedicalEven.HealthInstitutionId = new Guid(reader["HealthInstitutionId"].ToString());

            //    wMedicalEven.Diagnosis = reader["Diagnosis"].ToString();
            //    if (reader["CEI10_Code"] != DBNull.Value)
            //        wMedicalEven.CEI10_Code = reader["CEI10_Code"].ToString().Trim();

            //    wMedicalEven.PatientMedicaments.Add(wPatientMedicament_View);
            //}
            #endregion

            reader.Dispose();

            return list;
        }





        public static void Insert_MedicalEventDetail(MedicalEventDetailBE medicalEventDetail, Guid guid)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {

                MedicalEventDetail medicalEventDetail_db = new MedicalEventDetail();

                medicalEventDetail_db.Code = medicalEventDetail.Code;
                medicalEventDetail_db.Description = medicalEventDetail.Description;
                medicalEventDetail_db.MedicalEventId = medicalEventDetail.MedicalEventId;
                medicalEventDetail_db.DetailType = medicalEventDetail.DetailType;
                medicalEventDetail_db.RelevanceType = medicalEventDetail.RelevanceType;
                medicalEventDetail_db.ActiveRelevance = medicalEventDetail.ActiveRelevance;
                medicalEventDetail_db.Observations = medicalEventDetail.Observations;

                dc.MedicalEventDetails.AddObject(medicalEventDetail_db);
                dc.SaveChanges();
            }

            
        }

        public static void Update_MedicalEventDetail(MedicalEventDetailBE medicalEventDetail, Guid guid)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                MedicalEventDetail medicalEventDetail_db = dc.MedicalEventDetails.Where(p => p.Id.Equals(medicalEventDetail.Id)).FirstOrDefault<MedicalEventDetail>();
                medicalEventDetail_db.Code = medicalEventDetail.Code;
                medicalEventDetail_db.Description = medicalEventDetail.Description;
                medicalEventDetail_db.MedicalEventId = medicalEventDetail.MedicalEventId;
                dc.SaveChanges();
            }
        }

        public static void Remove_MedicalEventDetail(int pMedicalEventDetailsId)
        {
            using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
            {
                MedicalEventDetail medicalEventDetail_db = dc.MedicalEventDetails.Where(p => p.Id.Equals(pMedicalEventDetailsId)).FirstOrDefault<MedicalEventDetail>();

                dc.MedicalEventDetails.DeleteObject(medicalEventDetail_db);
                dc.SaveChanges();
            }
        }


        /// <summary>
        /// Retorna MedicalEventDetail_ViewList del propieo evento 
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="medicalEventId"></param>
        /// <returns></returns>
        public static MedicalEventDetail_ViewList Retrive_MedicalEventDetail_ViewList(int medicalEventId)
        {
            MedicalEventDetail_ViewList list = new MedicalEventDetail_ViewList();
            try
            {

                using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
                {
                        var list_db = dc.MedicalEventDetail_View.Where(p =>p.MedicalEventId.Equals(medicalEventId));

                        foreach (MedicalEventDetail_View item_db in list_db)
                        {
                            list.Add((MedicalEventDetail_ViewBE)item_db);
                        }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        /// <summary>
        /// Retorna MedicalEventDetail_ViewList del propieo evento y de eventos anteriores que sean relevante y esten con relevancia activa
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="medicalEventId"></param>
        /// <returns></returns>
        public static MedicalEventDetail_ViewList Retrive_MedicalEventDetail_ViewList_Patinet(int patientId)
        {
            MedicalEventDetail_ViewList list = new MedicalEventDetail_ViewList();
            try
            {

                using (Health.Back.BE.HealthEntities dc = new Health.Back.BE.HealthEntities(Common.CnnString_Entities))
                {
                    var details_from_others_Events = dc.MedicalEventDetail_View.Where(p =>
                        p.PatientId.Equals(patientId) &&
                      
                        p.RelevanceType.HasValue &&
                        p.ActiveRelevance.Value.Equals(true));

                  

                    foreach (MedicalEventDetail_View item_db in details_from_others_Events)
                    {
                        list.Add((MedicalEventDetail_ViewBE)item_db);
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
    }
}

