using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace UdpServer
{
    public partial class UdpCliente : Form
    {

        #region Variables privadas

        private Socket m_SocketServer;
        private bool m_IsServerStarted = false;
        private EndPoint m_EpServer;
        #endregion


        public UdpCliente()
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
                    
                    //Obtengo un IPEndPoint correspondiente a los valores ingresados en el form para poder enviar cosas al server
                    IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(m_TxtIpServer.Text),
                                                           int.Parse(m_TxtPuerto.Text));
                    m_EpServer = (EndPoint)ipEndPoint;

                    DesactivarStart();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Error al conectarse al server, por favor verifique la dirección IP y el puerto\n" + ex.Message,
                        "Udp Server Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void OnSend(IAsyncResult result)
        {

            try
            {
                IPEndPoint ipeSender = new IPEndPoint(IPAddress.Any, 0);
                EndPoint epSender = (EndPoint)ipeSender;

                m_SocketServer.EndReceiveFrom(result, ref epSender);
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
            m_CmdEnviar.Enabled = true;
        }

        private void ActivarStart()
        {
            m_TxtIpServer.Enabled = true;
            m_TxtPuerto.Enabled = true;

            m_CmdStartStop.Text = "Start";
            m_CmdEnviar.Enabled = false;
        }

        private void OnCmdEnviarClick(object sender, EventArgs e)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] byteDataToSend = encoder.GetBytes(m_TxtRecibido.Text);

            m_SocketServer.SendTo(byteDataToSend, m_EpServer);

        }

    }
}
