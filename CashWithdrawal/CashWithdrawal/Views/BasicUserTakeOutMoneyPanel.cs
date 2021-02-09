using cashDispenserLibrary.Data;
using cashDispenserLibrary.Data.Exceptions;
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
    public partial class BasicUserTakeOutMoneyPanel : Form
    {
        private LoginPanel loginPanel;
        private BasicUserPanel basicUserPanel;
        private BasicUser basicUser;

        public BasicUserTakeOutMoneyPanel(
            BasicUserTakeOutMoneyPanelVM basicUserTakeOutMoneyPanelVM)
        {
            InitializeComponent();

            // Set login panel information
            this.loginPanel = basicUserTakeOutMoneyPanelVM.loginPanel;

            // Set basic user panel information
            this.basicUserPanel = basicUserTakeOutMoneyPanelVM.basicUserPanel;

            // Set basic user information
            this.basicUser = basicUserTakeOutMoneyPanelVM.basicUser;

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
            this.CurrencyComboBox.Items.Add("Dolar");
            this.CurrencyComboBox.Items.Add("Euro");
            this.CurrencyComboBox.Items.Add("Funt Brytyjski");

            this.CurrencyComboBox.SelectedIndex = 0;

            // Set add money value combobox
            this.TakeOutMoneyValueComboBox.Items.Add("50");
            this.TakeOutMoneyValueComboBox.Items.Add("100");
            this.TakeOutMoneyValueComboBox.Items.Add("200");
            this.TakeOutMoneyValueComboBox.Items.Add("500");
            this.TakeOutMoneyValueComboBox.Items.Add("1 000");

            this.TakeOutMoneyValueComboBox.SelectedIndex = 0;
        }
        private void BasicUserTakeOutMoneyPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Safe close
            this.basicUserPanel.Dispose();
            this.loginPanel.Close();
        }

        private void ExitToBasicUserPanelButton_Click(object sender, EventArgs e)
        {
            // Redirect to basic user panel
            this.basicUserPanel.Show();
            this.Dispose();
        }

        private void TakeOutMoneyButton_Click(object sender, EventArgs e)
        {
            // Take out money process
            string takeOutMoneyResult = "Transakcja Przeprowadzona \nPomyślnie";
            Currency exchangeRateCurrency = Currency.PLN;
            decimal exchangeRate = 0.0M;
            decimal takeOutMoneyValue = 0.0M;

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

            // Get information about take out money value
            switch (this.TakeOutMoneyValueComboBox.SelectedIndex)
            {
                case 0:
                    {
                        takeOutMoneyValue = 50.0M;
                    }
                    break;
                case 1:
                    {
                        takeOutMoneyValue = 100.0M;
                    }
                    break;
                case 2:
                    {
                        takeOutMoneyValue = 200.0M;
                    }
                    break;
                case 3:
                    {
                        takeOutMoneyValue = 500.0M;
                    }
                    break;
                case 4:
                    {
                        takeOutMoneyValue = 1000.0M;
                    }
                    break;
            }

            // Take out money
            try
            {
                basicUser._BankAccount.TakeOutMoney(currencyRate: exchangeRate,
                    new MoneyVAL(value: takeOutMoneyValue,
                    currency: exchangeRateCurrency), user: this.basicUser);
            }
            catch (BankAccount_Exception b_e)
            {
                takeOutMoneyResult = b_e.What();
            }

            // Check report type
            if (this.TakeOutMoneyReportCheckBox.Checked == false)
            {
                // redirect to basic user take out money execute panel
                BasicUserTakeOutMoneyExecutePanelVM basicUserTakeOutMoneyExecutePanelVM =
                    new BasicUserTakeOutMoneyExecutePanelVM
                    {
                        takeOutMoneyResult = takeOutMoneyResult
                    };

                BasicUserTakeOutMoneyExecutePanel basicUserTakeOutMoneyExecutePanel =
                    new BasicUserTakeOutMoneyExecutePanel(
                        basicUserTakeOutMoneyExecutePanelVM);

                basicUserTakeOutMoneyExecutePanel.ShowDialog();
            }
            else
            {
                // TODO redirect to basic user take out money report panel
            }
        }
    }
}
