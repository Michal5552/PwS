using System;
#pragma warning disable 162

namespace cashDispenserLibrary.Data.Exceptions
{
    public class PinVAL_Exception : Exception
    {
        public PinVAL_ExceptionType _PinVAL_ExceptionType { get; private set; }

        public PinVAL_Exception(PinVAL_ExceptionType pinVAL_ExceptionType) =>
            _PinVAL_ExceptionType = pinVAL_ExceptionType;

        public string What()
        {
            switch (_PinVAL_ExceptionType)
            {
                case PinVAL_ExceptionType.LetterInPin:
                {
                    return "!!! W pinie znajduje się niedozwolony znak !!!";
                }
                    break;
                case PinVAL_ExceptionType.ToShortPin:
                {
                    return "!!! Pin składa się z mniej niż 3 cyfr !!!";
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}