namespace cashDispenserLibrary.Data
{
    public abstract class User
    {
        public int _Id { get; private set; }
        public PinVAL _Pin { get; private set; }
        public NameVAL _Name { get; private set; }
        public SurnameVAL _Surname { get; private set; }

        public User(PinVAL pin, NameVAL name, SurnameVAL surname)
        {
            _Pin = pin;
            _Name = name;
            _Surname = surname;
        }

        public void ChangePin(PinVAL pin) =>
            _Pin = pin;

        public void ChangeName(NameVAL name) =>
            _Name = name;

        public void ChangeSurname(SurnameVAL surname) =>
            _Surname = surname;
    }
}