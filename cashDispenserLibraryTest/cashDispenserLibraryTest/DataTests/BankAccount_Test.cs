using System.Xml.Schema;
using cashDispenserLibrary.Data;
using cashDispenserLibrary.Data.Exceptions;
using NUnit.Framework;

namespace cashDispenserTest.DataTests
{
    [TestFixture]
    public class BankAccount_Test
    {
        [TestCase(12_000, 12_000),
         TestCase(13_876, 13_876)]
        public void BankAccount_When_Init_Cases(
            decimal money_value, decimal expected)
        {
            decimal result;


            //arrange
            BankAccount bankAccount = null;

            try
            {
                bankAccount = new BankAccount(
                    new MoneyVAL(money_value, Currency.PLN));
            }
            catch (BankAccount_Exception b_e)
            {
            }

            //act
            result = bankAccount.state._Value;

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }

        [TestCase()]
        public void BankAccount_When_ShowState_Cases(
            decimal money_init,
            decimal money_value0, Currency currency0, decimal currencyRate0,
            decimal money_value1, Currency currency1, decimal currencyRate1,
            decimal money_value2, Currency currency2, decimal currencyRate2,
            decimal expected)
        {
            //arrange
            BankAccount bankAccount = null;

            try
            {
                bankAccount = new BankAccount(
                    new MoneyVAL(money_init, Currency.PLN));
            }
            catch (BankAccount_Exception b_e)
            {
            }

            //act
            // TODO finish implement
            //assert
        }
    }
}