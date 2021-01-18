// using System;
// using cashDispenserLibrary.Data;
// using cashDispenserLibrary.Data.Exceptions;
// using NUnit.Framework;
//
// namespace cashDispenserTest.DataTests
// {
//     [TestFixture]
//     public class TransactionReportVAL_Test
//     {
//         [TestCase(TransactionReportType.TakeOutMoney,
//              Currency.PLN, 140.96, 30.0,
//              2020, 12, 1, "OK"),
//          TestCase(TransactionReportType.AddMoney,
//              Currency.PLN, 150.56, 50.0,
//              2020, 12, 1, "OK"),
//          TestCase(TransactionReportType.AddMoney,
//              Currency.PLN, 200.50, 20.0,
//              1900, 1, 1, "OK"),
//          TestCase(TransactionReportType.AddMoney,
//              Currency.PLN, -1.0, 30.0,
//              2020, 12, 1,
//              "!!! Saldo Nie Jest Liczbą Dodatnią !!!"),
//          TestCase(TransactionReportType.TakeOutMoney,
//              Currency.PLN, 160.0, -1.0,
//              2020, 12, 1,
//              "!!! Wartość Nie Jest Liczbą Dodatnią !!!")]
//         public void TransactionReportVAL_When_Init_Cases(
//             TransactionReportType transactionReportType, Currency currency,
//             decimal remainingBalance, decimal value,
//             int year, int month, int day, string expected)
//         {
//             string result = "OK";
//
//
//             //arrange
//             TransactionReportVAL transactionReportVAL = null;
//
//             try
//             {
//                 transactionReportVAL =
//                     new TransactionReportVAL(transactionReportType,
//                         currency, remainingBalance, value,
//                         new DateTime(year, month, day));
//             }
//             catch (TransactionReportVAL_Exception t_e)
//             {
//                 result = t_e.What();
//             }
//
//             //act
//
//             //assert
//             Assert.AreEqual(expected: expected, actual: result);
//         }
//
//         [TestCase(TransactionReportType.TakeOutMoney,
//              Currency.PLN, 150.56, 50.0,
//              2020, 12, 1,
//              "                ### Wypłata ###\n\n" +
//              "     Data Operacji: 01.12.2020 00:00:00\n" +
//              "   Kwota Operacji: 50zł\n" +
//              "Saldo Po Operacji: 150,56zł"),
//          TestCase(TransactionReportType.AddMoney,
//              Currency.EUR, 290.76, 100.0,
//              2019, 9, 12,
//              "                ### Wpłata ###\n\n" +
//              "     Data Operacji: 12.09.2019 00:00:00\n" +
//              "   Kwota Operacji: 100€\n" +
//              "Saldo Po Operacji: 290,76€"),
//          TestCase(TransactionReportType.AddMoney,
//              Currency.GBP, 387.24, 150.0,
//              2019, 9, 12,
//              "                ### Wpłata ###\n\n" +
//              "     Data Operacji: 12.09.2019 00:00:00\n" +
//              "   Kwota Operacji: 150£\n" +
//              "Saldo Po Operacji: 387,24£")]
//         public void TransactionReportVAL_When_transaction_Report_Cases(
//             TransactionReportType transactionReportType, Currency currency,
//             decimal remainingBalance, decimal value, int year,
//             int month, int day, string expected)
//         {
//             string result = "OK";
//
//
//             //arrange
//             TransactionReportVAL transactionReportVAL = null;
//
//             try
//             {
//                 transactionReportVAL =
//                     new TransactionReportVAL(transactionReportType,
//                         currency, remainingBalance,
//                         value, new DateTime(year, month, day));
//             }
//             catch (TransactionReportVAL_Exception t_e)
//             {
//                 result = t_e.What();
//             }
//
//             //act
//             if (result.Equals("OK"))
//             {
//                 result = transactionReportVAL.PrintReport();
//             }
//
//             //assert
//             Assert.AreEqual(expected: expected, actual: result);
//         }
//     }
// }