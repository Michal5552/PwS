using System;
using System.IO;

namespace cashDispenserLibrary.Model.Exceptions
{
    public class MockBasicUsersRepository_Exception : Exception
    {
        public MockBasicUsersRepository_ExceptionType
            _ExceptionType { get; private set; }


        public MockBasicUsersRepository_Exception(
            MockBasicUsersRepository_ExceptionType exceptionType) =>
            _ExceptionType = exceptionType;

        public string What()
        {
            switch (_ExceptionType)
            {
                case MockBasicUsersRepository_ExceptionType.EmptyFile:
                {
                    return "!!! Nie Istnieje Żaden Użytkownik Podstawowy W Bazie Danych !!!";
                }
                    break;
                case MockBasicUsersRepository_ExceptionType.BasicUserNotExist:
                {
                    return "!!! Użytkownik Nie Istnieje W Bazie !!!";
                }
                    break;
                case MockBasicUsersRepository_ExceptionType.DuplicateBasicUser:
                {
                    return "!!! Użytkownik Już Istnieje W Bazie !!!";
                }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}