using EpironChatLogs;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;
using WebChat.Common;

namespace WebChat.Logic.DAC
{
    public class ChatMessageDAC
    {
        
        /// <summary>
        /// Retorna todos los mensajes de un chatRoom
        /// </summary>
        /// <param name="roomid"></param>
        /// <returns></returns>
        public static List<Message> RecieveMessage(int homePhone, HttpContextBase context)
        {
            List<Message> result = new List<Message>();
            using (EpironChat_logsDataContext db = new EpironChat_logsDataContext())
            {
                var msgs = from messages in db.SMSMessage
                           where messages.HomePhone.Equals(homePhone)
                           select messages;



                foreach (SMSMessage msg in msgs.ToList())
                {
                    result.Add(new Message(msg, context));
                }
                return result;
            }

        }
        

           /// <summary>
        /// [Chat].[ChatEmailMessage_i]
        /// </summary>
        /// <param name="phoneId"></param>
        /// <param name="message"></param>
        internal static int InsertMessage(int chatRoomId, int chatUserId, string message, int? recordId)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase("CnnStringKey");
                wCmd = wDataBase.GetStoredProcCommand("ChatUser_i");
                
                /// ChatUserId
                wDataBase.AddOutParameter(wCmd, "ChatMessageId", System.Data.DbType.Int32, 4);

                wDataBase.AddInParameter(wCmd, "ChatRoomId", System.Data.DbType.Int32, chatRoomId);

                wDataBase.AddInParameter(wCmd, "chatUserId", System.Data.DbType.Int32, chatUserId);

                wDataBase.AddInParameter(wCmd, "message", System.Data.DbType.String, message);


                wDataBase.ExecuteNonQuery(wCmd);
                return (System.Int32)wDataBase.GetParameterValue(wCmd, "ChatMessageId");
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

    }
}