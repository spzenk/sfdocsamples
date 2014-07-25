using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Fwk.Log4net
{
    public class CustomRollingFileAppender : log4net.Appender.RollingFileAppender
    {
        protected override void OpenFile(string fileName, bool append)
        {
            //Inject folder [yyyyMMdd] before the file name
            string baseDirectory = Path.GetDirectoryName(fileName);
            string fileNameOnly = Path.GetFileName(fileName);
            string newDirectory = Path.Combine(baseDirectory, DateTime.Now.ToString("yyyyMMdd"));
            string newFileName = Path.Combine(newDirectory, fileNameOnly);

            base.OpenFile(newFileName, append);
        }
    }
}
