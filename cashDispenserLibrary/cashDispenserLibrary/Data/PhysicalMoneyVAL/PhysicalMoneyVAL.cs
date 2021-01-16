using cashDispenserLibrary.Data;
using cashDispenserLibrary.Model.PhysicalMoneyVAL.Exceptions;

namespace cashDispenserLibrary.Model.PhysicalMoneyVAL
{
    public class PhysicalMoneyVAL
    {
        public decimal _Value { get; private set; }
        public Currency _Currency { get; private set; }

        public PhysicalMoneyVAL(decimal value, Currency currency)
        {
            //Examine value correctness
            if (value >= 0.0M)
            {
                _Value = value;
                _Currency = currency;
            }
            else
            {
                throw new PhysicalMoneyVAL_Exception(
                    PhysicalMoneyVAL_ExceptionType.BadValue);
            }
        }

        public void ChangePhysicalMoney(PhysicalMoneyVAL physicalMoneyVAL)
        {
            _Value = physicalMoneyVAL._Value;
            _Currency = physicalMoneyVAL._Currency;
        }
    }
}