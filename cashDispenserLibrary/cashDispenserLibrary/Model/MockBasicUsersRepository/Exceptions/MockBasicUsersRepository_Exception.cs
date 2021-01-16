using System;

namespace cashDispenserLibrary.Model.Exceptions
{
    public class MockBasicUsersRepository_Exception : Exception
    {
        public MockBasicUsersRepository_ExceptionType _ExceptionType { get; private set; }


        public MockBasicUsersRepository_Exception(
            MockBasicUsersRepository_ExceptionType exceptionType) =>
            _ExceptionType = exceptionType;
    }
}