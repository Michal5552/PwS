namespace cashDispenserLibrary.Data
{
    public class BasicUser : User
    {
        // TODO implement Bank Account
        public BasicUser(int id, PinVAL pin, NameVAL name, SurnameVAL surname)
            : base(id: id, pin: pin, name: name, surname: surname)
        {
        }
    }
}