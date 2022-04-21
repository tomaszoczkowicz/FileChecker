using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFileChecker
{
    public class ProductionFileList 
    {
        public List<ProductionFile> Files = new();


        public void WriteAll()
        {
            Console.WriteLine("Orders in directory:");
            foreach (var item in Files)
            {
                item.WriteInfo();
            }
        }

    }
}
