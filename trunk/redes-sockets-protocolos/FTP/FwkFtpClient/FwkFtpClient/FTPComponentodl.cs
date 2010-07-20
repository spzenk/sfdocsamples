//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.IO;
//using System.Net.Sockets;
//using System.Net;
//using System.Drawing;
//using System.Windows.Forms;
//using System.Data.Odbc;
//using System.Reflection;
//using System.Runtime.Remoting.Messaging;

//namespace FwkFtpClient
//{



//    [ToolboxItem(true)]
//    [ToolboxBitmap(typeof(FTPComponentNew), "Resources.db5.png")]
//    public partial class FTPComponentNew : Component
//    {
//        #region events
//        public event DebugHandler OnDebugEvent;
//        public event ErrorHandler OnErrorEvent;
//        public event ObjectHandler OnCloseEvent;
//        public event ObjectHandler OnLoginEvent;
//        public event FileListResivedHandler OnFileListResivedEvent;

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="msg"></param>
//        void SendDebug(string msg)
//        {
//            if (debug)
//                if (OnDebugEvent != null)
//                    OnDebugEvent(msg);
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="e"></param>
//        void SendErrorEvent(Exception e)
//        {
//            if (OnErrorEvent != null)
//                OnErrorEvent(e);
//        }
//        #endregion

//        #region properties
//        private char[] seperator = { '\n' };
//        private string ftpServer = string.Empty;
//        private string mes;

//        private string ftpUser = "anonymous";
//        private string ftpPath = ".";
//        private string ftpPass = string.Empty;
//        private int ftpPort = 21;
//        private int bytes;
//        private int retValue;
//        private Boolean debug = false;
//        private Boolean logined;

//        //[Browsable(false)]
//        //public Boolean Logined
//        //{
//        //    get { return logined; }
//        //    set { logined = value; }
//        //}
//        private string reply;
//        Byte[] buffer = new Byte[512];
//        private Socket clientSocket;
//        /// <summary>
//        /// Password para conectarce al servidor ftp.- Si es anonymous, no se establece este valor
//        /// </summary>
//        [Browsable(true)]
//        [Category("Fwk.factory"), Description("Password para conectarce al servidor ftp.- Si es anonymous, no se establece este valor")]
//        public string FTPPass
//        {
//            get { return ftpPass; }
//            set { ftpPass = value; }
//        }
//        /// <summary>
//        /// Usuario ftp.- Por defecto es anonymous
//        /// </summary>
//        [Browsable(true)]
//        [Category("Fwk.factory"), Description("Usuario ftp.- Por defecto es anonymous")]
//        public string FTPUser
//        {
//            get { return ftpUser; }
//            set { ftpUser = value; }
//        }
//        /// <summary>
//        /// Ruta del servidor remoto
//        /// </summary>
//        [Browsable(true)]
//        [Category("Fwk.factory"), Description("Ruta del servidor remoto")]
//        public string FTPPath
//        {
//            get { return ftpPath; }
//            set { ftpPath = value; }
//        }

//        /// <summary>
//        /// Direccion IP o Nombre del servidor remoto de ftp.- 
//        /// </summary>
//        [Browsable(true)]
//        [Category("Fwk.factory"), Description("Direccion IP o Nombre del servidor remoto de ftp.- ")]
//        public string FTPServer
//        {
//            get { return ftpServer; }
//            set { ftpServer = value; }
//        }


//        /// <summary>
//        /// Puerto ftp del server remoto, en general es 21
//        /// </summary>
//        [Browsable(true)]
//        [Category("Fwk.factory"), Description("Puerto ftp del server remoto, en general es 21")]
//        public int FTPPort
//        {
//            get { return ftpPort; }
//            set { ftpPort = value; }
//        }


//        /// <summary>
//        /// 
//        /// </summary>
//        [Browsable(true)]
//        [Category("Fwk.factory"), DefaultValue(false), Description("")]
//        public Boolean Debug
//        {
//            get { return debug; }
//            set { debug = value; }
//        }


