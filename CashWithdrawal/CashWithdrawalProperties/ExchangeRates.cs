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
			int attribute = new Random((int)DateTime.Now.Ticks).Next(0, 6);
			EUR_exchangeRate = RandExchangeRate(attribute);
			attribute = new Random((int)DateTime.Now.Ticks).Next(0, 6);
			USD_exchangeRate = RandExchangeRate(attribute);
			attribute = new Random((int)DateTime.Now.Ticks).Next(0, 6);
			GBP_exchangeRate = RandExchangeRate(attribute);
		}
		private decimal RandExchangeRate(int attribute)
		{
			int mantissa = new Random((int)DateTime.Now.Ticks).Next(0, 99);
			return decimal.Parse(attribute.ToString() + '.' + mantissa.ToString(), CultureInfo.InvariantCulture);
		}
	}

}
