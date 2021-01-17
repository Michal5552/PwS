using cashDispenserLibrary.Data;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;
using NUnit.Framework;

namespace cashDispenserTest.DataTests
{
    [TestFixture]
    public class PhysicalMoneyVAL_Test
    {
        [TestCase(15.50, Currency.PLN, "OK"),
         TestCase(0.0, Currency.GBP, "OK"),
         TestCase(-300.1, Currency.PLN,
             "!!! Zła Wartość Wprowadzanej Kwoty Fizycznych Pieniędzy !!!")]
        public void PhysicalMoneyVAL_When_Init(
            decimal value, Currency currency, string expected)
        {
            //arrange
            string result = "OK";

            PhysicalMoneyVAL physicalMoneyVAL = null;

            try
            {
                physicalMoneyVAL = new PhysicalMoneyVAL(
                    value: value, currency: currency);
            }
            catch (PhysicalMoneyVAL_Exception pmv_e)
            {
                result = pmv_e.What();
            }

            //act
            if (result.Equals("OK"))
            {
                //Check set value
                if (physicalMoneyVAL._Value != value)
                {
                    result = "Not set value";
                }

                //Check set currency
                if (physicalMoneyVAL._Currency != currency)
                {
                    result = "Not set currency";
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }

        [TestCase(123.56, Currency.USD, "OK"),
         TestCase(0.0, Currency.GBP, "OK"),
         TestCase(-1, Currency.EUR,
             "!!! Zła Wartość Wprowadzanej Kwoty Fizycznych Pieniędzy !!!")]
        public void PhysicalMoneyVAL_When_Change_Money(
            decimal changeValue, Currency changeCurrency, string expected)
        {
            const decimal value = 1000M;
            const Currency currency = Currency.PLN;

            //arrange
            string result = "OK";
            PhysicalMoneyVAL physicalMoneyVAL = null;

            try
            {
                physicalMoneyVAL = new PhysicalMoneyVAL(
                    value: value, currency: currency);
            }
            catch (PhysicalMoneyVAL_Exception pmv_e)
            {
                result = pmv_e.What();
            }

            //act
            try
            {
                physicalMoneyVAL.ChangePhysicalMoney(
                    new PhysicalMoneyVAL(
                        value: changeValue, currency: changeCurrency));
            }
            catch (PhysicalMoneyVAL_Exception pmv_e)
            {
                result = pmv_e.What();
            }

            if (result.Equals("OK"))
            {
                //Check set value
                if (physicalMoneyVAL._Value != changeValue)
                {
                    result = "Not set value";
                }

                //Check set currency
                if (physicalMoneyVAL._Currency != changeCurrency)
                {
                    result = "Not set currency";
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }
    }
}