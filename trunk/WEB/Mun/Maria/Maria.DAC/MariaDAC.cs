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

     

        public static NewsList SearchByParam(NewsInfo pNewsInfo)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;
            NewsList wNewsList;
            NewsInfo wNewsInfo;
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase("data");


                using (wCmd = wDataBase.GetStoredProcCommand("dbo.news_s_params"))
                {
                    
                    //wDataBase.AddInParameter(wCmd, "Title", System.Data.DbType.String, pNewsInfo.Title);

                   
                    wNewsList = new NewsList();
                    using (IDataReader reader = wDataBase.ExecuteReader(wCmd))
                    {

                        while (reader.Read())
                        {
                            wNewsInfo = new NewsInfo();
                            wNewsInfo.Id = (Guid)reader["newsid"];
                            if (reader["Img"] != DBNull.Value)
                                wNewsInfo.Img = (byte[])reader["Img"];

                            wNewsInfo.Title = reader["Title"].ToString();
                            wNewsInfo.Text = Fwk.HelperFunctions.TypeFunctions.ConvertBytesToTextString((Byte[])(reader["Body"]));
                            wNewsInfo.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                            wNewsInfo.CreationUser = reader["CreationUser"].ToString();

                            wNewsList.Add(wNewsInfo);
                        }
                    }
                }

                return wNewsList;
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }


    }
}
