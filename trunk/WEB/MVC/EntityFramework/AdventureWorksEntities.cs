using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Runtime.Serialization;
using System.IO;

namespace EntityFramework
{
    partial class Product
    {
        partial void OnNameChanging(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new Fwk.Exceptions.FunctionalException(1000,"Nomnre no puede ser nulo");
        }
        
    }

    public class Helper
    {
        //public static Helper(string xmlString)
        //{

        //    Product product;
        //    byte[] byteArray = Encoding.ASCII.GetBytes(xmlString);
        //    using (MemoryStream stream = new MemoryStream(byteArray))
        //    {
        //        XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8);
        //        DataContractSerializer srlz = new DataContractSerializer(typeof(Product));
        //       // srlz.Serialize(writer, product);
        //        writer.Close(); // ensure it's properly flushed

        //    }

         
        //}
    }


}
