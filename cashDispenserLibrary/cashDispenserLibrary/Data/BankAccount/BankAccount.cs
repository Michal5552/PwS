using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using cashDispenserLibrary.Data.Exceptions;

// ReSharper disable RedundantBoolCompare

namespace cashDispenserLibrary.Data
{
    // TODO set try catch clause in MoneyVAL changeMoney
    public class BankAccount
    {
        public MoneyVAL state;


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

        public MoneyVAL TakeOutMoney(decimal currencyRate, MoneyVAL money, BasicUser user)
        {
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
                }

                //Take out money
                return money;
            }
            //Others currency case
            else if (money._Value <= (state._Value * currencyRate))
            {
                //Take out money from account
                state.ChangeMoney(moneyVAL: new MoneyVAL(
                    value: (state._Value - (money._Value * currencyRate)),
                    currency: Currency.PLN));

                // TODO take out money wherewithal dbContext

                //Take out money
                return money;
            }
            //Not enough money in bank account case
            else
            {
                throw new BankAccount_Exception(BankAccount_ExceptionType.TooLittleMoney);
            }
        }

        public void AddMoney(decimal currencyRate, MoneyVAL money, BasicUser user)
        {
            // TODO implement
            //Core currency case
            if (state._Currency == money._Currency)
            {
                //Add money to account
                state.ChangeMoney(moneyVAL: new MoneyVAL(
                    value: (state._Value + money._Value),
                    currency: Currency.PLN));

                // TODO add money wherewithal dbContext
            }
            //Others currency case
            else
            {
                //Add money to account
                state.ChangeMoney(moneyVAL: new MoneyVAL(
                    value: (state._Value + (money._Value * currencyRate)),
                    money._Currency));
                
                // TODO add money wherewithal dbContext
            }
        }
    }
}