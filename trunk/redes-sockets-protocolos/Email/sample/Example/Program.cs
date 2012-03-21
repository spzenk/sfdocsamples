using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Example
{
  class Program
  {
    static void Main(string[] args)
    {
      /*
       * WARNING. Be sure to include e-mail server, an existing username and password!
       */
      // Pop3Lib.Client myPop3 = new Pop3Lib.Client("pop.gmail.com", "user name", "password");
      Pop3Lib.Client myPop3 = new Pop3Lib.Client("pop3 host", "user name", "password");

      Pop3Lib.MailItem m;
      while (myPop3.NextMail(out m))
      {
        Console.Write("New message from {0}: {1}", m.From, m.Subject);
        Console.WriteLine("Are you want remove this message (y/n)?");
        if (Console.ReadLine().ToLower().StartsWith("y"))
        {
          // mark for remove
          myPop3.Delete();
          Console.WriteLine("Mail is marked for remove.");
        }
      }

      myPop3.Close();
      Console.ReadKey();
    }
  }
}
