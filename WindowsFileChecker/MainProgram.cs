using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFileChecker
{
    public static class MainProgram
    {
        

        public static OrderList StartProgram()
        {


            WhConfig whConfig = new();

                SqlScanner scanner = new(whConfig);
                OrderList orderList = scanner.GenerateOrderList();




            WhFileScanner whFileScanner = new();
                ProductionFileList whFileList = whFileScanner.GenerateList(whConfig.GetWhPath());


                UltimaFileScanner ultimaWhScanner = new();
                ProductionFileList ultimaFileList = ultimaWhScanner.GenerateList(whConfig.GetUltimaPath());


                ListComparer listComparer = new(orderList, whFileList, ultimaFileList);
                OrderList result;
            
            return result = listComparer.Compare();

           


        }
        
}
}
