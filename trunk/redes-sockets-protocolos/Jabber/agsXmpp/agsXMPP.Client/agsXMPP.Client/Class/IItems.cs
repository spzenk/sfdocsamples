using System;
namespace agsXMPP.Client
{
   public interface IItems
    {
        System.Collections.Generic.Dictionary<string, agsXMPP.Jid> JidList { get; set; }
        string Servername { get; set; }
    }
}
