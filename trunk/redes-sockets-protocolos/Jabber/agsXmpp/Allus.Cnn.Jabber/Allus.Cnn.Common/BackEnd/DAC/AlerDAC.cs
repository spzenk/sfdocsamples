using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Allus.Cnn.Common.BE;
using Allus.Libs.Common;
using System.Data.SqlClient;

namespace Allus.Cnn.Common.DAC
{
    public class AlertDAC
    {
        public static ColaboratorData GetColaboratorDataByParams(string pUserName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            ColaboratorData wColaboratorData = new ColaboratorData();
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);
                wCmd = wDataBase.GetStoredProcCommand("[User_g_ByParams]");



                wDataBase.AddInParameter(wCmd, "UserName", System.Data.DbType.String, pUserName);


                using (IDataReader reader = wDataBase.ExecuteReader(wCmd))
                {
                    while (reader.Read())
                    {
                        wColaboratorData.Username = pUserName;
                        wColaboratorData.CuentaId = Convert.ToInt32(reader["CuentaId"]);
                        wColaboratorData.SubAreaId = Convert.ToInt32(reader["SubAreaId"]);
                        wColaboratorData.SucursalId = Convert.ToInt32(reader["SucursalId"]);
                        wColaboratorData.CargoId = Convert.ToInt32(reader["CargoId"]);
                        wColaboratorData.UserId = Convert.ToInt32(reader["userId"]);
                        wColaboratorData.Domain = reader["Domain"].ToString();
                        wColaboratorData.IsConsoleAdmin = Convert.ToBoolean(reader["IsConsoleAdmin"]);
                    }
                }

                return wColaboratorData;
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        public static List<ColaboratorData> SearchColaboratorsByParams(ColaboratorData pColaboratorData)
        {
            if (pColaboratorData == null) return null;
            Database wDataBase = null;
            DbCommand wCmd = null;            

            List<ColaboratorData> list = new List<ColaboratorData>();
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);
                wCmd = wDataBase.GetStoredProcCommand("[User_s_ByParams]");


                wDataBase.AddInParameter(wCmd, "@cuentaId", System.Data.DbType.String, pColaboratorData.CuentaId);
                wDataBase.AddInParameter(wCmd, "@subareaId", System.Data.DbType.String, pColaboratorData.SubAreaId);
                wDataBase.AddInParameter(wCmd, "@cargoId", System.Data.DbType.String, pColaboratorData.CargoId);
                wDataBase.AddInParameter(wCmd, "@SucursalId", System.Data.DbType.String, pColaboratorData.SucursalId);
                
                if (!string.IsNullOrEmpty(pColaboratorData.Domain) && string.Compare(pColaboratorData.Domain, Common.NULL) != 0)
                    wDataBase.AddInParameter(wCmd, "@Dominio", System.Data.DbType.String, pColaboratorData.Domain);

                if (!string.IsNullOrEmpty(pColaboratorData.Username))
                {
                    pColaboratorData.Username = string.Concat("%",pColaboratorData.Username, "%");
                    wDataBase.AddInParameter(wCmd, "@Username", System.Data.DbType.String, pColaboratorData.Username);                    
                }

                if (!string.IsNullOrEmpty(pColaboratorData.Firstname))
                {
                    pColaboratorData.Firstname = string.Concat("%", pColaboratorData.Firstname, "%");
                    wDataBase.AddInParameter(wCmd, "@firstname", System.Data.DbType.String, pColaboratorData.Firstname);
                }

                if (!string.IsNullOrEmpty(pColaboratorData.Surname))
                {
                    pColaboratorData.Surname = string.Concat("%", pColaboratorData.Surname, "%");
                    wDataBase.AddInParameter(wCmd, "@surname", System.Data.DbType.String, pColaboratorData.Surname);
                }

