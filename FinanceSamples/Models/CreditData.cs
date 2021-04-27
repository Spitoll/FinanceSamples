using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceSamples.Models
{
    public class CreditData
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "Значение 'Суммы кредита' должно быть 0.01 или больше.")]
        public decimal Amount { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Значение 'Процентной ставки' должно быть 0.01 или больше.")]
        public int Percent { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Значение 'Месячной комиссии' должно быть 0 или больше.")]
        public decimal MontlyCommission { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Значение 'Срока' должно быть 1 или больше.")]
        public int Period { get; set; } = 1;
        public List<CreditResultRow> Result { get; set; }
    }
}
