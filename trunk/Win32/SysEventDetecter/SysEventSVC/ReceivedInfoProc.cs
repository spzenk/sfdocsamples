using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SysEvent.Common;
namespace SysEventSVC
{
    internal static class ReceivedInfoProc
    {
        internal static void Process(Byte[] messageInBytes,DateTime time)
        {
            String wStrMessage = Encoding.ASCII.GetString((Byte[])messageInBytes);
            SysEventMessage wSysEvent = (SysEventMessage)SysEvent.Common.Helpers.DeserializeFromXml(typeof(SysEventMessage), wStrMessage);


        }

    }
}
