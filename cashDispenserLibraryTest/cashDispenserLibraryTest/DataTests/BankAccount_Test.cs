using System;
using System.Collections.Generic;
using System.IO;
using cashDispenserLibrary.Data;
using cashDispenserLibrary.Data.Exceptions;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;
using cashDispenserLibrary.Model.MockPhysicalMoneyRepository;
using cashDispenserTest.MockRepositoriesTest;
using NUnit.Framework;

namespace cashDispenserTest.DataTests
{
    // TODO check test's correctness
    [TestFixture]
    public class BankAccount_Test
    {
        private void initData()
        {
            using (StreamWriter sw = new StreamWriter(
                "cashDispenserDatabase/PhysicalMoney.txt", false))
            {
                sw.WriteLine($"{DbContextState.BankAccount_Test_PhysicalMoney_txt};0");
            }
        }

        [TestCase(1.0, 350.87,
             Currency.PLN, "OK"),
         TestCase(3.9, 350.87,
             Currency.USD, "OK"),
         TestCase(4.34, 467.78,
             Currency.EUR, "OK"),
         TestCase(5.13, 560.98,
             Currency.GBP, "OK"),
         Order(2)]
        public void BankAccount_When_Init_Cases(
            decimal currencyRate, decimal value,
            Currency currency, string expected)
        {
            string result = "OK";

            //arrange
            BankAccount bankAccount = null;

            try
            {
                bankAccount = new BankAccount(state: new MoneyVAL(
                    value: (value * currencyRate), currency: Currency.PLN));
            }
            catch (MoneyVAL_Exception m_e)
            {
                result = m_e.What();
            }
            catch (Exception ex)
            {
                result = "Issue with initial";
            }

            //act
            if (result.Equals("OK"))
            {
                //Check set value
                if (bankAccount.state._Value != (value * currencyRate))
                {
                    result = "Not set value";
                }

                //Check set currency
                if (bankAccount.state._Currency != Currency.PLN)
                {
                    result = "Not set core currency";
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }

        [TestCase(1349.56, Currency.PLN,
             1.0, 3.5,
             4.3, 5.3, "OK"),
         TestCase(1500.00, Currency.PLN,
             1.0, 3.9,
             4.4, 5.4, "OK"),
         TestCase(9801.90, Currency.PLN,
             1.0, 3.0,
             4.9, 5.01, "OK"),
         TestCase(9801.90, Currency.PLN,
             1.0, 0.0,
             4.9, 5.01, "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(9801.90, Currency.PLN,
             1.0, 3.9,
             -9.8, 5.01, "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(9801.90, Currency.PLN,
             0.0, 3.9,
             -9.8, 5.01, "!!! Zła Wartość Współczynnika Walutowego !!!"),
         Order(2)]
        public void BankAccount_When_Show_State(
            decimal value, Currency currency,
            decimal PLN_currencyRate, decimal USD_currencyRate,
            decimal EUR_currencyRate, decimal GBP_currencyRate,
            string expected)
        {
            string result = "OK";

            //arrange
            BankAccount bankAccount = null;

            try
            {
                bankAccount = new BankAccount(
                    state: new MoneyVAL(value: value, currency: currency));
            }
            catch (MoneyVAL_Exception m_e)
            {
                result = m_e.What();
            }
            catch (BankAccount_Exception ba_e)
            {
                result = ba_e.What();
            }

            //act
            if (result.Equals("OK"))
            {
                //Get bank account state
                var bankAccountState =
                    bankAccount.ShowState(new Dictionary<Currency, decimal>()
                    {
                        {Currency.PLN, PLN_currencyRate},
                        {Currency.USD, USD_currencyRate},
                        {Currency.EUR, EUR_currencyRate},
                        {Currency.GBP, GBP_currencyRate}
                    });

                //Validate receive data
                foreach (var bankAccountStateInCurrency in bankAccountState)
                {
                    switch (bankAccountStateInCurrency._Currency)
                    {
                        case Currency.PLN:
                        {
                            if (bankAccountStateInCurrency._Value != value)
                            {
                                result = $"Bad value for {bankAccountStateInCurrency._Currency}";
                            }
                        }
                            break;
                        case Currency.USD:
                        {
                            if ((bankAccountStateInCurrency._Value * USD_currencyRate) != value)
                            {
                                result = $"Bad value for {bankAccountStateInCurrency._Currency}";
                            }
                        }
                            break;
                        case Currency.EUR:
                        {
                            if ((bankAccountStateInCurrency._Value * EUR_currencyRate) != value)
                            {
                                result = $"Bad value for {bankAccountStateInCurrency._Currency}";
                            }
                        }
                            break;
                        case Currency.GBP:
                        {
                            if ((bankAccountStateInCurrency._Value * GBP_currencyRate) != value)
                            {
                                result = $"Bad value for {bankAccountStateInCurrency._Currency}";
                            }
                        }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }

        [TestCase(1.0, 500.01,
             Currency.PLN, "OK"),
         TestCase(3.5, 390,
             Currency.USD, "OK"),
         TestCase(4.4, 339.78,
             Currency.EUR, "OK"),
         TestCase(5.2, 213.99,
             Currency.GBP, "OK"),
         Order(2)]
        public void BankAccount_When_Take_Out_Money(
            decimal takeOutCurrencyRate, decimal takeOutValue,
            Currency takeOutCurrency, string expected)
        {
            string result = "OK";

            //arrange
            BankAccount bankAccount = null;

            //Init database
            initData();

            try
            {
                bankAccount = new BankAccount(state: new MoneyVAL(
                    value: DbContextState.BankAccount_Test_PhysicalMoney_txt,
                    currency: Currency.PLN));
            }
            catch (MoneyVAL_Exception mv_e)
            {
                result = mv_e.What();
            }
            catch (BankAccount_Exception ba_e)
            {
                ba_e.What();
            }

            //act
            if (result.Equals("OK"))
            {
                //Take out money
                MoneyVAL takeOutMoneyResult = null;

                try
                {
                    takeOutMoneyResult = bankAccount.TakeOutMoney(
                        currencyRate: takeOutCurrencyRate,
                        money: new MoneyVAL(value: takeOutValue,
                            currency: takeOutCurrency), null);
                }
                catch (BankAccount_Exception ba_e)
                {
                    result = ba_e.What();
                }
                catch (MoneyVAL_Exception m_e)
                {
                    result = m_e.What();
                }

                //Check take out money value
                if (takeOutMoneyResult._Value != takeOutValue)
                {
                    result = "Bad Result Value";
                }

                //Check take out money currency
                if (takeOutMoneyResult._Currency != takeOutCurrency)
                {
                    result = "Bad Result Currency";
                }

                //---Check physical money repository state---

                //Connect with database
                MockPhysicalMoneyRepository mockPhysicalMoneyRepository =
                    new MockPhysicalMoneyRepository(PlatformType.Unix);

                //Get physical money state
                PhysicalMoneyVAL physicalMoneyState = null;

                try
                {
                    physicalMoneyState = mockPhysicalMoneyRepository.GetInCurrency(
                        currencyRate: 1.0M, currency: Currency.PLN);
                }
                catch (MockPhysicalMoneyRepository_Exception mpmr_e)
                {
                    result = mpmr_e.What();
                }
                catch (Exception ex)
                {
                    result = "!!! Issue with open file !!!";
                }

                //Check database value
                if (physicalMoneyState._Value !=
                    (DbContextState.BankAccount_Test_PhysicalMoney_txt -
                     (takeOutValue * takeOutCurrencyRate)))
                {
                    result = "Bad database result value";
                }

                //Check database currency
                if (physicalMoneyState._Currency != Currency.PLN)
                {
                    result = "Bad database result currency";
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }

        [TestCase(1.0, 300.66,
             Currency.PLN, "OK"),
         TestCase(3.6, 150.13,
             Currency.USD, "OK"),
         TestCase(4.3, 100.00,
             Currency.EUR, "OK"),
         TestCase(5.1, 200.45,
             Currency.GBP, "OK"),
         TestCase(0.0, 300.66,
             Currency.PLN, "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(0.0, 300.66,
             Currency.GBP, "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(3.2, -90.87,
             Currency.USD, "!!! Niepoprawny zapis kwoty !!!"),
         TestCase(-3.0, 12.2,
             Currency.USD, "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(0.0, 0.0,
             Currency.EUR, "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(-4.0, -12.2,
             Currency.EUR, "!!! Niepoprawny zapis kwoty !!!"),
         Order(3)]
        public void BankAccount_When_Add_Money(
            decimal addCurrencyRate, decimal addValue,
            Currency addCurrency, string expected)
        {
            string result = "OK";

            //arrange
            BankAccount bankAccount = null;

            //Init database
            initData();

            try
            {
                bankAccount = new BankAccount(state: new MoneyVAL(
                    value: DbContextState.BankAccount_Test_PhysicalMoney_txt,
                    currency: Currency.PLN));
            }
            catch (BankAccount_Exception ba_e)
            {
                result = ba_e.What();
            }
            catch (MoneyVAL_Exception m_e)
            {
                result = m_e.What();
            }

            //act
            if (result.Equals("OK"))
            {
                //Add money
                try
                {
                    bankAccount.AddMoney(currencyRate: addCurrencyRate,
                        money: new MoneyVAL(value: addValue, currency: addCurrency),
                        null);
                }
                catch (MoneyVAL_Exception m_e)
                {
                    result = m_e.What();
                }
                catch (BankAccount_Exception ba_e)
                {
                    result = ba_e.What();
                }
                catch (Exception ex)
                {
                    result = "!!! Issue with open file !!!";
                }

                if (result.Equals("OK"))
                {
                    //---Check physical money repository state---

                    //Connect with database
                    MockPhysicalMoneyRepository mockPhysicalMoneyRepository =
                        new MockPhysicalMoneyRepository(PlatformType.Unix);

                    //Get physical money state
                    PhysicalMoneyVAL physicalMoneyState = null;

                    try
                    {
                        physicalMoneyState =
                            mockPhysicalMoneyRepository.GetInCurrency(
                                currencyRate: 1.0M, currency: Currency.PLN);
                    }
                    catch (MockPhysicalMoneyRepository_Exception mpmr_e)
                    {
                        result = mpmr_e.What();
                    }
                    catch (Exception ex)
                    {
                        result = "!!! Issue with open file !!!";
                    }

                    //Check database value
                    if ((physicalMoneyState._Value - (addValue * addCurrencyRate))
                        != DbContextState.BankAccount_Test_PhysicalMoney_txt)
                    {
                        result = "Bad database value";
                    }

                    if (physicalMoneyState._Currency != Currency.PLN)
                    {
                        result = "Bad database currency";
                    }
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }
    }
}