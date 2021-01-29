namespace cashDispenserLibrary.Data
{
    public class Administrator : User
    {
        public Administrator(int id, PinVAL pin, NameVAL name,
            SurnameVAL surname) : base(id, pin, name, surname)
        {
        }
    }
}