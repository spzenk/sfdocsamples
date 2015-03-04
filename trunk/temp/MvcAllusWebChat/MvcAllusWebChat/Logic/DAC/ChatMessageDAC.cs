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
        /// [Chat].[ChatEmailMessage_i]
        /// </summary>
        /// <param name="phoneId"></param>
        /// <param name="message"></param>
        internal static int InsertMessage(int chatRoomId, int chatUserId, string message, int? recordId)
        {
            Database dataBase = null;
            DbCommand cmd = null;

            //try
            //{
                dataBase = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                using (cmd = dataBase.GetStoredProcCommand("[Chat].[ChatMessage_i]"))
                {
                    dataBase.AddOutParameter(cmd, "ChatMessageId", System.Data.DbType.Int32, 4);
                    dataBase.AddInParameter(cmd, "ChatRoomId", System.Data.DbType.Int32, chatRoomId);
                    dataBase.AddInParameter(cmd, "ChatUserId", System.Data.DbType.Int32, chatUserId);
                    dataBase.AddInParameter(cmd, "ChatMessage", System.Data.DbType.String, message);

                    dataBase.ExecuteNonQuery(cmd);
                    return (System.Int32)dataBase.GetParameterValue(cmd, "ChatMessageId");
                }
            //}
            //catch (Exception ex)
            //{
            //    throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            //}
        }

    }
}