using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Caching;

using System.Reflection;

using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using Fwk.HelperFunctions;
using System.IO;

namespace TestServicePerformance
{

    public partial class frmTest : Form
    {


        RemotingWrapper _RemotingWrapper;
        RemotingWrapper_config _RemotingWrapper_config;
        StringBuilder strResult = new StringBuilder();


        public frmTest()
        {
            InitializeComponent();


        }





        private void btnPing_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ControllerTest.Storage.Load();
            txtObjectUri.Text = ControllerTest.Storage.StorageObject.ObjectUri;
            txtServer.Text = ControllerTest.Storage.StorageObject.Server;
            txtPort.Text = ControllerTest.Storage.StorageObject.Port;

            txtURL.Text = string.Concat("tcp://", ControllerTest.Storage.StorageObject.Server, ":", ControllerTest.Storage.StorageObject.Port.Trim(), @"/", ControllerTest.Storage.StorageObject.ObjectUri);
            if (ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Request != null)
            {
                Fwk.Bases.IServiceContract isvcReq = (Fwk.Bases.IServiceContract)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Request);

            }
        }

        private void frmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControllerTest.Storage.StorageObject.ObjectUri = txtObjectUri.Text;
            ControllerTest.Storage.StorageObject.Server = txtServer.Text;
            ControllerTest.Storage.StorageObject.Port = txtPort.Text;

            ControllerTest.Storage.Save();
        }





        private void txtServer_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = string.Concat("tcp://", txtServer.Text, ":", txtPort.Text.Trim(), @"/", txtObjectUri.Text);

        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = string.Concat("tcp://", txtServer.Text, ":", txtPort.Text.Trim(), @"/", txtObjectUri.Text);
        }

        private void txtObjectUri_TextChanged(object sender, EventArgs e)
        {
            txtURL.Text = string.Concat("tcp://", txtServer.Text, ":", txtPort.Text.Trim(), @"/", txtObjectUri.Text);
        }

        public decimal GetSizeOfObject(object obj)
        {
            long lSize = 0;



            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            BinaryFormatter objFormatter = new BinaryFormatter();
            objFormatter.Serialize(stream, obj);
            lSize = stream.Length;



            return (decimal)lSize;
        }





        private void btn_InitConfigFile_Click(object sender, EventArgs e)
        {
            this.btn_InitConfigFile.Image = global::TestServicePerformance.Properties.Resources.Ball__Red_;
            //if (!ValidateInit()) return;
            _RemotingWrapper_config = new RemotingWrapper_config();
            try
            {
                _RemotingWrapper_config.Init();


                this.btn_InitConfigFile.Image = global::TestServicePerformance.Properties.Resources.Ball__Green_;
                tabControl2.TabIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }



        bool ValidateInit()
        {
            if (_RemotingWrapper_config == null)
            {

                errorProvider1.SetError(btn_Method1, "Falta inicialisar");
                txtPort.Focus();
                return false;
            }
            if (radioButton2.Checked)
            {
                if (string.IsNullOrEmpty(txtPort.Text))
                {
                    errorProvider1.SetError(txtPort, "No puede faltar este valor");
                    txtPort.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtObjectUri.Text))
                {
                    errorProvider1.SetError(txtObjectUri, "No puede faltar este valor");
                    txtObjectUri.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtServer.Text))
                {
                    errorProvider1.SetError(txtServer, "No puede faltar este valor");
                    txtServer.Focus();
                    return false;
                }
            }

            return true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            btn_InitConfigFile.Enabled = radioButton1.Checked;
            btn_Activator.Enabled = radioButton2.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            btn_Activator.Enabled = radioButton2.Checked;
            btn_InitConfigFile.Enabled = radioButton1.Checked;
        }

        private void btnActivator_Click(object sender, EventArgs e)
        {

            this.btn_Activator.Image = global::TestServicePerformance.Properties.Resources.Ball__Red_;
            if (!ValidateInit()) return;
            _RemotingWrapper = new RemotingWrapper();
            try
            {
                _RemotingWrapper.Init(txtURL.Text);

                this.btn_Activator.Image = global::TestServicePerformance.Properties.Resources.Ball__Green_;
                tabControl2.TabIndex = 0;
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
                if (ValidateInit())
                    _RemotingWrapper_config.RemoteObj.Metodo1(txtParamMethod_1.Text);
                tabControl2.TabIndex = 0;
            }
            catch (Exception ex)
            {

                txtTestResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInit())
                {
                    Dictionary<string, string> status = _RemotingWrapper_config.RemoteObj.GetStatus();

                    StringBuilder str = new StringBuilder();
                    foreach (KeyValuePair<string, string> kp in status)
                    {
                        str.AppendLine(string.Concat(kp.Key, kp.Value));
                    }
                    txtTestResult.Text = str.ToString();
                }
            }
            catch (Exception ex)
            {

                txtTestResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInit())
                    _RemotingWrapper_config.RemoteObj.SetValue_1(Convert.ToInt32(txtValue1.Text));
            }
            catch (Exception ex)
            {

                txtTestResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }
    }

    
}
