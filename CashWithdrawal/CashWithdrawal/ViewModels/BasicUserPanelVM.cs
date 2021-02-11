using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using cashDispenserLibrary.Data;

namespace CashWithdrawal.ViewModels
{
    public class BasicUserPanelVM
    {
        public LoginPanel loginPanel { get; set; }
        public BasicUser basicUser { get; set; }
    }
}
