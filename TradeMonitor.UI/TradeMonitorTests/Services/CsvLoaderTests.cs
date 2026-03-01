using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeMonitorCore.Loaders;
namespace TradeMonitorTests.Services
{
    public class CsvLoaderTests
    {
        [Fact]
        public void Load_ValidCsvFile_ReturnsCorrectRecords()
        {
            // Arrange
            var csvContent = "2025-01-01,100,110,90,105,1000\n2025-01-02,105,115,95,110,1500";
            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, csvContent);

            var loader = new CsvLoader();

            // Act
            var records = loader.Load(tempFile);

            // Assert
            Assert.Equal(2, records.Count);
            Assert.Equal(105, records[0].Close);
            Assert.Equal(1500, records[1].Volume);
        }

        [Fact]
        public void Load_InvalidLine_SkipsLine()
        {
            // Arrange
            var csvContent = "invalid,line\n2025-01-02,105,115,95,110,1500";
            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, csvContent);

            var loader = new CsvLoader();

            // Act
            var records = loader.Load(tempFile);

            // Assert
            Assert.Single(records);
        }
    }
}