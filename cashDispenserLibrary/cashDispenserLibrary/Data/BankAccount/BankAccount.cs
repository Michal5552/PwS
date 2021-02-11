using System.Collections.Generic;
using System.Linq;
using cashDispenserLibrary.Data.Exceptions;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;
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
                    //Arrange bank account database connection
                    MockBasicUsersRepository mockBasicUsersRepository =
                        new MockBasicUsersRepository(
                            platformType: SystemSettings._PlatformType);


                    //Update Basic user account state
                    var basicUser = mockBasicUsersRepository.Get(
                        basicUserId: user._Id);

                    basicUser._BankAccount.state.ChangeMoney(
                        moneyVAL: new MoneyVAL(
                            value: (basicUser._BankAccount.state._Value
                                    - money._Value),
                            currency: Currency.PLN));

                    //Save changes
                    mockBasicUsersRepository.Update(basicUser);

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
                    //Arrange bank account database connection
                    MockBasicUsersRepository mockBasicUsersRepository =
                        new MockBasicUsersRepository(
                            platformType: SystemSettings._PlatformType);


                    //Update Basic user account state
                    var basicUser = mockBasicUsersRepository.Get(
                        basicUserId: user._Id);

                    basicUser._BankAccount.state.ChangeMoney(
                        moneyVAL: new MoneyVAL(
                            value: (basicUser._BankAccount.state._Value
                                    - (money._Value * currencyRate)),
                            currency: Currency.PLN));

                    //Save changes
                    mockBasicUsersRepository.Update(basicUser);

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
                //Arrange bank account database connection
                MockBasicUsersRepository mockBasicUsersRepository =
                    new MockBasicUsersRepository(
                        platformType: SystemSettings._PlatformType);


                //Update Basic user account state
                var basicUser = mockBasicUsersRepository.Get(
                    basicUserId: user._Id);

                basicUser._BankAccount.state.ChangeMoney(
                    moneyVAL: new MoneyVAL(
                        value: (basicUser._BankAccount.state._Value
                                + money._Value),
                        currency: Currency.PLN));

                mockBasicUsersRepository.Update(basicUser);

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
            }
            //Others currency case
            else
            {
                //Arrange bank account database connection
                MockBasicUsersRepository mockBasicUsersRepository =
                    new MockBasicUsersRepository(
                        platformType: SystemSettings._PlatformType);


                //Update Basic user account state
                var basicUser = mockBasicUsersRepository.Get(
                    basicUserId: user._Id);

                basicUser._BankAccount.state.ChangeMoney(
                    moneyVAL: new MoneyVAL(
                        value: (basicUser._BankAccount.state._Value
                                + (money._Value * currencyRate)),
                        currency: Currency.PLN));

                //Save changes
                mockBasicUsersRepository.Update(basicUser);

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
            }
        }
    }
}