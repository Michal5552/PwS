using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cashDispenserLibrary.Data;

namespace CashWithdrawal.ViewModels
{
    public class AdministratorPanelVM
    {
        public LoginPanel loginPanel { get; set; }
        public Administrator administrator { get; set; }
    }
}
