using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeMonitorCore.Interfaces;
using TradeMonitorCore.Models;

//Folder - i izləyir(yeni fayl tapmaq üçün)
namespace TradeMonitorCore.Services
{
    internal class FileProcessingService
    {
        private readonly List<IFileLoader> _loaders;

        public FileProcessingService(IEnumerable<IFileLoader> loaders)
        {
            _loaders = loaders.ToList();
        }

        public async Task<List<TradeRecord>> ProcessFileAsync(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            var loader = _loaders.FirstOrDefault(l =>
                (extension == ".csv" && l.FileType == "CSV") ||
                (extension == ".txt" && l.FileType == "TXT") ||
                (extension == ".xml" && l.FileType == "XML"));

            if (loader == null)
            {
                Console.WriteLine($"⚠️ Uyğun loader tapılmadı: {filePath}");
                return new List<TradeRecord>();
            }

            return await Task.Run(() => loader.Load(filePath));
        }
    }
}
