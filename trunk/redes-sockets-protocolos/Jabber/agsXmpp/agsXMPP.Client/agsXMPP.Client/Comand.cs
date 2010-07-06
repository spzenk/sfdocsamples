using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agsXMPP.Xml.Dom;

namespace agsXMPP.Client
{
    public class Comand : Element
    {
        public Comand()
        {
            this.TagName = "comand";
            this.Namespace = "fwk.jabber:command";
        }
        public Comand(string type, int value)
            : this()
        {
            this.Type = type;
            this.Value = value;
        }
        public string Type
        {
            get { return GetTag("type"); }
            set { SetTag("type", value); }
        }

        public int Value
        {
            get { return GetTagInt("value"); }
            set { SetTag("value", value.ToString()); }
        }
    }
}
