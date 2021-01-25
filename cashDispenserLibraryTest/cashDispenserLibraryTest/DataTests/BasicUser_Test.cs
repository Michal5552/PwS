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
    // TODO before update test it can't work (BankAccount is in test phase)
    [TestFixture]
    public class BasicUser_Test
    {
        private readonly decimal PhysicalMoney_txt = 1680.90M;

        private void initData()
        {
            using (StreamWriter sw = new StreamWriter(
                "cashDispenserDatabase/PhysicalMoney.txt", false))
            {
                sw.WriteLine($"{PhysicalMoney_txt};0");
            }
        }

        [TestCase(7, "0007", "James", "Bond",
             2_300_000, Currency.PLN,
             "OK"),
         TestCase(9, "0009", "Michał", "Kowalski",
             300_598.67, Currency.PLN,
             "OK"),
         TestCase(-1, "0010", "Dariusz", "Jo",
             234.67, Currency.PLN,
             "OK"),
         TestCase(-7, "001001", "Dariusz", "Jo",
             1000.51, Currency.PLN,
             "OK"),
         TestCase(12, "0010", "Mariusz", "Zbigniewski",
             234.67, Currency.USD,
             "!!! Waluta Jest Różna Od PLN !!!"),
         TestCase(12, "00101", "Mariusz", "Zbigniewski",
             234.67, Currency.PLN,
             "!!! Długość Pinu Jest Nie Prawidłowa!!!"),
         TestCase(12, "101", "Mariusz", "Zbigniewski",
             234.67, Currency.PLN,
             "!!! Długość Pinu Jest Nie Prawidłowa!!!"),
         TestCase(12, "1010123", "Mariusz", "Zbigniewski",
             234.67, Currency.PLN,
             "!!! Długość Pinu Jest Nie Prawidłowa!!!"),
         TestCase(12, "10a100", "Mariusz", "Zbigniewski",
             234.67, Currency.PLN,
             "!!! W pinie znajduje się niedozwolony znak !!!"),
         TestCase(12, "101100", "", "Zbigniewski",
             234.67, Currency.PLN,
             "!!! Niepoprawny zapis imienia !!!"),
         TestCase(12, "101100", "Mariusz", "",
             234.67, Currency.PLN,
             "!!! Niepoprawny zapis nazwiska !!!"),
         Order(0)]
        public void BasicUser_When_Init(int id, string pin,
            string name, string surname, decimal bankAccountValue,
            Currency bankAccountCurrency, string expected)
        {
            string result = "OK";

            //arrange
            int id_counter = User._Id_counter;

            BasicUser basicUser = null;

            try
            {
                basicUser = new BasicUser(
                    id: id, pin: new PinVAL(value: pin),
                    name: new NameVAL(value: name),
                    surname: new SurnameVAL(value: surname),
                    bankAccount: new BankAccount(
                        state: new MoneyVAL(value: bankAccountValue,
                            currency: bankAccountCurrency)));
            }
            catch (PinVAL_Exception p_e)
            {
                result = p_e.What();
            }
            catch (NameVAL_Exception n_e)
            {
                result = n_e.What();
            }
            catch (SurnameVAL_Exception s_e)
            {
                result = s_e.What();
            }
            catch (BankAccount_Exception b_e)
            {
                result = b_e.What();
            }
            catch (MoneyVAL_Exception m_e)
            {
                result = m_e.What();
            }

            //act
            if (result.Equals("OK"))
            {
                //Check static id value case
                if (id >= 0)
                {
                    //Check id
                    if (basicUser._Id != id)
                    {
                        result = "Bad id";
                    }
                    //Check pin
                    else if ((basicUser._Pin._Value.Equals(pin)) == false)
                    {
                        result = "Bad pin";
                    }

                    //Check name
                    else if ((basicUser._Name._Value.Equals(name)) == false)
                    {
                        result = "Bad name";
                    }

                    //Check surname
                    else if ((basicUser._Surname._Value.Equals(surname)) == false)
                    {
                        result = "Bad surname";
                    }

                    //Check bank account value
                    else if (basicUser._BankAccount.state._Value != bankAccountValue)
                    {
                        result = "Bad account value";
                    }

                    //Check bank account currency
                    else if (basicUser._BankAccount.state._Currency != bankAccountCurrency)
                    {
                        result = "Bad account currency";
                    }
                }

                //Check auto increment id value case
                else if (id < 0)
                {
                    //Check id
                    if (basicUser._Id != id_counter)
                    {
                        result = "Bad id";
                    }

                    //Check id counter work
                    else if (User._Id_counter != (id_counter + 1))
                    {
                        result = "Bad id counter work";
                    }

                    //Check pin
                    else if ((basicUser._Pin._Value.Equals(pin)) == false)
                    {
                        result = "Bad pin";
                    }

                    //Check name
                    else if ((basicUser._Name._Value.Equals(name)) == false)
                    {
                        result = "Bad name";
                    }

                    //Check surname
                    else if ((basicUser._Surname._Value.Equals(surname)) == false)
                    {
                        result = "Bad surname";
                    }

                    //Check bank account value
                    else if (basicUser._BankAccount.state._Value != bankAccountValue)
                    {
                        result = "Bad account value";
                    }

                    //Check bank account currency
                    else if (basicUser._BankAccount.state._Currency != bankAccountCurrency)
                    {
                        result = "Bad account currency";
                    }
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }

        [TestCase("1000", "OK"),
         TestCase("1101", "OK"),
         TestCase("100110", "OK"),
         TestCase("10011",
             "!!! Długość Pinu Jest Nie Prawidłowa!!!"),
         TestCase("1a0011",
             "!!! W pinie znajduje się niedozwolony znak !!!"),
         Order(0)]
        public void BasicUser_When_Change_Pin(string changePin, string expected)
        {
            string result = "OK";

            //arrange
            BasicUser basicUser = null;
            string corePin = "1010";

            try
            {
                basicUser = new BasicUser(
                    id: 0, pin: new PinVAL(value: corePin),
                    name: new NameVAL(value: "Imię"),
                    surname: new SurnameVAL(value: "Nazwisko"),
                    bankAccount: new BankAccount(
                        state: new MoneyVAL(value: 200.0M,
                            currency: Currency.PLN)));
            }
            catch (PinVAL_Exception p_e)
            {
                result = p_e.What();
            }
            catch (NameVAL_Exception n_e)
            {
                result = n_e.What();
            }
            catch (SurnameVAL_Exception s_e)
            {
                result = s_e.What();
            }
            catch (BankAccount_Exception b_e)
            {
                result = b_e.What();
            }
            catch (MoneyVAL_Exception m_e)
            {
                result = m_e.What();
            }

            //act
            if (result.Equals("OK"))
            {
                try
                {
                    basicUser.ChangePin(pin: new PinVAL(value: changePin));
                }
                catch (PinVAL_Exception p_e)
                {
                    result = p_e.What();
                }

                if (result.Equals("OK"))
                {
                    if (basicUser._Pin._Value.Equals(changePin) == false)
                    {
                        result = "Issue with change Pin";
                    }
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }

        [TestCase("Michał", "OK"),
         TestCase("James", "OK"),
         TestCase("", "!!! Niepoprawny zapis imienia !!!"),
         Order(0)]
        public void BasicUser_When_Change_Name(string changeName, string expected)
        {
            string result = "OK";

            //arrange
            BasicUser basicUser = null;
            string coreName = "Imię";

            try
            {
                basicUser = new BasicUser(
                    id: 0, pin: new PinVAL(value: "1010"),
                    name: new NameVAL(value: coreName),
                    surname: new SurnameVAL(value: "Nazwisko"),
                    bankAccount: new BankAccount(
                        state: new MoneyVAL(value: 200.0M,
                            currency: Currency.PLN)));
            }
            catch (PinVAL_Exception p_e)
            {
                result = p_e.What();
            }
            catch (NameVAL_Exception n_e)
            {
                result = n_e.What();
            }
            catch (SurnameVAL_Exception s_e)
            {
                result = s_e.What();
            }
            catch (BankAccount_Exception b_e)
            {
                result = b_e.What();
            }
            catch (MoneyVAL_Exception m_e)
            {
                result = m_e.What();
            }

            //act
            if (result.Equals("OK"))
            {
                try
                {
                    basicUser.ChangeName(name: new NameVAL(value: changeName));
                }
                catch (NameVAL_Exception n_e)
                {
                    result = n_e.What();
                }

                if (result.Equals("OK"))
                {
                    if (basicUser._Name._Value.Equals(changeName) == false)
                    {
                        result = "Issue with change name";
                    }
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }

        [TestCase("Wacławowski", "OK"),
         TestCase("Kozłowski", "OK"),
         TestCase("", "!!! Niepoprawny zapis nazwiska !!!"),
         Order(0)]
        public void BasicUser_When_Change_Surname(
            string changeSurname, string expected)
        {
            string result = "OK";

            //arrange
            BasicUser basicUser = null;
            string coreSurname = "Nazwisko";

            try
            {
                basicUser = new BasicUser(
                    id: 0, pin: new PinVAL(value: "1010"),
                    name: new NameVAL(value: "Imię"),
                    surname: new SurnameVAL(value: coreSurname),
                    bankAccount: new BankAccount(
                        state: new MoneyVAL(value: 200.0M,
                            currency: Currency.PLN)));
            }
            catch (PinVAL_Exception p_e)
            {
                result = p_e.What();
            }
            catch (NameVAL_Exception n_e)
            {
                result = n_e.What();
            }
            catch (SurnameVAL_Exception s_e)
            {
                result = s_e.What();
            }
            catch (BankAccount_Exception b_e)
            {
                result = b_e.What();
            }
            catch (MoneyVAL_Exception m_e)
            {
                result = m_e.What();
            }

            //act
            if (result.Equals("OK"))
            {
                try
                {
                    basicUser.ChangeSurname(surname: new SurnameVAL(value: changeSurname));
                }
                catch (SurnameVAL_Exception s_e)
                {
                    result = s_e.What();
                }

                if (result.Equals("OK"))
                {
                    if (basicUser._Surname._Value.Equals(changeSurname) == false)
                    {
                        result = "Issue with change surname";
                    }
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
        public void BasicUser_When_Show_State(
            decimal PLN_currencyRate, decimal USD_currencyRate,
            decimal EUR_currencyRate, decimal GBP_currencyRate, string expected)
        {
            string result = "OK";

            //arrange
            BasicUser basicUser = null;

            try
            {
                basicUser = new BasicUser(
                    id: 0, pin: new PinVAL(value: "1111"),
                    name: new NameVAL(value: "Imię"),
                    surname: new SurnameVAL(value: "Nazwisko"),
                    bankAccount: new BankAccount(
                        state: new MoneyVAL(
                            value: PhysicalMoney_txt,
                            currency: Currency.PLN)));
            }
            catch (PinVAL_Exception p_e)
            {
                result = p_e.What();
            }
            catch (NameVAL_Exception n_e)
            {
                result = n_e.What();
            }
            catch (SurnameVAL_Exception s_e)
            {
                result = s_e.What();
            }
            catch (BankAccount_Exception b_e)
            {
                result = b_e.What();
            }
            catch (MoneyVAL_Exception m_e)
            {
                result = m_e.What();
            }

            //act
            if (result.Equals("OK"))
            {
                List<MoneyVAL> bankAccountState = null;

                //Get bank account state
                try
                {
                    bankAccountState =
                        (List<MoneyVAL>) basicUser._BankAccount.ShowState(
                            new Dictionary<Currency, decimal>()
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
         TestCase(1.0, 1779.44,
             Currency.PLN,
             "!!! Stan Konta Nie Pozwala Na Wypłatę Tej Kwoty !!!"),
         TestCase(1.0, 1900.45,
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
         Order(0)]
        public void BasicUser_When_Take_out_Money(
            decimal takeOutCurrencyRate, decimal takeOutValue,
            Currency takeOutCurrency, string expected)
        {
            string result = "OK";

            //arrange
            BasicUser basicUser = null;

            //Init database
            initData();

            try
            {
                basicUser = new BasicUser(
                    id: 0, pin: new PinVAL(value: "1111"),
                    name: new NameVAL(value: "Imię"),
                    surname: new SurnameVAL(value: "Nazwisko"),
                    bankAccount: new BankAccount(
                        state: new MoneyVAL(
                            value: PhysicalMoney_txt,
                            currency: Currency.PLN)));
            }
            catch (PinVAL_Exception p_e)
            {
                result = p_e.What();
            }
            catch (NameVAL_Exception n_e)
            {
                result = n_e.What();
            }
            catch (SurnameVAL_Exception s_e)
            {
                result = s_e.What();
            }
            catch (BankAccount_Exception b_e)
            {
                result = b_e.What();
            }
            catch (MoneyVAL_Exception m_e)
            {
                result = m_e.What();
            }

            //act
            if (result.Equals("OK"))
            {
                //Take out money
                MoneyVAL takeOutMoneyResult = null;

                try
                {
                    takeOutMoneyResult = basicUser._BankAccount.TakeOutMoney(
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
                                     (PhysicalMoney_txt -
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
         Order(1)]
        public void BasicUser_When_Add_Money(
            decimal addCurrencyRate, decimal addValue,
            Currency addCurrency, string expected)
        {
            string result = "OK";

            //arrange
            BasicUser basicUser = null;

            //Init database
            initData();

            try
            {
                basicUser = new BasicUser(
                    id: 0, pin: new PinVAL(value: "1111"),
                    name: new NameVAL(value: "Imię"),
                    surname: new SurnameVAL(value: "Nazwisko"),
                    bankAccount: new BankAccount(
                        state: new MoneyVAL(
                            value: PhysicalMoney_txt,
                            currency: Currency.PLN)));
            }
            catch (PinVAL_Exception p_e)
            {
                result = p_e.What();
            }
            catch (NameVAL_Exception n_e)
            {
                result = n_e.What();
            }
            catch (SurnameVAL_Exception s_e)
            {
                result = s_e.What();
            }
            catch (BankAccount_Exception b_e)
            {
                result = b_e.What();
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
                    basicUser._BankAccount.AddMoney(currencyRate: addCurrencyRate,
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
                            != PhysicalMoney_txt)
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