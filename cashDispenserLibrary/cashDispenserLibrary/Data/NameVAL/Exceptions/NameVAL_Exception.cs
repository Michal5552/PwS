using System;
#pragma warning disable 162

namespace cashDispenserLibrary.Data.Exceptions
{
    public class NameVAL_Exception : Exception
    {
        public NameVAL_ExceptionType _ExceptionType { get; private set; }

        public NameVAL_Exception(NameVAL_ExceptionType nameVAL_ExceptionType) =>
            _ExceptionType = nameVAL_ExceptionType;

        public string What()
        {
            switch (_ExceptionType)
            {
                case NameVAL_ExceptionType.BadNameValue:
                {
                    return "!!! Niepoprawny zapis imienia !!!";
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}