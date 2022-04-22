using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFileChecker
{
    public static class LoadConfigHelper
    {
        public static WhConfig LoadConfigData(ref WhConfig whConfig)
        {
            var whConfigSerialized = File.ReadAllText(@".\Settings\Config.json");
            whConfig = JsonConvert.DeserializeObject<WhConfig>(whConfigSerialized);
            return whConfig;
        }
    }
}
