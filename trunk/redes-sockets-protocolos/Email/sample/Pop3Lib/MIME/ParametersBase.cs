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
  /// <summary>
  /// Base class for processing parameters in the value of MIME-headers
  /// </summary>
  public class ParametersBase
  {

    private string _Source = String.Empty;
    private string _Type = String.Empty;
    private ParametersCollection _Parameters = null;

    public string Source { get { return _Source; } }

    public string Type { get { return _Type; } }

    public ParametersCollection Parameters { get { return _Parameters; } }

    public ParametersBase(string source)
    {
      if (String.IsNullOrEmpty(source)) return;
      _Source = source;
      int typeTail = source.IndexOf(";");
      if (typeTail == -1)
      {
        _Type = source;
        return;
      }
      _Type = source.Substring(0, typeTail);
      string p = source.Substring(typeTail + 1, source.Length - typeTail - 1);
      _Parameters = new ParametersCollection();
      Regex myReg = new Regex(@"(?<key>.+?)=((""(?<value>.+?)"")|((?<value>[^\;]+)))[\;]{0,1}", RegexOptions.Singleline);
      MatchCollection mc = myReg.Matches(p);
      foreach (Match m in mc)
      {
        if (!_Parameters.ContainsKey(m.Groups["key"].Value))
        {
          _Parameters.Add(m.Groups["key"].Value.Trim(), m.Groups["value"].Value);
        }
      }
    }

  }
}
