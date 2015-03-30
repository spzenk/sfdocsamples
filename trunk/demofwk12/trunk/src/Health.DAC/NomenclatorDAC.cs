using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Health.Back.BE;
using Health.Entities;
using Health.BE;
using Health.BE.Enums;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Health.Back
{
    public class NomenclatorDAC
    {
        public static void Process_PMO_AnalisisClinicos()
        {


            using (Health.Entities.HealthLinQDataContext dc = new Health.Entities.HealthLinQDataContext(Common.CnnString))
            {
                string auxiliar = string.Empty;
                var list = dc.Nomenclators.Where(p => p.PMOType.Equals((int)PMOEnum.Diagnostico_Analisis_Clinico)).OrderBy(p => p.Id);
                foreach (Nomenclator PMO in list)
                {


                    if (!string.IsNullOrEmpty(PMO.Code.Trim()))
                    {
                        auxiliar = PMO.Code.Trim();
                        PMO.Code = auxiliar;
                    }

                    PMO.Code = auxiliar;
                }
                dc.SubmitChanges();
            }


        }


        public static void Process_PMO(List<Nomenclator> list, int pmoType)
        {
            Nomenclator wNomenclator;

            using (Health.Entities.HealthLinQDataContext dc = new Health.Entities.HealthLinQDataContext(Common.CnnString))
            {
                string[] auxiliar;
                foreach (Nomenclator temp in list.OrderBy(p => p.Id))
                {
                    wNomenclator = new Nomenclator();

                    auxiliar = temp.Code.Split('.');

                    if (auxiliar.Length == 3)
                    {
                        wNomenclator.Code = temp.Code.Trim();
                        wNomenclator.ParentCode = string.Concat(auxiliar[0], '.', auxiliar[1]);
                        wNomenclator.HasChilds = false;
                    }

                    if (auxiliar.Length == 2)
                    {
                        wNomenclator.Code = temp.Code.Trim();
                        wNomenclator.ParentCode = auxiliar[0].ToString();
                        wNomenclator.HasChilds = true;
                    }


                    if (auxiliar.Length == 1)
                    {
                        wNomenclator.Code = temp.Code.Trim();
                        wNomenclator.ParentCode = string.Empty;
                        wNomenclator.HasChilds = true;
                    }



                    wNomenclator.Description = temp.Description.Trim();
                    wNomenclator.PMOType = pmoType;
                    //wNomenclator.Id = temp.Id;

                    dc.Nomenclators.InsertOnSubmit(wNomenclator);
                }
                dc.SubmitChanges();
            }
        }


        public static void Process_PMO_Odont()
        {


            using (Health.Entities.HealthLinQDataContext dc = new Health.Entities.HealthLinQDataContext(Common.CnnString))
            {
                string[] auxiliar;
                var list = dc.Nomenclators.Where(p => p.PMOType.Equals((int)PMOEnum.Odontológicas)).OrderBy(p => p.Id);
                foreach (Nomenclator PMO in list)
                {
                    auxiliar = PMO.Code.Split('.');

                    if (auxiliar.Length == 3)
                    {
                        //PMO.Code = temp.Code.Trim();
                        PMO.ParentCode = string.Concat(auxiliar[0], '.', auxiliar[1]);
                        PMO.HasChilds = false;
                    }

                    if (auxiliar.Length == 2)
                    {
                        //PMO.Code = temp.Code.Trim();
                        PMO.ParentCode = auxiliar[0].ToString().Trim();
                        PMO.HasChilds = true;
                    }


                    if (auxiliar.Length == 1)
                    {
                        //PMO.Code = temp.Code.Trim();
                        PMO.ParentCode = string.Empty;
                        PMO.HasChilds = true;
                    }

                }
                dc.SubmitChanges();
            }
        }





        public static List<Nomenclator> RetriveByType(int type)
        {

            using (Health.Entities.HealthLinQDataContext dc = new Health.Entities.HealthLinQDataContext(Common.CnnString))
            {
                return dc.Nomenclators.Where(p => p.PMOType.Equals(type)).ToList<Nomenclator>();
            }

        }
        public static List<Nomenclator> RetriveAll()
        {

            using (Health.Entities.HealthLinQDataContext dc = new Health.Entities.HealthLinQDataContext(Common.CnnString))
            {
                return dc.Nomenclators.OrderBy(p => p.Id).ToList<Nomenclator>();
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        public static MedicalEventPMO_Diag_List Search_CEI10(int patientId)
        {
            Database wDatabase = null;
            DbCommand wCmd = null;
            MedicalEventPMO_Diag_List list = new MedicalEventPMO_Diag_List();

            MedicalEventPMO_Diag_View wMedicalEven = null;

            wDatabase = DatabaseFactory.CreateDatabase(Common.CnnStringName);
            wCmd = wDatabase.GetStoredProcCommand("MedicalEvent_CEI10_s");
            wDatabase.AddInParameter(wCmd, "PatientId", System.Data.DbType.Int32, patientId);

            IDataReader reader = wDatabase.ExecuteReader(wCmd);

            #region Fill IDataReader
            while (reader.Read())
            {
                wMedicalEven = new MedicalEventPMO_Diag_View();

                wMedicalEven.MedicalEventId = Convert.ToInt32(reader["MedicalEventId"]);
                wMedicalEven.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                wMedicalEven.Code = reader["CEI10_Code"].ToString().Trim();
                wMedicalEven.Value = reader["Diagnosis"].ToString();

                wMedicalEven.Motivo = reader["Motivo"].ToString().Trim();
                if (reader["IsDefinitive"] != DBNull.Value)
                    wMedicalEven.IsDefinitive = Convert.ToBoolean(reader["IsDefinitive"]);
                wMedicalEven.IsDefinitive = Convert.ToBoolean(reader["IsDefinitive"]);
                wMedicalEven.Profesional = reader["Profesional"].ToString();

                wMedicalEven.RazonSocial = reader["RazonSocial"].ToString();
                if (reader["HealthInstitutionId"] != DBNull.Value)
                    wMedicalEven.HealthInstitutionId = new Guid(reader["HealthInstitutionId"].ToString());
                list.Add(wMedicalEven);
            }
            #endregion
            return list;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        public static MedicalEventPMO_Diag_List Search_PMO_MetodoComplementario(int patientId)
        {
            Database wDatabase = null;
            DbCommand wCmd = null;
            MedicalEventPMO_Diag_List list = new MedicalEventPMO_Diag_List ();

            MedicalEventPMO_Diag_View wMedicalEven = null;

            wDatabase = DatabaseFactory.CreateDatabase(Common.CnnStringName);
            wCmd = wDatabase.GetStoredProcCommand("MedicalEvent_PMO_MetodoComplementario_s");
            wDatabase.AddInParameter(wCmd, "PatientId", System.Data.DbType.Int32, patientId);

            IDataReader reader = wDatabase.ExecuteReader(wCmd);

            #region Fill IDataReader
            while (reader.Read())
            {
                wMedicalEven = new MedicalEventPMO_Diag_View();

                wMedicalEven.MedicalEventId = Convert.ToInt32(reader["MedicalEventId"]);
                wMedicalEven.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                wMedicalEven.Code = reader["Code"].ToString().Trim();
                wMedicalEven.Value = reader["Value"].ToString();

                wMedicalEven.Motivo = reader["Motivo"].ToString().Trim();
                if (reader["IsDefinitive"] != DBNull.Value)
                    wMedicalEven.IsDefinitive = Convert.ToBoolean(reader["IsDefinitive"]);
                wMedicalEven.IsDefinitive = Convert.ToBoolean(reader["IsDefinitive"]);
                wMedicalEven.Profesional = reader["Profesional"].ToString();

                wMedicalEven.RazonSocial = reader["RazonSocial"].ToString();
                if (reader["HealthInstitutionId"] != DBNull.Value)
                    wMedicalEven.HealthInstitutionId = new Guid(reader["HealthInstitutionId"].ToString());
                list.Add(wMedicalEven);
            }
            #endregion
            return list;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        public static MedicalEventPMO_Diag_List Search_PMO_Quirurgico(int patientId)
        {
            Database wDatabase = null;
            DbCommand wCmd = null;
            MedicalEventPMO_Diag_List list = new MedicalEventPMO_Diag_List();

            MedicalEventPMO_Diag_View wMedicalEven = null;

            wDatabase = DatabaseFactory.CreateDatabase(Common.CnnStringName);
            wCmd = wDatabase.GetStoredProcCommand("MedicalEvent_PMO_Quirurgico_s");
            wDatabase.AddInParameter(wCmd, "PatientId", System.Data.DbType.Int32, patientId);

            IDataReader reader = wDatabase.ExecuteReader(wCmd);

            #region Fill IDataReader
            while (reader.Read())
            {
                wMedicalEven = new MedicalEventPMO_Diag_View();

                wMedicalEven.MedicalEventId = Convert.ToInt32(reader["MedicalEventId"]);
                wMedicalEven.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
                wMedicalEven.Code = reader["Code"].ToString().Trim();
                wMedicalEven.Value = reader["Value"].ToString();

                wMedicalEven.Motivo = reader["Motivo"].ToString().Trim();
                if (reader["IsDefinitive"] != DBNull.Value)
                    wMedicalEven.IsDefinitive = Convert.ToBoolean(reader["IsDefinitive"]);
                wMedicalEven.IsDefinitive = Convert.ToBoolean(reader["IsDefinitive"]);
                wMedicalEven.Profesional = reader["Profesional"].ToString();

                wMedicalEven.RazonSocial = reader["RazonSocial"].ToString();
                if (reader["HealthInstitutionId"] != DBNull.Value)
                    wMedicalEven.HealthInstitutionId = new Guid(reader["HealthInstitutionId"].ToString());
                list.Add(wMedicalEven);
            }
            #endregion
            return list;
        }
    }
}
