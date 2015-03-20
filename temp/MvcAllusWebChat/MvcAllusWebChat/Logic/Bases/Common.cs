using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using Fwk.Security.Cryptography;
using System.Data.SqlClient;
using Fwk.Logging;
using Fwk.Logging.Targets;
using Fwk.HelperFunctions;
using System.Net.Mail;
using System.Drawing;
using System.Drawing.Imaging;
using Fwk.Bases;

namespace WebChat.Common
{
    public class Common
    {
        static bool logOnWindowsEvent = true;
        public const string EpironChatLogs_CnnStringName = "EpironChat_LogsConnectionString";
        public const string EpironChat_CnnStringName = "EpironChat_ConnectionString";
        public static string CnnString_Entities = string.Empty;
        public static string EpironChatLogs_CnnString = string.Empty;

        public static string EpironChat_CnnString = string.Empty;
        
        static Boolean logOnFile = false;



        public static int RetriveMessage_Timer = 1000;
        public static int CheckOperators_Timer = 2000;
        public static int GetRecord_Timer = 2000;
        
        public static ISymetriCypher ISymetriCypher;
        public static string SEED_K = "SESshxdRu3p4ik3IOxM6/qAWmmTYUw8N1ZGIh1Pgh2w=$pQgQvA49Cmwn8s7xRUxHmA==";//"sec.key";
        //[11:48:26 a.m.] yulygasp: si el campo contiene uno de estos valores:indica que esta cerrado
        public static Int32[] ClosedStatus = new Int32[] { 201, 202, 205, 206, 207, 212, 214 };

        static Common()
        {
            //SI NO HAY WRAPPERS CARGA DIRECTAMENTE 

            EpironChatLogs_CnnString = System.Configuration.ConfigurationManager.ConnectionStrings[EpironChatLogs_CnnStringName].ConnectionString;
            EpironChat_CnnString = System.Configuration.ConfigurationManager.ConnectionStrings[EpironChat_CnnStringName].ConnectionString;
                //CnnString_Entities = System.Configuration.ConfigurationManager.ConnectionStrings["HealthEntities"].ConnectionString;
         

            //Fwk.Security.Cryptography.FwkSymetricAlg s = new FwkSymetricAlg(SEED_K);
            //ISymetriCypher = s;// SymetricCypherFactory.Cypher();// SymetricCypherFactory.Get<RijndaelManaged>(SEED_K);

            if (!String.IsNullOrEmpty(Fwk.Configuration.ConfigurationManager.GetProperty("Config", "RetriveMessage_Timer") ))
                RetriveMessage_Timer = Convert.ToInt32(Fwk.Configuration.ConfigurationManager.GetProperty("Config", "RetriveMessage_Timer"));
            if (!String.IsNullOrEmpty(Fwk.Configuration.ConfigurationManager.GetProperty("Config", "CheckOperators_Timer")))
                CheckOperators_Timer = Convert.ToInt32(Fwk.Configuration.ConfigurationManager.GetProperty("Config", "CheckOperators_Timer"));
            if (!String.IsNullOrEmpty(Fwk.Configuration.ConfigurationManager.GetProperty("Config", "GetRecord_Timer")))
                CheckOperators_Timer = Convert.ToInt32(Fwk.Configuration.ConfigurationManager.GetProperty("Config", "GetRecord_Timer"));
        }

        public static bool IsEncrypted(System.Configuration.Configuration config)
        {
            if (config.AppSettings.Settings["crypt"] == null)
                return false;
            else
                return Convert.ToBoolean(config.AppSettings.Settings["crypt"].Value);
        }
        public static bool IsEncrypted()
        {
            if (System.Configuration.ConfigurationManager.AppSettings["crypt"] == null)
                return false;
            else
                return Convert.ToBoolean(System.Configuration.ConfigurationManager.AppSettings["crypt"]);
        }

        public static SqlConnection GetCnn(string cnnName)
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

        /// <summary>
        /// Crea una entrada en el visor de eventos
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="eventType"></param>
        public static void LogWinEvent(string msg, Fwk.Logging.EventType eventType)
        {

            Fwk.Logging.Event ev = new Fwk.Logging.Event();
            ev.LogType = eventType;
            ev.Source = "";
            ev.Message.Text = msg;

            try
            {
                if (!logOnWindowsEvent)
                    StaticLogger.Log(TargetType.WindowsEvent, ev, string.Empty, string.Empty);

                Audit(msg);
            }
            catch (System.Security.SecurityException)
            {
                logOnWindowsEvent = false;

            }

        }

        /// <summary>
        /// Crea una entrada en log.xml
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="eventType"></param>
        public static void Audit(string msg)
        {
            if (!logOnFile) return;

            Fwk.Logging.Event ev = new Fwk.Logging.Event();
            ev.LogType = Fwk.Logging.EventType.Audit;
            
            ev.Message.Text = msg;
            //StaticLogger.Log(ev, string.Empty, DateFunctions.Get_Year_Mont_Day_String(DateTime.Now, '-'));

            try
            {
                StaticLogger.Log(ev);
            }
            catch (System.Security.SecurityException)
            {
                logOnFile = false;

            }
        }



        // Hash an input string and return the hash as
        // a 32 character hexadecimal string.
        public static string getMd5Hash(string input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5 md5Hasher = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public static bool verifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = getMd5Hash(input);
            return (hashOfInput.Equals(hash, StringComparison.OrdinalIgnoreCase));

        }