//        #endregion


//        public FTPComponentNew()
//        {
//            InitializeComponent();
//            logined = false;
//        }

//        public FTPComponentNew(IContainer container)
//        {
//            container.Add(this);
//            InitializeComponent();
//            logined = false;
//        }

//        #region  Files

//        /// <summary>
//        /// Retorna un string[] con la lista de arhivos remotos.-
//        /// </summary>
//        /// <param name="mask"></param>
//        /// <returns></returns>
//        public void GetFileList(string mask)
//        {
//            if (!logined)
//            {
//                Conect();
//            }
//            Socket cSocket = null;
//            try
//            {
//                 cSocket = CreateDataSocket();
//            }
//            catch (IOException ex)
//            {
//                if (OnFileListResivedEvent != null)
//                    OnFileListResivedEvent(this.ftpPath, null, ex);
//            }

//            SendCommand("NLST " + mask);

//            if (!(retValue == 150 || retValue == 125))
//            {
//                if (OnFileListResivedEvent != null)
//                    OnFileListResivedEvent(this.ftpPath, null, new IOException(reply.Substring(4)));
//            }

//            mes = string.Empty;

//            while (true)
//            {

//                int bytes = cSocket.Receive(buffer, buffer.Length, 0);
//                mes += Encoding.ASCII.GetString(buffer, 0, bytes);

//                if (bytes < buffer.Length)
//                {
//                    break;
//                }
//            }


//            string[] mess = mes.Split(seperator);

//            cSocket.Close();

//            ReadReply();

//            if (retValue != 226)
//            {
//                if (OnFileListResivedEvent != null)
//                    OnFileListResivedEvent(this.ftpPath, mess, new IOException(reply.Substring(4)));
//            }
//            if (OnFileListResivedEvent != null)
//                OnFileListResivedEvent(this.ftpPath, mess, null);

//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="fileName"></param>
//        /// <returns></returns>
//        public long GetFileSize(string fileName)
//        {

//            if (!logined)
//            {
//                Conect();
//            }

//            SendCommand("SIZE " + fileName);
//            long size = 0;

//            if (retValue == 213)
//            {
//                size = Int64.Parse(reply.Substring(4));
//            }
//            else
//            {
//                SendErrorEvent(new IOException(reply.Substring(4)));

//            }

//            return size;

//        }


//        /// <summary>
//        /// Descarga el archivo remoto, mantiene el nombre original
//        /// </summary>
//        /// <param name="remFileName">Nombre del archivo remoto</param>
//        public void Download(string remFileName)
//        {
//            Download(remFileName, string.Empty, false);
//        }


//        /// <summary>
//        /// Descarga el archivo remoto, mantiene el nombre y establece la bandera
//        /// resume
//        /// </summary>
//        /// <param name="remFileName">Nombre del archivo remoto</param>
//        /// <param name="resume">Llama al comando REST: Reiniciar cargas y descargas de FTP y despues RETR
//        /// Las descargas se pueden reiniciar emitiendo primero un comando rest con el desplazamiento deseado y, 
//        /// a continuación, emitiendo el comando retr.
//        /// </param>
//        public void Download(string remFileName, Boolean resume)
//        {
//            Download(remFileName, string.Empty, resume);
//        }

//        /// <summary>
//        /// Descarga el archivo remoto. 
//        /// <summary>
//        /// <param name="remFileName">Nombre del archivo remoto</param>
//        /// <param name="fullLocalFileName">Nombre del archivo destino, Ruta+Nombre
//        /// La ruta debe existir y el archivo sera creado.
//        /// </param>
//        public void Download(string remFileName, string fullLocalFileName)
//        {
//            Download(remFileName, fullLocalFileName, false);
//        }


