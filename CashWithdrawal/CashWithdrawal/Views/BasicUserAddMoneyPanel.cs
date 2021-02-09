using cashDispenserLibrary.Data;
using cashDispenserLibrary.Data.Exceptions;
using CashWithdrawal.ViewModels;
using System.Globalization;
using System.Windows.Forms;

namespace CashWithdrawal.Views
{
    public partial class BasicUserAddMoneyPanel : Form
    {
        private LoginPanel loginPanel;
        private BasicUserPanel basicUserPanel;
        private BasicUser basicUser;

        public BasicUserAddMoneyPanel(BasicUserAddMoneyPanelVM basicUserAddMoneyPanelVM)
        {
            InitializeComponent();

            // Set login panel information
            this.loginPanel = basicUserAddMoneyPanelVM.loginPanel;

            // Set basic user panel information
            this.basicUserPanel = basicUserAddMoneyPanelVM.basicUserPanel;

            // Set basic user information
            this.basicUser = basicUserAddMoneyPanelVM.basicUser;

            // Set exchange rates information
            this.PLN_ExchangeRateValueLabel.Text =
                CashWithdrawalProperties.exchangeRates.PLN_exchangeRate.ToString(
                    new CultureInfo("en-US"));

            this.USD_ExchangeRateValueLabel.Text =
                CashWithdrawalProperties.exchangeRates.USD_exchangeRate.ToString(
                    new CultureInfo("en-US"));

            this.EUR_ExchangeRateValueLabel.Text =
                CashWithdrawalProperties.exchangeRates.EUR_exchangeRate.ToString(
                    new CultureInfo("en-US"));

            this.GBP_ExchangeRateValueLabel.Text =
                CashWithdrawalProperties.exchangeRates.GBP_exchangeRate.ToString(
                    new CultureInfo("en-US"));

            // Set currency combobox
            this.CurrencyComboBox.Items.Add("Polski Złoty");
            this.CurrencyComboBox.Items.Add("Dolar Amerykański");
            this.CurrencyComboBox.Items.Add("Euro");
            this.CurrencyComboBox.Items.Add("Funt Brytyjski");

            this.CurrencyComboBox.SelectedIndex = 0;

            // Set add money value combobox
            this.AddMoneyValueComboBox.Items.Add("50");
            this.AddMoneyValueComboBox.Items.Add("100");
            this.AddMoneyValueComboBox.Items.Add("200");
            this.AddMoneyValueComboBox.Items.Add("500");
            this.AddMoneyValueComboBox.Items.Add("1 000");

            this.AddMoneyValueComboBox.SelectedIndex = 0;

            // Set add money report check box
            this.AddMoneyReportCheckBox.Checked = false;
        }
        private void BasicUserAddMoneyPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Safe close
            basicUserPanel.Dispose();
            loginPanel.Close();
        }

        private void ExitToBasicUserPanelButton_Click(object sender, System.EventArgs e)
        {
            // redirect to basic user panel
            this.basicUserPanel.Show();
            this.Dispose();
        }

        private void AddMoneyButton_Click(object sender, System.EventArgs e)
        {
            // Add money process
            Currency exchangeRateCurrency = Currency.PLN;
            decimal exchangeRate = 0.0M;
            decimal addMoneyValue = 0.0M;


            // Get information about currency
            switch (this.CurrencyComboBox.SelectedIndex)
            {
                case 0:
                    {
                        exchangeRateCurrency = Currency.PLN;
                        exchangeRate =
                            CashWithdrawalProperties.exchangeRates.PLN_exchangeRate;
                    }
                    break;
                case 1:
                    {
                        exchangeRateCurrency = Currency.USD;
                        exchangeRate =
                            CashWithdrawalProperties.exchangeRates.USD_exchangeRate;
                    }
                    break;
                case 2:
                    {
                        exchangeRateCurrency = Currency.EUR;
                        exchangeRate =
                            CashWithdrawalProperties.exchangeRates.EUR_exchangeRate;
                    }
                    break;
                case 3:
                    {
                        exchangeRateCurrency = Currency.GBP;
                        exchangeRate =
                            CashWithdrawalProperties.exchangeRates.GBP_exchangeRate;
                    }
                    break;
            }

            // Get information about add money value
            switch (this.AddMoneyValueComboBox.SelectedIndex)
            {
                case 0:
                    {
                        addMoneyValue = 50.0M;
                    }
                    break;
                case 1:
                    {
                        addMoneyValue = 100.0M;
                    }
                    break;
                case 2:
                    {
                        addMoneyValue = 200.0M;
                    }
                    break;
                case 3:
                    {
                        addMoneyValue = 500.0M;
                    }
                    break;
                case 4:
                    {
                        addMoneyValue = 1000.0M;
                    }
                    break;
            }

            // Add money
            try
            {
                this.basicUser._BankAccount.AddMoney(currencyRate: exchangeRate,
                    money: new MoneyVAL(value: addMoneyValue,
                    currency: exchangeRateCurrency),
                    user: this.basicUser);
            }
            catch (BankAccount_Exception b_e) { }

            // Check report type
            if (AddMoneyReportCheckBox.Checked == false)
            {
                // Redirect to basic user add money execute panel
                BasicUserAddMoneyExecutePanel basicUserAddMoneyExecutePanel =
                    new BasicUserAddMoneyExecutePanel();

                basicUserAddMoneyExecutePanel.ShowDialog();
            }
            else
            {
                // Redirect to basic user add money report panel
                BasicUserAddMoneyReportPanelVM basicUserAddMoneyReportPanelVM =
                    new BasicUserAddMoneyReportPanelVM
                    {
                        accountState = this.basicUser._BankAccount.state._Value,
                        addMoneyValue = (addMoneyValue * exchangeRate)
                    };

                BasicUserAddMoneyReportPanel basicUserAddMoneyReportPanel =
                    new BasicUserAddMoneyReportPanel(basicUserAddMoneyReportPanelVM);

                basicUserAddMoneyReportPanel.ShowDialog();
            }
        }
    }
}
