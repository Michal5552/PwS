using NUnit.Framework;
using cashDispenserLibrary.Data.MoneyVAL;
using cashDispenserLibrary.Data.MoneyVAL.Exceptions;

namespace cashDispenserTest.DataTests
{
    [TestFixture]
    public class MoneyVAL_Test
    {
        [TestCase(-200, Currency.PLN, "!!! Niepoprawny zapis kwoty !!!"),
         TestCase(123, Currency.PLN, "OK"),
         TestCase(0, Currency.GBP, "OK")]
        public void MoneyVAL_When_Init_Cases(decimal value, Currency currency,
            string expected)
        {
            // arrange
            string result = "OK";

            MoneyVAL moneyVAL = null;

            try
            {
                moneyVAL = new MoneyVAL(value: value, currency: currency);
            }
            catch (MoneyVAL_Exception m_e)
            {
                result = m_e.What();
            }

            // act
            if (result == "OK")
            {
                //check set value
                if (moneyVAL._Value != value)
                {
                    result = "Not set value";
                }

                //Check set currency
                if (moneyVAL._Currency != currency)
                {
                    result = "Not set currency";
                }
            }

            // assert
            Assert.AreEqual(expected: expected, actual: result);
        }

        [TestCase(124, Currency.GBP, "OK"),
         TestCase(0, Currency.GBP, "OK"),
         TestCase(-1, Currency.GBP, "!!! Niepoprawny zapis kwoty !!!")]
        public void MoneyVAL_When_Change_Money(decimal changeValue,
            Currency changeCurrency, string expected)
        {
            const decimal value = 123M;
            const Currency currency = Currency.PLN;

            //arrange
            string result = "OK";
            MoneyVAL moneyVAL = new MoneyVAL(value: value, currency: currency);

            //act
            try
            {
                moneyVAL.ChangeMoney(moneyVAL: new MoneyVAL(
                    value: changeValue, currency: changeCurrency));
            }
            catch (MoneyVAL_Exception m_e)
            {
                result = m_e.What();
            }

            if (result == "OK")
            {
                //check set value
                if (moneyVAL._Value != changeValue)
                {
                    result = "Not set value";
                }

                //Check set currency
                if (moneyVAL._Currency != changeCurrency)
                {
                    result = "Not set currency";
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }
    }
}