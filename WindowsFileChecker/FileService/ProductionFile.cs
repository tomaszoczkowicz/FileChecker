using System;
namespace WindowsFileChecker
{
    public class ProductionFile
    {
        protected string OptimalizationNumber { get; }
        public string OrderNumber { get; }
        protected string FileName { get; }
        public void WriteInfo()
        {
            Console.WriteLine(FileName + " " + OrderNumber + " " + OptimalizationNumber);
        }
        public ProductionFile(string orderNumber = "", string fileName = "", string optimalizationNumber = "")
        {
            OrderNumber = orderNumber.Trim();
            FileName = fileName.Trim();
            OptimalizationNumber = optimalizationNumber.Trim();
        }

    }
}