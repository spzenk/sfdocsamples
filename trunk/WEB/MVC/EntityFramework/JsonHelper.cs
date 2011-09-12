using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.IO;

namespace EntityFramework
{
  
   /// <summary>
    /// http://samscode.com/index.php/2010/06/entity-framework-v4-end-to-end-application-strategy-part-2-data-layer/
   /// </summary>
    public static class JsonHelper
    {
        private static readonly JsonSerializer s_serializer = new JsonSerializer();


        static JsonHelper()
        {
            s_serializer.Converters.Add(new IsoDateTimeConverter());
            s_serializer.MissingMemberHandling = MissingMemberHandling.Ignore;
            s_serializer.NullValueHandling = NullValueHandling.Include;
            s_serializer.PreserveReferencesHandling = PreserveReferencesHandling.None;
            s_serializer.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            
        }


        public static string Serialize(object obj, bool format = false)
        {
            StringWriter stringWriter = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(stringWriter);
            jsonWriter.Formatting = format ? Formatting.Indented : Formatting.None;
            s_serializer.Serialize(jsonWriter, obj);
            return stringWriter.ToString();
        }


        public static T Deserialize<T>(string json)
        {
            StringReader reader = new StringReader(json);
            return (T)s_serializer.Deserialize(reader, typeof(T));
        }
    }

}
