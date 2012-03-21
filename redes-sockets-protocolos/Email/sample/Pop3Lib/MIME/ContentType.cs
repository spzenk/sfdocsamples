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
using System.Text.RegularExpressions;

namespace Pop3Lib.MIME
{

  public class ContentType : ParametersBase
  {

    private Encoding _CodePage = null;

    public string Charset 
    { 
      get 
      {
        if (this.Parameters != null && this.Parameters.ContainsKey("charset"))
        {
          return this.Parameters["charset"];
        }
        return "utf-8"; // default
      } 
    }

    public string Boundary 
    {
      get
      {
        if (this.Parameters != null && this.Parameters.ContainsKey("boundary"))
        {
          return this.Parameters["boundary"];
        }
        return String.Empty;
      }
    }

    public string Format
    {
      get
      {
        if (this.Parameters != null && this.Parameters.ContainsKey("format"))
        {
          return this.Parameters["format"];
        }
        return String.Empty;
      }
    }

    public Encoding CodePage
    {
      get
      {
        if (_CodePage == null && !String.IsNullOrEmpty(this.Charset))
        {
          _CodePage = Encoding.GetEncoding(this.Charset);
        }
        else
        {
          _CodePage = Encoding.UTF8;
        }
        return _CodePage;
      }
    }

    public ContentType(string source): base(source) { }

  }
}