//        /// <summary>
//        /// Descarga el archivo remoto, el archivo sera creado o sobreescrito
//        /// <summary>
//        /// <param name="remFileName">Nombre del archivo remoto</param>
//        /// <param name="fullLocalFileName">Nombre del archivo destino, Ruta+Nombre
//        /// La ruta debe existir y el archivo sera creado o sobreescrito.</param>param>
//        /// <param name="resume">Llama al comando REST: Reiniciar cargas y descargas de FTP y despues RETR
//        /// Las descargas se pueden reiniciar emitiendo primero un comando rest con el desplazamiento deseado y, 
//        /// a continuación, emitiendo el comando retr.
//        /// </param>
//        public void Download(string remFileName, string fullLocalFileName, Boolean resume)
//        {
           
           
//            if (!logined)
//            {
//                Conect();
//            }

//            SetBinaryMode(true);

//            SendDebug(string.Concat("Downloading file ", remFileName, " from ", ftpServer, "/", ftpPath));

//            if (fullLocalFileName.Equals(string.Empty))
//            {
//                fullLocalFileName = remFileName;
//            }

//            if (!File.Exists(fullLocalFileName))
//            {
//                Stream st = File.Create(fullLocalFileName);
//                st.Close();
//            }

//            FileStream output = new FileStream(fullLocalFileName, FileMode.Open);

//            Socket cSocket = null;
//            try
//            {
//                cSocket = CreateDataSocket();
//            }
//            catch (IOException ex)
//            {
//                if (OnFileDowloadEvent != null)
//                    OnFileDowloadEvent(fullLocalFileName, ex);
//            }
//            long offset = 0;

//            if (resume)
//            {

//                offset = output.Length;

//                if (offset > 0)
//                {
//                    SendCommand("REST " + offset);
//                    if (retValue != 350)
//                    {
//                        //throw new IOException(reply.Substring(4));
//                        //Algunos servers no soportan esta caracteristica(resuming)
//                        offset = 0;
//                    }
//                }

//                if (offset > 0)
//                {
//                    if (debug)
//                    {
//                        SendDebug("seeking to " + offset);
//                    }
//                    long npos = output.Seek(offset, SeekOrigin.Begin);
//                    //SendDebug(string.Concat("new pos=", npos));
//                }
//            }

//            SendCommand("RETR " + remFileName);

//            if (!(retValue == 150 || retValue == 125))
//            {
//                if (OnFileDowloadEvent != null)
//                    OnFileDowloadEvent(fullLocalFileName, new IOException(reply.Substring(4)));
//            }

//            while (true)
//            {

//                bytes = cSocket.Receive(buffer, buffer.Length, 0);
//                output.Write(buffer, 0, bytes);

//                if (bytes <= 0)
//                {
//                    break;
//                }
//            }

//            output.Close();
//            if (cSocket.Connected)
//            {
//                cSocket.Close();
//            }

//            ReadReply();

//            if (!(retValue == 226 || retValue == 250))
//            {
//                if (OnFileDowloadEvent != null)
//                    OnFileDowloadEvent(fullLocalFileName, new IOException(reply.Substring(4)));
//            }
//            if (OnFileDowloadEvent != null)
//                OnFileDowloadEvent(fullLocalFileName, null);
//        }

//        /// <summary>
//        /// Sube un archivo al servidor remoto.-
//        /// </summary>
//        /// <param name="fileName">Nombre del archivo a subir</param>
//        public void Upload(string fileName)
//        {
//            Upload(fileName, false);
//        }

//        /// <summary>
//        /// Sube un archivo al servidor remoto.-
//        /// </summary>
//        /// <param name="fileName">Nombre del archivo a subir</param>
//        /// <param name="resume">Llama al comando REST: Reiniciar cargas y descargas de FTP y despues RETR
//        /// Las descargas se pueden reiniciar emitiendo primero un comando rest con el desplazamiento deseado y, 
//        /// a continuación, emitiendo el comando retr.
//        /// </param>
//        public void Upload(string fileName, Boolean resume)
//        {

//            if (!logined)
//            {
//                Conect();
//            }
//            Socket cSocket = null;
//            try
//            {
//                cSocket = CreateDataSocket();
//            }
//            catch (IOException ex)
//            {
//                if (OnFileUploadedEvent != null)
//                    OnFileUploadedEvent(fileName, ex);
//            }
//            long offset = 0;

