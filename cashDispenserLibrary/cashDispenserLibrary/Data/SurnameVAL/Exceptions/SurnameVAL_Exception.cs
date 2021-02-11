using System;
#pragma warning disable 162

namespace cashDispenserLibrary.Data.Exceptions
{
    public class SurnameVAL_Exception : Exception
    {
        public SurnameVAL_ExceptionType _ExceptionType { get; private set; }

        public SurnameVAL_Exception(SurnameVAL_ExceptionType surnameVAL_ExceptionType)
            => _ExceptionType = surnameVAL_ExceptionType;

        public string What()
        {
            switch (_ExceptionType)
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