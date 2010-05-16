using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Controls;
using System.Drawing;


namespace WCFDirectHost.Services
{
    [DataContract]   
    public class IntelData
    {
        [DataMember]
        public string Agent { get; set; }

        [DataMember]
        public Bitmap Image { get; set; }

        [DataMember]
        public string Caption { get; set; }

        public IntelData() { }

        public IntelData(string agent, Bitmap image, string caption)
        {
            this.Agent = agent;
            this.Image = image;
            this.Caption = caption;
        }
    }
}
