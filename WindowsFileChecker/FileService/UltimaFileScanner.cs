using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFileChecker
{
    public class UltimaFileScanner : FileScanner
    {
        protected override string[] GetData(string path)
        {
            var files = Directory.GetFiles(path, $"*.cmp", SearchOption.TopDirectoryOnly);
            return files;
        }

        protected override string GetOrderName(string[] rawData)
        {
            string infoLine = "";
            infoLine = rawData.FirstOrDefault(name => name.StartsWith("PInfo3"), "");
            string orderName = "pusty plik";
            if (infoLine != "")
            {
                orderName = infoLine.Substring(9);
            }
            return orderName;
        }
    }
}
