using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcAPI1.Controllers
{
    public class TestController : ApiController
    
    {
        public MvcAPI.Connector.ServiceReference1.WCFAPIServiceClient svcClient = null;
      
        public TestController()
        {
            svcClient = new MvcAPI.Connector.ServiceReference1.WCFAPIServiceClient("tcp");
            
        }
        // GET api/test
        //[HttpGet]
        //public IEnumerable<string> RetriveAll()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        [HttpPost]
        public string RetriveAll2()
        {
            MvcAPI.Connector.ServiceReference1.PMOFile[] pmoList = svcClient.RetrivePMOList();

            return  "value3";
        }
        // GET api/test/5
        //[HttpPost]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/test
        public void Crear([FromBody]string value)
        {
        }

        // PUT api/test/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/test/5
        public void Delete(int id)
        {
        }
    }
}
