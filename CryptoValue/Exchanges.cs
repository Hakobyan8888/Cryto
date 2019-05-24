using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoValue
{
    public class Exchanges
    {
        public decimal Profit { get; set; }
        public decimal Investment { get; set; }
        public decimal SuspectedProfit { get; set; }
        public decimal WithdrawalFeeFirst { get; set; }
        public decimal WithdrawalFeeSecond { get; set; }
        public decimal TransactionFeeFirst { get; set; }
        public decimal TransactionFeeSecond { get; set; }

        public Exchanges()
        {
            Investment = 4m;
            WithdrawalFeeFirst = 0.0005m;
            WithdrawalFeeSecond = 0.00032m;
            TransactionFeeFirst = 0.0005m;
            TransactionFeeSecond = 0.001m;
        }

        public decimal Checker(decimal suspectedProfit)
        {
            this.SuspectedProfit = suspectedProfit;
            Profit = Investment * (SuspectedProfit - (TransactionFeeFirst + TransactionFeeSecond)) - (WithdrawalFeeFirst + WithdrawalFeeSecond);
            return Profit;
        }
    }
}
