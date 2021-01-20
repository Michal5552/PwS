using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using cashDispenserLibrary.Data;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;
using NUnit.Framework;

namespace cashDispenserTest.MockRepositoriesTest
{
    [TestFixture]
    public class MockBasicUsersRepository_Test
    {
        [TestCase(new string[]
         {
             "0;0007;James;Bond;3000582.69;0",
             "1;0009;Michał;Kopiel;300.99;0",
             "2;0123;Ryszard;Ryszardzki;380.23;0"
         }, "OK"),
         TestCase(new string[]
         {
             "0;0007;James;Bond;3000582.69;0",
             "1;0009;Michał;Kopiel;300.99;0",
             "2;0123;Ryszard;Ryszardzki;380.23;0",
             "3;1111;Krzysiu;Sise;7777.33;0",
             "4;1001;Radziu;Grudlewski;5555.05;0"
         }, "OK"),
         TestCase(new string[] { },
             "!!! Nie Istnieje Żaden Użytkownik Podstawowy W Bazie Danych !!!"),
         Order(0)]
        public void MockBasicUsersRepository_When_Get_All(
            string[] basicUsersData, string expected)
        {
            string result = "OK";

            //arrange
            var mockBasicUsers = new List<BasicUser>();
            var insertBasicUsers = new List<string[]>();


            //Convert basic users data
            foreach (var basicUserData in basicUsersData)
            {
                insertBasicUsers.Add(basicUserData.Split(';'));
            }

            using (StreamWriter sw = new StreamWriter(
                (cashDispenserLibraryTestSettings._SystemSettings
                 == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt", false))
            {
                foreach (var basicUserData in basicUsersData)
                {
                    sw.WriteLine(basicUserData);
                }
            }

            //act

            //Connect with database
            MockBasicUsersRepository mockBasicUsersRepository =
                new MockBasicUsersRepository(
                    cashDispenserLibraryTestSettings._SystemSettings);

            //Get all basic users
            try
            {
                mockBasicUsers = mockBasicUsersRepository.GetAll().ToList();
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {
                result = mbur_e.What();
            }


            if (result.Equals("OK"))
            {
                //Check got basic users
                for (int i = 0; i < insertBasicUsers.Count; ++i)
                {
                    if ((!(mockBasicUsers[i]._Id.ToString().Equals(insertBasicUsers[i][0])))
                        || (!(mockBasicUsers[i]._Pin._Value.Equals(insertBasicUsers[i][1])))
                        || (!(mockBasicUsers[i]._Name._Value.Equals(insertBasicUsers[i][2])))
                        || (!(mockBasicUsers[i]._Surname._Value.Equals(insertBasicUsers[i][3])))
                        || (!(mockBasicUsers[i]._BankAccount.state._Value.ToString(
                            new CultureInfo("en-US")).Equals(insertBasicUsers[i][4])))
                        || (mockBasicUsers[i]._BankAccount.state._Currency != Currency.PLN))
                    {
                        result = "!!! Issue with get basic user !!!";
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
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 2, "0123", "Ryszard",
             "Ryszardzki", 380.23,
             Currency.PLN, "OK"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 4, "1001", "Radziu",
             "Grudlewski", 5555.05,
             Currency.PLN, "OK"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0",
                 "5;1090;Krzyś;NieOdDziś;333.33;0"
             }, 4, "1001", "Radziu",
             "Grudlewski", 5555.05,
             Currency.PLN, "OK"),
         TestCase(new string[] { },
             4, "1001", "Radziu",
             "Grudlewski", 5555.05,
             Currency.PLN,
             "!!! Nie Istnieje Żaden Użytkownik Podstawowy W Bazie Danych !!!"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0",
                 "5;1090;Krzyś;NieOdDziś;333.33;0"
             },
             7, "1001", "Radziu",
             "Grudlewski", 5555.05,
             Currency.PLN,
             "!!! Użytkownik Nie Istnieje W Bazie !!!"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0",
                 "5;1090;Krzyś;NieOdDziś;333.33;0"
             },
             9, "1101", "Krzysiu",
             "Krzysiewski", 13.13,
             Currency.PLN,
             "!!! Użytkownik Nie Istnieje W Bazie !!!"),
         Order(1)]
        public void MockBasicUsersRepository_When_Get(
            string[] basicUsersData, int basicUserId, string basicUserPin,
            string basicUserName, string basicUserSurname,
            decimal basicUserBankAccountValue, Currency basicUserBankAccountCurrency,
            string expected)
        {
            string result = "OK";

            //arrange
            using (StreamWriter sw = new StreamWriter(
                (cashDispenserLibraryTestSettings._SystemSettings
                 == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt", false))
            {
                foreach (var basicUserData in basicUsersData)
                {
                    sw.WriteLine(basicUserData);
                }
            }

            //act

            //Connect with database
            MockBasicUsersRepository mockBasicUsersRepository =
                new MockBasicUsersRepository(
                    cashDispenserLibraryTestSettings._SystemSettings);

            //Get information about respectively basic user
            BasicUser gotBasicUser = null;

            try
            {
                gotBasicUser =
                    mockBasicUsersRepository.Get(basicUserId: basicUserId);
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {
                result = mbur_e.What();
            }

            //Check got basic user
            if (result.Equals("OK"))
            {
                if ((gotBasicUser._Id != basicUserId)
                    || (!(gotBasicUser._Pin._Value.Equals(basicUserPin)))
                    || (!(gotBasicUser._Name._Value.Equals(basicUserName)))
                    || (!(gotBasicUser._Surname._Value.Equals(basicUserSurname)))
                    || (gotBasicUser._BankAccount.state._Value != basicUserBankAccountValue)
                    || (gotBasicUser._BankAccount.state._Currency != basicUserBankAccountCurrency))
                {
                    result = "!!! Issue with get basic user !!!";
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }

        [TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 5, "0123", "Marian",
             "Kozłowski", 500.00,
             Currency.PLN, "OK"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 5, "010123", "Krzyś",
             "Ciuta", 510.00,
             Currency.PLN, "OK"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, -1, "1023", "Marian",
             "Kozłowski", 500.00,
             Currency.PLN, "OK"),
         TestCase(new string[] { },
             6, "0123", "Marian",
             "Kozłowski", 500.00,
             Currency.PLN, "OK"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 0, "0007", "James",
             "Bond", 3000582.69,
             Currency.PLN,
             "!!! Użytkownik Już Istnieje W Bazie !!!"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0"
             }, 3, "1111", "Krzysiu",
             "Sise", 7777.33,
             Currency.PLN,
             "!!! Użytkownik Już Istnieje W Bazie !!!"),
         Order(2)]
        public void MockBasicUsersRepository_When_Add(
            string[] basicUsersData, int basicUserId, string basicUserPin,
            string basicUserName, string basicUserSurname,
            decimal basicUserBankAccountValue, Currency basicUserBankAccountCurrency,
            string expected)
        {
            string result = "OK";

            //Set id counter
            if (basicUsersData.Length > 0)
            {
                User._Id_counter = ((basicUsersData.Last()[0] - 48) + 1);
            }
            else
            {
                User._Id_counter = 0;
            }

            //arrange
            using (StreamWriter sw = new StreamWriter(
                (cashDispenserLibraryTestSettings._SystemSettings
                 == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt", false))
            {
                foreach (var basicUserData in basicUsersData)
                {
                    sw.WriteLine(basicUserData);
                }
            }

            //act

            //Connect with database
            MockBasicUsersRepository mockBasicUsersRepository =
                new MockBasicUsersRepository(
                    cashDispenserLibraryTestSettings._SystemSettings);

            try
            {
                mockBasicUsersRepository.Add(basicUser: new BasicUser(
                    id: basicUserId, pin: new PinVAL(value: basicUserPin),
                    name: new NameVAL(value: basicUserName),
                    surname: new SurnameVAL(value: basicUserSurname),
                    bankAccount: new BankAccount(
                        state: new MoneyVAL(
                            value: basicUserBankAccountValue,
                            currency: basicUserBankAccountCurrency))));
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {
                result = mbur_e.What();
            }

            if (result.Equals("OK"))
            {
                //Check add result
                BasicUser added_basicUser = null;

                try
                {
                    if (basicUserId >= 0)
                    {
                        added_basicUser = mockBasicUsersRepository.Get(
                            basicUserId: basicUserId);
                    }
                    else
                    {
                        added_basicUser = mockBasicUsersRepository.Get(
                            basicUserId: (User._Id_counter - 1));
                    }
                }
                catch (MockBasicUsersRepository_Exception mbur_e)
                {
                    result = mbur_e.What();
                }

                if (result.Equals("OK"))
                {
                    if ((((basicUserId >= 0) && (added_basicUser._Id != basicUserId))
                         || ((basicUserId < 0) && (added_basicUser._Id != (User._Id_counter - 1))))
                        || (!(added_basicUser._Pin._Value.Equals(basicUserPin)))
                        || (!(added_basicUser._Name._Value.Equals(basicUserName)))
                        || (!(added_basicUser._Surname._Value.Equals(basicUserSurname)))
                        || (added_basicUser._BankAccount.state._Value != basicUserBankAccountValue)
                        || (added_basicUser._BankAccount.state._Currency != basicUserBankAccountCurrency))
                    {
                        result = "!!! Issue with get basic user !!!";
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
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0",
                 "5;1090;Krzyś;NieOdDziś;333.33;0"
             }, 5, "1011", "Stanisław",
             "Rydzewski", 10.00,
             Currency.PLN, "OK"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0",
                 "5;1090;Krzyś;NieOdDziś;333.33;0"
             }, 2, "0011", "Romuald",
             "Roj", 100.00,
             Currency.PLN, "OK"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0",
                 "5;1090;Krzyś;NieOdDziś;333.33;0"
             }, 6, "0011", "Romuald",
             "Roj", 100.00,
             Currency.PLN,
             "!!! Użytkownik Nie Istnieje W Bazie !!!"),
         TestCase(new string[]
             {
                 "0;0007;James;Bond;3000582.69;0",
                 "1;0009;Michał;Kopiel;300.99;0",
                 "2;0123;Ryszard;Ryszardzki;380.23;0",
                 "3;1111;Krzysiu;Sise;7777.33;0",
                 "4;1001;Radziu;Grudlewski;5555.05;0",
                 "5;1090;Krzyś;NieOdDziś;333.33;0"
             }, 10, "1011", "Ranik",
             "Ryś", 102.02,
             Currency.PLN,
             "!!! Użytkownik Nie Istnieje W Bazie !!!"),
         TestCase(new string[] { },
             10, "1011", "Ranik",
             "Ryś", 102.02,
             Currency.PLN,
             "!!! Nie Istnieje Żaden Użytkownik Podstawowy W Bazie Danych !!!"),
         Order(3)]
        public void MockBasicUsersRepository_When_Update(
            string[] basicUsersData, int basicUserId, string basicUserPin,
            string basicUserName, string basicUserSurname,
            decimal basicUserBankAccountValue, Currency basicUserBankAccountCurrency,
            string expected)
        {
            string result = "OK";

            //arrange
            using (StreamWriter sw = new StreamWriter(
                (cashDispenserLibraryTestSettings._SystemSettings
                 == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt", false))
            {
                foreach (var basicUserData in basicUsersData)
                {
                    sw.WriteLine(basicUserData);
                }
            }

            //act

            //Connect with database
            MockBasicUsersRepository mockBasicUsersRepository =
                new MockBasicUsersRepository(
                    cashDispenserLibraryTestSettings._SystemSettings);

            try
            {
                mockBasicUsersRepository.Update(basicUser: new BasicUser(
                    id: basicUserId, pin: new PinVAL(value: basicUserPin),
                    name: new NameVAL(value: basicUserName),
                    surname: new SurnameVAL(value: basicUserSurname),
                    bankAccount: new BankAccount(
                        state: new MoneyVAL(
                            value: basicUserBankAccountValue,
                            currency: basicUserBankAccountCurrency))));
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {
                result = mbur_e.What();
            }

            if (result.Equals("OK"))
            {
                //Check add result
                BasicUser updated_basicUser = null;

                try
                {
                    updated_basicUser = mockBasicUsersRepository.Get(
                        basicUserId: basicUserId);
                }
                catch (MockBasicUsersRepository_Exception mbur_e)
                {
                    result = mbur_e.What();
                }

                if (result.Equals("OK"))
                {
                    if ((updated_basicUser._Id != basicUserId)
                        || (!(updated_basicUser._Pin._Value.Equals(basicUserPin)))
                        || (!(updated_basicUser._Name._Value.Equals(basicUserName)))
                        || (!(updated_basicUser._Surname._Value.Equals(basicUserSurname)))
                        || (updated_basicUser._BankAccount.state._Value != basicUserBankAccountValue)
                        || (updated_basicUser._BankAccount.state._Currency != basicUserBankAccountCurrency))
                    {
                        result = "!!! Issue with get basic user !!!";
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
             "2;0123;Ryszard;Ryszardzki;380.23;0",
             "3;1111;Krzysiu;Sise;7777.33;0",
             "4;1001;Radziu;Grudlewski;5555.05;0",
             "5;1090;Krzyś;NieOdDziś;333.33;0"
         }, 1, "!!! Użytkownik Nie Istnieje W Bazie !!!"),
         TestCase(new string[]
         {
             "0;0007;James;Bond;3000582.69;0",
             "1;0009;Michał;Kopiel;300.99;0",
             "2;0123;Ryszard;Ryszardzki;380.23;0",
             "3;1111;Krzysiu;Sise;7777.33;0",
             "4;1001;Radziu;Grudlewski;5555.05;0",
             "5;1090;Krzyś;NieOdDziś;333.33;0"
         }, 3, "!!! Użytkownik Nie Istnieje W Bazie !!!"),
         TestCase(new string[]
         {
             "0;0007;James;Bond;3000582.69;0",
             "1;0009;Michał;Kopiel;300.99;0",
             "2;0123;Ryszard;Ryszardzki;380.23;0",
             "3;1111;Krzysiu;Sise;7777.33;0",
             "4;1001;Radziu;Grudlewski;5555.05;0",
             "5;1090;Krzyś;NieOdDziś;333.33;0"
         }, 5, "!!! Użytkownik Nie Istnieje W Bazie !!!"),
         TestCase(new string[]
         {
             "0;0007;James;Bond;3000582.69;0",
             "1;0009;Michał;Kopiel;300.99;0",
             "2;0123;Ryszard;Ryszardzki;380.23;0",
             "3;1111;Krzysiu;Sise;7777.33;0",
             "4;1001;Radziu;Grudlewski;5555.05;0",
             "5;1090;Krzyś;NieOdDziś;333.33;0"
         }, 0, "!!! Użytkownik Nie Istnieje W Bazie !!!"),
         Order(4)]
        public void MockBasicUsersRepository_When_Remove(
            string[] basicUsersData, int basicUserId, string expected)
        {
            string result = "OK";

            //arrange
            using (StreamWriter sw = new StreamWriter(
                (cashDispenserLibraryTestSettings._SystemSettings
                 == PlatformType.Windows)
                    ? "cashDispenserDatabase\\BasicUsers.txt"
                    : "cashDispenserDatabase/BasicUsers.txt", false))
            {
                foreach (var basicUserData in basicUsersData)
                {
                    sw.WriteLine(basicUserData);
                }
            }

            //act

            //Connect with database
            MockBasicUsersRepository mockBasicUsersRepository =
                new MockBasicUsersRepository(
                    cashDispenserLibraryTestSettings._SystemSettings);

            //Remove basic user
            try
            {
                mockBasicUsersRepository.Remove(basicUserId: basicUserId);
            }
            catch (MockBasicUsersRepository_Exception mbur_e)
            {
                result = mbur_e.What();
            }

            //Check remove's result
            if (result.Equals("OK"))
            {
                try
                {
                    mockBasicUsersRepository.Get(basicUserId: basicUserId);
                }
                catch (MockBasicUsersRepository_Exception mbur_e)
                {
                    result = mbur_e.What();
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }
    }
}