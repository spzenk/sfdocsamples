﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a allus Code Generator.
//     Runtime Version: 1.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//</auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

using WebChat.Common.BE;
using WebChat.Common;


namespace WebChat.Logic.DAC
{

    public static class ChatUserDAC
    {


        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="pChatUser">ChatUser</param>
        /// <returns>void</returns>
        /// <Date>2015-01-19T10:21:49</Date>
        /// <Author>moviedo</Author>
        public static void Insert(ChatUserBE pChatUser)
        {
            Database dataBase = null;
            DbCommand cmd = null;

            //try
            //{
                dataBase = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                using (cmd = dataBase.GetStoredProcCommand("[Chat].[ChatUser_i]"))
                {
                    /// ChatUserId
                    dataBase.AddOutParameter(cmd, "ChatUserId", System.Data.DbType.Int32, 4);

                    dataBase.AddInParameter(cmd, "ChatUserPhone", System.Data.DbType.String, pChatUser.ChatUserPhone);

                    dataBase.AddInParameter(cmd, "ChatUserName", System.Data.DbType.String, pChatUser.ChatUserName);

                    dataBase.AddInParameter(cmd, "ChatUserEmail", System.Data.DbType.String, pChatUser.ChatUserEmail);


                    dataBase.ExecuteNonQuery(cmd);
                    pChatUser.ChatUserId = (System.Int32)dataBase.GetParameterValue(cmd, "ChatUserId");
                }
            //}
            //catch (Exception ex)
            //{
            //    throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            //}

        }








        /// <summary>
        /// Update
        /// </summary>
        ///<param name="pChatUser">ChatUser</param>
        /// <returns>void</returns>
        /// <Date>2015-01-19T10:21:49</Date>
        /// <Author>moviedo</Author>
        public static void Update(ChatUserBE pChatUser)
        {
            Database dataBase = null;
            DbCommand cmd = null;

            //try
            //{
                dataBase = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                using (cmd = dataBase.GetStoredProcCommand("[Chat].[ChatUser_u]"))
                {

                    dataBase.AddInParameter(cmd, "ChatUserId", System.Data.DbType.Int32, pChatUser.ChatUserId);

                    //dataBase.AddInParameter(cmd, "ChatUserPhone", System.Data.DbType.String, pChatUser.ChatUserPhone);

                    dataBase.AddInParameter(cmd, "ChatUserName", System.Data.DbType.String, pChatUser.ChatUserName);

                    dataBase.AddInParameter(cmd, "ChatUserEmail", System.Data.DbType.String, pChatUser.ChatUserEmail);


                    //dataBase.AddInParameter(cmd, "ChatUserModifiedDate", System.Data.DbType.DateTime, pChatUser.ChatUserModifiedDate);

                    dataBase.ExecuteNonQuery(cmd);
                }
            //}
            //catch (Exception ex)
            //{
            //    throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            //}

        }






        /// <summary>
        /// Trae los datos sobre la cuenta de email del Usere
        /// </summary>
        /// <param name="pChatConfigGuid">id configuración de la cuenta</param>
        /// <returns></returns>
        public static ChatUserBE GetByParams(String chatUserPhone)
        {
            ChatUserBE wChatUser = null;
            Database database = null;

            //try
            //{
                database = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                using (DbCommand cmd = database.GetStoredProcCommand("[Chat].[ChatUser_g]"))
                {
                    if (!String.IsNullOrEmpty(chatUserPhone))
                        database.AddInParameter(cmd, "ChatUserPhone", DbType.String, chatUserPhone);

                    using (IDataReader reader = database.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            wChatUser = new ChatUserBE();

                            wChatUser.ChatUserId = Convert.ToInt32(reader["ChatUserId"]);
                            if (reader["ChatUserPhone"] != DBNull.Value)
                                wChatUser.ChatUserPhone = Convert.ToString(reader["ChatUserPhone"]);

                            if (reader["ChatUserName"] != DBNull.Value)
                                wChatUser.ChatUserName = Convert.ToString(reader["ChatUserName"]);

                            if (reader["ChatUserEmail"] != DBNull.Value)
                                wChatUser.ChatUserEmail = Convert.ToString(reader["ChatUserEmail"]);

                        }
                    }
                }
                return wChatUser;
            //}
            //catch (Exception ex)
            //{
            //    throw SecPortalException.ProcessException(ex, typeof(EpironChatDAC), "EpironChatConnectionString");
            //}
        }


    }
}







