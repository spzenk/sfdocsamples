using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebService_Asinc
{
  
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Service1 : System.Web.Services.WebService
    {

       
        [WebMethod]
        public Employee ExecuteService(String name)
        {


            EmployeeDataContext dc = new EmployeeDataContext();
            var empleado = from emp in dc.Employees where emp.Contact.FirstName == name select emp;
            return empleado.First<Employee>();
 
        }

        //public RemoteService remoteService;
        //[WebMethod]
        //public IAsyncResult BegIngExecuteService(String Author, AsyncCallback callback, object asyncState)
        //{
        //    // Begin asynchronous communictation with a different XML Web
        //    // service.
        //    return remoteService.BeginReturnedStronglyTypedDS(Author,
        //        callback, asyncState);
        //}
        //// Define the End method.
        //[WebMethod]
        //public Employee EndGetExecuteService(IAsyncResult asyncResult)
        //{
        //    // Return the asynchronous result from the other Web service.
        //    return remoteService.EndReturnedStronglyTypedDS(asyncResult);
        //}
    }
}
