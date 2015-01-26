using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using WebChat.Common;
using WebChat.Common.BE;
using WebChat.Data;

namespace WebChat.Logic
{
    public class ChatRoomDAC
    {
        /// <summary>
        /// Crea un chatroom 
        /// </summary>
        /// <param name="chatConfigId"></param>
        /// <param name="statusId">Estado </param>
        /// <param name="chatRoomExternalIdentifier">Parametro @case cuando la generacion del chatroom proviene de  una URL</param>
        /// <returns></returns>
        internal static int CreateChatRoom(Int32 chatConfigId, Int32 statusId, String chatRoomExternalIdentifier)
        {
            Database dataBase = null;
            DbCommand cmd = null;

            try
            {
                dataBase = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                using (cmd = dataBase.GetStoredProcCommand("[Chat].[ChatRoom_i]"))
                {

                    dataBase.AddOutParameter(cmd, "ChatRoomId", System.Data.DbType.Int32, 4);
                    dataBase.AddInParameter(cmd, "ChatRoomStatusId", System.Data.DbType.Int32, statusId);
                    dataBase.AddInParameter(cmd, "ChatConfigId", System.Data.DbType.Int32, chatConfigId);
                    if (!String.IsNullOrEmpty(chatRoomExternalIdentifier))
                        dataBase.AddInParameter(cmd, "ChatRoomExternalIdentifier", System.Data.DbType.String, chatRoomExternalIdentifier);
                    dataBase.ExecuteNonQuery(cmd);
                    return (System.Int32)dataBase.GetParameterValue(cmd, "ChatRoomId");
                }
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomid"></param>
        /// <param name="status">Estado</param>
        /// <param name="recordId">Si es Null no lo envia al SP</param>
        internal static void Update(int chatRoomId, int statusId, int? recordId)
        {

            Database dataBase = null;
            DbCommand cmd = null;

            try
            {
                dataBase = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                using (cmd = dataBase.GetStoredProcCommand("[Chat].[ChatRoom_u]"))
                {
                    /// ChatUserId
                    dataBase.AddInParameter(cmd, "ChatRoomId", System.Data.DbType.Int32, chatRoomId);

                    dataBase.AddInParameter(cmd, "ChatRoomStatusId", System.Data.DbType.Int32, statusId);

                    if (recordId.HasValue)
                        dataBase.AddInParameter(cmd, "RecordId", System.Data.DbType.String, recordId);

                    dataBase.ExecuteNonQuery(cmd);
                }

            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        internal static List<ActiveChatRoomBE> RetriveActiveChatRooms(int userId)
        {

            Database database = null;
            DbCommand cmd = null;
            ActiveChatRoomBE item = null;
            List<ActiveChatRoomBE> list = new List<ActiveChatRoomBE>();
            try
            {
                database = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                using (cmd = database.GetStoredProcCommand("[Chat].[ActiveChatRoom_s_ByChatUserId]"))
                {
                    database.AddInParameter(cmd, "ChatUserId", System.Data.DbType.Int32, userId);
                    using (IDataReader reader = database.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            item = new ActiveChatRoomBE();
                            item.ChatRoomId = Convert.ToInt32(reader["ChatRoomId"]);
                            item.ChatMessageId = Convert.ToInt32(reader["ChatMessageId"]);
                            item.ChatMessageDate = Convert.ToDateTime(reader["ChatMessageDate"]);
                            list.Add(item);

                        }
                    }
                    return list;
                }
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }

        }




        [Obsolete("todavia no se usa")]
        internal static ChatRoom GetById(int p)
        {
            return new ChatRoom();
        }
        [Obsolete("todavia no se usa")]
        internal static void UpdateTTL(int chatRoomId)
        {

        }
    }
}