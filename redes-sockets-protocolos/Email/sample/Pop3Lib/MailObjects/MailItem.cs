/*
 * This is example for article: 
 * http://kbyte.ru/ru/Programming/Articles.aspx?id=65&mode=art
 * (only russian language)
 * Author: Aleksey S Nemiro
 * http://aleksey.nemiro.ru
 * http://kbyte.ru
 * August 27, 2011
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Collections;

namespace Pop3Lib
{
  public class MailItem : MailItemBase
  {

    private MailAddress _To = null;
    private MailAddress _From = null;
    private MailAddress _ReturnPath = null;

    /// <summary>
    /// Subject of the mail
    /// </summary>
    public string Subject 
    { 
      get
      {
        if (this.Headers.ContainsKey("Subject")) return this.Headers["Subject"].ToString();
        return String.Empty;
      }
    }

    /// <summary>
    /// Sender of the mail
    /// </summary>
    public MailAddress From
    { 
      get
      {
        if (_From == null)
        {
          if (!this.Headers.ContainsKey("From")) return null;
          _From = ParseMail(this.Headers["From"].ToString());
        }
        return _From;
      }
    }

    /// <summary>
    /// Recipient of the mail
    /// </summary>
    public MailAddress To
    { 
      get
      {
        if (_To == null)
        {
          if (!this.Headers.ContainsKey("To")) return null;
          _To = ParseMail(this.Headers["To"].ToString());
        }
        return _To;
      }
    }

    /// <summary>
    /// Return path
    /// </summary>
    public MailAddress ReturnPath
    { 
      get
      {
        if (_ReturnPath == null)
        {
          if (!this.Headers.ContainsKey("Return-Path")) return null;
          _ReturnPath = ParseMail(this.Headers["Return-Path"].ToString());
        }
        return _ReturnPath;
      }
    }

    /// <summary>
    /// Date of the mail
    /// </summary>
    public DateTime? Date
    { 
      get
      {
        if (this.Headers.ContainsKey("Date"))
        {
          return Convert.ToDateTime(this.Headers["Date"]);
        }
        return null;
      }
    }

    public MailItem(string source) : base(source) { }

    /// <summary>
    /// The function parses the e-mail address and returns an object of type MailAddress
    /// </summary>
    private MailAddress ParseMail(string source)
    {
      if (String.IsNullOrEmpty(source)) return null;
      Regex myReg = new Regex(@"(?<name>[^\<]*?)[\<]{0,1}(?<email>[A-Za-zА-Яа-яЁё0-9_\-\.]+@[A-Za-zА-Яа-яЁё0-9_\-\.]+)[\>]{0,1}", RegexOptions.IgnoreCase | RegexOptions.Multiline);
      Match m = myReg.Match(source);
      if (m == null || String.IsNullOrEmpty(m.Value)) return null;
      string email = m.Groups["email"].Value.Trim();
      if (String.IsNullOrEmpty(email)) return null;
      string name = m.Groups["name"].Value.Trim("\" ".ToCharArray());
      return new MailAddress(email, name);
    }

  }
}
