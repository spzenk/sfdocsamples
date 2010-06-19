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
            this.btnPing.Image = global::TestServicePerformance.Properties.Resources.Ball__Red_;
            if (!ValidateInit()) return;
            _RemotingWrapper = new RemotingWrapper();
            try
            {
                _RemotingWrapper.Init(txtURL.Text);
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                dataGridView1.DataSource = _RemotingWrapper.RemoteObj.GetServicesList();
                this.btnPing.Image = global::TestServicePerformance.Properties.Resources.Ball__Green_;
                tabControl2.TabIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            ControllerTest.Storage.Load();
            txtObjectUri.Text = ControllerTest.Storage.StorageObject.ObjectUri;
            txtServer.Text = ControllerTest.Storage.StorageObject.Server;
            txtPort.Text = ControllerTest.Storage.StorageObject.Port;
            txtSvc.Text = ControllerTest.Storage.StorageObject.Svc;
            txtXmlRequest.Text = ControllerTest.Storage.StorageObject.XmlRequest;
            txtSvc.Text = ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Name;
            numericThread.Value = Convert.ToDecimal(ControllerTest.Storage.StorageObject.Threads);
            numericCallsNumber.Value = Convert.ToDecimal(ControllerTest.Storage.StorageObject.Calls);

            txtURL.Text = string.Concat("tcp://", ControllerTest.Storage.StorageObject.Server, ":", ControllerTest.Storage.StorageObject.Port.Trim(), @"/", ControllerTest.Storage.StorageObject.ObjectUri);
            if (ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Request != null)
            {
                Fwk.Bases.IServiceContract isvcReq = (Fwk.Bases.IServiceContract)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Request);
                this.txtXmlRequest.Text = isvcReq.GetBusinessDataXml();
            }
        }

        private void frmTest_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControllerTest.Storage.StorageObject.ObjectUri = txtObjectUri.Text;
            ControllerTest.Storage.StorageObject.Server = txtServer.Text;
            ControllerTest.Storage.StorageObject.Port = txtPort.Text;
            ControllerTest.Storage.StorageObject.Svc = txtSvc.Text;
            ControllerTest.Storage.StorageObject.XmlRequest = txtXmlRequest.Text;
            ControllerTest.Storage.StorageObject.Threads = (int)numericThread.Value;
            ControllerTest.Storage.StorageObject.Calls = (int)numericCallsNumber.Value;

            ControllerTest.Storage.StorageObject.SelectedServiceConfiguration.Name = txtSvc.Text;
            ControllerTest.Storage.Save();
        }

       

        private void numericThread_ValueChanged(object sender, EventArgs e)
        {
            ControllerTest.Storage.StorageObject.Threads = (int)numericThread.Value;
        }

        private void numericCallsNumber_ValueChanged(object sender, EventArgs e)
        {
            ControllerTest.Storage.StorageObject.Calls = (int)numericCallsNumber.Value;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            progressBar1.Maximum = 101;
            progressBar1.Value = 0;
            for (int i = 0; i <= 100; i++)
            {

                progressBar1.Value++;
                System.Threading.Thread.Sleep(369);
            }
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
                dataGridView1.DataSource = null;
                dataGridView1.Refresh();
                 _RemotingWrapper_config.RemoteObj.Metodo1("");
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

            return true;
        }
    }

    
}
