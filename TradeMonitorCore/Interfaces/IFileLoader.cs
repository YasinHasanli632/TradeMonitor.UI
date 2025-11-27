using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeMonitorCore.Models;

namespace TradeMonitorCore.Interfaces
{
    internal interface IFileLoader
    {
        string FileType { get; }  // Məs: "CSV", "TXT", "XML"
        List<TradeRecord> Load(string filePath);//Fayl oxudan metod
    }
}
