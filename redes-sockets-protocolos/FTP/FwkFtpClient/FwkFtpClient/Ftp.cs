using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace FwkFtpClient
{
    class Ftp
    {

        void subir()
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;


            try
            {

                //Ajustes necesarios para establecer una conexión con el servidor
                this.ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://ServerIP/FileName"));
                this.ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                this.ftpRequest.Proxy = null;
                this.ftpRequest.UseBinary = true;
                this.ftpRequest.Credentials = new NetworkCredential("UserName", "Password");


                //Selección de archivo a ser cargado
                FileInfo ff = new FileInfo("File Local Path With File Name");//e.g.: c:\\Test.txt
                byte[] fileContents = new byte[ff.Length];


                //destruirá el objeto inmediatamente después de ser utilizado

                using (FileStream fr = ff.OpenRead())
                {
                    fr.Read(fileContents, 0, Convert.ToInt32(ff.Length));
                }


                using (Stream writer = ftpRequest.GetRequestStream())
                {
                    writer.Write(fileContents, 0, fileContents.Length);
                }

                //Obtiene el FtpWebResponse de la operación de carga
                this.ftpResponse = (FtpWebResponse)this.ftpRequest.GetResponse();
                Response.Write(this.ftpResponse.StatusDescription); //Display response
            }

            catch (WebException webex)
            {
                this.Message = webex.ToString();
            }
        }
    }
}
