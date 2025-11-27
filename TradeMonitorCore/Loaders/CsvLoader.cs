using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeMonitorCore.Interfaces;
using TradeMonitorCore.Models;

namespace TradeMonitorCore.Loaders
{
    public class CsvLoader : IFileLoader
    {
        public string FileType => "CSV";

        public List<TradeRecord> Load(string filePath)
        {
            var records = new List<TradeRecord>();
            foreach (var line in File.ReadAllLines(filePath))
            {
                try
                {
                    var parts = line.Split(',');

                    // Sətirdəki dəyərləri modelə yazırıq
                    var record = new TradeRecord
                    {
                        Date = DateTime.Parse(parts[0]),
                        Open = decimal.Parse(parts[1], CultureInfo.InvariantCulture),
                        High = decimal.Parse(parts[2], CultureInfo.InvariantCulture),
                        Low = decimal.Parse(parts[3], CultureInfo.InvariantCulture),
                        Close = decimal.Parse(parts[4], CultureInfo.InvariantCulture),
                        Volume = long.Parse(parts[5])
                    };
                    records.Add(record);
                }
                catch
                {
                    // Faylda problemli sətir olarsa keçirik
                    continue;
                }
            }
            return records;
        }
    }
}
