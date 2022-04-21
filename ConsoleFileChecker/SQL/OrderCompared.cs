using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileChecker
{
    public class OrderCompared : Order
    {
        public bool WhFile { get; set; }
        public bool UltimaFile { get; set; }
        public string InfoTypeToShow { get; set; } = "";
        public OrderCompared(int srcdoc, string orderName, string state, DateTime productionDate, string infoType, bool whFile = false, bool ultimaFile = false) 
            : base(srcdoc, orderName, state, productionDate, infoType)
        {
            WhFile = whFile;
            UltimaFile = ultimaFile;
            ShowInfo();
        }


        public override void WriteAll()
        {
            Console.WriteLine(OrderNumber.ToString().Trim() + " | " + State.ToString() + " | " + ProductionDate.ToString("d")
                + " | Wh: " + IsWhFile() + " | Ultima: " + IsUltimaFile() + " | " +ShowInfo() );
        }
        public string IsWhFile()
        {
            return WhFile ? "ok  " : "brak";
        }
        public string IsUltimaFile()
        {
            return UltimaFile ? "ok  " : "brak";
        }
        public string ShowInfo()
        {
            return !UltimaFile ? InfoType.ToString() : "";
        }
    }
}
