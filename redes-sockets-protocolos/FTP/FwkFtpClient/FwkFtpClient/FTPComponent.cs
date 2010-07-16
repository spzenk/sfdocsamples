using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace FwkFtpClient
{
    public delegate void DebugHandler(string msg);
    public delegate void ErrorHandler(Exception ex);
    public delegate void ObjectHandler(object sender);
    public partial class FTPComponent : Component
    {
        #region events
        public event DebugHandler OnDebugEvent;
        public event ErrorHandler OnErrorEvent;
        public event ObjectHandler OnCloseEvent;
        public event ObjectHandler OnLoginEvent;
        public event ObjectHandler OnFileListResivedEvent;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        void SendDebug(string msg)
        {
            if (debug)
                if (OnDebugEvent != null)
                    OnDebugEvent(msg);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        void SendErrorEvent(Exception e)
        {
            if (OnErrorEvent != null)
                OnErrorEvent(e);
        }
        #endregion 


        #region properties
        private  char[] seperator = { '\n' };
        private string ftpServer, mes;
        private string ftpUser = "anonymous";
        private string ftpPath = ".";
        private string ftpPass = string.Empty;
        private int ftpPort, bytes;
        private int retValue;
        private Boolean debug;
        private Boolean logined;

        [Browsable(false)]
        public Boolean Logined
        {
            get { return logined; }
            set { logined = value; }
        }
        private string reply;
        Byte[] buffer = new Byte[512];
        private Socket clientSocket;
        /// <summary>
        /// Password para conectarce al servidor ftp.- Si es anonymous, no se establece este valor
        /// </summary>
        [Browsable(true)]
        [Category("Fwk.factory"), DefaultValue(""), Description("Password para conectarce al servidor ftp.- Si es anonymous, no se establece este valor")]
        public string FTPPass
        {
            get { return ftpPass; }
            set { ftpPass = value; }
        }
        /// <summary>
        /// Usuario ftp.- Por defecto es anonymous
        /// </summary>
        [Browsable(true)]
        [Category("Fwk.factory"), DefaultValue("anonymous"), Description("Usuario ftp.- Por defecto es anonymous")]
        public string FTPUser
        {
            get { return ftpUser; }
            set { ftpUser = value; }
        }
        /// <summary>
        /// Ruta del servidor remoto
        /// </summary>
        [Browsable(true)]
        [Category("Fwk.factory"), DefaultValue("."), Description("Ruta del servidor remoto")]
        public string FTPPath
        {
            get { return ftpPath; }
            set { ftpPath = value; }
        }

        /// <summary>
        /// Direccion IP o Nombre del servidor remoto de ftp.- 
        /// </summary>
        [Browsable(true)]
        [Category("Fwk.factory"), DefaultValue(null), Description("Direccion IP o Nombre del servidor remoto de ftp.- ")]
        public string FTPServer
        {
            get { return ftpServer; }
            set { ftpServer = value; }
        }


        /// <summary>
        /// Puerto ftp del server remoto, en general es 21
        /// </summary>
        [Browsable(true)]
        [Category("Fwk.factory"), DefaultValue(21), Description("Puerto ftp del server remoto, en general es 21")]
        public int FTPPort
        {
            get { return ftpPort; }
            set { ftpPort = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        [Browsable(true)]
        [Category("Fwk.factory"), DefaultValue(false), Description("")]
        public Boolean Debug
        {
            get { return debug; }
            set { debug = value; }
        }


        #endregion

        public FTPComponent()
        {
            InitializeComponent();
            logined = false;
        }

        public FTPComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            logined = false;
        }



        #region  Files

        /// <summary>
        /// Retorna un string[] con la lista de arhivos remotos.-
        /// </summary>
        /// <param name="mask"></param>
        /// <returns></returns>
        public void GetFileList(string mask)
        {

            if (!logined)
            {
                Conect();
            }

            Socket cSocket = CreateDataSocket();

            SendCommand("NLST " + mask);

            if (!(retValue == 150 || retValue == 125))
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }

            mes = string.Empty;

            while (true)
            {

                int bytes = cSocket.Receive(buffer, buffer.Length, 0);
                mes += Encoding.ASCII.GetString(buffer, 0, bytes);

                if (bytes < buffer.Length)
                {
                    break;
                }
            }

           
            string[] mess = mes.Split(seperator);

            cSocket.Close();

            ReadReply();

            if (retValue != 226)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }
            if(OnFileListResivedEvent!=null)
                OnFileListResivedEvent(mess);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public long GetFileSize(string fileName)
        {

            if (!logined)
            {
                Conect();
            }

            SendCommand("SIZE " + fileName);
            long size = 0;

            if (retValue == 213)
            {
                size = Int64.Parse(reply.Substring(4));
            }
            else
            {
                SendErrorEvent(new IOException(reply.Substring(4)));

            }

            return size;

        }

        ///
        /// Download a file to the Assembly's local directory,
        /// keeping the same file name.
        ///
        ///
        public void Download(string remFileName)
        {
            Download(remFileName, string.Empty, false);
        }

        ///
        /// Download a remote file to the Assembly's local directory,
        /// keeping the same file name, and set the resume flag.
        ///
        ///
        ///
        public void Download(string remFileName, Boolean resume)
        {
            Download(remFileName, string.Empty, resume);
        }

        ///
        /// Download a remote file to a local file name which can include
        /// a path. The local file name will be created or overwritten,
        /// but the path must exist.
        ///
        ///
        ///
        public void Download(string remFileName, string locFileName)
        {
            Download(remFileName, locFileName, false);
        }

        ///
        /// Download a remote file to a local file name which can include
        /// a path, and set the resume flag. The local file name will be
        /// created or overwritten, but the path must exist.
        ///
        ///
        ///
        ///
        public void Download(string remFileName, string locFileName, Boolean resume)
        {
            if (!logined)
            {
                Conect();
            }

            SetBinaryMode(true);

            SendDebug(string.Concat("Downloading file ", remFileName, " from ", ftpServer, "/", ftpPath));

            if (locFileName.Equals(string.Empty))
            {
                locFileName = remFileName;
            }

            if (!File.Exists(locFileName))
            {
                Stream st = File.Create(locFileName);
                st.Close();
            }

            FileStream output = new FileStream(locFileName, FileMode.Open);

            Socket cSocket = CreateDataSocket();

            long offset = 0;

            if (resume)
            {

                offset = output.Length;

                if (offset > 0)
                {
                    SendCommand("REST " + offset);
                    if (retValue != 350)
                    {
                        //throw new IOException(reply.Substring(4));
                        //Some servers may not support resuming.
                        offset = 0;
                    }
                }

                if (offset > 0)
                {
                    if (debug)
                    {
                        Console.WriteLine("seeking to " + offset);
                    }
                    long npos = output.Seek(offset, SeekOrigin.Begin);
                    SendDebug(string.Concat("new pos=", npos));
                }
            }

            SendCommand("RETR " + remFileName);

            if (!(retValue == 150 || retValue == 125))
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }

            while (true)
            {

                bytes = cSocket.Receive(buffer, buffer.Length, 0);
                output.Write(buffer, 0, bytes);

                if (bytes <= 0)
                {
                    break;
                }
            }

            output.Close();
            if (cSocket.Connected)
            {
                cSocket.Close();
            }

            //SendDebug(string.empty);

            ReadReply();

            if (!(retValue == 226 || retValue == 250))
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }

        }

        ///
        /// Upload a file.
        ///
        ///
        public void Upload(string fileName)
        {
            Upload(fileName, false);
        }

        ///
        /// Upload a file and set the resume flag.
        ///
        ///
        ///
        public void Upload(string fileName, Boolean resume)
        {

            if (!logined)
            {
                Conect();
            }

            Socket cSocket = CreateDataSocket();
            long offset = 0;

            if (resume)
            {

                try
                {

                    SetBinaryMode(true);
                    offset = GetFileSize(fileName);

                }
                catch (Exception)
                {
                    offset = 0;
                }
            }

            if (offset > 0)
            {
                SendCommand("REST " + offset);
                if (retValue != 350)
                {
                    //throw new IOException(reply.Substring(4));
                    //Remote server may not support resuming.
                    offset = 0;
                }
            }

            SendCommand("STOR " + Path.GetFileName(fileName));

            if (!(retValue == 125 || retValue == 150))
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }

            // open input stream to read source file
            FileStream input = new FileStream(fileName, FileMode.Open);

            if (offset != 0)
            {

                //if (debug)
                //{
                //    Console.WriteLine("seeking to " + offset);
                //}
                input.Seek(offset, SeekOrigin.Begin);
            }

            Console.WriteLine("Uploading file " + fileName + " to " + ftpPath);

            while ((bytes = input.Read(buffer, 0, buffer.Length)) > 0)
            {

                cSocket.Send(buffer, bytes, 0);

            }
            input.Close();

            //Console.WriteLine(string.empty);

            if (cSocket.Connected)
            {
                cSocket.Close();
            }

            ReadReply();
            if (!(retValue == 226 || retValue == 250))
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }
        }

        ///
        /// Delete a file from the remote FTP server.
        ///
        ///
        public void DeleteRemoteFile(string fileName)
        {

            if (!logined)
            {
                Conect();
            }

            SendCommand("DELE " + fileName);

            if (retValue != 250)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }

        }


        /// <summary>
        /// Renombrado de archivo en el servidor remoto
        /// </summary>
        /// <param name="oldFileName"></param>
        /// <param name="newFileName"></param>
        public void RenameRemoteFile(string oldFileName, string newFileName)
        {

            if (!logined)
            {
                Conect();
            }

            SendCommand("RNFR " + oldFileName);

            if (retValue != 350)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }

            //  known problem
            //  rnto will not take care of existing file.
            //  i.e. It will overwrite if newFileName exist
            SendCommand("RNTO " + newFileName);
            if (retValue != 250)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }

        }
        #endregion

        /// <summary>
        /// Se concta al servidor remoto
        /// </summary>
        public void Conect()
        {

            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(Dns.Resolve(ftpServer).AddressList[0], ftpPort);

            try
            {
                clientSocket.Connect(ep);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ReadReply();
            if (retValue != 220)
            {
                Close();
                SendErrorEvent(new IOException(reply.Substring(4)));
            }
            //if (debug)
            //    Console.WriteLine("USER " + ftpUser);

            SendCommand("USER " + ftpUser);

            if (!(retValue == 331 || retValue == 230))
            {
                Cleanup();
                SendErrorEvent(new IOException(reply.Substring(4)));
            }

            if (retValue != 230)
            {
                //if (debug)
                //    Console.WriteLine("PASS xxx");

                SendCommand("PASS " + ftpPass);
                if (!(retValue == 230 || retValue == 202))
                {
                    Cleanup();
                    SendErrorEvent(new IOException(reply.Substring(4)));
                }
            }

            logined = true;

            if (OnLoginEvent != null) 
                OnLoginEvent(this);

            SendDebug("Connected to " + ftpServer);
            Chdir(ftpPath);

        }

        
        
        /// <summary>
        /// True = modo bunario para descargas
        /// False, Modo Ascii para descargas.
        /// </summary>
        /// <param name="mode"></param>
        public void SetBinaryMode(Boolean mode)
        {

            if (mode)
            {
                SendCommand("TYPE I");
            }
            else
            {
                SendCommand("TYPE A");
            }
            if (retValue != 200)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }
        }


        /// <summary>
        /// Crea un directorio en el servidor remoto
        /// </summary>
        /// <param name="dirName"></param>
        public void Mkdir(string dirName)
        {

            if (!logined)
            {
                Conect();
            }

            SendCommand("MKD " + dirName);

            if (retValue != 250)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }

        }

        /// <summary>
        /// Elimina un directorio en el servidor remoto
        /// </summary>
        /// <param name="dirName"></param>
        public void Rmdir(string dirName)
        {

            if (!logined)
            {
                Conect();
            }

            SendCommand("RMD " + dirName);

            if (retValue != 250)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }

        }


        /// <summary>
        /// Cambia el actual directorio en el servidor remoto
        /// </summary>
        /// <param name="dirName"></param>
        public void Chdir(string dirName)
        {

            if (dirName.Equals("."))
            {
                return;
            }

            if (!logined)
            {
                Conect();
            }

            SendCommand("CWD " + dirName);

            if (retValue != 250)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }

            this.ftpPath = dirName;

            SendDebug(string.Concat("Current directory is " , ftpPath));

        }

        ///
        /// Close the FTP connection.
        ///
        public void Close()
        {

            if (clientSocket != null)
            {
                SendCommand("QUIT");
            }

            Cleanup();
            SendDebug("Closing...");

        }


        /// <summary>
        /// Lee el buffer
        /// </summary>
        private void ReadReply()
        {
            mes = string.Empty;
            reply = ReadLine();
            retValue = Int32.Parse(reply.Substring(0, 3));
        }

        /// <summary>
        /// Cierra el socket. Es decir la conexion con el server FTP
        /// </summary>
        private void Cleanup()
        {
            if (clientSocket != null)
            {
                clientSocket.Close();
                clientSocket = null;
            }
            logined = false;
            if (OnCloseEvent != null)
                OnCloseEvent(this);
        }

        /// <summary>
        /// Lee el buffer del socket del cliente.- 
        /// </summary>
        /// <returns></returns>
        private string ReadLine()
        {

            while (true)
            {
                bytes = clientSocket.Receive(buffer, buffer.Length, 0);
                mes += Encoding.ASCII.GetString(buffer, 0, bytes);
                if (bytes < buffer.Length)
                {
                    break;
                }
            }

            
            string[] mess = mes.Split(seperator);

            if (mes.Length > 2)
            {
                mes = mess[mess.Length - 2];
            }
            else
            {
                mes = mess[0];
            }

            if (!mes.Substring(3, 1).Equals(" "))
            {
                return ReadLine();
            }

            //if (debug)
            //{
            //    for (int k = 0; k < mess.Length - 1; k++)
            //    {
            //        Console.WriteLine(mess[k]);
            //    }
            //}
            return mes;
        }

        /// <summary>
        /// Envia un comando FTP
        /// </summary>
        /// <param name="command"></param>
        private void SendCommand(String command)
        {

            Byte[] cmdBytes = Encoding.ASCII.GetBytes((command + "\r\n").ToCharArray());
            clientSocket.Send(cmdBytes, cmdBytes.Length, 0);
            ReadReply();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Socket CreateDataSocket()
        {

            SendCommand("PASV");

            if (retValue != 227)
            {
                SendErrorEvent(new IOException(reply.Substring(4)));
            }

            int index1 = reply.IndexOf('(');
            int index2 = reply.IndexOf(')');
            string ipData = reply.Substring(index1 + 1, index2 - index1 - 1);
            int[] parts = new int[6];

            int len = ipData.Length;
            int partCount = 0;
            string buf = string.Empty;

            for (int i = 0; i < len && partCount <= 6; i++)
            {

                char ch = Char.Parse(ipData.Substring(i, 1));
                if (Char.IsDigit(ch))
                    buf += ch;
                else if (ch != ',')
                {
                   SendErrorEvent(  new IOException(string .Concat("Malformed PASV reply: " + reply)));
                }

                if (ch == ',' || i + 1 == len)
                {

                    try
                    {
                        parts[partCount++] = Int32.Parse(buf);
                        buf = string.Empty;
                    }
                    catch (Exception)
                    {
                        SendErrorEvent(new IOException(string .Concat("Malformed PASV reply: " + reply)));
                    }
                }
            }

            string ipAddress = string.Concat(parts[0], ".", parts[1] + ".", parts[2] + ".", parts[3]);

            int port = (parts[4] << 8) + parts[5];

            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(Dns.Resolve(ipAddress).AddressList[0], port);

            try
            {
                s.Connect(ep);
            }
            catch (Exception ex)
            {
                SendErrorEvent(new IOException(string.Concat("Can't connect to remote server " + ex.Message)));
                
            }

            return s;
        }
    }
}
