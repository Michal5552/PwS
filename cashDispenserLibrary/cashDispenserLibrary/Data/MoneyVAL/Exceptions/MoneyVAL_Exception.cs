using System;
#pragma warning disable 162

namespace cashDispenserLibrary.Data.Exceptions
{
    public class MoneyVAL_Exception : Exception
    {
        public MoneyVAL_ExceptionType _ExceptionType { get; private set; }

        public MoneyVAL_Exception(MoneyVAL_ExceptionType exceptionType) =>
            _ExceptionType = exceptionType;

        public string What()
        {
            switch (_ExceptionType)
            {
                case MoneyVAL_ExceptionType.BadMoneyValue:
                {
                    return "!!! Niepoprawny zapis kwoty !!!";
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}