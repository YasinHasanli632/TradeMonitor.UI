using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMonitorCore.Config
{
    internal class AppSettings
    {
        public string WatchDirectory { get; set; }
        public int CheckIntervalSeconds { get; set; }
        public string[] EnabledLoaders { get; set; }
    }
}
