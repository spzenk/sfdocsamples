using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace EntLib6_MultiDB
{
   public  class dac
    {
        public static void Get(int groupId,string cnnstring)
        {
            Database database = null;
        
            try
            {
               
                database = DatabaseFactory.CreateDatabase(cnnstring);
                
                using (DbCommand cmd = database.GetStoredProcCommand("Product_g_Id"))
                {
                    database.AddInParameter(cmd, "productid", DbType.Int32, groupId);

                    using (IDataReader wReader = database.ExecuteReader(cmd))
                    {
                        while (wReader.Read())
                        {
                       
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            
        }
    }
}
