using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFileChecker
{
    public class OrderCompared : Order
    {
        public bool WhFile { get; set; }
        public bool UltimaFile { get; set; }
        public OrderCompared(int srcdoc, string orderName, string state, DateTime productionDate, string infoType, bool whFile = false, bool ultimaFile = false) 
            : base(srcdoc, orderName, state, productionDate, infoType)
        {
            WhFile = whFile;
            UltimaFile = ultimaFile;           
        }


        public override void WriteAll()
        {
            Console.WriteLine(OrderNumber.ToString().Trim() + " | " + State.ToString() + " | " + ProductionDate.ToString("d")
                + " | Wh: " + IsWhFile() + " | Ultima: " + IsUltimaFile());
        }
        public string IsWhFile()
        {
            return WhFile ? "ok  " : "brak";
        }
        public string IsUltimaFile()
        {
            return UltimaFile ? "ok  " : "brak";
        }


    }
}
