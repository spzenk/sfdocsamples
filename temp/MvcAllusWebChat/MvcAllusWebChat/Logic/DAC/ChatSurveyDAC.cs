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
    public class ChatSurveyDAC
    {
        
       
        

        /// <summary>
        /// [ChatSurvey_i]
        /// </summary>
        /// <param name="phoneId"></param>
        /// <param name="message"></param>
        internal static void InsertChatSurvey( int pRecordId, Guid pRandomGuid)
        {
            Database dataBase = null;
            DbCommand cmd = null;

            //try
            //{
                dataBase = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                using (cmd = dataBase.GetStoredProcCommand("[Chat].[ChatSurvey_i]"))
                {
                    //dataBase.AddOutParameter(cmd, "ChatMessageId", System.Data.DbType.Int32, 4);
                    dataBase.AddInParameter(cmd, "RecordId", System.Data.DbType.Int32, pRecordId);
                    dataBase.AddInParameter(cmd, "RamdomId", System.Data.DbType.Guid, pRandomGuid);

                    dataBase.ExecuteNonQuery(cmd);
                    //return (System.Int32)dataBase.GetParameterValue(cmd, "ChatMessageId");
                }
            //}
            //catch (Exception ex)
            //{
            //    throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            //}
        }

    }
}