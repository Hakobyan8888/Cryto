using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoValue
{
    class Bank2
    {
        public decimal BTCBalance { get; set; } = 1m;
        public decimal ETHBalance { get; set; } = 32m;
        public decimal WithdrawFeeETH { get; set; } = 0.01m;
        public decimal WithdrawFeeBTC { get; set; } = 0.0005m;
        public decimal TransactionFee { get; set; } = 0.1m;

        public void BuyBTC(decimal cost)
        {
            BTCBalance += (ETHBalance - ETHBalance * TransactionFee / 100) * cost;
            ETHBalance = 0;
        }

        public void BuyETH(decimal cost)
        {
            ETHBalance += (BTCBalance - BTCBalance * TransactionFee / 100) / cost;
            BTCBalance = 0;
        }

        public void SendMoney(Bank1 bank1)
        {
            if (ETHBalance > 0)
            {
                ETHBalance /= 2;
                bank1.ETHBalance += ETHBalance - WithdrawFeeETH;

            }
            else if (BTCBalance > 0)
            {
                BTCBalance /= 2;
                bank1.BTCBalance += BTCBalance - WithdrawFeeBTC;
            }
            else
            {
                Console.WriteLine("You dont have money");
            }
        }

    }
}
