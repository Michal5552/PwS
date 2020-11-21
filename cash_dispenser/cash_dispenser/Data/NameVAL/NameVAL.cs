using Cash_dispenser.Properties.NameVAL.Exceptions;

namespace Cash_dispenser.Properties.NameVAL
{
    public class NameVAL
    {
        public string _Value { get; private set; }

        public NameVAL(string value)
        {
            //Check name's value correctness
            if (value.Length == 0)
            {
                throw new NameVAL_Exception(NameVAL_ExceptionType.BadNameValue);
            }

            //Set value
            _Value = value;
        }

        public void ChangeName(NameVAL nameVAL) =>
            _Value = nameVAL._Value;
    }
}