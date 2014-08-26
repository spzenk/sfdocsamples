using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvcAPI.Connector.ServiceReference1;
namespace MvcAPI.Connector
{
    public class PMOFilerepository : MvcAPI.Connector.IPMOFilerepository
    {
        public MvcAPI.Connector.ServiceReference1.WCFAPIServiceClient svcClient = null;

        public PMOFilerepository()
        {
            svcClient = new WCFAPIServiceClient("tcp");
          
        }
        public IEnumerable<PMOFile> RetrivePMOList()
        {
            return svcClient.RetrivePMOList();
        }
        public PMOContract RetrivePMOListParamas(string filterName)
        {
            return svcClient.RetrivePMOListParamas(filterName);
        }
    }
}
