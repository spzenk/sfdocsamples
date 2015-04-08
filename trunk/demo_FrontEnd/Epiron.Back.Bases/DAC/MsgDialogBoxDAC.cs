using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data;
using Epiron.Back.Bases.BE;

namespace Epiron.Back.Bases.DAC
{
    public class MsgDialogBoxDAC 
    {
        public static MsgDialogBoxList MsgDialogBoxGet(string pMsgDialogBoxName, int? pLanguageId)
        {
            try
            {
                Database wDatabase = null;
                DbCommand wCmd = null;

                MsgDialogBoxList wMsgDialogBoxList = new MsgDialogBoxList();
                MsgDialogBoxBE wMsgDialogBoxBE  = null;

                //wDatabase = new SqlDatabase(Common.CnnString);
                wDatabase = DatabaseFactory.CreateDatabase(Common.EpironConnectionStringKey);

                wCmd = wDatabase.GetStoredProcCommand("Config.W32MsgDialogBox_s");

                if (pLanguageId != null)
                    wDatabase.AddInParameter(wCmd, "LanguageId", System.Data.DbType.Int32, pLanguageId);
                if (pMsgDialogBoxName != null)
                    wDatabase.AddInParameter(wCmd, "MsgDialogBoxName", System.Data.DbType.Boolean, pMsgDialogBoxName);

                IDataReader reader = wDatabase.ExecuteReader(wCmd);

                while (reader.Read())
                {
                    wMsgDialogBoxBE = new MsgDialogBoxBE();

                    if (reader["LanguageId"] != DBNull.Value)
                        wMsgDialogBoxBE.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                    if (reader["MsgDialogBoxName"] != DBNull.Value)
                        wMsgDialogBoxBE.MsgDialogBoxName = Convert.ToString(reader["MsgDialogBoxName"]);
                    if (reader["MsgDialogBoxActiveFlag"] != DBNull.Value)
                        wMsgDialogBoxBE.MsgDialogBoxActiveFlag = Convert.ToBoolean(reader["MsgDialogBoxActiveFlag"]);
                    if (reader["MsgDialogBoxCreatedRow"] != DBNull.Value)
                        wMsgDialogBoxBE.MsgDialogBoxCreatedRow = Convert.ToDateTime(reader["MsgDialogBoxCreatedRow"]);
                    if (reader["MsgDialogBoxDescrip"] != DBNull.Value)
                        wMsgDialogBoxBE.MsgDialogBoxDescrip = Convert.ToString(reader["MsgDialogBoxDescrip"]);
                    if (reader["MsgDialogBoxId"] != DBNull.Value)
                        wMsgDialogBoxBE.MsgDialogBoxId = Convert.ToInt32(reader["MsgDialogBoxId"]);

                    wMsgDialogBoxList.Add(wMsgDialogBoxBE);

                }

                reader.Dispose();
                return wMsgDialogBoxList;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
