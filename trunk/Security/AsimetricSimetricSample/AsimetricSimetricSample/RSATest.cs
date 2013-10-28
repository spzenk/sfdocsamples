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

        /// <summary>
        /// Creates and returns an XML string containing the key of the current System.Security.Cryptography.RSA object
        /// </summary>
        /// <returns></returns>
        public string ObtenerLlavePublica()
        {
            return this.objRSA.ToXmlString(false);
        }


        public string DesEncriptar(byte[] bytEncriptado, bool blnConSimetrico)
        {
            if (blnConSimetrico)
            {
                //Array que continen la clave simetrica encriptada
                byte[] keyArray = new byte[objRSA.KeySize / 8];
                //Array que continen la encriptacion simetrica del contenido
                byte[] encrypted = new byte[bytEncriptado.Length - keyArray.Length];

                //Copia la clave asimetrica
                Array.Copy(bytEncriptado, 0, keyArray, 0, keyArray.Length);
                //Copia  de contenido simetrico
                Array.Copy(bytEncriptado, keyArray.Length, encrypted, 0, encrypted.Length);
                
                //Obtinen la clave Simetrica desencripptada que utilizara el Algoritmo simetrico
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
