using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PNRPRegistration.Core
{
    public class DisplayMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public DisplayMessage(string title, string message)
        {
            this.Title = title;
            this.Message = message;
        }
    }
}
