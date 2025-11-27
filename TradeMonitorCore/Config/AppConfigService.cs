using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TradeMonitorCore.Config
{
   

    internal static class AppConfigService
    {
        private const string ConfigFileName = "Config/AppSettings.json";

        public static AppSettings Load()
        {
            try
            {
                string json = File.ReadAllText(ConfigFileName);
                return JsonSerializer.Deserialize<AppSettings>(json) ?? new AppSettings(); ;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"⚠️ Konfiqurasiya faylını oxumaqda xəta: {ex.Message}");
                return new AppSettings
                {
                    WatchDirectory = "C:\\Temp",
                    CheckIntervalSeconds = 5,
                    EnabledLoaders = new[] { "CSV", "TXT", "XML" }
                };

            }

        }
    }
}
