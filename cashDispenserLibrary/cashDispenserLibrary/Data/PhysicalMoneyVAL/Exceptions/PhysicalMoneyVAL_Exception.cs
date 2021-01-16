using System;
using System.IO;

namespace cashDispenserLibrary.Model.PhysicalMoneyVAL.Exceptions
{
    public class PhysicalMoneyVAL_Exception : Exception
    {
        public PhysicalMoneyVAL_ExceptionType _ExceptionType { get; private set; }

        public PhysicalMoneyVAL_Exception(PhysicalMoneyVAL_ExceptionType exceptionType) =>
            _ExceptionType = exceptionType;

        public string What()
        {
            switch (_ExceptionType)
            {
                case PhysicalMoneyVAL_ExceptionType.BadValue:
                {
                    return "!!! Zła Wartość Wprowadzanej Kwoty Fizycznych Pieniędzy !!!";
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}