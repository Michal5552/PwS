using cashDispenserLibrary.Data.MoneyVAL.Exceptions;

namespace cashDispenserLibrary.Data.MoneyVAL
{
    public class MoneyVAL
    {
        public decimal _Value { get; private set; }
        public Currency _Currency { get; private set; }

        public MoneyVAL(decimal value, Currency currency)
        {
            //Check money's value correctness
            if (value < 0.0M)
            {
                throw new MoneyVAL_Exception(MoneyVAL_ExceptionType.BadMoneyValue);
            }

            //Set value
            _Value = value;
            
            //Set currency
            _Currency = currency;
        }

        public void ChangeMoney(MoneyVAL moneyVAL)
        {
            _Value = moneyVAL._Value;
            _Currency = moneyVAL._Currency;
        }
    }
}