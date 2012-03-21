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
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Pop3Lib
{
  [DefaultProperty("Source")] 
  public class Result
  {
    /// <summary>
    /// Server response source
    /// </summary>
    public string Source { get; set; }
    /// <summary>
    /// Server response error mark
    /// </summary>
    public bool IsError { get; set; }
    /// <summary>
    /// Server message (first line)
    /// </summary>
    public string ServerMessage { get; set; }
    /// <summary>
    /// Response body (excluding first line)
    /// </summary>
    public string Body { get; set; }

    public Result() { }
    public Result(string source)
    {
      this.Source = source;
      this.IsError = source.StartsWith("-ERR"); // is error
      // get server message
      Regex myReg = new Regex(@"(\+OK|\-ERR)\s{1}(?<msg>.*)?", RegexOptions.Multiline | RegexOptions.IgnoreCase);
      if (myReg.IsMatch(source))
      {
        this.ServerMessage = myReg.Match(source).Groups["msg"].Value;
      }
      else
      {
        this.ServerMessage = source;
      }
      // get body
      if (source.IndexOf("\r\n") != -1)
      {
        this.Body = source.Substring(source.IndexOf("\r\n") + 2, source.Length - source.IndexOf("\r\n") - 2);
        if (this.Body.IndexOf("\r\n\r\n.\r\n") != -1)
        {
          this.Body = this.Body.Substring(0, this.Body.IndexOf("\r\n\r\n.\r\n"));
        }
      }
      // --
    }

    /// <summary>
    /// Realize an implicit conversion operator
    /// </summary>
    public static implicit operator Result(string value)
    {
      return new Result(value);
    }

    /// <summary>
    /// Get messages count and size.
    /// Only for STAT command
    /// </summary>
    /// <param name="messagesCount">Return messages count (from 1)</param>
    /// <param name="messagesSize">Return messages size (byte)</param>
    public void ParseStat(out int messagesCount, out int messagesSize)
    {
      Regex myReg = new Regex(@"(?<count>\d+)\s+(?<size>\d+)");
      Match m = myReg.Match(this.Source);
      int.TryParse(m.Groups["count"].Value, out messagesCount);
      int.TryParse(m.Groups["size"].Value, out messagesSize);
    }

    /// <summary>
    /// Return mail object
    /// </summary>
    public void ParseMail(out MailItem m)
    {
      m = new MailItem(this.Body);
    }

  }
}
