using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography.Xml;
using System.Xml;
using System.Security.Cryptography;

namespace XmlSimetrico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Doc"></param>
        /// <param name="ElementName">Ruta completa del elemento a encriptar
        /// Ejemplos:
        /// <example>
        /// Encripta el precio los libros cuyo precio es mayor a 35
        /// /bookstore/book[price>35]/price 
        /// 
        /// Busca el grupos "ValidationExceptionMessage" y dentro de este la clave con nombre "MaxLenghtField" 
        ///         "/ConfigurationFile/Groups/Group[@name='ValidationExceptionMessage']/Keys/Key[@name='MaxLenghtField']"
        ///         
        /// 
        /// "//EXAMPLE/CUSTOMER[substring(@type,1,2) ='DE']"
        /// "//EXAMPLE/CUSTOMER[contains(@type,'DECEA')]"
        /// </example>
        /// </param>
        /// <param name="Key"></param>
        public static string Encrypt(string xml, string elementPath, SymmetricAlgorithm symmetricAlgorithm)
        {

            // Check the arguments.  
            if (string.IsNullOrEmpty(xml))
                throw new ArgumentNullException("xml");
            if (string.IsNullOrEmpty(elementPath))
                throw new ArgumentNullException("elementPath");
            if (symmetricAlgorithm == null)
                throw new ArgumentNullException("SymmetricAlgorithm");


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml(xml);

            ///bookstore/book[price>35]/price 
            /// "/ConfigurationFile/Groups/Group[@name='ValidationExceptionMessage']/Keys/Key[@name='MaxLenghtField']"
            XmlElement elementToEncrypt = xmlDoc.SelectSingleNode(elementPath) as XmlElement;

            // Throw an XmlException if the element was not found.
            if (elementToEncrypt == null)
            {
                throw new XmlException("The specified element was not found");

            }


            //////////////////////////////////////////////////
            // Creo una instancia de EncryptedXml y la uso 
            // para encriptar XmlElement con lka clave simetrica
            //////////////////////////////////////////////////
            EncryptedXml eXml = new EncryptedXml();

            
            byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, symmetricAlgorithm, false);

            // Construct an EncryptedData object and populate
            // it with the desired encryption information.
            EncryptedData edElement = new EncryptedData();
            edElement.Type = EncryptedXml.XmlEncElementUrl;
            edElement.EncryptionMethod = GetEncrypTionMethod(symmetricAlgorithm);

            //// Add the encrypted element data to the EncryptedData object.
            edElement.CipherData.CipherValue = encryptedElement;

            // Create a new KeyInfo element.
            edElement.KeyInfo = new KeyInfo();


            //// Encrypt the session key and add it to an EncryptedKey element.
            //EncryptedKey ek = new EncryptedKey();


            //// Create a new KeyInfoName element.
            //KeyInfoName kin = new KeyInfoName();

            //// Specify a name for the key.
            //kin.Value = KeyName;

            //// Add the KeyInfoName element to the 
            //// EncryptedKey object.
            //ek.KeyInfo.AddClause(kin);

            // Add the encrypted key to the 
            // EncryptedData object.

            //edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));




            // Replace the element from the original XmlDocument   object with the EncryptedData element.
            EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
            symmetricAlgorithm.Clear();
            xml = xmlDoc.InnerXml;
            xmlDoc = null;
            return xml;
        }

        public static string Decrypt(string xmlEncrypted, string elementPath, SymmetricAlgorithm symmetricAlgorithm)
        {

            // Check the arguments.  
            if (string.IsNullOrEmpty(xmlEncrypted))
                throw new ArgumentNullException("xml");
            if (string.IsNullOrEmpty(elementPath))
                throw new ArgumentNullException("elementPath");
            if (symmetricAlgorithm == null)
                throw new ArgumentNullException("SymmetricAlgorithm ");


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml(xmlEncrypted);


            // Find the EncryptedData element in the XmlDocument.
            
            XmlNodeList encryptedElementxmlDoc = xmlDoc.GetElementsByTagName("EncryptedData");

            // If the EncryptedData element was not found, throw an exception.
            if (encryptedElementxmlDoc == null)
            {
                throw new XmlException("The EncryptedData element was not found.");
            }
            EncryptedData edElement;
            EncryptedXml exml = new EncryptedXml(xmlDoc);
            // Add a key-name mapping.
            // This method can only decrypt documents
            // that present the specified key name.
            exml.AddKeyNameMapping("", symmetricAlgorithm);


            exml.DecryptDocument();
      
            //foreach (XmlNode node in encryptedElementxmlDoc)
            //{


            //    // Create an EncryptedData object and populate it.
            //    edElement = new EncryptedData();
            //    edElement.LoadXml(node as XmlElement);
            //    exml = new EncryptedXml();

            //    exml.DecryptDocument();

            //    //// Decrypt the element using the symmetric key.
            //    //byte[] rgbOutput = exml.DecryptData(edElement, symmetricAlgorithm);

            //    //// Replace the encryptedData element with the plaintext XML element.
            //    //exml.ReplaceData(node as XmlElement, rgbOutput);
            //}



            symmetricAlgorithm.Clear();
            xmlEncrypted = xmlDoc.InnerXml;
            xmlDoc = null;
            return xmlEncrypted;
        }
        public static void Decrypt(string xmlEncrypted, SymmetricAlgorithm Alg, string KeyName)
        {
     

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = true;
            xmlDoc.LoadXml(xmlEncrypted);


            // Create a new EncryptedXml object.
            EncryptedXml exml = new EncryptedXml(xmlDoc);

            // Add a key-name mapping.
            // This method can only decrypt documents
            // that present the specified key name.
            exml.AddKeyNameMapping(KeyName, Alg);

            // Decrypt the element.
            exml.DecryptDocument();

        }


        /// <summary>
        /// Crea un elemento EncryptionMethod 
        /// Determina que tipo de algotitmo es usado 
        /// </summary>
        /// <param name="symmetricAlgorithm"></param>
        /// <returns></returns>
        static EncryptionMethod GetEncrypTionMethod(SymmetricAlgorithm symmetricAlgorithm)
        {
            // Create an EncryptionMethod element so that the 
            // receiver knows which algorithm to use for decryption.
            // Determine what kind of algorithm is being used and
            // supply the appropriate URL to the EncryptionMethod element.

            string encryptionMethod = null;

            if (symmetricAlgorithm is TripleDES)
            {
                encryptionMethod = EncryptedXml.XmlEncTripleDESUrl;
            }
            else if (symmetricAlgorithm is DES)
            {
                encryptionMethod = EncryptedXml.XmlEncDESUrl;
            }
            if (symmetricAlgorithm is Rijndael)
            {
                switch (symmetricAlgorithm.KeySize)
                {
                    case 128:
                        encryptionMethod = EncryptedXml.XmlEncAES128Url;
                        break;
                    case 192:
                        encryptionMethod = EncryptedXml.XmlEncAES192Url;
                        break;
                    case 256:
                        encryptionMethod = EncryptedXml.XmlEncAES256Url;
                        break;
                }
            }
            else
            {
                // Throw an exception if the transform is not in the previous categories
                throw new CryptographicException("The specified algorithm is not supported for XML Encryption.");
            }

            return new EncryptionMethod(encryptionMethod);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RijndaelManaged key = new RijndaelManaged();

            string xml = Fwk.HelperFunctions.FileFunctions.OpenTextFile("ConfigurationManager.xml");

            try
            {
                textBox1.Text = Encrypt(xml, textBox2.Text, key);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void button2_Click(object sender, EventArgs e)
        {

            try
            {
                textBox1.Text = Decrypt(textBox1.Text, textBox2.Text, new RijndaelManaged());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Fwk.HelperFunctions.FileFunctions.SaveTextFile("ConfigurationManager.xml", textBox1.Text,false);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = Fwk.HelperFunctions.FileFunctions.OpenTextFile("ConfigurationManager.xml");
        }

    }
}
