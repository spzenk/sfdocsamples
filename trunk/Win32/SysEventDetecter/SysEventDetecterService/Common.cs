using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace SysEventDetecterService
{

    public  sealed class Helpers
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public static string SerializeToXml(object pObj)
        {
            XmlSerializer wSerializer;
            StringWriter wStwSerializado = new StringWriter();
            XmlTextWriter wXmlWriter = new XmlTextWriter(wStwSerializado);
            XmlSerializerNamespaces wNameSpaces = new XmlSerializerNamespaces();

            wXmlWriter.Formatting = Formatting.Indented;
            wNameSpaces.Add(String.Empty, String.Empty);

            wSerializer = new XmlSerializer(pObj.GetType());
            wSerializer.Serialize(wXmlWriter, pObj, wNameSpaces);


            return wStwSerializado.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", String.Empty);
        }
    }
    public class SysEvent
    {
        string _UserName;

        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        string _MachineName;

        public string MachineName
        {
            get { return _MachineName; }
            set { _MachineName = value; }
        }
        EventTypeEnum _EventType;

        internal EventTypeEnum EventType
        {
            get { return _EventType; }
            set { _EventType = value; }
        }

        string _Message;

        public string Message
        {
            get { return _Message; }
            set { _Message = value; }
        }

    }
    [Serializable]
    public enum EventTypeEnum
    {
        UserPreferenceChanging = 0,
        SessionEnded = 2,
        PowerModeChanged = 4,
        SessionSwitch = 8
    }
}
