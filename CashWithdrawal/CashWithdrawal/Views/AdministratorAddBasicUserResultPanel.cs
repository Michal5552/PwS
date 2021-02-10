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
    public partial class AdministratorAddBasicUserResultPanel : Form
    {
        public AdministratorAddBasicUserResultPanel()
        {
            InitializeComponent();
        }

        private void ExitToAdministratorManageBasicUsersButton_Click(object sender, EventArgs e)
        {
            // Safe close
            this.Dispose();
        }
    }
}