                using (IDataReader reader = wDataBase.ExecuteReader(wCmd))
                {
                    while (reader.Read())
                    {
                        ColaboratorData wColaborator = new ColaboratorData();
                        wColaborator.Username = reader["username"].ToString();
                        wColaborator.Firstname = reader["firstname"].ToString();
                        wColaborator.Surname = reader["surname"].ToString();
                        wColaborator.UserId = Convert.ToInt32(reader["userId"]);

                        list.Add(wColaborator);
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        public static void GetAllRelatedDomains(out DomainList pRelatedDomains, out DomainList pAllDomains)
        {
            pRelatedDomains = new DomainList();
            List<DomainAux> pDomainAuxList = null;
            pAllDomains = null;
            GetDomainsAuxiliarValues(out pDomainAuxList, out pAllDomains);

            var sublistCuentas = from c in pDomainAuxList
                                 where c.CuentaId != null && c.SubareaId == null && c.CargoId == null
                                 select new Domain
                                 {
                                     ParentID = "0",
                                     Id = string.Concat(c.CuentaId.ToString()),
                                     DomainId = c.CuentaId,
                                     Hierarchy = 0,
                                     Count = c.Count
                                 };

            pRelatedDomains.AddRange(sublistCuentas.ToArray<Domain>());

            var sublistSubArea = from c in pDomainAuxList
                                 where c.CuentaId != null && c.SubareaId != null && c.CargoId == null
                                 select new Domain
                                 {
                                     ParentID = string.Concat(c.CuentaId.ToString()),
                                     Id = string.Concat(c.CuentaId.Value.ToString(), c.SubareaId.ToString()),
                                     DomainId = c.SubareaId,
                                     Hierarchy = 1,
                                     Count = c.Count
                                 };

            pRelatedDomains.AddRange(sublistSubArea.ToArray<Domain>());


            var sublistCargo = from c in pDomainAuxList
                               where c.CuentaId != null && c.SubareaId != null && c.CargoId != null
                               select new Domain
                               {
                                   ParentID = string.Concat(c.CuentaId.ToString(), c.SubareaId.ToString()),
                                   Id = string.Concat(c.CuentaId.ToString(), c.SubareaId.ToString(), c.CargoId.ToString()),
                                   DomainId = c.CargoId,
                                   Hierarchy = 2,
                                   Count = c.Count
                               };
            pRelatedDomains.AddRange(sublistCargo.ToArray<Domain>());


            ///Macheo los nombres en una nueva lista finalList
            var finalList = from l1 in pRelatedDomains
                            join l2 in pAllDomains on l1.DomainId equals l2.DomainId
                            where l1.Hierarchy == l2.Hierarchy
                            select new Domain { ParentID = l1.ParentID, Name = l2.Name, Id = l1.Id, DomainId = l1.DomainId, Hierarchy = l1.Hierarchy, Count = l1.Count };

            pRelatedDomains = new DomainList();

            pRelatedDomains.AddRange(finalList.ToArray<Domain>());

        }

        static void GetDomainsAuxiliarValues(out List<DomainAux> pDomainAuxList, out DomainList pDomainList)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            pDomainAuxList = new List<DomainAux>();
            DomainAux wDomainAux;
            pDomainList = new DomainList();
            Domain wDomain;
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);
                wCmd = wDataBase.GetStoredProcCommand("[Domains_s]");


                using (IDataReader reader = wDataBase.ExecuteReader(wCmd))
                {
                    while (reader.Read())
                    {
                        wDomainAux = new DomainAux();
                        if (reader["cuentaid"] != DBNull.Value)
                            wDomainAux.CuentaId = Convert.ToInt32(reader["cuentaid"]);
                        if (reader["subareaid"] != DBNull.Value)
                            wDomainAux.SubareaId = Convert.ToInt32(reader["subareaid"]);
                        if (reader["cargoid"] != DBNull.Value)
                            wDomainAux.CargoId = Convert.ToInt32(reader["cargoid"]);
                        wDomainAux.Count = Convert.ToInt32(reader["Count"]);

                        pDomainAuxList.Add(wDomainAux);
                    }

                    reader.NextResult();
                    while (reader.Read())
                    {
                        wDomain = new Domain();

                        wDomain.DomainId = Convert.ToInt32(reader["Id"]);
                        wDomain.Hierarchy = Convert.ToInt32(reader["Hierarchy"]);
                        wDomain.Name = reader["Name"].ToString();


                        pDomainList.Add(wDomain);
                    }
                }


            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        public static void CreateDomains(string pUserName, DomainList domainList)
        {
            ColaboratorData col = GetColaboratorDataByParams(pUserName);
            if (col != null)
            {
                DeleteRelatedDomains(col.UserId);
                InsertDomainBatch(col.UserId, domainList);
            }
        }

        internal static DomainList SearchRelatedDomainsByUser(int userId)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;


            DomainList wDomainList = new DomainList();
            Domain wDomain;
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);
                wCmd = wDataBase.GetStoredProcCommand("Domain_s_ByUser");

