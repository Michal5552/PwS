namespace cashDispenserLibrary.Data
{
    public class BasicUser : User
    {
        public BankAccount _BankAccount { get; private set; }

        public BasicUser(int id, PinVAL pin, NameVAL name,
            SurnameVAL surname, BankAccount bankAccount)
            : base(id: id, pin: pin, name: name, surname: surname)
        {
            _BankAccount = bankAccount;
        }
    }
}