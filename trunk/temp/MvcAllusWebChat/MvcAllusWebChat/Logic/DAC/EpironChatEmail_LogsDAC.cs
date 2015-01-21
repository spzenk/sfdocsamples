using EpironChatLogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Common;
using WebChat.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using WebChat.Common.BE;
namespace WebChat.Logic
{
    public class EpironChatEmail_LogsDAC
    {
        /// <summary>
        /// Trae los datos sobre la cuenta de email con que se deben mandar los correos
        /// </summary>
        /// <param name="pChatConfigGuid">id configuración de la cuenta</param>
        /// <returns></returns>
        public static ChatMailSenderBE GetChatMailSenderByCongGuid(Guid pChatConfigGuid)
        {
            ChatMailSenderBE wChatMailSender = null;
            Database database = null;
            int? recordId = null;
            try
            {
                database = DatabaseFactory.CreateDatabase("EpironChat_LogsConnectionString");
                using (DbCommand cmd = database.GetStoredProcCommand("[Chat].[ChatMailSender_s_ByChatConfigGuid]"))
                {
                    database.AddInParameter(cmd, "ChatConfigGuid", DbType.Guid, pChatConfigGuid);
                    using (IDataReader reader = database.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            wChatMailSender = new ChatMailSenderBE();

                            if (reader["Email"] != DBNull.Value)
                                wChatMailSender.Email = Convert.ToString(reader["Email"]);

                            if (reader["Password"] != DBNull.Value)
                                wChatMailSender.Password = Convert.ToString(reader["Password"]);

                            if (reader["UserName"] != DBNull.Value)
                                wChatMailSender.UserName = Convert.ToString(reader["UserName"]);

                            if (reader["SMTPServer"] != DBNull.Value)
                                wChatMailSender.SMTPServer = Convert.ToString(reader["SMTPServer"]);

                            if (reader["SMTPPort"] != DBNull.Value)
                                wChatMailSender.SMTPPort = Convert.ToInt32(reader["SMTPPort"]);

                            if (reader["EnableSSL"] != DBNull.Value)
                                wChatMailSender.EnableSSL = Convert.ToBoolean(reader["EnableSSL"]);

                            if (reader["TagStartWith"] != DBNull.Value)
                                wChatMailSender.TagStartWith = Convert.ToString(reader["TagStartWith"]);

                            if (reader["TagEndWith"] != DBNull.Value)
                                wChatMailSender.TagEndWith = Convert.ToString(reader["TagEndWith"]);
                        }
                    }
                }
                return wChatMailSender;
            }
            catch (Exception ex)
            {
                throw SecPortalException.ProcessException(ex, typeof(EpironChatDAC), "EpironChatConnectionString");
            }
        }




        /// <summary>
        /// Inserta en ChatMessage
        /// </summary>
        /// <param name="pChatMessage">Entidad a insertar</param>
        /// <returns></returns>
        public static bool InsertChatMessage(WebChat.Common.BE.ChatMessageBE pChatMessage)
        {
            ChatUser wChatUser = new ChatUser();
            Database database = null;
            int newId = 0;
            try
            {
                database = DatabaseFactory.CreateDatabase("EpironChat_LogsConnectionString");
                using (DbCommand cmd = database.GetStoredProcCommand("[Chat].[ChatMessage]"))
                {
                    database.AddInParameter(cmd, "ChatMessage", DbType.String, pChatMessage.ChatMessageText);
                    database.AddInParameter(cmd, "ChatRoomId", DbType.Int32, pChatMessage.ChatRoomId);
                    database.AddInParameter(cmd, "ChatUserId", DbType.Int32, pChatMessage.ChatUserId);
                    newId = (int)database.ExecuteScalar(cmd);
                    if (newId > 0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                throw SecPortalException.ProcessException(ex, typeof(EpironChatDAC), "EpironChatConnectionString");
            }
        }
    }
}