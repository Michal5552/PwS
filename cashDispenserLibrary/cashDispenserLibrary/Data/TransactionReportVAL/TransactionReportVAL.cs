using System;
using cashDispenserLibrary.Data.Exceptions;

namespace cashDispenserLibrary.Data
{
    public class TransactionReportVAL
    {
        private readonly TransactionReportType transactionReportType;
        private readonly Currency currency;
        private readonly decimal remainingBalance;
        private readonly decimal value;
        private readonly DateTime date;

        public TransactionReportVAL(
            TransactionReportType transactionReportType, Currency currency,
            decimal remainingBalance, decimal value, DateTime date)
        {
            //Check remaining balance's correctness
            if (remainingBalance < 0.0M)
            {
                throw new TransactionReportVAL_Exception(
                    TransactionReportVAL_ExceptionType.BadRemainingBalance);
            }

            //Check value's correctness
            if (value < 0.0M)
            {
                throw new TransactionReportVAL_Exception(
                    TransactionReportVAL_ExceptionType.BadValue);
            }

            //Set properties
            this.transactionReportType = transactionReportType;
            this.currency = currency;
            this.remainingBalance = remainingBalance;
            this.value = value;
            this.date = date;
        }

        public string PrintReport()
        {
            switch (transactionReportType)
            {
                case TransactionReportType.TakeOutMoney:
                {
                    string response = "                ### Wypłata ###\n\n" +
                                      $"     Data Operacji: {date}\n";

                    switch (currency)
                    {
                        case Currency.PLN:
                        {
                            response += $"   Kwota Operacji: {value}zł\n" +
                                        $"Saldo Po Operacji: {remainingBalance}zł";
                        }
                            break;
                        case Currency.USD:
                        {
                            response += $"   Kwota Operacji: {value}$\n" +
                                        $"Saldo Po Operacji: {remainingBalance}$";
                        }
                            break;
                        case Currency.EUR:
                        {
                            response += $"   Kwota Operacji: {value}€\n" +
                                        $"Saldo Po Operacji: {remainingBalance}€";
                        }
                            break;
                        case Currency.GBP:
                        {
                            response += $"   Kwota Operacji: {value}£\n" +
                                        $"Saldo Po Operacji: {remainingBalance}£";
                        }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    return response;
                }
                    break;
                case TransactionReportType.AddMoney:
                {
                    string response = "                ### Wpłata ###\n\n" +
                                      $"     Data Operacji: {date}\n";

                    switch (currency)
                    {
                        case Currency.PLN:
                        {
                            response += $"   Kwota Operacji: {value}zł\n" +
                                        $"Saldo Po Operacji: {remainingBalance}zł";
                        }
                            break;
                        case Currency.USD:
                        {
                            response += $"   Kwota Operacji: {value}$\n" +
                                        $"Saldo Po Operacji: {remainingBalance}$";
                        }
                            break;
                        case Currency.EUR:
                        {
                            response += $"   Kwota Operacji: {value}€\n" +
                                        $"Saldo Po Operacji: {remainingBalance}€";
                        }
                            break;
                        case Currency.GBP:
                        {
                            response += $"   Kwota Operacji: {value}£\n" +
                                        $"Saldo Po Operacji: {remainingBalance}£";
                        }
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    return response;
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}