using EpironChat;
using EpironChatLogs;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;
using WebChat.Common;
using WebChat.Data;
using WebChat.Logic.BE;

namespace WebChat.Logic
{
    public class EpironChatDAC
    {


        static EpironChatDAC()
        {


        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="puserId"></param>
        /// <param name="chatRoomStatusFromEtl">Estado del recodr id </param>
        /// <returns></returns>
        internal static GetRecordIdBE GetRecordId(int messageId, out int? chatRoomStatusFromEtl)
        {
            chatRoomStatusFromEtl = null;
            Database database = null;
            int? recordId = null;
            GetRecordIdBE wGetRecordId = new GetRecordIdBE();
            //try
            //{
            database = DatabaseFactory.CreateDatabase(Common.Common.EpironChat_CnnStringName);
            using (DbCommand cmd = database.GetStoredProcCommand("[chat].[Record_s_bySourceChatMessageId]"))
            {
                database.AddInParameter(cmd, "ChatMessageId", DbType.Int32, messageId);
                using (IDataReader reader = database.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        if (reader["recordId"] != DBNull.Value)
                            wGetRecordId.RecordId = Convert.ToInt32(reader["recordId"]);

                        if (reader["PCRecordActionResultType"] != DBNull.Value)
                            chatRoomStatusFromEtl = Convert.ToInt32(reader["PCRecordActionResultType"]);

                        if (reader["FirstName"] != DBNull.Value)
                            wGetRecordId.UserFirstName = Convert.ToString(reader["FirstName"]);

                        if (reader["LastName"] != DBNull.Value)
                            wGetRecordId.UserLastName = Convert.ToString(reader["LastName"]);

                        if (reader["Name"] != DBNull.Value)
                            wGetRecordId.UserName = Convert.ToString(reader["Name"]);
                    }
                }
            }
            return wGetRecordId;
            //}
            //catch (Exception ex)
            //{
            //    throw SecPortalException.ProcessException(ex, typeof(EpironChatDAC), Common.Common.EpironChat_CnnStringName);
            //}




        }


        /// <summary>
        /// Retorna todos los mensajes de un chatRoom
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        internal static List<Message> RecieveComments(int recordId, out int? chatRoomStatus, out Boolean operatorWriting, out string pNameOperator)
        {
            List<Message> result = new List<Message>();
            Message item;
            Database database = null;
            chatRoomStatus = null;

            database = DatabaseFactory.CreateDatabase(Common.Common.EpironChat_CnnStringName);

            using (DbCommand cmd = database.GetStoredProcCommand("[Chat].[RecordCommentChat_s_ByRecordId]"))
            {
                database.AddInParameter(cmd, "RecordId", DbType.Int32, recordId);
                operatorWriting = false;
                pNameOperator = string.Empty;
                using (IDataReader reader = database.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                       
                        if (chatRoomStatus.HasValue == false)
                            if (reader["PCRecordActionResultType"] != DBNull.Value)
                                chatRoomStatus = Convert.ToInt32(reader["PCRecordActionResultType"]);

                            pNameOperator = reader["rctusername"].ToString();

                    }
                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                item = new Message();
                                item.MessageData = reader["Comment"].ToString();

                                //Los comentarios que tienen el campo rctModifiedByUserId = NULL, son los enviados por el cliente
                                if (reader["commentid"] != DBNull.Value)
                                {
                                    item.IsFriend = true;
                                    //item.Talker = reader["rctusername"].ToString();
                                }
                                else
                                {
                                    item.IsFriend = false;

                                    //El nombre del rep es el campo rctUserName.
                                    //item.Talker = reader["rctUserName"].ToString();
                                }

                                item.SendTime = Convert.ToDateTime(reader["PostDate"]);
                                result.Add(item);
                              
                            }
                        }

                       

                      
                    
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            operatorWriting = Convert.ToBoolean(reader["ChatRoomoperatorWriting"]);
                        }
                    }
                }
            }

            return result;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chatConfigGuid"></param>
        /// <returns></returns>
        internal static int OnlineUsers_Count(Guid? chatConfigGuid)
        {
            Database database = null;
            int cantidadUsuarios = 0;

            database = DatabaseFactory.CreateDatabase(Common.Common.EpironChat_CnnStringName);

            using (DbCommand cmd = database.GetStoredProcCommand("[Chat].[OnlineUsers_s_byChatConfigGuid]"))
            {
                database.AddInParameter(cmd, "ChatConfigGuid", DbType.Guid, chatConfigGuid);

                using (IDataReader reader = database.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        cantidadUsuarios = Convert.ToInt32(reader["CantidadUsuarios"]);
                    }
                }
                //cantidadUsuarios = database.ExecuteNonQuery(cmd);
            }
            return cantidadUsuarios;
          
        }


    }
}