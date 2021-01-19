using System;
#pragma warning disable 162

namespace cashDispenserLibrary.Data.Exceptions
{
    public class PinVAL_Exception : Exception
    {
        public PinVAL_ExceptionType _ExceptionType { get; private set; }

        public PinVAL_Exception(PinVAL_ExceptionType pinVAL_ExceptionType) =>
            _ExceptionType = pinVAL_ExceptionType;

        public string What()
        {
            switch (_ExceptionType)
            {
                case PinVAL_ExceptionType.LetterInPin:
                {
                    return "!!! W pinie znajduje się niedozwolony znak !!!";
                }
                    break;
                case PinVAL_ExceptionType.BadPinLength:
                {
                    return "!!! Długość Pinu Jest Nie Prawidłowa!!!";
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}