using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;

namespace AsimetricSimetric_hash_Ent_Libs
{
    public class HashPasswords
    {
        const String HashProviderName = "SHA256Managed";
         const String HashCredenctialFormat = "{0}-->{1}";

         public static string CreateHash(string texto)
         {
             string textoHash = Cryptographer.CreateHash(HashProviderName, texto);
             return textoHash;
         }

         public static string CreateHash(String userName, String password)
         {
             return CreateHash(Get_Credentials_Pathern(userName, password));
             
         }
        public static string Get_Credentials_Pathern(String userName ,String password)
        {
            return String.Format(HashCredenctialFormat, password, userName);
        }

        public static bool CompararHash(string textoProbar, string textoHash)
        {
            return Cryptographer.CompareHash(HashProviderName, textoProbar, textoHash);
            
        }
        public static bool CompararHash(String userName, String password, string textoHash)
        {
            return CompararHash(Get_Credentials_Pathern(userName, password), textoHash);
            
        }
    }


   
}
