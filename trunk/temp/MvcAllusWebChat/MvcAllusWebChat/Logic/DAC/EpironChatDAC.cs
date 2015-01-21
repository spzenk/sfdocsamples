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
        /// <param name="pSMSId"></param>
        /// <param name="chatRoomStatusFromEtl">Estado del recodr id </param>
        /// <returns></returns>
        internal static int? GetRecordId(int pSMSId, out int? chatRoomStatusFromEtl)
        {
            chatRoomStatusFromEtl = null;
            Database database = null;
            int? recordId = null;
            try
            {
                database = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                using (DbCommand cmd = database.GetStoredProcCommand("[SMS].[Record_s_bySourceSMSId]"))
                {
                    database.AddInParameter(cmd, "SMSId", DbType.Int32, pSMSId);
                    using (IDataReader reader = database.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            recordId = Convert.ToInt32(reader["recordId"]);
                            if (reader["PCRecordActionResultType"] != DBNull.Value)
                                chatRoomStatusFromEtl = Convert.ToInt32(reader["PCRecordActionResultType"]);
                        }
                    }
                }
                return recordId;
            }
            catch (Exception ex)
            {
                throw SecPortalException.ProcessException(ex, typeof(EpironChatDAC), "EpironChatConnectionString");
            }




        }
      

        /// <summary>
        /// Retorna todos los mensajes de un chatRoom
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        internal static List<Message> RecieveComments(int recordId,out int? chatRoomStatus)
        {
            List<Message> result = new List<Message>();
            Message item;
            Database database = null;
            chatRoomStatus  =null;
           

            try
            {
                database = DatabaseFactory.CreateDatabase("EpironChatConnectionString");
                
                using (DbCommand cmd = database.GetStoredProcCommand("[SMS].[RecordCommentChat_s_ByRecordId]"))
                {
                    database.AddInParameter(cmd, "RecordId", DbType.Int32, recordId);
                    
                    
                    using (IDataReader reader = database.ExecuteReader(cmd))
                    {
                        while (reader.Read())
                        {
                            item = new Message();
                            if (chatRoomStatus.HasValue==false)
                                if (reader["PCRecordActionResultType"] != DBNull.Value)
                                    chatRoomStatus = Convert.ToInt32(reader["PCRecordActionResultType"]);

                            item.MessageData = reader["Comment"].ToString();

                            //Los comentarios que tienen el campo rctModifiedByUserId = NULL, son los enviados por el cliente
                            if (reader["commentid"] != DBNull.Value)
                            {
                                item.IsFriend = true;
                                item.Talker = reader["rctusername"].ToString();
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
                }
                
                return result;
            }


            catch (Exception ex)
            {
                throw SecPortalException.ProcessException(ex, typeof(EpironChatDAC), "EpironChatConnectionString");
            }
    
        }



        
    }
}