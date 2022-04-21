using ConsoleFileChecker;

Console.SetWindowSize(130, 55);
WhConfig whConfig = new WhConfig();

while (true)
{

    SqlScanner scanner = new(whConfig);
    OrderList orderList = scanner.GenerateOrderList();
    //orderList.WriteAll();

    Console.WriteLine("Wczytywanie");

    WhFileScanner whFileScanner = new();
    ProductionFileList whFileList = whFileScanner.GenerateList(whConfig.GetWhPath());
    //whFileList.WriteAll();

    UltimaFileScanner ultimaWhScanner = new();
    ProductionFileList ultimaFileList = ultimaWhScanner.GenerateList(whConfig.GetUltimaPath());
    //ultimaFileList.WriteAll();
    Console.Clear();


    ListComparer listComparer = new(orderList, whFileList, ultimaFileList);
    listComparer.Compare();

    Console.WriteLine("Naciśnij klawisz, by odświeżyć");
    Console.ReadKey();
    Console.Clear();

}



