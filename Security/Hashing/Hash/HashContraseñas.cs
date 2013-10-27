using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace AsimetricSimetric_Client
{
    public class HashContraseñas
    {
         const String HashCredenctialFormat = "{0}-->{1}";
        public static bool CompareByteArray(Byte[] arrayA, Byte[] arrayB)
        {
            if (arrayA.Length != arrayB.Length)
                return false;

            for (int i = 0; i <= arrayA.Length - 1; i++)
                if (!arrayA[i].Equals(arrayB[i]))
                    return false;
            return true;
        }
        public static byte[] CreateHash(string strPassword, string strSalt, int intIteraciones)
        {
            string _strPasswordSalt = strPassword + strSalt;
            SHA256Managed sha256 = new SHA256Managed();
            byte[] _objTemporal = null;

            try
            {
                _objTemporal = System.Text.Encoding.UTF8.GetBytes(_strPasswordSalt);
                for (int i = 0; i <= intIteraciones - 1; i++)
                    _objTemporal = sha256.ComputeHash(_objTemporal);
            }
            finally { sha256.Clear(); }

            return _objTemporal;
        }

        public static string Get_Credentials_Pathern(String userName ,String password)
        {
            return String.Format(HashContraseñas.HashCredenctialFormat, password, userName);
        }
    }


    public class HashValidacion
    {
        public static byte[] CreateHash(string strTexto, byte[] objKey)
        {
            HMACSHA1 _objHMACSHA = new HMACSHA1(objKey);
            try
            {
                return _objHMACSHA.ComputeHash(Encoding.UTF8.GetBytes(strTexto));
            }
            finally
            {
                _objHMACSHA.Clear();
            }
        }

        public static bool CompareByteArray(Byte[] arrayA, Byte[] arrayB)
        {
            if (arrayA.Length != arrayB.Length)
                return false;

            for (int i = 0; i <= arrayA.Length - 1; i++)
                if (!arrayA[i].Equals(arrayB[i]))
                    return false;
            return true;
        }
    } 
}
