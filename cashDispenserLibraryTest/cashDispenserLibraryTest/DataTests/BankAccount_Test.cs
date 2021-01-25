using System;
using System.Collections.Generic;
using System.IO;
using cashDispenserLibrary.Data;
using cashDispenserLibrary.Data.Exceptions;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;
using cashDispenserLibrary.Model.MockPhysicalMoneyRepository;
using NUnit.Framework;

namespace cashDispenserTest.DataTests
{
    [TestFixture]
    public class BankAccount_Test
    {
        private readonly decimal PhysicalMoney_txt = 1579.43M;

        private void initData()
        {
            //Init Physical Money database
            using (StreamWriter sw = new StreamWriter(
                "cashDispenserDatabase/PhysicalMoney.txt", false))
            {
                sw.WriteLine($"{PhysicalMoney_txt};0");
            }
        }

        [TestCase(350.87, Currency.PLN, "OK"),
         TestCase(147.09, Currency.PLN, "OK"),
         TestCase(350.87, Currency.USD, "!!! Waluta Jest Różna Od PLN !!!"),
         TestCase(467.78, Currency.EUR, "!!! Waluta Jest Różna Od PLN !!!"),
         TestCase(560.98, Currency.GBP, "!!! Waluta Jest Różna Od PLN !!!"),
         Order(0)]
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
         Order(0)]
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
                        value: PhysicalMoney_txt,
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
                                if (bankAccountStateInCurrency._Value
                                    != PhysicalMoney_txt)
                                {
                                    result = $"Bad value for {bankAccountStateInCurrency._Currency}";
                                }
                            }
                                break;
                            case Currency.USD:
                            {
                                if ((bankAccountStateInCurrency._Value * USD_currencyRate)
                                    != PhysicalMoney_txt)
                                {
                                    result = $"Bad value for {bankAccountStateInCurrency._Currency}";
                                }
                            }
                                break;
                            case Currency.EUR:
                            {
                                if ((bankAccountStateInCurrency._Value * EUR_currencyRate)
                                    != PhysicalMoney_txt)
                                {
                                    result = $"Bad value for {bankAccountStateInCurrency._Currency}";
                                }
                            }
                                break;
                            case Currency.GBP:
                            {
                                if ((bankAccountStateInCurrency._Value * GBP_currencyRate)
                                    != PhysicalMoney_txt)
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

        [TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 1.0, 500.01,
             Currency.PLN, 2, "OK"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 3.5, 390,
             Currency.USD, 3, "OK"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 4.4, 339.78,
             Currency.EUR, 4, "OK"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;1200.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 5.2, 213.99,
             Currency.GBP, 1, "OK"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 0.0, 213.99,
             Currency.PLN, 1,
             "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, -0.5, 213.99,
             1, Currency.PLN,
             "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, -2.3, 213.99,
             Currency.USD, 1,
             "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 0.0, 213.99,
             Currency.GBP, 1,
             "!!! Zła Wartość Współczynnika Walutowego !!!"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 1.0, 1579.44,
             Currency.PLN, 1,
             "!!! Stan Konta Nie Pozwala Na Wypłatę Tej Kwoty !!!"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 1.0, 1600.45,
             Currency.PLN, 2,
             "!!! Stan Konta Nie Pozwala Na Wypłatę Tej Kwoty !!!"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;2000.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 3.6, 650.89,
             Currency.USD, 3,
             "!!! Stan Konta Nie Pozwala Na Wypłatę Tej Kwoty !!!"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 1.0, -50.00,
             Currency.PLN, 1,
             "!!! Niepoprawny zapis kwoty !!!"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;500.01;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 3.1, -200.65,
             Currency.USD, 1,
             "!!! Niepoprawny zapis kwoty !!!"),
         Order(0)]
        public void BankAccount_When_Take_Out_Money(
            string[] basicUsersData, decimal takeOutCurrencyRate,
            decimal takeOutValue, Currency takeOutCurrency,
            int basicUserId, string expected)
        {
            string result = "OK";

            //arrange
            BankAccount bankAccount = null;
            BasicUser basicUser = null;

            decimal beginBasicUserBankAccountState = -1;


            //Init database
            initData();

            //Init basic users database
            using (StreamWriter sw = new StreamWriter(
                "cashDispenserDatabase/BasicUsers.txt", false))
            {
                foreach (var basicUserData in basicUsersData)
                {
                    sw.WriteLine(basicUserData);
                }
            }

            //Get respectively basic user's from database
            try
            {
                MockBasicUsersRepository mockBasicUsersRepository =
                    new MockBasicUsersRepository(
                        cashDispenserLibraryTestSettings._SystemSettings);

                basicUser = mockBasicUsersRepository.Get(
                    basicUserId: basicUserId);
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {
                result = mbur_e.What();
            }

            //Get basic user's begin nak account state
            if (result.Equals("OK"))
            {
                beginBasicUserBankAccountState =
                    basicUser._BankAccount.state._Value;
            }

            if (result.Equals("OK"))
            {
                //Create bank account base on respectively basic user
                try
                {
                    bankAccount = new BankAccount(state: new MoneyVAL(
                        value: basicUser._BankAccount.state._Value,
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
                                currency: takeOutCurrency), basicUser);
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
                                         (PhysicalMoney_txt -
                                          (takeOutValue * takeOutCurrencyRate))) > 0.002M)
                            {
                                result = "Bad physical money database result value";
                            }

                            //Check database currency
                            if (physicalMoneyState._Currency != Currency.PLN)
                            {
                                result = "Bad physical money database result currency";
                            }

                            //--- Check basic user's bank account state in
                            //repository state ---

                            //Connect with database
                            try
                            {
                                MockBasicUsersRepository mockBasicUsersRepository =
                                    new MockBasicUsersRepository(
                                        cashDispenserLibraryTestSettings._SystemSettings);

                                basicUser = mockBasicUsersRepository.Get(
                                    basicUserId: basicUserId);
                            }
                            catch (MockBasicUsersRepository_Exception mbur_e)
                            {
                                result = mbur_e.What();
                            }

                            //Check basic user money's state
                            if (result.Equals("OK"))
                            {
                                if (Math.Abs(basicUser._BankAccount.state._Value -
                                             (beginBasicUserBankAccountState -
                                              (takeOutValue * takeOutCurrencyRate))) > 0.002M)
                                {
                                    result = "Bad basic user money database result value";
                                }

                                if (basicUser._BankAccount.state._Currency != Currency.PLN)
                                {
                                    result = "Bad basic user money database result currency";
                                }
                            }
                        }
                    }
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }

        [
            TestCase(new string[]
                {
                    "0;0007;James;Bond;3000582.69;0",
                    "1;0009;Michał;Kopiel;300.99;0",
                    "2;0123;Ryszard;Ryszardzki;500.01;0",
                    "3;1111;Krzysiu;Sise;7777.33;0",
                    "4;1001;Radziu;Grudlewski;5555.05;0"
                }, 1.0, 300.66,
                Currency.PLN, 1, "OK"),
            TestCase(new string[]
                {
                    "0;0007;James;Bond;3000582.69;0",
                    "1;0009;Michał;Kopiel;300.99;0",
                    "2;0123;Ryszard;Ryszardzki;500.01;0",
                    "3;1111;Krzysiu;Sise;7777.33;0",
                    "4;1001;Radziu;Grudlewski;5555.05;0"
                }, 3.6, 150.13,
                Currency.USD, 3, "OK"),
            TestCase(new string[]
                {
                    "0;0007;James;Bond;3000582.69;0",
                    "1;0009;Michał;Kopiel;300.99;0",
                    "2;0123;Ryszard;Ryszardzki;500.01;0",
                    "3;1111;Krzysiu;Sise;7777.33;0",
                    "4;1001;Radziu;Grudlewski;5555.05;0"
                }, 4.3, 100.00,
                Currency.EUR, 2, "OK"),
            TestCase(new string[]
                {
                    "0;0007;James;Bond;3000582.69;0",
                    "1;0009;Michał;Kopiel;300.99;0",
                    "2;0123;Ryszard;Ryszardzki;500.01;0",
                    "3;1111;Krzysiu;Sise;7777.33;0",
                    "4;1001;Radziu;Grudlewski;5555.05;0"
                }, 5.1, 200.45,
                Currency.GBP,2, "OK"),
            TestCase(new string[]
                {
                    "0;0007;James;Bond;3000582.69;0",
                    "1;0009;Michał;Kopiel;300.99;0",
                    "2;0123;Ryszard;Ryszardzki;500.01;0",
                    "3;1111;Krzysiu;Sise;7777.33;0",
                    "4;1001;Radziu;Grudlewski;5555.05;0"
                },0.0, 300.66,
                Currency.PLN, 4,
                "!!! Zła Wartość Współczynnika Walutowego !!!"),
            TestCase(new string[]
                {
                    "0;0007;James;Bond;3000582.69;0",
                    "1;0009;Michał;Kopiel;300.99;0",
                    "2;0123;Ryszard;Ryszardzki;500.01;0",
                    "3;1111;Krzysiu;Sise;7777.33;0",
                    "4;1001;Radziu;Grudlewski;5555.05;0"
                }, 0.0, 300.66,
                Currency.GBP, 3,
                "!!! Zła Wartość Współczynnika Walutowego !!!"),
            TestCase(new string[]
                {
                    "0;0007;James;Bond;3000582.69;0",
                    "1;0009;Michał;Kopiel;300.99;0",
                    "2;0123;Ryszard;Ryszardzki;500.01;0",
                    "3;1111;Krzysiu;Sise;7777.33;0",
                    "4;1001;Radziu;Grudlewski;5555.05;0"
                }, 3.2, -90.87,
                Currency.USD, 4,
                "!!! Niepoprawny zapis kwoty !!!"),
            TestCase(new string[]
                {
                    "0;0007;James;Bond;3000582.69;0",
                    "1;0009;Michał;Kopiel;300.99;0",
                    "2;0123;Ryszard;Ryszardzki;500.01;0",
                    "3;1111;Krzysiu;Sise;7777.33;0",
                    "4;1001;Radziu;Grudlewski;5555.05;0"
                }, -3.0, 12.2,
                Currency.USD, 3,
                "!!! Zła Wartość Współczynnika Walutowego !!!"),
            TestCase(new string[]
                {
                    "0;0007;James;Bond;3000582.69;0",
                    "1;0009;Michał;Kopiel;300.99;0",
                    "2;0123;Ryszard;Ryszardzki;500.01;0",
                    "3;1111;Krzysiu;Sise;7777.33;0",
                    "4;1001;Radziu;Grudlewski;5555.05;0"
                }, 0.0, 0.0,
                Currency.EUR, 4,
                "!!! Zła Wartość Współczynnika Walutowego !!!"),
            TestCase(new string[]
                {
                    "0;0007;James;Bond;3000582.69;0",
                    "1;0009;Michał;Kopiel;300.99;0",
                    "2;0123;Ryszard;Ryszardzki;500.01;0",
                    "3;1111;Krzysiu;Sise;7777.33;0",
                    "4;1001;Radziu;Grudlewski;5555.05;0"
                }, -4.0, -12.2,
                Currency.EUR, 3,
                "!!! Niepoprawny zapis kwoty !!!"),
            Order(1)]
        public void BankAccount_When_Add_Money(
            string[] basicUsersData, decimal addCurrencyRate,
            decimal addValue, Currency addCurrency,
            int basicUserId, string expected)
        {
            string result = "OK";

            //arrange
            BankAccount bankAccount = null;
            BasicUser basicUser = null;

            decimal beginBasicUserBankAccountState = -1;

            //Init database
            initData();

            //Init basic users database
            using (StreamWriter sw = new StreamWriter(
                "cashDispenserDatabase/BasicUsers.txt", false))
            {
                foreach (var basicUserData in basicUsersData)
                {
                    sw.WriteLine(basicUserData);
                }
            }

            //Get respectively basic user's from database
            try
            {
                MockBasicUsersRepository mockBasicUsersRepository =
                    new MockBasicUsersRepository(
                        cashDispenserLibraryTestSettings._SystemSettings);

                basicUser = mockBasicUsersRepository.Get(
                    basicUserId: basicUserId);
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {
                result = mbur_e.What();
            }

            //Get basic user's begin account state
            if (result.Equals("OK"))
            {
                beginBasicUserBankAccountState =
                    basicUser._BankAccount.state._Value;
            }

            if (result.Equals("OK"))
            {
                //Create bank account base on respectively basic user
                try
                {
                    bankAccount = new BankAccount(state: new MoneyVAL(
                        value: basicUser._BankAccount.state._Value,
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
                    //Add money
                    try
                    {
                        bankAccount.AddMoney(currencyRate: addCurrencyRate,
                            money: new MoneyVAL(value: addValue,
                                currency: addCurrency), basicUser);
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
                                != PhysicalMoney_txt)
                            {
                                result = "Bad database value";
                            }

                            //Check database currency
                            if (physicalMoneyState._Currency != Currency.PLN)
                            {
                                result = "Bad database currency";
                            }

                            //--- Check basic user's bank account state in
                            //repository state ---

                            //Connect with database
                            try
                            {
                                MockBasicUsersRepository mockBasicUsersRepository =
                                    new MockBasicUsersRepository(
                                        cashDispenserLibraryTestSettings._SystemSettings);

                                basicUser = mockBasicUsersRepository.Get(
                                    basicUserId: basicUserId);
                            }
                            catch (MockBasicUsersRepository_Exception mbur_e)
                            {
                                result = mbur_e.What();
                            }

                            //Check basic user money's state
                            if (result.Equals("OK"))
                            {
                                if (Math.Abs((basicUser._BankAccount.state._Value -
                                             addValue * addCurrencyRate) -
                                             beginBasicUserBankAccountState) > 0.002M)
                                {
                                    result = "Bad basic user money database result value";
                                }

                                if (basicUser._BankAccount.state._Currency != Currency.PLN)
                                {
                                    result = "Bad basic user money database result currency";
                                }
                            }
                        }
                    }
                }

                //assert
                Assert.AreEqual(expected: expected, actual: result);
            }
        }
    }
}