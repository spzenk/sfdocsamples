using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Common.BE;
using WebChat.Logic.DAC;

namespace WebChat.Logic.BC
{
    public class ApplicationSettingBC
    {
        public static List<ApplicationSettingBE> SearchApplicationSetting()
        {
            return ChatConfigDAC.SearchApplicationSettings();
        }
    }
}