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
    public partial class BasicUserTakeOutMoneyExecutePanel : Form
    {
        public BasicUserTakeOutMoneyExecutePanel(
            BasicUserTakeOutMoneyExecutePanelVM basicUserTakeOutMoneyExecutePanelVM)
        {
            InitializeComponent();

            // Show take out money result
            this.TakeOutMoneyResultLabel.Text =
                basicUserTakeOutMoneyExecutePanelVM.takeOutMoneyResult;
        }

        private void ExitToBasicUserAddMoneyPanel_Click(object sender, EventArgs e)
        {
            // Safe close
            this.Close();
        }
    }
}
