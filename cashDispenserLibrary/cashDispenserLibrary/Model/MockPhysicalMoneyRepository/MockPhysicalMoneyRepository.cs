using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using cashDispenserLibrary.Data;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;

namespace cashDispenserLibrary.Model.MockPhysicalMoneyRepository
{
    public class MockPhysicalMoneyRepository
    {
        public PlatformType _PlatformType { get; private set; }

        public MockPhysicalMoneyRepository(PlatformType platformType) =>
            _PlatformType = platformType;

        public IEnumerable<PhysicalMoneyVAL> GetAllCurrency(
            Dictionary<Currency, decimal> currencyRates)
        {
            var responsePhysicalMoneyVAL = new List<PhysicalMoneyVAL>();
            string[] physicalMoneyData = null;


            //Read physical money state
            using (StreamReader sr = new StreamReader(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\PhysicalMoney.txt"
                    : "cashDispenserDatabase/PhysicalMoney.txt"))
            {
                physicalMoneyData = sr.ReadLine().Split(';');
            }

            //Fill response collection
            foreach (var currencyRate in currencyRates)
            {
                //Core currency case
                if (currencyRate.Key == Currency.PLN)
                {
                    responsePhysicalMoneyVAL.Add(new PhysicalMoneyVAL(
                        value: decimal.Parse(physicalMoneyData[0],
                            CultureInfo.InvariantCulture),
                        currency: Currency.PLN));
                }
                //Others case
                else
                {
                    responsePhysicalMoneyVAL.Add(new PhysicalMoneyVAL(
                        value: (decimal.Parse(physicalMoneyData[0],
                            CultureInfo.InvariantCulture) / currencyRate.Value),
                        currency: currencyRate.Key));
                }
            }

            //Return got physical money in all currency
            return responsePhysicalMoneyVAL;
        }

        public PhysicalMoneyVAL GetInCurrency(
            decimal currencyRate, Currency currency)
        {
            string[] physicalMoneyData = null;

            //Validate currency rate
            if (currencyRate <= 0.0M)
            {
                throw new MockPhysicalMoneyRepository_Exception(
                    MockPhysicalMoneyRepository_ExceptionType.BadCurrencyRate);
            }

            //Read physical money state
            using (StreamReader sr = new StreamReader(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\PhysicalMoney.txt"
                    : "cashDispenserDatabase/PhysicalMoney.txt"))
            {
                physicalMoneyData = sr.ReadLine().Split(';');
            }

            //Return got physical money in respectively currency
            return new PhysicalMoneyVAL(
                value: (decimal.Parse(physicalMoneyData[0],
                    CultureInfo.InvariantCulture) / currencyRate),
                currency: currency);
        }

        public void UpdateInCurrency(
            decimal currencyRate, PhysicalMoneyVAL physicalMoneyVAL)
        {
            //Validate currency rate
            if (currencyRate <= 0.0M)
            {
                throw new MockPhysicalMoneyRepository_Exception(
                    MockPhysicalMoneyRepository_ExceptionType.BadCurrencyRate);
            }

            //Update physical money state
            using (StreamWriter sw = new StreamWriter(
                (_PlatformType == PlatformType.Windows)
                    ? "cashDispenserDatabase\\PhysicalMoney.txt"
                    : "cashDispenserDatabase/PhysicalMoney.txt", false))
            {
                //Check currency
                if (physicalMoneyVAL._Currency == Currency.PLN)
                {
                    sw.WriteLine($"{physicalMoneyVAL._Value};{Currency.PLN}");
                }
                //Others case
                else
                {
                    sw.WriteLine(
                        $"{(physicalMoneyVAL._Value * currencyRate).ToString(new CultureInfo("en-US"))};{(int) Currency.PLN}");
                }
            }
        }
    }
}