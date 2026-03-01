using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeMonitorCore.Models
{
    public class TradeRecord
    {
        public DateTime Date { get; set; }
        public decimal Open { get; set; }
        public decimal High { get; set; }
        public decimal Low { get; set; }
        public decimal Close { get; set; }
        public long Volume { get; set; }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} | Open: {Open}, Close: {Close}, Volume: {Volume}";
        }
    }
}