        /// <summary>
        /// Envia mail de acuerdo a las direcciones configuradas.
        /// </summary>
        public static void SendMail(string subjet, string body, string from, string to)
        {
            if (string.IsNullOrEmpty(from) || to.Length == 0)
                return;

            //Crea el nuevo correo electronico con el cuerpo del mensaje y el asutno.
            MailMessage wMailMessage = new MailMessage() { Body = body, Subject = subjet };
            wMailMessage.IsBodyHtml = true;

            //Asigna el remitente del mensaje de acuerdo a direccion obtenida en el archivo de configuracion.
            wMailMessage.From = new MailAddress(from);
            //Asigna los destinatarios del mensaje de acuerdo a las direcciones obtenidas en el archivo de configuracion.
            //foreach (string recipient in MailRecipients)
            //{
            wMailMessage.To.Add(new MailAddress(to));
            //}

            //SmtpClient wSmtpClient = new SmtpClient("smtp.gmail.com", 587);
            //wSmtpClient.EnableSsl = true;
            //NetworkCredential cred = new NetworkCredential("marcelo.oviedo", "santana668");
            //wSmtpClient.Credentials = cred;

            //Inicializa un nuevo cliente smtp de acuerdo a las configuraciones 
            //obtenidas en la seccion mailSettings del archivo de configuracion.
            SmtpClient wSmtpClient = new SmtpClient();


            //Envia el correo electronico.
            try
            {

                wSmtpClient.Send(wMailMessage);
            }
            catch (Exception) { }
        }
        /// <summary>
        /// Este c�digo se encargar� de longitud / anchura en el cambio de tama�o.
        /// </summary>
        /// <param name="originalFileName"></param>
        /// <param name="reducedFileName"></param>
        /// <param name="lnWidth"></param>
        /// <param name="lnHeight"></param>
        /// <returns></returns>
        public static void ImageChangeSize_AndSaveFile(string originalFileName, string reducedFileName, int newWidth, int newHeight)
        {

            using (Bitmap originalBMP = new Bitmap(originalFileName))
            {
                ImageFormat originalFormat = originalBMP.RawFormat;
                //decimal lnRatio;
                //int wNewWidth = newWidth;
                //int wNewHeight = newHeight;
                if (originalBMP.Width <= newWidth && originalBMP.Height <= newHeight)
                {
                    originalBMP.Save(reducedFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return;
                }

                //if (originalBMP.Width > originalBMP.Height)
                //{
                //    lnRatio = (decimal)newWidth / originalBMP.Width;
                //    lnNewWidth = newWidth;
                //    decimal lnTemp = originalBMP.Height * lnRatio;
                //    lnNewHeight = (int)lnTemp;
                //}
                //else
                //{
                //    lnRatio = (decimal)newHeight / originalBMP.Height;
                //    lnNewHeight = newHeight;
                //    decimal lnTemp = originalBMP.Width * lnRatio;
                //    lnNewWidth = (int)lnTemp;
                //}

                using (Bitmap bmpOut = new Bitmap(newWidth, newHeight))
                {
                    Graphics g = Graphics.FromImage(bmpOut);
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                    g.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
                    g.DrawImage(originalBMP, 0, 0, newWidth, newHeight);
                    //loBMP.Dispose();
                    bmpOut.Save(reducedFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }


        public static Image ImageChangeSize(Image originalImage, int newWidth, int newHeight)
        {

            using (Bitmap originalBMP = new Bitmap(originalImage))
            {
                ImageFormat originalFormat = originalBMP.RawFormat;
                //decimal lnRatio;
                //int wNewWidth = newWidth;
                //int wNewHeight = newHeight;
                //if (originalBMP.Width <= newWidth && originalBMP.Height <= newHeight)
                //{
                //    originalBMP.Save(reducedFileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                //    return originalBMP;
                //}

                //if (originalBMP.Width > originalBMP.Height)
                //{
                //    lnRatio = (decimal)newWidth / originalBMP.Width;
                //    lnNewWidth = newWidth;
                //    decimal lnTemp = originalBMP.Height * lnRatio;
                //    lnNewHeight = (int)lnTemp;
                //}
                //else
                //{
                //    lnRatio = (decimal)newHeight / originalBMP.Height;
                //    lnNewHeight = newHeight;
                //    decimal lnTemp = originalBMP.Width * lnRatio;
                //    lnNewWidth = (int)lnTemp;
                //}

                //using (Bitmap bmpOut = new Bitmap(wNewWidth, wNewHeight))
                //{
                Bitmap bmpOut = new Bitmap(newWidth, newHeight);
                Graphics g = Graphics.FromImage(bmpOut);
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.FillRectangle(Brushes.White, 0, 0, newWidth, newHeight);
                g.DrawImage(originalBMP, 0, 0, newWidth, newHeight);
                //loBMP.Dispose();
                //bmpOut.Save(@"c:\img.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);

                //Fwk.HelperFunctions.FileFunctions.SaveBinaryFile(@"d:\img.Jpeg",Fwk.HelperFunctions.TypeFunctions.ConvertImageToByteArray( bmpOut , ImageFormat.Jpeg));
                return (Image)bmpOut;
                //}
            }



        }

        
    }
    public class Enumerations
    {
        public enum ChatRoomStatus
        {
            Active = 1,
            ClosedByOwner = 2,
            ExpiredTimeout = 3,
            Waiting = 4,
            ClosedByOperator = 5,
        }
        public enum MenuTypeEmun
        {
            Leaft = 2,
            Submenu = 1
        }
    }
    
}
