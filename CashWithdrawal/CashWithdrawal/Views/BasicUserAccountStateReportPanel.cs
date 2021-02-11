using cashDispenserLibrary.Data;
using CashWithdrawal.ViewModels;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace CashWithdrawal.Views
{
    public partial class BasicUserAccountStateReportPanel : Form
    {
        public BasicUserAccountStateReportPanel(
            BasicUserAccountStateReportPanelVM basicUserAccountStateReportPanelVM)
        {
            InitializeComponent();

            // Show date information
            this.DateValueLabel.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // Show currency information
            switch (basicUserAccountStateReportPanelVM.currency)
            {
                case Currency.PLN:
                    {
                        this.CurrencyValueLabel.Text = "Polski Złoty";
                    }
                    break;
                case Currency.USD:
                    {
                        this.CurrencyValueLabel.Text = "Dolar Amerykański";
                    }
                    break;
                case Currency.EUR:
                    {
                        this.CurrencyValueLabel.Text = "Euro";
                    }
                    break;
                case Currency.GBP:
                    {
                        this.CurrencyValueLabel.Text = "Funt Brytyjski";
                    }
                    break;
            }

            // Show account state information
            this.AccountStateValueLabel.Text = String.Format("{0:0.00}",
                basicUserAccountStateReportPanelVM.accountState)
                .ToString(new CultureInfo("en-US"));
        }

        private void ExitToBasicUserAccountStatePanel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
