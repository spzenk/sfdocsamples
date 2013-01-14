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
            txtImport.Text = KeepconSvc.SendASK(txtSetId.Text);
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
            keepconengine1.Start();
        }




    }

    //public partial class Post
    //{
    //    public static IQueryable<T> Page<T, TResult>(this IQueryable<T> query,
    //                           int pageNum, int pageSize,
    //                           Expression<Func<T, TResult>> orderByProperty,
    //                           bool isAscendingOrder, out int rowsCount)
    //    {
    //        if (pageSize <= 0) pageSize = 20;

    //        rowsCount = query.Count();

    //        if (rowsCount <= pageSize || pageNum <= 0) pageNum = 1;

    //        int excludedRows = (pageNum - 1) * pageSize;

    //        if (isAscendingOrder)
    //            query = query.OrderBy(orderByProperty);
    //        else
    //            query = query.OrderByDescending(orderByProperty);

    //        return query.Skip(excludedRows).Take(pageSize);
    //    }
    //}
}
