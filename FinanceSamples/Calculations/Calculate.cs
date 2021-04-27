using FinanceSamples.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinanceSamples.Calculations
{
    public static class Calculate
    {
        public static void Credit(CreditData creditData)
        {
            if (creditData.Amount <= 0
                || creditData.MontlyCommission < 0
                || creditData.Percent < 0
                || creditData.Period <= 0) return;

            List<CreditResultRow> rows = new List<CreditResultRow>();
            decimal bodyLoan = creditData.Amount / creditData.Period;
            decimal beginAmount = creditData.Amount;
            for (int i = 1; i <= creditData.Period; i++)
            {
                decimal percentAmount = beginAmount * creditData.Percent / 1200;
                CreditResultRow row = new CreditResultRow
                {
                    Payment = i,
                    LoanBalance = beginAmount,
                    Commission = creditData.MontlyCommission,
                    PayAmount = bodyLoan + percentAmount + creditData.MontlyCommission,
                    Percent = percentAmount
                };
                rows.Add(row);

                beginAmount -= bodyLoan;
            }

            creditData.Result = rows;
        }

        public static void Deposit(DepositData depositData)
        {
            if (depositData.Amount <= 0
                || depositData.Percent < 0
                || depositData.Period <= 0) return;

            List<DepositResultRow> rows = new List<DepositResultRow>();
            decimal startAmount = depositData.Amount;
            decimal percentAmount = 0;
            for (int i = 1; i <= depositData.Period; i++)
            {
                decimal percent = startAmount * depositData.Percent / 1200;
                percentAmount += percent;
                DepositResultRow row = new DepositResultRow
                {
                    Period = i,
                    StartAmount = startAmount,
                    Percent = percent,
                    PercentAmount = percentAmount,
                    EndAmount = depositData.IsMontlyСapitalization
                                ? startAmount + percent
                                : i < depositData.Period ? startAmount : startAmount + percentAmount
                };
                rows.Add(row);

                if (depositData.IsMontlyСapitalization)
                    startAmount += percent;
            }

            depositData.Result = rows;
        }
    }
}
