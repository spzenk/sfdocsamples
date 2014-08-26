using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using API.Common.BE;

namespace WCFAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class WCFAPIService : IWCFAPIService
    {
        public PMOFileList RetrivePMOList()
        {
            String xml = Fwk.HelperFunctions.FileFunctions.OpenTextFile(@"pmo.xml");
            PMOFileList list = Fwk.HelperFunctions.SerializationFunctions.DeserializeFromXml(typeof(PMOFileList), xml) as PMOFileList;
            return list;
        }

        public PMOContract RetrivePMOListParamas(string filterName)
        {
            if (filterName == null)
            {
                throw new ArgumentNullException("filterName");
            }
            PMOContract res = new PMOContract();
            return res;
        }


     
    }
}
