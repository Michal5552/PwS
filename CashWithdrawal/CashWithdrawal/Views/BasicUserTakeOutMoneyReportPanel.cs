using CashWithdrawal.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashWithdrawal.Views
{
    public partial class BasicUserTakeOutMoneyReportPanel : Form
    {
        public BasicUserTakeOutMoneyReportPanel(
            BasicUserTakeOutMoneyReportPanelVM basicUserTakeOutMoneyReportPanelVM)
        {
            InitializeComponent();

            // Show date information
            this.DateValueLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Show account state information
            this.AccountStateValueLabel.Text =
                (String.Format("{0:0.00}", basicUserTakeOutMoneyReportPanelVM.accountState)
                .ToString(new CultureInfo("en-US")) + " PLN");

            // Show take out money information
            this.TakeOutMoneyValueLabel.Text =
                (String.Format("{0:0.00}", basicUserTakeOutMoneyReportPanelVM.takeOutMoneyValue)
                .ToString(new CultureInfo("en-US")) + " PLN");
        }

        private void ExitToBasicUserTakeOutMoneyPanel_Click(object sender, EventArgs e)
        {
            // Safe close
            this.Close();
        }
    }
}
