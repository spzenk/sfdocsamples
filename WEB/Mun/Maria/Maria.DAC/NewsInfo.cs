using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Maria.BE;
using System.Data;
using System.Data.SqlClient;
using Fwk.Exceptions;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace Maria.DAC
{
    public class MariaDAC:Fwk.Bases.BaseDAC
    {

        public static void Create(NewsInfo pNewsInfo)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase("data");
                wCmd = wDataBase.GetStoredProcCommand("dbo.news_i");

                wDataBase.AddInParameter(wCmd, "Id", System.Data.DbType.Guid, pNewsInfo.Id);

                if (pNewsInfo.Img != null)
                    wDataBase.AddInParameter(wCmd, "Img", System.Data.DbType.Binary, pNewsInfo.Img);

                if (pNewsInfo.ExpitationDate != null)
                    wDataBase.AddInParameter(wCmd, "ExpitationDate", System.Data.DbType.Binary, pNewsInfo.ExpitationDate.Value);


                if (pNewsInfo.CreationUser != null)
                    wDataBase.AddInParameter(wCmd, "CreationUser", System.Data.DbType.Binary, pNewsInfo.CreationUser);

                wDataBase.AddInParameter(wCmd, "Body", System.Data.DbType.Binary, Fwk.HelperFunctions.TypeFunctions.ConvertStringToByteArray(pNewsInfo.Text));
                wDataBase.AddInParameter(wCmd, "Title", System.Data.DbType.String, pNewsInfo.Title);

                wDataBase.ExecuteNonQuery(wCmd);

            }
            catch (SqlException ex)
            {
                if (ex.Number != 2627)
                    throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        public  List<NewsInfo> SearchByParam(NewsInfo pFwk_News)
        {
            List<NewsInfo> wFwk_NewsList = new List<NewsInfo>();
            NewsInfo wFwk_News;
            using (SqlConnection cnn = new SqlConnection(GetCnnstring("data")))
            {
                using (SqlCommand cmd = cnn.CreateCommand())
                {
                    try
                    {
                        using (IDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                wFwk_News = new NewsInfo();
                                wFwk_News.Id = (Guid)reader["newsid"];
                                if (reader["Img"] != DBNull.Value)
                                    wFwk_News.Img = (byte[])reader["Img"];

                                wFwk_News.Title = reader["Title"].ToString();
                                wFwk_News.Text = Fwk.HelperFunctions.TypeFunctions.ConvertBytesToTextString((Byte[])(reader["Body"]));
                                //wFwk_News.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                                //wFwk_News.CreationUser = reader["CreationUser"].ToString();

                                wFwk_NewsList.Add(pFwk_News);
                            }
                        }
                        return wFwk_NewsList;

                    }
                    catch (Exception ex)
                    {
                        Fwk.Exceptions.TechnicalException te = new TechnicalException(ex.Message, ex);
                        te.Source = "SQL Server - base de datos de usuarios de la empresa";

                        return null;
                    }
                }
            }

        }

        //internal static Dictionary<string, string> DomainsByOpenfire()
        //{
        //    Dictionary<string, string> wDomains;
        //    using (SqlConnection cnn = CommonDAC.GetCnn("imcall"))
        //    {
        //        using (SqlCommand cmd = cnn.CreateCommand())
        //        {
        //            try
        //            {
        //                cmd.CommandText = _SelectDomainsByOpenfire;
        //                cmd.CommandType = CommandType.Text;
        //                cnn.Open();

        //                wDomains = new Dictionary<string, string>();
        //                using (IDataReader reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        if (reader["DOM_SERVER_IMALLUS"] != DBNull.Value)
        //                        {
        //                            if (!string.IsNullOrEmpty(reader["DOM_SERVER_IMALLUS"].ToString().Trim()))
        //                                wDomains.Add(reader["DOM_NOMBRE"].ToString().Trim(), reader["DOM_SERVER_IMALLUS"].ToString().Trim());
        //                        }
        //                    }
        //                }
        //                return wDomains;

        //            }
        //            catch (Exception ex)
        //            {
        //                Fwk.Exceptions.TechnicalException te = new TechnicalException(ex.Message, ex);
        //                te.Source = "SQL Server - base de datos de usuarios de la empresa";

        //                return null;
        //            }
        //        }
        //    }

        //}

        //public override void AddNews(NewsInfo pNewsInfo)
        //{
        //    SqlHelper.ExecuteNonQuery(ConnectionString, "dbo.Fwk_News_i",
        //        pNewsInfo.ModuleId,
        //        pNewsInfo.ItemId,
        //        pNewsInfo.Content, pNewsInfo.Title,
        //        pNewsInfo.CreatedByUser);

        //}
        //public override void UpdateNews(int ModuleId, int ItemId, string Content, int UserId)
        //{
        //    SqlHelper.ExecuteNonQuery(ConnectionString, "dbo.Fwk_News_u", ModuleId, ItemId, Content, UserId);
        //}

        //public override void DeleteNews(int ModuleId, int ItemId)
        //{
        //    SqlHelper.ExecuteNonQuery(ConnectionString, "dbo.Fwk_News_d", ModuleId, ItemId);
        //}

    }
}
