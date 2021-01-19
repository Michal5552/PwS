using System;
using System.Collections.Generic;
using System.Linq;
using cashDispenserLibrary.Data.Exceptions;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.MockPhysicalMoneyRepository;

// ReSharper disable RedundantBoolCompare

namespace cashDispenserLibrary.Data
{
    public class BankAccount
    {
        public MoneyVAL state;


        public BankAccount(MoneyVAL state)
        {
            //Validate currency type
            if (state._Currency != Currency.PLN)
            {
                throw new BankAccount_Exception(
                    BankAccount_ExceptionType.BadCurrencyType);
            }

            this.state = state;
        }

        public IEnumerable<MoneyVAL> ShowState(
            Dictionary<Currency, decimal> currencyRates)
        {
            var responseMoneyVAL = new List<MoneyVAL>();


            //Validate currency Rates
            if (currencyRates.Any((
                    currencyRate)
                => (currencyRate.Value <= 0.0M)))
            {
                throw new BankAccount_Exception(
                    BankAccount_ExceptionType.BadCurrencyRate);
            }

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
                        value: (state._Value / currencyRate.Value),
                        currency: currencyRate.Key));
                }
            }

            return responseMoneyVAL;
        }

        public MoneyVAL TakeOutMoney(
            decimal currencyRate, MoneyVAL money, BasicUser user)
        {
            //Validate currency rate
            if (currencyRate <= 0.0M)
            {
                throw new BankAccount_Exception(
                    BankAccount_ExceptionType.BadCurrencyRate);
            }

            //Core currency case
            if (money._Currency == Currency.PLN)
            {
                //Take out money from account
                if (money._Value <= state._Value)
                {
                    //Arrange physical money database connection
                    MockPhysicalMoneyRepository mockPhysicalMoneyRepository =
                        new MockPhysicalMoneyRepository(
                            SystemSettings._PlatformType);

                    //Update bank account state
                    state.ChangeMoney(new MoneyVAL(
                        value: (state._Value - money._Value), currency: Currency.PLN));

                    //Update physical money state
                    PhysicalMoneyVAL mockPhysicalMoney =
                        mockPhysicalMoneyRepository.GetInCurrency(
                            currencyRate: currencyRate, currency: Currency.PLN);

                    mockPhysicalMoneyRepository.UpdateInCurrency(
                        currencyRate: currencyRate, new PhysicalMoneyVAL(
                            value: (mockPhysicalMoney._Value - money._Value),
                            currency: Currency.PLN));

                    // TODO Update Basic user account state

                    //Take out money
                    return money;
                }
                //To little money to take out money case
                else
                {
                    throw new BankAccount_Exception(
                        BankAccount_ExceptionType.TooLittleMoney);
                }
            }
            //Others currency case
            else
            {
                //Take out money from account
                if (money._Value <= (state._Value / currencyRate))
                {
                    //Arrange physical money database connection
                    MockPhysicalMoneyRepository mockPhysicalMoneyRepository =
                        new MockPhysicalMoneyRepository(SystemSettings._PlatformType);

                    //Update bank account state
                    state.ChangeMoney(new MoneyVAL(
                        value: (state._Value - (money._Value * currencyRate)),
                        currency: Currency.PLN));

                    //Update physical money state
                    PhysicalMoneyVAL mockPhysicalMoney =
                        mockPhysicalMoneyRepository.GetInCurrency(
                            currencyRate: currencyRate, currency: money._Currency);

                    mockPhysicalMoneyRepository.UpdateInCurrency(
                        currencyRate: currencyRate, new PhysicalMoneyVAL(
                            value: (mockPhysicalMoney._Value - money._Value),
                            currency: money._Currency));

                    // TODO Update Basic user account state

                    //Take out money
                    return money;
                }
                //To little money to take out money case
                else
                {
                    throw new BankAccount_Exception(
                        BankAccount_ExceptionType.TooLittleMoney);
                }
            }
        }

        public void AddMoney(
            decimal currencyRate, MoneyVAL money, BasicUser user)
        {
            //Validate currency rate
            if (currencyRate <= 0.0M)
            {
                throw new BankAccount_Exception(
                    BankAccount_ExceptionType.BadCurrencyRate);
            }

            //Add money to account in core currency case
            if (money._Currency == Currency.PLN)
            {
                //Arrange physical money database connection
                MockPhysicalMoneyRepository mockPhysicalMoneyRepository =
                    new MockPhysicalMoneyRepository(
                        SystemSettings._PlatformType);

                //Update bank account state
                state.ChangeMoney(moneyVAL: new MoneyVAL(
                    value: (state._Value + money._Value),
                    currency: Currency.PLN));

                //Update physical money state
                PhysicalMoneyVAL mockPhysicalMoney =
                    mockPhysicalMoneyRepository.GetInCurrency(
                        currencyRate: currencyRate, currency: Currency.PLN);

                mockPhysicalMoneyRepository.UpdateInCurrency(
                    currencyRate: currencyRate, new PhysicalMoneyVAL(
                        value: (mockPhysicalMoney._Value + money._Value),
                        currency: Currency.PLN));

                // TODO Update Basic user account state
            }
            //Others currency case
            else
            {
                //Arrange physical money database connection
                MockPhysicalMoneyRepository mockPhysicalMoneyRepository =
                    new MockPhysicalMoneyRepository(
                        SystemSettings._PlatformType);

                //Update bank account state
                state.ChangeMoney(moneyVAL: new MoneyVAL(
                    value: (state._Value + (money._Value * currencyRate)),
                    currency: Currency.PLN));

                //Update physical money state
                PhysicalMoneyVAL mockPhysicalMoney =
                    mockPhysicalMoneyRepository.GetInCurrency(
                        currencyRate: currencyRate, currency: money._Currency);

                mockPhysicalMoneyRepository.UpdateInCurrency(
                    currencyRate: currencyRate, new PhysicalMoneyVAL(
                        value: (mockPhysicalMoney._Value + money._Value),
                        currency: money._Currency));

                // TODO Update Basic user account state
            }
        }
    }
}