using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace WindowsFileChecker
{
    public class WhConfig 
    {
        //przerobić na prywatne
        public string dbserver = @"";
        public string dbname = "";
        public string pass = "";
        public string user = "";
        public string directoryWh = @"";
        public string directoryUltima = @"";
        public string connectionString ="";

        public WhConfig()
        {

        }
        public WhConfig(string dbserver, string dbname, string pass, string user, string directoryWh, string directoryUltima)
        {
            this.directoryWh = directoryWh;
            this.dbserver = dbserver;
            this.dbname = dbname;
            this.pass = pass;
            this.user = user;
            this.directoryUltima = directoryUltima;
        }


        public string GetConnectionString()
        {
            connectionString = $@"Data Source = {dbserver}; Initial Catalog = {dbname}; 
                                        Persist Security Info=True; User ID = {user}; Password = {pass}";
            return connectionString;
        }
        public string GetServer()
        {
            return dbserver;
        }
        public string GetBase()
        {
            return dbname;
        }
        public string GetPass()
        {
            return pass;
        }
        public string GetUser()
        {
            return user;
        }
        public string GetUltimaPath()
        {
            return directoryUltima;
        }
        public string GetWhPath()
        {
            return directoryWh;
        }
    }
}
