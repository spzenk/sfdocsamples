using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;

namespace BuzzwordBingo.Core
{
    [DataContract]
    public class Profile
    {

        [DataMember]
        public string Name { get; set; }

        //[DataMember]
        //public Bitmap Image { get; set; }

        public Profile(string player)
        {
            this.Name = player;
        }

        //public Profile(string player, Bitmap image)
        //    : this(player)
        //{
        //    this.Image = image;
        //}
    }
}
