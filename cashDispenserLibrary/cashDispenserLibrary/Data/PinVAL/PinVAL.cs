using System.Linq;
using cashDispenserLibrary.Data.Exceptions;

namespace cashDispenserLibrary.Data
{
    public class PinVAL
    {
        public string _Value { get; private set; }

        public PinVAL(string value)
        {
            //Search any letter
            if (value.Any((value_character) =>
                ((value_character < '0') || (value_character > '9'))
            ))
            {
                //Letter was find
                throw new PinVAL_Exception(PinVAL_ExceptionType.LetterInPin);
            }

            //Check pin's length
            if ((value.Length != 4) && (value.Length != 6))
            {
                throw new PinVAL_Exception(PinVAL_ExceptionType.BadPinLength);
            }

            //Set value
            _Value = value;
        }

        public void ChangePin(PinVAL pinVAL) =>
            _Value = pinVAL._Value;
    }
}