//            if (resume)
//            {

//                try
//                {
//                    SetBinaryMode(true);
//                    offset = GetFileSize(fileName);
//                }
//                catch (Exception)
//                {
//                    offset = 0;
//                }
//            }

//            if (offset > 0)
//            {
//                SendCommand("REST " + offset);
//                if (retValue != 350)
//                {
//                    //throw new IOException(reply.Substring(4));
//                    offset = 0;
//                }
//            }

//            SendCommand("STOR " + Path.GetFileName(fileName));

//            if (!(retValue == 125 || retValue == 150))
//            {
//                if (OnFileUploadedEvent != null)
//                    OnFileUploadedEvent(fileName, new IOException(reply.Substring(4)));
//                return;
//            }

//            // Abre el stream de enrtada para leer el archivo de origen
//            FileStream input = new FileStream(fileName, FileMode.Open);

//            if (offset != 0)
//            {

//                //if (debug)
//                //{
//                //    Console.WriteLine("seeking to " + offset);
//                //}
//                input.Seek(offset, SeekOrigin.Begin);
//            }

//            SendDebug(string.Concat("Uploading file ", fileName, " to " + ftpPath));

//            while ((bytes = input.Read(buffer, 0, buffer.Length)) > 0)
//            {

//                cSocket.Send(buffer, bytes, 0);

//            }
//            input.Close();


//            if (cSocket.Connected)
//            {
//                cSocket.Close();
//            }

//            ReadReply();
//            if (!(retValue == 226 || retValue == 250))
//            {
//                if (OnFileUploadedEvent != null)
//                    OnFileUploadedEvent(fileName, new IOException(reply.Substring(4)));
//                return;
//            }
//            if (OnFileUploadedEvent != null)
//                OnFileUploadedEvent(fileName, null);
//        }

//        /// <summary>
//        /// elimina un archivo
//        /// </summary>
//        /// <param name="fileName">Archivo a eliminar</param>
//        public void DeleteRemoteFile(string fileName)
//        {

//            if (!logined)
//            {
//                Conect();
//            }

//            SendCommand("DELE " + fileName);

//            if (retValue != 250)
//            {
//                if (OnFileRemovedEvent != null)
//                    OnFileRemovedEvent(fileName, new IOException(reply.Substring(4)));
//                return;
//            }
//            if (OnFileRemovedEvent != null)
//                OnFileRemovedEvent(fileName, null);
//        }


//        /// <summary>
//        /// Renombrado de archivo en el servidor remoto
//        /// </summary>
//        /// <param name="oldFileName">Nombre viejo del archivo</param>
//        /// <param name="newFileName">Nuevo nombre</param>
//        public void RenameRemoteFile(string oldFileName, string newFileName)
//        {

//            if (!logined)
//            {
//                Conect();
//            }

//            SendCommand("RNFR " + oldFileName);

//            if (retValue != 350)
//            {
//                SendErrorEvent(new IOException(reply.Substring(4)));
//                return;
//            }

//            //  known problem
//            //  rnto will not take care of existing file.
//            //  i.e. It will overwrite if newFileName exist
//            SendCommand("RNTO " + newFileName);
//            if (retValue != 250)
//            {
//                SendErrorEvent(new IOException(reply.Substring(4)));
//                return;
//            }
//            if (OnFileRenamedEvent != null)
//                OnFileRenamedEvent(oldFileName, null);


//        }
//        #endregion

       

  

       
//        /// <summary>
//        /// Se concta al servidor remoto
//        /// </summary>
//        public void Conect()
//        {
//            if (string.IsNullOrEmpty(ftpServer))
//                throw new IOException("El valor FTPServer no puede ser nulo");

//            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(target);
//            request.Method = WebRequestMethods.Ftp.co;


