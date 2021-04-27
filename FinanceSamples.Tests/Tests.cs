using FinanceSamples.Calculations;
using FinanceSamples.Models;
using System;
using Xunit;

namespace FinanceSamples.Tests
{
    public class Tests
    {
        [Fact]
        public void CreditTest1()
        {
            CreditData data = new CreditData {
                Amount = 1200,
                MontlyCommission = 10,
                Percent = 10,
                Period = 12
            };

            Calculate.Credit(data);

            Assert.NotNull(data.Result);
            Assert.True(data.Result.Count == 12, "Count of rows should be 12");

            int payment = 0;
            foreach(CreditResultRow row in data.Result)
            {
                payment++;
                decimal amount = data.Amount - (payment - 1) * 100;
                decimal percent = amount / 120;
                Assert.True(row.Payment == payment
                    && row.LoanBalance == amount
                    && row.Commission == 10
                    && row.Percent == percent
                    && row.PayAmount == 110 + percent, $"Test failed: Payment {row.Payment}");
            }
        }

        [Fact]
        public void DepositTest1()
        {
            DepositData data = new DepositData
            {
                Amount = 1200,
                IsMontly—apitalization = false,
                Percent = 10,
                Period = 12
            };

            Calculate.Deposit(data);

            Assert.NotNull(data.Result);
            Assert.True(data.Result.Count == 12, "Count of rows should be 12");

            int period = 0;
            foreach (DepositResultRow row in data.Result)
            {
                period++;
                Assert.True(row.Period == period
                    && row.StartAmount == 1200
                    && row.Percent == 10
                    && row.PercentAmount == 10 * period
                    && row.EndAmount == (period == 12 ? 1320 : 1200), $"Test failed: Period {row.Period}");
            }
        }

        [Fact]
        public void DepositTest2()
        {
            DepositData data = new DepositData
            {
                Amount = 1200,
                IsMontly—apitalization = true,
                Percent = 10,
                Period = 12
            };

            Calculate.Deposit(data);

            Assert.NotNull(data.Result);
            Assert.True(data.Result.Count == 12, "Count of rows should be 12");

            int period = 0;
            decimal amount = 1200;
            decimal percentAmount = 0;
            foreach (DepositResultRow row in data.Result)
            {
                period++;
                decimal percent = amount / 120;
                percentAmount += percent;
                Assert.True(row.Period == period
                    && row.StartAmount == amount
                    && row.Percent == percent
                    && row.PercentAmount == percentAmount
                    && row.EndAmount == amount + percent, $"Test failed: Period {row.Period}");
                amount += percent;
            }
        }
    }
}
