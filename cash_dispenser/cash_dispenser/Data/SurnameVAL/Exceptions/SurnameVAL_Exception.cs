using System;

namespace Cash_dispenser.Properties.SurnameVAL.Exceptions
{
    public class SurnameVAL_Exception : Exception
    {
        public SurnameVAL_ExceptionType _SurnameVAL_ExceptionType { get; private set; }

        public SurnameVAL_Exception(SurnameVAL_ExceptionType surnameVAL_ExceptionType)
            => _SurnameVAL_ExceptionType = surnameVAL_ExceptionType;

        public string What()
        {
            switch (_SurnameVAL_ExceptionType)
            {
                case SurnameVAL_ExceptionType.BadSurname:
                {
                    return "!!! Niepoprawny zapis nazwiska !!!";
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}