//            try
//            {
//                clientSocket.Connect(ep);
//            }
//            catch (Exception ex)
//            {
//                if (OnLoginEvent != null)
//                    OnLoginEvent(this, ex);
//                return;
//            }

//            ReadReply();
//            if (retValue != 220)
//            {
//                Close();
//                if (OnLoginEvent != null)
//                    OnLoginEvent(this, new IOException(reply.Substring(4)));
//                return;
//            }
//            //if (debug)
//            //    Console.WriteLine("USER " + ftpUser);

//            SendCommand("USER " + ftpUser);

//            if (!(retValue == 331 || retValue == 230))
//            {
//                Cleanup();
//                if (OnLoginEvent != null)
//                    OnLoginEvent(this, new IOException(reply.Substring(4)));
//                return;
//            }

//            if (retValue != 230)
//            {
//                //if (debug)
//                //    Console.WriteLine("PASS xxx");

//                SendCommand("PASS " + ftpPass);
//                if (!(retValue == 230 || retValue == 202))
//                {
//                    Cleanup();
//                    if (OnLoginEvent != null)
//                        OnLoginEvent(this, new IOException(reply.Substring(4)));
//                }
//            }

//            logined = true;

//            if (OnLoginEvent != null)
//                OnLoginEvent(this, null);

//            SendDebug("Connected to " + ftpServer);
//            Chdir(ftpPath);

//        }

//        /// <summary>
//        /// Cierra la conexion FTP.-
//        /// </summary>
//        public void Close()
//        {
//            if (clientSocket != null)
//            {
//                SendCommand("QUIT");
//            }
//            Cleanup();
//            SendDebug("Closing...");
//        }

//        /// <summary>
//        /// True = modo bunario para descargas
//        /// False, Modo Ascii para descargas.
//        /// </summary>
//        /// <param name="mode">true o false</param>
//        public void SetBinaryMode(Boolean mode)
//        {

//            if (mode)
//            {
//                SendCommand("TYPE I");
//            }
//            else
//            {
//                SendCommand("TYPE A");
//            }
//            if (retValue != 200)
//            {
//                SendErrorEvent(new IOException(reply.Substring(4)));
//                return;
//            }
//        }

//        #region Directories
//        /// <summary>
//        /// Crea un directorio en el servidor remoto
//        /// </summary>
//        /// <param name="dirName">directorio romoto crear</param>
//        public void Mkdir(string dirName)
//        {

//            if (!logined)
//            {
//                Conect();
//            }

//            SendCommand("MKD " + dirName);

//            if (retValue != 250)
//            {
//                if (OnDirectoryCreatedEvent != null)
//                    OnDirectoryCreatedEvent(dirName, new IOException(reply.Substring(4)));

//                return;
//            }
//            if (OnDirectoryCreatedEvent != null)
//                OnDirectoryCreatedEvent(dirName, null);
//        }

//        /// <summary>
//        /// Elimina un directorio en el servidor remoto
//        /// </summary>
//        /// <param name="dirName">Directorio remoto a eliminar</param>
//        public void Rmdir(string dirName)
//        {

//            if (!logined)
//            {
//                Conect();
//            }

//            SendCommand("RMD " + dirName);

//            if (retValue != 250)
//            {
//                if (OnDirectoryRemovedEvent != null)
//                    OnDirectoryRemovedEvent(dirName, new IOException(reply.Substring(4)));
//                return;
//            }
//            if (OnDirectoryRemovedEvent != null)
//                OnDirectoryRemovedEvent(dirName, null);
//        }


//        /// <summary>
//        /// Cambia el actual directorio en el servidor remoto
//        /// </summary>
//        /// <param name="dirName">Nombre del directorio al que se quiere cambiar</param>
//        public void Chdir(string dirName)
//        {

//            if (dirName.Equals("."))
//            {
//                return;
//            }

//            if (!logined)
//            {
//                Conect();
//            }

//            SendCommand("CWD " + dirName);

//            if (retValue != 250)
//            {
//                if (OnDirectoryChangedEvent != null)
//                    OnDirectoryChangedEvent(dirName, new IOException(reply.Substring(4)));
//                return;
//            }

