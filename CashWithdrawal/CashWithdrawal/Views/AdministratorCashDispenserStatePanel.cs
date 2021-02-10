using cashDispenserLibrary.Data;
using cashDispenserLibrary.Model;
using cashDispenserLibrary.Model.Exceptions;
using cashDispenserLibrary.Model.MockPhysicalMoneyRepository;
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
    public partial class AdministratorCashDispenserStatePanel : Form
    {
        private LoginPanel loginPanel;
        private AdministratorPanel administratorPanel;
        private decimal cashDispenserStateInPlnCurrency;

        public AdministratorCashDispenserStatePanel(
            AdministratorCashDispenserStatePanelVM administratorCashDispenserStatePanelVM)
        {
            InitializeComponent();

            // Set login panel information
            this.loginPanel = administratorCashDispenserStatePanelVM.loginPanel;

            // Set administrator manage basic users panel information
            this.administratorPanel =
                administratorCashDispenserStatePanelVM.administratorPanel;


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

            // Set cash dispenser state information
            try
            {
                // Connect with database
                MockPhysicalMoneyRepository mockPhysicalMoneyRepository =
                    new MockPhysicalMoneyRepository(SystemSettings._PlatformType);

                // Get physical money in all currency
                this.cashDispenserStateInPlnCurrency =
                     mockPhysicalMoneyRepository.GetInCurrency(
                         currencyRate: CashWithdrawalProperties.exchangeRates.PLN_exchangeRate,
                         currency: Currency.PLN)._Value;

                // Show physical money in default currency
                this.CashDispenserStateValueLabel.Text =
                    (String.Format("{0:0.00}",
                    cashDispenserStateInPlnCurrency));
            }
            catch (MockPhysicalMoneyRepository_Exception mpmr_e)
            {
            }
        }

        private void AdministratorCashDispenserStatePanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Safe close
            this.Dispose();
            this.administratorPanel.Dispose();
            this.loginPanel.Close();
        }

        private void PLN_CurrencyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Show cash dispenser state in PLN currency
            this.CashDispenserStateValueLabel.Text =
                (String.Format("{0:0.00}", (this.cashDispenserStateInPlnCurrency
                / CashWithdrawalProperties.exchangeRates.PLN_exchangeRate)).ToString(
                    new CultureInfo("en-US")));
        }

        private void USD_CurrencyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Show cash dispenser state in USD currency
            this.CashDispenserStateValueLabel.Text =
                (String.Format("{0:0.00}", (this.cashDispenserStateInPlnCurrency
                / CashWithdrawalProperties.exchangeRates.USD_exchangeRate)).ToString(
                    new CultureInfo("en-US")));
        }

        private void EUR_CurrencyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Show cash dispenser state in EUR currency
            this.CashDispenserStateValueLabel.Text =
                (String.Format("{0:0.00}", (this.cashDispenserStateInPlnCurrency
                / CashWithdrawalProperties.exchangeRates.EUR_exchangeRate)).ToString(
                    new CultureInfo("en-US")));
        }

        private void GBP_CurrencyRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // Show cash dispenser state in PLN currency
            this.CashDispenserStateValueLabel.Text =
                (String.Format("{0:0.00}", (this.cashDispenserStateInPlnCurrency
                / CashWithdrawalProperties.exchangeRates.GBP_exchangeRate)).ToString(
                    new CultureInfo("en-US")));
        }

        private void ExitToAdministratorPanelButton_Click(object sender, EventArgs e)
        {
            // Redirect to administrator panel
            this.administratorPanel.Show();
            this.Dispose();
        }

        private void ChangeCashDispenserStatePanelButton_Click(object sender, EventArgs e)
        {
            // Redirect to change cash dispenser state panel
            AdministratorChangeCashDispenserStatePanelVM
                administratorChangeCashDispenserStatePanelVM = new
                AdministratorChangeCashDispenserStatePanelVM
                {
                    loginPanel = this.loginPanel,
                    AdministratorPanel = this.administratorPanel,
                    administratorCashDispenserStatePanel = this,
                    cashDispenserStateInPlnCurrency = this.cashDispenserStateInPlnCurrency
                };

            AdministratorChangeCashDispenserStatePanel
                administratorChangeCashDispenserStatePanel = new
                AdministratorChangeCashDispenserStatePanel(
                    administratorChangeCashDispenserStatePanelVM);

            this.Hide();
            administratorChangeCashDispenserStatePanel.Show();
        }
    }
}
