using cashDispenserLibrary.Data;
using CashWithdrawal.Views;

namespace CashWithdrawal.ViewModels
{
    public class AdministratorManageBasicUsersPanelVM
    {
        public LoginPanel loginPanel { get; set; }
        public AdministratorPanel administratorPanel { get; set; }
        public Administrator administrator { get; set; }
    }
}
