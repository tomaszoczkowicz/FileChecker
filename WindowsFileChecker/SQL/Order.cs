using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFileChecker
{
    public class Order
    {
        public int Srcdoc { get; set; }
        public string OrderNumber { get; set; }
        public string State { get; set; }
        public DateTime ProductionDate { get; set; }

        public string InfoType { get; set; }

        public Order(int srcdoc, string orderNumber, string state, DateTime productionDate, string infoType)
        {
            Srcdoc = srcdoc;
            OrderNumber = orderNumber.Trim();
            State = state.Trim();
            ProductionDate = productionDate;
            InfoType = infoType;
        }
        public virtual void WriteAll()
        {
            Console.WriteLine(OrderNumber.ToString().Trim() + " " + State.ToString() + " " + ProductionDate.ToString()) ;
        }
    }

}
