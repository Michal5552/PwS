using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

// ReSharper disable RedundantBoolCompare

namespace cashDispenserLibrary.Data
{
    public class BankAccount
    {
        public MoneyVAL state { get; private set; }


        public BankAccount(MoneyVAL state) =>
            this.state = state;

        public IEnumerable<MoneyVAL> ShowState(Dictionary<Currency, decimal> currencyRates)
        {
            var responseMoneyVAL = new List<MoneyVAL>();


            //Fill response collection
            foreach (var currencyRate in currencyRates)
            {
                //Core currency case
                if (currencyRate.Key == Currency.PLN)
                {
                    responseMoneyVAL.Add(new MoneyVAL(
                        value: state._Value, currency: Currency.PLN));
                }
                //Others case
                else
                {
                    responseMoneyVAL.Add(new MoneyVAL(
                        value: (state._Value * currencyRate.Value),
                        currency: currencyRate.Key));
                }
            }

            return responseMoneyVAL;
        }

        public BankAccountModel TakeOutMoney(bool report,
            decimal currencyRate, MoneyVAL money)
        {
            string reportData = "";


            //Check take out money possibility
            //Core currency case
            if (money._Currency == Currency.PLN)
            {
                //Take out money from account
                if (money._Value <= state._Value)
                {
                    state.ChangeMoney(new MoneyVAL(
                        value: (state._Value - money._Value), currency: Currency.PLN));

                    // TODO take out money wherewithal dbContext

                    //Check transaction report case
                    if (report == true)
                    {
                        //Generate transaction report
                        TransactionReportVAL transactionReportVAL =
                            new TransactionReportVAL(
                                transactionReportType: TransactionReportType.TakeOutMoney,
                                currency: Currency.PLN, remainingBalance: state._Value,
                                value: money._Value, date: DateTime.Now);

                        //Return response
                        return new BankAccountModel(
                            reportData: transactionReportVAL.PrintReport(),
                            money: money);
                    }
                    else
                    {
                        //Return response
                        return new BankAccountModel(reportData: "", money: money);
                    }
                }
            }
            //Others case
            else if (money._Value <= (state._Value * currencyRate))
            {
                // TODO implement
            }
            else
            {
                // TODO throw exception
            }

            throw new Exception();
        }

        public void AddMoney(bool report, MoneyVAL money)
        {
            // TODO implement
            throw new Exception();
        }
    }
}