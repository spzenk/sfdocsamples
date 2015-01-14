using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fwk.Bases;
using Fwk.Exceptions;
using System.ComponentModel;
using Newtonsoft.Json;

namespace WebChat.Common.Models
{

    public class BaseModel : IBaseModel
    {

        public BaseModel() { }
        public void Fill(String baseModel)
        {
            BaseModel wBaseModel = JsonConvert.DeserializeObject(baseModel, typeof(BaseModel), new JsonSerializerSettings()) as BaseModel;

            //this.FirstName = wBaseModel.FirstName;
            //this.LastName = wBaseModel.LastName;
            //this.HealtInstitutionId = wBaseModel.HealtInstitutionId;
       
            //this.RazonSocial = wBaseModel.RazonSocial;
            //this.Email = wBaseModel.Email;

            this.FullName = wBaseModel.FullName;
        }
       
        public String userId { get; set; }
        public String Redirect { get; set; }
        public String FullName { get; set; }
        public String PhotoURL { get; set; }
        public int ProfesionalId { get; set; }
        
        [DisplayName("Seleccione modo de autenticacion")]
        public String AuthenticationModeId { get; set; }

   



        //Valor Conrtoller,Page
        public ErrorModel Error { get; set; }



    }
}