using System.Collections.Generic;
using System.IO;
using System.Linq;
using cashDispenserLibrary.Data;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.MockAdministratorsRepository;
using cashDispenserLibrary.Model.MockAdministratorsRepository.Exceptions;
using NUnit.Framework;

namespace cashDispenserTest.MockRepositoriesTest
{
    [TestFixture]
    public class MockAdministratorsRepository_Test
    {
        [TestCase(new string[]
         {
             "0;000007;James;Bond;",
             "1;150009;Michał;Kopiel;",
             "2;570123;Ryszard;Ryszardzki;",
             "3;101111;Krzysiu;Sise;",
             "4;011001;Radziu;Grudlewski;",
             "5;331090;Krzyś;NieOdDziś;"
         }, "150009", "OK"),
         TestCase(new string[]
         {
             "0;000007;James;Bond;",
             "1;150009;Michał;Kopiel;",
             "2;570123;Ryszard;Ryszardzki;",
             "3;101111;Krzysiu;Sise;",
             "4;011001;Radziu;Grudlewski;",
             "5;331090;Krzyś;NieOdDziś;"
         }, "011001", "OK"),
         TestCase(new string[] { }, "011001",
             "!!! Nie Istnieje Żaden Administrator W Bazie Danych !!!"),
         TestCase(new string[] { }, "",
             "!!! Nie Istnieje Żaden Administrator W Bazie Danych !!!"),
         TestCase(new string[]
             {
                 "0;000007;James;Bond;",
                 "1;150009;Michał;Kopiel;",
                 "2;570123;Ryszard;Ryszardzki;",
                 "3;101111;Krzysiu;Sise;",
                 "4;011001;Radziu;Grudlewski;",
                 "5;331090;Krzyś;NieOdDziś;"
             }, "111111",
             "!!! Administrator with it pin does not exist !!!"),
         Order(0)]
        public void
            MockAdministratorsRepository_When_Find_Administrator_By_Pin(
                string[] administratorsData, string pin, string expected)
        {
            string result = "OK";

            //arrange
            MockAdministratorsRepository mockAdministratorsRepository = null;
            Administrator administrator = null;

            var insertAdministrators = new List<string[]>();


            //Convert administrators data
            foreach (var administratorData in administratorsData)
            {
                insertAdministrators.Add(
                    administratorData.Split(';'));
            }

            //Save administrators data
            using (StreamWriter sw = new StreamWriter(
                (cashDispenserLibraryTestSettings._SystemSettings
                 == PlatformType.Windows)
                    ? "cashDispenserDatabase\\Administrators.txt"
                    : "cashDispenserDatabase/Administrators.txt", false))
            {
                foreach (var administratorData in administratorsData)
                {
                    sw.WriteLine(administratorData);
                }
            }

            //act

            //Connect with database
            try
            {
                mockAdministratorsRepository =
                    new MockAdministratorsRepository(
                        cashDispenserLibraryTestSettings._SystemSettings);
            }
            catch (MockAdministratorsRepository_Exception mar_e)
            {
                result = mar_e.What();
            }

            //Find administrator by pin number
            if (result.Equals("OK"))
            {
                try
                {
                    administrator =
                        mockAdministratorsRepository.GetAll().FirstOrDefault(
                            (singleAdministrator) =>
                                singleAdministrator._Pin._Value.Equals(pin));

                    if (administrator == null)
                    {
                        result = "!!! Administrator with it pin does not exist !!!";
                    }
                }
                catch (MockAdministratorsRepository_Exception mar_e)
                {
                    result = mar_e.What();
                }

                // Check received administrator information
                if (result.Equals("OK"))
                {
                    var insertAdministratorWithPin =
                        insertAdministrators.FirstOrDefault(
                            (insertAdministrator) =>
                                insertAdministrator[1].Equals(pin));

                    if (((insertAdministratorWithPin[0].Equals(
                            administrator._Id.ToString())) == false)
                        || ((insertAdministratorWithPin[1].Equals(
                            administrator._Pin._Value)) == false)
                        || ((insertAdministratorWithPin[2].Equals(
                            administrator._Name._Value)) == false)
                        || ((insertAdministratorWithPin[3].Equals(
                            administrator._Surname._Value)) == false))
                    {
                        result = "!!! Bad receive administrator's information !!!";
                    }
                }
            }

            //assert
            Assert.AreEqual(expected: expected, actual: result);
        }
    }
}