﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using System.IO;
using System.Security.Cryptography;
using Fwk.Exceptions;

namespace Symetric_EntLibs_5._0
{
    /// <summary>
    /// Encriptador eue utiliza el algoritmo simetrico RijndaelManaged
    /// </summary>
     static class SymetricCrypter_Rijndael
    {

        static SymetriCypher<RijndaelManaged> cryptopher;

        /// <summary>
        /// 
        /// </summary>
        static SymetricCrypter_Rijndael()
        {
            cryptopher = new SymetriCypher<RijndaelManaged>();
        }

        /// <summary>
        /// Encripta una cadena de caracteres.-
        /// </summary>
        /// <param name="val">Cadena a encriptar</param>
        /// <returns>Cadena encriptada</returns>
        public static string Encrypt(string val)
        {
            return cryptopher.Encrypt(val);
        }

        /// <summary>
        /// Desencripta una cadena de caracteres.-
        /// </summary>
        /// <param name="val">Cadena encriptada</param>
        /// <returns>Cadena desencriptada</returns>
        public static string Dencrypt(string val)
        {
            return cryptopher.Dencrypt(val);
        }

        /// <summary>
        /// Crea una archivo que contiene la semilla de encriptacion.- En base a este archivo el proveedor de encriptacion 
        /// realizara la criptografia.
        /// Esta sobrecarga abre un dialog box de creacion de archivo.-
        /// </summary>
        public static void CreateKeyFile()
        {
            cryptopher.CreateKeyFile();
        }

        /// <summary>
        /// Crea una archivo que contiene la semilla de encriptacion.- En base a este archivo el proveedor de encriptacion 
        /// realizara la criptografia.
        /// </summary>
        /// <param name="keyFileName">Nombre del archivo que contrendra la semilla.-</param>
        public static void CreateKeyFile(string keyFileName)
        {
            cryptopher.CreateKeyFile(keyFileName);
        }



    }


    /// <summary>
    /// Clase generica de encriptacion
     /// <![CDATA[SymetriCypher<T>]]>
    /// </summary>
     /// <typeparam name="T"><see cref="SymmetricAlgorithm"/></typeparam>
     public  class SymetriCypher<T> : Symetric_EntLibs_5._0.ISymetriCypher where T : SymmetricAlgorithm
     {
         private string keyFileName;

         public string KeyFileName
         {
             get { return keyFileName; }
             set { keyFileName = value; }
         }

         SymmetricAlgorithmProvider _SymmetricAlgorithmProvider;


         /// <summary>
         /// Encripta una cadena de caracteres.-
         /// </summary>
         /// <param name="val">Cadena a encriptar</param>
         /// <returns>Cadena encriptada</returns>
         public string Encrypt(string val)
         {
             CreateSymmetricAlgorithmProvider();
             byte[] decryptedBin = Encoding.UTF8.GetBytes(val);
             try
             {
                 return Convert.ToBase64String(_SymmetricAlgorithmProvider.Encrypt(decryptedBin));
             }

             catch (CryptographicException e)
             {
                 TechnicalException te = new TechnicalException("Clave de encriptacion no es la correcta ");
                 ExceptionHelper.SetTechnicalException<SymetriCypher<T>>(te);
                 te.ErrorId = "4402";
                 throw te;
             }
         }

         /// <summary>
         /// Desencripta una cadena de caracteres.-
         /// </summary>
         /// <param name="val">Cadena encriptada</param>
         /// <returns>Cadena desencriptada</returns>
         public string Dencrypt(string val)
         {
             CreateSymmetricAlgorithmProvider();
             byte[] cryptedBin = Convert.FromBase64String(val);
             try
             {
                 return Encoding.UTF8.GetString(_SymmetricAlgorithmProvider.Decrypt(cryptedBin));
             }
             catch (CryptographicException)
             {
                 TechnicalException te = new TechnicalException("Clave de encriptacion no es la correcta ");
                 ExceptionHelper.SetTechnicalException<SymetriCypher<T>>(te);
                 te.ErrorId = "4402";
                 throw te;
             }
             catch (Exception e)
             { 
            
                 TechnicalException te = new TechnicalException("Error al intentar desencriptar",e);
                 ExceptionHelper.SetTechnicalException<SymetriCypher<T>>(te);
                 te.ErrorId = "4402";
                 throw te;
             }
             
         }


