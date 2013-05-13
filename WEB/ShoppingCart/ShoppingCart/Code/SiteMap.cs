using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace ShoppingCart.Code
{

    [XmlRoot("siteMap", Namespace = "http://schemas.microsoft.com/AspNet/SiteMap-File-1.0", IsNullable = false)]
    public class siteMap : Fwk.Bases.BaseEntity
    {


        siteMapNode _siteMapNode;
        [XmlElement("siteMapNode")]
        public siteMapNode SiteMapNode
        {
            get { return _siteMapNode; }
            set { _siteMapNode = value; }
        }
    }
    [XmlInclude(typeof(siteMapNode)), Serializable]
    public class siteMapNode : Fwk.Bases.BaseEntity
    {
        string url;
        [XmlAttribute("url")]
        public string Url
        {
            get { return url; }
            set { url = value; }
        }
        string description;
        [XmlAttribute("description")]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        string title;
        [XmlAttribute("title")]
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        string imageBig;
        [XmlAttribute("imageBig")]
        public string ImageBig
        {
            get { return imageBig; }
            set { imageBig = value; }
        }
        string imageSmall;
        [XmlAttribute("imageSmall")]
        public string ImageSmall
        {
            get { return imageSmall; }
            set { imageSmall = value; }
        }




        List<siteMapNode> siteMapNodes = new List<siteMapNode>();

        [XmlElement("siteMapNode")]
        public List<siteMapNode> SiteMapNodes
        {
            get { return siteMapNodes; }
            set { siteMapNodes = value; }
        }
    }
}