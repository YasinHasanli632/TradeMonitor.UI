using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TradeMonitorCore.Interfaces;
using TradeMonitorCore.Models;

namespace TradeMonitorCore.Loaders
{
    public class XmlLoader : IFileLoader
    {
        public string FileType => "XML";

        public List<TradeRecord> Load(string filePath)
        {
            var records = new List<TradeRecord>();
            var doc = XDocument.Load(filePath);

            foreach (var el in doc.Descendants("value"))
            {
                try
                {
                    var record = new TradeRecord
                    {
                        Date = DateTime.Parse(el.Attribute("date")?.Value ?? ""),
                        Open = decimal.Parse(el.Attribute("open")?.Value ?? "0", CultureInfo.InvariantCulture),
                        High = decimal.Parse(el.Attribute("high")?.Value ?? "0", CultureInfo.InvariantCulture),
                        Low = decimal.Parse(el.Attribute("low")?.Value ?? "0", CultureInfo.InvariantCulture),
                        Close = decimal.Parse(el.Attribute("close")?.Value ?? "0", CultureInfo.InvariantCulture),
                        Volume = long.Parse(el.Attribute("volume")?.Value ?? "0")
                    };
                    records.Add(record);
                }
                catch
                {
                    continue;
                }
            }
            return records;
        }
    }
}