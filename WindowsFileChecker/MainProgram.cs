using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFileChecker
{
    public static class MainProgram
    {
        public delegate void UpdateStatus(string text);

        public static async Task<OrderList> StartProgram(UpdateStatus updateStatus)
        {

            WhConfig whConfig = new();
            updateStatus("Ładowanie ustawień...");
            LoadConfigHelper.LoadConfigData(ref whConfig);
            SqlScanner scanner = new(whConfig);
            updateStatus("Łączenie z bazą...");
            OrderList orderList = await Task.Run(() => scanner.GenerateOrderList());

            WhFileScanner whFileScanner = new();
            updateStatus("Skanowanie plików WH...");
            ProductionFileList whFileList = await Task.Run(() => whFileScanner.GenerateList(whConfig.GetWhPath()));

            UltimaFileScanner ultimaWhScanner = new();
            updateStatus("Skanowanie plików Ultima...");
            ProductionFileList ultimaFileList = await Task.Run(() => ultimaWhScanner.GenerateList(whConfig.GetUltimaPath()));

            ListComparer listComparer = new(orderList, whFileList, ultimaFileList);
            OrderList result;
            updateStatus("Porównanie danych...");
            return result = await Task.Run(() => listComparer.Compare());        

        }
        
}
}
