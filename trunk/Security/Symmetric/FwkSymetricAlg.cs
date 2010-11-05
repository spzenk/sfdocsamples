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

        //key,iv
        static string k = "SESshxdRu3p4ik3IOxM6/qAWmmTYUw8N1ZGIh1Pgh2w=$pQgQvA49Cmwn8s7xRUxHmA==";

        static FwkSymetricAlg()
        {
            _SymmetricAlgorithm = new RijndaelManaged();

            //_SymmetricAlgorithm.Key = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["key"]);
            //_SymmetricAlgorithm.IV = Convert.FromBase64String(System.Configuration.ConfigurationManager.AppSettings["IV"]);
            
            _SymmetricAlgorithm.Key = Convert.FromBase64String(k.Split('$')[0]);
            _SymmetricAlgorithm.IV = Convert.FromBase64String(k.Split('$')[1]);
        }

        public static string  GetNewK()
        {
            //Create a new key and initialization vector.
            _SymmetricAlgorithm.GenerateKey();
            _SymmetricAlgorithm.GenerateIV();

            return string.Concat ( Convert.ToBase64String(_SymmetricAlgorithm.Key), "$",Convert.ToBase64String(_SymmetricAlgorithm.IV));
            
        }



        public static string Encrypt(string plainText, string k)
        {
            return Encrypt(plainText, Convert.FromBase64String(k.Split('$')[0]), Convert.FromBase64String(k.Split('$')[1]));
        }

        public static string Encrypt(string plainText)
        {
            return Encrypt(plainText, _SymmetricAlgorithm.Key, _SymmetricAlgorithm.IV);
        }

        static string Encrypt(string plainText, byte[] rgbKey, byte[] rgbIV)
        {
            //Get an encryptor.
            ICryptoTransform encryptor = _SymmetricAlgorithm.CreateEncryptor(rgbKey, rgbIV);


            //Encrypt the data.
            MemoryStream msEncrypt = new MemoryStream();


            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                {

                    //Write all data to the stream.
                    swEncrypt.Write(plainText);
                }
            }

            return Convert.ToBase64String(msEncrypt.ToArray());
        }


        public static string Dencrypt(string cipherText)
        {
            return Dencrypt(cipherText, _SymmetricAlgorithm.Key, _SymmetricAlgorithm.IV);
        }
        public static string Dencrypt(string cipherText, string k)
        {
            return Dencrypt(cipherText, Convert.FromBase64String(k.Split('$')[0]), Convert.FromBase64String(k.Split('$')[1]));
        }

        public static string Dencrypt(string cipherText, byte[] rgbKey, byte[] rgbIV)
        {
            byte[] cipherTextBin = Convert.FromBase64String(cipherText);

            ICryptoTransform decryptor = _SymmetricAlgorithm.CreateDecryptor(rgbKey, rgbIV);

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
