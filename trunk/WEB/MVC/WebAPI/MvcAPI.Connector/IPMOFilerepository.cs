using System;
namespace MvcAPI.Connector
{
   public  interface IPMOFilerepository
    {
        System.Collections.Generic.IEnumerable<MvcAPI.Connector.ServiceReference1.PMOFile> RetrivePMOList();
        MvcAPI.Connector.ServiceReference1.PMOContract RetrivePMOListParamas(string filterName);
    }
}
