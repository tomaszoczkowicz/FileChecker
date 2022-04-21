using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WindowsFileChecker
{
    public abstract class FileScanner
    {
        //Template design pattern
        public ProductionFileList GenerateList(string path)
        {
            var rawData = GetData(path);
            return PrepareData(rawData);
        }
        protected abstract string[] GetData(string path);
        protected abstract string GetOrderName(string[] rawData);
        protected ProductionFileList PrepareData(string[] inputlist)
        {
            ProductionFileList resultlist = new();
            foreach (var item in inputlist)
            {
                var currentDocument = File.ReadAllLines(item);
                var name = Path.GetFileName(item);
                var optymalizationNumber = name.Substring(0, 4);
                string orderName = GetOrderName(currentDocument);
                ProductionFile productionFile = new(orderName, name, optymalizationNumber);
                resultlist.Files.Add(productionFile);
            }
            return resultlist;
        }
        
    }
}
