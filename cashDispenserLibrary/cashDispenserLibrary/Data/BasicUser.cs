namespace cashDispenserLibrary.Data
{
    public class BasicUser : User
    {
        // TODO implement Bank Account
        public BasicUser(PinVAL pin, NameVAL name, SurnameVAL surname)
            : base(pin: pin, name: name, surname: surname)
        {
        }
    }
}