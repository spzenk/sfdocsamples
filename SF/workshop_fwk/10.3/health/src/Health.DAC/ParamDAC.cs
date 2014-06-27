using System;
using System.Text;
using System.Data;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Fwk.Bases;
using Health.Back.BE;
using System.Linq;
using Health.BE;


namespace Health.Back
{
    public class ParametroDAC
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pIdTipoParametro">Tipo (gasto, clase, forma pago etc)</param>
        /// <param name="pIdParametroRef">Relacion con otro param</param>
        /// <param name="vigente">Vigentes o no</param>
        /// <returns></returns>
        public static ParametroList GetByParams(int? pIdTipoParametro, int? pIdParametroRef, bool? vigente, string pCompanyId)
        {
            Database wDatabase = null;
            DbCommand wCmd = null;

            ParametroList list = new ParametroList();
            ParametroBE wParametroBE = null;
            try
            {
                wDatabase = DatabaseFactory.CreateDatabase(Common.CnnStringName);
                wCmd = wDatabase.GetStoredProcCommand("Parametro_s_ByParam");


                wDatabase.AddInParameter(wCmd, "IdTipoParametro", System.Data.DbType.Int32, pIdTipoParametro);
                wDatabase.AddInParameter(wCmd, "IdParametroRef", System.Data.DbType.Int32, pIdParametroRef);
                wDatabase.AddInParameter(wCmd, "Vigente", System.Data.DbType.Boolean, vigente);
                if (!String.IsNullOrEmpty(pCompanyId))
                    wDatabase.AddInParameter(wCmd, "CompanyId", System.Data.DbType.String, pCompanyId);
                
                IDataReader reader = wDatabase.ExecuteReader(wCmd);

                #region Fill wGastoBECollection
                while (reader.Read())
                {
                    wParametroBE = new ParametroBE();
                    
                      wParametroBE.IdParametro = Convert.ToInt32(reader["IdParametro"]);
                    if (reader["IdTipoParametro"] != DBNull.Value)
                        wParametroBE.IdTipoParametro = Convert.ToInt32(reader["IdTipoParametro"]);
                    
                        wParametroBE.Nombre = reader["Nombre"].ToString().Trim();

                    if (reader["IdParametroRef"] != DBNull.Value)
                        wParametroBE.IdParametroRef = Convert.ToInt32(reader["IdParametroRef"]);

                    list.Add(wParametroBE);

                }
                #endregion

                reader.Dispose();

                return list;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


     

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pParametroBE"></param>
        /// <param name="pUserId"></param>
        /// <param name="pCompanyId"></param>
        public static void Create(ParametroBE pParametroBE, Guid pUserId,string pCompanyId)
        {
            Database wDatabase = null;
            DbCommand wCmd = null;

            try
            {
                wDatabase = DatabaseFactory.CreateDatabase("xxxxxxxxxxxxxxxx");
                wCmd = wDatabase.GetStoredProcCommand("Parametro_i");

                wDatabase.AddOutParameter(wCmd, "IdParametro", DbType.Int32, 4);

                wDatabase.AddInParameter(wCmd, "@IdTipoParametro", System.Data.DbType.Int32, pParametroBE.IdTipoParametro.Value);

                if(pParametroBE.IdParametroRef!=null)
                    wDatabase.AddInParameter(wCmd, "@IdParametroRef", System.Data.DbType.Int32, pParametroBE.IdParametroRef);

                wDatabase.AddInParameter(wCmd, "Nombre", System.Data.DbType.String, pParametroBE.Nombre);

                wDatabase.AddInParameter(wCmd, "UserId", DbType.Guid, pUserId);

                wDatabase.AddInParameter(wCmd, "CompanyId", System.Data.DbType.String, pCompanyId);

                if (!string.IsNullOrEmpty(pParametroBE.Descripcion))
                    wDatabase.AddInParameter(wCmd, "Descripcion", System.Data.DbType.String, pParametroBE.Descripcion);

                wDatabase.ExecuteNonQuery(wCmd);
                pParametroBE.IdParametro = (System.Int32)wDatabase.GetParameterValue(wCmd, "IdParametro");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }






    }
}