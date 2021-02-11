using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashWithdrawal.Views
{
    public partial class AdministratorChangeCashDispenserStateResultPanel : Form
    {
        public AdministratorChangeCashDispenserStateResultPanel()
        {
            InitializeComponent();
        }

        private void ExitToAdministratorPanel_Click(object sender, EventArgs e)
        {
            // Safe close
            this.Close();
        }
    }
}
