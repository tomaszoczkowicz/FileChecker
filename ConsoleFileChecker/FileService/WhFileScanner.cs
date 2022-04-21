using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileChecker
{
    public class WhFileScanner : FileScanner
    {
        protected override string[] GetData(string path)
        {
            var files = Directory.GetFiles(path, $"*.txt", SearchOption.AllDirectories);
            return files;
        }


        protected override string GetOrderName(string[] rawData)
        {
            string infoLine = "";
            infoLine = rawData.FirstOrDefault(name => name.StartsWith("P;"), "");
            string orderName = "pusty plik";
            if(infoLine != "")
            {
                orderName = infoLine.Split(";")[10];
            }
            return orderName;
        }
    }
}