                wDataBase.AddInParameter(wCmd, "@UserId", System.Data.DbType.Int32, userId);

                using (IDataReader reader = wDataBase.ExecuteReader(wCmd))
                {


                    while (reader.Read())
                    {
                        wDomain = new Domain();

                        wDomain.DomainId = Convert.ToInt32(reader["DomainId"]);
                        wDomain.Id = reader["TreeId"].ToString();
                        wDomain.ParentID = reader["TreeParentId"].ToString();
                        wDomain.Name = reader["Name"].ToString();
                        wDomain.Hierarchy = Convert.ToInt32(reader["Hierarchy"]);


                        wDomainList.Add(wDomain);
                    }
                }

                return wDomainList;
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="pDomainBE">DomainBE</param>
        /// <returns>void</returns>
        /// <Date>2009-08-20T16:17:26</Date>
        /// <Author>moviedo</Author>
        internal static void InsertDomain(int pUserId, Domain pDomainBE)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);
                wCmd = wDataBase.GetStoredProcCommand("dbo.Domain_i");

                wDataBase.AddInParameter(wCmd, "DomainId", System.Data.DbType.Int32, pDomainBE.DomainId);
                wDataBase.AddInParameter(wCmd, "UserId", System.Data.DbType.Int32, pUserId);
                wDataBase.AddInParameter(wCmd, "Hierarchy", System.Data.DbType.Int32, pDomainBE.Hierarchy);
                wDataBase.AddInParameter(wCmd, "TreeId", System.Data.DbType.String, pDomainBE.Id);
                wDataBase.AddInParameter(wCmd, "TreeParentId", System.Data.DbType.String, pDomainBE.ParentID);
                wDataBase.AddInParameter(wCmd, "Name", System.Data.DbType.String, pDomainBE.Name);

