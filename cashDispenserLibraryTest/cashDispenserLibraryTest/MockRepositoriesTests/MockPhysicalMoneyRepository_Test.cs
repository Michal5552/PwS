// using System;
// using System.Collections.Generic;
// using System.IO;
// using cashDispenserLibrary.Data;
// using cashDispenserLibrary.Model;
// using cashDispenserLibrary.Model.Exceptions;
// using cashDispenserLibrary.Model.MockPhysicalMoneyRepository;
// using NUnit.Framework;
//
// namespace cashDispenserTest.MockRepositoriesTest
// {
//     [TestFixture]
//     public class MockPhysicalMoneyRepository_Test
//     {
//         private readonly decimal PhysicalMoney_txt = 1600.56M;
//         
//         private void initData()
//         {
//             using (StreamWriter sw = new StreamWriter(
//                 "cashDispenserDatabase/PhysicalMoney.txt", false))
//             {
//                 sw.WriteLine($"{PhysicalMoney_txt};0");
//             }
//         }
//
//         public MockPhysicalMoneyRepository_Test()
//         {
//             initData();
//         }
//
//         [TestCase(1, 3.5, 4.0,
//              5.5, "OK"),
//          TestCase(1, 3.7, 4.5,
//              5.6, "OK"),
//          TestCase(1, 3.3, 4.4,
//              5.8, "OK"),
//          TestCase(1, 3.3, 4.4,
//              -9.0, "!!! Zła Wartość Współczynnika Walutowego !!!"),
//          TestCase(1, 0, 4.4,
//              5.8, "!!! Zła Wartość Współczynnika Walutowego !!!"),
//          TestCase(1, -3.3, 4.4,
//              5.8, "!!! Zła Wartość Współczynnika Walutowego !!!"),
//          Order(0)]
//         public void MockPhysicalMoneyRepository_When_Get_All_Currency(
//             decimal PLN_currencyRate, decimal USD_currencyRate,
//             decimal EUR_currencyRate, decimal GBP_currencyRate,
//             string expected)
//         {
//             string result = "OK";
//             IEnumerable<PhysicalMoneyVAL> physicalMoneyInAllCurrency = null;
//
//             //arrange
//             MockPhysicalMoneyRepository mockPhysicalMoneyRepository =
//                 new MockPhysicalMoneyRepository(
//                     cashDispenserLibraryTestSettings._SystemSettings);
//
//             //act
//             try
//             {
//                 physicalMoneyInAllCurrency =
//                     mockPhysicalMoneyRepository.GetAllCurrency(
//                         new Dictionary<Currency, decimal>
//                         {
//                             {Currency.PLN, PLN_currencyRate},
//                             {Currency.USD, USD_currencyRate},
//                             {Currency.EUR, EUR_currencyRate},
//                             {Currency.GBP, GBP_currencyRate},
//                         });
//             }
//             catch (MockPhysicalMoneyRepository_Exception mpmr_e)
//             {
//                 result = mpmr_e.What();
//             }
//             catch (Exception ex)
//             {
//                 result = "!!! Issue with open file !!!";
//             }
//
//             if (result.Equals("OK"))
//             {
//                 //Check values correctness
//                 foreach (var physicalMoneyInCurrency in physicalMoneyInAllCurrency)
//                 {
//                     switch (physicalMoneyInCurrency._Currency)
//                     {
//                         case Currency.PLN:
//                         {
//                             if (physicalMoneyInCurrency._Value !=
//                                 (PhysicalMoney_txt / PLN_currencyRate))
//                             {
//                                 result = $"Bad value for {physicalMoneyInCurrency._Currency.ToString()}";
//                             }
//                         }
//                             break;
//                         case Currency.USD:
//                         {
//                             if (physicalMoneyInCurrency._Value !=
//                                 (PhysicalMoney_txt / USD_currencyRate))
//                             {
//                                 result = $"Bad value for {physicalMoneyInCurrency._Currency.ToString()}";
//                             }
//                         }
//                             break;
//                         case Currency.EUR:
//                         {
//                             if (physicalMoneyInCurrency._Value !=
//                                 (PhysicalMoney_txt / EUR_currencyRate))
//                             {
//                                 result = $"Bad value for {physicalMoneyInCurrency._Currency.ToString()}";
//                             }
//                         }
//                             break;
//                         case Currency.GBP:
//                         {
//                             if (physicalMoneyInCurrency._Value !=
//                                 (PhysicalMoney_txt / GBP_currencyRate))
//                             {
//                                 result = $"Bad value for {physicalMoneyInCurrency._Currency.ToString()}";
//                             }
//                         }
//                             break;
//                         default:
//                             throw new ArgumentOutOfRangeException();
//                     }
//                 }
//             }
//
//             //assert
//             Assert.AreEqual(expected: expected, actual: result);
//         }
//
//         [TestCase(1.0, Currency.PLN, "OK"),
//          TestCase(3.5, Currency.USD, "OK"),
//          TestCase(4.1, Currency.EUR, "OK"),
//          TestCase(5.2, Currency.GBP, "OK"),
//          TestCase(0.0, Currency.USD, "!!! Zła Wartość Współczynnika Walutowego !!!"),
//          TestCase(-1.5, Currency.USD, "!!! Zła Wartość Współczynnika Walutowego !!!"),
//          Order(0)]
//         public void MockPhysicalMoneyRepository_When_Get_In_Currency(
//             decimal currencyRate, Currency currency, string expected)
//         {
//             string result = "OK";
//             PhysicalMoneyVAL physicalMoneyInCurrency = null;
//
//             //arrange
//             MockPhysicalMoneyRepository mockPhysicalMoneyRepository =
//                 new MockPhysicalMoneyRepository(
//                     cashDispenserLibraryTestSettings._SystemSettings);
//
//             //act
//             //Try get in currency form file
//             try
//             {
//                 physicalMoneyInCurrency =
//                     mockPhysicalMoneyRepository.GetInCurrency(
//                         currencyRate, currency);
//             }
//             catch (MockPhysicalMoneyRepository_Exception mpmr_e)
//             {
//                 result = mpmr_e.What();
//             }
//             catch (Exception ex)
//             {
//                 result = "!!! Issue with open file !!!";
//             }
//
//             //Check currency
//             if (result.Equals("OK"))
//             {
//                 if (physicalMoneyInCurrency._Currency != currency)
//                 {
//                     result = $"Bad currency for {currency.ToString()}";
//                 }
//             }
//
//             if (result.Equals("OK"))
//             {
//                 //Check value
//                 if ((physicalMoneyInCurrency._Value)
//                     != (PhysicalMoney_txt / currencyRate))
//                 {
//                     result = $"Bad value for {currency.ToString()}";
//                 }
//             }
//
//             //assert
//             Assert.AreEqual(expected: expected, actual: result);
//         }
//
//         [TestCase(4.4, 386.98,
//              Currency.USD, "OK"),
//          TestCase(5.6, 456.72,
//              Currency.GBP, "OK"),
//          TestCase(0.0, 300.90,
//              Currency.GBP, "!!! Zła Wartość Współczynnika Walutowego !!!"),
//          Order(1)]
//         public void MockPhysicalMoneyRepository_When_Update_In_Currency(
//             decimal currencyRate, decimal value,
//             Currency currency, string expected)
//         {
//             string result = "OK";
//
//             //arrange
//             MockPhysicalMoneyRepository mockPhysicalMoneyRepository =
//                 new MockPhysicalMoneyRepository(
//                     cashDispenserLibraryTestSettings._SystemSettings);
//
//             PhysicalMoneyVAL getPhysicalMoneyInCurrency = null;
//
//             //act
//             //Update physical money state
//             try
//             {
//                 mockPhysicalMoneyRepository.UpdateInCurrency(
//                     currencyRate: currencyRate, new PhysicalMoneyVAL(
//                         value: value, currency: currency));
//             }
//             catch (PhysicalMoneyVAL_Exception pmv_e)
//             {
//                 result = pmv_e.What();
//             }
//             catch (MockPhysicalMoneyRepository_Exception mpmr_e)
//             {
//                 result = mpmr_e.What();
//             }
//             catch (Exception ex)
//             {
//                 result = "!!! Issue with open file !!!";
//             }
//
//             //Get update's physical money
//             try
//             {
//                 getPhysicalMoneyInCurrency = mockPhysicalMoneyRepository.GetInCurrency(
//                     currencyRate: currencyRate, currency: currency);
//             }
//             catch (MockPhysicalMoneyRepository_Exception mpmr_e)
//             {
//                 result = mpmr_e.What();
//             }
//             catch (Exception e)
//             {
//                 Console.WriteLine(e);
//                 throw;
//             }
//
//             //Check value and currency
//             if (result.Equals("OK"))
//             {
//                 if (getPhysicalMoneyInCurrency._Value != value)
//                 {
//                     result = "!!! Bad value !!!";
//                 }
//
//                 if (getPhysicalMoneyInCurrency._Currency != currency)
//                 {
//                     result = "!!! Bad currency !!!";
//                 }
//             }
//
//             //assert
//             Assert.AreEqual(expected: expected, actual: result);
//         }
//     }
// }

