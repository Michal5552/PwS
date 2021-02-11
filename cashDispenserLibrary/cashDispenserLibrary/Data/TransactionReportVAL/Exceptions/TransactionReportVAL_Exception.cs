using System;
using System.Diagnostics;

#pragma warning disable 162

namespace cashDispenserLibrary.Data.Exceptions
{
    public class TransactionReportVAL_Exception : Exception
    {
        public TransactionReportVAL_ExceptionType _ExceptionType { get; private set; }

        public TransactionReportVAL_Exception(
            TransactionReportVAL_ExceptionType exceptionType) =>
            _ExceptionType = exceptionType;

        public string What()
        {
            switch (_ExceptionType)
            {
                case TransactionReportVAL_ExceptionType.BadRemainingBalance:
                {
                    return "!!! Saldo Nie Jest Liczbą Dodatnią !!!";
                }
                    break;

                case TransactionReportVAL_ExceptionType.BadValue:
                {
                    return "!!! Wartość Nie Jest Liczbą Dodatnią !!!";
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}