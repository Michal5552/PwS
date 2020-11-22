using System;
using System.Collections.Generic;

namespace cashDispenserLibrary.Data
{
    public class BankAccount
    {
        private MoneyVAL state;

        public BankAccount() =>
            state = new MoneyVAL(value: 0M, currency: Currency.PLN);

        public IEnumerable<MoneyVAL> ShowState()
        {
            //Create result collection
            var result = new List<MoneyVAL>();

            //Fill result collection state in all currency
            for (int i = 0; i < CurrencySize.size; ++i)
            {
                result.Add(new MoneyVAL(
                    value: state._Value, currency: state._Currency));
            }

            return result;
        }

        public MoneyVAL TakeOutMoney(bool report, MoneyVAL money)
        {
            // TODO implement
            throw new Exception();
        }

        public void AddMoney(bool report, MoneyVAL money)
        {
            // TODO implement
            throw new Exception();
        }
    }
}