using System;
using System.IO;

namespace Cash_dispenser.Properties.NameVAL.Exceptions
{
    public class NameVAL_Exception : Exception
    {
        public NameVAL_ExceptionType _NameVAL_ExceptionType { get; private set; }

        public NameVAL_Exception(NameVAL_ExceptionType nameVAL_ExceptionType) =>
            _NameVAL_ExceptionType = nameVAL_ExceptionType;

        public string What()
        {
            switch (_NameVAL_ExceptionType)
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