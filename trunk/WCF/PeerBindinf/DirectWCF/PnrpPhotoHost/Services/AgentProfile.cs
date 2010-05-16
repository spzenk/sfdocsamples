using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;



namespace WCFDirectHost.Services {

    [DataContract]
    public class AgentProfile {

        [DataMember]
        public string Agent { get; set; }

        [DataMember]
        public Bitmap Image { get; set; }

        public AgentProfile(string agent) {
            this.Agent = agent;
        }

        public AgentProfile(string agent, Bitmap image) : this(agent){
            this.Image = image;
        }
    }
}
