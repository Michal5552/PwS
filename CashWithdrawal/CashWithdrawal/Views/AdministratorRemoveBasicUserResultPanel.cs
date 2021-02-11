using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashWithdrawal.ViewModels
{
    public partial class AdministratorRemoveBasicUserResultPanel : Form
    {
        public AdministratorRemoveBasicUserResultPanel()
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
