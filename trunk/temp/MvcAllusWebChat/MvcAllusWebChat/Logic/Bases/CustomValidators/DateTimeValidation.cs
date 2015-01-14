using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebChat.Common.Bases
{
    public class RangeDateValidation : ValidationAttribute
    {
        public int Start_Year { get; set; }
        public int Start_Day { get; set; }
        public int Start_Month { get; set; }

        public int End_Year { get; set; }
        public int End_Day { get; set; }
        public int End_Month { get; set; }
     
       protected override ValidationResult IsValid(object value, ValidationContext validationContext)
       {
           DateTime dt;
           bool parsed = DateTime.TryParse((string)value, out dt);
           if (!parsed)
               return new ValidationResult(this.ErrorMessage);

           //if (dt > DateTime.Now.Subtract(new TimeSpan(Start_Year, 0, 0, 0)) &&
           //     dt < DateTime.Now.Subtract(new TimeSpan(End_Year, 0, 0, 0)))
           //    return ValidationResult.Success;


            if ((dt >= DateTime.Now.AddYears(-Start_Year)) &&  (dt <= DateTime.Now.AddYears(-End_Year)))
                return ValidationResult.Success;

           return ValidationResult.Success;
           
       }
     
    }
    /// <summary>
    /// Valida formato dd/mm/yyyy hh:mm
    /// </summary>
    public class DateTimeValidation : RegularExpressionAttribute
    {
        public DateTimeValidation()
            : base(@"^((((31\/(0?[13578]|1[02]))|((29|30)\/(0?[1,3-9]|1[0-2])))\/(1[6-9]|[2-9]\d)?\d{2})|(29\/0?2\/(((1[6-9]|[2-9]\d)?(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))|(0?[1-9]|1\d|2[0-8])\/((0?[1-9])|(1[0-2]))\/((1[6-9]|[2-9]\d)?\d{2})) (20|21|22|23|[0-1]?\d):[0-5]?\d$")
        {
            ErrorMessage = "La fecha debe tener el formato : dd/mm/yyyy hh:mm";
        }
    }
}