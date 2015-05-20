using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Logging;
using System.Data.SqlClient;
using System.Data;
using Fwk.Exceptions;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;

namespace WebChat.Logic.DAC
{
    public class LogDAC
    {
        public static void Write(EpironEvent pEvent)
        {

            Database dataBase = null;
            DbCommand cmd = null;

            try
            {
                dataBase = DatabaseFactory.CreateDatabase(Common.Common.EpironChatLogs_CnnStringName);
                using (cmd = dataBase.GetStoredProcCommand("[dbo].[fwk_Logs_i]"))
                {
                    dataBase.AddInParameter(cmd, "Message", System.Data.DbType.String, pEvent.Message.Text);
                    dataBase.ExecuteNonQuery(cmd);
                }
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }
    }

    public class EpironEvent : Event
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid ServiceInstanceUnique { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? AsiDetailUnique { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? AccountDetailUnique { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public String ConnectionString { get; set; }

        /// <summary>
        /// Identificador del error respecto al sistema. No representa el id de base de datos
        /// </summary>
        public String EpironLogId { get; set; }
    }
}