         /// <summary>
         /// Crea una archivo que contiene la semilla de encriptacion.- En base a este archivo el proveedor de encriptacion 
         /// realizara la criptografia.
         /// Esta sobrecarga abre un dialog box de creacion de archivo.-
         /// </summary>
         public string CreateKeyFile()
         {

             keyFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_New(keyFileName, "Key Files(*.key)|*.key", false);

             return CreateKeyFile(keyFileName);


         }

         /// <summary>
         /// Crea una archivo que contiene la semilla de encriptacion.- En base a este archivo el proveedor de encriptacion 
         /// realizara la criptografia.
         /// </summary>
         /// <param name="pkeyFileName">Nombre del archivo que contrendra la semilla.-</param>
         public string CreateKeyFile(string pkeyFileName)
         {
             keyFileName = pkeyFileName;
             if (!string.IsNullOrEmpty(keyFileName))
             {

                 ProtectedKey symmetricKey = KeyManager.GenerateSymmetricKey(typeof(T), DataProtectionScope.LocalMachine);
                 using (FileStream keyStream = new FileStream(keyFileName, FileMode.Create))
                 {
                     KeyManager.Write(keyStream, symmetricKey);
                 }
             }
             return keyFileName;
         }


         void CreateSymmetricAlgorithmProvider()
         {
             if (_SymmetricAlgorithmProvider != null) return;
             TechnicalException te;
             if (string.IsNullOrEmpty(keyFileName))
             {
                 keyFileName = System.Configuration.ConfigurationManager.AppSettings["CrypKeyFile"];
             }
             if (string.IsNullOrEmpty(keyFileName))
             {
                 te = new TechnicalException("La clave de encriptacion no puede ser nula");
                 ExceptionHelper.SetTechnicalException<SymetriCypher<T>>(te);
                 te.ErrorId = "4401";
                 throw te;
             }

             if (!File.Exists(keyFileName))
             {
                                  te = new TechnicalException(string.Concat("La clave de encriptacion ", keyFileName, " no existe"));
                 ExceptionHelper.SetTechnicalException<SymetriCypher<T>>(te);
                 te.ErrorId = "4401";
                 throw te;

             }
             try
             {
                 if (_SymmetricAlgorithmProvider == null)
                     _SymmetricAlgorithmProvider = new SymmetricAlgorithmProvider(typeof(T), keyFileName, DataProtectionScope.LocalMachine);
             }
             catch (Exception e)
             {
                 te = new TechnicalException("Error al intentar crear SymmetricAlgorithmProvider ", e);
                 ExceptionHelper.SetTechnicalException<SymetriCypher<T>>(te);
                 te.ErrorId = "4400";
                 throw te;
             }

         }
     }


    /// <summary>
    /// Fabrica de SymetriCypher <![CDATA[SymetriCypher<T>]]>
    /// </summary>
    public static class SymetricCypherFactory
    {
        static Dictionary<string, ISymetriCypher> list;

        /// <summary>
        /// Crea el diccionario de ISymetriCypher
        /// </summary>
        static SymetricCypherFactory()
        {
            list = new Dictionary<string, ISymetriCypher>();
        }

        /// <summary>
        /// Busca un criptographer determinado por medio de su nombre de archivo de encriptacion y tipo de algoritmo simetrico
        /// </summary>
        /// <typeparam name="T">Tipo de algoritmo simetrico</typeparam>
        /// <param name="keyFileName">nombre de archivo de encriptacion </param>
        /// <returns>Argoritmo <see cref="SymetriCypher"/></returns>
        public static SymetriCypher<T> Get<T>(string keyFileName) where T : SymmetricAlgorithm
        {
            if (string.IsNullOrEmpty(keyFileName))
            {

                TechnicalException te = new TechnicalException("La clave de encriptacion no puede ser nula");
                ExceptionHelper.SetTechnicalException<SymetriCypher<T>>(te);
                te.ErrorId = "4401";
                throw te;
            }

            SymetriCypher<T> symetriCypher = null;
            
            if (list.ContainsKey(string.Concat(keyFileName,typeof(T).FullName)))
                symetriCypher = (SymetriCypher<T>)list[string.Concat(keyFileName, typeof(T).FullName)];
            else
            {
                symetriCypher = new SymetriCypher<T>();
                symetriCypher.KeyFileName = keyFileName;
                list.Add(string.Concat(keyFileName, typeof(T).FullName), symetriCypher);
            }

            return symetriCypher;
        }

    }
}
