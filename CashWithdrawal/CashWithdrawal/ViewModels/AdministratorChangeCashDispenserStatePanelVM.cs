using CashWithdrawal.Views;

namespace CashWithdrawal.ViewModels
{
    public class AdministratorChangeCashDispenserStatePanelVM
    {
        public LoginPanel loginPanel { get; set; }
        public AdministratorPanel AdministratorPanel { get; set; }
        public AdministratorCashDispenserStatePanel
            administratorCashDispenserStatePanel
        { get; set; }
        public decimal cashDispenserStateInPlnCurrency { get; set; }
    }
}
