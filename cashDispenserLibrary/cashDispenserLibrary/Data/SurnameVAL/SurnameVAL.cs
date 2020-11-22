using cashDispenserLibrary.Data.Exceptions;

namespace cashDispenserLibrary.Data
{
    public class SurnameVAL
    {
        public string _Value { get; private set; }

        public SurnameVAL(string value)
        {
            //Check surname's value correctness
            if (value.Length == 0)
            {
                throw new SurnameVAL_Exception(SurnameVAL_ExceptionType.BadSurname);
            }

            //Set value
            _Value = value;
        }

        public void ChangeName(SurnameVAL surnameVAL) =>
            _Value = surnameVAL._Value;
    }
}