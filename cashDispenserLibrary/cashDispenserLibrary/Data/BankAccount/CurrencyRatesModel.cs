namespace cashDispenserLibrary.Data
{
    public class CurrencyRatesModel
    {
        public decimal _PLN { get; private set; }
        public decimal _USD { get; private set; }
        public decimal _EUR { get; private set; }
        public decimal _GBP { get; private set; }


        public CurrencyRatesModel(decimal pln, decimal usd, decimal eur, decimal gbp)
        {
            this._PLN = pln;
            this._USD = usd;
            this._EUR = eur;
            this._GBP = gbp;
        }
    }
}