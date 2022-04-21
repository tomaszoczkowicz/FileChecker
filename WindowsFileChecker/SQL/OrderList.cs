using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFileChecker
{
    public class OrderList 
    {
       public ObservableCollection<Order> Orders = new();


        public void WriteAll()
        {
            Console.WriteLine("Status najbliższych zleceń:");
            Console.WriteLine("Nazwa zlecenia         | Status    | Data prod  |      Status pliku");
            Console.WriteLine("------------------------------------------------------------------------");
            foreach (var item in Orders)
            {
                item.WriteAll();   
            }
        }

    }
}
