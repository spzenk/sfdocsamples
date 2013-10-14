using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TRIS.Web
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICarService" in both code and config file together.
    [ServiceContract]
    public interface ICarService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/list", ResponseFormat = WebMessageFormat.Json)]
        string GetCarList();

        [OperationContract]
        [WebInvoke(UriTemplate = "/car/{id}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        string GetCar(string id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/car", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string SetCar(Stream stream);
    }
}