//            this.ftpPath = dirName;

//            SendDebug(string.Concat("Current directory is ", ftpPath));

//            if (OnDirectoryChangedEvent != null)
//                OnDirectoryChangedEvent(dirName, null);
//        }

//        #endregion

    

//        /// <summary>
//        /// Lee el buffer
//        /// </summary>
//        private void ReadReply()
//        {
//            mes = string.Empty;
//            reply = ReadLine();
//            retValue = Int32.Parse(reply.Substring(0, 3));
//        }

//        /// <summary>
//        /// Cierra el socket. Es decir la conexion con el server FTP
//        /// </summary>
//        private void Cleanup()
//        {
//            if (clientSocket != null)
//            {
//                clientSocket.Close();
//                clientSocket = null;
//            }
//            logined = false;
//            if (OnCloseEvent != null)
//                OnCloseEvent(this, null);
//        }

//        /// <summary>
//        /// Lee el buffer del socket del cliente.- 
//        /// </summary>
//        /// <returns></returns>
//        private string ReadLine()
//        {
//            while (true)
//            {
//                bytes = clientSocket.Receive(buffer, buffer.Length, 0);
//                mes += Encoding.ASCII.GetString(buffer, 0, bytes);
//                if (bytes < buffer.Length)
//                {
//                    break;
//                }
//            }

//            string[] mess = mes.Split(seperator);

//            if (mes.Length > 2)
//            {
//                mes = mess[mess.Length - 2];
//            }
//            else
//            {
//                mes = mess[0];
//            }

//            if (!mes.Substring(3, 1).Equals(" "))
//            {
//                return ReadLine();
//            }

//            //if (debug)
//            //{
//            //    for (int k = 0; k < mess.Length - 1; k++)
//            //    {
//            //        Console.WriteLine(mess[k]);
//            //    }
//            //}
//            return mes;
//        }

//        /// <summary>
//        /// Envia un comando FTP
//        /// </summary>
//        /// <param name="command"></param>
//        private void SendCommand(String command)
//        {

//            Byte[] cmdBytes = Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());
//            clientSocket.Send(cmdBytes, cmdBytes.Length, 0);
//            ReadReply();
//        }

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <returns></returns>
//        private Socket CreateDataSocket()
//        {

//            SendCommand("PASV");

//            if (retValue != 227)
//            {
//                throw new IOException(reply.Substring(4));
//            }

//            int index1 = reply.IndexOf('(');
//            int index2 = reply.IndexOf(')');
//            string ipData = reply.Substring(index1 + 1, index2 - index1 - 1);
//            int[] parts = new int[6];

//            int len = ipData.Length;
//            int partCount = 0;
//            string buf = string.Empty;

//            for (int i = 0; i < len && partCount <= 6; i++)
//            {

//                char ch = Char.Parse(ipData.Substring(i, 1));
//                if (Char.IsDigit(ch))
//                    buf += ch;
//                else if (ch != ',')
//                {
//                    throw new IOException(string.Concat("Malformed PASV reply: " + reply));

//                }

//                if (ch == ',' || i + 1 == len)
//                {

//                    try
//                    {
//                        parts[partCount++] = Int32.Parse(buf);
//                        buf = string.Empty;
//                    }
//                    catch (Exception)
//                    {
//                        throw new IOException(string.Concat("Malformed PASV reply: " + reply));

//                    }
//                }
//            }

//            string ipAddress = string.Concat(parts[0], ".", parts[1] + ".", parts[2] + ".", parts[3]);

//            int port = (parts[4] << 8) + parts[5];

//            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//            IPEndPoint ep = new IPEndPoint(Dns.Resolve(ipAddress).AddressList[0], port);

//            try
//            {
//                s.Connect(ep);
//            }
//            catch (Exception ex)
//            {
//                throw new IOException(string.Concat("Can't connect to remote server " + ex.Message));


//            }

//            return s;
//        }
//    }
//}
