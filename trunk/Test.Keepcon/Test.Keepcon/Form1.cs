using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using Allus.Keepcon;
using System.Linq.Expressions;

namespace Test.Keepcon
{
    public partial class Form1 : Form
    {

        int skip = 0;
        public Form1()
        {
            InitializeComponent();

            if (Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval_SendContent") != null)
                lblSend_Clock.Text = Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval_SendContent");

            if (Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval_CheckResult") != null)
                lblCheckResultClock.Text = Fwk.Configuration.ConfigurationManager.GetProperty("Engine", "ClockInterval_CheckResult");
        }







        private void btnSendBath_Click(object sender, EventArgs e)
        {
            //<?xml version="1.0" encoding="UTF-8"?><response><status>OK</status><setId>aa8f0d86-2d0d-404d-9aa0-c9644e939d9d</setId></response>
            //ClearText();
            //List<Post> posts = KeepconSvc.RetrivePost_To_Send(12);

            //Allus.Keepcon.Import.Import wImport = new Allus.Keepcon.Import.Import(posts);
            //int count = posts.Count();
            //txtImport.Text = wImport.GetXml();
            //txtResult.Text = KeepconSvc.SendContent(wImport);


        }



        private void btnCheckResult_Click(object sender, EventArgs e)
        {
            ClearText();
            //Allus.Keepcon.Export.Export export = KeepconSvc.RetriveResult_2();
            //if (export != null)
            //{
            //    txtImport.Text = export.GetXml();
            //    txtSetId.Text = export.SetId;
            //    KeepconSvc.SaveResult(export);
            //}

        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtResult.Text = txtImport.Text = string.Empty;
            txtImport.Text = keepconengine1.SendASK(txtSetId.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {

            //List<Post> posts = KeepconSvc.RetrivePost_To_Send(12);
            //Allus.Keepcon.Import.Import wImport = new Allus.Keepcon.Import.Import(posts[8]);

            //txtImport.Text = wImport.GetXml();

            //txtResult.Text = KeepconSvc.SendContent(wImport);
        }
        void ClearText()
        {
            txtSetId.Text = txtResult.Text = txtImport.Text = string.Empty;
        }

        #region chek xml


        private void button2_Click(object sender, EventArgs e)
        {


            Allus.Keepcon.Export.Export exp = new Allus.Keepcon.Export.Export();

            Allus.Keepcon.Export.Content c = new Allus.Keepcon.Export.Content();
            c.Id = 12121;
            c.ModerationDate = 23123432432;
            c.ModerationDecision = "APPROVED";
            exp.Contents.Add(c);

            c = new Allus.Keepcon.Export.Content();
            c.Id = 1111;
            c.ModerationDate = 23123432432;
            c.ModerationDecision = "REJECTED";
            c.Tagging.Add(new Allus.Keepcon.Export.Tag("Inapropiado")); exp.Contents.Add(c);


            txtImport.Text = exp.GetXml();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Allus.Keepcon.Export.Response exp = new Allus.Keepcon.Export.Response();


            exp.Content.Id = 1;
            exp.Content.ModerationDate = 23123432432;
            exp.Content.ModerationDecision = "REJECTED";



            exp.Content.Tagging.Add(new Allus.Keepcon.Export.Tag("desnudo"));
            exp.Content.Tagging.Add(new Allus.Keepcon.Export.Tag("contacto"));

            txtImport.Text = exp.GetXml();
        }
        #endregion

        private void btnEngine_StartSVC_Click(object sender, EventArgs e)
        {
            btnStart_SendContent.Enabled = false;
            try
            {
                keepconengine1.Start();
            }
            catch (Exception ex)
            {
                btnStart_SendContent.Enabled = true;
                txtResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
            btnStop_SendContent.Enabled = true;
        }

        private void btnStart_CheckResult_Click(object sender, EventArgs e)
        {
            btnStart_CheckResult.Enabled = false;
            try
            {
                keepconengine1.Start();
            }
            catch (Exception ex)
            {
                btnStart_CheckResult.Enabled = true;
                txtResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
            btnStop_Checkresult.Enabled = true;
        }

        private void btnStop_SendContent_Click(object sender, EventArgs e)
        {
            btnStop_SendContent.Enabled = false;
            try
            {
                keepconengine1.Start();
            }
            catch (Exception ex)
            {

                btnStop_SendContent.Enabled = true;
                txtResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
            btnStart_CheckResult.Enabled = true;
        }

        private void btnStop_Checkresult_Click(object sender, EventArgs e)
        {
            btnStop_Checkresult.Enabled = false;
            try
            {
                keepconengine1.Start();
            }
            catch (Exception ex)
            {
                
                btnStop_Checkresult.Enabled = true;
                txtResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
            btnStart_CheckResult.Enabled = true;
        }




    }

    
}
