using System;
using Fwk.Bases;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections;

namespace Fwk.SocialNetworks.Twitter.Entities
{
    [XmlInclude(typeof(User)), Serializable]
    public class User : Entity
    {
        public int id { get; set; }

        public string name { get; set; }

        public string screen_name { get; set; }

        public string profile_image_url { get; set; }

        public string created_at { get; set; }
    }
}