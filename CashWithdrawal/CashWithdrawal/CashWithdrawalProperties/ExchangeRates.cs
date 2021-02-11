using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashWithdrawal
{
    public class ExchangeRates
    {
        public decimal PLN_exchangeRate { get; private set; }
        public decimal EUR_exchangeRate { get; private set; }
        public decimal USD_exchangeRate { get; private set; }
        public decimal GBP_exchangeRate { get; private set; }

        public ExchangeRates()
        {
            PLN_exchangeRate = 1.0M;

            GBP_exchangeRate = RandGBP_Currency();
            EUR_exchangeRate = (GBP_exchangeRate - 0.5M);
            USD_exchangeRate = (GBP_exchangeRate - 1.0M);
        }
        private decimal RandGBP_Currency()
        {
            // Draw exchange rate attribute and mantissa
            int attribute = new Random((int)DateTime.Now.Ticks).Next(4, 6);
            int mantissa = new Random((int)DateTime.Now.Ticks).Next(0, 99);

            // Concatenation and return decimal value
            return decimal.Parse((attribute.ToString() + '.' + mantissa.ToString()),
                CultureInfo.InvariantCulture);
        }
    }
}
