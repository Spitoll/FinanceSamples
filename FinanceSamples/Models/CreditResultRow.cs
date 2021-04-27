using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceSamples.Models
{
    public class CreditResultRow
    {
        public int Payment { get; set; }
        public decimal LoanBalance { get; set; }
        public decimal Percent { get; set; }
        public decimal Commission { get; set; }
        public decimal PayAmount { get; set; }
    }
}
