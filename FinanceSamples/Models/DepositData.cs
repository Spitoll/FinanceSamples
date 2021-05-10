using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceSamples.Models
{
    public class DepositData
    {
        [Range(0.01, double.MaxValue, ErrorMessage = "Значение 'Суммы депозита' должно быть больше или равно 0.01")]
        public decimal Amount { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Значение 'Процентной ставки' должно быть больше или равно 0")]
        public decimal Percent { get; set; }
        public bool IsMontlyСapitalization { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Значение 'Срока' должно быть 1 или больше.")]
        public int Period { get; set; } = 1;
        public List<DepositResultRow> Result { get; set; }
    }
}
