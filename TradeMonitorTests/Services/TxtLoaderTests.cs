using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeMonitorCore.Loaders;

namespace TradeMonitorTests.Services
{
    public class TxtLoaderTests
    {
        [Fact]
        public void Load_ValidTxtFile_ReturnsCorrectRecords()
        {
            // Arrange
            var txtContent = "Date;Open;High;Low;Close;Volume\n2025-01-01;100;110;90;105;1000\n2025-01-02;105;115;95;110;1500";
            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, txtContent);

            var loader = new TxtLoader();

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
            var txtContent = "Date;Open;High;Low;Close;Volume\ninvalid;line\n2025-01-02;105;115;95;110;1500";
            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, txtContent);

            var loader = new TxtLoader();

            // Act
            var records = loader.Load(tempFile);

            // Assert
            Assert.Single(records);
        }
    }
}
