using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Configuration;


namespace Fwk.SocialNetworks.Data
{
    public class Helper
    {

        #region [Schema Methods]
  
 

        /// <summary>
        /// Este es el que deserealiza posta
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        internal static fql_query_response DeserializeResponse(TextReader pReader, out error_response error)
        {
            fql_query_response wResponses = null;
            error = null;
            string xml = Fwk.HelperFunctions.FileFunctions.GetTextFromReader(pReader);
            if (xml.Contains("<error_response"))
                error = (error_response)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(error_response), xml);
            else
                wResponses = (fql_query_response)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(fql_query_response), xml);

            //  XmlSerializer wSerializer = new XmlSerializer(typeof(fql_query_response));
            //wResponses = (fql_query_response)wSerializer.Deserialize(pReader);

            return wResponses;
        }

    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pReader"></param>
        internal static Exception MapErrorAndThrowException(error_response wError)
        {
            //error_response wError = DeserializeError(pReader);
 
            return new Exception(string.Concat("Error: ", wError.error_msg[0], " (cod: ", wError.error_code[0], ")."));
        }
        #endregion


   


    }
    public class Constants
    {
        internal static readonly Int32 SocialNetworkID = 1;

        internal static readonly String Cnnstring = ConfigurationManager.ConnectionStrings["socialnet"].ConnectionString;

        public  static readonly DateTime LogSince = new DateTime(2010, 8, 20);
    }
    public class Enums
    {
        public enum SocialNetwork { Facebook = 1, Twitter = 2 }
    }
}