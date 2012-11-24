using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Allus.Keepcon.Import
{

    [Serializable]
    [XmlRootAttribute("import")]
    public class Import
    {

        public Import(Post post)
        {
            this.Contents = new List<Content>();
            this.Contenttype = "MovistarPostDemo";


            Content wContent = new Content();

            wContent.Author = new Author("author", post.FromUserID.ToString());

            //wContent.Date = System.DateTime.Now;
            wContent.Id = post.PostID;
            wContent.Text.Text = post.Message;
            // wContent.Url_Context.Text = "http://allus.com.ar";

            this.Contents.Add(wContent);


        }

        public Import(List<Post> posts)
        {
            this.Contents = new List<Content>();
            this.Contenttype = "MovistarPostDemo";

            Content wContent = null;




            //List<Post> posts = RetrivePost(skip + 10);
            int count = posts.Count();
            foreach (Post p in posts)
            {
                wContent = new Content();

                wContent.Author = new Author("author", p.FromUserID.ToString());

                //wContent.Date = System.DateTime.Now;
                wContent.Id = p.PostID;
                wContent.Text.Text = p.Message;
                // wContent.Url_Context.Text = "http://allus.com.ar";


                this.Contents.Add(wContent);
            }




        }

        public Import()
        {
            this.Contents = new List<Content>();
        }
        [XmlElement("contenttype")]
        public string Contenttype { get; set; }

        [XmlArray("contents")]
        [XmlArrayItem("content")]
        public List<Content> Contents { get; set; }

        public String GetXml()
        {
            return Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(this);
        }


    }




    public class Content
    {
        [XmlAttribute("id")]
        public int Id { get; set; }


        [XmlElement("autor")]
        public Author Author { get; set; }

        //Fwk.Xml.CData url_context = new Fwk.Xml.CData();
        //[XmlElement("url_context", Type = typeof(Fwk.Xml.CData))]
        //public Fwk.Xml.CData Url_Context { get { return url_context; } set { url_context = value; } }

        Fwk.Xml.CData text = new Fwk.Xml.CData();
        [XmlElement("texto", Type = typeof(Fwk.Xml.CData))]
        public Fwk.Xml.CData Text { get { return text; } set { text = value; } }

        //Fwk.Xml.CData img = new Fwk.Xml.CData();
        //[XmlElement("img", Type = typeof(Fwk.Xml.CData))]
        //public Fwk.Xml.CData Img { get { return img; } set { img = value; } }

        //Fwk.Xml.CData video = new Fwk.Xml.CData();

        //[XmlElement("video", Type = typeof(Fwk.Xml.CData))]
        //public Fwk.Xml.CData Video { get { return video; } set { video = value; } }



        //long datetime;
        //[XmlElement("datetime")]
        //public long Datetime_UTC
        //{
        //    get { return Date.ToFileTimeUtc(); }
        //    set { datetime = value; }
        //}

        //[XmlIgnore()]
        //public DateTime Date { get; set; }



    }

    public class Author
    {
        //<author type="author">Pepe1989</author>

        public Author() { }
        public Author(string type, string text) { this.Type = type; this.Text = text; }
        [XmlText()]
        public string Text { get; set; }
        [XmlAttribute("type")]
        public string Type { get; set; }
    }

    //<response><status>OK</status><setId>2f08b13e-ec34-412f-a5c3-3def1982ef83</setId></response>
    [Serializable]
    [XmlRootAttribute("response")]
    public class Response
    {
        [XmlElement("status")]
        public String Status { get; set; }

        [XmlElement("setId")]
        public String SetId { get; set; }

        [XmlIgnore()]
        public Guid SetGuid
        {
            get { return new Guid(SetId); }
        }

    }

}
