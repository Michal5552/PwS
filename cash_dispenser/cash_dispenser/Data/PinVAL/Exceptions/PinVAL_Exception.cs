using System;

namespace Cash_dispenser.Data.PinVAL.Exceptions
{
    public class PinVAL_Exception : Exception
    {
        public PinVAL_ExceptionType _PinVAL_ExceptionType { get; private set; }

        public PinVAL_Exception(PinVAL_ExceptionType pinVAL_ExceptionType) =>
            _PinVAL_ExceptionType = pinVAL_ExceptionType;
        
        // TODO write what method
    }
}