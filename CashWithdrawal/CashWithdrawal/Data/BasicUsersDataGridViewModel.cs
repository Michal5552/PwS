using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashWithdrawal.Data
{
    public class BasicUsersDataGridViewModel
    {
        public int BasicUserId { get; set; }
        public decimal accountState { get; set; }
        public string pin { get; set; }
        public String name { get; set; }
        public String surname { get; set; }
    }
}
