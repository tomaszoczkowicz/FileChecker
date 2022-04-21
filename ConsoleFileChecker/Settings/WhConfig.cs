using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleFileChecker
{
    public class WhConfig 
    {
        //zrobić niestatyczną, która deserializuje dane z pliku .json
        private string dbserver = @"SERWER3\WHOKNA";
        private string dbname = "GLOWNA_NEW";
        private string pass = "excel";
        private string user = "excel2k18";
        private string directoryWh = @"\\SERWER2\HalaPliki\Pliki_WH\";
        private string directoryUltima = @"\\Serwer2\HalaPliki\Pliki_ULTIMA\";
        private string connectionString ="";

        public string GetConnectionString()
        {
            connectionString = $@"Data Source = {dbserver}; Initial Catalog = {dbname}; 
                                        Persist Security Info=True; User ID = {user}; Password = {pass}";
            return connectionString;
        }
        public string GetWhPath()
        {
            return directoryWh;
        }
        public string GetUltimaPath()
        {
            return directoryUltima;
        }
    }
}
