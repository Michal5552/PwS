using cashDispenserLibrary.Data;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;
using CashWithdrawal.Data;
using CashWithdrawal.ViewModels;
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
    public partial class AdministratorUpdateBasicUserResultPanel : Form
    {
        public AdministratorUpdateBasicUserResultPanel()
        {
            InitializeComponent();
        }

        private void ExitToAdministratorManageBasicUsersButton_Click(object sender, EventArgs e)
        {
            // Safe close
            this.Close();
        }
    }
}
