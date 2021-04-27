using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceSamples.Models
{
    public class DepositResultRow
    {
        public int Period { get; set; }
        public decimal StartAmount { get; set; }
        public decimal Percent { get; set; }
        public decimal PercentAmount { get; set; }
        public decimal EndAmount { get; set; }
    }
}
