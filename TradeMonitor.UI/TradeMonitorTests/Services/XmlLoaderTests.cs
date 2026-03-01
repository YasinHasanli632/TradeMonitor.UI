using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeMonitorCore.Loaders;

namespace TradeMonitorTests.Services
{
    public class XmlLoaderTests
    {
        [Fact]
        public void Load_ValidXmlFile_ReturnsCorrectRecords()
        {
            // Arrange
            var xmlContent = @"<root>
                                  <value date='2025-01-01' open='100' high='110' low='90' close='105' volume='1000'/>
                                  <value date='2025-01-02' open='105' high='115' low='95' close='110' volume='1500'/>
                               </root>";
            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, xmlContent);

            var loader = new XmlLoader();

            // Act
            var records = loader.Load(tempFile);

            // Assert
            Assert.Equal(2, records.Count);
            Assert.Equal(105, records[0].Close);
            Assert.Equal(1500, records[1].Volume);
        }

        [Fact]
        public void Load_InvalidXml_SkipsInvalid()
        {
            // Arrange
            var xmlContent = @"<root>
                                  <value wrong='something'/>
                                  <value date='2025-01-02' open='105' high='115' low='95' close='110' volume='1500'/>
                               </root>";
            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, xmlContent);

            var loader = new XmlLoader();

            // Act
            var records = loader.Load(tempFile);

            // Assert
            Assert.Single(records);
        }
    }
}
