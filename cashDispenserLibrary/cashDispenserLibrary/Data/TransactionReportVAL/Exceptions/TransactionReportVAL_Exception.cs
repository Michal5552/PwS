using System;

namespace cashDispenserLibrary.Data.TransactionReportVAL.Exceptions
{
    public class TransactionReportVAL_Exception : Exception
    {
        public TransactionReportVAL_ExceptionType _ExceptionType { get; private set; }

        public TransactionReportVAL_Exception(
            TransactionReportVAL_ExceptionType exceptionType) =>
            _ExceptionType = exceptionType;
    }
}