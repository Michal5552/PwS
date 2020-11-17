using System.CodeDom;
using System.Linq;
using Cash_dispenser.Data.PinVAL.Exceptions;

namespace Cash_dispenser.Data.PinVAL
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
            if (value.Length < 3)
            {
                throw new PinVAL_Exception(PinVAL_ExceptionType.ToShortPin);
            }
        }
    }
}