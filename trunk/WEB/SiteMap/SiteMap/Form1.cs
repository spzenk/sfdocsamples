using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace SiteMap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            siteMap wSiteMap = new siteMap();
            
            siteMapNode sn = new siteMapNode();
            sn.Description = "Bigbang";
            sn.Title = "Bigbang";

            wSiteMap.SiteMapNode = sn;

             sn = new siteMapNode();
            sn.Url = "login.aspx";
            sn.Title = "Iniciar Sesión";
            sn.Description = "Iniciar Sesión";
            sn.ImageBig = @"~\Images\TreeView\IniciarSesionBig.gif";
            sn.ImageSmall = @"~\Images\TreeView\IniciarSesionBig.gif";
            wSiteMap.SiteMapNode.SiteMapNodes.Add(sn);

             sn = new siteMapNode();
            sn.Url = "xx.aspx";
            sn.Title = "xx Sesión";
            sn.Description = "xx Sesión";
            sn.ImageBig = @"~\Images\TreeView\IniciarSesionBig.gif";
            sn.ImageSmall = @"~\Images\TreeView\IniciarSesionBig.gif";
            wSiteMap.SiteMapNode.SiteMapNodes.Add(sn);

            textBox1.Text = wSiteMap.GetXml();

           
        }

        private void button2_Click(object sender, EventArgs e)
        {
           string xml = Fwk.HelperFunctions.FileFunctions.OpenTextFile(@"site.xml");

           siteMap wSiteMap = siteMap.GetFromXml<siteMap>(xml);

           textBox1.Text = wSiteMap.GetXml().Replace("q1:", "");


        }


    }
}
