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
using System.Collections;
using System.Text.RegularExpressions;

namespace Pop3Lib
{
  /// <summary>
  /// Base class for mail or parts
  /// </summary>
  public class MailItemBase
  {

    private string _Source = String.Empty;
    private Dictionary<string, object> _Headers = null;
    private Pop3Lib.MIME.ContentType _ContentType = null;
    private Pop3Lib.MIME.ContentDisposition _ContentDisposition = null;
    private string _ContentTransferEncoding = String.Empty;
    private object _Data = null;

    /// <summary>
    /// Source of the mail (MIME)
    /// </summary>
    public string Source
    {
      get { return _Source; }
    }

    /// <summary>
    /// MIME-headers collection
    /// </summary>
    public Dictionary<string, object> Headers
    {
      get { return _Headers; }
    }

    /// <summary>
    /// Content type
    /// </summary>
    public Pop3Lib.MIME.ContentType ContentType
    {
      get { return _ContentType; }
    }

    /// <summary>
    /// Content disposition
    /// </summary>
    public Pop3Lib.MIME.ContentDisposition ContentDisposition
    {
      get { return _ContentDisposition; }
    }

    /// <summary>
    /// Content transfer encoding
    /// </summary>
    public string ContentTransferEncoding
    {
      get { return _ContentTransferEncoding; }
    }

    /// <summary>
    /// Content of the mail or part
    /// </summary>
    public object Data
    {
      get { return _Data; }
    }

    /// <summary>
    /// Return true for empty parts
    /// </summary>
    public bool IsEmpty
    {
      get 
      {
        return _Data == null ||
          (_Data.GetType() == typeof(string) && String.IsNullOrEmpty(_Data.ToString())) ||
          (_Data.GetType() == typeof(byte[]) && ((byte[])_Data).Length <= 0) ||
          (_Data.GetType() == typeof(MailItemCollection) && ((MailItemCollection)_Data).Count <= 0);
      }
    }

    /// <summary>
    /// Return true for text part
    /// </summary>
    public bool IsText
    {
      get { return _Data != null && _Data.GetType() == typeof(string); }
    }

    /// <summary>
    /// Return true for binary part
    /// </summary>
    public bool IsBinary
    {
      get { return _Data != null && _Data.GetType() == typeof(byte[]); }
    }

    /// <summary>
    /// Return true for multiparts
    /// </summary>
    public bool IsMultipart
    {
      get { return _Data != null && _Data.GetType() == typeof(MailItemCollection); }
    }

    public MailItemBase() { }

    public MailItemBase(string source)
    {
      if (String.IsNullOrEmpty(source))
      {
        throw new Exception("Source is required.");
      }
      _Source = source;
      // get headers
      int headersTail = source.IndexOf("\r\n\r\n"); // for next time
      string h = String.Empty;
      if (headersTail == -1)
      {  // tail not found. Source as headers.
        h = source;
      }
      else
      { // separate headers
        h = source.Substring(0, headersTail);
      }
      _Headers = ParseHeaders(h);

      if (headersTail == -1) return; // tail not found and not mail body (only headers). exit.

      // get mail body
      string b = source.Substring(headersTail + 4, source.Length - headersTail - 4); // 4 = "\r\n\r\n".Length
      if (_Headers.ContainsKey("Content-Transfer-Encoding"))
      {
        _ContentTransferEncoding = _Headers["Content-Transfer-Encoding"].ToString().ToLower();
      }
      if (_Headers.ContainsKey("Content-Type"))
      {
        _ContentType = new Pop3Lib.MIME.ContentType(_Headers["Content-Type"].ToString());
      }
      else
      {
        _ContentType = new Pop3Lib.MIME.ContentType("");
      }
      if (_Headers.ContainsKey("Content-Disposition"))
      {
        _ContentDisposition = new Pop3Lib.MIME.ContentDisposition(_Headers["Content-Disposition"].ToString());
      }

      // parse content
      if (_ContentType.Type.StartsWith("multipart"))
      {
        // is multipart
        ParseMultiPart(b); // parse multipart
      }
      else if (_ContentType.Type.StartsWith("application") || _ContentType.Type.StartsWith("image") || _ContentType.Type.StartsWith("video") || _ContentType.Type.StartsWith("audio"))
      {
        // is binary
        if (_ContentTransferEncoding != "base64")
        {
          throw new Exception("Base64 expected...");
        }
        _Data = Convert.FromBase64String(b);
      }
      else
      { // is text
        _Data = DecodeContent(_ContentTransferEncoding, b);
      }
    }

