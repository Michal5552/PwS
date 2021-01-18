using System;

#pragma warning disable 162

namespace cashDispenserLibrary.Data.Exceptions
{
    public class BankAccount_Exception : Exception
    {
        public BankAccount_ExceptionType _ExceptionType { get; private set; }

        public BankAccount_Exception(BankAccount_ExceptionType exceptionType)
            => _ExceptionType = exceptionType;

        public string What()
        {
            switch (_ExceptionType)
            {
                case BankAccount_ExceptionType.TooLittleMoney:
                {
                    return "!!! Stan Konta Nie Pozwala Na Wypłatę Tej Kwoty !!!";
                }
                    break;
                case BankAccount_ExceptionType.BadCurrencyRate:
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