                wDataBase.ExecuteNonQuery(wCmd);

            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }

        }


        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="pMessagesBE">MessagesBE</param>
        /// <returns>void</returns>
        /// <Date>2009-09-24T09:40:05</Date>
        /// <Author>jiguastini</Author>
        internal static void CreateMessage(BE.MessagesBE pMessagesBE)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);
                wCmd = wDataBase.GetStoredProcCommand("dbo.Messages_i");


                wDataBase.AddInParameter(wCmd, "MessageId", System.Data.DbType.Guid, pMessagesBE.MessageId);
                wDataBase.AddInParameter(wCmd, "Title", System.Data.DbType.String, pMessagesBE.Title);
                wDataBase.AddInParameter(wCmd, "Url", System.Data.DbType.String, pMessagesBE.Url);
                wDataBase.AddInParameter(wCmd, "Sender", System.Data.DbType.String, pMessagesBE.Sender);
                wDataBase.AddInParameter(wCmd, "Date", System.Data.DbType.DateTime, pMessagesBE.Date);

                pMessagesBE.MeshName = MeshBE.GetDatabaseMeshNameOrId(pMessagesBE.MeshName);
                wDataBase.AddInParameter(wCmd, "MeshName", System.Data.DbType.String, pMessagesBE.MeshName);

                pMessagesBE.MeshId = MeshBE.GetDatabaseMeshNameOrId(pMessagesBE.MeshId);
                wDataBase.AddInParameter(wCmd, "MeshId", System.Data.DbType.String, pMessagesBE.MeshId);

                wDataBase.AddInParameter(wCmd, "RequireConfirm", System.Data.DbType.Boolean, pMessagesBE.RequireConfirm);
                wDataBase.AddInParameter(wCmd, "MachineIp", System.Data.DbType.String, pMessagesBE.MachineIp);
                wDataBase.AddInParameter(wCmd, "ColaboratorsCountInMesh", System.Data.DbType.Int32, pMessagesBE.ColaboratorsCountInMesh);
                wDataBase.AddInParameter(wCmd, "MachineName", System.Data.DbType.String, pMessagesBE.MachineName);
                wDataBase.AddInParameter(wCmd, "Priority", System.Data.DbType.Int32, pMessagesBE.Priority);
                wDataBase.AddInParameter(wCmd, "MessageText", System.Data.DbType.Binary, Fwk.HelperFunctions.TypeFunctions.ConvertStringToByteArray(pMessagesBE.MessageText));
                wDataBase.AddInParameter(wCmd, "MessageType", System.Data.DbType.String, pMessagesBE.MessageType);
                wDataBase.ExecuteNonQuery(wCmd);

            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        internal static void CreateReceivedMessages(ReceivedMessagesBE pReceivedMessagesBE)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);
                wCmd = wDataBase.GetStoredProcCommand("dbo.ReceivedMessages_i");

                /// MessageId
                wDataBase.AddInParameter(wCmd, "MessageId", System.Data.DbType.Guid, pReceivedMessagesBE.MessageId);
                /// Receptor
                wDataBase.AddInParameter(wCmd, "Receptor", System.Data.DbType.String, pReceivedMessagesBE.Receptor);
                /// Date
                wDataBase.AddInParameter(wCmd, "Date", System.Data.DbType.DateTime, pReceivedMessagesBE.Date);
                /// Date
                wDataBase.AddInParameter(wCmd, "Confirmed", System.Data.DbType.Boolean, pReceivedMessagesBE.Confirmed);

                wDataBase.ExecuteNonQuery(wCmd);

            }
            catch (SqlException ex)
            {
               if(ex.Number != 2627)
                   throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }


        /// <summary>
        /// Crea registros en batch sobre la tabla DomainBE.-
        /// </summary>
        /// <param name="DomainList">DomainList</param>
        /// <Date>2009-08-20T16:17:26</Date>
        /// <Author>moviedo</Author>
        internal static void InsertDomainBatch(int pUserId, DomainList pDomainList)
        {

            StringBuilder BatchCommandText = new StringBuilder();
            try
            {
                Database wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);

                #region --[Seteo de Parametros]--
                foreach (Domain wDomainBE in pDomainList)
                {
                    BatchCommandText.Append(" Exec dbo.Domain_i ");


                    BatchCommandText.Append("@UserId = ");
                    BatchCommandText.Append(pUserId);
                    BatchCommandText.Append(",");


                    BatchCommandText.Append("@Hierarchy = ");
                    BatchCommandText.Append(wDomainBE.Hierarchy);
                    BatchCommandText.Append(",");

                    BatchCommandText.Append("@DomainId = ");
                    BatchCommandText.Append(wDomainBE.DomainId);
                    BatchCommandText.Append(",");

                    BatchCommandText.Append("@TreeParentId = ");
                    BatchCommandText.Append(string.Concat("'", wDomainBE.ParentID.Trim(), "'"));
                    BatchCommandText.Append(",");


                    BatchCommandText.Append("@TreeId = ");
                    BatchCommandText.Append(string.Concat("'", wDomainBE.Id.Trim(), "'"));
                    BatchCommandText.Append(",");

                    BatchCommandText.Append("@Name = ");
                    BatchCommandText.Append(string.Concat("'", wDomainBE.Name.Trim(), "'"));
                    BatchCommandText.Append(";");


                }
                #endregion

                DbCommand wCommand = wDataBase.GetSqlStringCommand(BatchCommandText.ToString());
                wCommand.CommandType = CommandType.Text;

                if (BatchCommandText.Length > 0)
                {
                    wDataBase.ExecuteNonQuery(wCommand);
                }

                wCommand.Connection.Close();

            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex); ;
            }

        }

        /// <summary>
        /// Delete
        /// </summary>

        /// <returns>void</returns>
        /// <Date>2009-08-20T16:17:26</Date>
        /// <Author>moviedo</Author>
        public static void DeleteRelatedDomains(int pUserId)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);
                wCmd = wDataBase.GetStoredProcCommand("dbo.Domain_d");
                /// UserId
                wDataBase.AddInParameter(wCmd, "UserId", System.Data.DbType.Int32, pUserId);

                wDataBase.ExecuteNonQuery(wCmd);

            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }

        }

        public static void UpdateReceivedMessages(Guid pMessageId, string pReceptor, bool pConfirmed)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);
                wCmd = wDataBase.GetStoredProcCommand("dbo.ReceivedMessages_u");
                /// Confirmed
                wDataBase.AddInParameter(wCmd, "Confirmed", System.Data.DbType.Boolean, pConfirmed);
                /// Receptor
                wDataBase.AddInParameter(wCmd, "Receptor", System.Data.DbType.String, pReceptor);
                ///MessageId
                wDataBase.AddInParameter(wCmd, "MessageId", System.Data.DbType.Guid, pMessageId);

                wDataBase.ExecuteNonQuery(wCmd);

            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        internal static MessagesBECollection SearchMessageByParams(MessagesBE pMessagesBE, DateTime? pStartDate, DateTime? pEndDate)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            BE.MessagesBECollection wMessagesBECollection = new MessagesBECollection();
            //string wEnum = Enum.GetName(typeof(MessageType), pMessagesBE.MessageType);

            pMessagesBE.MeshName = MeshBE.GetDatabaseMeshNameOrId(pMessagesBE.MeshName);
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);
                wCmd = wDataBase.GetStoredProcCommand("Messages_s_ByParams");
                wDataBase.AddInParameter(wCmd, "@DateStart", System.Data.DbType.DateTime, Convert.ToDateTime(pStartDate.Value.ToShortDateString()));
                wDataBase.AddInParameter(wCmd, "@DateEnd", System.Data.DbType.DateTime, Convert.ToDateTime(pEndDate.Value.ToShortDateString()));
                if (!string.IsNullOrEmpty(pMessagesBE.Title))
                    wDataBase.AddInParameter(wCmd, "@Title", System.Data.DbType.String, HelperFunctions.GetSearchTypeValue(pMessagesBE.Title, Allus.Libs.Common.SearchtypeEnum.Contain));
                if (!string.IsNullOrEmpty(pMessagesBE.Url))
                    wDataBase.AddInParameter(wCmd, "@Url", System.Data.DbType.String, HelperFunctions.GetSearchTypeValue(pMessagesBE.Url, Allus.Libs.Common.SearchtypeEnum.Contain));
                if (!string.IsNullOrEmpty(pMessagesBE.Sender))
                    wDataBase.AddInParameter(wCmd, "@Sender", System.Data.DbType.String, pMessagesBE.Sender);
                if (!string.IsNullOrEmpty(pMessagesBE.MeshName))
                    wDataBase.AddInParameter(wCmd, "@MeshName", System.Data.DbType.String, HelperFunctions.GetSearchTypeValue(pMessagesBE.MeshName, Allus.Libs.Common.SearchtypeEnum.Contain));
                if (pMessagesBE.MessageType != MessageType.None)
                    wDataBase.AddInParameter(wCmd, "@MessageType", System.Data.DbType.String, HelperFunctions.GetSearchTypeValue(Enum.GetName(typeof(MessageType), pMessagesBE.MessageType), Allus.Libs.Common.SearchtypeEnum.Contain));

                using (IDataReader reader = wDataBase.ExecuteReader(wCmd))
                {

                    RecorrerDataReader(reader, wMessagesBECollection);

                }

                return wMessagesBECollection;
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        private static MessagesBECollection RecorrerDataReader(IDataReader pReader,  MessagesBECollection pMessagesBECollection)
        {
            MessagesBE wMessagesBE;

            while (pReader.Read())
            {
                wMessagesBE = new MessagesBE();

                wMessagesBE.MessageId = (Guid)pReader["MessageId"];
                wMessagesBE.MessageText = Fwk.HelperFunctions.TypeFunctions.ConvertByteToTextString((Byte[])(pReader["MessageText"]));
                wMessagesBE.Date = Convert.ToDateTime(pReader["Date"]);
                wMessagesBE.MeshName = pReader["MeshName"].ToString();
                wMessagesBE.MeshId = pReader["MeshId"].ToString();
                wMessagesBE.MachineIp = pReader["MachineIp"].ToString();
                wMessagesBE.ColaboratorsCountInMesh = Convert.ToInt32(pReader["ColaboratorsCountInMesh"]);
                wMessagesBE.MachineName = pReader["MachineName"].ToString();
                wMessagesBE.Title = pReader["Title"].ToString();
                wMessagesBE.RequireConfirm = Convert.ToBoolean(pReader["RequireConfirm"]);
                wMessagesBE.Url = pReader["Url"].ToString();
                wMessagesBE.Priority = Convert.ToInt32(pReader["Priority"]);
                if (pReader["MessageType"] != System.DBNull.Value)
                    wMessagesBE.MessageType = (MessageType)Enum.Parse(typeof(MessageType), pReader["MessageType"].ToString().Trim());

                pMessagesBECollection.Add(wMessagesBE);
            }
            return pMessagesBECollection;
        }


        internal static DataTable SearchRpt_ReadConfirmed(Guid pMessageId)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;
            DataSet wDs;

            try
            {
                wDs = new DataSet();
                wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);
                wCmd = wDataBase.GetStoredProcCommand("dbo.rpt_ReadConfirmedMessagesCount_s");
                /// Confirmed
                wDataBase.AddInParameter(wCmd, "MessageId", System.Data.DbType.Guid, pMessageId);

                wDs = wDataBase.ExecuteDataSet(wCmd);

                //Convertimos el resultado del stored a una estructura de DataTable con una fila y una columna
                DataRow dr;
                DataTable dt = new DataTable();
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Cantidad");

                foreach (DataColumn dc in wDs.Tables[0].Columns)
                {
                    dr = dt.NewRow();
                    dr["Descripcion"] = dc.ToString();
                    dr["Cantidad"] = wDs.Tables[0].Rows[0][dc];
                    dt.Rows.Add(dr);
                }

                return dt;
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        public static List<ColaboratorData> SearchMessages_ReadConfirmed(Guid pMessageId, ColaboratorData pColaboratorData)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;
            ColaboratorData wColaboratorData;
            List<ColaboratorData> wColaboratorList = new List<ColaboratorData>();

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Allus.Cnn.Common.Common.DataConfig);
                wCmd = wDataBase.GetStoredProcCommand("dbo.Messages_ReadConfirmed_s");
               
                wDataBase.AddInParameter(wCmd, "MessageId", System.Data.DbType.Guid, pMessageId);
                if (pColaboratorData.CuentaId != null)
                    wDataBase.AddInParameter(wCmd, "cuentaId", System.Data.DbType.String, pColaboratorData.CuentaId);
                if (pColaboratorData.SubAreaId != null)
                wDataBase.AddInParameter(wCmd, "subareaId", System.Data.DbType.String, pColaboratorData.SubAreaId);
                if (pColaboratorData.CargoId != null)
                wDataBase.AddInParameter(wCmd, "cargoId", System.Data.DbType.String, pColaboratorData.CargoId);
                if (pColaboratorData.SucursalId != null)
                wDataBase.AddInParameter(wCmd, "SucursalId", System.Data.DbType.String, pColaboratorData.SucursalId);
                if (!string.IsNullOrEmpty(pColaboratorData.Domain) && string.Compare(pColaboratorData.Domain, Common.NULL) != 0)
                    wDataBase.AddInParameter(wCmd, "Dominio", System.Data.DbType.String, pColaboratorData.Domain);


                using (IDataReader reader = wDataBase.ExecuteReader(wCmd))
                {
                   while (reader.Read())
                    {
                        wColaboratorData = new ColaboratorData();
                        wColaboratorData.Username = reader["UserName"].ToString();
                        wColaboratorData.Firstname = reader["FirstName"].ToString();
                        wColaboratorData.Surname = reader["surname"].ToString();
                        wColaboratorData.MessageStatus = reader["Estado"].ToString();
                        wColaboratorList.Add(wColaboratorData);
                    }
                }
                return wColaboratorList;
            }

            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }
    }
}
