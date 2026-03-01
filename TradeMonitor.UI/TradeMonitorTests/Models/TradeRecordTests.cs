using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMonitorTests.Models
{
    public class TradeRecordTests
    {
        [Fact]
        public void TradeRecord_ShouldStorePropertiesCorrectly()
        {
            // Arrange
            var date = new DateTime(2025, 11, 8);
            decimal open = 120.5m;
            decimal high = 125.3m;
            decimal low = 118.7m;
            decimal close = 123.9m;
            long volume = 5000;

            // Act
            var record = new TradeRecord
            {
                Date = date,
                Open = open,
                High = high,
                Low = low,
                Close = close,
                Volume = volume
            };

            // Assert
            Assert.Equal(date, record.Date);
            Assert.Equal(open, record.Open);
            Assert.Equal(high, record.High);
            Assert.Equal(low, record.Low);
            Assert.Equal(close, record.Close);
            Assert.Equal(volume, record.Volume);
        }

        [Fact]
        public void ToString_ShouldReturnFormattedText()
        {
            // Arrange
            var record = new TradeRecord
            {
                Date = new DateTime(2025, 11, 8),
                Open = 100.5m,
                Close = 105.2m,
                Volume = 1200
            };

            // Act
            var result = record.ToString();

            // Assert
            Assert.Contains("Open: 100.5", result);
            Assert.Contains("Close: 105.2", result);
            Assert.Contains("Volume: 1200", result);
            Assert.Contains("2025", result); // tarix hissəsinin daxil olduğunu yoxlayır
        }

        [Fact]
        public void TradeRecord_DefaultValues_ShouldBeZeroOrDefault()
        {
            // Arrange
            var record = new TradeRecord();

            // Assert
            Assert.Equal(default(DateTime), record.Date);
            Assert.Equal(0m, record.Open);
            Assert.Equal(0m, record.High);
            Assert.Equal(0m, record.Low);
            Assert.Equal(0m, record.Close);
            Assert.Equal(0, record.Volume);
        }
    }
}
