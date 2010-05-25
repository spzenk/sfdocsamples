using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace UdpServer
{
    public partial class UdpServer : Form
    {

        #region Variables privadas

        private Socket m_SocketServer;
        private byte[] m_ByteData = new byte[1024];
        private bool m_IsServerStarted = false;
        #endregion


        public UdpServer()
        {
            InitializeComponent();

            CheckForIllegalCrossThreadCalls = false;

            //Creo el nuevo socket
            m_SocketServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

        }
        
        private void OnCmdStartStopClick(object sender, EventArgs e)
        {
            
            if (m_SocketServer.IsBound)
            {
                m_SocketServer.Disconnect(true);
                ActivarStart();
            }
            else
            {

                try
                {
                    
                    //Obtengo un IPEndPoint correspondiente a los valores ingresados en el form para asignar al server
                    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(m_TxtIpServer.Text),
                                                           int.Parse(m_TxtPuerto.Text));

                    //Pego el socket a la direccion
                    m_SocketServer.Bind(ipEndPoint);

                    // Usado para obtener el ip del cliente que envia los datos
                    IPEndPoint ipSender = new IPEndPoint(IPAddress.Any, 0);

                    EndPoint epSender = (EndPoint) ipSender;

                    //Cominezo a recibir datos
                    m_SocketServer.BeginReceiveFrom(m_ByteData, 0, m_ByteData.Length, SocketFlags.None, ref epSender,
                                                    new AsyncCallback(OnReceive), epSender);

                    DesactivarStart();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al crear el Server, por favor verifique la dirección IP y el puerto\n" + ex.Message,
                        "Udp Server Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void OnReceive(IAsyncResult result)
        {

            try
            {
                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint epSender = (EndPoint)ipeSender;

                m_SocketServer.EndReceiveFrom(result, ref epSender);

                ASCIIEncoding encoder = new ASCIIEncoding();

                m_TxtRecibido.Text = encoder.GetString(m_ByteData);

                m_ByteData = new byte[1024];

                //Cominezo a recibir datos nuevamente
                m_SocketServer.BeginReceiveFrom(m_ByteData, 0, m_ByteData.Length, SocketFlags.None, ref epSender,
                                                new AsyncCallback(OnReceive), epSender);
            }
            catch
            {
            }
           
        }

        private void DesactivarStart()
        {
            m_TxtIpServer.Enabled = false;
            m_TxtPuerto.Enabled = false;

            m_CmdStartStop.Text = "Stop";
        }

        private void ActivarStart()
        {
            m_TxtIpServer.Enabled = true;
            m_TxtPuerto.Enabled = true;

            m_CmdStartStop.Text = "Start";
        }

        private void UdpServer_Load(object sender, EventArgs e)
        {

        }
    }
}
