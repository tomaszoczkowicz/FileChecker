using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileChecker
{
    public class OrderList 
    {
       public List<Order> Orders = new();


        public void WriteAll()
        {
            Console.WriteLine("Status najbliższych zleceń:");
            Console.WriteLine("Nazwa zlecenia         | Status    | Data prod  |      Status pliku       |     Typ brakujący  ");
            Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------");
            foreach (var item in Orders)
            {
                item.WriteAll();   
            }
        }

    }
}
