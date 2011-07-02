using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Configuration;


namespace Fwk.SocialNetworks.Facebook
{
    public class Helper
    {

        #region [Schema Methods]
        internal static string GetTextFromReader(TextReader pReader)
        {
            StringBuilder list = new StringBuilder();
            
                string line;
                while ((line = pReader.ReadLine()) != null)
                {
                    list.Append(line); 
              
                }
                return list.ToString();
        }
        internal static fql_query_response DeserializeResponse(String pXmlPath)
        {
            error_response error = null;
            TextReader wReader = new StreamReader(pXmlPath);
            fql_query_response wResponses = DeserializeResponse(wReader,out error);

            wReader.Close();

            return wResponses;
        }

        /// <summary>
        /// Este es el que deserealiza posta
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        internal static fql_query_response DeserializeResponse(TextReader pReader, out error_response error)
        {
            fql_query_response wResponses = null;
            error = null;
            string xml = GetTextFromReader(pReader);
            if (xml.Contains("<error_response"))
                error = (error_response)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(error_response), xml);
            else
                wResponses = (fql_query_response)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(fql_query_response), xml);

            //  XmlSerializer wSerializer = new XmlSerializer(typeof(fql_query_response));
            //wResponses = (fql_query_response)wSerializer.Deserialize(pReader);

            return wResponses;
        }

        /// <summary>
        /// Deserializa los errores que pueden haber en Facebook.
        /// </summary>
        /// <param name="pReader"></param>
        /// <returns></returns>
        internal static error_response DeserializeError(StreamReader pReader)
        {
            XmlSerializer wSerializer = new XmlSerializer(typeof(error_response));
            error_response wErrorResponse = (error_response)wSerializer.Deserialize(pReader);
            
            return wErrorResponse;
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


        /// <summary>
        /// Convierte DateTime a UnixTimeStamp
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        internal static Int64 DateTimeToUnixTimeStamp(DateTime pDate)
        {
            TimeSpan wTimeSpan = pDate.Subtract(new DateTime(1970, 1, 1, 0, 0, 0, 0));
            return Convert.ToInt64(wTimeSpan.TotalSeconds);
        }


        /// <summary>
        /// Convierte UnixTimeStamp a DateTime
        /// </summary>
        /// <param name="unixtimestamp"></param>
        /// <returns></returns>
        internal static DateTime UnixTimeStampToDateTime(Int64 pUnixTimeStamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(pUnixTimeStamp);
        }


    }
    public class Constants
    {
        internal static readonly Int32 SocialNetworkID = 1;

        internal static readonly String Cnnstring = ConfigurationManager.ConnectionStrings["socialnet"].ConnectionString;

        internal static readonly DateTime LogSince = new DateTime(2010, 8, 20);
    }
    public class Enums
    {
        public enum SocialNetwork { Facebook = 1, Twitter = 2 }
    }
}