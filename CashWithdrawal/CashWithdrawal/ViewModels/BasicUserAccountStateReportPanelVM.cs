using cashDispenserLibrary.Data;
using CashWithdrawal.Views;

namespace CashWithdrawal.ViewModels
{
    public class BasicUserAccountStateReportPanelVM
    {
        public Currency currency { get; set; }
        public decimal accountState { get; set; }
    }
}
