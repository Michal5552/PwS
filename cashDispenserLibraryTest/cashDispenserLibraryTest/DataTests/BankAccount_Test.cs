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

        [TestCase(350.87, Currency.PLN, "OK"),
         TestCase(147.09, Currency.PLN, "OK"),
         TestCase(350.87, Currency.USD, "!!! Waluta Jest Różna Od PLN !!!"),
         TestCase(467.78, Currency.EUR, "!!! Waluta Jest Różna Od PLN !!!"),
         TestCase(560.98, Currency.GBP, "!!! Waluta Jest Różna Od PLN !!!"),
         Order(2)]
        public void BankAccount_When_Init_Cases(decimal value,
            Currency currency, string expected)
        {
            string result = "OK";

            //arrange
            BankAccount bankAccount = null;

            try
            {
                bankAccount = new BankAccount(state: new MoneyVAL(
                    value: value, currency: currency));
            }
            catch (BankAccount_Exception ba_e)
            {
                result = ba_e.What();
            }
            catch (MoneyVAL_Exception m_e)
            {
                result = m_e.What();
            }
            catch (Exception ex)
            {
                result = "Issue with open file";
            }

            //act
            if (result.Equals("OK"))
            {
                //Check set value
                if (bankAccount.state._Value != value)
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

        [TestCase(1.0, 3.5,
             4.2, 5.2, "OK"),
         TestCase(1.0, 3.7,
             4.4, 5.1, "OK"),
         TestCase(1.0, 3.0,
             4.9, 5.01, "OK"),
         TestCase(1.0, -0.9,
             4.0, 3.9,
             "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(1.0, 3.5,
             0.0, 3.9,
             "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(1.0, 3.5,
             0.0, -0.7,
             "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(0.0, -3.5,
             0.0, -0.7,
             "!!! Zła Wartość Współczynnika Walutowego !!!"),
         Order(2)]
        public void BankAccount_When_Show_State(
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
                    state: new MoneyVAL(
                        value: DbContextState.BankAccount_Test_PhysicalMoney_txt,
                        currency: Currency.PLN));
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
                List<MoneyVAL> bankAccountState = null;

                //Get bank account state
                try
                {
                    bankAccountState =
                        (List<MoneyVAL>) bankAccount.ShowState(new Dictionary<Currency, decimal>()
                        {
                            {Currency.PLN, PLN_currencyRate},
                            {Currency.USD, USD_currencyRate},
                            {Currency.EUR, EUR_currencyRate},
                            {Currency.GBP, GBP_currencyRate}
                        });
                }
                catch (BankAccount_Exception ba_e)
                {
                    result = ba_e.What();
                }

                if (result.Equals("OK"))
                {
                    //Validate receive data
                    foreach (var bankAccountStateInCurrency in bankAccountState)
                    {
                        switch (bankAccountStateInCurrency._Currency)
                        {
                            case Currency.PLN:
                            {
                                if (bankAccountStateInCurrency._Value !=
                                    DbContextState.BankAccount_Test_PhysicalMoney_txt)
                                {
                                    result = $"Bad value for {bankAccountStateInCurrency._Currency}";
                                }
                            }
                                break;
                            case Currency.USD:
                            {
                                if ((bankAccountStateInCurrency._Value * USD_currencyRate) !=
                                    DbContextState.BankAccount_Test_PhysicalMoney_txt)
                                {
                                    result = $"Bad value for {bankAccountStateInCurrency._Currency}";
                                }
                            }
                                break;
                            case Currency.EUR:
                            {
                                if ((bankAccountStateInCurrency._Value * EUR_currencyRate) !=
                                    DbContextState.BankAccount_Test_PhysicalMoney_txt)
                                {
                                    result = $"Bad value for {bankAccountStateInCurrency._Currency}";
                                }
                            }
                                break;
                            case Currency.GBP:
                            {
                                if ((bankAccountStateInCurrency._Value * GBP_currencyRate) !=
                                    DbContextState.BankAccount_Test_PhysicalMoney_txt)
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
         TestCase(0.0, 213.99,
             Currency.PLN,
             "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(-0.5, 213.99,
             Currency.PLN,
             "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(-2.3, 213.99,
             Currency.USD,
             "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(0.0, 213.99,
             Currency.GBP,
             "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(1.0, 1579.44,
             Currency.PLN,
             "!!! Stan Konta Nie Pozwala Na Wypłatę Tej Kwoty !!!"),
         TestCase(1.0, 1600.45,
             Currency.PLN,
             "!!! Stan Konta Nie Pozwala Na Wypłatę Tej Kwoty !!!"),
         TestCase(3.6, 650.89,
             Currency.USD,
             "!!! Stan Konta Nie Pozwala Na Wypłatę Tej Kwoty !!!"),
         TestCase(1.0, -50.00,
             Currency.PLN,
             "!!! Niepoprawny zapis kwoty !!!"),
         TestCase(3.1, -200.65,
             Currency.USD,
             "!!! Niepoprawny zapis kwoty !!!"),
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
                catch (Exception ex)
                {
                    result = "Issue with open file";
                }

                if (result.Equals("OK"))
                {
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

                    if (result.Equals("OK"))
                    {
                        //---Check physical money repository state---

                        //Connect with database
                        MockPhysicalMoneyRepository mockPhysicalMoneyRepository =
                            new MockPhysicalMoneyRepository(
                                cashDispenserLibraryTestSettings._SystemSettings);

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
                        if (Math.Abs(physicalMoneyState._Value -
                                     (DbContextState.BankAccount_Test_PhysicalMoney_txt -
                                      (takeOutValue * takeOutCurrencyRate))) > 0.002M)
                        {
                            result = "Bad database result value";
                        }

                        //Check database currency
                        if (physicalMoneyState._Currency != Currency.PLN)
                        {
                            result = "Bad database result currency";
                        }
                    }
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
                        money: new MoneyVAL(value: addValue,
                            currency: addCurrency), null);
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
                        new MockPhysicalMoneyRepository(
                            cashDispenserLibraryTestSettings._SystemSettings);

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

                    if (result.Equals("OK"))
                    {
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
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }
    }
}