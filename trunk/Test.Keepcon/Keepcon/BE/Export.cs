using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Allus.Keepcon.Export
{
    [Serializable]
    [XmlRootAttribute("export")]
    public class Export
    {
        [XmlAttribute("setId")]
        public String SetId { get; set; }
        [XmlIgnore()]
        public Guid SetGuid
        {
            get { return new Guid(SetId); }
        }
        public Export()
        {
            this.Contents = new List<Content>();
        }
        [XmlArray("contents")]
        [XmlArrayItem("content")]
        public List<Content> Contents { get; set; }

        public String GetXml()
        {
            return Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(this);
        }
        public static Export SetXml(string xml)
        {
            return (Export)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(Export), xml);
        }
    }

    public class Content
    {

        public Content()
        {
            this.Tagging = new List<Tag>();
        }

        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("moderatorName")]
        public String ModeratorName { get; set; }

        [XmlElement("moderationDecision")]
        public String ModerationDecision { get; set; }

        //long datetime;
        [XmlElement("moderationDate")]
        public long ModerationDate
        {
            get;
            set;
        }


        [XmlArray("tagging")]
        [XmlArrayItem("tag")]
        public List<Tag> Tagging { get; set; }



    }

    public class Tag
    {
        public Tag() { }
        public Tag(string text) { this.Text = text; }
        [XmlText()]
        public string Text { get; set; }
    }



    [Serializable]
    [XmlRootAttribute("response")]
    public class Response
    {

        public Response()
        {
            this.Content = new Content();
        }
        [XmlElement("status")]
        public String Status { get; set; }

        [XmlElement("content")]
        public Content Content { get; set; }

        public String GetXml()
        {
            return Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(this);
        }
        public static Export SetXml(string xml)
        {
            return (Export)Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(Export), xml);
        }
    }
   
}
