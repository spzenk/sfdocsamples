using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace AsimetricSimetricSample
{
   
    public class RSATest
    {
        private RSACryptoServiceProvider objRSA = null;

        public RSATest()
        {
            this.objRSA = new RSACryptoServiceProvider(1024);
        }

        public string ObtenerLlavePublica()
        {
            return this.objRSA.ToXmlString(false);
        }

        public string DesEncriptar(byte[] bytEncriptado, bool blnConSimetrico)
        {
            if (blnConSimetrico)
            {
                byte[] keyArray = new byte[objRSA.KeySize / 8];
                byte[] encrypted = new byte[bytEncriptado.Length - keyArray.Length];
                Array.Copy(bytEncriptado, 0, keyArray, 0, keyArray.Length);
                Array.Copy(bytEncriptado, keyArray.Length, encrypted, 0, encrypted.Length);

                byte[] simKey = this.objRSA.Decrypt(keyArray, false);

                return MiRijndael.Desencriptar(encrypted, simKey);
            }
            else
            {
                return System.Text.Encoding.UTF8.GetString(this.objRSA.Decrypt(bytEncriptado, false));
            }
        }
    } 
}
