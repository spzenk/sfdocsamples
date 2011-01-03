using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Fwk.Security.Cryptography;
using System.Data.SqlClient;

namespace Maria.DAC
{
    public class CommonDAC
    {
        static Dictionary<string, string> _OpenFiredomains;

        public   static Dictionary<string, string> OpenFiredomains
        {
            get { return _OpenFiredomains; }
            set { _OpenFiredomains = value; }
        }
        internal static ISymetriCypher ISymetriCypher;
        public static string SEED_K = "SESshxdRu3p4ik3IOxM6/qAWmmTYUw8N1ZGIh1Pgh2w=$pQgQvA49Cmwn8s7xRUxHmA==";//"sec.key";

        static CommonDAC()
        {
            ISymetriCypher = SymetricCypherFactory.Get<RijndaelManaged>(SEED_K);
        }


        public static bool IsEncrypted(System.Configuration.Configuration config)
        {
            if (config.AppSettings.Settings["crypt"] == null)
                return false;
            else
                return Convert.ToBoolean(config.AppSettings.Settings["crypt"].Value);
        }
        internal static bool IsEncrypted()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["crypt"] == null)
                return false;
            else
                return Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["crypt"]);
        }

        internal static SqlConnection GetCnn(string cnnName)
        {
            System.Data.SqlClient.SqlConnection cnn = null;
            if (IsEncrypted())
            {
                cnn = new System.Data.SqlClient.SqlConnection(ISymetriCypher.Dencrypt(System.Configuration.ConfigurationManager.ConnectionStrings[cnnName].ConnectionString));
            }
            else
            {
                cnn = new System.Data.SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[cnnName].ConnectionString);
            }

            return cnn;
        }
       
      
    }
}
