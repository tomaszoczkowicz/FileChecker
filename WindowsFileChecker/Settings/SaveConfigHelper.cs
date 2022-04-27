using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFileChecker
{
    internal static class SaveConfigHelper
    {
        public static void SaveConfigData(WhConfig whConfig)
        {
            var tempWhConfig = JsonConvert.SerializeObject(whConfig);
  
            File.WriteAllText(@".\Settings\Config.json", tempWhConfig);
            
        }
    }
}
