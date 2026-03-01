using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Tapılan faylı uyğun loader-lə oxuyur
namespace TradeMonitorCore.Services
{
    internal class FileWatcherService
    {
        private readonly string _directoryPath;
        private readonly int _intervalSeconds;
        private readonly Action<string> _onNewFileDetected;
        private readonly HashSet<string> _processedFiles = new();

        public FileWatcherService(string directoryPath, int intervalSeconds, Action<string> onNewFileDetected)
        {
            _directoryPath = directoryPath;
            _intervalSeconds = intervalSeconds;
            _onNewFileDetected = onNewFileDetected;
        }

        public async Task StartWatchingAsync(CancellationToken token)
        {
            Console.WriteLine($"İzləmə başladı: {_directoryPath}");

            while (!token.IsCancellationRequested)
            {
                var files = Directory.GetFiles(_directoryPath);

                foreach (var file in files)
                {
                    if (!_processedFiles.Contains(file))
                    {
                        _processedFiles.Add(file);
                        _onNewFileDetected?.Invoke(file);
                    }
                }

                await Task.Delay(_intervalSeconds * 1000, token);
            }
        }
    }
}
