using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Symmetric
{
    public class FwkSymetricAlg
    {
        static RijndaelManaged _SymmetricAlgorithm;


        static FwkSymetricAlg()
        {
            _SymmetricAlgorithm = new RijndaelManaged();

            _SymmetricAlgorithm.Key = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["key"]);
            _SymmetricAlgorithm.IV = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["IV"]);
        }


        static void create()
        {
            //Create a new key and initialization vector.
            _SymmetricAlgorithm.GenerateKey();
            _SymmetricAlgorithm.GenerateIV();



            string s = Convert.ToBase64String(_SymmetricAlgorithm.Key);
            string s2 = Convert.ToBase64String(_SymmetricAlgorithm.IV);
        }


        public static string Encrypt(string value)
        {
            //ASCIIEncoding textConverter = new ASCIIEncoding();



            //Get an encryptor.
            ICryptoTransform encryptor = _SymmetricAlgorithm.CreateEncryptor(_SymmetricAlgorithm.Key, _SymmetricAlgorithm.IV);


            //Encrypt the data.
            MemoryStream msEncrypt = new MemoryStream();


            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {

                    //Write all data to the stream.
                    swEncrypt.Write(value);
                }
            }

            return Convert.ToBase64String(msEncrypt.ToArray());



        }



        public static string Dencrypt(string cipherText)
        {
            byte[] cipherTextBin = Convert.FromBase64String(cipherText);

            ICryptoTransform decryptor = _SymmetricAlgorithm.CreateDecryptor(_SymmetricAlgorithm.Key, _SymmetricAlgorithm.IV);

            using (MemoryStream msDecrypt = new MemoryStream(cipherTextBin))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }


        }
    }
}
