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
                    if ((mockBasicUsers[i]._Id.ToString() != insertBasicUsers[i][0])
                        || (mockBasicUsers[i]._Pin._Value.ToString() != insertBasicUsers[i][1])
                        || (mockBasicUsers[i]._Name._Value.ToString() != insertBasicUsers[i][2])
                        || (mockBasicUsers[i]._Surname._Value.ToString() != insertBasicUsers[i][3])
                        || (mockBasicUsers[i]._BankAccount.state._Value.ToString(
                            new CultureInfo("en-US")) != insertBasicUsers[i][4])
                        || (mockBasicUsers[i]._BankAccount.state._Currency != Currency.PLN))
                    {
                        result = "!!! Issue with get basic user !!!";
                    }
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }
    }
}