using System;
using System.ComponentModel.Design;
using cashDispenserLibrary.Data.TransactionReportVAL.Exceptions;

namespace cashDispenserLibrary.Data.TransactionReportVAL
{
    public class TransactionReportVAL
    {
        public readonly TransactionReportType transactionReportType;
        public readonly decimal value;
        public readonly DateTime date;

        public TransactionReportVAL(
            TransactionReportType transactionReportType,
            decimal value, DateTime date)
        {
            //Check value's correctness
            if (value < 0.0M)
            {
                throw new TransactionReportVAL_Exception(
                    TransactionReportVAL_ExceptionType.BadValue);
            }

            // TODO finish implement
            //Check date correctness
            if (date.Year <= 1900)
            {
                
            }
            this.value = value;
            this.date = date;
            this.transactionReportType = transactionReportType;
        }
    }
}