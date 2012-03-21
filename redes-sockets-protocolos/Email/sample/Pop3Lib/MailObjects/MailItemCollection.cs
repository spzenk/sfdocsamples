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

namespace Pop3Lib
{
  public class MailItemCollection : List<MailItemBase>
  {

    public void AddItem(string source)
    {
      this.Add(new MailItemBase(source));
    }

  }
}
