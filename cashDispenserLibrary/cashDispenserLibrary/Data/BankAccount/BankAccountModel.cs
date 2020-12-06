namespace cashDispenserLibrary.Data
{
    public class BankAccountModel
    {
        public string _ReportData { get; private set; }
        public MoneyVAL _Money { get; private set; }


        public BankAccountModel(string reportData, MoneyVAL money)
        {
            this._ReportData = reportData;
            this._Money = money;
        }
    }
}