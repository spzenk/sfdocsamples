
using System;
using System.Collections;
using System.ComponentModel;

using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;

namespace Fwk.CodeGenerator
{

    public static class FwkGeneratorHelper
    {
        private static string _Entity_Property_tt;
        private static string _Entity_Member_tt;
        static FwkGeneratorHelper()
        {
            _Entity_Property_tt = Fwk.HelperFunctions.FileFunctions.OpenTextFile(@"Templates\Property.txt");
            _Entity_Member_tt = "private [TYPENAME] _[Property_Name]";
        }

     
        /// <summary>
        /// Obtiene el seteo de parametro que se envia a un store procedure  para Aplication Block,
        /// en forma de batch.-
        /// 
        /// </summary>
        /// <param name="pTableName">Nombre de tabla</param>
        /// <param name="pColumnName">Nombre de columna</param>
        /// <param name="pType">Tipo de SQL Server</param>
        ///<example>
        /// <code>
        /// 		
        ///   #region [[Property_Name]]
        ///   public [TYPENAME] [Property_Name]
        ///     {
        ///      get { return _[Property_Name]; }
        ///      set { _[Property_Name] = value;  }
        ///     }
        ///   #endregion
        /// 
        /// </code>
        /// </example>
        /// <returns>string</returns>
        public static string GetCsharpProperty(string pFieldName, string pType)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder(_Entity_Property_tt);

            switch (pType.ToUpper())
            {
                case "BIT":
                   
                    str.Replace(CommonConstants.CONST_TYPENAME, "bool");
                    break;
                case "REAL":
                case "NUMERIC":
                case "BIGINT":
                case "SMALLINT":
                case "INT":
                case "TINYINT":
                    str.Replace(CommonConstants.CONST_TYPENAME, "int");
                    break;
                case "MONEY":
                case "SMALLMONEY":
                case "DECIMAL":
                case "FLOAT":
                    str.Replace(CommonConstants.CONST_TYPENAME, "decimal");
                    break;
                case "SMALLDATETIME":
                case "DATETIME":
                    str.Replace(CommonConstants.CONST_TYPENAME, "datetime");
                    break;
                case "TEXT":
                case "CHAR":
                case "VARCHAR":
                case "NVARCHAR":
                    str.Replace(CommonConstants.CONST_TYPENAME, "string");
                    break;
                ///TODO:Ver paso de binarios por batch
                //case "IMAGE":
                //case "VARBINARY":
                //case "BINARY":
                //    str.Append(_ParameterBatchBynary);
                //    break;

            }

            str.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, pFieldName);
        

            return str.ToString();
        }

        public static string GetCsharpMember(string pFieldName, string pType)
        {
            System.Text.StringBuilder str = new System.Text.StringBuilder(_Entity_Member_tt);

            switch (pType.ToUpper())
            {
                case "BIT":

                    str.Replace(CommonConstants.CONST_TYPENAME, "bool");
                    break;
                case "REAL":
                case "NUMERIC":
                case "BIGINT":
                case "SMALLINT":
                case "INT":
                case "TINYINT":
                    str.Replace(CommonConstants.CONST_TYPENAME, "int");
                    break;
                case "MONEY":
                case "SMALLMONEY":
                case "DECIMAL":
                case "FLOAT":
                    str.Replace(CommonConstants.CONST_TYPENAME, "decimal");
                    break;
                case "SMALLDATETIME":
                case "DATETIME":
                    str.Replace(CommonConstants.CONST_TYPENAME, "datetime");
                    break;
                case "TEXT":
                case "CHAR":
                case "VARCHAR":
                case "NVARCHAR":
                    str.Replace(CommonConstants.CONST_TYPENAME, "string");
                    break;
                ///TODO:Ver paso de binarios por batch
                //case "IMAGE":
                //case "VARBINARY":
                //case "BINARY":
                //    str.Append(_ParameterBatchBynary);
                //    break;

            }

            str.Replace(CommonConstants.CONST_ENTITY_PROPERTY_NAME, pFieldName);


            return str.ToString();
        }
    }

}
