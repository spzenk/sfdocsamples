using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EntityFramework
{
    [JsonObject(MemberSerialization.OptIn)]// OptIn solo serializa las q tienn nel atributo JsonProperty
    public class ProductMapp
    {
        [JsonProperty]
        public int ProductID
        {
            get;
            set;
        }
        public string Name
        {
            get;
            set;
        }
        public string ProductNumber
        {
            get;
            set;
        }
        public bool MakeFlag
        {
            get;
            set;
        }
        [JsonProperty]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime SellStartDate
        {
            get;
            set;
        }

    }
}
