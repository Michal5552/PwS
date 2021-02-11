using cashDispenserLibrary.Data;
using CashWithdrawal.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashWithdrawal.ViewModels
{
    public class BasicUserTakeOutMoneyPanelVM
    {
        public LoginPanel loginPanel { get; set; }
        public BasicUserPanel basicUserPanel { get; set; }
        public BasicUser basicUser { get; set; }
    }
}
