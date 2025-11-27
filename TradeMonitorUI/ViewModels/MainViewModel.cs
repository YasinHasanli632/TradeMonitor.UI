using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using TradeMonitorCore.Models;// 🔹 Bunu əlavə et
using TradeMonitorUI.ViewModels;
using System.Windows.Forms;

namespace TradeMonitorUI.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string _watchDirectory;
        private int _checkInterval;
        private string _log;

        public string WatchDirectory
        {
            get => _watchDirectory;
            set { _watchDirectory = value; OnPropertyChanged(); }
        }

        public int CheckInterval
        {
            get => _checkInterval;
            set { _checkInterval = value; OnPropertyChanged(); }
        }

        public string Log
        {
            get => _log;
            set { _log = value; OnPropertyChanged(); }
        }

        public ObservableCollection<ProcessedFileInfo> ProcessedFiles { get; set; } = new();
        public ObservableCollection<TradeRecord> TradeData { get; set; } = new();

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public void LoadDummyData()
        {
            WatchDirectory = @"C:\TicarətGirişi";
            CheckInterval = 5;
            Log = "Yeni fayl aşkarlanıb: data6.csv";

            ProcessedFiles.Add(new ProcessedFileInfo { FileName = "data1.csv", Status = "Başarılı" });
            ProcessedFiles.Add(new ProcessedFileInfo { FileName = "data2.txt", Status = "Yüklənir" });
            ProcessedFiles.Add(new ProcessedFileInfo { FileName = "data9.csv", Status = "Xəta" });

            TradeData.Add(new TradeRecord { Date = new DateTime(2013, 5, 2), Open = 30.16m, High = 30.36m, Low = 30.02m, Close = 30.12m, Volume = 2478200 });
            TradeData.Add(new TradeRecord { Date = new DateTime(2013, 5, 1), Open = 29.55m, High = 29.94m, Low = 29.45m, Close = 29.61m, Volume = 1005000 });
        }
       
        
    }
}