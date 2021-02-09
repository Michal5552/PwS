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
    public partial class BasicUserAddMoneyReportPanel : Form
    {
        public BasicUserAddMoneyReportPanel(
            BasicUserAddMoneyReportPanelVM basicUserAddMoneyReportPanelVM)
        {
            InitializeComponent();

            // Show date information
            this.DateValueLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Show currency information
            this.CurrencyValueLabel.Text = "Polski Złoty";

            // Show account state information
            this.AccountStateValueLabel.Text =
                String.Format("{0:0.00}", basicUserAddMoneyReportPanelVM.accountState)
                .ToString(new CultureInfo("en-US"));

            // Show add money information
            this.AddMoneyValueLabel.Text =
                String.Format("{0:0.00}", basicUserAddMoneyReportPanelVM.addMoneyValue)
                .ToString(new CultureInfo("en-US"));
        }

        private void ExitToBasicUserAddMoneyPanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
