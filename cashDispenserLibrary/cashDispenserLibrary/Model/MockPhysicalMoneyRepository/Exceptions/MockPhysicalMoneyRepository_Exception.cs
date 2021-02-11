using System;

namespace cashDispenserLibrary.Model.Exceptions
{
    public class MockPhysicalMoneyRepository_Exception : Exception
    {
        public MockPhysicalMoneyRepository_ExceptionType _ExceptionType { get; private set; }

        public MockPhysicalMoneyRepository_Exception(
            MockPhysicalMoneyRepository_ExceptionType exceptionType) =>
            _ExceptionType = exceptionType;

        public string What()
        {
            switch (_ExceptionType)
            {
                case MockPhysicalMoneyRepository_ExceptionType.BadCurrencyRate:
                {
                    return "!!! Zła Wartość Współczynnika Walutowego !!!";
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}