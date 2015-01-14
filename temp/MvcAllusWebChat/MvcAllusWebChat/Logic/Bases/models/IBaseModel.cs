using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebChat.Common.Models
{
    public interface IBaseModel
    {


        void Fill(string baseModel);
      
  
        string Redirect { get; set; }

    }
}