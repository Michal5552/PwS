using System;

namespace cashDispenserLibrary.Model.MockAdministratorsRepository.Exceptions
{
    public class MockAdministratorsRepository_Exception : Exception
    {
        public MockAdministratorsRepository_ExceptionType
            _ExceptionType { get; private set; }

        public MockAdministratorsRepository_Exception(
            MockAdministratorsRepository_ExceptionType exceptionType) =>
            _ExceptionType = exceptionType;

        public string What()
        {
            switch (_ExceptionType)
            {
                case MockAdministratorsRepository_ExceptionType.EmptyFile:
                {
                    return "!!! Nie Istnieje Żaden Administrator W Bazie Danych !!!";
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}