    /// <summary>
    /// The method parses multipart content
    /// </summary>
    private void ParseMultiPart(string b)
    {
      Regex myReg = new Regex(String.Format(@"(--{0})([^\-]{{2}})", _ContentType.Boundary), RegexOptions.Multiline);
      MatchCollection mc = myReg.Matches(b);
      // create collection
      MailItemCollection items = new MailItemCollection();
      // search parts by boundary
      for (int i = 0; i <= mc.Count - 1; i++)
      {
        int start = mc[i].Index + String.Format("--{0}", _ContentType.Boundary).Length;
        int len = 0;
        if (i + 1 > mc.Count - 1)
        {
          len = b.Length - start;
        }
        else
        {
          len = (mc[i + 1].Index - 1) - start;
        }
        string part = b.Substring(start, len).Trim("\r\n".ToCharArray());
        int partTail = 0;
        if ((partTail = part.LastIndexOf(String.Format("--{0}--", _ContentType.Boundary))) != -1)
        {
          part = part.Substring(0, partTail);
        }
        items.AddItem(part);
      }
      // set collection as mail content
      _Data = items;
    }

    /// <summary>
    /// The function parses the headers and returns the Dictionary
    /// </summary>
    /// <param name="h">Источник, из которого нужно получить заголовки</param>
    private Dictionary<string, object> ParseHeaders(string h)
    {
      Dictionary<string, object> result = new Dictionary<string, object>(StringComparer.CurrentCultureIgnoreCase);
      // decode data
      h = Regex.Replace(h, @"([\x22]{0,1})\=\?(?<cp>[\w\d\-]+)\?(?<ct>[\w]{1})\?(?<value>[^\x3f]+)\?\=([\x22]{0,1})", HeadersEncode, RegexOptions.Multiline | RegexOptions.IgnoreCase);
      // replace spaces
      h = Regex.Replace(h, @"([\r\n]+)^(\s+)(.*)?$", " $3", RegexOptions.Multiline);
      // parse
      Regex myReg = new Regex(@"^(?<key>[^\x3A]+)\:\s{1}(?<value>.+)$", RegexOptions.Multiline);
      MatchCollection mc = myReg.Matches(h);
      foreach (Match m in mc)
      {
        string key = m.Groups["key"].Value;
        if (result.ContainsKey(key))
        {
          // key is exists
          if (result[key].GetType() == typeof(string))
          {
            // create collection
            ArrayList arr = new ArrayList();
            // add first value to collection
            arr.Add(result[key]);
            // and current value
            arr.Add(m.Groups["value"].Value);
            // set collection as header
            result[key] = arr;
          }
          else
          {
            // header is collection
            // add item
            ((ArrayList)result[key]).Add(m.Groups["value"].Value);
          }
        }
        else
        {
          // value is text
          result.Add(key, m.Groups["value"].Value.TrimEnd("\r\n ".ToCharArray()));
        }
      }
      return result;
    }

    private string HeadersEncode(Match m)
    {
      string result = String.Empty;
      Encoding cp = Encoding.GetEncoding(m.Groups["cp"].Value);
      if (m.Groups["ct"].Value.ToUpper() == "Q")
      {
        // Quoted-Printable
        result = ParseQuotedPrintable(m.Groups["value"].Value);
      }
      else if (m.Groups["ct"].Value.ToUpper() == "B")
      {
        // Base64
        result = cp.GetString(Convert.FromBase64String(m.Groups["value"].Value));
      }
      else
      {
        result = m.Groups["value"].Value;
      }
      return result; //ConvertCodePage(result, cp);
    }

    /// <summary>
    /// The function performs decoding Quoted-Printable.
    /// </summary>
    /// <param name="source">Текст для декодирования</param>
    private string ParseQuotedPrintable(string source)
    {
      source = source.Replace("_", " ");
      source = Regex.Replace(source, @"(\=)([^\dABCDEFabcdef]{2})", "");
      return Regex.Replace(source, @"\=(?<char>[\d\w]{2})", QuotedPrintableEncode);
    }
    private string QuotedPrintableEncode(Match m)
    {
      return ((char)int.Parse(m.Groups["char"].Value, System.Globalization.NumberStyles.AllowHexSpecifier)).ToString();
    }
    
    private string ConvertCodePage(string source, Encoding source_encoding)
    {
      if (source_encoding == Encoding.Default) return source;
      return Encoding.Default.GetString(source_encoding.GetBytes(source));
    }
    private string ConvertCodePage(byte[] source, Encoding source_encoding)
    {
      if (source_encoding == Encoding.Default) return Encoding.Default.GetString(source);
      return Encoding.Default.GetString(Encoding.Default.GetBytes(source_encoding.GetString(source)));
    }

    private string DecodeContent(string contentTransferEncoding, string source)
    {
      if (contentTransferEncoding == "base64")
      {
        return ConvertCodePage(Convert.FromBase64String(source), _ContentType.CodePage);
      }
      else if (contentTransferEncoding == "quoted-printable")
      {
        return ConvertCodePage(ParseQuotedPrintable(source), _ContentType.CodePage);
      }
      else
      { //"8bit", "7bit", "binary"
        return ConvertCodePage(source, _ContentType.CodePage);
      }
    }

    public string GetText()
    {
      if (!this.IsText) return String.Empty;
      return _Data.ToString();
    }

    public byte[] GetBinary()
    {
      if (!this.IsBinary) return null;
      return (byte[])_Data;
    }

    public MailItemCollection GetItems()
    {
      if (!this.IsMultipart) return null;
      return (MailItemCollection)_Data;
    }

  }
}
