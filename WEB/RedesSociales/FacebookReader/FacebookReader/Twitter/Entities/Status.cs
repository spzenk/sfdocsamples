using System;
using Fwk.Bases;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Collections;

namespace Fwk.SocialNetworks.Twitter.Entities
{
    //[XmlInclude(typeof(Status)), XmlInclude(typeof(User)), Serializable]    

    public class Status : Entity
    {
        public int id { get; set; }

        public string text { get; set; }

        public string created_at { get; set; }

        public int in_reply_to_user_id { get; set; }

        public int in_reply_to_status_id { get; set; }

        public User user { get; set; }
    }

    //[XmlRoot("Statuses"), SerializableAttribute]
    public class Statuses : Entities<Status> { }
}
