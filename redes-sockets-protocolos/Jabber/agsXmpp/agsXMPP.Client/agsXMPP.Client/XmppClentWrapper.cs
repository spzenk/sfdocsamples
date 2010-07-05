using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agsXMPP;
using agsXMPP.protocol;
using agsXMPP.protocol.iq;
using agsXMPP.protocol.iq.disco;
using agsXMPP.protocol.iq.roster;
using agsXMPP.protocol.iq.version;
using agsXMPP.protocol.iq.oob;
using agsXMPP.protocol.client;
using agsXMPP.protocol.extensions.shim;
using agsXMPP.protocol.extensions.si;
using agsXMPP.protocol.extensions.bytestreams;

using agsXMPP.protocol.x;
using agsXMPP.protocol.x.data;

using agsXMPP.Xml;
using agsXMPP.Xml.Dom;

using agsXMPP.sasl;

using agsXMPP.ui;
using agsXMPP.ui.roster;

using System.Security.Cryptography;


using agsXMPP.protocol.stream.feature.compression;
namespace agsXMPP.Client
{
    public class XmppClentWrapper
    {
        private XmppClientConnection XmppCon;
        //private DiscoHelper discoHelper;
        DiscoManager discoManager;
        public XmppClentWrapper()
        {

            XmppCon = new XmppClientConnection();

            XmppCon.SocketConnectionType = agsXMPP.net.SocketConnectionType.Direct;
            XmppCon.OnIq += new IqHandler(XmppCon_OnIq);
            XmppCon.OnMessage += new MessageHandler(XmppCon_OnMessage);

            XmppCon.OnLogin += new ObjectHandler(XmppCon_OnLogin);
        }

        void XmppCon_OnIq(object sender, IQ iq)
        {

        }

        void XmppCon_OnMessage(object sender, agsXMPP.protocol.client.Message msg)
        {

        }

        void XmppCon_OnLogin(object sender)
        {
        }

        public void Connect()
        { }
    }


}
