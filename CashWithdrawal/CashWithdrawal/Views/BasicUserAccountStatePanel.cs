using cashDispenserLibrary.Data;
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
    public partial class BasicUserAccountStatePanel : Form
    {
        private LoginPanel loginPanel;
        private BasicUserPanel basicUserPanel;
        private BasicUser basicUser;

        private Currency presentedCurrencyMode;
        private decimal presentedAccountState;

        public BasicUserAccountStatePanel(
            BasicUserAccountStatePanelVM basicUserAccountStatePanelVM)
        {
            InitializeComponent();

            // Set login panel information
            this.loginPanel = basicUserAccountStatePanelVM.loginPanel;

            // Set basic user panel information
            this.basicUserPanel = basicUserAccountStatePanelVM.basicUserPanel;

            // Set basic user information
            this.basicUser = basicUserAccountStatePanelVM.basicUser;

            // Set form's text
            this.Text = $"Panel Stanu Konta {basicUser._Name._Value} " +
                $"{basicUser._Surname._Value}";

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

            // Set account state information
            this.AccountStateValueLabel.Text =
                basicUser._BankAccount.state._Value.ToString(new CultureInfo("en-US"));
        }
        private void BasicUserAccountStatePanel_FormClosing(
            object sender, FormClosingEventArgs e)
        {
            basicUserPanel.Close();
            loginPanel.Close();
        }

        private void PLN_ExchangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Set presented currency data
            presentedAccountState = (basicUser._BankAccount.state._Value /
                CashWithdrawalProperties.exchangeRates.PLN_exchangeRate);
            presentedCurrencyMode = Currency.PLN;

            // Show presented currency information
            AccountStateValueLabel.Text =
                (String.Format("{0:0.00}", presentedAccountState)).
                ToString(new CultureInfo("en-US"));
        }

        private void USD_ExchangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Set presented currency data
            presentedAccountState = (basicUser._BankAccount.state._Value /
                CashWithdrawalProperties.exchangeRates.USD_exchangeRate);
            presentedCurrencyMode = Currency.USD;

            // Show presented currency information
            AccountStateValueLabel.Text =
                (String.Format("{0:0.00}", presentedAccountState)).
                ToString(new CultureInfo("en-US"));
        }

        private void EUR_ExchangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Set presented currency data
            presentedAccountState = (basicUser._BankAccount.state._Value /
                CashWithdrawalProperties.exchangeRates.EUR_exchangeRate);
            presentedCurrencyMode = Currency.EUR;

            // Show presented currency information
            AccountStateValueLabel.Text =
                (String.Format("{0:0.00}", presentedAccountState)).
                ToString(new CultureInfo("en-US"));
        }

        private void GBP_ExchangeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Set presented currency data
            presentedAccountState = (basicUser._BankAccount.state._Value /
                CashWithdrawalProperties.exchangeRates.GBP_exchangeRate);
            presentedCurrencyMode = Currency.GBP;

            // Show presented currency information
            AccountStateValueLabel.Text =
                (String.Format("{0:0.00}", presentedAccountState)).
                ToString(new CultureInfo("en-US"));
        }

        private void ExitToBasicUserPanelButton_Click(object sender, EventArgs e)
        {
            // Redirect to basic user panel
            this.basicUserPanel.Show();
            this.Dispose();
        }

        private void BasicUserAccountStateReportPanelButton_Click(object sender, EventArgs e)
        {
            // redirect to basic user account state report panel
            BasicUserAccountStateReportPanelVM basicUserAccountStateReportPanelVM =
                new BasicUserAccountStateReportPanelVM
                {
                    currency = presentedCurrencyMode,
                    accountState = presentedAccountState
                };

            BasicUserAccountStateReportPanel basicUserAccountStateReportPanel =
                new BasicUserAccountStateReportPanel(basicUserAccountStateReportPanelVM);

            basicUserAccountStateReportPanel.ShowDialog();
        }
    }
}
