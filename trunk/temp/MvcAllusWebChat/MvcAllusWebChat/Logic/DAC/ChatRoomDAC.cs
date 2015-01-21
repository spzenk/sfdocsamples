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
        /// <param name="statusId"></param>
        /// <returns></returns>
        internal static int CreateChatRoom(string chatConfigId, int statusId)             
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                wCmd = wDataBase.GetStoredProcCommand("[Chat].[ChatRoom_u]");
                /// ChatUserId
                wDataBase.AddOutParameter(wCmd, "ChatRoomId", System.Data.DbType.Int32, 4);

                wDataBase.AddInParameter(wCmd, "ChatRoomStatusId", System.Data.DbType.Int32, statusId);

                wDataBase.AddInParameter(wCmd, "ChatConfigId", System.Data.DbType.String, chatConfigId);

                wDataBase.ExecuteNonQuery(wCmd);
                return (System.Int32)wDataBase.GetParameterValue(wCmd, "ChatRoomId");

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
        /// <param name="status"></param>
        /// <param name="recordId">Si es Null no lo envia al SP</param>
        internal static void Update(int chatRoomId, int statusId, int? recordId)
        {

            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                wCmd = wDataBase.GetStoredProcCommand("[Chat].[ChatRoom_u]");
                /// ChatUserId
                wDataBase.AddInParameter(wCmd, "ChatRoomId", System.Data.DbType.Int32, chatRoomId);

                wDataBase.AddInParameter(wCmd, "ChatRoomStatusId", System.Data.DbType.Int32, statusId);

                if (recordId.HasValue)
                    wDataBase.AddInParameter(wCmd, "RecordId", System.Data.DbType.String, recordId);

                wDataBase.ExecuteNonQuery(wCmd);
                
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }



        internal static List<ActiveChatRoomBE> RetriveActiveChatRooms(int userId)
        {

            Database database = null;
            DbCommand cmd = null;
            ActiveChatRoomBE item = null;
            List<ActiveChatRoomBE> list = new List<ActiveChatRoomBE>();
            try
            {
                database = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                cmd = database.GetStoredProcCommand("[Chat].[ActiveChatRoom_s_ByChatUserId]");
                /// ChatUserId
                database.AddInParameter(cmd, "UserId", System.Data.DbType.Int32, userId);
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
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }

        }





        internal static ChatRoom GetById(int p)
        {
            throw new NotImplementedException();
        }
    }
}